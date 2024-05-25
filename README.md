
# SQL Server with Docker and Adminer

This repository contains a Docker setup to run SQL Server 2019 and Adminer, a database management tool. The SQL Server instance is initialized with a custom script to set up the database and its schema.

## Prerequisites

- Docker
- Docker Compose

## Getting Started

### Environment Variables

Create a `.env` file in the root of the project to specify the environment variables:

```env
SA_PASSWORD=root
DB_NAME=rocheval
```

### Docker Compose

The `docker-compose.yml` file defines the services for SQL Server and Adminer.

```yaml
version: '3.3'

services:
  sqlserver:
    build: .
    container_name: sqlserver
    ports:
      - "1433:1433"
    environment:
      SA_PASSWORD: "${SA_PASSWORD}"
      ACCEPT_EULA: "Y"
    volumes:
      - sqlserver_data:/var/opt/mssql
      - ./init-db.sql:/docker-entrypoint-initdb.d/init-db.sql

  adminer:
    image: adminer
    container_name: adminer
    ports:
      - "8083:8080"
    environment:
      ADMINER_DEFAULT_SERVER: sqlserver

volumes:
  sqlserver_data:
```

### Dockerfile

The `Dockerfile` is used to build a custom Docker image for SQL Server.

```Dockerfile
FROM mcr.microsoft.com/mssql/server:2019-latest

# Set environment variables
ENV ACCEPT_EULA=Y

# Copy initialization script
COPY init-db.sql /docker-entrypoint-initdb.d/

USER mssql

# Run SQL Server process
CMD /opt/mssql/bin/sqlservr
```

### Initialization Script

The `init-db.sql` script is used to initialize the database and set up the schema.

```sql
CREATE DATABASE ${DB_NAME};
GO

USE ${DB_NAME};
GO

CREATE TABLE Users (
    Id INT PRIMARY KEY IDENTITY,
    FirstName NVARCHAR(100),
    LastName NVARCHAR(100),
    Email NVARCHAR(100) UNIQUE,
    Password NVARCHAR(100)
);
GO
```

### Building and Running the Containers

To build and run the containers, execute the following commands:

```sh
docker-compose down
docker-compose build
docker-compose up -d
```

### Accessing Adminer

Adminer can be accessed in your web browser at `http://localhost:8083`. Use the following credentials to connect:

- **System:** MS SQL
- **Server:** sqlserver
- **Username:** sa
- **Password:** (as specified in your `.env` file)
- **Database:** (leave empty to see the list of databases)

### Logs and Troubleshooting

To view the logs for the SQL Server container, use the following command:

```sh
docker logs sqlserver
```

### Stopping the Containers

To stop the running containers, use:

```sh
docker-compose down
```
