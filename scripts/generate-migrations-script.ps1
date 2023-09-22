Write-Host "update dotnet ef..."
dotnet tool update -g dotnet-ef
Write-Host "generate migrations script..."
dotnet ef migrations script --idempotent -p "..\src\Util.Platform.Systems.Data.SqlServer" -o ../build/deploy/sql/sqlserver/migrations.sql
dotnet ef migrations script --idempotent -p "..\src\Util.Platform.Systems.Data.PgSql" -o ../build/deploy/sql/pgsql/migrations.sql