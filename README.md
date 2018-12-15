# build-pipeline

## build.sh

```bash
run $PAKET_EXE restore

chmod +x packages/Be.Vlaanderen.Basisregisters.Build.Pipeline/Content/*

run $FAKE_EXE build.fsx "$@"
```

## build.fsx

```
#load "packages/Be.Vlaanderen.Basisregisters.Build.Pipeline/Content/build-generic.fsx"

open Fake
open ``Build-generic``
```

## package.json

```
{
    "path": "@semantic-release/exec",
    "cmd": "node packages/Be.Vlaanderen.Basisregisters.Build.Pipeline/Content/ci-myget.js dist/Be.Vlaanderen.Basisregisters.AggregateSource/Be.Vlaanderen.Basisregisters.AggregateSource.${nextRelease.version}.nupkg"
},

{
    "path": "@semantic-release/exec",
    "cmd": "./packages/Be.Vlaanderen.Basisregisters.Build.Pipeline/Content/ci-bitbucket.sh dist/Be.Vlaanderen.Basisregisters.AggregateSource/Be.Vlaanderen.Basisregisters.AggregateSource.SqlStreamStore.${nextRelease.version}.nupkg"
},

{
    "path": "@semantic-release/exec",
    "cmd": "./packages/Be.Vlaanderen.Basisregisters.Build.Pipeline/Content/ci-confluence.sh"
}
```
