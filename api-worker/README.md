# Mon API REST en C#

## Description

Cette application est une API REST construite en C# avec ASP.NET Core. Elle gère les entités suivantes :
- Départements
- Missions
- Employés
- Projets
- Affectations (Assignments)
- Prévisions météorologiques

Swagger est utilisé pour documenter et tester l'API.

## Prérequis

- .NET 6 SDK
- Docker
- Docker Compose

## Installation

1. Clonez le dépôt :

    ```sh
    git clone https://github.com/votre-utilisateur/votre-repo.git
    cd votre-repo
    ```

2. Construisez et lancez l'application avec Docker Compose :

    ```sh
    docker-compose up --build
    ```

## Utilisation

L'API est documentée et testable via Swagger. Une fois l'application lancée, accédez à Swagger UI à l'adresse suivante : [http://localhost:8080](http://localhost:8080).

### Points de terminaison disponibles

#### Départements
- **GET /api/Departements** : Récupère tous les départements.
- **GET /api/Departements/{id}** : Récupère un département par ID.
- **POST /api/Departements** : Crée un nouveau département.
- **PUT /api/Departements/{id}** : Met à jour un département existant.
- **DELETE /api/Departements/{id}** : Supprime un département.

#### Missions
- **GET /api/Missions** : Récupère toutes les missions.
- **GET /api/Missions/{id}** : Récupère une mission par ID.
- **POST /api/Missions** : Crée une nouvelle mission.
- **PUT /api/Missions/{id}** : Met à jour une mission existante.
- **DELETE /api/Missions/{id}** : Supprime une mission.

#### Employés
- **GET /api/Employees** : Récupère tous les employés.
- **GET /api/Employees/{id}** : Récupère un employé par ID.
- **POST /api/Employees** : Crée un nouvel employé.
- **PUT /api/Employees/{id}** : Met à jour un employé existant.
- **DELETE /api/Employees/{id}** : Supprime un employé.

#### Projets
- **GET /api/Projects** : Récupère tous les projets.
- **GET /api/Projects/{id}** : Récupère un projet par ID.
- **POST /api/Projects** : Crée un nouveau projet.
- **PUT /api/Projects/{id}** : Met à jour un projet existant.
- **DELETE /api/Projects/{id}** : Supprime un projet.

## Points de terminaison disponibles

...

#### Affectations (Assignments)
- **GET /api/assignments** : Récupère toutes les affectations.
- **GET /api/assignments/{workerId}/{projectId}** : Récupère une affectation par ID de travailleur et ID de projet.
- **POST /api/assignments** : Crée une nouvelle affectation.
- **DELETE /api/assignments/{workerId}/{projectId}** : Supprime une affectation.

...


#### Prévisions météorologiques
- **GET /weatherforecast** : Récupère les prévisions météorologiques.

## Contribution

1. Forkez le projet
2. Créez une branche de fonctionnalité (`git checkout -b feature/AmazingFeature`)
3. Commitez vos modifications (`git commit -m 'Add some AmazingFeature'`)
4. Poussez votre branche (`git push origin feature/AmazingFeature`)
5. Ouvrez une Pull Request

## Licence

Distribué sous la licence MIT. Voir `LICENSE` pour plus d'informations.



Lien du projet : https://github.com/ridha-boughediri/rocheval-api-rest/api-worker/.git
