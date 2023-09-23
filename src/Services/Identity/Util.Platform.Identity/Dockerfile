# ��֤���ľ�������

# ��������
ARG runtime_version=7.0.9
ARG sdk_version=7.0.306

# �����׶�
FROM mcr.microsoft.com/dotnet/aspnet:${runtime_version} AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# �����׶�
FROM mcr.microsoft.com/dotnet/sdk:${sdk_version} AS publish
WORKDIR /src
COPY ["Directory.Build.props", "."]
COPY ["build/*", "./build/"]
COPY ["src/Services/Identity/Util.Platform.Identity/Util.Platform.Identity.csproj", "src/Services/Identity/Util.Platform.Identity/"]
COPY ["src/Share/Util.Platform.Share.Config/Util.Platform.Share.Config.csproj", "src/Share/Util.Platform.Share.Config/"]
COPY ["src/Services/Identity/Util.Platform.Identity.Application/Util.Platform.Identity.Application.csproj", "src/Services/Identity/Util.Platform.Identity.Application/"]
COPY ["src/Services/Identity/Util.Platform.Identity.Data.PgSql/04-Util.Platform.Identity.Data.PgSql.csproj", "src/Services/Identity/Util.Platform.Identity.Data.PgSql/"]
COPY ["src/Services/Identity/Util.Platform.Identity.Data/02-Util.Platform.Identity.Data.csproj", "src/Services/Identity/Util.Platform.Identity.Data/"]
COPY ["src/Services/Identity/Util.Platform.Identity.Domain/Util.Platform.Identity.Domain.csproj", "src/Services/Identity/Util.Platform.Identity.Domain/"]
COPY ["src/Services/Identity/Util.Platform.Identity.Data.SqlServer/03-Util.Platform.Identity.Data.SqlServer.csproj", "src/Services/Identity/Util.Platform.Identity.Data.SqlServer/"]
COPY ["src/Services/Identity/Util.Platform.Identity.Share/Util.Platform.Identity.Share.csproj", "src/Services/Identity/Util.Platform.Identity.Share/"]
RUN dotnet restore "src/Services/Identity/Util.Platform.Identity/Util.Platform.Identity.csproj"
COPY . .
WORKDIR "/src/src/Services/Identity/Util.Platform.Identity"
RUN dotnet publish "Util.Platform.Identity.csproj" -c Release -o /app/publish /p:UseAppHost=false

# ���ս׶�
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV TZ=Asia/Shanghai
ENTRYPOINT ["dotnet", "Util.Platform.Identity.dll"]