#!/usr/bin/env bash
set -e

python packages/Be.Vlaanderen.Basisregisters.Build.Pipeline/Content/ci-md2conf.py CHANGELOG.md VBR \
    --user "${CONFLUENCE_USERNAME}" \
    --password "${CONFLUENCE_PASSWORD}" \
    --orgname "vlaamseoverheid" \
    --title "${CIRCLE_PROJECT_REPONAME}" \
    --ancestor "Changelog" \
    --nogo
