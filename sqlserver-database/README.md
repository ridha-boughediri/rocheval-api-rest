# AuthApi - Microservice d'authentification

Ce projet est un microservice d'authentification développé en ASP.NET Core, utilisant JWT pour l'authentification et SQL Server comme base de données.

## Prérequis

- [Docker](https://www.docker.com/get-started)
- [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)

## Configuration

1. **Cloner le dépôt :**

    ```sh
    git clone https://github.com/votre-utilisateur/votre-depot.git
    cd votre-depot
    ```

2. **Créer un fichier `.env` à la racine du projet :**

    ```plaintext
    ASPNETCORE_ENVIRONMENT=Development
    JWT_SECRET=your_secret_key_here
    SQLSERVER_DB=AuthDb
    SQLSERVER_USER=sa
    SQLSERVER_PASSWORD=your_password
    SQLSERVER_HOST=sql-server
    SQLSERVER_PORT=1433
    ```

3. **Créer le fichier `appsettings.json` (optionnel) :**

    Si vous souhaitez configurer davantage l'application, vous pouvez ajouter un fichier `appsettings.json` à la racine du projet.

    ```json
    {
      "Logging": {
        "LogLevel": {
          "Default": "Information",
          "Microsoft.AspNetCore": "Warning"
        }
      },
      "AllowedHosts": "*",
      "ConnectionStrings": {
        "DefaultConnection": "Server=sql-server,1433;Database=AuthDb;User Id=sa;Password=your_password;"
      }
    }
    ```

## Développement

### Construire et exécuter le projet localement

1. **Restaurer les dépendances :**

    ```sh
    dotnet restore
    ```

2. **Construire le projet :**

    ```sh
    dotnet build
    ```

3. **Exécuter les migrations (si nécessaire) :**

    ```sh
    dotnet ef database update
    ```

4. **Exécuter le projet :**

    ```sh
    dotnet run
    ```

### Utilisation de Docker

1. **Construire et démarrer les conteneurs Docker :**

    ```sh
    docker-compose up --build
    ```

    Cela construira et démarrera les conteneurs Docker pour le microservice d'authentification et SQL Server.

2. **Arrêter les conteneurs Docker :**

    ```sh
    docker-compose down
    ```

## Endpoints

Le microservice expose les endpoints suivants :

- `POST /api/auth/register` : Inscrire un nouvel utilisateur.
- `POST /api/auth/login` : Connecter un utilisateur existant et obtenir un JWT.
- `GET /api/auth/users` : Récupérer la liste de tous les utilisateurs (nécessite une authentification).

## Exemple de requête

### Inscription d'un utilisateur

```sh
curl -X POST http://localhost:8080/api/auth/register \
-H "Content-Type: application/json" \
-d '{
  "username": "testuser",
  "password": "Password123!",
  "firstName": "John",
  "lastName": "Doe",
  "email": "johndoe@example.com",
  "gender": "Male"
}'
