FROM mysql:8.0.21
COPY sql/database.sql /docker-entrypoint-initdb.d