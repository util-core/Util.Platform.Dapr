# �������UI��������

# ��������
ARG runtime_version=8.0.1-bookworm-slim
ARG sdk_version=8.0.101

# �����׶�
FROM mcr.microsoft.com/dotnet/aspnet:${runtime_version} AS base
WORKDIR /app
EXPOSE 80

# �����׶�
FROM mcr.microsoft.com/dotnet/sdk:${sdk_version} AS publish
WORKDIR /src
COPY ["Directory.Build.props", "."]
COPY ["build/*", "./build/"]
COPY ["src/HealthChecks/Util.Platform.HealthChecks/Util.Platform.HealthChecks.csproj", "src/HealthChecks/Util.Platform.HealthChecks/"]
RUN dotnet restore "src/HealthChecks/Util.Platform.HealthChecks/Util.Platform.HealthChecks.csproj"
COPY . .
WORKDIR "/src/src/HealthChecks/Util.Platform.HealthChecks"
RUN dotnet publish "Util.Platform.HealthChecks.csproj" -c Release -o /app/publish /p:UseAppHost=false

# ���ս׶�
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV TZ=Asia/Shanghai
ENTRYPOINT ["dotnet", "Util.Platform.HealthChecks.dll"]