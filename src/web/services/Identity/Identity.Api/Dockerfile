FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/services/Identity/Identity.Api/Identity.Api.csproj", "src/services/Identity/Identity.Api/"]
COPY ["src/services/Identity/Identity.DataAccess/Identity.DataAccess.csproj", "src/services/Identity/Identity.DataAccess/"]
COPY ["src/services/Identity/Identity.Domain/Identity.Domain.csproj", "src/services/Identity/Identity.Domain/"]
COPY ["src/building-blocks/Inspirer.Infrastructure/Inspirer.Infrastructure.csproj", "src/building-blocks/Inspirer.Infrastructure/"]
COPY ["src/building-blocks/Inspirer.Application/Inspirer.Application.csproj", "src/building-blocks/Inspirer.Application/"]
COPY ["src/building-blocks/Inspirer.Contracts/Inspirer.Contracts.csproj", "src/building-blocks/Inspirer.Contracts/"]
RUN dotnet restore "src/services/Identity/Identity.Api/Identity.Api.csproj"
COPY . .
WORKDIR "/src/src/services/Identity/Identity.Api"
RUN dotnet build "Identity.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Identity.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Identity.Api.dll"]
