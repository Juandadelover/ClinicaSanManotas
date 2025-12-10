# DATA-MODEL.md - Modelo de Datos y Entidades

**Generado**: 2025-12-06  
**Estado**: Phase 1 - Diseño Completado

---

## 📊 DIAGRAMA RELACIONAL

```
┌─────────────┐
│   Usuario   │ (Administración del sistema)
├─────────────┤
│ UsuarioId   │◄──┐
│ Username    │   │
│ Email       │   │
│ PasswordHash│   │
│ Rol         │   │ 1:N
│ Foto (BLOB) │   │
│ Estado      │   │
└─────────────┘   │
                  │
        ┌─────────┴──────────┐
        │                    │
   ┌────────────┐      ┌────────────┐
   │  Paciente  │      │   Medico   │
   ├────────────┤      ├────────────┤
   │PacienteId  │      │ MedicoId   │
   │Nombres     │      │Nombres     │
   │Apellidos   │      │Apellidos   │
   │Email       │      │Email       │
   │Telefono    │      │Telefono    │
   │Genero      │      │Licencia    │
   │FechaNac    │      │Horario     │
   │Documento   │      │Especialidad│◄──┐
   │EPSId ──────┼──┐   │Estado      │   │ 1:N
   │Estado      │  │   │Foto(BLOB)  │   │
   └────────────┘  │   └────────────┘   │
        │          │                    │
        │          │   ┌────────────────┤
        │    ┌─────┴──►│ Especialidad   │
        │    │ 1:N     ├────────────────┤
        │    │         │Especialidad Id │
        │    │         │Nombre          │
        │ ┌──┴─────────┤Descripcion     │
        │ │ 1:N        │Estado          │
        │ │            └────────────────┘
        │ │
        │ │   ┌──────────────┐
        │ │   │  Cita        │
        │ │   ├──────────────┤
        │ │   │CitaId        │
        │ │   │PacienteId ───┼──┐
        │ │   │MedicoId ─────┼──┼──┐
        │ │   │Fecha         │  │  │
        │ │   │Hora          │  │  │
        │ │   │Motivo        │  │  │
        │ │   │Estado        │  │  │
        │ │   └──────────────┘  │  │
        │ │         ▲            │  │
        │ │         └────────────┘  │
        │ │              1:N        │
        │ │                         │
        │ └─────────────────────────┘
        │
    ┌───┴──────┐
    │ 1:N      │
    │          ▼
    │      ┌────────────┐
    │      │    EPS     │
    │      ├────────────┤
    │      │EPSId       │
    │      │Nombre      │
    │      │Codigo      │
    │      │Contacto    │
    │      │Email       │
    │      │Direccion   │
    │      │Estado      │
    │      └────────────┘
    │
    └──────────────────────────────────────
```

---

## 🔑 ENTIDADES PRINCIPALES

### 1. Usuario
**Propósito**: Gestión de cuentas de sistema y autenticación

```csharp
public class Usuario
{
    public int UsuarioId { get; set; }
    public string Username { get; set; }              // Único
    public string Email { get; set; }                 // Único
    public string PasswordHash { get; set; }          // SHA256 + Base64
    public string Rol { get; set; }                   // Admin/Recepcionista/Doctor
    public string Estado { get; set; } = "Activo";    // Activo/Inactivo
    public byte[] Foto { get; set; }                  // BLOB (opcional)
    public DateTime FechaCreacion { get; set; }
    public DateTime? UltimoLogin { get; set; }
    
    // Relaciones
    public ICollection<AuditLog> Accesos { get; set; }
}
```

**Validaciones**:
- Username: 3-50 caracteres, alfanuméricos + punto/guión
- Email: Formato RFC 5322
- PasswordHash: No vacío, min 8 caracteres (en forma texto antes de hash)
- Rol: Valores permitidos solo (Admin, Recepcionista, Doctor)

---

### 2. Paciente
**Propósito**: Registro de pacientes de la clínica

```csharp
public class Paciente
{
    public int PacienteId { get; set; }
    public string Nombres { get; set; }
    public string Apellidos { get; set; }
    public string Email { get; set; }
    public string Telefono { get; set; }
    public string Genero { get; set; }                // M/F/Otro
    public DateTime FechaNacimiento { get; set; }
    public string NumeroDocumento { get; set; }       // Cédula/Pasaporte
    public int EPSId { get; set; }                    // FK
    public string Estado { get; set; } = "Activo";
    public DateTime FechaCreacion { get; set; }
    
    // Relaciones
    public virtual EPS EPS { get; set; }
    public virtual ICollection<Cita> Citas { get; set; }
}
```

**Validaciones**:
- Nombres/Apellidos: No vacío, min 3 caracteres
- Email: Formato válido (ValidationHelper.EsEmailValido)
- Telefono: 10-15 dígitos (ValidationHelper.ValidarTelefono)
- FechaNacimiento: No mayor a hoy, min 16 años
- NumeroDocumento: Único, formato válido
- EPSId: Debe existir en tabla EPS

---

### 3. Médico
**Propósito**: Registro de médicos especializados

```csharp
public class Medico
{
    public int MedicoId { get; set; }
    public string Nombres { get; set; }
    public string Apellidos { get; set; }
    public string Email { get; set; }
    public string Telefono { get; set; }
    public string LicenciaNumber { get; set; }        // Licencia profesional
    public int EspecialidadId { get; set; }           // FK
    public string HorarioInicio { get; set; }         // Ej: "08:00"
    public string HorarioFin { get; set; }            // Ej: "17:00"
    public string DiasAtencion { get; set; }          // Ej: "L,M,X,J,V" (JSON array)
    public string Estado { get; set; } = "Activo";
    public byte[] Foto { get; set; }                  // BLOB (opcional)
    public DateTime FechaCreacion { get; set; }
    
    // Relaciones
    public virtual Especialidad Especialidad { get; set; }
    public virtual ICollection<Cita> Citas { get; set; }
}
```

**Validaciones**:
- Nombres/Apellidos: No vacío, min 3 caracteres
- Email: Formato válido
- LicenciaNumber: Único, formato válido
- EspecialidadId: Debe existir
- HorarioInicio/Fin: Formato HH:MM válido, Fin > Inicio
- DiasAtencion: JSON array de 1-7 días (L,M,X,J,V,S,D)

---

### 4. Cita
**Propósito**: Registro de citas médicas entre paciente-médico

```csharp
public class Cita
{
    public int CitaId { get; set; }
    public int PacienteId { get; set; }               // FK
    public int MedicoId { get; set; }                 // FK
    public DateTime Fecha { get; set; }               // Ej: 2025-12-15
    public TimeSpan Hora { get; set; }                // Ej: 14:30
    public string Motivo { get; set; }                // Ej: "Chequeo general"
    public string Estado { get; set; } = "Pendiente"; // Estados: ver abajo
    public DateTime FechaCreacion { get; set; }
    
    // Relaciones
    public virtual Paciente Paciente { get; set; }
    public virtual Medico Medico { get; set; }
}
```

**Estados Permitidos**:
- `Pendiente` - Creada, espera confirmación
- `Confirmada` - Confirmada por recepción/médico
- `Realizada` - Completada
- `Cancelada` - Cancelada

**Validaciones**:
- PacienteId: Debe existir
- MedicoId: Debe existir
- Fecha: >= hoy (no pueden ser citas en pasado)
- Hora: Dentro del horario del médico
- Hora: No solapada con otras citas del médico
- Motivo: No vacío, min 5 caracteres
- Estado: Valores permitidos solo

---

### 5. Especialidad
**Propósito**: Tipos de especialidades médicas

```csharp
public class Especialidad
{
    public int EspecialidadId { get; set; }
    public string Nombre { get; set; }                // Único, Ej: "Cardiología"
    public string Descripcion { get; set; }           // Descripción de la especialidad
    public string Estado { get; set; } = "Activo";
    
    // Relaciones
    public ICollection<Medico> Medicos { get; set; }
}
```

**Ejemplos**:
- Cardiología
- Dermatología
- Pediatría
- Psicología
- Odontología
- Neurología

**Validaciones**:
- Nombre: No vacío, min 3 caracteres, único
- Descripcion: No vacío

---

### 6. EPS (Entidad Prestadora de Salud)
**Propósito**: Gestión de aseguradoras/EPS

```csharp
public class EPS
{
    public int EPSId { get; set; }
    public string Nombre { get; set; }                // Único, Ej: "SURA", "Salud Total"
    public string Codigo { get; set; }                // Único, Ej: "001"
    public string Contacto { get; set; }              // Teléfono
    public string Email { get; set; }
    public string DireccionOficina { get; set; }
    public string Estado { get; set; } = "Activo";
    public DateTime FechaCreacion { get; set; }
    
    // Relaciones
    public ICollection<Paciente> Pacientes { get; set; }
}
```

**Ejemplos**:
- SURA
- Salud Total
- AXA Colmédica
- Sanitas
- Famisanar
- Duran Salud

**Validaciones**:
- Nombre: No vacío, único, min 3 caracteres
- Codigo: Único, formato válido

---

### 7. AuditLog
**Propósito**: Registro de cambios y accesos del sistema

```csharp
public class AuditLog
{
    public int AuditLogId { get; set; }
    public int UsuarioId { get; set; }                // FK (Usuario que hizo cambio)
    public string TipoAccion { get; set; }            // CREATE/READ/UPDATE/DELETE
    public string Tabla { get; set; }                 // Tabla afectada
    public int RegistroId { get; set; }               // ID del registro
    public string Descripcion { get; set; }           // Descripción del cambio
    public DateTime FechaAccion { get; set; }
    
    // Relaciones
    public virtual Usuario Usuario { get; set; }
}
```

---

## 🔄 RELACIONES Y CARDINALIDADES

| Relación | Tipo | Descripción |
|----------|------|-------------|
| Usuario ↔ Paciente | 0..* | Un admin gestiona muchos pacientes |
| Usuario ↔ AuditLog | 1..* | Cada log referencia el usuario |
| Paciente ↔ EPS | *..1 | Muchos pacientes en una EPS |
| Paciente ↔ Cita | 1..* | Un paciente tiene múltiples citas |
| Medico ↔ Cita | 1..* | Un médico tiene múltiples citas |
| Medico ↔ Especialidad | *..1 | Muchos médicos en una especialidad |

---

## 🔐 TRANSICIONES DE ESTADO

### Cita
```
┌─────────┐
│PENDIENTE│ ────► ┌──────────┐
└─────────┘       │CONFIRMADA│
                  └──────────┘
                       │
                       ├──► ┌────────┐
                       │    │REALIZADA│
                       │    └────────┘
                       │
                       └──► ┌─────────┐
                            │CANCELADA│
                            └─────────┘
```

### Usuario / Paciente / Medico / EPS
```
┌────────┐         ┌─────────┐
│ACTIVO  │ ◄──────►│INACTIVO │
└────────┘         └─────────┘
```

---

## 📋 RESTRICCIONES DE INTEGRIDAD

| Restricción | Tipo | Descripción |
|-------------|------|-------------|
| Username UNIQUE | PK | Debe ser único en sistema |
| Email UNIQUE | Unique | Email único por usuario |
| NumeroDocumento UNIQUE | Unique | Documento único por paciente |
| LicenciaNumber UNIQUE | Unique | Licencia única por médico |
| Nombre EPS UNIQUE | Unique | Nombre único por EPS |
| FK PacienteId | Foreign Key | Paciente debe existir |
| FK MedicoId | Foreign Key | Médico debe existir |
| FK EPSId | Foreign Key | EPS debe existir |
| FK EspecialidadId | Foreign Key | Especialidad debe existir |
| FK UsuarioId (Audit) | Foreign Key | Usuario debe existir |

---

## 🔍 ÍNDICES RECOMENDADOS

```sql
-- Performance crítica
CREATE INDEX idx_usuario_username ON Usuario(Username);
CREATE INDEX idx_paciente_eps ON Paciente(EPSId);
CREATE INDEX idx_medico_especialidad ON Medico(EspecialidadId);
CREATE INDEX idx_cita_paciente ON Cita(PacienteId);
CREATE INDEX idx_cita_medico ON Cita(MedicoId);
CREATE INDEX idx_cita_fecha ON Cita(Fecha);
CREATE INDEX idx_cita_estado ON Cita(Estado);
CREATE INDEX idx_auditlog_usuario ON AuditLog(UsuarioId);
CREATE INDEX idx_auditlog_fecha ON AuditLog(FechaAccion);
```

---

## 📊 VOLUMEN ESTIMADO

Para clínica mediana (test):
- Usuarios: 5-10
- Pacientes: 100-500
- Médicos: 10-50
- Especialidades: 5-15
- EPS: 10-20
- Citas: 500-2,000
- AuditLogs: 1,000-5,000

---

## ✅ CHECKLIST DE VALIDACIÓN

- [x] Todas las entidades tienen ID como PK
- [x] Relaciones claramente definidas
- [x] Estados y transiciones documentados
- [x] Restricciones de integridad especificadas
- [x] Índices para performance identificados
- [x] Campos BLOB (Foto) considerados
- [x] Campos JSON (DiasAtencion) considerados
- [x] Campos DateTime con valores por defecto
- [x] Campos nullable identificados (`?`)
