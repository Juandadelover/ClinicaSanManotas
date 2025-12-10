# RESEARCH-FASE2.md - Nuevas Investigaciones Fase 2

**Generado**: 2025-12-06  
**Estado**: Phase 0 - Investigación Completada

---

## MAIL-002: Recuperación de Contraseña por Email

### Decision
**SMTP con Tokens en BD + Expiración de 1 hora**

### Rationale
- SMTP es estándar industrial para envío de emails
- Tokens con expiración previenen ataques de fuerza bruta
- Guardar tokens en BD permite auditoría y revocación
- Tabla separada facilita limpieza de expirados

### Implementación
```csharp
// 1. Crear tabla PasswordResetTokens en BD
CREATE TABLE PasswordResetTokens (
    TokenId INT PRIMARY KEY AUTO_INCREMENT,
    UsuarioId INT NOT NULL,
    Token VARCHAR(100) UNIQUE NOT NULL,
    ExpiresAt DATETIME NOT NULL,
    IsUsed BIT DEFAULT 0,
    CreatedAt DATETIME DEFAULT NOW(),
    FOREIGN KEY (UsuarioId) REFERENCES Usuario(UsuarioId)
);

// 2. Generar token seguro (crypto random)
public string GenerarToken()
    => Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));

// 3. Enviar email con SMTP
var client = new SmtpClient("smtp.gmail.com", 587)
{
    Credentials = new NetworkCredential("clinica@gmail.com", "app-password"),
    EnableSsl = true
};

// 4. Crear MailMessage
var mail = new MailMessage("clinica@gmail.com", usuario.Email)
{
    Subject = "Recuperar Contraseña - Clínica San Manotas",
    Body = $"Link: https://tuapp.com/reset?token={token}",
    IsBodyHtml = true
};

client.Send(mail);
```

---

## FILTER-001: Filtros Avanzados en DataGridView

### Decision
**LINQ en Repositories + Panel de Filtros en cada Formulario**

### Rationale
- LINQ es type-safe y evita SQL injection
- Reutilizable sin recompilación
- Performance aceptable para CRUD (< 10K registros)
- Fácil de testear

### Métodos Base a Implementar

#### PacienteRepository
```csharp
public List<Paciente> BuscarPorGenero(string genero)
    => GetAll().Where(p => p.Genero == genero).ToList();

public List<Paciente> BuscarPorEdad(int edad)
    => GetAll().Where(p => 
        DateTime.Now.Year - p.FechaNacimiento.Year == edad).ToList();

public List<Paciente> BuscarPorEPS(int epsId)
    => GetAll().Where(p => p.EPSId == epsId).ToList();

public List<Paciente> BuscarPorFechaRegistro(DateTime fecha)
    => GetAll().Where(p => 
        p.FechaCreacion.Date == fecha.Date).ToList();

public List<Paciente> BuscarConCitaEnFecha(DateTime fecha)
    => GetAll().Where(p => p.Citas.Any(c => 
        c.Fecha.Date == fecha.Date)).ToList();
```

#### CitaRepository
```csharp
public List<Cita> BuscarPorEstado(string estado)
    => GetAll().Where(c => c.Estado == estado).ToList();

public List<Cita> BuscarEnRangoFechas(DateTime inicio, DateTime fin)
    => GetAll().Where(c => 
        c.Fecha >= inicio && c.Fecha <= fin).ToList();

public List<Cita> BuscarPorPaciente(int pacienteId)
    => GetAll().Where(c => c.PacienteId == pacienteId).ToList();

public List<Cita> BuscarPorMedico(int medicoId)
    => GetAll().Where(c => c.MedicoId == medicoId).ToList();
```

#### MedicoRepository
```csharp
public List<Medico> BuscarPorEspecialidad(int especialidadId)
    => GetAll().Where(m => m.EspecialidadId == especialidadId).ToList();

public List<Medico> BuscarPorNombre(string nombre)
    => GetAll().Where(m => 
        m.Nombres.Contains(nombre) || m.Apellidos.Contains(nombre))
        .ToList();
```

---

## PHOTO-001: Sistema de Fotos de Usuario

### Decision
**BLOB en BD + Almacenamiento en carpeta local para backup**

### Rationale
- BLOB centraliza datos con usuario
- Backup en carpeta permite recuperación rápida
- Compatible con System.Drawing.Image
- Respaldado automáticamente con BD

### Modificación Modelo
```csharp
public class Usuario
{
    public int UsuarioId { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public string Rol { get; set; }
    public string Estado { get; set; }
    public DateTime FechaCreacion { get; set; }
    public DateTime? UltimoLogin { get; set; }
    
    // 🆕 Foto del usuario
    public byte[] Foto { get; set; }  // BLOB
}
```

### Implementación
```csharp
// Cargar desde archivo
public void CargarFoto(string rutaArchivo)
{
    byte[] fotoBytes = File.ReadAllBytes(rutaArchivo);
    usuario.Foto = fotoBytes;
    
    // Guardar backup
    Directory.CreateDirectory("~/Data/Fotos");
    File.Copy(rutaArchivo, $"~/Data/Fotos/{usuario.UsuarioId}.jpg", true);
}

// Mostrar en PictureBox
public Image ObtenerFoto(Usuario usuario)
{
    if (usuario?.Foto == null) 
        return Properties.Resources.DefaultUserPhoto;
    
    using var ms = new MemoryStream(usuario.Foto);
    return Image.FromStream(ms);
}

// Eliminar foto
public void EliminarFoto(Usuario usuario)
{
    usuario.Foto = null;
    File.Delete($"~/Data/Fotos/{usuario.UsuarioId}.jpg");
}
```

---

## I18N-001: Sistema de Idiomas (Español/Inglés)

### Decision
**JSON + LocalizationManager (Singleton) + Event System**

### Rationale
- JSON es portable y no requiere recompilación
- LocalizationManager centraliza la gestión (Singleton)
- Event system permite actualización en tiempo real
- Más flexible que .resx para dinámico

### Estructura Carpeta
```
Resources/
├── translations/
│   ├── es.json
│   └── en.json
└── LocalizationManager.cs
```

### es.json
```json
{
  "app.title": "CLÍNICA SAN MANOTAS",
  "login.title": "Iniciar Sesión",
  "login.username": "Usuario",
  "login.password": "Contraseña",
  "login.button": "Entrar",
  "login.error": "Usuario o contraseña incorrectos",
  "menu.pacientes": "Pacientes",
  "menu.medicos": "Médicos",
  "menu.citas": "Citas",
  "menu.usuarios": "Usuarios",
  "menu.especialidades": "Especialidades",
  "menu.reportes": "Reportes",
  "button.agregar": "Agregar",
  "button.actualizar": "Actualizar",
  "button.eliminar": "Eliminar",
  "button.buscar": "Buscar",
  "validation.required": "Campo obligatorio",
  "validation.email": "Email inválido",
  "validation.phone": "Teléfono inválido"
}
```

### en.json
```json
{
  "app.title": "CLINIC SAN MANOTAS",
  "login.title": "Login",
  "login.username": "Username",
  "login.password": "Password",
  "login.button": "Enter",
  "login.error": "Invalid username or password",
  "menu.pacientes": "Patients",
  "menu.medicos": "Doctors",
  "menu.citas": "Appointments",
  "menu.usuarios": "Users",
  "menu.especialidades": "Specialties",
  "menu.reportes": "Reports",
  "button.agregar": "Add",
  "button.actualizar": "Update",
  "button.eliminar": "Delete",
  "button.buscar": "Search",
  "validation.required": "Required field",
  "validation.email": "Invalid email",
  "validation.phone": "Invalid phone"
}
```

### LocalizationManager.cs
```csharp
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace SistemaEmpleadosMySQL.Helpers
{
    public class LocalizationManager
    {
        private static LocalizationManager _instance;
        private Dictionary<string, Dictionary<string, string>> _translations;
        private string _currentLanguage = "es";
        
        public static LocalizationManager Instance 
            => _instance ??= new LocalizationManager();
        
        public event Action OnLanguageChanged;
        
        private LocalizationManager()
        {
            LoadTranslations();
        }
        
        private void LoadTranslations()
        {
            _translations = new Dictionary<string, Dictionary<string, string>>();
            
            foreach (var lang in new[] { "es", "en" })
            {
                var json = File.ReadAllText($"Resources/translations/{lang}.json");
                _translations[lang] = JsonSerializer.Deserialize<Dictionary<string, string>>(json);
            }
        }
        
        public string GetString(string key)
        {
            if (_translations[_currentLanguage].TryGetValue(key, out var value))
                return value;
            return key;
        }
        
        public void SetLanguage(string language)
        {
            if (_translations.ContainsKey(language))
            {
                _currentLanguage = language;
                OnLanguageChanged?.Invoke();
            }
        }
    }
}
```

---

## EPS-001: Gestión de Entidad EPS

### Decision
**Patrón CRUD idéntico a PacientesForm/MedicosForm**

### Rationale
- Consistencia arquitectónica
- Validación de integridad referencial
- Logging y auditoría integrada

### Estructura Tabla (SQL)
```sql
CREATE TABLE EPS (
    EPSId INT PRIMARY KEY AUTO_INCREMENT,
    Nombre VARCHAR(100) NOT NULL UNIQUE,
    Codigo VARCHAR(10) NOT NULL UNIQUE,
    Contacto VARCHAR(20),
    Email VARCHAR(100),
    DireccionOficina VARCHAR(255),
    Estado VARCHAR(20) DEFAULT 'Activo',
    FechaCreacion DATETIME DEFAULT NOW(),
    INDEX idx_nombre (Nombre),
    INDEX idx_codigo (Codigo)
);
```

### Modelo EPS
```csharp
public class EPS
{
    public int EPSId { get; set; }
    public string Nombre { get; set; }
    public string Codigo { get; set; }
    public string Contacto { get; set; }
    public string Email { get; set; }
    public string DireccionOficina { get; set; }
    public string Estado { get; set; } = "Activo";
    public DateTime FechaCreacion { get; set; } = DateTime.Now;
    
    // Relación
    public ICollection<Paciente> Pacientes { get; set; }
}
```

---

## ✅ RESUMEN DE DECISIONES ARQUITECTÓNICAS

### Layer Datos
- **ORM**: Entity Framework Core 8 ✅
- **Patrón**: Repository + UnitOfWork ✅
- **Filtros**: LINQ en Repositories ✅
- **Caché**: SessionManager in-memory ✅

### Layer Aplicación
- **Framework**: Windows Forms .NET 8 ✅
- **Idiomas**: JSON + LocalizationManager ✅
- **Validación**: ValidationHelper centralizado ✅
- **Logging**: LogHelper (file-based) ✅

### Layer Seguridad
- **Hash**: SHA256 + Base64 ✅
- **Recovery**: SMTP + Tokens en BD 🆕
- **Fotos**: BLOB + File Backup 🆕
- **Roles**: Admin, Recepcionista, Doctor ✅

### Layer Reportes
- **Tipos**: 6 reportes (General, Pacientes, Médicos, Citas, Especialidades, Usuarios) ✅
- **Exportación**: TXT + CSV ✅

---

## 📋 CHECKLIST ANTES DE IMPLEMENTAR

- [ ] Crear tabla PasswordResetTokens en BD
- [ ] Crear carpeta Resources/translations/
- [ ] Agregar es.json y en.json
- [ ] Crear clase LocalizationManager
- [ ] Crear clase EmailHelper con SMTP
- [ ] Crear EPSRepository
- [ ] Agregar métodos filtros en todas Repositories
- [ ] Agregar byte[] Foto en Usuario model
- [ ] Crear table EPS si no existe
- [ ] Documentar API contracts

---

## 🚀 PRÓXIMA FASE

**Phase 1: Implementación** - Orden recomendado:
1. EPSForm (CRUD - 220 líneas)
2. Filtros en Repositories (200 líneas)
3. Filtros en Forms (300 líneas)
4. LocalizationManager + Traducciones (500 líneas)
5. Recuperación de Contraseña (250 líneas)
6. Sistema de Fotos (180 líneas)

**Estimado Total**: ~1,650 líneas nuevas

