# CrudWebTest
CrudWebTest With docker Compose

If you don't create database could you run this script:

 docker exec -it crudtestweb_db_1 /opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P Your_password123 -i /docker-entrypoint-initdb.d/init.sql
 
 The App was build:
 - Backend: Dotnet 6 , clean architecture, modular monolith, DDD, Domain Events
 - Frontend: Angular 15, clean architecture
 - Persistence: Db in Sql server with event logs
