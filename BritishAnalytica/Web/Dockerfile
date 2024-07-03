FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /nuget-packages
COPY ["nuget-packages/*", "/nuget-packages/"]
WORKDIR /src
COPY ["Web/Web.csproj", "Web/"]
COPY ["Services/Services.csproj", "Services/"]
COPY ["DatabaseBroker/DatabaseBroker.csproj", "DatabaseBroker/"]
COPY ["Entity/Entity.csproj", "Entity/"]

RUN dotnet nuget add source "/nuget-packages"
RUN dotnet restore "Web/Web.csproj"

WORKDIR "/src/Web"
RUN dotnet build "Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Web.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Web.dll"]