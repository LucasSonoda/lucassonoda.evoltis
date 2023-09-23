### Stack

- AspNet Webforms
- Net Framework v4.8
- ORM: EF6

### Ejecutar Base de Datos
Lo primero que debemos hacer es revisar de tener instalado "Windows subsystem for windows" en la PC
Luego tener instalado Docker Desktop (version utilizada 23.0.5)

Ahora debemos ingresar en la carpera raíz del proyecto "./lucassonoda.evoltis/"

Luego abrir una consola apuntando a esta ubication y escribir los siguientes comandos:
	1- "docker build -t "sqltest:Dockerfile" ."
	2- "docker run -d -p 1433:1433 --name sqlserver --hostname sqlserver sqltest:Dockerfile" (Espera al menos 30 segundos antes de avanzar al siguiente comando)
	3- "docker exec -it sqlserver" Con esto ingresamos en el contenedor que acabamos de ejecutar. 
	4- Por ultimo dentro del contenedor debemos pegar esto ultimo y ejecutarlo "/opt/mssql-tools/bin/sqlcmd -S localhost -U SA -P '!Desafio123' -d master -i script.sql".

Con esto debería estar funcionando la base de datos, en caso de error o no poder levantarla se puede crear la base de datos con un script ubicado en la raiz del proyecto ("script.sql")  el cual contiene todo lo necesario.

> hay que tener en cuenta de actualizar el web.config con las credenciales de la db nueva 
> (si se realizo la operación mediante docker este ultimo paso no es necesario). 


### Ejecución del proyecto

Primero debemos ingresar en el archivo lucassonoda.evoltis.sln
-  Antes de Iniciar la application realizar un Clean y posterior un Build
-  Ahora si ya podemos iniciar la application.