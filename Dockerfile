FROM mcr.microsoft.com/mssql/server:2022-latest
ENV ACCEPT_EULA=Y
ENV MSSQL_SA_PASSWORD=!Desafio123
ENV MSSQL_RPC_PORT=135
ENV container_name=sqlserver
ENV hostname=sqlserver
COPY script.sql . 
COPY initialization.sh .
EXPOSE 1433
USER mssql
CMD ["/bin/bash"]
CMD ["./initialization.sh"]
ENTRYPOINT ["/opt/mssql/bin/permissions_check.sh"]