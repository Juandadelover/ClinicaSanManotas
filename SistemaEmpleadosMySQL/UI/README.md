# UI Forms - Documentación

## Estructura de Formularios

Esta carpeta contiene todos los formularios Windows Forms de la aplicación CLINICA SAN MANOTAS.

### Autenticación

#### LoginForm
**Archivo:** `LoginForm.cs` y `LoginForm.Designer.cs`

**Descripción:** Formulario de entrada a la aplicación. Permite que los usuarios se autentiquen.

**Características:**
- Validación de credenciales contra la base de datos
- Logging de intentos de acceso
- Soporte para Enter en campo de contraseña
- Validación de usuario activo
- Cálculo de último login
- Redirección según rol del usuario

**Campos:**
- Usuario (TextBox)
- Contraseña (TextBox con PasswordChar)

**Botones:**
- **Ingresar** - Valida credenciales y abre formulario según rol
- **Salir** - Cierra la aplicación

**Flujo de Autenticación:**
1. Usuario ingresa credenciales
2. Se llama a `UsuarioRepository.VerificarCredenciales()`
3. Se verifica que usuario esté activo
4. Se actualiza `FechaUltimoLogin`
5. Se guarda en `SessionManager.UsuarioActual`
6. Se abre formulario según rol (Admin → MainForm, Recepcionista → RecepcionForm, Doctor → DoctorForm)

### Panel Administrativo

#### MainForm
**Archivo:** `MainForm.cs` y `MainForm.Designer.cs`

**Descripción:** Formulario principal para usuarios con rol Admin.

**Características:**
- Acceso a todas las funciones del sistema
- Control de permisos por rol
- Visualización de usuario actual
- Cierre de sesión

**Botones:**
- **Gestionar Pacientes** → Abre `PacientesForm`
- **Gestionar Médicos** → Abre `MedicosForm`
- **Gestionar Citas** → Abre `CitasForm`
- **Administrar Usuarios** → Abre `UsuariosForm` (solo Admin)
- **Especialidades** → Abre `EspecialidadesForm`
- **Reportes** → Abre `ReportesForm`
- **Cerrar Sesión** - Cierra sesión y vuelve a LoginForm

### Paneles Específicos

#### RecepcionForm
**Archivo:** `RecepcionForm.cs` y `RecepcionForm.Designer.cs`

**Descripción:** Formulario para recepcionistas. Acceso limitado a pacientes y citas.

**Botones:**
- **Gestionar Pacientes** → Abre `PacientesForm`
- **Gestionar Citas** → Abre `CitasForm`
- **Cerrar Sesión**

#### DoctorForm
**Archivo:** `DoctorForm.cs` y `DoctorForm.Designer.cs`

**Descripción:** Formulario para doctores. Acceso a sus citas y pacientes.

**Botones:**
- **Mis Citas** → Abre `CitasForm` (filtrado por doctor)
- **Mis Pacientes** → Abre `PacientesForm` (filtrado por citas del doctor)
- **Cerrar Sesión**

### Gestión de Datos

#### PacientesForm
**Archivo:** `PacientesForm.cs` y `PacientesForm.Designer.cs`

**Descripción:** Formulario completo de gestión de pacientes.

**Características:**
- **CRUD completo** (Create, Read, Update, Delete)
- Búsqueda por nombre
- Paginación de resultados (10 items por página)
- Validación de datos
- Logging de cambios
- Soft delete

**Campos del Formulario:**
- Nombres (TextBox)
- Apellidos (TextBox)
- Email (TextBox)
- Teléfono (TextBox)
- Documento (TextBox, único)
- Dirección (TextBox)
- Ciudad (TextBox)
- EPS (ComboBox)
- Género (ComboBox: M, F, O)
- Fecha de Nacimiento (DateTimePicker)

**Validaciones:**
- Email válido (ValidationHelper.EsEmailValido)
- Documento válido (ValidationHelper.EsDocumentoValido)
- Campos obligatorios
- EPS seleccionada

**Botones:**
- **Nuevo** - Limpia formulario para nuevo paciente
- **Guardar** - Inserta o actualiza paciente
- **Editar** - Carga datos del paciente seleccionado
- **Eliminar** - Soft delete del paciente
- **Cancelar** - Limpia formulario

**Funciones:**
- `CargarEPS()` - Carga lista de EPS en combobox
- `CargarPacientes()` - Carga pacientes con paginación
- `BuscarPacientes(criterio)` - Búsqueda LIKE por nombre
- `ValidarDatos()` - Validación completa de formulario
- `ActualizarPaginacion()` - Navega entre páginas

#### MedicosForm (Stub)
**Archivo:** `MedicosForm.cs` y `MedicosForm.Designer.cs`

**Descripción:** Formulario para gestión de médicos (en desarrollo).

**Estado:** Stub - Mensaje indicando formulario en desarrollo

#### CitasForm (Stub)
**Archivo:** `CitasForm.cs` y `CitasForm.Designer.cs`

**Descripción:** Formulario para gestión de citas (en desarrollo).

**Estado:** Stub - Mensaje indicando formulario en desarrollo

#### UsuariosForm (Stub)
**Archivo:** `UsuariosForm.cs` y `UsuariosForm.Designer.cs`

**Descripción:** Formulario para administración de usuarios (en desarrollo).

**Estado:** Stub - Mensaje indicando formulario en desarrollo

#### EspecialidadesForm (Stub)
**Archivo:** `EspecialidadesForm.cs` y `EspecialidadesForm.Designer.cs`

**Descripción:** Formulario para gestión de especialidades (en desarrollo).

**Estado:** Stub - Mensaje indicando formulario en desarrollo

#### ReportesForm (Stub)
**Archivo:** `ReportesForm.cs` y `ReportesForm.Designer.cs`

**Descripción:** Formulario de reportes (en desarrollo).

**Estado:** Stub - Mensaje indicando formulario en desarrollo

## SessionManager

**Ubicación:** `LoginForm.cs`

**Descripción:** Clase estática que maneja la sesión del usuario actual.

**Propiedades:**
```csharp
public static Usuario UsuarioActual { get; set; }
public static DateTime FechaLogin { get; set; }
public static bool EstaAutenticado => UsuarioActual != null
```

**Métodos:**
```csharp
public static void CerrarSesion()           // Cierra sesión actual
public static bool TienePermiso(string)     // Verifica permiso según rol
```

**Lógica de Permisos:**
- **Admin:** Todos los permisos
- **Recepcionista:** Acceso a pacientes y citas, NO a usuarios
- **Doctor:** Solo citas y sus pacientes

## Flujo de Navegación

```
LoginForm (Autenticación)
    ↓
    ├─→ MainForm (Admin)
    │   ├─→ PacientesForm
    │   ├─→ MedicosForm
    │   ├─→ CitasForm
    │   ├─→ UsuariosForm
    │   ├─→ EspecialidadesForm
    │   └─→ ReportesForm
    │
    ├─→ RecepcionForm (Recepcionista)
    │   ├─→ PacientesForm
    │   └─→ CitasForm
    │
    └─→ DoctorForm (Doctor)
        ├─→ CitasForm (filtrado)
        └─→ PacientesForm (filtrado)
```

## Eventos Importantes

### LoginForm
- `Load`: Inicializa controles
- `Closing`: Limpia recursos
- `KeyPress (Contraseña)`: Permite Enter para enviar

### PacientesForm
- `Load`: Carga EPS y pacientes
- `SelectionChanged (DataGridView)`: Carga datos en formulario
- `Closing`: Limpia UnitOfWork

### MainForm / RecepcionForm / DoctorForm
- `Load`: Actualiza etiqueta de usuario
- `Closing`: Confirma cierre de sesión

## Logging

Todos los formularios usan `LogHelper` para registrar:
- Cargas de formularios
- Intentos de acceso
- Cambios en datos
- Errores

Ejemplo:
```csharp
LogHelper.Info("Formulario de pacientes cargado");
LogHelper.LogAcceso(usuario.UserId, usuario.Username, "LOGIN", true);
LogHelper.LogCambio(usuario.UserId, "Paciente", paciente.PacienteId, "INSERT", "Nuevo paciente");
```

## Validaciones

### Integración con ValidationHelper
- `EsEmailValido(email)` - Valida formato de email
- `EsDocumentoValido(documento)` - Valida documento
- `EsTelefonoValido(telefono)` - Valida teléfono
- `EsEdadValida(fechaNacimiento)` - Valida edad

### Validaciones Locales
- Campos no vacíos
- Selecciones obligatorias
- Datos duplicados

## Integraciones

### Con Repositorios
```csharp
UnitOfWork uow = new UnitOfWork();
var usuarios = uow.Usuarios.GetAll();
var paciente = uow.Pacientes.GetById(id);
uow.Pacientes.Add(paciente);
uow.Pacientes.Update(paciente);
uow.Pacientes.Remove(paciente);
```

### Con Helpers
```csharp
LogHelper.Info("Mensaje");
ValidationHelper.EsEmailValido(email);
SecurityHelper.GenerarHashContraseña(password);
```

## Próximas Mejoras

- [ ] Implementar búsqueda avanzada en PacientesForm
- [ ] Agregar validación de doble clic en DataGridView
- [ ] Mejorar diseño visual con temas
- [ ] Agregar confirmaciones de eliminación personalizadas
- [ ] Implementar exportación a Excel de reportes
- [ ] Agregar caché de datos de referencia
- [ ] Implementar permisos granulares por usuario

## Consideraciones de Diseño

1. **Responsabilidad Única:** Cada formulario maneja una entidad
2. **Separación de Concerns:** Lógica de negocio en Repositorios/Services
3. **Validación en Capas:** UI valida formato, Repositorio valida reglas
4. **Logging Centralizado:** LogHelper para auditoría
5. **Gestión de Sesión:** SessionManager para acceso global
6. **Disposición de Recursos:** UnitOfWork en using o Dispose explícito

## Dependencias

- System.Windows.Forms
- SistemaEmpleadosMySQL.Repositories (UnitOfWork, IRepository)
- SistemaEmpleadosMySQL.Helpers (LogHelper, ValidationHelper, SecurityHelper)
- SistemaEmpleadosMySQL.Model (Entidades)
- SistemaEmpleadosMySQL.DTO (Data Transfer Objects)
