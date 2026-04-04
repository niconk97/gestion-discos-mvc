# Gestion de Discos MVC

Aplicacion ASP.NET Core MVC para gestion de discos musicales derivado del proyecto de Maxi Programa https://github.com/msarfernandez/discos-console-db.

El proyecto esta organizado en capas para separar responsabilidades y facilitar mantenimiento.

## Objetivo

Permitir operaciones CRUD sobre discos, usando una capa de negocio reutilizable y soporte para dos motores de base de datos:

- SQL Server
- SQLite

## Arquitectura

La solucion contiene 3 proyectos principales:

- Discos.Dominio
	- Entidades de negocio: Disco, Estilo, TipoEdicion.

- Discos.Negocio
	- Casos de uso (DiscoNegocio, EstiloNegocio, TipoEdicionNegocio).
	- Implementaciones concretas para SQL Server y SQLite.

- Discos.Web
	- Capa MVC (controllers, views, layout).
	- Listado de discos y acciones CRUD base.

## Tecnologias

- .NET 9
- ASP.NET Core MVC
- Microsoft.Data.SqlClient (SQL Server)
- Microsoft.Data.Sqlite (SQLite)

## Requisitos

- .NET SDK 9.0 o superior
- Visual Studio 2022 / VS Code (opcional)
- Opcional: SQL Server Express si se usa proveedor SQL Server

## Base de datos

### SQLite

Script de esquema y datos de ejemplo:

- Discos.Negocio/script_db/discos_db_sqlite.sql

La implementacion SQLite busca el archivo discos.db en rutas relativas al proyecto.

### SQL Server

La implementacion SQL Server usa cadena de conexion local (SQLEXPRESS). Ajustar en la clase de acceso correspondiente si es necesario.
