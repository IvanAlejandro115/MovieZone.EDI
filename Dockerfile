# Imagen de compilación con .NET 9.0 SDK
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copiar archivos y restaurar dependencias
COPY . .
RUN dotnet restore
RUN dotnet publish -c Release -o /app/publish

# Imagen de ejecución ligera
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

# Configurar puerto para el servidor en la nube
ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

ENTRYPOINT ["dotnet", "MovieZone.dll"]
