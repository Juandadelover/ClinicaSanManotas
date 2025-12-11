# Base de Datos - Clínica San Manotas

## Instalación

Ejecutar en MySQL Workbench en este orden:

1. `01-crear-base-datos.sql` - Crea la estructura
2. `02-insertar-datos.sql` - Inserta datos de prueba

## Credenciales de Prueba

| Usuario | Contraseña | Rol |
|---------|------------|-----|
| admin | 123456 | Administrador |
| recepcionista1 | 123456 | Recepcionista |
| dr_garcia | 123456 | Doctor |

## Tablas

- **usuario** - Usuarios del sistema
- **eps** - Entidades prestadoras de salud
- **especialidad** - Especialidades médicas
- **medico** - Médicos
- **paciente** - Pacientes
- **cita** - Citas médicas
- **auditlog** - Registro de auditoría

## Conexión

```
Server: localhost
Database: clinica_san_manotas
User: root
Password: 12345
```
