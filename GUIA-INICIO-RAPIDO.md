# 🚀 GUÍA DE INICIO RÁPIDO

**Para**: Comenzar implementación inmediata de nuevas tareas  
**Tiempo**: 5 minutos para leer esto  
**Fecha**: 2025-12-06

---

## ⚡ EN 5 SEGUNDOS

✅ Análisis completado  
✅ 50 tareas nuevas creadas (T158-T212)  
✅ Compilación: 0 errores  
✅ Listo para programar AHORA

---

## 📖 LO QUE NECESITAS LEER (En orden)

### 1️⃣ **SINTESIS-EJECUTIVA.md** (10 minutos)
- Qué falta
- 3 opciones de plan
- Recomendación

### 2️⃣ **NUEVAS-TAREAS-158-212.md** (30 minutos)
- Detalles de cada tarea
- Qué implementar exactamente
- Líneas de código aproximadas

### 3️⃣ **Listo para programar** 🎯

---

## 🎯 ELIGE TU PLAN

### OPCIÓN 1: COMPLETO (Semana completa - 95% requisitos)
```
Lunes:    Filtros Avanzados (4-5 hrs)
Martes:   Sistema de Idiomas (3-4 hrs)
Miércoles: Sistema de Idiomas (3-4 hrs)
Jueves:   Cambio Contraseña (2-3 hrs)
Viernes:  Recuperación Email (4-5 hrs)
Semana 2: Sistema de Fotos (3-4 hrs)
```
**Total**: 19-25 horas

### OPCIÓN 2: ESENCIAL (3-4 días - 85-90% requisitos) ⭐ RECOMENDADO
```
Lunes:         Filtros Avanzados (4-5 hrs)
Martes-Miércoles: Sistema de Idiomas (6-8 hrs)
Jueves:        Cambio Contraseña (2-3 hrs)
Viernes:       Testing + Docs (2-3 hrs)
```
**Total**: 14-19 horas

### OPCIÓN 3: MÍNIMO (2 días - 75-80% requisitos)
```
Lunes:  Filtros Avanzados (4-5 hrs)
Martes: Sistema de Idiomas (6-8 hrs)
```
**Total**: 10-13 horas

**RECOMENDACIÓN**: Opción 2 (equilibrado, cubre lo importante)

---

## 📋 TAREAS POR DÍA (Opción 2 Recomendada)

### 🟦 LUNES: FILTROS AVANZADOS

**Tareas**: T158, T159, T160, T161, T162, T163, T164 (7 tareas)

**Tiempo**: 4-5 horas

**Qué hacer**:
- [ ] Abrir **NUEVAS-TAREAS-158-212.md**
- [ ] Buscar sección **"PHASE 9: FILTROS AVANZADOS"**
- [ ] Implementar T158 → CitasForm UI filtros (1.5 hrs)
- [ ] Implementar T159 → PacientesForm UI filtros (1.5 hrs)
- [ ] Implementar T160 → MedicosForm UI filtros (1.5 hrs)
- [ ] Compilar y verificar

**Resultado**: Todos los 8 filtros del contex.md funcionales

---

### 🟧 MARTES-MIÉRCOLES: SISTEMA DE IDIOMAS

**Tareas**: T165-T177 (13 tareas)

**Tiempo**: 6-8 horas (3-4 hrs cada día)

**Qué hacer**:
- [ ] Leer **NUEVAS-TAREAS-158-212.md** → "PHASE 10: LOCALIZACIÓN"
- [ ] Implementar T165 → LocalizationManager (2 hrs)
- [ ] Implementar T168 → es.json (1.5 hrs)
- [ ] Implementar T169 → en.json (1.5 hrs)
- [ ] Implementar T170 → SettingsForm (1.5 hrs)
- [ ] Implementar T172-T174 → Aplicar a formularios (1.5 hrs)
- [ ] Compilar y verificar

**Resultado**: App 100% bilingüe, cambio de idioma dinámico

---

### 🟨 JUEVES: CAMBIO DE CONTRASEÑA

**Tareas**: T178-T184 (7 tareas)

**Tiempo**: 2-3 horas

**Qué hacer**:
- [ ] Leer **NUEVAS-TAREAS-158-212.md** → "PHASE 11: CAMBIO DE CONTRASEÑA"
- [ ] Implementar T178 → ChangePasswordForm (1 hr)
- [ ] Implementar T181 → AuthenticationService lógica (1 hr)
- [ ] Compilar y verificar

**Resultado**: Usuarios pueden cambiar contraseña

---

### 🟩 VIERNES: TESTING + DOCUMENTACIÓN

**Tareas**: T208-T212 (5 tareas)

**Tiempo**: 2-3 horas

**Qué hacer**:
- [ ] Compilar proyecto (`dotnet build`)
- [ ] Verificar: 0 errores ✅
- [ ] Testing manual de filtros
- [ ] Testing manual de cambio idioma
- [ ] Testing manual de cambio contraseña
- [ ] Actualizar PROGRESO.md

**Resultado**: Proyecto finalizado, 0 errores, todas las funcionalidades verificadas

---

## 🔧 GUÍA RÁPIDA POR ARCHIVO

### CitasForm (T158)
**Agregar Panel de Filtros**:
- Método en CitasForm.cs: `btnFiltrar_Click()`
- Conectar a existentes: `FiltrarPorEstado()`, `FiltrarPorFechas()`, etc.
- Líneas: ~80-100

### LocalizationManager (T165)
**Crear Servicio de Idiomas**:
- Archivo: `SistemaEmpleadosMySQL/Helpers/LocalizationManager.cs`
- Método: `GetString(key)` - retorna traducción
- Líneas: ~150-180

### ChangePasswordForm (T178)
**Crear Formulario de Cambio**:
- Archivo: `SistemaEmpleadosMySQL/UI/Forms/ChangePasswordForm.cs`
- TextBox para contraseñas (3)
- Validaciones de requisitos
- Líneas: ~120-150

---

## 📖 CÓMO LEER LAS TAREAS

**Cada tarea tiene**:
```
- [ ] T### [PRIORIDAD] Título
  - Descripción breve
  - Archivo(s) afectado(s)
  - Métodos/funciones
  - ~Líneas de código
```

**Ejemplo**:
```
- [ ] T158 [CRÍTICA] Agregar panel de filtros a CitasForm
  - ComboBox: Estado (Todos, Pendiente, Confirmada, Realizada, Cancelada)
  - DateTimePicker: Fecha Inicio
  - DateTimePicker: Fecha Fin
  - Conectar a métodos existentes: FiltrarPorEstado, etc.
  - ~80-100 líneas
```

---

## ✅ CHECKLIST DIARIO

**Al Empezar**:
- [ ] Leer documentación de la fase del día
- [ ] Compilar proyecto (verificar 0 errores)
- [ ] Abrir NUEVAS-TAREAS-158-212.md
- [ ] Identificar tarea #1 del día

**Durante Código**:
- [ ] Escribir código incrementalmente
- [ ] Compilar cada 30 minutos
- [ ] Testear cambios manualmente
- [ ] Documentar en código

**Al Terminar**:
- [ ] Compilar proyecto completo
- [ ] Verificar 0 errores
- [ ] Actualizar PROGRESO.md
- [ ] Marcar tareas completadas ✅

---

## 🎓 ESTRUCTURA DE CARPETAS

```
SistemaEmpleadosMySQL/
├── Helpers/
│   ├── LocalizationManager.cs (NUEVO - T165)
│   ├── PasswordTokenGenerator.cs (NUEVO - T188)
│   ├── FileManager.cs (NUEVO - T198)
│   └── ...
├── UI/Forms/
│   ├── CitasForm.cs (MODIFICAR - T158)
│   ├── ChangePasswordForm.cs (NUEVO - T178)
│   ├── RecuperarContraseñaForm.cs (NUEVO - T190)
│   ├── SettingsForm.cs (NUEVO - T170)
│   └── ...
├── Services/
│   ├── EmailService.cs (NUEVO - T187)
│   └── ...
├── Resources/
│   └── Translations/ (NUEVO - T168, T169)
│       ├── es.json
│       └── en.json
└── Uploads/ (NUEVO - T196)
    └── Usuarios/
```

---

## 💻 COMANDOS ÚTILES

### Compilar
```powershell
cd "C:\ruta\proyecto"
dotnet build
```

### Ver errores
```powershell
dotnet build 2>&1 | Select-String "error"
```

### Ejecutar tests
```powershell
dotnet test
```

### Limpiar build
```powershell
dotnet clean
```

---

## 🐛 TROUBLESHOOTING

### Problema: Compilación lenta
**Solución**: `dotnet clean` y luego `dotnet build`

### Problema: Archivo bloqueado
**Solución**: Cerrar VS, ejecutar: `Stop-Process -Name CLINICA_SAN_MANOTAS -Force`

### Problema: Método no encontrado
**Solución**: Verificar nombre exacto y que esté en la clase correcta

### Problema: No compila
**Solución**: Leer mensaje de error, buscar línea, verificar sintaxis

---

## 📞 REFERENCIAS RÁPIDAS

| Necesito | Archivo | Sección |
|----------|---------|---------|
| Plan general | SINTESIS-EJECUTIVA.md | "Plan Propuesto" |
| Detalles T### | NUEVAS-TAREAS-158-212.md | Buscar "T###" |
| Cobertura | ANALISIS-CONTEX-VS-IMPLEMENTADO.md | "Matriz" |
| Búsqueda | INDICE-RAPIDO.md | Todo |

---

## 🏁 META FINAL

**Después de seguir esta guía**:
- ✅ Filtros Avanzados: Funcionales
- ✅ Sistema i18n: Español/Inglés
- ✅ Cambio Contraseña: Implementado
- ✅ Compilación: 0 errores
- ✅ Requisitos contex.md: 85-90% cubiertos

---

## 🚀 COMENZAR AHORA

### Paso 1: Leer (5 min)
- [ ] Esta guía (lo que estás leyendo ahora)

### Paso 2: Preparar (5 min)
- [ ] Abrir NUEVAS-TAREAS-158-212.md
- [ ] Abrir editor de código
- [ ] Abrirproyecto en VS

### Paso 3: Programar
- [ ] Lunes: T158-T164 (Filtros)
- [ ] Martes-Miércoles: T165-T177 (i18n)
- [ ] Jueves: T178-T184 (Contraseña)

### Paso 4: Verificar
- [ ] Compilar: `dotnet build`
- [ ] Resultado: 0 errores ✅

---

**¡LISTO PARA EMPEZAR!** 🎉

Próximo paso: Abre **NUEVAS-TAREAS-158-212.md** y comienza con **T158**

