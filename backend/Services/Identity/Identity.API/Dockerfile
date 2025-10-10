
# Identity API (.NET 8) multi-stage build


FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base

WORKDIR /app
EXPOSE 8081
ENV ASPNETCORE_URLS=http://+:8081



FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copy csproj first to leverage Docker layer caching
COPY Services/Identity/Identity.API/Identity.API.csproj Services/Identity/Identity.API/
RUN dotnet restore Services/Identity/Identity.API/Identity.API.csproj

# Copy the rest of the source
COPY . .
WORKDIR /src/Services/Identity/Identity.API

# Build
RUN dotnet build Identity.API.csproj -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
WORKDIR /src/Services/Identity/Identity.API
RUN dotnet publish Identity.API.csproj -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false


FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Identity.API.dll"]