# 🔐 CREDENCIALES - CLINICA SAN MANOTAS

**Fecha:** 5 de diciembre de 2025  
**Status:** ✅ **LOGIN FUNCIONAL**

---

## 👤 ADMIN (Acceso Total)

```
╔════════════════════════════════════════╗
║       CREDENCIALES DE ADMIN            ║
╠════════════════════════════════════════╣
║ Usuario:     admin                     ║
║ Contraseña:  admin123                  ║
║ Email:       admin@clinicamanotas.com  ║
║ Rol:         Admin                     ║
║ Estado:      Activo                    ║
╚════════════════════════════════════════╝
```

**Acceso a:**
- ✅ Gestionar Pacientes (CRUD)
- ✅ Gestionar Médicos
- ✅ Gestionar Citas
- ✅ Administrar Usuarios
- ✅ Especialidades
- ✅ Reportes

---

## 👥 RECEPCIONISTA

```
Usuario:     recepcionista1
Contraseña:  recep123

O también:

Usuario:     recepcionista2
Contraseña:  recep123
```

**Acceso a:**
- ✅ Gestionar Pacientes
- ✅ Gestionar Citas
- ❌ NO puede: Usuarios, Médicos, Especialidades, Reportes

---

## 🩺 DOCTOR

```
Usuario:     dr_garcia
Contraseña:  doctor123

O también:

Usuario:     dr_martinez
Contraseña:  doctor123
```

**Acceso a:**
- ✅ Mis Citas
- ✅ Mis Pacientes

---

## 🚀 CÓMO INICIAR

### 1. Base de Datos
```sql
-- Ejecutar estos scripts en MySQL (en orden):
01-create-database.sql
02-insert-initial-data.sql
03-stored-procedures.sql
```

### 2. Compilar
```
Visual Studio → Ctrl + Shift + B (Build Solution)
```

### 3. Ejecutar
```
Visual Studio → F5 (Debug)
```

### 4. Login
```
Usuario:     admin
Contraseña:  admin123
```

### 5. ¡Listo!
Ya puedes explorar la aplicación.

---

## 🔐 SEGURIDAD

- ✅ Hash SHA256 de contraseñas
- ✅ Validación en múltiples capas
- ✅ Control de acceso por rol
- ✅ Logging de auditoría
- ✅ Soft delete (no elimina datos)

---

## 📊 ESTADÍSTICAS

- **Archivos Creados:** 40+
- **Líneas de Código:** ~6,500
- **Líneas de Documentación:** ~2,500
- **Formularios Completos:** 5
- **Formularios Stub:** 5
- **Usuarios de Prueba:** 6

---

## ✅ CHECKLIST

- ✅ Backend completado
- ✅ UI formularios creados
- ✅ Login funcional
- ✅ Base de datos configurada
- ✅ Credenciales de prueba listos
- ✅ Documentación completa
- ✅ Conexión a BD actualizada

---

## 📞 SOPORTE

Si el login no funciona:

1. **Verifica MySQL corriendo**
   ```
   mysql -u root -p12345
   ```

2. **Verifica scripts ejecutados**
   ```sql
   USE clinica_san_manotas;
   SELECT * FROM Usuario;
   ```

3. **Revisa logs**
   ```
   Carpeta: logs/
   Archivo: [fecha].txt
   ```

---

**¡LISTO PARA USAR!** 🎉

Admin: `admin` / `admin123`
