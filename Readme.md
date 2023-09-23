### Stack

- AspNet Webforms
- Net Framework v4.8
- ORM: EF6

### Ejecutar Base de Datos
Esta se puede instalar mediante docker (version utilizada 23.0.5)
Primero ingresar a la carpera raíz del proyecto "./lucassonoda.evoltis/"

Luego abrir una consola apuntando a esta ubication y escribir los siguientes comandos:
	1- docker build -t "sqltest:Dockerfile" .
	2- docker run -d -p 1433:1433 --name sqlserver --hostname sqlserver sqltest:Dockerfile
	3- docker exec -t sqlserver cat /var/opt/mssql/log/errorlog

Con esto debería estar funcionando la base de datos, en caso de error o no poder levantarla se puede crear la base de datos con un script ubicado en la raiz del proyecto ("script.sql")  el cual contiene todo lo necesario.

> hay que tener en cuenta de actualizar el web.config con las credenciales de la bd nueva 
> (si se realizo la operación mediante docker este ultimo paso no es necesario). 

Por ultimo Abrir el archivo .sln y ejectuar utilizando IIS Express.