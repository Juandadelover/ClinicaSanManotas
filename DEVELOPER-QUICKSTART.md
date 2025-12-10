# 🚀 GUÍA DE INICIO RÁPIDO - PARA DESARROLLADORES

**Proyecto**: CLINICA SAN MANOTAS  
**Fecha**: 5 de Diciembre de 2025  
**Target**: Comenzar Phase 2 en < 1 hora

---

## ⏱️ CHECKLIST DE SETUP (30 minutos)

### 1. Verificar Requisitos ✅
```powershell
# En PowerShell - Verificar instalaciones

# .NET 8 SDK
dotnet --version
# Esperado: 8.0.x

# MySQL
mysql --version
# Esperado: mysql Ver 8.0+

# Visual Studio 2022 o VS Code
code --version      # Para VS Code
# Esperado: versión reciente
```

**Si falta algo**: Instalar desde:
- `.NET 8 SDK`: https://dotnet.microsoft.com/download
- `MySQL Community`: https://dev.mysql.com/downloads/mysql/
- `Visual Studio 2022`: https://visualstudio.microsoft.com/
- `VS Code + C# Extension`: https://code.visualstudio.com/

---

### 2. Clonar o Preparar Proyecto
```powershell
# Navegar a carpeta del proyecto
cd "C:\Users\aquil\OneDrive\Escritorio\Nueva carpeta\SENA\MANOTAS\EVALUACIÓN C#\CLINICA_SAN_MANOTAS\CLINICA_SAN_MANOTAS\CLINICA_SAN_MANOTAS"

# Verificar archivos presentes
ls
# Esperado: CLINICA_SAN_MANOTAS.sln, Form1.cs, etc.
```

---

### 3. Crear Base de Datos (10 minutos)
```powershell
# Opción A: PowerShell + MySQL CLI
$scripts = @(
    "database\scripts\01-create-database.sql",
    "database\scripts\02-insert-initial-data.sql",
    "database\scripts\03-stored-procedures.sql"
)

foreach ($script in $scripts) {
    Write-Host "Ejecutando: $script"
    mysql -u root -p < $script
}

# Opción B: MySQL Workbench
# 1. Abrir MySQL Workbench
# 2. New Query Tab
# 3. Copiar contenido de cada .sql
# 4. Ejecutar (Ctrl + Shift + Enter)
# 5. Verificar: SHOW DATABASES; SHOW TABLES;
```

---

### 4. Restaurar NuGet Packages
```powershell
# En la carpeta del proyecto
dotnet restore

# Alternativa: Visual Studio
# Tools → NuGet Package Manager → Package Manager Console
# Update-Package
```

---

### 5. Compilar Proyecto
```powershell
# Compilar
dotnet build

# Esperado: Build succeeded
# Si hay errores: Ver sección Troubleshooting
```

---

## 📖 LECTURA RECOMENDADA (15 minutos)

Leer en este orden:

1. **PLAN_RESUMEN.md** (5 min)
   - Visión general del proyecto
   - Phases y timeline

2. **specs/master/spec.md** (5 min)
   - Requisitos funcionales
   - Qué se va a construir

3. **specs/master/data-model.md** (5 min)
   - Estructura de base de datos
   - Relaciones entre tablas

---

## 🔥 EMPEZAR PHASE 2 (22 horas)

### Tareas T001-T006: Setup (2-3 horas)

**T001**: Crear estructura de carpetas
```powershell
# Crear carpetas
mkdir src
mkdir src/Models
mkdir src/Data
mkdir src/Services
mkdir src/Repositories
mkdir src/Validation
mkdir src/DTOs
mkdir tests
mkdir tests/UnitTests
mkdir tests/IntegrationTests
```

**T002**: Agregar NuGet Packages necesarios
```powershell
dotnet add package Microsoft.EntityFrameworkCore --version 8.0.0
dotnet add package Microsoft.EntityFrameworkCore.MySql --version 8.0.0
dotnet add package BCrypt.Net-Next --version 4.0.3
dotnet add package Serilog --version 3.1.0
dotnet add package Serilog.Sinks.Console --version 4.1.0
dotnet add package Serilog.Sinks.File --version 5.0.0
dotnet add package xunit --version 2.6.0
dotnet add package Moq --version 4.20.0
```

**T003**: Crear appsettings.json
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=CLINICA_SAN_MANOTAS;User=root;Password=your_password;"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information"
    }
  },
  "Serilog": {
    "Using": ["Serilog.Sinks.Console", "Serilog.Sinks.File"],
    "MinimumLevel": "Debug",
    "WriteTo": [
      { "Name": "Console" },
      { "Name": "File", "Args": { "path": "logs/app-.txt", "rollingInterval": "Day" } }
    ]
  }
}
```

**T004-T006**: Ver tareas.md para detalles

---

## 🧪 VERIFICACIÓN RÁPIDA

### Test: ¿Está todo configurado?

```csharp
// En Program.cs
static void Main()
{
    // 1. Verificar conexión BD
    using var context = new ClinicaDbContext();
    var users = context.Usuarios.Count();
    Console.WriteLine($"✅ BD conectada: {users} usuarios");

    // 2. Verificar Models cargan
    var patient = new Paciente { Nombres = "Test" };
    Console.WriteLine($"✅ Models OK");

    // 3. Verificar Serilog
    var logger = new LoggerConfiguration()
        .WriteTo.Console()
        .CreateLogger();
    logger.Information("✅ Logging OK");
}
```

---

## 📊 ROADMAP VISUAL

```
[Day 1-3]  Phase 2: Setup + Foundational (22h)
├─ T001-T006: Project Structure (2h)
├─ T007-T012: Entity Models (6h)
├─ T013-T020: DbContext + Repositories (6h)
├─ T021-T024: DB Migration (3h)
└─ T025-T040: Services + Tests (5h)

[Day 4-5]  Phase 3: Authentication (16h)
├─ T041-T044: Usuario Model + DTO (2h)
├─ T045-T048: AuthService (4h)
├─ T049-T050: LoginForm UI (3h)
└─ T051-T056: Tests + Integration (7h)

[Day 6-9]  Phase 4: Patients (22h)
[Day 10-15] Remaining Phases...
```

---

## ⚠️ TROUBLESHOOTING COMÚN

### Error: "Cannot connect to database"
```
Solución:
1. Verificar MySQL está corriendo: mysql -u root -p
2. Verificar script 01 se ejecutó: SHOW DATABASES;
3. Verificar connection string en appsettings.json
4. Si sigue: Ver quickstart.md sección Troubleshooting
```

### Error: "NuGet package not found"
```
Solución:
1. Limpiar cache: dotnet nuget locals all --clear
2. Restaurar: dotnet restore
3. Actualizar NuGet: nuget update
```

### Error: "EF Core migration failed"
```
Solución:
1. Ejecutar: dotnet ef database update
2. Si falla: Revisar ClinicaDbContext configuration
3. Ver tasks.md T014-T017 para config
```

### Error: "Cannot load Form Designer"
```
Solución:
1. Cerrar Visual Studio
2. Eliminar carpeta obj/: rm -r obj
3. Limpiar: dotnet clean
4. Reabrir VS
```

---

## 📚 DOCUMENTACIÓN DE REFERENCIA

| Documento | Cuándo Leer | Propósito |
|-----------|-----------|----------|
| spec.md | Antes de T001 | Entender requisitos |
| data-model.md | Antes de T007 | Entender estructura BD |
| tasks.md | Durante T001 | Seguir tareas exactas |
| testing.md | Antes de T025 | Entender testing strategy |
| risks.md | Durante planning | Mitigar riesgos |
| dependencies.md | Durante planning | Entender dependencies |

---

## 💡 TIPS PARA ÉXITO

### Tip 1: Seguir Tasks.md al pie de la letra
```
- No saltarse tareas
- Completar en orden
- Unit tests DESPUÉS de cada task
```

### Tip 2: Usar Git/Version Control
```powershell
# Crear branches por task
git checkout -b T001-create-structure
# Commit después de completar
git commit -m "T001: Create project structure"
# Merge a main después que tests pasen
```

### Tip 3: Code Reviews
```
- Después de cada task, pedir revisión
- Especialmente: T007-T020 (Models & Data)
- Asegurar adherencia a constitution.md
```

### Tip 4: Testing desde el inicio
```
- No esperar a Phase 10
- Test después de cada función
- Target: 75% coverage
```

---

## 🎯 HITOS IMPORTANTES

```
✅ MILESTONE 1: Phase 2 Complete (22h)
   - All models working
   - DB fully operational
   - Repository pattern implemented
   - Services framework ready
   - Tests: 100% pass on Phase 2 tests

✅ MILESTONE 2: Auth Complete (38h)
   - Login form working
   - User authentication done
   - Role-based access working

✅ MILESTONE 3: Core Data Ready (60h)
   - Patient CRUD working
   - Doctor CRUD working
   - All validations working

✅ MILESTONE 4: MVP Complete (100h)
   - All 7 user stories implemented
   - 80+ tests passing
   - E2E workflows functional
```

---

## 📞 OBTENER AYUDA

Si algo no funciona:

1. **Verificar tasks.md** (solución más probable)
2. **Buscar en Troubleshooting** (arriba en esta guía)
3. **Revisar quickstart.md** (instalación detallada)
4. **Google el error exacto** (StackOverflow)
5. **Code review** (pedir otra opinión)

---

## ✨ PRÓXIMO PASO

```
🟢 Completar Checklist de Setup (arriba)
🟢 Leer PLAN_RESUMEN.md + spec.md
🟢 Ejecutar scripts de BD (3 scripts)
🟢 Abrir proyecto en Visual Studio
🟢 Empezar Task T001 de tasks.md

↓

¡FELICIDADES! Listo para la implementación
```

---

**Tiempo Total Setup**: < 1 hora  
**Status**: 🟢 Ready to Dev  
**Siguiente**: Abrir tasks.md y comenzar T001

---

*Generado: 5 de Diciembre de 2025*  
*Versión: 1.0.0*
