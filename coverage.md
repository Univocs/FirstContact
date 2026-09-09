# Coverage

1. Install ReportGenerator
   ```powershell
   dotnet tool install --global dotnet-reportgenerator-globaltool
   ```
2. Run the tests with coverage
   ```powershell
   if (Test-Path '.\TestCoverage') {
       Remove-Item '.\TestCoverage' -Recurse -Force
   }
   dotnet test FirstContact.Tests\FirstContact.Tests.csproj --collect:"XPlat Code Coverage" --settings coverage.runsettings --results-directory TestCoverage
   ```
3. Generate an HTML report using ReportGenerator:
   ```powershell
   if (Test-Path '.\TestReport') {
       Remove-Item '.\TestReport' -Recurse -Force
   }
   reportgenerator -reports:"TestCoverage\**\coverage.cobertura.xml" -targetdir:"TestReport" -reporttypes:Html
   start TestReport\index.html
   ```