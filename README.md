# build-pipeline [![Build Status](https://github.com/Informatievlaanderen/build-pipeline/workflows/CI/badge.svg)](https://github.com/Informatievlaanderen/build-pipeline/actions)

## Build actions

to-do

## Scripts

### pre-restore.sh

To install this package (`Be.Vlaanderen.Basisregisters.Build.Pipeline`) inside your repo before calling `dotnet restore`.

Example to install version 7.0.3
```shell
#!/bin/bash

bash <(curl -s https://raw.githubusercontent.com/Informatievlaanderen/build-pipeline/refs/heads/main/scripts/pre-restore.sh) 7.0.3
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
