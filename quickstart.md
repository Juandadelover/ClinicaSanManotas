# CLINICA SAN MANOTAS - Quickstart Guide

**Versión**: 1.0.0 | **Fecha**: 2025-12-05

Guía rápida para configurar y ejecutar la aplicación CLINICA SAN MANOTAS por primera vez.

---

## 📋 Tabla de Contenidos

1. [Requisitos Previos](#requisitos-previos)
2. [Instalación de Base de Datos](#instalación-de-base-de-datos)
3. [Configuración de la Aplicación](#configuración-de-la-aplicación)
4. [Primer Inicio](#primer-inicio)
5. [Usuarios de Prueba](#usuarios-de-prueba)
6. [Troubleshooting](#troubleshooting)

---

## ✅ Requisitos Previos

Antes de comenzar, asegúrate de tener instalado:

### Software Requerido

- ✓ **Windows 10/11** (o superior)
- ✓ **.NET 8 SDK** o Runtime ([descargar](https://dotnet.microsoft.com/es-es/download/dotnet/8.0))
- ✓ **MySQL Server 8.0+** ([descargar](https://dev.mysql.com/downloads/mysql/))
- ✓ **Visual Studio 2022** o **VS Code** con extensión C# (opcional, para desarrollo)
- ✓ **Git** (opcional, para clonar repositorio)

### Verificar Instalación

```powershell
# Verificar .NET
dotnet --version

# Verificar MySQL está ejecutándose
mysql --version

# Conectar a MySQL
mysql -u root -p
# Escribir: SELECT VERSION();
# Debe mostrar versión 8.0+
```

---

## 🗄️ Instalación de Base de Datos

### Paso 1: Ubicar Scripts de Base de Datos

Los scripts SQL están en:
```
CLINICA_SAN_MANOTAS/database/scripts/
├── 01-create-database.sql
├── 02-insert-initial-data.sql
├── 03-stored-procedures.sql
└── README-DATABASE.md
```

### Paso 2: Ejecutar Scripts

#### Opción A: MySQL Workbench (Recomendado para Principiantes)

1. **Abrir MySQL Workbench**

2. **Crear conexión si no existe**
   - Click en "+" para nueva conexión
   - Nombre: "ClinicaManotas"
   - Hostname: `localhost`
   - Port: `3306`
   - Username: `root`
   - Click "OK"

3. **Ejecutar Script 1: Crear Base de Datos**
   ```
   - File → Open SQL Script → 01-create-database.sql
   - Click Execute (⚡ o Ctrl+Shift+Enter)
   - Esperar a que termine
   ```

4. **Ejecutar Script 2: Datos Iniciales**
   ```
   - File → Open SQL Script → 02-insert-initial-data.sql
   - Click Execute
   - Esperar a que termine
   ```

5. **Ejecutar Script 3: Procedimientos Almacenados**
   ```
   - File → Open SQL Script → 03-stored-procedures.sql
   - Click Execute
   - Esperar a que termine
   ```

6. **Verificar Instalación**
   ```sql
   USE clinica_san_manotas;
   SELECT COUNT(*) as TablesCreated FROM information_schema.tables 
   WHERE table_schema = 'clinica_san_manotas';
   -- Debe mostrar: 8
   ```

#### Opción B: Línea de Comandos PowerShell

```powershell
# Navegar al directorio de scripts
cd "C:\ruta\a\CLINICA_SAN_MANOTAS\database\scripts"

# Ejecutar script 1
mysql -u root -p < 01-create-database.sql

# Ejecutar script 2
mysql -u root -p < 02-insert-initial-data.sql

# Ejecutar script 3
mysql -u root -p < 03-stored-procedures.sql

# Ingresar contraseña cuando se solicite
```

### Paso 3: Verificar Base de Datos

Ejecutar en MySQL Workbench o línea de comandos:

```sql
-- Conectarse a la BD
USE clinica_san_manotas;

-- Ver todas las tablas
SHOW TABLES;

-- Contar registros iniciales
SELECT 'Usuarios' as Tabla, COUNT(*) as Registros FROM Usuario
UNION ALL
SELECT 'Especialidades', COUNT(*) FROM Especialidad
UNION ALL
SELECT 'EPS', COUNT(*) FROM EPS
UNION ALL
SELECT 'Médicos', COUNT(*) FROM Medico
UNION ALL
SELECT 'Pacientes', COUNT(*) FROM Paciente
UNION ALL
SELECT 'Citas', COUNT(*) FROM Cita;
```

Resultado esperado:
```
Usuarios       | 5
Especialidades | 10
EPS            | 8
Médicos        | 8
Pacientes      | 10
Citas          | 10
```

---

## ⚙️ Configuración de la Aplicación

### Paso 1: Abrir Proyecto en Visual Studio

1. Abrir Visual Studio 2022
2. File → Open → Project/Solution
3. Seleccionar: `CLINICA_SAN_MANOTAS.sln`
4. Esperar a que cargue (puede tomar 1-2 minutos)

### Paso 2: Verificar .NET Framework

1. En Solution Explorer, click derecho en proyecto
2. Properties → Target Framework
3. Debe estar en: `.NET 8.0` o superior
4. Si no, cambiar a .NET 8.0

### Paso 3: Instalar Dependencias NuGet

Las dependencias necesarias se instalarán automáticamente:

```
Abrir: Tools → NuGet Package Manager → Package Manager Console

Ejecutar:
dotnet restore
```

O automáticamente al compilar (Build → Build Solution).

**Paquetes que se instalarán**:
- Entity Framework Core 8
- Entity Framework Core MySql
- BCrypt.Net-Next (seguridad)
- Serilog (logging)

### Paso 4: Configurar Cadena de Conexión

1. **Abrir archivo**: `appsettings.json` en la raíz del proyecto

2. **Verificar/Actualizar conexión**:
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=localhost;Database=clinica_san_manotas;User Id=root;Password=tu_contraseña;SslMode=none;"
     }
   }
   ```

3. **Reemplazar `tu_contraseña`** con contraseña de MySQL root

4. **Guardar archivo** (Ctrl+S)

### Paso 5: Compilar Proyecto

```powershell
# En Package Manager Console o PowerShell
cd "C:\ruta\a\CLINICA_SAN_MANOTAS"

# Compilar
dotnet build

# Esperar a que compile sin errores
```

Si hay errores, ejecutar:
```powershell
dotnet restore
dotnet build
```

---

## 🚀 Primer Inicio

### Opción A: Desde Visual Studio

1. **Asegurarse que proyecto está compilado**
   - Build → Build Solution (debe completarse sin errores)

2. **Establecer proyecto como startup**
   - Click derecho en `CLINICA_SAN_MANOTAS`
   - "Set as Startup Project"

3. **Ejecutar aplicación**
   - Press F5 o Debug → Start Debugging
   - Alternativa: Press Ctrl+F5 (sin debugging)

4. **Esperar a que abra la aplicación**
   - Primer inicio puede tomar 15-30 segundos
   - Se abrirá formulario de login

### Opción B: Desde Línea de Comandos

```powershell
# Navegar al proyecto
cd "C:\ruta\a\CLINICA_SAN_MANOTAS"

# Ejecutar
dotnet run

# O compilar y ejecutar .exe
dotnet publish -c Release
cd bin/Release/net8.0
CLINICA_SAN_MANOTAS.exe
```

---

## 👤 Usuarios de Prueba

Una vez abra la aplicación, usar estos usuarios para acceder:

### Admin
```
Usuario: admin
Contraseña: admin123
Rol: Administrador (acceso completo)
```

### Recepcionista
```
Usuario: recepcionista1
Contraseña: recep123
Rol: Recepcionista (gestión de citas y pacientes)
```

### Doctor
```
Usuario: dr_garcia
Contraseña: doctor123
Rol: Doctor (consulta de horarios y pacientes)
```

### Credenciales MySQL
```
Usuario: root
Contraseña: (la que estableciste en instalación de MySQL)
Base de Datos: clinica_san_manotas
```

---

## 🧪 Pruebas Iniciales

Después de login exitoso, probar lo siguiente:

### 1. Gestión de Pacientes
- [ ] Crear nuevo paciente
- [ ] Visualizar lista de pacientes
- [ ] Editar paciente
- [ ] Buscar por nombre o documento

### 2. Gestión de Citas
- [ ] Agendar cita
- [ ] Ver citas por médico
- [ ] Confirmar cita
- [ ] Cancelar cita

### 3. Filtros
- [ ] Buscar médicos por especialidad
- [ ] Filtrar pacientes por EPS
- [ ] Filtrar citas por estado
- [ ] Ver citas por fecha

### 4. Cambio de Idioma
- [ ] Cambiar interfaz a Inglés
- [ ] Verificar que todos los textos cambien
- [ ] Volver a Español

### 5. Seguridad
- [ ] Cambiar contraseña propia
- [ ] Logout y login de nuevo
- [ ] Intentar acceder sin credenciales (debe rechazar)

---

## 📁 Estructura de Archivos

```
CLINICA_SAN_MANOTAS/
├── CLINICA_SAN_MANOTAS.csproj         # Configuración del proyecto
├── CLINICA_SAN_MANOTAS.sln            # Solución de Visual Studio
├── Program.cs                          # Punto de entrada
├── Form1.cs / Form1.Designer.cs       # Formularios iniciales
├── appsettings.json                   # Configuración (incluir contraseña)
├── appsettings.Development.json       # Config de desarrollo
│
├── Core/
│   ├── Models/                        # Entidades (Usuario, Paciente, etc)
│   ├── Enums/                         # Enumeraciones
│   └── Constants/                     # Constantes
│
├── Data/
│   ├── Context/                       # ClinicaContext (DbContext)
│   ├── Repositories/                  # Patrón Repository
│   └── UnitOfWork/                    # Patrón UnitOfWork
│
├── Services/
│   ├── Authentication/                # Login y autenticación
│   ├── Patient/                       # Lógica de pacientes
│   ├── Doctor/                        # Lógica de médicos
│   ├── Appointment/                   # Lógica de citas
│   ├── Email/                         # Servicio de correo
│   └── Localization/                  # Cambio de idioma
│
├── UI/
│   ├── Forms/                         # Todos los formularios WinForms
│   └── Controls/                      # Controles personalizados
│
├── Resources/
│   ├── es.resx                        # Strings español
│   └── en.resx                        # Strings inglés
│
├── database/
│   ├── scripts/
│   │   ├── 01-create-database.sql
│   │   ├── 02-insert-initial-data.sql
│   │   ├── 03-stored-procedures.sql
│   │   └── README-DATABASE.md
│   └── migrations/                    # Entity Framework Migrations
│
├── specs/master/
│   ├── spec.md                        # Especificación de características
│   ├── data-model.md                  # Modelo de datos
│   ├── plan.md                        # Plan de implementación
│   └── research.md                    # Investigación técnica
│
└── .gitignore
```

---

## 🔍 Troubleshooting

### Error: "Cannot connect to MySQL server"

**Causas posibles**:
- MySQL no está ejecutándose
- Contraseña incorrecta en appsettings.json
- Puerto 3306 está bloqueado

**Solución**:
```powershell
# 1. Verificar si MySQL está ejecutándose
Get-Service | Where-Object {$_.Name -like "*MySQL*"}

# 2. Si no está, iniciar servicio
Start-Service MySQL80  # Ajustar número según versión

# 3. Verificar conexión
mysql -u root -p
# Si entra, la conexión está bien

# 4. Revisar appsettings.json
# Verificar Password sea correcta
```

### Error: "Database does not exist"

**Causas posibles**:
- Scripts de BD no se ejecutaron correctamente
- Base de datos se eliminó accidentalmente

**Solución**:
```powershell
# 1. Verificar que BD existe
mysql -u root -p
> SHOW DATABASES;
> USE clinica_san_manotas;  # Debe funcionar

# 2. Si no existe, ejecutar scripts nuevamente
# Ver sección "Instalación de Base de Datos" arriba
```

### Error: ".NET Framework not found"

**Solución**:
```powershell
# 1. Descargar e instalar .NET 8
# https://dotnet.microsoft.com/es-es/download/dotnet/8.0

# 2. Reiniciar Visual Studio

# 3. Verificar instalación
dotnet --list-sdks
# Debe mostrar versión 8.0.x
```

### Error: "NuGet packages not restored"

**Solución**:
```powershell
# En Package Manager Console de Visual Studio
Update-Package

# O en PowerShell
cd "C:\ruta\a\CLINICA_SAN_MANOTAS"
dotnet restore
```

### Aplicación se abre pero cierra inmediatamente

**Causas posibles**:
- Excepción no capturada en Program.cs
- Error en DbContext

**Solución**:
```powershell
# Ejecutar en modo debug
dotnet run
# Revisar mensajes de error en consola

# Si hay error en BD, verificar:
# 1. Cadena de conexión en appsettings.json
# 2. Que BD existe: mysql -u root -p > SHOW DATABASES;
# 3. Que usuario root tiene permisos correctos
```

---

## 📞 Soporte Adicional

### Contactos
- **Instructor**: Wilmer Manotas
- **Email**: [instrucción completada]

### Recursos Útiles
- [Documentación .NET 8](https://docs.microsoft.com/es-es/dotnet/core/)
- [Entity Framework Core](https://docs.microsoft.com/es-es/ef/core/)
- [Documentación MySQL](https://dev.mysql.com/doc/)
- [Foros de Microsoft Learn](https://learn.microsoft.com/)

### Commits Importantes
```powershell
git log --oneline
# Muestra historial de cambios
```

---

## ✨ Próximos Pasos

Una vez tengas la aplicación ejecutándose:

1. **Familiarizarse con la UI**
   - Crear pacientes de prueba
   - Agendar citas
   - Explorar filtros

2. **Revisar Código Fuente**
   - Estudiar estructura de capas
   - Entender patrón Repository
   - Revisar validaciones

3. **Extender Funcionalidad**
   - Agregar nuevos campos
   - Crear nuevos reportes
   - Mejorar validaciones

4. **Testing**
   - Escribir unit tests
   - Probar casos de error
   - Validar datos extremos

---

**¡Listo para comenzar!** 🎉

Si encuentras problemas, revisa esta guía o contacta al instructor.

**Última actualización**: 2025-12-05  
**Versión**: 1.0.0
