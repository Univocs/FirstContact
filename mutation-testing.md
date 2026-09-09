# Mutation testing with Stryker.NET

> [Stryker.NET](https://stryker-mutator.io/docs/stryker-net/introduction/) 

Mutation testing requires a green initial test run, then alters the implementation in small ways and checks whether the test suite detects those changes. A surviving mutant often indicates a missing assertion, an untested boundary, or a test that executes behaviour without specifying it precisely.

```powershell
dotnet stryker --config-file stryker-config.json --skip-version-check
```