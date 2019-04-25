#I "../../FAKE/tools"
#r "FakeLib.dll"

#I "../../Newtonsoft.Json/lib/net45"
#r "Newtonsoft.Json.dll"

open Fake
open Fake.NpmHelper
open System
open System.IO
open Newtonsoft.Json.Linq

let buildNumber = environVarOrDefault "BITBUCKET_BUILD_NUMBER" "0"
let buildDir = environVarOrDefault "BUILD_STAGINGDIRECTORY" (currentDirectory @@ "dist")
let dockerRegistry = environVarOrDefault "BUILD_DOCKER_REGISTRY" "dev.local"

let mutable customDotnetExePath : Option<string> = None

let getDotNetClrVersionFromGlobalJson() : string =
    if not (File.Exists "global.json") then
        failwithf "global.json not found"
    try
        let content = File.ReadAllText "global.json"
        let json = Newtonsoft.Json.Linq.JObject.Parse content
        let sdk = json.Item("clr") :?> JObject
        let version = sdk.Property("version").Value.ToString()
        version
    with
    | exn -> failwithf "Could not parse global.json: %s" exn.Message

let determineInstalledFxVersion () =
  printfn "Determining CLR Version using %s" (match customDotnetExePath with
                                              | None -> Environment.CurrentDirectory
                                              | Some dotnetExePath -> Path.GetDirectoryName dotnetExePath)

  let clrVersion =
    try
      ExecProcessAndReturnMessages (fun info ->
        info.FileName <- match customDotnetExePath with
                                  | None -> "dotnet"
                                  | Some dotnetExePath -> dotnetExePath
        info.WorkingDirectory <- Environment.CurrentDirectory
        info.Arguments <- "--list-runtimes") (TimeSpan.FromMinutes 30.)
      |> fun output -> output.Messages
      |> Seq.filter (fun line -> line.Contains("Microsoft.NETCore.App"))
      |> Seq.map (fun line -> line.Split([| " " |], StringSplitOptions.None).[1].Trim())
      |> Seq.sortDescending
      |> Seq.head
    with
      | _ -> "0.0.0"

  printfn "Determined CLR Version: %s" clrVersion
  clrVersion

let determineInstalledSdkVersion () =
  printfn "Determining SDK Version using %s" (match customDotnetExePath with
                                              | None -> Environment.CurrentDirectory
                                              | Some dotnetExePath -> Path.GetDirectoryName dotnetExePath)

  let sdkVersion =
    try
      ExecProcessAndReturnMessages (fun info ->
        info.FileName <- match customDotnetExePath with
                                  | None -> "dotnet"
                                  | Some dotnetExePath -> dotnetExePath
        info.WorkingDirectory <- Environment.CurrentDirectory
        info.Arguments <- "--list-sdks") (TimeSpan.FromMinutes 30.)
      |> fun output -> output.Messages
      |> Seq.map (fun line -> line.Split([| " " |], StringSplitOptions.None).[0].Trim())
      |> Seq.sortDescending
      |> Seq.head
    with
      | _ -> "0.0.0"

  printfn "Determined SDK Version: %s" sdkVersion
  sdkVersion

let addVersionArguments version args =
  [|
    "-p:AssemblyVersion=%s"
    "-p:FileVersion=%s"
    "-p:InformationalVersion=%s"
    "-p:PackageVersion=%s"
  |]
  |> Seq.map (fun parameterFormat -> sprintf (PrintfFormat<_,_,_,_> parameterFormat) version)
  |> Seq.append args
  |> Seq.toList

let addRuntimeFrameworkVersion args =
  let fxVersion = getDotNetClrVersionFromGlobalJson()
  [|
    (sprintf "-p:RuntimeFrameworkVersion=%s" fxVersion)
  |]
  |> Seq.append args
  |> Seq.toList

let testWithXunit path =
  let fxVersion = getDotNetClrVersionFromGlobalJson()
  DotNetCli.RunCommand
    (fun p ->
       { p with
          ToolPath =
            match customDotnetExePath with
            | None -> p.ToolPath
            | Some dotnetExePath -> dotnetExePath
          WorkingDir = path })
    (sprintf "xunit -nologo -verbose -configuration Release -xml test-results/TestResults.xml -parallel collections -fxversion %s" fxVersion)

let testWithDotNet path =
  DotNetCli.Test(fun p ->
  { p with
      ToolPath =
        match customDotnetExePath with
        | None -> p.ToolPath
        | Some dotnetExePath -> dotnetExePath
      Project = path
      AdditionalArgs = ["-l trx"; "--no-build"; "--no-restore"] |> addRuntimeFrameworkVersion
   })

let test project =
  testWithDotNet ("test" @@ project @@ (sprintf "%s.csproj" project))

let testSolution sln =
  testWithDotNet (sprintf "%s.sln" sln)

let buildNeutral formatAssemblyVersion x =
  DotNetCli.Build(fun p ->
  { p with
      ToolPath =
        match customDotnetExePath with
        | None -> p.ToolPath
        | Some dotnetExePath -> dotnetExePath
      Project = x
      Configuration = "Release"
      AdditionalArgs = ["--no-restore"] |> addRuntimeFrameworkVersion |> addVersionArguments (formatAssemblyVersion buildNumber)
  })

  DotNetCli.Build(fun p ->
  { p with
      ToolPath =
        match customDotnetExePath with
        | None -> p.ToolPath
        | Some dotnetExePath -> dotnetExePath
      Project = x
      Configuration = "Release"
      Runtime = "debian.8-x64"
      AdditionalArgs = ["--no-restore"] |> addRuntimeFrameworkVersion |> addVersionArguments (formatAssemblyVersion buildNumber)
  })

  DotNetCli.Build(fun p ->
  { p with
      ToolPath =
        match customDotnetExePath with
        | None -> p.ToolPath
        | Some dotnetExePath -> dotnetExePath
      Project = x
      Configuration = "Release"
      Runtime = "win10-x64"
      AdditionalArgs = ["--no-restore"] |> addRuntimeFrameworkVersion |> addVersionArguments (formatAssemblyVersion buildNumber)
  })

let build formatAssemblyVersion project =
  buildNeutral formatAssemblyVersion ("src" @@ project @@ (sprintf "%s.csproj" project))

let buildTest formatAssemblyVersion project =
  buildNeutral formatAssemblyVersion ("test" @@ project @@ (sprintf "%s.csproj" project))

let buildSolution formatAssemblyVersion sln =
  buildNeutral formatAssemblyVersion (sprintf "%s.sln" sln)

let publish formatAssemblyVersion project =
  DotNetCli.Publish(fun p ->
  { p with
      ToolPath =
        match customDotnetExePath with
        | None -> p.ToolPath
        | Some dotnetExePath -> dotnetExePath
      Project = "src" @@ project @@ (sprintf "%s.csproj" project)
      Configuration = "Release"
      Output = buildDir @@ project @@ "linux"
      Runtime = "debian.8-x64"
      AdditionalArgs = ["--no-build"; "--no-restore"; "--self-contained true"] |> addRuntimeFrameworkVersion |> addVersionArguments (formatAssemblyVersion buildNumber)
  })

  DotNetCli.Publish(fun p ->
  { p with
      ToolPath =
        match customDotnetExePath with
        | None -> p.ToolPath
        | Some dotnetExePath -> dotnetExePath
      Project = "src" @@ project @@ (sprintf "%s.csproj" project)
      Configuration = "Release"
      Output = buildDir @@ project @@ "win"
      Runtime = "win10-x64"
      AdditionalArgs =  ["--no-build"; "--no-restore"; "--self-contained true"] |> addRuntimeFrameworkVersion |> addVersionArguments (formatAssemblyVersion buildNumber)
  })

let publishSolution formatAssemblyVersion sln =
  DotNetCli.RunCommand(fun p ->
  { p with
      ToolPath =
        match customDotnetExePath with
        | None -> p.ToolPath
        | Some dotnetExePath -> dotnetExePath })
    (sprintf "msbuild %s -m:1 -target:Publish -restore:False -p:NoBuild=true -p:SelfContained=true -p:configuration=%s -p:RuntimeIdentifier=%s -p:PublishDir=%s %s %s"
      (sprintf "%s.sln" sln)
      "Release"
      "debian.8-x64"
      (buildDir @@ sln @@ "linux")
      (addRuntimeFrameworkVersion [] |> List.fold (+) " ")
      (addVersionArguments (formatAssemblyVersion buildNumber) [] |> List.fold (+) " "))

  // DotNetCli.Publish(fun p ->
  // { p with
  //     ToolPath =
  //       match customDotnetExePath with
  //       | None -> p.ToolPath
  //       | Some dotnetExePath -> dotnetExePath
  //     Project = (sprintf "%s.sln" sln)
  //     Configuration = "Release"
  //     Output = buildDir @@ sln @@ "linux"
  //     Runtime = "debian.8-x64"
  //     AdditionalArgs = ["--no-build"; "--no-restore"; "--self-contained true"] |> addRuntimeFrameworkVersion |> addVersionArguments (formatAssemblyVersion buildNumber)
  // })

  DotNetCli.RunCommand(fun p ->
  { p with
      ToolPath =
        match customDotnetExePath with
        | None -> p.ToolPath
        | Some dotnetExePath -> dotnetExePath })
    (sprintf "msbuild %s -m:1 -target:Publish -restore:False -p:NoBuild=true -p:SelfContained=true -p:configuration=%s -p:RuntimeIdentifier=%s -p:PublishDir=%s %s %s"
      (sprintf "%s.sln" sln)
      "Release"
      "win10-x64"
      (buildDir @@ sln @@ "win")
      (addRuntimeFrameworkVersion [] |> List.fold (+) " ")
      (addVersionArguments (formatAssemblyVersion buildNumber) [] |> List.fold (+) " "))

  // DotNetCli.Publish(fun p ->
  // { p with
  //     ToolPath =
  //       match customDotnetExePath with
  //       | None -> p.ToolPath
  //       | Some dotnetExePath -> dotnetExePath
  //     Project = (sprintf "%s.sln" sln)
  //     Configuration = "Release"
  //     Output = buildDir @@ sln @@ "win"
  //     Runtime = "win10-x64"
  //     AdditionalArgs =  ["--no-build"; "--no-restore"; "--self-contained true"] |> addRuntimeFrameworkVersion |> addVersionArguments (formatAssemblyVersion buildNumber)
  // })

let containerize dockerRepository project containerName =
  let result1 =
    ExecProcess (fun info ->
        info.FileName <- "docker"
        info.Arguments <- sprintf "build --no-cache --tag %s/%s/%s:%s ." dockerRegistry dockerRepository containerName buildNumber
        info.WorkingDirectory <- buildDir @@ project @@ "linux"
    ) (System.TimeSpan.FromMinutes 5.)

  if result1 <> 0 then failwith "Failed result from Docker Build"

  let result2 =
    ExecProcess (fun info ->
        info.FileName <- "docker"
        info.Arguments <- sprintf "tag %s/%s/%s:%s %s/%s/%s:latest" dockerRegistry dockerRepository containerName buildNumber dockerRegistry dockerRepository containerName
    ) (System.TimeSpan.FromMinutes 5.)

  if result2 <> 0 then failwith "Failed result from Docker Tag"

let push dockerRepository containerName =
  let result1 =
    ExecProcess (fun info ->
        info.FileName <- "docker"
        info.Arguments <- sprintf "push %s/%s/%s:%s" dockerRegistry dockerRepository containerName buildNumber
    ) (System.TimeSpan.FromMinutes 5.)

  if result1 <> 0 then failwith "Failed result from Docker Push"

  let result2 =
    ExecProcess (fun info ->
        info.FileName <- "docker"
        info.Arguments <- sprintf "push %s/%s/%s:latest" dockerRegistry dockerRepository containerName
    ) (System.TimeSpan.FromMinutes 5.)

  if result2 <> 0 then failwith "Failed result from Docker Push Latest"

let pack formatNugetVersion project =
  let nugetVersion = formatNugetVersion buildNumber
  Paket.Pack(fun p ->
    { p with
        BuildConfig = "Release"
        OutputPath = buildDir @@ "nuget"
        Version = nugetVersion
        WorkingDir = buildDir @@ project @@ "win"
        TemplateFile = buildDir @@ project @@ "win" @@ "paket.template"
    }
  )

let packSolution formatNugetVersion sln =
  let nugetVersion = formatNugetVersion buildNumber
  Paket.Pack(fun p ->
    { p with
        BuildConfig = "Release"
        OutputPath = buildDir @@ sln
        Version = nugetVersion
    }
  )

Target "DotNetCli" (fun _ ->
  let desiredFxVersion = getDotNetClrVersionFromGlobalJson()
  let mutable installedFxVersion = determineInstalledFxVersion()
  let desiredSdkVersion = DotNetCli.GetDotNetSDKVersionFromGlobalJson()
  let mutable installedSdkVersion = determineInstalledSdkVersion()

  if desiredSdkVersion <> installedSdkVersion then
    printfn "Invalid SDK Version, Desired: %s Installed: %s" desiredSdkVersion installedSdkVersion
    customDotnetExePath <- Some <| DotNetCli.InstallDotNetSDK(DotNetCli.GetDotNetSDKVersionFromGlobalJson())
    installedFxVersion <- determineInstalledFxVersion()
    installedSdkVersion <- determineInstalledSdkVersion()
    printfn "Custom SDK Path: %s" customDotnetExePath.Value

  if desiredFxVersion > installedFxVersion then
    failwithf "Invalid CLR Version, Desired: %s Installed: %s" desiredFxVersion installedFxVersion

  printfn ".NET Core CLR Version, Desired: %s Installed: %s" desiredFxVersion installedFxVersion
  printfn ".NET Core SDK Version, Desired: %s Installed: %s" desiredSdkVersion installedSdkVersion
)

Target "Clean" (fun _ -> CleanDir buildDir)

let restore sln =
  DotNetCli.Restore(fun p ->
  {
    p with
      ToolPath =
        match customDotnetExePath with
        | None -> p.ToolPath
        | Some dotnetExePath -> dotnetExePath
      Project = (sprintf "%s.sln" sln)
      AdditionalArgs = ["-r win10-x64"; "-r debian.8-x64" ] |> addRuntimeFrameworkVersion
  })

Target "Restore" (fun _ ->
  DotNetCli.Restore(fun p ->
  {
    p with
      ToolPath =
        match customDotnetExePath with
        | None -> p.ToolPath
        | Some dotnetExePath -> dotnetExePath
      AdditionalArgs = ["-r win10-x64"; "-r debian.8-x64" ] |> addRuntimeFrameworkVersion
  })
)

Target "NpmInstall" (fun _ ->
  Npm (fun p ->
  { p with
      Command = Install Standard
  })
 )

Target "DockerLogin" (fun _ ->
  let dockerLogin =
    ExecProcess (fun info ->
        info.FileName <- "bash"
        info.Arguments <- "packages/Be.Vlaanderen.Basisregisters.Build.Pipeline/Content/ci-docker-login.sh"
    ) (System.TimeSpan.FromMinutes 5.)

  if dockerLogin <> 0 then failwith "Failed result from Docker Login"
)
