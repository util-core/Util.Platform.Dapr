# Api网关镜像配置

# 变量定义
ARG runtime_version=7.0.9
ARG sdk_version=7.0.306

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
COPY ["src/ApiGateways/Util.Platform.ApiGateway/Util.Platform.ApiGateway.csproj", "src/ApiGateways/Util.Platform.ApiGateway/"]
COPY ["src/Share/Util.Platform.Share.Config/Util.Platform.Share.Config.csproj", "src/Share/Util.Platform.Share.Config/"]
COPY ["src/ApiGateways/Util.Platform.ApiGateway.Application/Util.Platform.ApiGateway.Application.csproj", "src/ApiGateways/Util.Platform.ApiGateway.Application/"]
COPY ["src/Services/Identity/Util.Platform.Identity.Share/Util.Platform.Identity.Share.csproj", "src/Services/Identity/Util.Platform.Identity.Share/"]
RUN dotnet restore "src/ApiGateways/Util.Platform.ApiGateway/Util.Platform.ApiGateway.csproj"
COPY . .
WORKDIR "/src/src/ApiGateways/Util.Platform.ApiGateway"
RUN dotnet publish "Util.Platform.ApiGateway.csproj" -c Release -o /app/publish /p:UseAppHost=false

# 最终阶段
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV TZ=Asia/Shanghai
ENTRYPOINT ["dotnet", "Util.Platform.ApiGateway.dll"]