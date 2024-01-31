# Identity Api镜像配置

# 变量定义
ARG runtime_version=8.0.1
ARG sdk_version=8.0.101

# 基础阶段
FROM mcr.microsoft.com/dotnet/aspnet:${runtime_version} AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# 发布阶段
FROM mcr.microsoft.com/dotnet/sdk:${sdk_version} AS publish
WORKDIR /src
COPY ["Directory.Build.props", "."]
COPY ["build/*", "./build/"]
COPY ["src/Share/Util.Platform.Share.Config/Util.Platform.Share.Config.csproj", "src/Share/Util.Platform.Share.Config/"]
COPY ["src/Share/Util.Platform.Share.Service/Util.Platform.Share.Service.csproj", "src/Share/Util.Platform.Share.Service/"]
COPY ["src/Services/Identity/Util.Platform.Identity.Api/Util.Platform.Identity.Api.csproj", "src/Services/Identity/Util.Platform.Identity.Api/"]
COPY ["src/Services/Identity/Util.Platform.Identity.Application/Util.Platform.Identity.Application.csproj", "src/Services/Identity/Util.Platform.Identity.Application/"]
COPY ["src/Services/Identity/Util.Platform.Identity.Domain/Util.Platform.Identity.Domain.csproj", "src/Services/Identity/Util.Platform.Identity.Domain/"]
COPY ["src/Services/Identity/Util.Platform.Identity.Data/Util.Platform.Identity.Data.csproj", "src/Services/Identity/Util.Platform.Identity.Data/"]
COPY ["src/Services/Identity/Util.Platform.Identity.Data.SqlServer/Util.Platform.Identity.Data.SqlServer.csproj", "src/Services/Identity/Util.Platform.Identity.Data.SqlServer/"]
COPY ["src/Services/Identity/Util.Platform.Identity.Data.PgSql/Util.Platform.Identity.Data.PgSql.csproj", "src/Services/Identity/Util.Platform.Identity.Data.PgSql/"]
COPY ["src/Services/Identity/Util.Platform.Identity.Data.MySql/Util.Platform.Identity.Data.MySql.csproj", "src/Services/Identity/Util.Platform.Identity.Data.MySql/"]
COPY ["src/Services/Identity/Util.Platform.Identity.Share/Util.Platform.Identity.Share.csproj", "src/Services/Identity/Util.Platform.Identity.Share/"]
RUN dotnet restore "src/Services/Identity/Util.Platform.Identity.Api/Util.Platform.Identity.Api.csproj"
COPY . .
WORKDIR "/src/src/Services/Identity/Util.Platform.Identity.Api"
RUN dotnet publish "Util.Platform.Identity.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

# 最终阶段
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV TZ=Asia/Shanghai
ENTRYPOINT ["dotnet", "Util.Platform.Identity.Api.dll"]