## [7.2.4](https://github.com/Informatievlaanderen/build-pipeline/compare/v7.2.3...v7.2.4) (2024-03-25)


### Bug Fixes

* **ci:** remove `--self-contained` from build-lambda ([eafce88](https://github.com/Informatievlaanderen/build-pipeline/commit/eafce88877b4e21c142d999b71b5b3b43fc8d81b))

## [7.2.3](https://github.com/Informatievlaanderen/build-pipeline/compare/v7.2.2...v7.2.3) (2024-03-25)


### Bug Fixes

* **ci:** remove self-contained for build lambda ([47c8086](https://github.com/Informatievlaanderen/build-pipeline/commit/47c808618488c061096065c421fe087be1561005))

## [7.2.2](https://github.com/Informatievlaanderen/build-pipeline/compare/v7.2.1...v7.2.2) (2024-03-25)


### Bug Fixes

* **ci:** remove `self-contained` for lamba ([033d94d](https://github.com/Informatievlaanderen/build-pipeline/commit/033d94d31e9ef25ae281c88a84a79564b73a950e))

## [7.2.1](https://github.com/Informatievlaanderen/build-pipeline/compare/v7.2.0...v7.2.1) (2024-03-19)


### Bug Fixes

* build lambda in release config ([894efa5](https://github.com/Informatievlaanderen/build-pipeline/commit/894efa534af46bad4a47170849c22df0811f9117))

# [7.2.0](https://github.com/Informatievlaanderen/build-pipeline/compare/v7.1.0...v7.2.0) (2024-03-19)

# [7.1.0](https://github.com/Informatievlaanderen/build-pipeline/compare/v7.0.4...v7.1.0) (2024-03-13)


### Features

* change build-image and build-lambda to be more generic ([aa2d137](https://github.com/Informatievlaanderen/build-pipeline/commit/aa2d1378505f500ca67e0b274c2859547ed97cd7))

## [7.0.4](https://github.com/Informatievlaanderen/build-pipeline/compare/v7.0.3...v7.0.4) (2024-03-06)


### Bug Fixes

* be able to skip tests for pack ([1d6ca26](https://github.com/Informatievlaanderen/build-pipeline/commit/1d6ca263d8cc00982cd5d5c07a1ce402a8b2dd3c))

## [7.0.3](https://github.com/Informatievlaanderen/build-pipeline/compare/v7.0.2...v7.0.3) (2024-03-05)


### Bug Fixes

* remove disabling version generation ([e0b255b](https://github.com/Informatievlaanderen/build-pipeline/commit/e0b255bf2b16f186cc42a2f559f0a39cbcf6281a))

## [7.0.2](https://github.com/Informatievlaanderen/build-pipeline/compare/v7.0.1...v7.0.2) (2024-03-05)


### Bug Fixes

* use dotnet nuget ([cd7f3f3](https://github.com/Informatievlaanderen/build-pipeline/commit/cd7f3f34cd29a78bbee53c871215430bc5293087))

## [7.0.1](https://github.com/Informatievlaanderen/build-pipeline/compare/v7.0.0...v7.0.1) (2024-03-05)


### Bug Fixes

* try upload nuget again + bump npm packages ([d9a5178](https://github.com/Informatievlaanderen/build-pipeline/commit/d9a5178060d4cf0534b21f6c57bd7179478651f0))

# [7.0.0](https://github.com/Informatievlaanderen/build-pipeline/compare/v6.2.9...v7.0.0) (2024-03-05)


### Features

* add new buildprops + bump dotnet8 ([ef61a5c](https://github.com/Informatievlaanderen/build-pipeline/commit/ef61a5c78c5bab847bb0ff5b5c7b44897bf41aca))


### BREAKING CHANGES

* move to dotnet 8.0.2 + removed FAKE build scripts

## [6.2.9](https://github.com/Informatievlaanderen/build-pipeline/compare/v6.2.8...v6.2.9) (2023-10-24)


### Bug Fixes

* rollback on set-output-version ([#248](https://github.com/Informatievlaanderen/build-pipeline/issues/248)) ([1f5cfd8](https://github.com/Informatievlaanderen/build-pipeline/commit/1f5cfd893ca2db166f572c83abf430f5770c5282))

## [6.2.8](https://github.com/Informatievlaanderen/build-pipeline/compare/v6.2.7...v6.2.8) (2023-10-24)


### Bug Fixes

* use release version instead of output variables ([#247](https://github.com/Informatievlaanderen/build-pipeline/issues/247)) ([c9faf78](https://github.com/Informatievlaanderen/build-pipeline/commit/c9faf78d8fa857e05e5d0ac6aeb488951464b387))

## [6.2.7](https://github.com/Informatievlaanderen/build-pipeline/compare/v6.2.6...v6.2.7) (2023-10-23)


### Bug Fixes

* lowercase did not merge properly ([54476e5](https://github.com/Informatievlaanderen/build-pipeline/commit/54476e512d76bec050eaad95637ec61887d26f16))

## [6.2.6](https://github.com/Informatievlaanderen/build-pipeline/compare/v6.2.5...v6.2.6) (2023-10-23)


### Bug Fixes

* remove output from workflow in favour of environment variables ([6ec349b](https://github.com/Informatievlaanderen/build-pipeline/commit/6ec349b9fc96c3724876343b860ee0101a2272aa))

## [6.2.5](https://github.com/Informatievlaanderen/build-pipeline/compare/v6.2.4...v6.2.5) (2023-10-23)


### Bug Fixes

* added main branch to the action references ([f651c0a](https://github.com/Informatievlaanderen/build-pipeline/commit/f651c0ab086a59a650df578d44d8e1311510efa2))

## [6.2.4](https://github.com/Informatievlaanderen/build-pipeline/compare/v6.2.3...v6.2.4) (2023-10-23)


### Bug Fixes

* lowercase did not merge properly ([#242](https://github.com/Informatievlaanderen/build-pipeline/issues/242)) ([2ca93e1](https://github.com/Informatievlaanderen/build-pipeline/commit/2ca93e14bc5c582359251bb5c745d3e19473b933))

## [6.2.3](https://github.com/Informatievlaanderen/build-pipeline/compare/v6.2.2...v6.2.3) (2023-10-23)


### Bug Fixes

* lowercase reference links ([95f42e0](https://github.com/Informatievlaanderen/build-pipeline/commit/95f42e0a78e12def9d796a7262ea13bd99f19d7f))

## [6.2.2](https://github.com/Informatievlaanderen/build-pipeline/compare/v6.2.1...v6.2.2) (2023-10-23)


### Bug Fixes

* update incorrect reference path ([#240](https://github.com/Informatievlaanderen/build-pipeline/issues/240)) ([7d3bf70](https://github.com/Informatievlaanderen/build-pipeline/commit/7d3bf706457fc9e9afeb3bd1e19b579a028bd7eb))

## [6.2.1](https://github.com/Informatievlaanderen/build-pipeline/compare/v6.2.0...v6.2.1) (2023-10-23)


### Bug Fixes

* reference full url in actions and workflows ([886655a](https://github.com/Informatievlaanderen/build-pipeline/commit/886655ac46a4df723f5d22b00a8ace5b2aa13716))

# [6.2.0](https://github.com/Informatievlaanderen/build-pipeline/compare/v6.1.0...v6.2.0) (2023-10-23)


### Bug Fixes

* cleanup for analyze-code and set-release-version ([c036c8f](https://github.com/Informatievlaanderen/build-pipeline/commit/c036c8f7378f7998b7ec9b1175b12600b2daee2a))
* remove unused environment variable ([78b5688](https://github.com/Informatievlaanderen/build-pipeline/commit/78b5688a2df6e9986932ff7ed37b66ef2e925f65))
* updated name for analyze-code workflow ([32a953e](https://github.com/Informatievlaanderen/build-pipeline/commit/32a953e345fc6b28d826c608d1bf9f5a8687a691))


### Features

* Added workflow for set-release-version and analyze-code ([909570e](https://github.com/Informatievlaanderen/build-pipeline/commit/909570e5492eb8151edf42eb6fc6003dc5eb2e1f))

# [6.1.0](https://github.com/Informatievlaanderen/build-pipeline/compare/v6.0.8...v6.1.0) (2023-10-23)


### Features

* add reusable actions for npm, dotnet, and python ([f93d231](https://github.com/Informatievlaanderen/build-pipeline/commit/f93d23119ecfa8d65ed7b54d2bfb015d9154fa91))

## [6.0.8](https://github.com/Informatievlaanderen/build-pipeline/compare/v6.0.7...v6.0.8) (2023-08-01)


### Bug Fixes

* exclude common files being published when referencing other projects ([44d927e](https://github.com/Informatievlaanderen/build-pipeline/commit/44d927e41a0cd397933bf0356d7eed822badbdd8))

## [6.0.7](https://github.com/Informatievlaanderen/build-pipeline/compare/v6.0.6...v6.0.7) (2023-01-13)


### Bug Fixes

* test setassemblyversions ([f43a840](https://github.com/Informatievlaanderen/build-pipeline/commit/f43a8406f1dc4697d4a6cb6cd703f3cb4674397d))

## [6.0.6](https://github.com/Informatievlaanderen/build-pipeline/compare/v6.0.5...v6.0.6) (2022-12-09)


### Bug Fixes

* pin net6 libs ([c12ec2b](https://github.com/Informatievlaanderen/build-pipeline/commit/c12ec2b296021bbe08d607cb67b7b9eb4288ed90))

## [6.0.5](https://github.com/Informatievlaanderen/build-pipeline/compare/v6.0.4...v6.0.5) (2022-05-03)


### Bug Fixes

* make tests work for non-msil projects ([afb7c8d](https://github.com/Informatievlaanderen/build-pipeline/commit/afb7c8d8bfc5c403ebde95e90106bd6fe45244ec))

## [6.0.4](https://github.com/Informatievlaanderen/build-pipeline/compare/v6.0.3...v6.0.4) (2022-04-27)


### Bug Fixes

* dont do neutral build and support no restore elsewhere ([91b2b90](https://github.com/Informatievlaanderen/build-pipeline/commit/91b2b900d6950d94fb5802f087b8c1d726892e18))
* make build solution great again ([2dc761b](https://github.com/Informatievlaanderen/build-pipeline/commit/2dc761b628f51a7c09aef19fec2d03d03b1d2db8))

## [6.0.3](https://github.com/Informatievlaanderen/build-pipeline/compare/v6.0.2...v6.0.3) (2022-03-23)


### Bug Fixes

* restore on neutral build with ready to run ([1783c48](https://github.com/Informatievlaanderen/build-pipeline/commit/1783c4881f5e3dd2e15fbf60606b1f56a67caea0))

## [6.0.2](https://github.com/Informatievlaanderen/build-pipeline/compare/v6.0.1...v6.0.2) (2022-03-23)


### Bug Fixes

* NoRestore false in DotNetPublish of build-generic.fsx ([a96f128](https://github.com/Informatievlaanderen/build-pipeline/commit/a96f128b3f03466c0c47dfe57aca504816b60666))

## [6.0.1](https://github.com/Informatievlaanderen/build-pipeline/compare/v6.0.0...v6.0.1) (2022-03-22)


### Bug Fixes

* use dotnet6 in props files ([c0d2d79](https://github.com/Informatievlaanderen/build-pipeline/commit/c0d2d792555486d8b7b41912bcc43d58b0bc4b4e))

# [6.0.0](https://github.com/Informatievlaanderen/build-pipeline/compare/v5.2.0...v6.0.0) (2022-03-22)


### Features

* move to dotnet 6.0.3 ([a927e03](https://github.com/Informatievlaanderen/build-pipeline/commit/a927e036c9d825a2d0b4de20beb8bb60fabb0375))


### BREAKING CHANGES

* move to dotnet 6.0.3

# [5.2.0](https://github.com/Informatievlaanderen/build-pipeline/compare/v5.1.0...v5.2.0) (2022-03-09)


### Features

* pass build_number to dockerfile as ARG ([3347feb](https://github.com/Informatievlaanderen/build-pipeline/commit/3347feb283095bc62b67aa0b08732a3e1cc7335c))

# [5.1.0](https://github.com/Informatievlaanderen/build-pipeline/compare/v5.0.4...v5.1.0) (2021-10-05)


### Features

* remove clearing of fallback folder ([3a8752d](https://github.com/Informatievlaanderen/build-pipeline/commit/3a8752dec07c1fd12f6b92934aec9b5cca6dd610))

## [5.0.4](https://github.com/Informatievlaanderen/build-pipeline/compare/v5.0.3...v5.0.4) (2021-05-31)


### Bug Fixes

* move to 5.0.6 pt 2 ([ab08b4b](https://github.com/Informatievlaanderen/build-pipeline/commit/ab08b4b5e1a7a92baa26462501f9811a50c1722a))

## [5.0.3](https://github.com/Informatievlaanderen/build-pipeline/compare/v5.0.2...v5.0.3) (2021-05-28)


### Bug Fixes

* move to 5.0.6 ([a916401](https://github.com/Informatievlaanderen/build-pipeline/commit/a916401f9d6d7aeadc86b002424407e5cfb77c63))

## [5.0.2](https://github.com/Informatievlaanderen/build-pipeline/compare/v5.0.1...v5.0.2) (2021-02-02)


### Bug Fixes

* move to 5.0.2 ([d9469e4](https://github.com/Informatievlaanderen/build-pipeline/commit/d9469e438da44228594991965e1f5e9eb78172bc))

## [5.0.1](https://github.com/Informatievlaanderen/build-pipeline/compare/v5.0.0...v5.0.1) (2020-12-17)


### Bug Fixes

* bump to 5.0.1 ([d62c1c7](https://github.com/Informatievlaanderen/build-pipeline/commit/d62c1c796da40b3892adafc173b5125071468f02))

# [5.0.0](https://github.com/Informatievlaanderen/build-pipeline/compare/v4.2.5...v5.0.0) (2020-12-17)


### Features

* upgrade to net5.0 ([cc6c95f](https://github.com/Informatievlaanderen/build-pipeline/commit/cc6c95f7f05e828424e1e057543219d37ffde685))


### BREAKING CHANGES

* Major .NET upgrade

## [4.2.5](https://github.com/Informatievlaanderen/build-pipeline/compare/v4.2.4...v4.2.5) (2020-12-17)


### Bug Fixes

* move to 5.0.1 ([3d7092e](https://github.com/Informatievlaanderen/build-pipeline/commit/3d7092e3ff0d4dfd5ef90cb072a83278f82eaa16))

## [4.2.4](https://github.com/Informatievlaanderen/build-pipeline/compare/v4.2.3...v4.2.4) (2020-11-17)


### Bug Fixes

* correct typo ([80ed5b0](https://github.com/Informatievlaanderen/build-pipeline/commit/80ed5b0d040b7e2fcfba962ac83057dfa3776962))
* remove set-env usage in gh-actions ([ca495b4](https://github.com/Informatievlaanderen/build-pipeline/commit/ca495b463abe59d1bc07defa8df3e9650f359120))

## [4.2.3](https://github.com/Informatievlaanderen/build-pipeline/compare/v4.2.2...v4.2.3) (2020-09-17)


### Bug Fixes

* upgrade to 3.1.8 ([f428d09](https://github.com/Informatievlaanderen/build-pipeline/commit/f428d0966976c1ba1a61bddcaa74662b2f3f44e3))

## [4.2.2](https://github.com/Informatievlaanderen/build-pipeline/compare/v4.2.1...v4.2.2) (2020-07-16)


### Bug Fixes

* move to 3.1.6 ([0377919](https://github.com/Informatievlaanderen/build-pipeline/commit/03779199c1f4816f06e81d30b2c64f62dd7b9bb1))

## [4.2.1](https://github.com/Informatievlaanderen/build-pipeline/compare/v4.2.0...v4.2.1) (2020-06-18)


### Bug Fixes

* move to 3.1.5 ([9ef61b3](https://github.com/Informatievlaanderen/build-pipeline/commit/9ef61b36893c33902e851e7b877f0d7573bf0998))
* use main branch name ([ef2961b](https://github.com/Informatievlaanderen/build-pipeline/commit/ef2961bf433e7c17a3c5b4dc105fbc944c9b9511))
* use main branch name ([b7762b2](https://github.com/Informatievlaanderen/build-pipeline/commit/b7762b233c0b3977cc3f1561e24bece4b579ab11))
* use main branch name ([e8e373c](https://github.com/Informatievlaanderen/build-pipeline/commit/e8e373c901a9387ae4994d34f2fe35b2e33c6652))

# [4.2.0](https://github.com/Informatievlaanderen/build-pipeline/compare/v4.1.0...v4.2.0) (2020-06-08)


### Features

* add fake msil rid ([f45ec5d](https://github.com/Informatievlaanderen/build-pipeline/commit/f45ec5daea4df80e08c8211c6f5b2d71d0df43a0))

# [4.1.0](https://github.com/Informatievlaanderen/build-pipeline/compare/v4.0.14...v4.1.0) (2020-05-18)


### Features

* fancy version number ([6c9f0ad](https://github.com/Informatievlaanderen/build-pipeline/commit/6c9f0ad390d7c0d4c31d7957cd48b15fcc725319))

## [4.0.14](https://github.com/Informatievlaanderen/build-pipeline/compare/v4.0.13...v4.0.14) (2020-05-18)


### Bug Fixes

* force build ([53f25ba](https://github.com/Informatievlaanderen/build-pipeline/commit/53f25ba39ced5261a6016961ca2d0e414eceb334))

## [4.0.13](https://github.com/Informatievlaanderen/build-pipeline/compare/v4.0.12...v4.0.13) (2020-05-18)


### Bug Fixes

* cleanup code ([5bb7f6c](https://github.com/Informatievlaanderen/build-pipeline/commit/5bb7f6cc65954876ee4731198b1b621624eeaed7))

## [4.0.12](https://github.com/Informatievlaanderen/build-pipeline/compare/v4.0.11...v4.0.12) (2020-05-18)


### Bug Fixes

* python 3 ([aa446c8](https://github.com/Informatievlaanderen/build-pipeline/commit/aa446c8dfb666210e6f1d9577dbe503e9e722f3b))

## [4.0.11](https://github.com/Informatievlaanderen/build-pipeline/compare/v4.0.10...v4.0.11) (2020-05-18)


### Bug Fixes

* publish to confluence ([28d16a1](https://github.com/Informatievlaanderen/build-pipeline/commit/28d16a168006a74bccbe2a4267771fa0c66031c8))

## [4.0.10](https://github.com/Informatievlaanderen/build-pipeline/compare/v4.0.9...v4.0.10) (2020-05-18)


### Bug Fixes

* set correct version number ([fa71b5c](https://github.com/Informatievlaanderen/build-pipeline/commit/fa71b5c81992f7022d37268ec77b4df1f02eb2c2))

## [4.0.9](https://github.com/Informatievlaanderen/build-pipeline/compare/v4.0.8...v4.0.9) (2020-05-18)


### Bug Fixes

* push to nuget ([6e2909b](https://github.com/Informatievlaanderen/build-pipeline/commit/6e2909b502be4a24124bcc467ee80024908844b3))

## [4.0.8](https://github.com/Informatievlaanderen/build-pipeline/compare/v4.0.7...v4.0.8) (2020-05-18)


### Bug Fixes

* move to 3.1.4 ([27e09fe](https://github.com/Informatievlaanderen/build-pipeline/commit/27e09fe5099462a7f2726c8312d46699844158d4))

## [4.0.7](https://github.com/Informatievlaanderen/build-pipeline/compare/v4.0.6...v4.0.7) (2020-05-18)


### Bug Fixes

* move to GH-actions ([98cd96e](https://github.com/Informatievlaanderen/build-pipeline/commit/98cd96eacb85d91ad5f33b21b8faabb643289339))

## [4.0.6](https://github.com/Informatievlaanderen/build-pipeline/compare/v4.0.5...v4.0.6) (2020-04-28)


### Bug Fixes

* move to 3.1.3 ([215ab21](https://github.com/Informatievlaanderen/build-pipeline/commit/215ab21a2d1d9847e99b73ace0caa1c42be74c13))

## [4.0.5](https://github.com/Informatievlaanderen/build-pipeline/compare/v4.0.4...v4.0.5) (2020-04-15)


### Bug Fixes

* convert ci-jiraversion.py to python 3 ([2614ecf](https://github.com/Informatievlaanderen/build-pipeline/commit/2614ecf0b557dd0f38e67a147a904e922b1ce6ec))

## [4.0.4](https://github.com/Informatievlaanderen/build-pipeline/compare/v4.0.3...v4.0.4) (2020-04-15)


### Bug Fixes

* no more decode('utf-8') needed ([d86d8e3](https://github.com/Informatievlaanderen/build-pipeline/commit/d86d8e3019c1bd44c843a967bac8137760b4cb7f))

## [4.0.3](https://github.com/Informatievlaanderen/build-pipeline/compare/v4.0.2...v4.0.3) (2020-04-15)


### Bug Fixes

* urllib quote plus moved ([7e002a5](https://github.com/Informatievlaanderen/build-pipeline/commit/7e002a588fc0c30f028a4814b2eb1655df32d237))

## [4.0.2](https://github.com/Informatievlaanderen/build-pipeline/compare/v4.0.1...v4.0.2) (2020-04-15)


### Bug Fixes

* convert md2conf to python3 ([9b042d5](https://github.com/Informatievlaanderen/build-pipeline/commit/9b042d5964155a65eebe3344a633d3820963ebc4))

## [4.0.1](https://github.com/Informatievlaanderen/build-pipeline/compare/v4.0.0...v4.0.1) (2020-04-15)


### Bug Fixes

* pack from linux ([bca8b0f](https://github.com/Informatievlaanderen/build-pipeline/commit/bca8b0f5144ffa1b6862991f96b28d3c3a3caa87))

# [4.0.0](https://github.com/Informatievlaanderen/build-pipeline/compare/v3.3.5...v4.0.0) (2020-04-15)


### Bug Fixes

* get rid of bb names ([74ed95f](https://github.com/Informatievlaanderen/build-pipeline/commit/74ed95ff47a42b92b0bb3264f670e668a38ed944))


### BREAKING CHANGES

* BITBUCKET_COMMIT is now GIT_COMMIT and BITBUCKET_BUILD_NUMBER is CI_BUILD_NUMBER

## [3.3.5](https://github.com/Informatievlaanderen/build-pipeline/compare/v3.3.4...v3.3.5) (2020-04-08)


### Bug Fixes

* use correct array syntax ([768a618](https://github.com/Informatievlaanderen/build-pipeline/commit/768a61895b17f084224925ff5b837970aa25ee7d))

## [3.3.4](https://github.com/Informatievlaanderen/build-pipeline/compare/v3.3.3...v3.3.4) (2020-04-08)


### Bug Fixes

* use correct build user ([b3b4c18](https://github.com/Informatievlaanderen/build-pipeline/commit/b3b4c18deface07c9b4e142d57ee8aae7418aafd))

## [3.3.3](https://github.com/Informatievlaanderen/build-pipeline/compare/v3.3.2...v3.3.3) (2020-04-08)


### Bug Fixes

* dotnetcli detection - suppported runtime identifiers ([26f8983](https://github.com/Informatievlaanderen/build-pipeline/commit/26f8983b59f35954452171d86ea1b2a5317d5c09))

## [3.3.2](https://github.com/Informatievlaanderen/build-pipeline/compare/v3.3.1...v3.3.2) (2020-03-02)


### Bug Fixes

* bump to netcore 3.1.2 ([7e4db5c](https://github.com/Informatievlaanderen/build-pipeline/commit/7e4db5cab7278030c548807a8a8234dcdea31a43))

## [3.3.1](https://github.com/Informatievlaanderen/build-pipeline/compare/v3.3.0...v3.3.1) (2020-01-31)


### Bug Fixes

* compile readytorun when platform matches ([3652256](https://github.com/Informatievlaanderen/build-pipeline/commit/3652256af9a90ab9eb744ca50eaea9e825e508f2))

# [3.3.0](https://github.com/Informatievlaanderen/build-pipeline/compare/v3.2.0...v3.3.0) (2020-01-31)


### Features

* bump to net core 3.1.1 and enable ready to run ([9c7332d](https://github.com/Informatievlaanderen/build-pipeline/commit/9c7332d146681dc3e0a636b7d66970fc700ef5b0))

# [3.2.0](https://github.com/Informatievlaanderen/build-pipeline/compare/v3.1.0...v3.2.0) (2019-12-15)


### Features

* support nullable reference types ([41357ff](https://github.com/Informatievlaanderen/build-pipeline/commit/41357ff1bc38a68cdd89fc35308090cb760be9b1))

# [3.1.0](https://github.com/Informatievlaanderen/build-pipeline/compare/v3.0.1...v3.1.0) (2019-12-11)


### Bug Fixes

* add title for changelog push to confluence ([57f7b63](https://github.com/Informatievlaanderen/build-pipeline/commit/57f7b63))


### Features

* upgrade to netcoreapp31 ([4a00d37](https://github.com/Informatievlaanderen/build-pipeline/commit/4a00d37))

## [3.0.1](https://github.com/Informatievlaanderen/build-pipeline/compare/v3.0.0...v3.0.1) (2019-11-22)


### Bug Fixes

* use correct docker tag flag ([09fe646](https://github.com/Informatievlaanderen/build-pipeline/commit/09fe646))

# [3.0.0](https://github.com/Informatievlaanderen/build-pipeline/compare/v2.0.1...v3.0.0) (2019-11-12)


### Features

* upgrade to .net core 3 ([4cc2680](https://github.com/Informatievlaanderen/build-pipeline/commit/4cc2680))


### BREAKING CHANGES

* Switched to .NET Core 3

## [2.0.1](https://github.com/Informatievlaanderen/build-pipeline/compare/v2.0.0...v2.0.1) (2019-10-27)


### Bug Fixes

* get rid of unneeded fake syntax ([5357cce](https://github.com/Informatievlaanderen/build-pipeline/commit/5357cce))
* make publish and pack work ([87389c9](https://github.com/Informatievlaanderen/build-pipeline/commit/87389c9))

# [2.0.0](https://github.com/Informatievlaanderen/build-pipeline/compare/v1.11.1...v2.0.0) (2019-10-27)


### Bug Fixes

* run correct fake target on build ([b2ed418](https://github.com/Informatievlaanderen/build-pipeline/commit/b2ed418))


### Features

* switch to fake 5 ([5c11f0d](https://github.com/Informatievlaanderen/build-pipeline/commit/5c11f0d))


### BREAKING CHANGES

* The generic build script has moved to Fake 5

## [1.11.1](https://github.com/Informatievlaanderen/build-pipeline/compare/v1.11.0...v1.11.1) (2019-09-05)


### Bug Fixes

* include jira scripts in nuget ([093c958](https://github.com/Informatievlaanderen/build-pipeline/commit/093c958))

# [1.11.0](https://github.com/Informatievlaanderen/build-pipeline/compare/v1.10.0...v1.11.0) (2019-09-05)


### Features

* add github url to jira version ([d8c95b0](https://github.com/Informatievlaanderen/build-pipeline/commit/d8c95b0))

# [1.10.0](https://github.com/Informatievlaanderen/build-pipeline/compare/v1.9.0...v1.10.0) (2019-09-05)


### Features

* add jira creation script ([acb5f17](https://github.com/Informatievlaanderen/build-pipeline/commit/acb5f17))

# [1.9.0](https://github.com/Informatievlaanderen/build-pipeline/compare/v1.8.0...v1.9.0) (2019-08-30)


### Features

* support generating assemblyinfo ([70bdd2d](https://github.com/Informatievlaanderen/build-pipeline/commit/70bdd2d))

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
