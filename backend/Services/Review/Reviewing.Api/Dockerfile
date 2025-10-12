# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080

# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Services/Review/Reviewing.Api/Reviewing.API.csproj", "Reviewing.Api/"]
COPY ["Services/Review/Reviewing.Application/Reviewing.Application.csproj", "Reviewing.Application/"]
COPY ["Services/Review/Reviewing.Domain/Reviewing.Domain.csproj", "Reviewing.Domain/"]
COPY ["Services/Review/Reviewing.Infrastructure/Reviewing.Infrastructure.csproj", "Reviewing.Infrastructure/"]
RUN dotnet restore "./Reviewing.Api/Reviewing.API.csproj"

# copy the rest of the source (use same casing so files end up in Reviewing.Api)
COPY Services/Review/ .
WORKDIR "/src/Reviewing.Api"
RUN dotnet build "./Reviewing.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Reviewing.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Reviewing.API.dll"]
