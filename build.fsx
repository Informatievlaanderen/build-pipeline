#r "paket:
framework: net6.0
source https://api.nuget.org/v3/index.json

nuget Microsoft.Build 17.3.2
nuget Microsoft.Build.Framework 17.3.2
nuget Microsoft.Build.Tasks.Core 17.3.2
nuget Microsoft.Build.Utilities.Core 17.3.2
nuget FSharp.Core ~> 6.0

nuget Fake.Core.Target
nuget Fake.Core.Environment
nuget Fake.DotNet.Paket
nuget Fake.IO.FileSystem //"

open System.IO

open Fake.Core
open Fake.DotNet
open Fake.IO.FileSystemOperators

let currentDirectory = Directory.GetCurrentDirectory()
let buildNumber = Environment.environVarOrDefault "CI_BUILD_NUMBER" "0.0.1"
let buildDir = Environment.environVarOrDefault "BUILD_STAGINGDIRECTORY" (currentDirectory @@ "dist")

Target.create "PackageAll" (fun _ ->
  Paket.pack(fun p ->
    { p with
        ToolType = ToolType.CreateLocalTool()
        OutputPath = buildDir @@ "Be.Vlaanderen.Basisregisters.Build.Pipeline"
        Version = buildNumber
    }
  )
)

Target.runOrDefault "PackageAll"
