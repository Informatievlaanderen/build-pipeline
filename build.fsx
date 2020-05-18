#r "paket:
framework: netstandard20
source https://api.nuget.org/v3/index.json
nuget Fake.Core.Target
nuget Fake.Core.Environment
nuget Fake.DotNet.Paket
nuget Fake.IO.FileSystem //"

open System.IO

open Fake.Core
open Fake.Core.TargetOperators
open Fake.DotNet
open Fake.IO.FileSystemOperators

let currentDirectory = Directory.GetCurrentDirectory()
let buildNumber = Environment.environVarOrDefault "BITBUCKET_BUILD_NUMBER" "0.0.1"
let buildDir = Environment.environVarOrDefault "BUILD_STAGINGDIRECTORY" (currentDirectory @@ "dist")

Target.create "Lib_Pack" (fun _ ->
  Paket.pack(fun p ->
    { p with
        ToolType = ToolType.CreateLocalTool()
        OutputPath = buildDir @@ "Be.Vlaanderen.Basisregisters.Build.Pipeline"
        Version = buildNumber
    }
  )
)

Target.create "PackageAll" ignore

"Lib_Pack" ==> "PackageAll"

Target.runOrDefault "Lib_Pack"
