FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Services/Tours/Tours.API/Tours.API.csproj", "Services/Tours/Tours.API/"]
COPY ["Services/Tours/Tours.Domain/Tours.Domain.csproj", "Services/Tours/Tours.Domain/"]
COPY ["Services/Tours/Tours.Application/Tours.Application.csproj", "Services/Tours/Tours.Application/"]
COPY ["Services/Tours/Tours.Infrastructure/Tours.Infrastructure.csproj", "Services/Tours/Tours.Infrastructure/"]
RUN dotnet restore "Services/Tours/Tours.API/Tours.API.csproj"
COPY . .
WORKDIR "/src/Services/Tours/Tours.API"
RUN dotnet build "Tours.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Tours.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Tours.API.dll"]