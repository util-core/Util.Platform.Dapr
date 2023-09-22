# 健康检查UI镜像配置

# 变量定义
ARG runtime_version=7.0.9-bullseye-slim
ARG sdk_version=7.0.306

# 基础阶段
FROM mcr.microsoft.com/dotnet/aspnet:${runtime_version} AS base
WORKDIR /app
EXPOSE 80

# 发布阶段
FROM mcr.microsoft.com/dotnet/sdk:${sdk_version} AS publish
WORKDIR /src
COPY ["Directory.Build.props", "."]
COPY ["build/*", "./build/"]
COPY ["nuget.config", "."]
COPY ["src/HealthChecks/Util.Platform.HealthChecks/Util.Platform.HealthChecks.csproj", "src/HealthChecks/Util.Platform.HealthChecks/"]
RUN dotnet restore "src/HealthChecks/Util.Platform.HealthChecks/Util.Platform.HealthChecks.csproj"
COPY . .
WORKDIR "/src/src/HealthChecks/Util.Platform.HealthChecks"
RUN dotnet publish "Util.Platform.HealthChecks.csproj" -c Release -o /app/publish /p:UseAppHost=false

# 最终阶段
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV TZ=Asia/Shanghai
ENTRYPOINT ["dotnet", "Util.Platform.HealthChecks.dll"]