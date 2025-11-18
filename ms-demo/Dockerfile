FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app
COPY ms-demo.csproj .
RUN dotnet restore
COPY . .
RUN dotnet publish -c Release -o publish

FROM base AS final
COPY --from=build /app/publish .
ENTRYPOINT [ "dotnet", "ms-demo.dll" ]

