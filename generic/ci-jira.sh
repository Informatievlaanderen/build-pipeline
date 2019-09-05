#!/usr/bin/env bash
set -e

python packages/Be.Vlaanderen.Basisregisters.Build.Pipeline/Content/ci-jiraversion.py ${JIRA_PREFIX}-${JIRA_VERSION} ${JIRA_PROJECT} \
    --user "${CONFLUENCE_USERNAME}" \
    --password "${CONFLUENCE_PASSWORD}" \
    --orgname "vlaamseoverheid"
