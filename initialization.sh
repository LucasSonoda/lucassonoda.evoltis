{
    sleep 60s 
    /opt/mssql-tools/bin/sqlcmd -S localhost -U SA -P !Desafio123 -d master -i script.sql 
} &
/opt/mssql/bin/sqlservr 