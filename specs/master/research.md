# Research & Clarifications - CLINICA SAN MANOTAS

**Generado**: 2025-12-05 | **Status**: ✓ COMPLETADO

---

## ARCH-001: Mejores Prácticas Entity Framework Core en Windows Forms

### Decision
Usar **Entity Framework Core 8 con patrón Repository + UnitOfWork** y **DbContext por sesión** para evitar problemas de conexión.

### Rationale
- EF Core es el ORM moderno de .NET, diseñado específicamente para .NET 8
- Patrón Repository abstrae la capa de datos
- UnitOfWork garantiza transacciones atómicas
- Conexión por sesión previene deadlocks y problemas de estado
- Entity Framework Core incluye lazy loading, eager loading para relaciones

### Alternatives Considered
- Dapper: Más manual, menos abstracción (rechazado por complejidad)
- Raw ADO.NET: No portátil, muy verboso (rechazado)
- Stored Procedures: Limitantes, difíciles de testear (rechazado)

### Implementation Pattern
```csharp
// IRepository<T> interface
// Repository<T> : IRepository<T> implementation
// IUnitOfWork para transacciones
// DbContext con lazy loading deshabilitado por defecto
```

---

## ARCH-002: Estrategia de Localización (i18n) en WinForms

### Decision
**Archivos .resx separados** (es.resx, en.resx) + **CultureInfo** + **custom ResourceManager**

### Rationale
- .resx es el estándar de Microsoft para WinForms
- Cambio dinámico de idioma sin reiniciar aplicación
- Compatible con designer de Visual Studio
- Fácil mantenimiento de traducciones

### Implementation Pattern
```csharp
// 1. Crear es.resx y en.resx en carpeta Resources
// 2. Crear LocalizationService que cambia CultureInfo
// 3. Subscribirse a eventos de cambio de idioma
// 4. Usar Properties.Resources.MyCadena en lugar de strings hardcoded
// 5. UI formula tiene propiedad Language para aplicar recursos dinámicamente
```

---

## SEC-001: Algoritmo Seguro para Hash de Contraseñas

### Decision
**Argon2id** (con librería Konscious.Hashing.Argon2) o **bcrypt** (BCrypt.Net-Next)

### Rationale
- Argon2id es ganador de Password Hashing Competition (PHC) 2015
- bcrypt es proven, ampliamente usado, no requiere NuGet adicional en algunos contextos
- Ambos incluyen salt automático
- Resistencia a ataques GPU/ASIC
- Parámetro de costo ajustable

### Recommendation
**Usar bcrypt** por compatibilidad y disponibilidad en NuGet (BCrypt.Net-Next)
```csharp
// Hashing: BCrypt.Net.BCrypt.HashPassword(password)
// Verificación: BCrypt.Net.BCrypt.Verify(password, hash)
```

---

## DB-001: Versionamiento de Scripts SQL

### Decision
**Versionamiento por carpeta con numeración** + **tabla de migrations en BD**

### Rationale
- Fácil seguimiento de cambios
- Control de versión manual para máximo control
- Tabla `migrations` en BD para registrar qué scripts fueron ejecutados

### Structure
```
database/
├── scripts/
│   ├── 01-create-database.sql
│   ├── 02-create-tables.sql
│   ├── 03-create-indexes.sql
│   ├── 04-insert-initial-data.sql
│   ├── 05-add-audit-columns.sql (cambios posteriores)
│   └── VERSION.md (registro de versiones)
└── migrations/ (para EF Migrations)
    └── .gitkeep
```

---

## MAIL-001: Servicio de Correo para Recuperación de Contraseña

### Decision
**Usar SMTP genérico** + **SendGrid o Gmail** como opción de desarrollo

### Rationale
- SMTP es estándar y funciona con casi todo
- SendGrid tiene plan free limitado
- Gmail disponible para testing

### Implementation Pattern
```csharp
// IEmailService interface
// EmailService : IEmailService (usa SmtpClient)
// Configuración en appsettings.json (NUNCA hardcoded)
// Usar plantillas de correo (HTML templates)
// Token temporal con expiración para reset de contraseña
```

---

## PATTERN-001: Patrón Repository + UnitOfWork

### Decision
**Repository Pattern + Unit of Work** para abstracción de datos

### Rationale
- Desacopla lógica de negocio de detalles de BD
- Facilita testing (mock repositories)
- Transacciones atómicas con UnitOfWork
- Fácil migración entre BD

### Interfaces Base
```csharp
IRepository<T> where T : class
{
    Task<T> GetByIdAsync(int id);
    Task<IEnumerable<T>> GetAllAsync();
    Task AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
    Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
}

IUnitOfWork
{
    IRepository<Patient> Patients { get; }
    IRepository<Doctor> Doctors { get; }
    IRepository<Appointment> Appointments { get; }
    Task<bool> SaveAsync();
    Task<bool> BeginTransactionAsync();
    Task<bool> CommitAsync();
    Task<bool> RollbackAsync();
}
```

---

## Additional Clarifications

### Autenticación
- **Role-based**: Admin, Recepcionista, Doctor (si aplica)
- **Sesión**: Tipo User + última actividad
- **Timeout**: 30 minutos de inactividad

### Validaciones de Datos
- Teléfono: Formato internacional (Colombia: +57)
- Email: Validación regex + verificación de formato
- Edad: Mayor a 0, menor a 150
- Fechas de cita: Mayor a hoy + máximo 6 meses adelante

### Performance
- Caché de Especialidades y EPS en memoria (son datos de referencia)
- Índices en: patientId, doctorId, appointmentDate, appointmentStatus
- Paginación por defecto: 10-20 registros

### Logging
- Usar **Serilog** (más moderno que NLog)
- Logs a archivo + consola en desarrollo
- Structured logging para auditoría

### Exportación
- Reportes básicos: PDF de citas, listado de pacientes
- Usar iTextSharp o QuestPDF para generación

---

## Decisiones Confirmadas

| Aspecto | Decisión |
|--------|----------|
| ORM | Entity Framework Core 8 |
| Patrón Datos | Repository + UnitOfWork |
| Hash Contraseñas | BCrypt.Net-Next |
| Localización | .resx + CultureInfo |
| Correo | SMTP + appsettings.json |
| Logging | Serilog |
| Versionamiento BD | Numeración manual + tabla migrations |
| Autenticación | Usuario/Contraseña + Roles |
| Sesión | Timeout 30 minutos |
| Caché | Especialidades y EPS en memoria |
| Reportes | QuestPDF para PDF |

---

## Próximos Pasos

1. ✓ Phase 0 Research completada
2. → **Phase 1: Iniciar con data-model.md**
3. → Generar contratos API
4. → Scripts SQL de base de datos
5. → Quickstart.md

