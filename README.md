# TiendaAPI

# Descripción
Esta es una aplicación web que permite realizar operaciones CRUD (Crear, Leer, Actualizar, Borrar) sobre una base de datos de productos. La aplicación incluye una WebAPI construida en ASP.NET Core, una interfaz de usuario en JavaScript, y utiliza SQL Server (o MySQL/PostgreSQL) para almacenar los datos.

# Tecnologías Utilizadas
ASP.NET Core - Para la creación de la WebAPI.
Entity Framework Core - Como ORM para interactuar con la base de datos.
SQL Server - Para el almacenamiento de datos.
JavaScript (Fetch) - Para el frontend e interacción con la API.
Git - Para el control de versiones.
Estructura del Proyecto
WebAPI en ASP.NET Core: Maneja las operaciones CRUD para los productos y expone los endpoints para las acciones de:
GET: Obtener todos los productos.
GET /{id}: Obtener un producto específico por ProductoID.
POST: Crear un nuevo producto.
PUT /{id}: Actualizar un producto existente.
DELETE /{id}: Eliminar un producto.
## Base de Datos: Tabla Productos con los campos:
ProductoID (int, clave primaria)
Nombre (varchar, obligatorio)
Precio (decimal, obligatorio)
FechaCreacion (datetime, por defecto la fecha actual)
## Frontend en JavaScript: Interfaz para mostrar la lista de productos y realizar operaciones CRUD a través de la WebAPI.
# Requisitos
Base de Datos SQL: Crear la tabla Productos en la base de datos elegida.
API en C#: Construir una WebAPI con ASP.NET Core y Entity Framework Core.
Control de Versiones: Utilizar Git para documentar el desarrollo en un repositorio.

# Instalación y Configuración
Clonar el repositorio:
git clone  https://github.com/GabrielVCI/TiendaAPI.git
cd TiendaAPI
Configurar la base de datos: Asegúrate de configurar la conexión a la base de datos en appsettings.json.

Ejecutar migraciones de Entity Framework Core:

dotnet ef database update
Ejecutar la API:
Ejecutela en Visual Studio o en VS Code

Abrir la interfaz de usuario: Dirígete al otro proyecto, luego al HTML principal (Home/Index) luego de abrir la aplicación. La interfaz permite:

Mostrar la lista de productos.
Crear, editar, y eliminar productos, también permite obtener productos usando el Id.
