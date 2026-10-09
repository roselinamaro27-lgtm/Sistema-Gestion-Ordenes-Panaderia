# Sistema de Gestión de Órdenes de Panadería

## Descripción del proyecto

El Sistema de Gestión de Órdenes de Panadería es una aplicación web desarrollada con ASP.NET Core MVC que permite administrar los productos, clientes y pedidos de una panadería.

El proyecto tiene como objetivo facilitar la organización de la información mediante operaciones CRUD (Crear, Leer, Actualizar y Eliminar), permitiendo registrar, consultar, modificar y eliminar datos.

## Funcionalidades principales

* **Gestión de productos:** permite registrar productos, consultar sus datos, modificar precios y actualizar existencias.
* **Gestión de clientes:** permite registrar clientes y administrar su información de contacto.
* **Gestión de pedidos:** permite crear, consultar, modificar y eliminar pedidos asociados a los clientes.
* **Gestión de detalles de pedidos:** permite registrar los productos incluidos en cada pedido, junto con sus cantidades y precios.
* **Navegación:** cuenta con una página de inicio y un menú para acceder a las diferentes secciones del sistema.

## Tecnologías utilizadas

* C#
* ASP.NET Core MVC
* .NET 8
* Entity Framework Core
* SQL Server LocalDB
* HTML
* CSS
* Bootstrap
* Razor Views
* Git y GitHub

## Estructura del proyecto

El proyecto está organizado siguiendo el patrón arquitectónico Modelo-Vista-Controlador (MVC).

* **Models:** contiene las clases que representan las entidades del sistema, como Producto, Cliente, Pedido y DetallePedido.
* **Views:** contiene las interfaces que permiten al usuario interactuar con la aplicación.
* **Controllers:** contiene la lógica que procesa las solicitudes y coordina las operaciones entre las vistas y los datos.
* **Data:** contiene el contexto de Entity Framework Core utilizado para conectar la aplicación con la base de datos.

## Base de datos

La aplicación utiliza SQL Server LocalDB como sistema de almacenamiento y Entity Framework Core para gestionar el acceso a los datos.

La base de datos se llama `PanaderiaDB` y contiene las siguientes tablas:

* Productos
* Clientes
* Pedidos
* DetallesPedido

Las migraciones de Entity Framework Core permiten crear y actualizar la estructura de la base de datos.

## Instalación y ejecución

Para ejecutar el proyecto localmente, se recomienda seguir estos pasos:

1. Clonar o descargar el repositorio.
2. Abrir la solución en Visual Studio.
3. Verificar que estén instalados el SDK de .NET 8 y SQL Server LocalDB.
4. Revisar la cadena de conexión en el archivo `appsettings.json`.
5. Abrir la Consola del Administrador de paquetes de Visual Studio.
6. Ejecutar el comando `Update-Database` para crear la base de datos.
7. Ejecutar el proyecto desde Visual Studio.

## Objetivo académico

Este proyecto fue desarrollado como parte de las prácticas de programación, con el propósito de aplicar los conocimientos sobre ASP.NET Core MVC, organización del código, operaciones CRUD, conexión a bases de datos, Entity Framework Core y control de versiones con Git y GitHub.


Proyecto académico desarrollado por Roselin Amaro.
