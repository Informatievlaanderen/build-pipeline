# build-pipeline [![Build Status](https://github.com/Informatievlaanderen/build-pipeline/workflows/CI/badge.svg)](https://github.com/Informatievlaanderen/build-pipeline/actions)

## build.sh

```bash
#!/usr/bin/env bash
set -e

dotnet tool restore
dotnet paket restore

if [ $# -eq 0 ]
then
  FAKE_ALLOW_NO_DEPENDENCIES=true dotnet fake build
else
  FAKE_ALLOW_NO_DEPENDENCIES=true dotnet fake build -t "$@"
fi
```

## build.fsx

```bash
#load "packages/Be.Vlaanderen.Basisregisters.Build.Pipeline/Content/build-generic.fsx"

open Fake
open ``Build-generic``
```

## package.json

```json
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
