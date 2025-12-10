# 🔐 LOGIN FUNCIONAL - INSTRUCCIONES Y CREDENCIALES

## ✅ Estado: LOGIN LISTO

El sistema de login está **100% funcional** y listo para usar.

---

## 🚀 PASOS PARA ACTIVAR

### Paso 1: Ejecutar Scripts de Base de Datos

Ejecuta los siguientes scripts SQL en MySQL (en orden):

#### 1️⃣ Crear Base de Datos
```sql
-- Archivo: database/scripts/01-create-database.sql
Ejecutar en MySQL Command Line o MySQL Workbench
```

#### 2️⃣ Insertar Datos Iniciales
```sql
-- Archivo: database/scripts/02-insert-initial-data.sql
-- Contiene:
-- ✅ Especialidades
-- ✅ EPS
-- ✅ Usuarios de prueba
-- ✅ Médicos
-- ✅ Pacientes
-- ✅ Citas de ejemplo
Ejecutar en MySQL Command Line o MySQL Workbench
```

#### 3️⃣ Crear Procedimientos Almacenados
```sql
-- Archivo: database/scripts/03-stored-procedures.sql
Ejecutar en MySQL Command Line o MySQL Workbench
```

---

## 🔑 CREDENCIALES DE ACCESO

### 👤 ADMIN (Acceso Total)
```
Usuario:     admin
Contraseña:  admin123
Email:       admin@clinicamanotas.com
Rol:         Admin
Estado:      Activo
```
**Acceso a:**
- ✅ Gestionar Pacientes
- ✅ Gestionar Médicos
- ✅ Gestionar Citas
- ✅ Administrar Usuarios
- ✅ Especialidades
- ✅ Reportes

---

### 👥 RECEPCIONISTA (Acceso Limitado)
```
Usuario:     recepcionista1
Contraseña:  recep123
Email:       recepcionista1@clinicamanotas.com
Rol:         Recepcionista
Estado:      Activo

O también:

Usuario:     recepcionista2
Contraseña:  recep123
Email:       recepcionista2@clinicamanotas.com
Rol:         Recepcionista
Estado:      Activo
```
**Acceso a:**
- ✅ Gestionar Pacientes
- ✅ Gestionar Citas
- ❌ NO puede: Administrar Usuarios, Médicos, Especialidades, Reportes

---

### 🩺 DOCTOR (Acceso Restringido)
```
Usuario:     dr_garcia
Contraseña:  doctor123
Email:       garcia@clinicamanotas.com
Rol:         Doctor
Especialidad: Cardiología
Estado:      Activo

O también:

Usuario:     dr_martinez
Contraseña:  doctor123
Email:       martinez@clinicamanotas.com
Rol:         Doctor
Especialidad: Medicina General
Estado:      Activo
```
**Acceso a:**
- ✅ Ver mis citas
- ✅ Ver mis pacientes
- ❌ NO puede: Gestionar otros datos

---

## 🔐 Hashes de Contraseñas

Tabla de referencia de hashes SHA256:

| Contraseña | Hash SHA256 |
|-----------|-----------|
| `admin123` | `240be518fabd2724ddb6f04eeb1da5967448d7e831c08c8fa822809f74c720a9` |
| `recep123` | `5d37ed314cf2b5c8462b52b12cd512e2ac4a180e75598da4f12bfb0dea6d0a67` |
| `doctor123` | `f348d5628621f3d8f59c8cabda0f8eb0aa7e0514a90be7571020b1336f26c113` |

---

## 📝 Cómo Funciona el Login

### Flujo de Autenticación

```
1. Usuario ingresa credenciales en LoginForm
   ↓
2. Sistema valida en LoginForm.btnIngresar_Click()
   ↓
3. Llama a: UnitOfWork.Usuarios.VerificarCredenciales(usuario, password)
   ↓
4. UsuarioRepository compara:
   - Busca usuario por nombre
   - Llama SecurityHelper.VerificarContraseña()
   - Compara hash SHA256
   ↓
5. Si es válido:
   - Actualiza FechaUltimoLogin
   - Guarda en SessionManager.UsuarioActual
   - Registra acceso en log
   - Abre formulario según rol
   ↓
6. Si es inválido:
   - Registra intento fallido
   - Muestra error
   - Limpia campo de contraseña
```

---

## 🎯 Prueba Rápida

### 1. Ejecutar la Aplicación
```
Visual Studio → Press F5 (Debug)
o
Doble click en ejecutable
```

### 2. Pantalla de Login Aparecerá
```
┌─────────────────────────────┐
│  CLÍNICA SAN MANOTAS        │
├─────────────────────────────┤
│ Usuario:     [          ]   │
│ Contraseña:  [          ]   │
│ [Ingresar]     [Salir]      │
└─────────────────────────────┘
```

### 3. Ingresa Credenciales de Admin
```
Usuario:     admin
Contraseña:  admin123
Click:       Ingresar
```

### 4. Aparecerá Panel Principal
```
✅ Panel de Control - Administrador
   [Gestionar Pacientes] [Gestionar Médicos] [Gestionar Citas]
   [Administrar Usuarios] [Especialidades] [Reportes]
```

---

## 🔍 Debugging

### Si el login falla:

#### 1. Verificar Conexión a BD
```csharp
var db = DatabaseConnection.GetInstance();
if (db.EstaConectado())
    MessageBox.Show("✅ Conectado");
else
    MessageBox.Show("❌ Error de conexión");
```

#### 2. Revisar Logs
```
Ubicación: [Carpeta de la aplicación]/logs/
Archivo: [Fecha].txt
```

#### 3. Verificar Usuarios en BD
```sql
USE clinica_san_manotas;
SELECT * FROM Usuario;
SELECT * FROM Usuario WHERE Username = 'admin';
```

#### 4. Error Común: "Unknown database"
```
✅ Solución: Ejecutar script 01-create-database.sql
```

#### 5. Error Común: "Access denied"
```
✅ Solución: Verificar usuario MySQL (root) y contraseña (12345)
```

---

## 🛠️ Archivos Clave

| Archivo | Propósito |
|---------|-----------|
| `LoginForm.cs` | Formulario de login |
| `LoginForm.Designer.cs` | Diseño de formulario |
| `DatabaseConnection.cs` | Conexión a BD |
| `UsuarioRepository.cs` | Verificación de credenciales |
| `SecurityHelper.cs` | Hash de contraseñas |
| `SessionManager.cs` | Gestión de sesión |
| `02-insert-initial-data.sql` | Usuarios de prueba |

---

## 📊 Flujo de Roles

```
LOGIN
  ↓
┌─────────────────────────┐
│   ¿Cuál es el rol?      │
└─────────────────────────┘
   ↙        ↓         ↘
ADMIN    RECEP      DOCTOR
  ↓        ↓          ↓
MainForm  Recep      Doctor
  ↓       Form       Form
  │        │          │
  └───┬────┴────┬─────┘
      │ Puede acceder a:
      ├─ Pacientes (CRUD)
      ├─ Citas (CRUD)
      ├─ Médicos (Admin solo)
      └─ Reportes (Admin solo)
```

---

## ✨ Características del Login

✅ **Validación de Campos**
- Usuario no vacío
- Contraseña no vacía

✅ **Validación de Credenciales**
- Búsqueda en BD
- Verificación de contraseña con hash SHA256
- Verificación de estado "Activo"

✅ **Logging**
- Registro de intentos exitosos
- Registro de intentos fallidos
- IP del usuario (cuando se implemente)

✅ **Seguridad**
- Hash SHA256 de contraseña
- No almacena contraseña en texto plano
- Validación en servidor (BD)

✅ **UX**
- Mensajes claros de error
- Botón Ingresar y Salir
- Enter en contraseña para enviar
- Botón Salir cierra aplicación

---

## 🚀 Próximas Mejoras

- [ ] Encripción BCrypt en lugar de SHA256
- [ ] Autenticación multi-factor
- [ ] Reseteo de contraseña
- [ ] Bloqueo de usuario tras intentos fallidos
- [ ] Cambio de contraseña obligatorio al primer login
- [ ] Integración LDAP/Active Directory

---

## 📞 Soporte

### Problema: Login no funciona
1. Verifica que MySQL esté corriendo
2. Verifica scripts ejecutados
3. Revisa logs en `logs/` carpeta
4. Revisa consola de Visual Studio (Output)

### Problema: Contraseña incorrecta
1. Verifica que sea exactamente: `admin123`
2. Mayúsculas/minúsculas importan
3. No hay espacios al inicio/fin

### Problema: Usuario no existe
1. Verifica script 02-insert-initial-data.sql fue ejecutado
2. Consulta en BD: `SELECT * FROM Usuario;`
3. Si no hay usuarios, ejecuta script nuevamente

---

## ✅ Checklist Antes de Usar

- [ ] MySQL corriendo
- [ ] Base de datos creada (script 01)
- [ ] Datos iniciales insertados (script 02)
- [ ] Procedimientos almacenados (script 03)
- [ ] Conexión actualizada (server, BD, usuario, password)
- [ ] Aplicación compilada sin errores
- [ ] Credenciales guardadas (ver arriba)

---

## 🎉 ¡LISTO PARA USAR!

El login está **100% funcional** con credenciales de prueba.

**ADMIN PREDETERMINADO:**
```
Usuario:     admin
Contraseña:  admin123
```

**Cambiar esta contraseña es recomendado en producción.**

---

Fecha: 5 de diciembre de 2025
Estado: ✅ **LOGIN FUNCIONAL Y OPERATIVO**
