# [1.8.0](https://github.com/Informatievlaanderen/build-pipeline/compare/v1.7.0...v1.8.0) (2019-08-30)


### Features

* do not generate assembly informational version automatically ([a6923d3](https://github.com/Informatievlaanderen/build-pipeline/commit/a6923d3))

# [1.7.0](https://github.com/Informatievlaanderen/build-pipeline/compare/v1.6.1...v1.7.0) (2019-08-21)


### Features

* bump to .net 2.2.6 ([3cac7f3](https://github.com/Informatievlaanderen/build-pipeline/commit/3cac7f3))

## [1.6.1](https://github.com/Informatievlaanderen/build-pipeline/compare/v1.6.0...v1.6.1) (2019-04-26)


### Bug Fixes

* escape commit messages for changelog ([2801b8a](https://github.com/Informatievlaanderen/build-pipeline/commit/2801b8a))

# [1.6.0](https://github.com/Informatievlaanderen/build-pipeline/compare/v1.5.0...v1.6.0) (2019-04-25)


### Features

* bump to .net core 2.2.4 ([2922779](https://github.com/Informatievlaanderen/build-pipeline/commit/2922779))

# [1.5.0](https://github.com/Informatievlaanderen/build-pipeline/compare/v1.4.0...v1.5.0) (2019-01-08)


### Features

* add testSolution function and Clear target ([1a5fd48](https://github.com/Informatievlaanderen/build-pipeline/commit/1a5fd48))

# [1.4.0](https://github.com/Informatievlaanderen/build-pipeline/compare/v1.3.0...v1.4.0) (2019-01-03)


### Features

* tag test projects to properly load Test Explorer in VS ([a718f06](https://github.com/Informatievlaanderen/build-pipeline/commit/a718f06))

# [1.3.0](https://github.com/Informatievlaanderen/build-pipeline/compare/v1.2.0...v1.3.0) (2019-01-02)


### Features

* add restore shorthand to restore for specific solutions ([58265b5](https://github.com/Informatievlaanderen/build-pipeline/commit/58265b5))

# [1.2.0](https://github.com/Informatievlaanderen/build-pipeline/compare/v1.1.6...v1.2.0) (2019-01-02)


### Features

* add buildTest shorthand to build projects in the test folder ([502a438](https://github.com/Informatievlaanderen/build-pipeline/commit/502a438))

## [1.1.6](https://github.com/Informatievlaanderen/build-pipeline/compare/v1.1.5...v1.1.6) (2018-12-30)

## [1.1.5](https://github.com/Informatievlaanderen/build-pipeline/compare/v1.1.4...v1.1.5) (2018-12-20)


### Bug Fixes

* no need to run build again for a publish, we have built before ([2d3f926](https://github.com/Informatievlaanderen/build-pipeline/commit/2d3f926))

## [1.1.4](https://github.com/Informatievlaanderen/build-pipeline/compare/v1.1.3...v1.1.4) (2018-12-19)


### Bug Fixes

* build runtime neutral as well to make tests work ([e387312](https://github.com/Informatievlaanderen/build-pipeline/commit/e387312))

## [1.1.3](https://github.com/Informatievlaanderen/build-pipeline/compare/v1.1.2...v1.1.3) (2018-12-19)


### Bug Fixes

* publish using only 1 cpu, slowing down but at least our CI server will not keep files locked ([071654b](https://github.com/Informatievlaanderen/build-pipeline/commit/071654b))

## [1.1.2](https://github.com/Informatievlaanderen/build-pipeline/compare/v1.1.1...v1.1.2) (2018-12-18)


### Bug Fixes

* nuget now requires an extra header to be sent x-nuget-client-version ([a1c4a62](https://github.com/Informatievlaanderen/build-pipeline/commit/a1c4a62))

## [1.1.1](https://github.com/Informatievlaanderen/build-pipeline/compare/v1.1.0...v1.1.1) (2018-12-18)


### Bug Fixes

* no need for nuget feed, it is always the root ([cb59148](https://github.com/Informatievlaanderen/build-pipeline/commit/cb59148))

# [1.1.0](https://github.com/Informatievlaanderen/build-pipeline/compare/v1.0.1...v1.1.0) (2018-12-18)


### Features

* add test properties and nuget push script ([35f1ad6](https://github.com/Informatievlaanderen/build-pipeline/commit/35f1ad6))

## [1.0.1](https://github.com/Informatievlaanderen/build-pipeline/compare/v1.0.0...v1.0.1) (2018-12-18)


### Bug Fixes

* dotnet test passes in the desired runtime framework version ([8fbb8f6](https://github.com/Informatievlaanderen/build-pipeline/commit/8fbb8f6))

# 1.0.0 (2018-12-15)


### Features

* make opensource as agentschap Informatie Vlaanderen under MIT ([016c89e](https://github.com/Informatievlaanderen/build-pipeline/commit/016c89e))
