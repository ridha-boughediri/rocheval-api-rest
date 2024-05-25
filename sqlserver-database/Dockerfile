FROM mcr.microsoft.com/mssql/server:2019-latest

# Set environment variables
ENV ACCEPT_EULA=Y

# Copy initialization script
COPY init-db.sql /docker-entrypoint-initdb.d/

USER mssql

# Run SQL Server process
CMD /opt/mssql/bin/sqlservr
