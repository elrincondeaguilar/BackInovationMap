# Dockerfile para Render
# Usa la imagen oficial de .NET 9
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copiar archivo de proyecto y restaurar dependencias
COPY ["BackInovationMap.csproj", "."]
RUN dotnet restore "BackInovationMap.csproj"

# Copiar todo el código fuente
COPY . .
WORKDIR "/src"

# Compilar la aplicación
RUN dotnet build "BackInovationMap.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BackInovationMap.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Imagen final
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Configurar el puerto dinámico de Render
ENV ASPNETCORE_URLS=http://0.0.0.0:$PORT

ENTRYPOINT ["dotnet", "BackInovationMap.dll"]
