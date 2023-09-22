# Tools Api镜像配置

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
COPY ["src/Services/Tools/Util.Platform.Tools.Api/Util.Platform.Tools.Api.csproj", "src/Services/Tools/Util.Platform.Tools.Api/"]
COPY ["src/Services/Identity/Util.Platform.Identity.Share/Util.Platform.Identity.Share.csproj", "src/Services/Identity/Util.Platform.Identity.Share/"]
RUN dotnet restore "src/Services/Tools/Util.Platform.Tools.Api/Util.Platform.Tools.Api.csproj"
COPY . .
WORKDIR "/src/src/Services/Tools/Util.Platform.Tools.Api"
RUN dotnet publish "Util.Platform.Tools.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

# 最终阶段
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV TZ=Asia/Shanghai
ENTRYPOINT ["dotnet", "Util.Platform.Tools.Api.dll"]