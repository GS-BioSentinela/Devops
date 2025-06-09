# Etapa base para runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Etapa de build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copia somente o csproj para restaurar dependências
COPY ["BioSentinela - .NET.csproj", "./"]

RUN dotnet restore "BioSentinela - .NET.csproj"

# Copia todo o código para a imagem
COPY . .

# Build da aplicação
RUN dotnet build "BioSentinela - .NET.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Publica a aplicação
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "BioSentinela - .NET.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Imagem final
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BioSentinela - .NET.dll"]
