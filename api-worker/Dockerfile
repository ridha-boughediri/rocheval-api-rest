# Utiliser l'image de base officielle de .NET 6.0 pour le build
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app

# Copier le fichier csproj et restaurer les dépendances
COPY *.csproj ./
RUN dotnet restore

# Copier tout le reste et publier l'application
COPY . ./
RUN dotnet publish -c Release -o out

# Utiliser l'image de base officielle de .NET 6.0 pour l'exécution
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /app
COPY --from=build /app/out ./

# Exposer le port 80
EXPOSE 80

# Définir le point d'entrée
ENTRYPOINT ["dotnet", "api-worker.dll"]
