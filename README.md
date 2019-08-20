# Pro Finder Back

Pro Finder Back es una API RESTful desarrollada en .NET Core.

El objetivo del proyecto es implementar un sistema de ejemplo utilizando tecnologías actuales y buenas prácticas del desarrollo de software.


## Requisitos

Para poder ejecutar el proyecto necesitas:

- Visual Studio 2017 o superior actualizado a la última versión.
- .NET Core SDK 2.2.
- SQL Server Express LocalDB o SQL Server Express (2016 o superior).
- Git.


## Instalación

Para poder descargar el proyecto y ejecutarlo debes seguir los siguientes pasos:

1) Clonar el repositorio con el siguiente comando:
	```
	git clone https://github.com/juanjduranr/profinderback.git
	```
2) Luego de tener una copia del proyecto debes abrir la solución con Visual Studio.

3) Una vez el proyecto se encuentre cargado en Visual Studio, debes configurar los proyectos de inicio:

	- Para esto debes hacer clic derecho sobre la solución y seleccionar la opción "Set StartUp ProJects...".
	![alt text](http://i.imgur.com/XOJMLGh.png)
	- Luego en la ventana, debajo de la opción "Common properties" -> "Startup proyects" debes marcar la opción "Multiple starup projects". 
	- Debes seleccionar en la columna action "Start" para los proyectos ProFinder.AuthIdsrv y ProFinder.WebApi (y debes verificar que el proyecto AuthIdsrv este de primer lugar).
	![alt text](http://i.imgur.com/C20Ca9P.png)
	- Para finalizar debes aplicar los cambios y aceptar.

4) Verificar que el proyecto ProFinder.AuthIdsrv utilice el puerto 5000:

	- Debes hacer clic derecho sobre el proyecto ProFinder.AuthIdsrv y seleccionar "properties"
	- Seleccionar la opción "Debug"
	- Verificar que en "Web Server Settings" la "App URL" sea http://localhost:5000
	![alt text](http://i.imgur.com/gaZemlY.png)

5) Iniciar el proyecto en Visual Studio.

	Al iniciar el proyecto, se crea la base de datos y se agrega la información automáticamente, este proceso utiliza por defecto SQL Server Express LocalDB en caso de que quieras utilizar SQL Server Express debes cambiar la cadena de conexión de la base de datos en el appsettings.Development.json.


## Arquitectura

La aplicación utiliza una arquitectura en capas (onion architecture):

- ProFinder.Core 
- ProFinder.Infrastructure 
- ProFinder.WebApi

Para poder crear los JSON Web Token (JWT) y autenticar algunos métodos de la API se utilizó Identity Server 4 (IDSRV).

IDSRV 4 es un framework de OpenID Connect y OAuth 2.0 para .NET Core. (http://docs.identityserver.io/en/latest/) 

Para facilitar la instalación y configuración de la aplicación, se agregó IDSRV en un proyecto dentro de la misma solución. Este proyecto carga los datos de los usuarios y de las aplicaciones de un archivo de configuración (Config.cs) y los mantiene en memoria (no utiliza base de datos).

Para otro tipo de proyectos en donde se deba mantener a los usuarios y las aplicaciones a las que van a acceder, se recomienda implementar IDSRV en una solución aparte y utilizar una base de datos.

En el sistema se utilizaron los siguientes patrones de diseño:

- Repository pattern
- Unit of work
- Data transfer object (DTO)
- Dependency inyection (DI)


## Tecnologías utilizadas

- ASP.NET Core 2.2
- ASP.NET Api Core
- Serilog
- IdentityServer 4


## Pro Finder Front

Se agrego la configuración del intercambio de recursos de origen cruzado (CORS) para permitir que la aplicación implementada en react (Pro Finder Front) pueda consumir los servicios de la API. Por defecto está configurado en el puerto 3000 (en caso de ejecutar la aplicación de react en otro puerto se debe actualizar en el appsettings.Development.json).

## Autor

Juan José Durán Rodríguez