📊 APP-GANADERIA

APP-GANADERIA es una aplicación diseñada para la gestión integral de agricultura y ganadería. Esta herramienta permite a los usuarios realizar compras de productos agrícolas, gestionar inventarios de insumos, y acceder a servicios especializados, como veterinarios o de inseminación. Además, la aplicación incluye funcionalidades de remates y subastas para facilitar el intercambio de animales y productos.

🚀 Características Principales

Marketplace de productos agrícolas y ganaderos: Compra y venta de pesticidas, alimentos para ganado, semillas y más.
Gestión de inventarios: Control completo de insumos y productos.
Servicios especializados: Solicitud de servicios veterinarios, inseminación, asesoría agrícola, entre otros.
Gestión de animales: Registro de especies y razas, ubicación, y otros detalles.
Remates y subastas: Organización de eventos de remate de ganado, con información de contacto y ubicación.

⚙️ Configuración e Instalación

Paso 1: Clonar el repositorio

bash
Copiar código
[git clone https://github.com/tu_usuario/APP-GANADERIA.git](https://github.com/ElPanadero123/Ganaderia_API.git)
cd APP-GANADERIA

Paso 2: Configurar la Base de Datos

Este proyecto utiliza SQL Server. Asegúrate de tenerlo instalado y funcionando en tu sistema.

Crea una base de datos en SQL Server para el proyecto (por ejemplo, Examen).

Modificar la cadena de conexión: En el archivo appsettings.json, ubica la línea:

"ConnectionStrings": {
    "Conn": "Server=MATIAS-BRAVO;Database=Examen;Trusted_Connection=True;TrustServerCertificate=True"
}

Cambia Server y Database según los valores de tu instancia de SQL Server y el nombre de tu base de datos. Por ejemplo:

"ConnectionStrings": {
    "Conn": "Server=TU-SERVIDOR;Database=TU-BASE-DE-DATOS;Trusted_Connection=True;TrustServerCertificate=True"
}

Server: Especifica el nombre de tu servidor SQL Server (por ejemplo, localhost, o NOMBRE-SERVIDOR).
Database: Especifica el nombre de la base de datos que creaste para el proyecto.
