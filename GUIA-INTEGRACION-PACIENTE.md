# 🚀 GUÍA DE INTEGRACIÓN - PacienteRepository

## Descripción
Esta guía explica cómo integrar el nuevo `PacienteRepository.cs` al proyecto para que el CRUD de pacientes funcione correctamente.

---

## ✅ Checklist de Integración

### Paso 1: Actualizar UnitOfWork.cs
**Archivo**: `SistemaEmpleadosMySQL/Repositories/UnitOfWork.cs`

**Cambio Requerido**: Agregar PacienteRepository

```csharp
// Buscar esta línea (aproximadamente línea 20):
public UsuarioRepository Usuarios { get; set; }

// Agregar después:
public PacienteRepository Pacientes { get; set; }

// En el constructor (línea ~30):
public UnitOfWork()
{
    Usuarios = new UsuarioRepository();
    Pacientes = new PacienteRepository();  // ← AGREGAR
}
```

### Paso 2: Actualizar Interfaz IRepository
**Archivo**: `SistemaEmpleadosMySQL/Repositories/IRepository.cs`

**Verificar** que incluya:
```csharp
public interface IRepository<T> where T : class
{
    IEnumerable<T> GetAll();
    IEnumerable<T> GetAllPaged(int pageNumber, int pageSize);
    T GetById(int id);
    void Add(T entity);
    void Update(T entity);
    void Remove(T entity);
    int Count();
}
```

### Paso 3: Compilar Solución
```powershell
# En Visual Studio
Build > Build Solution
# O presionar: Ctrl+Shift+B
```

**Verificar**: No hay errores de compilación

---

## 🧪 Pruebas de Validación

### Test 1: Cargar Pacientes
```csharp
// En PacientesForm.cs línea ~107
private void CargarPacientes()
{
    var pacientes = _unitOfWork.Pacientes.GetAllPaged(_paginaActual, ITEMS_POR_PAGINA);
    dgvPacientes.DataSource = pacientes;
    // Antes: DataGridView vacío
    // Después: ✅ Debe mostrar lista de pacientes
}
```

**Resultado Esperado**: ✅ DataGridView muestra 10 pacientes

### Test 2: Búsqueda
```csharp
// En btnBuscar_Click (línea ~135)
var resultados = _unitOfWork.Pacientes.BuscarPorNombre(criterio, 1, 10);
dgvPacientes.DataSource = resultados;
// Antes: No funcionaba (método no existía)
// Después: ✅ Busca correctamente
```

**Resultado Esperado**: ✅ Encuentra pacientes por nombre/apellido

### Test 3: Filtros
```csharp
// En BtnAplicarFiltrosPac_Click (línea ~394)
var pacientes = _unitOfWork.Pacientes.GetAll();
// Aplicar filtros...
// Antes: Retornaba lista vacía
// Después: ✅ Retorna datos reales
```

**Resultado Esperado**: ✅ Filtros funcionan correctamente

---

## 🔧 Correcciones Adicionales en PacientesForm.cs

### Corrección 1: Manejo de EPS en ComboBox

**Ubicación**: Método `CargarEPS()` (línea ~38)

**Código Actual** (Incorrecto):
```csharp
foreach (var eps in listaEPS)
{
    cmbEPS.Items.Add(eps.Nombre);  // ❌ Solo el nombre
}
```

**Código Corregido**:
```csharp
foreach (var eps in listaEPS)
{
    cmbEPS.Items.Add(eps);  // ✅ Agregar objeto EPS completo
}

// Cambiar tipo de combobox:
// this.cmbEPS.DisplayMember = "Nombre";
// this.cmbEPS.ValueMember = "EPSId";
```

**O Alternativa**:
```csharp
foreach (var eps in listaEPS)
{
    cmbEPS.Items.Add($"{eps.EPSId}|{eps.Nombre}");
}

// Y en btnGuardar_Click (línea ~195):
if (cmbEPS.SelectedItem != null)
{
    string[] partes = cmbEPS.SelectedItem.ToString().Split('|');
    if (int.TryParse(partes[0], out int epsId))
    {
        _pacienteActual.EPSId = epsId;
    }
}
```

### Corrección 2: Validar Documento Único

**Agregar en método btnGuardar_Click** (antes de `Add`):
```csharp
// Verificar documento único
var existente = _unitOfWork.Pacientes.ObtenerPorDocumento(txtDocumento.Text);
if (existente != null && existente.PacienteId != _pacienteActual.PacienteId)
{
    MessageBox.Show("Este documento ya existe en el sistema.");
    txtDocumento.Focus();
    return;
}
```

---

## 📋 Métodos Disponibles en PacienteRepository

### Lectura
```csharp
IEnumerable<Paciente> GetAll()
IEnumerable<Paciente> GetAllPaged(int pageNumber, int pageSize)
Paciente GetById(int id)
int ObtenerTotal()
```

### Búsqueda
```csharp
IEnumerable<Paciente> BuscarPorNombre(string criterio, int pageNumber = 1, int pageSize = 10)
Paciente ObtenerPorDocumento(string documento)
```

### Filtros
```csharp
IEnumerable<Paciente> ObtenerPorEPS(int epsId)
IEnumerable<Paciente> ObtenerPorGenero(string genero)
IEnumerable<Paciente> ObtenerPorRangoEdad(int edadMin, int edadMax)
IEnumerable<Paciente> ObtenerPorCiudad(string ciudad)
```

### Gestión (CRUD)
```csharp
void Add(Paciente entity)
void Update(Paciente entity)
void Remove(Paciente entity)  // Soft delete
```

---

## 🐛 Problemas Comunes y Soluciones

### Problema: "Object reference not set to an instance of an object"
**Causa**: `_unitOfWork` es nulo
**Solución**: Asegurar que en constructor se llama `_unitOfWork = new UnitOfWork();`

### Problema: "Unknown column 'Paciente' in 'from clause'"
**Causa**: Nombre de tabla incorrecto
**Solución**: La tabla se llama `Paciente` (singular), no `Pacientes`

### Problema: DataGridView sigue vacío
**Causa**: GetAllPaged() aún retorna lista vacía
**Solución**: Verificar que UnitOfWork.Pacientes esté inicializado correctamente

### Problema: EPSId = 0 al guardar paciente
**Causa**: ComboBox no devuelve ID correctamente
**Solución**: Usar las correcciones de "Manejo de EPS en ComboBox" arriba

---

## ✅ Verificación Final

Ejecutar estos tests después de integrar:

```csharp
// Test 1: Conexión
var db = DatabaseConnection.GetInstance();
if (!db.EstaConectado())
{
    MessageBox.Show("Error de conexión");
    return;
}

// Test 2: Lectura
var repo = new PacienteRepository();
var pacientes = repo.GetAll();
MessageBox.Show($"Se leyeron {pacientes.Count()} pacientes");

// Test 3: Búsqueda
var resultados = repo.BuscarPorNombre("Juan", 1, 10);
MessageBox.Show($"Se encontraron {resultados.Count()} resultados");

// Test 4: Filtro
var menores30 = repo.ObtenerPorRangoEdad(0, 29);
MessageBox.Show($"Pacientes < 30 años: {menores30.Count()}");
```

---

## 🎯 Orden de Implementación

1. ✅ Crear `PacienteRepository.cs` - **YA HECHO**
2. ⏳ Actualizar `UnitOfWork.cs`
3. ⏳ Compilar solución
4. ⏳ Ejecutar tests
5. ⏳ Corregir ComboBox EPS si es necesario
6. ⏳ Agregar validación de documento único
7. ⏳ Pruebas finales en interfaz

---

## 📚 Recursos Incluidos

- ✅ `PacienteRepository.cs` - Implementación completa (325 líneas)
- ✅ `08-test-pacientes-crud.sql` - Script de pruebas BD (239 líneas)
- ✅ `REPORTE-PRUEBAS-CRUD-PACIENTES.md` - Análisis detallado
- ✅ `CONEXION-VERIFICADA.md` - Verificación de BD
- ✅ Esta guía de integración

---

## 📞 Soporte

Si hay errores después de integrar:

1. Verificar que `PacienteRepository.cs` esté en carpeta correcta
2. Verificar que `using` statements estén correctos
3. Limpiar y recompilar solución (`Clean Solution` + `Build Solution`)
4. Revisar el archivo de log de errores
5. Consultar `REPORTE-PRUEBAS-CRUD-PACIENTES.md` para más detalles

---

**Última actualización**: 10 de Diciembre de 2025  
**Versión**: 1.0  
**Autor**: GitHub Copilot
