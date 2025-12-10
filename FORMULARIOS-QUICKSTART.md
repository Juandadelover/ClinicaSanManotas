# 🚀 Guía Rápida - Formularios UI

## 1. Punto de Entrada

El formulario de login es el punto de entrada. Modifica `Program.cs`:

```csharp
using System;
using System.Windows.Forms;
using SistemaEmpleadosMySQL.UI.Forms;

static class Program
{
    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        
        // Inicia con LoginForm
        Application.Run(new LoginForm());
    }
}
```

## 2. Flujo de Autenticación

### Credenciales de Prueba

**Admin:**
```
Usuario: admin
Contraseña: [Hash de 'password123']
```

**Recepcionista:**
```
Usuario: recepcion
Contraseña: [Hash de 'password123']
```

**Doctor:**
```
Usuario: doctor1
Contraseña: [Hash de 'password123']
```

> Estas deben insertarse en la BD con los scripts de inicialización

### Proceso de Login

1. Usuario ingresa credenciales
2. LoginForm valida contra `UsuarioRepository`
3. Si es válido:
   - Actualiza `FechaUltimoLogin`
   - Guarda en `SessionManager.UsuarioActual`
   - Registra en log
   - Abre formulario según rol

## 3. Uso de Sesión

### Acceder Datos del Usuario Actual

```csharp
if (SessionManager.EstaAutenticado)
{
    var usuario = SessionManager.UsuarioActual;
    Console.WriteLine($"Usuario: {usuario.Username}");
    Console.WriteLine($"Rol: {usuario.ObtenerNombreRol()}");
    Console.WriteLine($"Email: {usuario.Email}");
}
```

### Verificar Permisos

```csharp
if (SessionManager.TienePermiso("GestionarPacientes"))
{
    // Abrir formulario de pacientes
}
else
{
    MessageBox.Show("No tiene permisos para acceder a Pacientes.");
}
```

### Cerrar Sesión

```csharp
SessionManager.CerrarSesion();
// Vuelve a LoginForm
```

## 4. Trabajar con PacientesForm

### Abrir el Formulario

```csharp
PacientesForm pacientesForm = new PacientesForm();
pacientesForm.ShowDialog(); // Modal
// o
pacientesForm.Show(); // No modal
```

### Datos que Maneja

- Crear nuevo paciente
- Editar datos del paciente
- Buscar por nombre
- Ver lista paginada (10 items)
- Eliminar (soft delete)

## 5. Usar UnitOfWork en Formularios

### Patrón Básico

```csharp
using (var uow = new UnitOfWork())
{
    try
    {
        // Operaciones
        var pacientes = uow.Pacientes.GetAll();
        
        // Cambios
        uow.Pacientes.Add(nuevoPaciente);
        
        // Guardar (automático con dispose)
    }
    catch (Exception ex)
    {
        LogHelper.Error("Error", ex);
    }
} // Dispose automático
```

### Con Transacciones

```csharp
using (var uow = new UnitOfWork())
{
    uow.BeginTransaction();
    try
    {
        // Múltiples operaciones
        uow.Pacientes.Add(paciente);
        uow.Medicos.Add(medico);
        uow.Citas.Add(cita);
        
        uow.CommitTransaction();
    }
    catch
    {
        uow.RollbackTransaction();
        throw;
    }
}
```

## 6. Validaciones

### En UI

```csharp
private bool ValidarDatos()
{
    if (string.IsNullOrWhiteSpace(txtEmail.Text))
    {
        MessageBox.Show("Ingrese email");
        return false;
    }
    
    if (!ValidationHelper.EsEmailValido(txtEmail.Text))
    {
        MessageBox.Show("Email inválido");
        return false;
    }
    
    return true;
}
```

### En Modelo

```csharp
var paciente = new Paciente { ... };
if (!paciente.EsValido())
{
    throw new InvalidOperationException("Datos inválidos");
}
```

## 7. Logging

### Registrar Acciones

```csharp
// Acceso de usuario
LogHelper.LogAcceso(usuario.UserId, usuario.Username, "LOGIN", true);

// Cambios en datos
LogHelper.LogCambio(
    usuarioId: SessionManager.UsuarioActual.UserId,
    tabla: "Paciente",
    registroId: paciente.PacienteId,
    operacion: "INSERT",
    detalles: $"Nuevo paciente: {paciente.Nombres}"
);

// Mensajes generales
LogHelper.Info("Paciente creado exitosamente");
LogHelper.Error("Error al guardar", exception);
```

## 8. Manejo de Errores

### Try-Catch Estándar

```csharp
try
{
    // Operación
    var paciente = _unitOfWork.Pacientes.GetById(id);
}
catch (Exception ex)
{
    LogHelper.Error("Error obteniendo paciente", ex);
    MessageBox.Show($"Error: {ex.Message}", "Error", 
        MessageBoxButtons.OK, MessageBoxIcon.Error);
}
```

## 9. Patrones Comunes

### CRUD Pattern

```csharp
// CREATE
var paciente = new Paciente { Nombres = "Juan", ... };
_unitOfWork.Pacientes.Add(paciente);

// READ
var paciente = _unitOfWork.Pacientes.GetById(id);

// UPDATE
paciente.Nombres = "Juan Actualizado";
_unitOfWork.Pacientes.Update(paciente);

// DELETE (Soft)
_unitOfWork.Pacientes.Remove(paciente);
```

### Búsqueda y Paginación

```csharp
// Búsqueda
var resultados = _unitOfWork.Pacientes.BuscarPorNombre("Juan", 1, 10);

// Paginación
var pagina1 = _unitOfWork.Pacientes.GetAllPaged(1, 10);
var pagina2 = _unitOfWork.Pacientes.GetAllPaged(2, 10);
```

## 10. Debugging

### Verificar Conexión

```csharp
var connection = DatabaseConnection.GetInstance();
if (connection.EstaConectado())
{
    MessageBox.Show("Conectado a BD");
}
else
{
    MessageBox.Show("Error de conexión");
}
```

### Ver Logs

Los logs se guardan en: `logs/` (en la carpeta de la aplicación)

Formato: `[TIMESTAMP] [LEVEL] Mensaje`

## 11. Troubleshooting

### Error: "No existe constructor predeterminado"

**Solución:** Asegúrate de tener el constructor sin parámetros en los DTOs

```csharp
public class PacienteDTO
{
    public PacienteDTO() { }  // Requerido
    public int PacienteId { get; set; }
}
```

### Error: "NullReferenceException en SessionManager"

**Solución:** Verifica que `SessionManager.UsuarioActual` esté asignado en LoginForm

```csharp
SessionManager.UsuarioActual = usuarioActual;
```

### Error: "La conexión se cerró inesperadamente"

**Solución:** Asegúrate de usar `using` con UnitOfWork o llamar a `Dispose()`

```csharp
using (var uow = new UnitOfWork())
{
    // El using llama automáticamente a Dispose()
}
```

## 12. Mejores Prácticas

✅ **Siempre usar using con UnitOfWork**
```csharp
using (var uow = new UnitOfWork()) { ... }
```

✅ **Validar antes de guardar**
```csharp
if (!entity.EsValido()) throw new Exception("Invalid");
```

✅ **Loguear todas las operaciones**
```csharp
LogHelper.Info("Operación completada");
```

✅ **Manejar excepciones explícitamente**
```csharp
catch (Exception ex)
{
    LogHelper.Error("Error", ex);
}
```

✅ **Mostrar confirmación antes de eliminar**
```csharp
DialogResult = MessageBox.Show("¿Eliminar?", ...);
```

## 13. Checklist Pre-Producción

- [ ] Base de datos ejecutada (scripts 01-03)
- [ ] Usuarios de prueba creados
- [ ] Conexión verificada
- [ ] Logs funcionando
- [ ] Todas las validaciones en lugar
- [ ] Manejo de errores implementado
- [ ] Testing completado
- [ ] Documentación actualizada

---

**¡Listo para comenzar! 🎉**
