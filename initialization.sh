SQL_SCRIPT_DIR="/tmp"
SQL_SCRIPT_FILE="script.sql"
{
    if [ ! -f "$SQL_SCRIPT_DIR/$SQL_SCRIPT_FILE" ]; then
    echo "Primera ejecución del contenedor"
    sleep 60s
    echo "Ejecutando script sql"
    /opt/mssql-tools/bin/sqlcmd -S localhost -U SA -P !Desafio123 -d master -i script.sql

    # Marcar que el script SQL ya se ha ejecutado creando el archivo
    touch "$SQL_SCRIPT_DIR/$SQL_SCRIPT_FILE"
    fi
} &
/opt/mssql/bin/sqlservr 