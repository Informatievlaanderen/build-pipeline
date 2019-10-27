#!/usr/bin/env bash
set -e

dotnet tool restore
dotnet paket restore
FAKE_ALLOW_NO_DEPENDENCIES=true dotnet fake build "$@"
