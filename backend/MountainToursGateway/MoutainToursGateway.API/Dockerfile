FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8084

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copy project files
COPY ["MountainToursGateway/MoutainToursGateway.API/MoutainToursGateway.API.csproj", "MountainToursGateway/MoutainToursGateway.API/"]
COPY ["Services/Shared.Events/src/Shared.Events/Shared.Events.csproj", "Services/Shared.Events/src/Shared.Events/"]

# Restore dependencies (this layer will be cached if csproj files don't change)
RUN dotnet restore "MountainToursGateway/MoutainToursGateway.API/MoutainToursGateway.API.csproj"

# Now copy all source code (this invalidates cache only when source changes)
COPY ["MountainToursGateway/MoutainToursGateway.API/", "MountainToursGateway/MoutainToursGateway.API/"]
COPY ["Services/Shared.Events/src/Shared.Events/", "Services/Shared.Events/src/Shared.Events/"]

# Build
WORKDIR "/src/MountainToursGateway/MoutainToursGateway.API"
RUN dotnet build "MoutainToursGateway.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "MoutainToursGateway.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MoutainToursGateway.API.dll"]