# Ensemble de Microservices Rocheval

## Introduction
Cet ensemble de microservices fournit une architecture robuste pour le développement d'applications avec des services spécialisés tels que l'authentification, la gestion des mails, le traitement par des workers et le stockage des données.

## Composants
Les composants de l'ensemble incluent :
- **api-worker**: Service de backend destiné à traiter les tâches en arrière-plan.
- **Auth-Api**: Interface API pour les services d'authentification.
- **Auth-JWT**: Service pour la génération et la validation des tokens JWT.
- **MailerService**: Service de gestion des envois d'emails.
- **sqlserver-database**: Base de données Microsoft SQL Server configurée pour être utilisée avec Docker.

## Prérequis
- .NET Core pour l'exécution des solutions .NET.
- Docker et Docker Compose pour la gestion des conteneurs.
- Un client SQL pour accéder à SQL Server.

## Configuration
Chaque service doit être configuré conformément à ses exigences spécifiques. Les informations de configuration peuvent être trouvées dans les fichiers de configuration individuels ou les variables d'environnement pour chaque service.

## Démarrage rapide
1. **Cloner le dépôt** :
   ```bash
   git clone [URL_DU_DEPOT]
   cd [NOM_DU_REPO]
1. **Construire et démarrer tous les services :**
   ```bash
   docker-compose up --build -d

Cette commande va construire et lancer tous les containers définis dans votre fichier docker-compose.yml.



Utilisation
Vous pouvez accéder aux services via les ports configurés sur votre machine locale :

api-worker : Port spécifié dans le docker-compose ou la configuration du service.
Auth-Api : Port spécifié pour accéder aux endpoints d'authentification.
Auth-JWT : Port utilisé pour les requêtes de validation de tokens.
MailerService : Port configuré pour envoyer des emails.
SQL Server : Connectez-vous via le port 1455 avec les identifiants configurés.

