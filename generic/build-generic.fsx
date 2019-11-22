#I "../../Newtonsoft.Json/lib/net45"
#r "Newtonsoft.Json.dll"

open Fake.Core
open Fake.Core.TargetOperators
open Fake.IO
open Fake.IO.FileSystemOperators
open Fake.DotNet
open Fake.JavaScript

open System
open System.IO
open Newtonsoft.Json.Linq

Target.initEnvironment()

let currentDirectory = Directory.GetCurrentDirectory()
let buildNumber = Environment.environVarOrDefault "BITBUCKET_BUILD_NUMBER" "0.0.0"
let gitHash = Environment.environVarOrDefault "BITBUCKET_COMMIT" ""
let buildDir = Environment.environVarOrDefault "BUILD_STAGINGDIRECTORY" (currentDirectory @@ "dist")
let dockerRegistry = Environment.environVarOrDefault "BUILD_DOCKER_REGISTRY" "dev.local"

let mutable customDotnetExePath : Option<string> = None

let getDotnetExePath defaultPath : string =
  match customDotnetExePath with
  | None -> defaultPath
  | Some dotnetExePath -> Path.GetDirectoryName dotnetExePath

let getDotNetClrVersionFromGlobalJson() : string =
    if not (File.Exists "global.json") then
        failwithf "global.json not found"
    try
        let content = File.ReadAllText "global.json"
        let json = JObject.Parse content
        let sdk = json.Item("clr") :?> JObject
        let version = sdk.Property("version").Value.ToString()
        version
    with
    | exn -> failwithf "Could not parse global.json: %s" exn.Message

let determineInstalledFxVersion () =
  printfn "Determining CLR Version using %s" (getDotnetExePath "dotnet")

  let clrVersion =
    try
      let dotnetCommand = getDotnetExePath "dotnet"

      ["--list-runtimes"]
      |> CreateProcess.fromRawCommand dotnetCommand
      |> CreateProcess.withWorkingDirectory Environment.CurrentDirectory
      |> CreateProcess.withTimeout (TimeSpan.FromMinutes 30.)
      |> CreateProcess.redirectOutput
      |> Proc.run
      |> fun output -> output.Result.Output.Split([|  Environment.NewLine |], StringSplitOptions.None)
      |> Seq.filter (fun line -> line.Contains("Microsoft.NETCore.App"))
      |> Seq.map (fun line -> line.Split([| " " |], StringSplitOptions.None).[1].Trim())
      |> Seq.sortDescending
      |> Seq.head
    with
      | _ -> "0.0.0"

  printfn "Determined CLR Version: %s" clrVersion
  clrVersion

let determineInstalledSdkVersion () =
  printfn "Determining SDK Version using %s" (getDotnetExePath "dotnet")

  let sdkVersion =
    try
      let dotnetCommand = getDotnetExePath "dotnet"

      ["--list-sdks"]
      |> CreateProcess.fromRawCommand dotnetCommand
      |> CreateProcess.withWorkingDirectory Environment.CurrentDirectory
      |> CreateProcess.withTimeout (TimeSpan.FromMinutes 30.)
      |> CreateProcess.redirectOutput
      |> Proc.run
      |> fun output -> output.Result.Output.Split([|  Environment.NewLine |], StringSplitOptions.None)
      |> Seq.map (fun line -> line.Split([| " " |], StringSplitOptions.None).[0].Trim())
      |> Seq.sortDescending
      |> Seq.head
    with
      | _ -> "0.0.0"

  printfn "Determined SDK Version: %s" sdkVersion
  sdkVersion

let setCommonOptions (dotnet: DotNet.Options) =
  { dotnet with DotNetCliPath = getDotnetExePath dotnet.DotNetCliPath }

let merge a b =
  a @ b |> List.distinct

let addVersionArguments version args =
  let versionArgs =
    [
      "AssemblyVersion", version
      "FileVersion", version
      "InformationalVersion", version
      "PackageVersion", version
    ]
  merge args versionArgs

let addRuntimeFrameworkVersion args =
  let fxVersion = getDotNetClrVersionFromGlobalJson()
  let runtimeFrameworkVersionArgs = ["RuntimeFrameworkVersion", fxVersion]
  merge args runtimeFrameworkVersionArgs

let testWithDotNet path =
  let setMsBuildParams (msbuild: MSBuild.CliArguments) =
    { msbuild with Properties = List.empty |> addRuntimeFrameworkVersion }

  DotNet.test (fun p ->
  { p with
      Common = setCommonOptions p.Common
      Configuration = DotNet.Release
      NoBuild = true
      NoRestore = true
      Logger = Some "trx"
      MSBuildParams = setMsBuildParams p.MSBuildParams
  }) path

let test project =
  testWithDotNet ("test" @@ project @@ (sprintf "%s.csproj" project))

let testSolution sln =
  testWithDotNet (sprintf "%s.sln" sln)

let setSolutionVersions formatAssemblyVersion product copyright company x =
  AssemblyInfoFile.createCSharp x
      [AssemblyInfo.Version (formatAssemblyVersion buildNumber)
       AssemblyInfo.FileVersion (formatAssemblyVersion buildNumber)
       AssemblyInfo.InformationalVersion gitHash
       AssemblyInfo.Product product
       AssemblyInfo.Copyright copyright
       AssemblyInfo.Company company]

let buildNeutral formatAssemblyVersion x =
  let setMsBuildParams (msbuild: MSBuild.CliArguments) =
    { msbuild with Properties = List.empty |> addRuntimeFrameworkVersion |> addVersionArguments (formatAssemblyVersion buildNumber) }

  DotNet.build (fun p ->
  { p with
      Common = setCommonOptions p.Common
      Configuration = DotNet.Release
      NoRestore = true
      MSBuildParams = setMsBuildParams p.MSBuildParams
  }) x

  DotNet.build (fun p ->
  { p with
      Common = setCommonOptions p.Common
      Configuration = DotNet.Release
      NoRestore = true
      Runtime = Some "linux-x64"
      MSBuildParams = setMsBuildParams p.MSBuildParams
  }) x

  DotNet.build (fun p ->
  { p with
      Common = setCommonOptions p.Common
      Configuration = DotNet.Release
      NoRestore = true
      Runtime = Some "win-x64"
      MSBuildParams = setMsBuildParams p.MSBuildParams
  }) x

let build formatAssemblyVersion project =
  buildNeutral formatAssemblyVersion ("src" @@ project @@ (sprintf "%s.csproj" project))

let buildTest formatAssemblyVersion project =
  buildNeutral formatAssemblyVersion ("test" @@ project @@ (sprintf "%s.csproj" project))

let buildSolution formatAssemblyVersion sln =
  buildNeutral formatAssemblyVersion (sprintf "%s.sln" sln)

let publish formatAssemblyVersion project =
  let setMsBuildParams (msbuild: MSBuild.CliArguments) =
    { msbuild with Properties = List.empty |> addRuntimeFrameworkVersion |> addVersionArguments (formatAssemblyVersion buildNumber) }

  DotNet.publish (fun p ->
  { p with
      Common = setCommonOptions p.Common
      Configuration = DotNet.Release
      NoBuild = true
      NoRestore = true
      Runtime = Some "linux-x64"
      SelfContained = Some true
      OutputPath = Some (buildDir @@ project @@ "linux")
      MSBuildParams = setMsBuildParams p.MSBuildParams
  }) ("src" @@ project @@ (sprintf "%s.csproj" project))

  DotNet.publish (fun p ->
  { p with
      Common = setCommonOptions p.Common
      Configuration = DotNet.Release
      NoBuild = true
      NoRestore = true
      Runtime = Some "win-x64"
      SelfContained = Some true
      OutputPath = Some (buildDir @@ project @@ "win")
      MSBuildParams = setMsBuildParams p.MSBuildParams
  }) ("src" @@ project @@ (sprintf "%s.csproj" project))

let publishSolution formatAssemblyVersion sln =
  let setMsBuildParams (msbuild: MSBuild.CliArguments) runtimeIdentifier publishDir =
    { msbuild with
        MaxCpuCount = Some (Some 1)
        Targets = ["Publish"]
        Properties = [
          "NoBuild", "true"
          "SelfContained", "true"
          "configuration", "Release"
          "RuntimeIdentifier", runtimeIdentifier
          "PublishDir", publishDir
        ] |> addRuntimeFrameworkVersion |> addVersionArguments (formatAssemblyVersion buildNumber)
    }

  DotNet.msbuild (fun p ->
  { p with
      Common = setCommonOptions p.Common
      MSBuildParams = setMsBuildParams p.MSBuildParams "linux-x64" (buildDir @@ sln @@ "linux")
  }) (sprintf "%s.sln" sln)

  DotNet.msbuild (fun p ->
  { p with
      Common = setCommonOptions p.Common
      MSBuildParams = setMsBuildParams p.MSBuildParams "win-x64" (buildDir @@ sln @@ "win")
  }) (sprintf "%s.sln" sln)

let containerize dockerRepository project containerName =
  let result1 =
    [ "build"; "--no-cache"; "--tag"; sprintf "%s/%s/%s:%s" dockerRegistry dockerRepository containerName buildNumber; "."]
    |> CreateProcess.fromRawCommand "docker"
    |> CreateProcess.withWorkingDirectory (buildDir @@ project @@ "linux")
    |> CreateProcess.withTimeout (TimeSpan.FromMinutes 5.)
    |> Proc.run

  if result1.ExitCode <> 0 then failwith "Failed result from Docker Build"

  let result2 =
    [ "tag"; sprintf "%s/%s/%s:%s" dockerRegistry dockerRepository containerName buildNumber; sprintf "%s/%s/%s:latest" dockerRegistry dockerRepository containerName]
    |> CreateProcess.fromRawCommand "docker"
    |> CreateProcess.withTimeout (TimeSpan.FromMinutes 5.)
    |> Proc.run

  if result2.ExitCode <> 0 then failwith "Failed result from Docker Tag"

let push dockerRepository containerName =
  let result1 =
    [ "push"; sprintf "%s/%s/%s:%s" dockerRegistry dockerRepository containerName buildNumber]
    |> CreateProcess.fromRawCommand "docker"
    |> CreateProcess.withTimeout (TimeSpan.FromMinutes 5.)
    |> Proc.run

  if result1.ExitCode <> 0 then failwith "Failed result from Docker Push"

  let result2 =
    [ "push"; sprintf "%s/%s/%s:latest" dockerRegistry dockerRepository containerName]
    |> CreateProcess.fromRawCommand "docker"
    |> CreateProcess.withTimeout (TimeSpan.FromMinutes 5.)
    |> Proc.run

  if result2.ExitCode <> 0 then failwith "Failed result from Docker Push Latest"

let pack formatNugetVersion project =
  let nugetVersion = formatNugetVersion buildNumber
  Paket.pack(fun p ->
    { p with
        ToolType = ToolType.CreateLocalTool() 
        BuildConfig = "Release"
        OutputPath = buildDir @@ "nuget"
        Version = nugetVersion
        WorkingDir = buildDir @@ project @@ "win"
        TemplateFile = buildDir @@ project @@ "win" @@ "paket.template"
    }
  )

let packSolution formatNugetVersion sln =
  let nugetVersion = formatNugetVersion buildNumber
  Paket.pack(fun p ->
    { p with
        ToolType = ToolType.CreateLocalTool() 
        BuildConfig = "Release"
        OutputPath = buildDir @@ sln
        Version = nugetVersion
    }
  )

Target.create "DotNetCli" (fun _ ->
  let desiredFxVersion = getDotNetClrVersionFromGlobalJson()
  let mutable installedFxVersion = determineInstalledFxVersion()
  let desiredSdkVersion = DotNet.getSDKVersionFromGlobalJson()
  let mutable installedSdkVersion = determineInstalledSdkVersion()

  if desiredSdkVersion <> installedSdkVersion then
    printfn "Invalid SDK Version, Desired: %s Installed: %s" desiredSdkVersion installedSdkVersion

    let install = DotNet.install (fun p ->
      { p with
          Version = DotNet.getSDKVersionFromGlobalJson() |> DotNet.Version
      })

    let installOptions = DotNet.Options.Create() |> install

    customDotnetExePath <- Some installOptions.DotNetCliPath
    installedFxVersion <- determineInstalledFxVersion()
    installedSdkVersion <- determineInstalledSdkVersion()
    printfn "Custom SDK Path: %s" customDotnetExePath.Value

  if desiredFxVersion > installedFxVersion then
    failwithf "Invalid CLR Version, Desired: %s Installed: %s" desiredFxVersion installedFxVersion

  printfn ".NET Core CLR Version, Desired: %s Installed: %s" desiredFxVersion installedFxVersion
  printfn ".NET Core SDK Version, Desired: %s Installed: %s" desiredSdkVersion installedSdkVersion
)

Target.create "Clean" (fun _ -> Shell.cleanDir buildDir)

let restore sln =
  let fxVersion = getDotNetClrVersionFromGlobalJson()
  let dotnetCommand = getDotnetExePath "dotnet"

  let restore =
    ["restore"; (sprintf "-p:RuntimeFrameworkVersion=%s" fxVersion); (sprintf "%s.sln" sln)]
    |> CreateProcess.fromRawCommand dotnetCommand
    |> CreateProcess.withWorkingDirectory Environment.CurrentDirectory
    |> CreateProcess.withTimeout (TimeSpan.FromMinutes 30.)
    |> CreateProcess.redirectOutput
    |> Proc.run

  if restore.ExitCode <> 0 then failwith "Failed result from SLN Restore"

Target.create "Restore" (fun _ ->
  let fxVersion = getDotNetClrVersionFromGlobalJson()
  let dotnetCommand = getDotnetExePath "dotnet"

  let restore =
    ["restore"; (sprintf "-p:RuntimeFrameworkVersion=%s" fxVersion)]
    |> CreateProcess.fromRawCommand dotnetCommand
    |> CreateProcess.withWorkingDirectory Environment.CurrentDirectory
    |> CreateProcess.withTimeout (TimeSpan.FromMinutes 30.)
    |> CreateProcess.redirectOutput
    |> Proc.run

  if restore.ExitCode <> 0 then failwith "Failed result from Restore"
)

Target.create "NpmInstall" (fun _ ->
  Npm.install |> ignore
)

Target.create "DockerLogin" (fun _ ->
  let dockerLogin =
    [ "packages/Be.Vlaanderen.Basisregisters.Build.Pipeline/Content/ci-docker-login.sh"]
    |> CreateProcess.fromRawCommand "bash"
    |> CreateProcess.withTimeout (TimeSpan.FromMinutes 5.)
    |> Proc.run

  if dockerLogin.ExitCode <> 0 then failwith "Failed result from Docker Login"
)
