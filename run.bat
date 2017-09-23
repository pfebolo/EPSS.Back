SetLocal
chcp 65001
if [%1] NEQ [Production] set ASPNETCORE_ENVIRONMENT=Development
dotnet run
