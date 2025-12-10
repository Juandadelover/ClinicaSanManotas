# CLINICA SAN MANOTAS - Plan de Implementación de Funcionalidades Faltantes

**Rama**: master | **Fecha**: 2025-12-06  
**Estado Actual**: 7 de 10 formularios completados (70%)

---

## 📊 ANÁLISIS DE COMPLETITUD

### ✅ IMPLEMENTADO (100%)
- ✅ PacientesForm - CRUD completo (326 líneas)
- ✅ MedicosForm - CRUD completo (240+ líneas)
- ✅ CitasForm - CRUD completo (260+ líneas)
- ✅ UsuariosForm - CRUD completo (270+ líneas)
- ✅ EspecialidadesForm - CRUD completo (215+ líneas)
- ✅ ReportesForm - 6 tipos de reportes (400+ líneas)
- ✅ LoginForm - Autenticación (207 líneas)
- ✅ MainForm, RecepcionForm, DoctorForm - Dashboards

### ❌ FALTANTE (30%)

| Componente | Prioridad | Líneas Est. | Complejidad |
|-----------|-----------|----------|-------------|
| **EPSForm** | 🔴 CRÍTICA | 220+ | Baja |
| **Filtros Avanzados** | 🔴 CRÍTICA | 300+ | Media |
| **Sistema de Idiomas** | 🔴 CRÍTICA | 500+ | Alta |
| **Recuperación de Contraseña** | 🟡 MEDIA | 250+ | Media |
| **Sistema de Foto de Usuario** | 🟡 MEDIA | 180+ | Baja |

---

## 🔴 FASE 1: CRÍTICA - EPZFORM CRUD

### Requerimiento
```
- Gestionar EPS (Aseguradoras)
- Crear, actualizar, eliminar EPS
- Asignar múltiples pacientes a una EPS
- Validar integridad referencial
```

### Estructura
```csharp
public class EPS
{
    public int EPSId { get; set; }
    public string? Nombre { get; set; }          // Ej: "SURA", "Salud Total"
    public string? Codigo { get; set; }          // Ej: "001"
    public string? Contacto { get; set; }        // Teléfono
    public string? Email { get; set; }           // Correo
    public string? DireccionOficina { get; set; }
    public string? Estado { get; set; }          // "Activo" / "Inactivo"
    public DateTime FechaCreacion { get; set; }
}
```

### Archivo
`SistemaEmpleadosMySQL/UI/Forms/EPSForm.cs` - ~220 líneas

---

## 🔴 FASE 2: CRÍTICA - FILTROS AVANZADOS

### Requerimientos Faltantes (del contexto)
```
[ ] Buscar pacientes por GÉNERO
[ ] Buscar pacientes por EDAD
[ ] Buscar pacientes por EPS
[ ] Mostrar pacientes CON FECHA DE CITA determinada
[ ] Mostrar CITAS POR ESTADO (con datos de pacientes)
[ ] Filtrar pacientes registrados en FECHA determinada
```

### Implementación
- Agregar panel de filtros en **PacientesForm**
- Agregar panel de filtros en **CitasForm**
- Agregar panel de filtros en **MedicosForm**
- Métodos de búsqueda en Repositories

### Archivos a Modificar
```
SistemaEmpleadosMySQL/UI/Forms/PacientesForm.cs
SistemaEmpleadosMySQL/UI/Forms/MedicosForm.cs
SistemaEmpleadosMySQL/UI/Forms/CitasForm.cs
SistemaEmpleadosMySQL/Repositories/PacienteRepository.cs
SistemaEmpleadosMySQL/Repositories/CitaRepository.cs
SistemaEmpleadosMySQL/Repositories/MedicoRepository.cs
```

### Métodos a Agregar
```csharp
// PacienteRepository
public List<Paciente> BuscarPorGenero(string genero);
public List<Paciente> BuscarPorEdad(int edad);
public List<Paciente> BuscarPorEPS(int epsId);
public List<Paciente> BuscarPorFechaRegistro(DateTime fecha);
public List<Paciente> BuscarConCitaEnFecha(DateTime fecha);

// CitaRepository
public List<Cita> BuscarPorEstado(string estado);
public List<Cita> BuscarPacientesConCitaEnFecha(DateTime fecha);

// MedicoRepository
public List<Medico> BuscarPorEspecialidad(int especialidadId);
public List<Medico> BuscarPorNombre(string nombre);
```

---

## 🔴 FASE 3: CRÍTICA - SISTEMA DE IDIOMAS (Español/Inglés)

### Estrategia
1. **Crear archivo de traducciones JSON**
   ```
   Resources/
   ├── es.json  (Español)
   └── en.json  (Inglés)
   ```

2. **Crear LocalizationManager (Singleton)**
   ```csharp
   public class LocalizationManager
   {
       private static LocalizationManager _instance;
       private string _currentLanguage = "es";
       private Dictionary<string, Dictionary<string, string>> _translations;
       
       public string GetString(string key) { }
       public void SetLanguage(string language) { }
   }
   ```

3. **Agregar cambio de idioma en MainForm**
   - Menú desplegable: "Español" / "English"
   - Cambio en tiempo real sin reiniciar
   - Guardar preferencia en BD

4. **Traducir todos los formularios**
   - Labels, Buttons, Messages
   - Validaciones
   - Errores

### Alcance de Traducción
```
~150 strings para traducir:
- 50 Labels en formularios
- 40 Botones
- 30 Mensajes de validación
- 20 Títulos de formularios
- 10 Errores de sistema
```

---

## 🟡 FASE 4: MEDIA - RECUPERACIÓN DE CONTRASEÑA

### Requisitos
```
[ ] Formulario "Olvidé contraseña"
[ ] Validar email registrado
[ ] Generar token único
[ ] Enviar correo con link
[ ] Validar token
[ ] Permitir reset de contraseña
```

### Archivos Necesarios
```
SistemaEmpleadosMySQL/UI/Forms/ForgotPasswordForm.cs
SistemaEmpleadosMySQL/UI/Forms/ResetPasswordForm.cs
SistemaEmpleadosMySQL/Helpers/EmailHelper.cs
SistemaEmpleadosMySQL/Repositories/PasswordResetTokenRepository.cs
```

### Tabla necesaria
```sql
CREATE TABLE PasswordResetTokens (
    TokenId INT PRIMARY KEY AUTO_INCREMENT,
    UsuarioId INT NOT NULL,
    Token VARCHAR(100) UNIQUE NOT NULL,
    ExpiresAt DATETIME NOT NULL,
    IsUsed BIT DEFAULT 0,
    CreatedAt DATETIME DEFAULT NOW(),
    FOREIGN KEY (UsuarioId) REFERENCES Usuario(UsuarioId)
);
```

---

## 🟡 FASE 5: MEDIA - SISTEMA DE FOTOS

### Requerimiento
```
Los usuarios deben tener foto (ID photo)
```

### Implementación
```
SistemaEmpleadosMySQL/UI/Forms/UsuariosForm.cs
- Agregar PictureBox para foto
- Botón "Seleccionar Foto"
- Almacenar como BLOB en BD
```

### Modificación a Modelo
```csharp
public class Usuario
{
    ...
    public byte[]? Foto { get; set; }  // BLOB en BD
}
```

---

## 📋 ORDEN DE IMPLEMENTACIÓN RECOMENDADO

### Semana 1 (Lunes-Miércoles)
1. ✅ **Día 1**: EPSForm CRUD + Tests
2. ✅ **Día 2**: Filtros Avanzados (Pacientes + Citas)
3. ✅ **Día 3**: Filtros Avanzados (Médicos)

### Semana 1 (Jueves-Viernes)
4. ✅ **Día 4-5**: Sistema de Idiomas (LocalizationManager + Traducciones)

### Semana 2
5. ⏳ **Día 6-7**: Recuperación de Contraseña
6. ⏳ **Día 8-9**: Sistema de Fotos
7. ⏳ **Día 10**: Testing + Documentación Final

---

## 🚀 COMANDOS PARA COMPILAR Y PROBAR

```powershell
# Compilar proyecto
dotnet build

# Ejecutar aplicación
dotnet run

# Test de login (después de actualizar hashes)
Username: admin
Password: admin123
```

---

## 📝 TAREAS TÉCNICAS PENDIENTES

### Antes de Implementar Filtros
- [ ] Agregar métodos GetAll() a todos los Repositories
- [ ] Verificar joins en CitaRepository
- [ ] Actualizar UnitOfWork con nuevos métodos

### Antes de Implementar Idiomas
- [ ] Crear estructura de carpetas Resources/
- [ ] Crear archivos es.json y en.json
- [ ] Implementar LocalizationManager
- [ ] Actualizar Program.cs

### Antes de Implementar Recuperación de Contraseña
- [ ] Configurar servicio SMTP (Gmail/Office365)
- [ ] Crear EmailHelper con validación
- [ ] Crear tabla PasswordResetTokens en BD
- [ ] Generar tokens seguros

---

## ✨ CHECKLIST FINAL

- [x] Revisar contex.md
- [x] Identificar funcionalidades faltantes
- [x] Planificar orden de implementación
- [ ] Implementar EPSForm
- [ ] Implementar Filtros
- [ ] Implementar Sistema de Idiomas
- [ ] Implementar Recuperación de Contraseña
- [ ] Compilar y testear todo
- [ ] Documentación final
