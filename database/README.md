# Base de Datos - Clínica San Manotas

## Instalación

Ejecutar en MySQL Workbench en este orden:

1. `01-crear-base-datos.sql` - Crea la estructura
2. `02-insertar-datos.sql` - Inserta datos de prueba

## Credenciales de Prueba

| Usuario | Contraseña | Rol |
|---------|------------|-----|
| admin | admin123 | Administrador |
| recepcionista1 | recep123 | Recepcionista |
| dr_garcia | doctor123 | Doctor |

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
