# CLINICA SAN MANOTAS - Base de Datos

## Descripción General

Base de datos relacional MySQL 8.0+ para el sistema de gestión de clínicas. Incluye todas las tablas, índices, stored procedures y datos iniciales necesarios para el funcionamiento de la aplicación.

## Versión

- **Versión DB**: 1.0.0
- **Fecha Creación**: 2025-12-05
- **MySQL Requerido**: 8.0 o superior

## Estructura de Scripts

Los scripts de base de datos están numerados y deben ejecutarse en orden:

```
database/scripts/
├── 01-create-database.sql          # Crea BD y todas las tablas
├── 02-insert-initial-data.sql      # Inserta datos de referencia y prueba
├── 03-stored-procedures.sql        # Crea procedimientos almacenados
└── README-DATABASE.md              # Este archivo
```

## Instalación Paso a Paso

### Prerequisitos

- MySQL Server 8.0+ instalado y ejecutándose
- MySQL Workbench o cliente MySQL (mysql.exe)
- Acceso a usuario con permisos de administrador en MySQL

### Opción 1: Usando MySQL Workbench

1. **Abrir MySQL Workbench**

2. **Crear nueva conexión o usar existente**
   - Asegurarse de que la conexión está activa
   - Hacer clic en el icono para abrir nueva query tab

3. **Ejecutar Scripts en Orden**

   a) Ejecutar `01-create-database.sql`:
   ```
   - Abrir archivo: File → Open SQL Script
   - Seleccionar: 01-create-database.sql
   - Ejecutar: Ctrl+Shift+Enter o botón Execute
   - Esperar a que complete sin errores
   ```

   b) Ejecutar `02-insert-initial-data.sql`:
   ```
   - Repetir proceso con archivo 02-insert-initial-data.sql
   - Esto insertará datos de referencia y usuarios de prueba
   ```

   c) Ejecutar `03-stored-procedures.sql`:
   ```
   - Repetir proceso con archivo 03-stored-procedures.sql
   - Esto creará los procedimientos almacenados de consulta
   ```

4. **Verificar Instalación**
   ```sql
   USE clinica_san_manotas;
   SHOW TABLES;
   SELECT COUNT(*) as TotalTablas FROM information_schema.tables 
   WHERE table_schema = 'clinica_san_manotas';
   ```

### Opción 2: Usando Línea de Comandos

1. **Abrir Command Prompt o PowerShell**

2. **Navegar al directorio de scripts**
   ```powershell
   cd "C:\ruta\a\database\scripts"
   ```

3. **Conectarse a MySQL**
   ```powershell
   mysql -u root -p
   # Ingresar contraseña cuando se solicite
   ```

4. **Ejecutar scripts**
   ```sql
   SOURCE 01-create-database.sql;
   SOURCE 02-insert-initial-data.sql;
   SOURCE 03-stored-procedures.sql;
   ```

5. **Salir**
   ```sql
   EXIT;
   ```

### Opción 3: Script de Instalación Automática (PowerShell)

*Crear archivo `install-db.ps1` en la carpeta `database/scripts/`*

```powershell
# En PowerShell como Administrador
$mysqlPath = "C:\Program Files\MySQL\MySQL Server 8.0\bin"
$host_user = "root"
$host_password = "tu_contraseña_aqui"
$scripts_dir = Get-Location

# Ejecutar cada script
& "$mysqlPath\mysql.exe" -u $host_user -p$host_password < "$scripts_dir\01-create-database.sql"
& "$mysqlPath\mysql.exe" -u $host_user -p$host_password < "$scripts_dir\02-insert-initial-data.sql"
& "$mysqlPath\mysql.exe" -u $host_user -p$host_password < "$scripts_dir\03-stored-procedures.sql"

Write-Host "Base de datos instalada exitosamente!"
```

## Esquema de Base de Datos

### Tablas Principales

#### 1. **Usuario** (5 registros iniciales)
Usuarios del sistema con roles (Admin, Recepcionista, Doctor)

| Campo | Tipo | Descripción |
|-------|------|-------------|
| UserId | INT | Clave primaria |
| Username | VARCHAR(50) | Nombre de usuario único |
| Email | VARCHAR(100) | Email único |
| PasswordHash | VARCHAR(255) | Hash bcrypt de contraseña |
| Role | ENUM | Admin, Recepcionista, Doctor |
| Estado | ENUM | Activo, Inactivo, Bloqueado |

#### 2. **Especialidad** (10 registros iniciales)
Especialidades médicas de referencia

| Campo | Tipo | Descripción |
|-------|------|-------------|
| EspecialidadId | INT | Clave primaria |
| Nombre | VARCHAR(100) | Nombre de especialidad |
| Descripcion | TEXT | Descripción detallada |

#### 3. **EPS** (8 registros iniciales)
Empresas Promotoras de Salud (aseguradoras)

| Campo | Tipo | Descripción |
|-------|------|-------------|
| EPSId | INT | Clave primaria |
| Nombre | VARCHAR(100) | Nombre de EPS |
| Nit | VARCHAR(20) | NIT único |
| Telefono | VARCHAR(20) | Contacto telefónico |
| Email | VARCHAR(100) | Email de contacto |

#### 4. **Medico** (8 registros iniciales)
Médicos del sistema

| Campo | Tipo | Descripción |
|-------|------|-------------|
| MedicoId | INT | Clave primaria |
| Nombres | VARCHAR(100) | Nombre del médico |
| Apellidos | VARCHAR(100) | Apellido del médico |
| Licencia | VARCHAR(50) | Número de licencia única |
| EspecialidadId | INT | FK a Especialidad |
| HorarioInicio | TIME | Hora inicio jornada |
| HorarioFin | TIME | Hora fin jornada |
| DiasAtencion | VARCHAR(50) | Días de atención (ej. Lunes-Viernes) |

#### 5. **Paciente** (10 registros iniciales)
Pacientes de la clínica

| Campo | Tipo | Descripción |
|-------|------|-------------|
| PacienteId | INT | Clave primaria |
| Nombres | VARCHAR(100) | Nombres del paciente |
| Apellidos | VARCHAR(100) | Apellidos del paciente |
| Documento | VARCHAR(20) | Cédula única |
| FechaNacimiento | DATE | Fecha de nacimiento |
| Genero | ENUM | M, F, Otro |
| EPSId | INT | FK a EPS |
| Direccion | VARCHAR(200) | Dirección |

#### 6. **Cita** (10 registros iniciales)
Citas médicas

| Campo | Tipo | Descripción |
|-------|------|-------------|
| CitaId | INT | Clave primaria |
| PacienteId | INT | FK a Paciente |
| MedicoId | INT | FK a Medico |
| Fecha | DATE | Fecha de cita |
| Hora | TIME | Hora de cita |
| Motivo | VARCHAR(500) | Motivo de consulta |
| Estado | ENUM | Pendiente, Confirmada, Cancelada, Realizada |

#### 7. **AuditLog**
Registro de auditoría de cambios

| Campo | Tipo | Descripción |
|-------|------|-------------|
| AuditId | INT | Clave primaria |
| Tabla | VARCHAR(100) | Tabla modificada |
| Operacion | ENUM | INSERT, UPDATE, DELETE |
| ValoresAnteriores | JSON | Valores antes de cambio |
| ValoresNuevos | JSON | Valores después de cambio |

#### 8. **migrations**
Control de versión de scripts ejecutados

| Campo | Tipo | Descripción |
|-------|------|-------------|
| id | INT | Clave primaria |
| name | VARCHAR(255) | Nombre del script |
| applied_at | DATETIME | Fecha de aplicación |

### Relaciones Principales

```
Usuario (1) ──→ (N) AuditLog
Especialidad (1) ──→ (N) Medico
EPS (1) ──→ (N) Paciente
Medico (1) ──→ (N) Cita
Paciente (1) ──→ (N) Cita
```

## Datos Iniciales

### Usuarios de Prueba

| Username | Password | Rol | Email |
|----------|----------|-----|-------|
| admin | admin123 | Admin | admin@clinicamanotas.com |
| recepcionista1 | recep123 | Recepcionista | recepcionista1@clinicamanotas.com |
| recepcionista2 | recep123 | Recepcionista | recepcionista2@clinicamanotas.com |
| dr_garcia | doctor123 | Doctor | garcia@clinicamanotas.com |
| dr_martinez | doctor123 | Doctor | martinez@clinicamanotas.com |

### Especialidades de Prueba
- Cardiología
- Dermatología
- Medicina General
- Odontología
- Oftalmología
- Otorrinolaringología
- Pediatría
- Traumatología
- Neurología
- Psiquiatría

### EPS de Prueba
- SURA
- Axa Colpatria
- Coomeva
- Sanitas
- Compensar
- Famisanar
- Salud Total
- Digna

## Procedimientos Almacenados

Implementados 8 stored procedures para operaciones comunes:

1. **sp_GetAvailableAppointmentSlots** - Obtiene horarios disponibles
2. **sp_GetPatientAppointmentHistory** - Historial de citas de paciente
3. **sp_GetDoctorsBySpecialty** - Médicos por especialidad
4. **sp_SearchPatients** - Búsqueda avanzada de pacientes
5. **sp_GetAppointmentsByDate** - Citas por fecha
6. **sp_GetAppointmentsByStatus** - Citas por estado
7. **sp_GetPatientsByAge** - Pacientes por rango de edad
8. **sp_GetPatientsByRegistrationDate** - Pacientes por fecha de registro

## Funciones

1. **fn_CalculatePatientAge** - Calcula edad de paciente

## Índices

Se han creado índices en columnas clave para optimizar rendimiento:

- Búsquedas por usuario: `idx_username`, `idx_email`
- Búsquedas por paciente: `idx_documento`, `idx_eps`, `idx_genero`
- Búsquedas por cita: `idx_fecha`, `idx_estado`, `idx_paciente_fecha`
- Búsquedas por médico: `idx_licencia`, `idx_especialidad`

## Validaciones de Base de Datos

### Restricciones Únicas
- Username único
- Email único por usuario
- Licencia médica única
- Documento de paciente único
- NIT de EPS único
- No hay citas duplicadas (mismo médico, fecha, hora)

### Restricciones de Clave Foránea
- Médico debe pertenecer a especialidad existente
- Paciente debe estar asignado a EPS existente
- Cita debe tener paciente y médico existentes

## Seguridad

- ✓ Todas las contraseñas están hasheadas con bcrypt
- ✓ Las consultas usan parámetros (previene SQL Injection)
- ✓ Tabla de auditoría para tracking de cambios
- ✓ UTF-8mb4 para caracteres especiales seguros

## Backup y Recovery

### Crear Backup
```powershell
mysqldump -u root -p clinica_san_manotas > clinica_backup_2025-12-05.sql
```

### Restaurar Backup
```powershell
mysql -u root -p clinica_san_manotas < clinica_backup_2025-12-05.sql
```

## Troubleshooting

### Error: "Access denied for user"
- Verificar que MySQL está ejecutándose
- Verificar credenciales de usuario
- Asegurarse de que el usuario tiene permisos CREATE DATABASE

### Error: "Table already exists"
- La base de datos ya existe
- Ejecutar: `DROP DATABASE IF EXISTS clinica_san_manotas;`
- Antes de ejecutar 01-create-database.sql

### Error: "Foreign key constraint fails"
- Asegurarse de ejecutar scripts en orden
- No omitir script 01-create-database.sql
- Verificar que datos de referencia estén insertados (script 02)

## Conexión desde Aplicación C#

### Cadena de Conexión Recomendada
```csharp
"Server=localhost;Database=clinica_san_manotas;User Id=root;Password=contraseña;SslMode=none;"
```

### Entity Framework Core
```csharp
services.AddDbContext<ClinicaContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
);
```

## Mantenimiento

### Limpieza Periódica
```sql
-- Limpiar citas canceladas más de 1 año atrás
DELETE FROM Cita 
WHERE Estado = 'Cancelada' 
AND DATEDIFF(DAY, FechaActualizacion, NOW()) > 365;
```

### Verificar Integridad
```sql
ANALYZE TABLE Usuario, Paciente, Medico, Cita, EPS;
OPTIMIZE TABLE Usuario, Paciente, Medico, Cita, EPS;
```

## Soporte

Para problemas o preguntas sobre la base de datos:
1. Verificar sintaxis SQL con MySQL Workbench
2. Revisar logs de MySQL: `SHOW ENGINE INNODB STATUS;`
3. Consultar documentación MySQL oficial

---

**Última actualización**: 2025-12-05  
**Estado**: ✓ Listo para producción  
**Versión de Base de Datos**: 1.0.0
