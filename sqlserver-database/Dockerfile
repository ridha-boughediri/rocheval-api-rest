FROM mcr.microsoft.com/mssql/server:2019-latest

ENV ACCEPT_EULA=Y
ENV SA_PASSWORD=${SA_PASSWORD}

COPY init-db.sql /docker-entrypoint-initdb.d/
