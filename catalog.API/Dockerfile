FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS  build
WORKDIR /src
COPY ["catalog.API/catalog.API.csproj", "."]
RUN dotnet restore "catalog.API.csproj"
COPY "catalog.API" .
RUN dotnet build "catalog.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "catalog.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT [ "dotnet", "catalog.API.dll" ]
