# Clínica San Manotas

Hola profe Manotas, este es nuestro trabajo.

**Integrantes:**
- Juan David Aguilar Garizabal
- Danna Valentina Quintero
- Esau David Ortiz

**Programa:** ADSO - Ficha 3052186

---

Sistema de gestión para clínica médica desarrollado en C# con Windows Forms y MySQL.

## Requisitos

- .NET 8.0
- MySQL 8.0+
- Windows 10/11

## Instalación

1. Abrir MySQL Workbench
2. Ejecutar scripts SQL en orden:
   ```
   database/scripts/01-crear-base-datos.sql
   database/scripts/02-insertar-datos.sql
   ```
3. Abrir el proyecto en Visual Studio
4. Compilar y ejecutar (F5)

## Usuarios de Prueba

Todos tienen contraseña: **123456**

| Usuario | Rol |
|---------|-----|
| admin | Administrador |
| recepcionista1 | Recepcionista |
| recepcionista2 | Recepcionista |
| dr_garcia | Doctor |
| dr_martinez | Doctor |

## Funcionalidades

- Gestión de pacientes (CRUD completo)
- Programación de citas médicas
- Control de médicos y especialidades
- Administración de usuarios
- Sistema de permisos por rol
- Gestión de EPS

## Estructura

```
SistemaEmpleadosMySQL/
 Model/          # Entidades
 DAO/            # Acceso a datos
 Repositories/   # Lógica de negocio
 UI/Forms/       # Formularios Windows Forms
 Helpers/        # Utilidades
```

## Stack

- C# / .NET 8.0
- Windows Forms
- MySQL 8.0
- MySql.Data (ADO.NET)

**SENA - Evaluación C#**
