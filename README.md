# Taller Scaffold

Esta actividad esta referenciada a esta tarea: Utilizar el comando Scaffold-DbContext para crear el modelo basado en una Base de Datos existente

## Paquetes de Nuget Requeridos 
Microsoft.EntityFrameworkCore v6.0.18
Microsoft.EntityframeworkCore.Design v6.0.18
Microsoft.EntityframeworkCore.SqlServer v6.0.18
Microsoft.EntityframeworkCore.Tools v6.0.18
Swashbuckle.AspNetCore v6.2.3 -> (Se incluye automaticamente)


## Creación
Se debe de crear la carpeta models dentro de la aplicacion como tal.
Luego instalar los paquetes requeridos.
Posteriormente se debe de ejecutar el siguiente comando.
Scaffold-DbContext " connectionstring " Microsoft.EntityFramework.SqlServer -OutputDir Models
Donde connectionstring es el connectionstring respectivo de tu base de datos 

## Recomendaciones
Es necesario contar con el connection String correcto para que los cambios surgan efectos. 
