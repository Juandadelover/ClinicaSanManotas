# ✅ CHECKLIST - PRÓXIMAS TAREAS (FASE 9)

**Actualizado**: 6 de Diciembre 2025, 14:50

---

## 🎯 PRÓXIMA SESIÓN: T159 + T160

### T159: PacientesForm - Panel Filtros
**Estimación**: 35-45 minutos  
**Prioridad**: 🔴 CRÍTICA

#### Pre-requisitos
- [ ] Revisar CitasForm.Designer.cs (como referencia)
- [ ] Revisar CitasForm.cs (métodos de filtrado)
- [ ] Leer IMPLEMENTACION-INICIO.md sección T159

#### Implementación
- [ ] Agregar controles a PacientesForm.Designer.cs:
  - [ ] TextBox: txtFiltroNombre
  - [ ] ComboBox: cmbFiltroGenero
  - [ ] NumericUpDown: nudFiltroEdadMin
  - [ ] NumericUpDown: nudFiltroEdadMax
  - [ ] ComboBox: cmbFiltroEPS
  - [ ] DateTimePicker: dtpFiltroFechaRegistro
  - [ ] Button: btnAplicarFiltrosPacientes
  - [ ] Button: btnLimpiarFiltrosPacientes
  - [ ] Panel: pnlFiltrosPacientes (reutilizar si existe)

- [ ] Agregar métodos a PacientesForm.cs:
  - [ ] `CargarFiltrosPacientes()` - Inicializar combos
  - [ ] `BtnAplicarFiltrosPacientes_Click()` - Lógica AND
  - [ ] `BtnLimpiarFiltrosPacientes_Click()` - Reset
  - [ ] `FiltrarPorGenero(string genero)`
  - [ ] `FiltrarPorEdad(int min, int max)`
  - [ ] `FiltrarPorEPS(int epsId)`
  - [ ] `FiltrarPorFechaRegistro(DateTime fecha)`
  - [ ] `FiltrarPorNombre(string nombre)`

#### Verificación
- [ ] Compilación exitosa (0 errores)
- [ ] Todos los controles se cargan correctamente
- [ ] Filtros funcionan individualmente
- [ ] Filtros combinados funcionan (AND)
- [ ] Botón Limpiar reseta todos los filtros
- [ ] lblTotal muestra cantidad correcta

#### Líneas Esperadas
- Designer.cs: +120-140 líneas
- PacientesForm.cs: +120-140 líneas

---

### T160: MedicosForm - Panel Filtros
**Estimación**: 30-40 minutos  
**Prioridad**: 🔴 CRÍTICA

#### Pre-requisitos
- [ ] Completar T159 exitosamente
- [ ] Revisar T159 implementado (como referencia)
- [ ] Leer IMPLEMENTACION-INICIO.md sección T160

#### Implementación
- [ ] Agregar controles a MedicosForm.Designer.cs:
  - [ ] TextBox: txtFiltroNombreMedico
  - [ ] ComboBox: cmbFiltroEspecialidad
  - [ ] Button: btnAplicarFiltrosMedicos
  - [ ] Button: btnLimpiarFiltrosMedicos
  - [ ] Panel: pnlFiltrosMedicos

- [ ] Agregar métodos a MedicosForm.cs:
  - [ ] `CargarFiltrosMedicos()` - Inicializar combos
  - [ ] `BtnAplicarFiltrosMedicos_Click()` - Lógica AND
  - [ ] `BtnLimpiarFiltrosMedicos_Click()` - Reset
  - [ ] `FiltrarPorEspecialidad(int especialidadId)`
  - [ ] `FiltrarPorNombre(string nombre)`

#### Verificación
- [ ] Compilación exitosa (0 errores)
- [ ] Todos los controles visibles
- [ ] Filtros funcionan correctamente
- [ ] lblTotal actualizado

#### Líneas Esperadas
- Designer.cs: +100-120 líneas
- MedicosForm.cs: +80-100 líneas

---

## 📋 CHECKLIST COMPILACIÓN

### Antes de Compilar
- [ ] Todos los métodos tienen try-catch
- [ ] Todos los ComboBox tienen .Items.Add("Todos")
- [ ] Todos los Labels tienen texto descriptivo
- [ ] Todos los eventos están conectados

### Después de Compilar
- [ ] `dotnet build` sin errores
- [ ] 0 Errores críticos (CS0000-CS9999)
- [ ] Advertencias permitidas: solo CS8600-CS8625 (nullability)
- [ ] Tiempo de compilación < 5 segundos

---

## 🧪 TESTING MANUAL

### Por Formulario

#### CitasForm (Ya completado ✅)
- [X] Filtrar por Estado
- [X] Filtrar por Fechas
- [X] Filtrar por Paciente
- [X] Filtrar por Médico
- [X] Combinar todos los filtros
- [X] Botón Limpiar resetea filtros

#### PacientesForm (Próximo)
- [ ] Filtrar por Nombre
- [ ] Filtrar por Género
- [ ] Filtrar por Edad
- [ ] Filtrar por EPS
- [ ] Filtrar por Fecha Registro
- [ ] Combinar múltiples filtros
- [ ] Botón Limpiar resetea filtros

#### MedicosForm (Próximo)
- [ ] Filtrar por Nombre
- [ ] Filtrar por Especialidad
- [ ] Combinar ambos filtros
- [ ] Botón Limpiar resetea filtros

---

## 📊 PROGRESO VISUAL

```
FASE 9: Filtros Avanzados
═══════════════════════════════════════════════════

[████████░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░] 14%

T158 ✅ COMPLETADO
T159 ⏳ EN PROGRESO
T160 ⏳ PENDIENTE
T161 ⏳ PENDIENTE
T162 ⏳ PENDIENTE
T163 ⏳ PENDIENTE
T164 ⏳ PENDIENTE
```

---

## 🎯 OBJETIVOS POR SESIÓN

### Sesión 1 (HOY - COMPLETADA ✅)
- [X] T158: CitasForm Filtros - 100%
- [X] Documentación de inicio
- [X] 0 errores de compilación

### Sesión 2 (PRÓXIMA)
- [ ] T159: PacientesForm Filtros
- [ ] T160: MedicosForm Filtros
- [ ] Compilación y verificación
- [ ] Estimado: 1-1.5 horas

### Sesión 3 (POSTERIOR)
- [ ] T161: PacienteRepository
- [ ] T162: MedicoRepository
- [ ] Tests básicos
- [ ] Estimado: 1-1.5 horas

### Sesión 4 (FINAL FASE 9)
- [ ] T163-T164: Unit Tests completos
- [ ] Verificación final
- [ ] Preparar FASE 10
- [ ] Estimado: 1-1.5 horas

---

## 🔗 REFERENCIAS RÁPIDAS

### Archivos Clave
1. **CitasForm.cs**: Implementación completada (como referencia)
2. **CitasForm.Designer.cs**: UI completada (como referencia)
3. **IMPLEMENTACION-INICIO.md**: Plan detallado
4. **PROGRESO-IMPLEMENTACION.md**: Resumen actual
5. **NUEVAS-TAREAS-158-212.md**: Especificaciones técnicas

### Métodos a Copiar/Adaptar
1. `CargarCitasEnFiltros()` → `CargarFiltrosPacientes()` / `CargarFiltrosMedicos()`
2. `BtnAplicarFiltros_Click()` → `BtnAplicarFiltrosPacientes_Click()` / `BtnAplicarFiltrosMedicos_Click()`
3. `BtnLimpiarFiltros_Click()` → `BtnLimpiarFiltrosPacientes_Click()` / `BtnLimpiarFiltrosMedicos_Click()`

### Patrones a Seguir
```csharp
// Patrón de Filtrado
1. Obtener lista de BD: var items = _unitOfWork.Tabla.GetAll();
2. Limpiar DataGridView: dgv.Rows.Clear();
3. Iterar y filtrar: foreach (var item in items) { if (condición) add(); }
4. Actualizar contador: lblTotal.Text = $"Total: {dgv.Rows.Count}";
5. Logging: LogHelper.Info("Filtros aplicados...");
```

---

## ✨ NOTAS IMPORTANTES

### Nomenclatura Consistente
- Prefijo para filtros: `Filtro` (ej: cmbFiltroEstado, dtpFiltroFecha)
- Prefijo para botones: `btn` (ej: btnAplicarFiltros)
- Sufijo para métodos: `_Click` para eventos

### Consideraciones de UX
1. Inicializar combos con "Todos" primero
2. Fechas: rango por defecto es últimos 30 días
3. Mostrar cantidad de resultados siempre
4. Tooltip en cada control explicar uso

### Optimización
1. Usar `Count()` en lugar de `.Count` para IEnumerable
2. Validar combos antes de castear
3. Manejo de null en propiedades
4. Try-catch en todos los métodos

---

## 📝 REGISTRO DE CAMBIOS

| Fecha | Tarea | Status | Notas |
|-------|-------|--------|-------|
| 6 Dic | T158 | ✅ Completado | CitasForm 100%, 0 errores |
| Próx | T159 | ⏳ Planeado | PacientesForm - 35-45 min |
| Próx | T160 | ⏳ Planeado | MedicosForm - 30-40 min |
| - | T161-164 | ⏳ Planeado | Repository + Tests |

---

## 🚀 SIGUIENTES PASOS INMEDIATOS

1. ✅ **Revisión**: Leer este checklist completamente
2. ⏳ **Preparación**: Abrir CitasForm como referencia
3. ⏳ **Implementación**: Comenzar con T159
4. ⏳ **Verificación**: Compilar después de T159
5. ⏳ **Continuación**: Proceder con T160

---

**Último Actualizado**: 6 Dic 2025, 14:50  
**Próximo Review**: Después de T159  
**Status**: ✅ LISTO PARA SIGUIENTE SESIÓN
