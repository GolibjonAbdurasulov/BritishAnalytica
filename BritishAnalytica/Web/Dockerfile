FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy and restore NuGet packages
COPY ["nuget-packages/*", "/nuget-packages/"]
WORKDIR /src

# Copy csproj files and restore dependencies
COPY ["Services/Services.csproj", "Services/"]
COPY ["Entity/Entity.csproj", "Entity/"]
COPY ["DatabaseBroker/DatabaseBroker.csproj", "DatabaseBroker/"]
COPY ["Web/Web.csproj", "Web/"]

# Add NuGet package source and restore dependencies
WORKDIR /src/Web
RUN dotnet nuget add source "/nuget-packages"
RUN dotnet restore "Web.csproj"

# Copy entire project and build
WORKDIR /src
COPY . .
WORKDIR "/src/Web"
RUN dotnet build "Web.csproj" -c Release -o /app/build

# Publish the application
FROM build AS publish
RUN dotnet publish "Web.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Final stage for the runtime
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Web.dll"]
