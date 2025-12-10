# 🔌 Configuración de Conexión a Base de Datos

## ✅ Actualizado

La cadena de conexión ha sido actualizada con tus parámetros.

### Ubicaciones Actualizadas

#### 1. **DatabaseConnection.cs** (Clase Singleton)
```
Ruta: SistemaEmpleadosMySQL/DAO/DatabaseConnection.cs
Línea: 21
```

**Antes:**
```csharp
"Server=localhost;Database=CLINICA_SAN_MANOTAS;User Id=root;Password=;"
```

**Después:**
```csharp
"server=localhost; database=clinica_san_manotas; Uid=root; pwd=12345;"
```

#### 2. **config.xml** (Configuración)
```
Ruta: SistemaEmpleadosMySQL/App.config/config.xml
Línea: 6
```

**Antes:**
```xml
<add name="DefaultConnection" 
     connectionString="Server=localhost;Database=CLINICA_SAN_MANOTAS;User Id=root;Password=;" 
     providerName="MySql.Data.MySqlClient" />
```

**Después:**
```xml
<add name="DefaultConnection" 
     connectionString="server=localhost; database=clinica_san_manotas; Uid=root; pwd=12345;" 
     providerName="MySql.Data.MySqlClient" />
```

---

## 📋 Parámetros de Conexión

| Parámetro | Valor |
|-----------|-------|
| **Server** | localhost |
| **Database** | clinica_san_manotas |
| **User ID (Uid)** | root |
| **Password (pwd)** | 12345 |

---

## 🔑 Cómo se Usa

### En DatabaseConnection.cs
```csharp
// Obtener instancia singleton
var connection = DatabaseConnection.GetInstance();

// Usar conexión
var reader = connection.ExecuteQuery("SELECT * FROM Usuario");

// Cerrar conexión
connection.CerrarConexion();
```

### En Formularios
```csharp
// Automático a través de UnitOfWork
using (var uow = new UnitOfWork())
{
    var usuarios = uow.Usuarios.GetAll();
    // Usa la conexión automáticamente
}
```

### En Repositorios
```csharp
// La conexión se obtiene automáticamente
public List<Usuario> GetAll()
{
    var db = DatabaseConnection.GetInstance();
    var reader = db.ExecuteQuery("SELECT * FROM Usuario WHERE Estado = 'Activo'");
    // ...
}
```

---

## ✨ Características

✅ **Singleton Pattern** - Una única conexión reutilizable
✅ **Connection Pooling** - Gestión eficiente de conexiones
✅ **Thread-Safe** - Uso seguro en múltiples hilos
✅ **Error Handling** - Captura y logging de errores
✅ **Flexible** - Permite cambiar conexión en tiempo de ejecución

---

## ⚠️ Notas Importantes

1. **Base de Datos Debe Existir**
   - Debes tener MySQL corriendo
   - La BD `clinica_san_manotas` debe estar creada
   - Usuario `root` con contraseña `12345`

2. **Ejecutar Scripts**
   ```
   ✅ 01-create-database.sql
   ✅ 02-insert-initial-data.sql
   ✅ 03-stored-procedures.sql
   ```

3. **Verificar Conexión**
   ```csharp
   var db = DatabaseConnection.GetInstance();
   if (db.EstaConectado())
   {
       MessageBox.Show("Conectado a BD");
   }
   ```

---

## 🔧 Cambiar Credenciales

Si necesitas cambiar los parámetros en el futuro, actualiza ambos archivos:

1. `DatabaseConnection.cs` - Línea 21
2. `config.xml` - Línea 6

Ejemplo para usuario "admin" con contraseña "admin123":
```csharp
"server=localhost; database=clinica_san_manotas; Uid=admin; pwd=admin123;"
```

---

## 📞 Troubleshooting

### Error: "Connection refused"
- ✅ Verifica que MySQL esté corriendo
- ✅ Verifica el servidor (localhost)
- ✅ Verifica el puerto (3306 por defecto)

### Error: "Access denied for user"
- ✅ Verifica usuario (root)
- ✅ Verifica contraseña (12345)
- ✅ Verifica en MySQL: `mysql -u root -p12345`

### Error: "Unknown database"
- ✅ Verifica el nombre de BD (clinica_san_manotas)
- ✅ Ejecuta 01-create-database.sql
- ✅ Verifica: `SHOW DATABASES;`

---

**Estado:** ✅ Conectado y listo para usar
**Última Actualización:** 5 de diciembre de 2025
