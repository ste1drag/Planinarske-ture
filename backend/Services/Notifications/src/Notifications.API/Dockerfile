# Dockerfile
# Multi-stage build for Notifications Web API (.\Services\Notifications\src\Notifications.API)

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8083
ENV ASPNETCORE_URLS=http://+:8083

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy the repo
COPY . .

# Restore the Notifications solution
RUN dotnet restore Services/Notifications/Notifications.sln

# Publish the Notifications.API project by its .csproj; do not override AssemblyName
RUN dotnet publish Services/Notifications/src/Notifications.API/Notifications.API.csproj -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .

# Use the project's actual output dll name
ENTRYPOINT ["dotnet", "Notifications.API.dll"]
