FROM mcr.microsoft.com/mssql/server:2019-latest

# Accepter les termes de la licence et définir le mot de passe SA
ENV ACCEPT_EULA=Y
ENV SA_PASSWORD=Jesuismilliionnaire
ENV MSSQL_PID=Developer

# Exposer le port utilisé par SQL Server
EXPOSE 1433

# Commande pour démarrer SQL Server
CMD ["/opt/mssql/bin/sqlservr"]
