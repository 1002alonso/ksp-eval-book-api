# ksp-eval-book-api
# Proyecto .NET Core 8

ksp-eval-book-api esta desarrollado con .NET Core 8. El propósito de este proyecto es evaluar los conocimientos sobre Apis Rest y Clean Code.

## Contenido

- [Requisitos](#requisitos)
- [Instalación](#instalación)
- [Uso](#uso)
- [Estructura del Proyecto](#estructura-del-proyecto)
- [Pruebas](#pruebas)

## Requisitos

- [.NET Core 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Visual Studio 2022](https://visualstudio.microsoft.com/vs/) o [Visual Studio Code](https://code.visualstudio.com/)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (u otra base de datos que estés utilizando)


## Instalación

1. Clona el repositorio:

    ```bash
    git clone https://github.com/1002alonso/ksp-eval-book-api.git de la rama development
    cd tu-repositorio
    ```

2. Restaura los paquetes NuGet:

    ```bash
    dotnet restore
    ```

3. Configura la base de datos (opcional):

    - Asegúrate de que tu base de datos SQL Server esté en funcionamiento.
    - En la carpeta Documentation se encuentra el script para la creacion de la base de datos, con los datos iniciales.
    - Este escript se ejecutar en una New Query con Microsoft SQL Server Management Studio
    - Actualiza `appsettings.json` con tu cadena de conexión a la base de datos.


## Uso

Para iniciar la aplicación, usa el siguiente comando:

    ```bash
      dotnet run
    ```


## Estructura del Proyecto

/KSP-EVAL-BOOK-API
├── /KspEvalBook.Api               # Controladores de la aplicación
├    ├── Program.cs                # Punto de entrada de la aplicación
├    └── appsettings.json          # Configuración de la aplicación
├── /KspEvalBook.Application       # Modelo de negocio y caso de usos
├── /KspEvalBook.Domain            # Interfaces
├── /KspEvalBook.Infrastructure    # Conexion a base de datos y sus tablas
├── /Documentation                 # Documento guia para la creacion de modulos y script para restaurar la bd
         
  
## Pruebas
dotnet test
