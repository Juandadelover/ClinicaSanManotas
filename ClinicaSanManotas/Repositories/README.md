# Repository Pattern & Unit of Work Implementation

## Descripción

Esta carpeta contiene la implementación del patrón Repository y Unit of Work para CLINICA SAN MANOTAS.

## Archivos

### 1. **IRepository.cs**
Define las interfaces genéricas y específicas para acceso a datos.

**Interfaces Genéricas:**
- `IRepository<T>` - Contrato base para todos los repositorios

**Interfaces Específicas:**
- `IUsuarioRepository` - Acceso a usuarios
- `IPacienteRepository` - Acceso a pacientes
- `IMedicoRepository` - Acceso a médicos
- `ICitaRepository` - Acceso a citas
- `IEspecialidadRepository` - Acceso a especialidades
- `IEPSRepository` - Acceso a EPS
- `IAuditLogRepository` - Acceso a auditoría

### 2. **Repository.cs**
Implementación genérica base del patrón Repository.

Métodos disponibles:
```csharp
GetAll()                    // Obtiene todas las entidades activas
GetAllPaged()              // Obtiene con paginación
GetById()                  // Obtiene por ID
Find()                     // Búsqueda con predicado
Add()                      // Agregar nueva entidad
AddRange()                 // Agregar múltiples
Update()                   // Actualizar
Remove()                   // Eliminar (soft delete)
RemoveRange()              // Eliminar múltiples
Count()                    // Contar total
Count(predicate)           // Contar con condición
Any()                      // Verificar existencia
```

### 3. **UsuarioRepository.cs**
Implementación específica para Usuario.

Métodos adicionales:
```csharp
GetByUsername()            // Obtener por nombre de usuario
GetByEmail()               // Obtener por email
VerificarCredenciales()    // Verificar login
ActualizarUltimoLogin()    // Registrar último acceso
```

**Características:**
- Hash de contraseñas automático
- Validación de datos
- Logging de accesos
- Soft delete

### 4. **UnitOfWork.cs**
Implementación del patrón Unit of Work para transacciones.

Contiene:
- Interfaz `IUnitOfWork`
- Clase `UnitOfWork`
- Repositorio `MedicoRepository`
- Repositorio `CitaRepository`
- Repositorio `EspecialidadRepository`
- Repositorio `EPSRepository`
- Repositorio `AuditLogRepository`

**Métodos:**
```csharp
BeginTransaction()         // Inicia transacción
SaveChanges()              // Guarda cambios
CommitTransaction()        // Confirma transacción
RollbackTransaction()      // Revierte transacción
Dispose()                  // Libera recursos
```

**Uso:**
```csharp
using (var unitOfWork = new UnitOfWork())
{
    unitOfWork.BeginTransaction();
    try
    {
        // Operaciones
        var usuario = new Usuario { ... };
        unitOfWork.Usuarios.Add(usuario);
        
        var paciente = new Paciente { ... };
        unitOfWork.Pacientes.Add(paciente);
        
        unitOfWork.CommitTransaction();
    }
    catch
    {
        unitOfWork.RollbackTransaction();
        throw;
    }
}
```

## Patrones Implementados

### Repository Pattern
Abstrae la lógica de acceso a datos. Beneficios:
- Centralización de queries
- Facilita testing (mock repositories)
- Reusable en múltiples servicios
- Fácil de cambiar de BD

### Unit of Work Pattern
Gestiona múltiples repositorios como una unidad. Beneficios:
- Transacciones ACID
- Consistencia de datos
- Coordina múltiples operaciones
- Gestión de recursos

## Características de Seguridad

### Contraseñas
- Hash SHA256 (educativo)
- En producción: BCrypt.Net-Next
- Nunca se almacenan en texto plano
- Validación de fortaleza

### SQL Injection Prevention
- Uso de parámetros parametrizados
- Validación de entrada
- Limpieza de datos

### Auditoría
- Registro de todas las operaciones
- Tracking de cambios
- IP del usuario
- User Agent

## Búsquedas Disponibles

### Usuario
```csharp
repo.GetById(id)                   // Por ID
repo.GetByUsername(username)       // Por nombre
repo.GetByEmail(email)             // Por email
repo.VerificarCredenciales()       // Verificar login
```

### Paciente
```csharp
repo.GetById(id)                   // Por ID
repo.GetByDocumento(doc)           // Por documento
repo.BuscarPorNombre(nombre)       // Búsqueda por nombre
repo.BuscarPorEPS(epsId)           // Por EPS
repo.BuscarPorEdad(min, max)       // Rango de edad
```

### Médico
```csharp
repo.GetById(id)                   // Por ID
repo.GetByLicencia(lic)            // Por licencia
repo.GetByEspecialidad(espId)      // Por especialidad
repo.GetDisponibles(fecha, hora)   // Disponibles en fecha/hora
repo.EstaDisponible(medId, f, h)   // Verificar disponibilidad
```

### Cita
```csharp
repo.GetById(id)                   // Por ID
repo.GetByPaciente(pacId)          // De un paciente
repo.GetByMedico(medId)            // De un médico
repo.GetByFecha(fecha)             // Por fecha
repo.GetByEstado(estado)           // Por estado
repo.GetProximas(dias)             // Próximas N días
```

## Ejemplo de Uso

```csharp
// Autenticación
using (var uow = new UnitOfWork())
{
    if (uow.Usuarios.VerificarCredenciales("admin", "password123"))
    {
        var usuario = uow.Usuarios.GetByUsername("admin");
        uow.Usuarios.ActualizarUltimoLogin(usuario.UserId);
    }
}

// CRUD de Paciente
using (var uow = new UnitOfWork())
{
    // Create
    var paciente = new Paciente 
    { 
        Nombres = "Juan",
        Apellidos = "Pérez",
        Documento = "1234567890",
        EPSId = 1
    };
    uow.Pacientes.Add(paciente);
    
    // Read
    var pac = uow.Pacientes.GetByDocumento("1234567890");
    
    // Update
    pac.Telefono = "3001234567";
    uow.Pacientes.Update(pac);
    
    // Delete
    uow.Pacientes.Remove(pac);
}

// Búsqueda avanzada
using (var uow = new UnitOfWork())
{
    var resultados = uow.Pacientes.BuscarPorNombre("Juan", pageNumber: 1, pageSize: 10);
    foreach (var p in resultados)
    {
        Console.WriteLine($"{p.Nombres} {p.Apellidos}");
    }
}

// Transacción
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
    catch (Exception ex)
    {
        uow.RollbackTransaction();
        throw;
    }
}
```

## Consideraciones de Rendimiento

1. **Paginación**: Siempre usar paginación en listas grandes
   ```csharp
   repo.GetAll(pageNumber: 1, pageSize: 10)
   ```

2. **Índices**: Database tiene índices en campos frecuentes
   - Username, Email en Usuario
   - Documento en Paciente
   - Licencia en Médico
   - MedicoId, Fecha, Estado en Cita

3. **Caché**: Datos de referencia (EPS, Especialidades) son candidatos para caché

4. **Lazy Loading**: Deshabilitado para mejor control

## Testing

Los interfaces permiten mockear fácilmente:

```csharp
[TestClass]
public class UsuarioServiceTests
{
    [TestMethod]
    public void LoginTest()
    {
        // Mock
        var mockRepo = new Mock<IUsuarioRepository>();
        mockRepo.Setup(r => r.VerificarCredenciales("admin", "pass"))
                .Returns(true);
        
        // Test
        var service = new AuthService(mockRepo.Object);
        var resultado = service.Login("admin", "pass");
        
        Assert.IsTrue(resultado);
    }
}
```

## Roadmap

- [ ] Implementar caché de datos de referencia
- [ ] Agregar async/await en todas las operaciones
- [ ] Implementar especificaciones (Specification Pattern)
- [ ] Agregar Entity Framework como alternativa a ADO.NET
- [ ] Implementar soft delete centralizado
- [ ] Agregar versionado optimista

## Referencias

- Repository Pattern: https://docs.microsoft.com/en-us/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/infrastructure-persistence-layer-design
- Unit of Work: https://martinfowler.com/eaaCatalog/unitOfWork.html
- MySQL Connector/NET: https://dev.mysql.com/doc/connector-net/en/
