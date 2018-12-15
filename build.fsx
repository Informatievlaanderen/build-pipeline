#r "packages/FAKE/tools/FakeLib.dll"

open Fake

let buildNumber = environVarOrDefault "BITBUCKET_BUILD_NUMBER" "0.0.1"
let buildDir = environVarOrDefault "BUILD_STAGINGDIRECTORY" (currentDirectory @@ "dist")

Target "Lib_Pack" (fun _ ->
  Paket.Pack(fun p ->
  { p with
      OutputPath = buildDir @@ "Be.Vlaanderen.Basisregisters.Build.Pipeline"
      Version = buildNumber
  })
)

RunTargetOrDefault "Lib_Pack"
