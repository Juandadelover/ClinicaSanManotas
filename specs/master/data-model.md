# Data Model - CLINICA SAN MANOTAS

**Versión**: 1.0.0 | **Fecha**: 2025-12-05 | **Status**: ✓ DISEÑO COMPLETADO

---

## Diagrama Entidad-Relación (ER)

```
┌─────────────────┐
│     Usuario     │
├─────────────────┤
│ UserId (PK)     │
│ Username        │
│ Email           │
│ PasswordHash    │
│ Foto (blob)     │
│ Role            │
│ FechaCreacion   │
│ Estado          │
└────────┬────────┘
         │
         │ 1:N
         ▼
┌─────────────────┐      ┌──────────────────┐
│    Paciente     │◄─────┤      EPS         │
├─────────────────┤      ├──────────────────┤
│ PacienteId (PK) │      │ EPSId (PK)       │
│ Nombres         │      │ Nombre           │
│ Apellidos       │      │ Telefono         │
│ Email           │      │ Contacto         │
│ Telefono        │      └──────────────────┘
│ FechaNacimiento │
│ Genero          │
│ Documento       │
│ EPSId (FK)      │
│ Direccion       │
│ FechaRegistro   │
│ Estado          │
└────────┬────────┘
         │
         │ 1:N
         ▼
┌──────────────────┐
│    Cita          │
├──────────────────┤
│ CitaId (PK)      │
│ PacienteId (FK)  │
│ MedicoId (FK)    │
│ Fecha            │
│ Hora             │
│ Motivo           │
│ Estado           │
│ FechaCreacion    │
│ FechaActualizacion
└──────────────────┘
         ▲
         │ 1:N
┌────────┴────────┐
│     Medico      │
├─────────────────┤
│ MedicoId (PK)   │
│ Nombres         │
│ Apellidos       │
│ Email           │
│ Telefono        │
│ Licencia        │
│ EspecialidadId  │
│ HorarioInicio   │
│ HorarioFin      │
│ FechaRegistro   │
│ Estado          │
└────────┬────────┘
         │
         │ N:1
         ▼
┌──────────────────────┐
│   Especialidad       │
├──────────────────────┤
│ EspecialidadId (PK)  │
│ Nombre               │
│ Descripcion          │
└──────────────────────┘
```

---

## Entidades Detalladas

### 1. Usuario
**Propósito**: Autenticación y acceso al sistema

| Campo | Tipo | Constraints | Descripción |
|-------|------|-----------|-------------|
| UserId | INT | PK, AUTO_INCREMENT | Identificador único |
| Username | VARCHAR(50) | UNIQUE, NOT NULL | Usuario de login |
| Email | VARCHAR(100) | UNIQUE, NOT NULL | Correo electrónico |
| PasswordHash | VARCHAR(255) | NOT NULL | Hash bcrypt de contraseña |
| Foto | LONGBLOB | NULL | Fotografía del usuario |
| Role | ENUM('Admin','Recepcionista','Doctor') | NOT NULL | Rol en el sistema |
| FechaCreacion | DATETIME | NOT NULL | Fecha de creación |
| FechaUltimoLogin | DATETIME | NULL | Último acceso |
| Estado | ENUM('Activo','Inactivo','Bloqueado') | NOT NULL | Estado del usuario |

**Validaciones**:
- Username: 5-50 caracteres, sin espacios
- Email: Formato válido (regex)
- PasswordHash: Nunca almacenar contraseña en texto plano
- Role: Requerido, solo valores permitidos

**Índices**:
```sql
CREATE UNIQUE INDEX idx_username ON Usuario(Username);
CREATE UNIQUE INDEX idx_email ON Usuario(Email);
```

---

### 2. Especialidad
**Propósito**: Categorizar áreas de especialización médica

| Campo | Tipo | Constraints | Descripción |
|-------|------|-----------|-------------|
| EspecialidadId | INT | PK, AUTO_INCREMENT | Identificador único |
| Nombre | VARCHAR(100) | UNIQUE, NOT NULL | Nombre de especialidad |
| Descripcion | TEXT | NULL | Descripción detallada |

**Validaciones**:
- Nombre: No vacío, 3-100 caracteres
- Debe existir antes de asignar a médico

**Datos Iniciales**:
- Cardiología
- Dermatología
- Medicina General
- Odontología
- Oftalmología
- Otorrinolaringología
- Pediatría
- Traumatología

---

### 3. EPS (Empresa Promotora de Salud)
**Propósito**: Gestionar aseguradoras de los pacientes

| Campo | Tipo | Constraints | Descripción |
|-------|------|-----------|-------------|
| EPSId | INT | PK, AUTO_INCREMENT | Identificador único |
| Nombre | VARCHAR(100) | UNIQUE, NOT NULL | Nombre de EPS |
| Nit | VARCHAR(20) | UNIQUE, NOT NULL | NIT de la empresa |
| Telefono | VARCHAR(20) | NULL | Teléfono de contacto |
| Email | VARCHAR(100) | NULL | Email de contacto |
| Contacto | VARCHAR(100) | NULL | Persona de contacto |
| FechaRegistro | DATETIME | NOT NULL | Fecha de creación |
| Estado | ENUM('Activa','Inactiva') | NOT NULL | Estado |

**Validaciones**:
- Nombre: No vacío, 3-100 caracteres
- NIT: Formato válido
- Teléfono: Formato internacional (opcional)

**Datos Iniciales** (ejemplos):
- SURA
- Axa Colpatria
- Coomeva
- Sanitas
- Nuevavida

---

### 4. Medico
**Propósito**: Gestionar profesionales médicos

| Campo | Tipo | Constraints | Descripción |
|-------|------|-----------|-------------|
| MedicoId | INT | PK, AUTO_INCREMENT | Identificador único |
| Nombres | VARCHAR(100) | NOT NULL | Nombres del médico |
| Apellidos | VARCHAR(100) | NOT NULL | Apellidos del médico |
| Email | VARCHAR(100) | UNIQUE, NOT NULL | Correo electrónico |
| Telefono | VARCHAR(20) | NOT NULL | Teléfono de contacto |
| Licencia | VARCHAR(50) | UNIQUE, NOT NULL | Número de licencia médica |
| EspecialidadId | INT | FK NOT NULL | FK a Especialidad |
| HorarioInicio | TIME | NOT NULL | Hora de inicio (ej: 08:00) |
| HorarioFin | TIME | NOT NULL | Hora de fin (ej: 17:00) |
| DiasAtencion | VARCHAR(50) | NOT NULL | Días de atención (ej: Lunes-Viernes) |
| FechaRegistro | DATETIME | NOT NULL | Fecha de creación |
| Estado | ENUM('Activo','Inactivo','Licencia') | NOT NULL | Estado |

**Validaciones**:
- Nombres/Apellidos: No vacíos, 2-100 caracteres
- Email: Formato válido, único
- Telefono: Formato válido (ej: +57 followed by digits)
- Licencia: Único
- HorarioInicio < HorarioFin
- Especialidad debe existir

**Índices**:
```sql
CREATE UNIQUE INDEX idx_licencia ON Medico(Licencia);
CREATE INDEX idx_especialidad ON Medico(EspecialidadId);
CREATE INDEX idx_estado ON Medico(Estado);
```

---

### 5. Paciente
**Propósito**: Gestionar información de pacientes

| Campo | Tipo | Constraints | Descripción |
|-------|------|-----------|-------------|
| PacienteId | INT | PK, AUTO_INCREMENT | Identificador único |
| Nombres | VARCHAR(100) | NOT NULL | Nombres del paciente |
| Apellidos | VARCHAR(100) | NOT NULL | Apellidos del paciente |
| Email | VARCHAR(100) | NULL | Correo electrónico |
| Telefono | VARCHAR(20) | NOT NULL | Teléfono de contacto |
| FechaNacimiento | DATE | NOT NULL | Fecha de nacimiento |
| Genero | ENUM('M','F','Otro') | NOT NULL | Género |
| Documento | VARCHAR(20) | UNIQUE, NOT NULL | Cédula/Documento |
| EPSId | INT | FK NOT NULL | FK a EPS |
| Direccion | VARCHAR(200) | NOT NULL | Dirección |
| Ciudad | VARCHAR(100) | NOT NULL | Ciudad |
| FechaRegistro | DATETIME | NOT NULL | Fecha de registro |
| Estado | ENUM('Activo','Inactivo','Suspendido') | NOT NULL | Estado |

**Validaciones**:
- Nombres/Apellidos: No vacíos, 2-100 caracteres
- Email: Formato válido (opcional)
- Telefono: Formato válido, no vacío
- FechaNacimiento: Mayor a 0 años, menor a 150 años
- Genero: Requerido
- Documento: Único, formato válido
- EPS: Debe existir
- Dirección/Ciudad: No vacío

**Índices**:
```sql
CREATE UNIQUE INDEX idx_documento ON Paciente(Documento);
CREATE INDEX idx_eps ON Paciente(EPSId);
CREATE INDEX idx_genero ON Paciente(Genero);
CREATE INDEX idx_fecha_registro ON Paciente(FechaRegistro);
CREATE INDEX idx_estado ON Paciente(Estado);
```

**Cálculo Dinámico**:
- Edad = YEAR(NOW()) - YEAR(FechaNacimiento)

---

### 6. Cita
**Propósito**: Gestionar citas médicas

| Campo | Tipo | Constraints | Descripción |
|-------|------|-----------|-------------|
| CitaId | INT | PK, AUTO_INCREMENT | Identificador único |
| PacienteId | INT | FK NOT NULL | FK a Paciente |
| MedicoId | INT | FK NOT NULL | FK a Medico |
| Fecha | DATE | NOT NULL | Fecha de la cita |
| Hora | TIME | NOT NULL | Hora de la cita |
| Motivo | VARCHAR(500) | NOT NULL | Motivo de la consulta |
| Estado | ENUM('Pendiente','Confirmada','Cancelada','Realizada') | NOT NULL | Estado de cita |
| Notas | TEXT | NULL | Notas del médico (post-cita) |
| FechaCreacion | DATETIME | NOT NULL | Fecha de creación |
| FechaActualizacion | DATETIME | NOT NULL | Última actualización |

**Validaciones**:
- PacienteId y MedicoId: Deben existir
- Fecha: Mayor o igual a hoy, máximo 6 meses adelante
- Hora: Dentro del horario del médico
- Motivo: No vacío, 5-500 caracteres
- Estado: Requerido, solo valores permitidos
- No permitir citas duplicadas (mismo paciente, médico, fecha, hora)

**Restricción de Negocio**:
- No se puede agendar más de una cita en la misma hora para un médico
- Cambiar estado a "Realizada" solo si Fecha <= HOY
- Solo se puede cancelar si Estado es "Pendiente"

**Índices**:
```sql
CREATE INDEX idx_paciente ON Cita(PacienteId);
CREATE INDEX idx_medico ON Cita(MedicoId);
CREATE INDEX idx_fecha ON Cita(Fecha);
CREATE INDEX idx_estado ON Cita(Estado);
CREATE INDEX idx_paciente_fecha ON Cita(PacienteId, Fecha);
CREATE UNIQUE INDEX idx_no_duplicadas ON Cita(MedicoId, Fecha, Hora);
```

---

## Estados y Transiciones

### Estado de Paciente
```
Activo ←→ Inactivo
   ↓
Suspendido → Activo
```

### Estado de Medico
```
Activo ← → Inactivo
  ↓
Licencia → Activo
```

### Estado de Cita
```
Pendiente → Confirmada → Realizada
   ↓
   └──→ Cancelada (from any state before Realizada)
```

### Estado de Usuario
```
Activo → Inactivo → Activo
  ↓
Bloqueado → Activo (admin manual)
```

---

## Diccionario de Datos Resumido

| Tabla | Registros Esperados | Notas |
|-------|-------------------|-------|
| Usuario | 5-10 | Personal administrativo |
| Especialidad | 8-15 | Datos de referencia |
| EPS | 10-30 | Datos de referencia |
| Medico | 10-50 | Puede variar según clínica |
| Paciente | 100-1000+ | Crece constantemente |
| Cita | 50-500+ | Histórico completo |

---

## Convenciones de Base de Datos

### Naming
- Tablas: PascalCase (Usuario, Paciente, Cita)
- Columnas: PascalCase (UserId, FechaCreacion)
- FK: Tabla + "Id" (PacienteId, MedicoId)
- Índices: idx_nombrecolumna

### Data Types
- IDs: INT AUTO_INCREMENT (11 dígitos máximo)
- Textos cortos: VARCHAR(n) con límite apropiado
- Textos largos: TEXT
- Fecha: DATE (sin hora)
- Fecha+Hora: DATETIME
- Hora: TIME
- Verdadero/Falso: ENUM o BOOLEAN
- Binarios: LONGBLOB

### Charsets
```sql
DEFAULT CHARSET utf8mb4 COLLATE utf8mb4_unicode_ci
```

---

## Próximos Pasos

1. ✓ Data Model completado
2. → Generar scripts SQL (01-05)
3. → Crear contratos API
4. → Implementar DbContext y Models en C#

