# 🎯 TAREAS PENDIENTES PRIORITARIAS - CLINICA SAN MANOTAS

**Generado**: 2025-12-06  
**Basado en**: contex.md + Especificación actual  
**Status**: 📋 LISTO PARA IMPLEMENTACIÓN

---

## 📊 RESUMEN

**Total Tareas Pendientes**: 25  
**Horas Estimadas**: 20-25 horas  
**Fases**: 5 (Filtros, i18n, Contraseña, Email, Fotos)  
**Líneas de Código**: ~1,350 líneas

---

## FASE 1: FILTROS AVANZADOS (CRÍTICA) ⏰ 4-5 horas

### Requisito del contex.md
```
"La solución contará con los siguientes filtros: 
- buscar doctores por una especialidad dada por el usuario
- buscar doctores por el nombre o apellido
- buscar pacientes por géneros
- buscar pacientes por una edad dada
- buscar pacientes por una EPS dada
- mostrar pacientes con una fecha de cita determinada
- mostrar citas por un determinado estado (con los datos de los pacientes)
- Filtrar pacientes registrados en una determinada fecha"
```

### Tareas

#### T201: Agregar UI de Filtros a CitasForm
**Prioridad**: 🔴 CRÍTICA  
**Esfuerzo**: 1.5 horas  
**Complejidad**: Media  
**Líneas**: 80-100

**Acciones**:
- [ ] Agregar Panel de filtros (arriba del DataGridView)
- [ ] Agregar ComboBox "Estado" (Todos, Pendiente, Confirmada, Realizada, Cancelada)
- [ ] Agregar DateTimePicker "Fecha Inicio" y "Fecha Fin"
- [ ] Agregar ComboBox "Paciente" (cargado desde BD)
- [ ] Agregar ComboBox "Médico" (cargado desde BD)
- [ ] Agregar Button "Filtrar" (azul)
- [ ] Agregar Button "Limpiar Filtros" (gris)
- [ ] Conectar eventos Click a métodos de filtrado existentes
- [ ] Testear cada combinación de filtros

**Métodos Existentes a Conectar**:
- `FiltrarPorEstado(string estado)` ✅
- `FiltrarPorFechas(DateTime inicio, DateTime fin)` ✅
- `FiltrarPorPaciente(int pacienteId)` ✅
- `FiltrarPorMedico(int medicoId)` ✅

---

#### T202: Agregar UI de Filtros a PacientesForm
**Prioridad**: 🔴 CRÍTICA  
**Esfuerzo**: 1.5 horas  
**Complejidad**: Media  
**Líneas**: 120-140

**Acciones**:
- [ ] Agregar Panel de filtros
- [ ] Agregar TextBox "Nombre/Documento" (búsqueda)
- [ ] Agregar ComboBox "Género" (Todos, Masculino, Femenino, Otro)
- [ ] Agregar Numeric "Edad Mínima" y "Edad Máxima"
- [ ] Agregar ComboBox "EPS" (cargado desde BD)
- [ ] Agregar DateTimePicker "Fecha Registro" (desde/hasta)
- [ ] Agregar Button "Filtrar"
- [ ] Agregar Button "Limpiar Filtros"
- [ ] Crear e integrar métodos de filtrado:

**Nuevos Métodos a Crear en PacientesForm**:
1. `FiltrarPorGenero(string genero)` - ~25 líneas
2. `FiltrarPorEdad(int min, int max)` - ~25 líneas
3. `FiltrarPorEPS(int epsId)` - ~25 líneas
4. `FiltrarPorFechaRegistro(DateTime fecha)` - ~20 líneas
5. `FiltrarPorNombre(string nombre)` - ~20 líneas

---

#### T203: Agregar UI de Filtros a MedicosForm
**Prioridad**: 🔴 CRÍTICA  
**Esfuerzo**: 1.5 horas  
**Complejidad**: Media  
**Líneas**: 120-140

**Acciones**:
- [ ] Agregar Panel de filtros
- [ ] Agregar TextBox "Nombre/Apellido" (búsqueda)
- [ ] Agregar ComboBox "Especialidad" (cargado desde BD)
- [ ] Agregar Button "Filtrar"
- [ ] Agregar Button "Limpiar Filtros"
- [ ] Crear e integrar métodos de filtrado:

**Nuevos Métodos a Crear en MedicosForm**:
1. `FiltrarPorEspecialidad(int especialidadId)` - ~25 líneas
2. `FiltrarPorNombre(string nombre)` - ~25 líneas

---

#### T204: Agregar Métodos de Filtrado en Repositories
**Prioridad**: 🔴 CRÍTICA  
**Esfuerzo**: 1 hora  
**Complejidad**: Baja  
**Líneas**: 50-70

**Métodos a Crear en PacienteRepository**:
```csharp
public List<Paciente> BuscarPorGenero(string genero)
public List<Paciente> BuscarPorEdad(int edad)
public List<Paciente> BuscarPorEPS(int epsId)
public List<Paciente> BuscarPorFechaRegistro(DateTime fecha)
public List<Paciente> BuscarPorNombre(string nombre)
```

**Métodos a Crear en MedicoRepository**:
```csharp
public List<Medico> BuscarPorEspecialidad(int especialidadId)
public List<Medico> BuscarPorNombre(string nombre)
```

---

#### T205: Tests de Filtros
**Prioridad**: 🟡 IMPORTANTE  
**Esfuerzo**: 1.5 horas  
**Complejidad**: Media  
**Líneas**: 200-250

**Tests a Crear**:
- [ ] Test: Filtrar citas por estado
- [ ] Test: Filtrar citas por fecha
- [ ] Test: Filtrar pacientes por género
- [ ] Test: Filtrar pacientes por edad
- [ ] Test: Filtrar médicos por especialidad
- [ ] Test: Combinación de múltiples filtros
- [ ] Test: Resultados vacíos

---

## FASE 2: SISTEMA DE IDIOMAS (i18n) (CRÍTICA) ⏰ 6-8 horas

### Requisito del contex.md
```
"La interfaz debe ofrecer la opción de cambiar el idioma de la aplicación 
entre español e inglés en tiempo de ejecución."
```

### Tareas

#### T206: Crear LocalizationManager
**Prioridad**: 🔴 CRÍTICA  
**Esfuerzo**: 2 horas  
**Complejidad**: Media  
**Líneas**: 150-180

**Archivo**: `SistemaEmpleadosMySQL/Helpers/LocalizationManager.cs`

**Funcionalidades**:
- [ ] Enum Language (Spanish, English)
- [ ] Propiedad CurrentLanguage (estática)
- [ ] Método GetString(key) - retorna traducción
- [ ] Método SetLanguage(Language) - cambia idioma
- [ ] Evento OnLanguageChanged - notifica cambios
- [ ] Método LoadTranslations() - carga desde archivos
- [ ] Soporte para variables en strings (ex: "Hola {nombre}")

**Estructura**:
```csharp
public static class LocalizationManager
{
    public enum Language { Spanish, English }
    public static Language CurrentLanguage { get; set; }
    public static event Action OnLanguageChanged;
    
    public static string GetString(string key)
    public static void SetLanguage(Language lang)
    public static void Initialize()
}
```

---

#### T207: Crear Archivo de Traducciones Español
**Prioridad**: 🔴 CRÍTICA  
**Esfuerzo**: 1.5 horas  
**Complejidad**: Baja  
**Líneas**: 250-300

**Archivo**: `SistemaEmpleadosMySQL/Resources/Translations/es.json`

**Contenido Necesario**:
```json
{
  "app.title": "Clínica San Manotas",
  "app.version": "Versión 1.0",
  
  "login.title": "Iniciar Sesión",
  "login.username": "Usuario",
  "login.password": "Contraseña",
  "login.btnLogin": "Iniciar Sesión",
  "login.btnExit": "Salir",
  
  "main.btnPacientes": "Pacientes",
  "main.btnMedicos": "Médicos",
  "main.btnCitas": "Citas",
  "main.btnUsuarios": "Usuarios",
  "main.btnEPS": "Gestionar EPS",
  "main.btnEspecialidades": "Especialidades",
  "main.btnReportes": "Reportes",
  "main.btnSettings": "Configuración",
  
  "button.add": "Agregar",
  "button.edit": "Editar",
  "button.delete": "Eliminar",
  "button.save": "Guardar",
  "button.cancel": "Cancelar",
  "button.filter": "Filtrar",
  "button.clear": "Limpiar",
  
  "validation.required": "Campo requerido",
  "validation.invalid_email": "Email inválido",
  "validation.invalid_phone": "Teléfono inválido",
  "validation.invalid_date": "Fecha inválida",
  
  "error.connection_failed": "Error de conexión a la base de datos",
  "error.unknown": "Error desconocido",
  
  "success.saved": "Guardado correctamente",
  "success.deleted": "Eliminado correctamente",
  "success.updated": "Actualizado correctamente"
}
```

**Secciones**:
- [ ] Aplicación (app.*)
- [ ] Login (login.*)
- [ ] MainForm (main.*)
- [ ] Botones (button.*)
- [ ] Validaciones (validation.*)
- [ ] Errores (error.*)
- [ ] Éxito (success.*)
- [ ] Formularios (forms.*)
- [ ] DataGridView (grid.*)

---

#### T208: Crear Archivo de Traducciones Inglés
**Prioridad**: 🔴 CRÍTICA  
**Esfuerzo**: 1.5 horas  
**Complejidad**: Baja  
**Líneas**: 250-300

**Archivo**: `SistemaEmpleadosMySQL/Resources/Translations/en.json`

**Contenido**: Traducción al inglés de es.json

---

#### T209: Aplicar i18n a LoginForm
**Prioridad**: 🔴 CRÍTICA  
**Esfuerzo**: 1 hora  
**Complejidad**: Baja  
**Líneas**: 30-40

**Cambios**:
- [ ] Cambiar `Text` de Form a `LocalizationManager.GetString("login.title")`
- [ ] Cambiar `Text` de Label Username a `LocalizationManager.GetString("login.username")`
- [ ] Cambiar `Text` de Label Password a `LocalizationManager.GetString("login.password")`
- [ ] Cambiar `Text` de botones
- [ ] Suscribir a evento `OnLanguageChanged` para refresh

---

#### T210: Aplicar i18n a MainForm
**Prioridad**: 🔴 CRÍTICA  
**Esfuerzo**: 1 hora  
**Complejidad**: Baja  
**Líneas**: 40-50

**Cambios**:
- [ ] Cambiar `Text` de todos los botones del menú
- [ ] Cambiar `Text` de labels
- [ ] Suscribir a evento `OnLanguageChanged`

---

#### T211: Crear SettingsForm para Cambiar Idioma
**Prioridad**: 🔴 CRÍTICA  
**Esfuerzo**: 1.5 horas  
**Complejidad**: Media  
**Líneas**: 120-150

**Archivo**: `SistemaEmpleadosMySQL/UI/Forms/SettingsForm.cs`

**Funcionalidades**:
- [ ] ComboBox "Idioma" (Español, Inglés)
- [ ] Label "Idioma Actual"
- [ ] Button "Aplicar"
- [ ] Button "Aceptar"
- [ ] Button "Cancelar"
- [ ] Previsualización de cambios
- [ ] Guardar preferencia en archivo config

---

#### T212: Integrar SettingsForm en MainForm
**Prioridad**: 🔴 CRÍTICA  
**Esfuerzo**: 0.5 horas  
**Complejidad**: Baja  
**Líneas**: 10-15

**Cambios**:
- [ ] Agregar Button "Configuración" en MainForm
- [ ] Conectar evento Click a SettingsForm.ShowDialog()

---

## FASE 3: CAMBIO DE CONTRASEÑA (IMPORTANTE) ⏰ 2-3 horas

### Requisito del contex.md
```
"Además podrá permitir el cambio de contraseña, y recuperación de la misma"
```

### Tareas

#### T213: Crear ChangePasswordForm
**Prioridad**: 🟡 IMPORTANTE  
**Esfuerzo**: 1 hora  
**Complejidad**: Baja  
**Líneas**: 100-120

**Archivo**: `SistemaEmpleadosMySQL/UI/Forms/ChangePasswordForm.cs`

**Campos**:
- [ ] TextBox "Contraseña Actual" (PasswordChar)
- [ ] TextBox "Nueva Contraseña" (PasswordChar)
- [ ] TextBox "Confirmar Contraseña" (PasswordChar)
- [ ] Label "Requisitos de contraseña"
- [ ] Button "Cambiar"
- [ ] Button "Cancelar"

**Validaciones**:
- [ ] Verificar que contraseña actual es correcta
- [ ] Nueva contraseña != contraseña actual
- [ ] Nueva contraseña = confirmar contraseña
- [ ] Longitud mínima 8 caracteres
- [ ] Incluir mayúscula, minúscula, número

---

#### T214: Implementar Lógica de Cambio de Contraseña
**Prioridad**: 🟡 IMPORTANTE  
**Esfuerzo**: 1 hora  
**Complejidad**: Media  
**Líneas**: 40-60

**En ChangePasswordForm_Load()**:
- [ ] Obtener usuario actual de SessionManager
- [ ] Mostrar validaciones

**En btnCambiar_Click()**:
- [ ] Validar contraseña actual (hash)
- [ ] Hash nueva contraseña
- [ ] Actualizar en BD
- [ ] Mostrar mensaje éxito
- [ ] Cerrar formulario

---

#### T215: Integrar ChangePasswordForm en MainForm
**Prioridad**: 🟡 IMPORTANTE  
**Esfuerzo**: 0.5 horas  
**Complejidad**: Baja  
**Líneas**: 10-15

**Cambios**:
- [ ] Agregar Button "Cambiar Contraseña" en MainForm
- [ ] Conectar evento Click a ChangePasswordForm.ShowDialog()

---

## FASE 4: RECUPERACIÓN DE CONTRASEÑA (MEDIA) ⏰ 4-5 horas

### Requisito del contex.md
```
"se sugiere a través del envío de correo electrónico"
```

### Tareas

#### T216: Crear Tabla PasswordResetTokens en BD
**Prioridad**: 🟡 IMPORTANTE  
**Esfuerzo**: 0.5 horas  
**Complejidad**: Baja  
**SQL**: 10-15 líneas

**Script SQL**:
```sql
CREATE TABLE PasswordResetTokens (
    TokenId INT AUTO_INCREMENT PRIMARY KEY,
    UsuarioId INT NOT NULL,
    Token VARCHAR(255) UNIQUE NOT NULL,
    ExpiresAt DATETIME NOT NULL,
    UsedAt DATETIME NULL,
    CreatedAt DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (UsuarioId) REFERENCES Usuarios(UsuarioId)
);
```

---

#### T217: Crear EmailService
**Prioridad**: 🟡 IMPORTANTE  
**Esfuerzo**: 1.5 horas  
**Complejidad**: Media  
**Líneas**: 80-100

**Archivo**: `SistemaEmpleadosMySQL/Services/EmailService.cs`

**Funcionalidades**:
- [ ] Configuración SMTP (Gmail/Office365)
- [ ] Método `SendPasswordResetEmail(usuario, token)`
- [ ] Validación de email
- [ ] Manejo de excepciones
- [ ] Logging de envíos

**Configuración**:
```csharp
private static string SMTP_HOST = "smtp.gmail.com";
private static int SMTP_PORT = 587;
private static string SENDER_EMAIL = "clinicasanmanotas@gmail.com";
private static string SENDER_PASSWORD = "app-password-aqui";
```

---

#### T218: Crear PasswordTokenGenerator
**Prioridad**: 🟡 IMPORTANTE  
**Esfuerzo**: 0.5 horas  
**Complejidad**: Baja  
**Líneas**: 30-40

**Archivo**: `SistemaEmpleadosMySQL/Helpers/PasswordTokenGenerator.cs`

**Funcionalidades**:
- [ ] Generar token seguro (32 caracteres aleatorios)
- [ ] Método `GenerateToken()`
- [ ] Método `ValidateToken(token, expiresAt)`
- [ ] Método `CreateResetLink(token)`

---

#### T219: Crear RecuperarContraseñaForm (UI)
**Prioridad**: 🟡 IMPORTANTE  
**Esfuerzo**: 1 hora  
**Complejidad**: Media  
**Líneas**: 80-100

**Archivo**: `SistemaEmpleadosMySQL/UI/Forms/RecuperarContraseñaForm.cs`

**Dos Pasos**:

**Paso 1: Solicitar Email**
- [ ] Label "Ingrese su email registrado"
- [ ] TextBox "Email"
- [ ] Button "Enviar"
- [ ] Button "Cancelar"
- [ ] Validar que email existe en BD
- [ ] Generar token (válido 24 horas)
- [ ] Enviar email con link de reset

**Paso 2: Reset de Contraseña (desde email)**
- [ ] Parámetro URL: `?token=xxx`
- [ ] Validar token (no expirado)
- [ ] TextBox "Nueva Contraseña"
- [ ] TextBox "Confirmar Contraseña"
- [ ] Button "Cambiar"

---

#### T220: Integrar Recuperación en LoginForm
**Prioridad**: 🟡 IMPORTANTE  
**Esfuerzo**: 0.5 horas  
**Complejidad**: Baja  
**Líneas**: 15-20

**Cambios**:
- [ ] Agregar Link "¿Olvidó su contraseña?" en LoginForm
- [ ] Conectar a RecuperarContraseñaForm.ShowDialog()

---

## FASE 5: SISTEMA DE FOTOS (MEDIA) ⏰ 3-4 horas

### Requisito del contex.md
```
"La solución deberá permitir gestionar otros usuarios 
(los cuales contaran con foto, id, password y otros datos)"
```

### Tareas

#### T221: Crear Carpeta de Uploads
**Prioridad**: 🟡 IMPORTANTE  
**Esfuerzo**: 0.25 horas  
**Complejidad**: Baja  

**Estructura**:
```
SistemaEmpleadosMySQL/
  Uploads/
    Usuarios/
      (fotos aquí)
```

---

#### T222: Crear FileManager
**Prioridad**: 🟡 IMPORTANTE  
**Esfuerzo**: 1 hora  
**Complejidad**: Media  
**Líneas**: 80-100

**Archivo**: `SistemaEmpleadosMySQL/Helpers/FileManager.cs`

**Funcionalidades**:
- [ ] Método `SaveUserPhoto(usuarioId, foto)` - byte[] → archivo
- [ ] Método `GetUserPhoto(usuarioId)` - archivo → byte[]
- [ ] Método `DeleteUserPhoto(usuarioId)`
- [ ] Método `ValidatePhotoSize(size)` - máx 2MB
- [ ] Método `ValidatePhotoFormat(extension)` - JPG, PNG
- [ ] Logging de operaciones

---

#### T223: Agregar UI de Foto a UsuariosForm
**Prioridad**: 🟡 IMPORTANTE  
**Esfuerzo**: 1 hora  
**Complejidad**: Media  
**Líneas**: 60-80

**Cambios en UsuariosForm.Designer.cs**:
- [ ] Agregar PictureBox "pbFoto" (250x250)
- [ ] Agregar Button "Cargar Foto"
- [ ] Agregar Button "Eliminar Foto"
- [ ] Agregar OpenFileDialog

**Cambios en UsuariosForm.cs**:
- [ ] Evento `btnCargarFoto_Click()`
- [ ] Evento `btnEliminarFoto_Click()`
- [ ] Cargar foto en modo edición

---

#### T224: Implementar Upload/Download de Fotos
**Prioridad**: 🟡 IMPORTANTE  
**Esfuerzo**: 1 hora  
**Complejidad**: Media  
**Líneas**: 60-80

**En UsuariosForm.cs**:
- [ ] Método `CargarFotoDesdeArchivo()`
  - [ ] OpenFileDialog
  - [ ] Validar tamaño/formato
  - [ ] Convertir a byte[]
  - [ ] Mostrar preview en PictureBox
  - [ ] Guardar en propiedad Usuario.Foto

- [ ] Método `GuardarFoto()` 
  - [ ] Llamar FileManager.SaveUserPhoto()
  - [ ] Mostrar mensaje éxito

- [ ] Método `MostrarFoto(usuarioId)`
  - [ ] Cargar desde FileManager
  - [ ] Mostrar en PictureBox

---

#### T225: Tests de Sistema de Fotos
**Prioridad**: 🟡 IMPORTANTE  
**Esfuerzo**: 1 hora  
**Complejidad**: Media  
**Líneas**: 80-100

**Tests**:
- [ ] Test: Subir foto válida
- [ ] Test: Rechazar foto > 2MB
- [ ] Test: Rechazar extensión inválida
- [ ] Test: Descargar foto
- [ ] Test: Eliminar foto
- [ ] Test: Foto no encontrada

---

## 🚀 RESUMEN DE IMPLEMENTACIÓN

### Por Fase
| Fase | Tareas | Horas | Líneas | Criticidad |
|------|--------|-------|--------|-----------|
| Filtros | T201-T205 | 4-5 | 200-300 | 🔴 CRÍTICA |
| i18n | T206-T212 | 6-8 | 600-800 | 🔴 CRÍTICA |
| Contraseña | T213-T215 | 2-3 | 150-200 | 🟡 IMPORTANTE |
| Email | T216-T220 | 4-5 | 250-300 | 🟡 IMPORTANTE |
| Fotos | T221-T225 | 3-4 | 200-250 | 🟡 IMPORTANTE |
| **TOTAL** | **25** | **19-25** | **1,350-1,850** | - |

### Línea de Tiempo Recomendada
- **Día 1** (5 hrs): Filtros Avanzados (T201-T205)
- **Día 2-3** (8 hrs): Sistema de Idiomas (T206-T212)
- **Día 4** (3 hrs): Cambio de Contraseña (T213-T215)
- **Día 5** (5 hrs): Recuperación de Contraseña (T216-T220)
- **Día 6** (4 hrs): Sistema de Fotos (T221-T225)

---

## ✅ CHECKLIST FINAL

- [x] Análisis completo de contex.md
- [x] Identificación de 25 tareas pendientes
- [x] Estimación de esfuerzo por tarea
- [x] Asignación de prioridades
- [x] Creación de dependencias
- [ ] Implementar Fase 1 (Filtros)
- [ ] Implementar Fase 2 (i18n)
- [ ] Implementar Fase 3 (Cambio Contraseña)
- [ ] Implementar Fase 4 (Email)
- [ ] Implementar Fase 5 (Fotos)
- [ ] Testing completo
- [ ] Compilación final (0 errores)
- [ ] Documentación final

---

**Documento Generado**: 2025-12-06  
**Por**: GitHub Copilot  
**Estado**: Listo para implementación inmediata

