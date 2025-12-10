# API Contracts - CLINICA SAN MANOTAS

**Versión**: 1.0.0 | **Fecha**: 2025-12-05

Define la estructura de datos para las operaciones de la aplicación. Estos contratos representan los DTOs (Data Transfer Objects) que se utilizarán entre capas.

---

## 1. Autenticación

### 1.1 Login Request
```json
{
  "username": "string (50 chars max)",
  "password": "string (not sent to DB, only hash)"
}
```

### 1.2 Login Response
```json
{
  "success": "boolean",
  "message": "string",
  "token": "string (session token)",
  "user": {
    "userId": "int",
    "username": "string",
    "email": "string",
    "role": "enum (Admin|Recepcionista|Doctor)",
    "estado": "enum (Activo|Inactivo|Bloqueado)"
  }
}
```

### 1.3 Change Password Request
```json
{
  "userId": "int",
  "currentPassword": "string",
  "newPassword": "string (min 8 chars)",
  "confirmPassword": "string"
}
```

### 1.4 Change Password Response
```json
{
  "success": "boolean",
  "message": "string"
}
```

---

## 2. Gestión de Pacientes

### 2.1 Create Patient Request
```json
{
  "nombres": "string (2-100 chars, required)",
  "apellidos": "string (2-100 chars, required)",
  "email": "string (valid email format, optional)",
  "telefono": "string (required, e.g., +573001234567)",
  "fechaNacimiento": "date (YYYY-MM-DD, required)",
  "genero": "enum (M|F|Otro, required)",
  "documento": "string (unique, required)",
  "epsId": "int (FK, required)",
  "direccion": "string (required)",
  "ciudad": "string (required)"
}
```

### 2.2 Update Patient Request
```json
{
  "pacienteId": "int",
  "nombres": "string",
  "apellidos": "string",
  "email": "string",
  "telefono": "string",
  "fechaNacimiento": "date",
  "genero": "enum",
  "documento": "string",
  "epsId": "int",
  "direccion": "string",
  "ciudad": "string",
  "estado": "enum (Activo|Inactivo|Suspendido)"
}
```

### 2.3 Patient Response
```json
{
  "pacienteId": "int",
  "nombres": "string",
  "apellidos": "string",
  "email": "string",
  "telefono": "string",
  "fechaNacimiento": "date",
  "edad": "int (calculated)",
  "genero": "enum",
  "documento": "string",
  "epsId": "int",
  "epsNombre": "string",
  "direccion": "string",
  "ciudad": "string",
  "estado": "enum",
  "fechaRegistro": "datetime"
}
```

### 2.4 List Patients Response
```json
{
  "success": "boolean",
  "total": "int",
  "page": "int",
  "pageSize": "int",
  "patients": [
    { "...": "Patient Response" }
  ]
}
```

---

## 3. Gestión de Médicos

### 3.1 Create Doctor Request
```json
{
  "nombres": "string (required)",
  "apellidos": "string (required)",
  "email": "string (unique, required)",
  "telefono": "string (required)",
  "licencia": "string (unique, required)",
  "especialidadId": "int (FK, required)",
  "horarioInicio": "time (HH:MM:SS, required)",
  "horarioFin": "time (HH:MM:SS, required, must be > horarioInicio)",
  "diasAtencion": "string (e.g., 'Lunes-Viernes')"
}
```

### 3.2 Update Doctor Request
```json
{
  "medicoId": "int",
  "nombres": "string",
  "apellidos": "string",
  "email": "string",
  "telefono": "string",
  "licencia": "string",
  "especialidadId": "int",
  "horarioInicio": "time",
  "horarioFin": "time",
  "diasAtencion": "string",
  "estado": "enum (Activo|Inactivo|Licencia)"
}
```

### 3.3 Doctor Response
```json
{
  "medicoId": "int",
  "nombres": "string",
  "apellidos": "string",
  "email": "string",
  "telefono": "string",
  "licencia": "string",
  "especialidadId": "int",
  "especialidad": "string",
  "horarioInicio": "time",
  "horarioFin": "time",
  "diasAtencion": "string",
  "estado": "enum",
  "fechaRegistro": "datetime"
}
```

---

## 4. Gestión de Especialidades

### 4.1 Specialty Response
```json
{
  "especialidadId": "int",
  "nombre": "string",
  "descripcion": "string"
}
```

### 4.2 Get All Specialties Response
```json
{
  "specialties": [
    { "...": "Specialty Response" }
  ]
}
```

---

## 5. Gestión de EPS

### 5.1 Create EPS Request
```json
{
  "nombre": "string (unique, required)",
  "nit": "string (unique, required)",
  "telefono": "string (optional)",
  "email": "string (optional)",
  "contacto": "string (optional)"
}
```

### 5.2 EPS Response
```json
{
  "epsId": "int",
  "nombre": "string",
  "nit": "string",
  "telefono": "string",
  "email": "string",
  "contacto": "string",
  "estado": "enum (Activa|Inactiva)",
  "fechaRegistro": "datetime"
}
```

---

## 6. Gestión de Citas

### 6.1 Create Appointment Request
```json
{
  "pacienteId": "int (required)",
  "medicoId": "int (required)",
  "fecha": "date (YYYY-MM-DD, required, >= today)",
  "hora": "time (HH:MM:SS, required, within doctor hours)",
  "motivo": "string (5-500 chars, required)"
}
```

### 6.2 Update Appointment Request
```json
{
  "citaId": "int",
  "fecha": "date",
  "hora": "time",
  "motivo": "string",
  "estado": "enum (Pendiente|Confirmada|Cancelada|Realizada)",
  "notas": "string (post-appointment notes)"
}
```

### 6.3 Appointment Response
```json
{
  "citaId": "int",
  "pacienteId": "int",
  "pacienteNombre": "string",
  "pacienteDocumento": "string",
  "medicoId": "int",
  "medicoNombre": "string",
  "especialidad": "string",
  "fecha": "date",
  "hora": "time",
  "motivo": "string",
  "estado": "enum",
  "notas": "string",
  "fechaCreacion": "datetime",
  "fechaActualizacion": "datetime"
}
```

---

## 7. Búsquedas y Filtros

### 7.1 Search Doctors Request
```json
{
  "searchTerm": "string (optional, name/email/phone)",
  "especialidadId": "int (optional)",
  "estado": "enum (optional)"
}
```

### 7.2 Search Patients Request
```json
{
  "searchTerm": "string (optional)",
  "genero": "enum (optional)",
  "epsId": "int (optional)",
  "edadMin": "int (optional)",
  "edadMax": "int (optional)",
  "page": "int (default: 1)",
  "pageSize": "int (default: 20)"
}
```

### 7.3 Get Appointments by Status Request
```json
{
  "estado": "enum (Pendiente|Confirmada|Cancelada|Realizada)",
  "fechaInicio": "date (optional)",
  "fechaFin": "date (optional)"
}
```

### 7.4 Get Appointments by Date Request
```json
{
  "fecha": "date (YYYY-MM-DD)"
}
```

---

## 8. Gestión de Usuarios

### 8.1 Create User Request
```json
{
  "username": "string (50 chars max, unique, required)",
  "email": "string (unique, required)",
  "password": "string (min 8 chars, required)",
  "role": "enum (Admin|Recepcionista|Doctor, required)"
}
```

### 8.2 User Response
```json
{
  "userId": "int",
  "username": "string",
  "email": "string",
  "role": "enum",
  "estado": "enum",
  "fechaCreacion": "datetime",
  "fechaUltimoLogin": "datetime"
}
```

---

## 9. Respuesta de Error Estándar

Aplicable a todas las operaciones en caso de error:

```json
{
  "success": false,
  "message": "string (error description)",
  "errorCode": "string (e.g., VALIDATION_ERROR, DB_ERROR, AUTH_ERROR)",
  "details": [
    {
      "field": "string",
      "error": "string"
    }
  ]
}
```

### Ejemplos de Errores

```json
{
  "success": false,
  "message": "Validación fallida",
  "errorCode": "VALIDATION_ERROR",
  "details": [
    {
      "field": "email",
      "error": "Email debe tener formato válido"
    },
    {
      "field": "telefono",
      "error": "Teléfono debe tener al menos 10 dígitos"
    }
  ]
}
```

---

## 10. Response Wrapper Estándar

Todas las respuestas exitosas deben envolver los datos:

```json
{
  "success": true,
  "message": "string (optional, operation description)",
  "data": {
    "...": "Specific response data"
  }
}
```

---

## 11. Paginación

Para operaciones que retornan listas:

```json
{
  "success": true,
  "data": {
    "items": [{ "..." : "Item 1" }],
    "pagination": {
      "total": "int",
      "page": "int",
      "pageSize": "int",
      "totalPages": "int",
      "hasNextPage": "boolean",
      "hasPreviousPage": "boolean"
    }
  }
}
```

---

## 12. Validaciones de Campos

| Campo | Tipo | Min | Max | Formato |
|-------|------|-----|-----|---------|
| username | string | 5 | 50 | Alfanumérico + _ |
| password | string | 8 | 255 | Alfanumérico + caracteres especiales |
| email | string | 5 | 100 | RFC 5322 |
| telefono | string | 10 | 20 | +país código área número |
| documento | string | 6 | 20 | Alfanumérico |
| nombres | string | 2 | 100 | Letras + espacios |
| apellidos | string | 2 | 100 | Letras + espacios |
| motivo | string | 5 | 500 | Alfanumérico + caracteres especiales |
| licencia | string | 5 | 50 | Alfanumérico |

---

## 13. Códigos de Respuesta HTTP

```
200 OK                    - Operación exitosa
201 Created              - Recurso creado exitosamente
400 Bad Request          - Validación fallida
401 Unauthorized         - Autenticación requerida
403 Forbidden            - Acceso denegado (authorization)
404 Not Found            - Recurso no encontrado
409 Conflict             - Conflicto (ej. documento duplicado)
500 Internal Server Error - Error del servidor
```

---

## 14. Enumeraciones

### Role
```
Admin        - Acceso completo
Recepcionista - Gestión de pacientes y citas
Doctor       - Consulta de pacientes y citas
```

### Gender
```
M     - Masculino
F     - Femenino
Otro  - Otro
```

### Appointment Status
```
Pendiente    - Cita agendada, pendiente confirmación
Confirmada   - Cita confirmada
Cancelada    - Cita cancelada
Realizada    - Cita completada
```

### User Status
```
Activo   - Usuario activo
Inactivo - Usuario inactivo
Bloqueado - Usuario bloqueado por admin
```

### Doctor Status
```
Activo   - Disponible para citas
Inactivo - No disponible temporalmente
Licencia - En licencia/incapacidad
```

---

## 15. Ejemplos de Flujos

### Flujo 1: Login y Crear Cita

1. **POST /api/auth/login**
   ```json
   Request: { "username": "recepcionista1", "password": "recep123" }
   Response: { "success": true, "data": { "token": "xyz...", "user": {...} } }
   ```

2. **GET /api/doctors/1/available-slots?date=2025-12-10**
   ```json
   Response: { "success": true, "data": { "slots": ["10:00", "10:30", "11:00"] } }
   ```

3. **POST /api/appointments**
   ```json
   Request: { 
     "pacienteId": 1, 
     "medicoId": 1, 
     "fecha": "2025-12-10", 
     "hora": "10:00", 
     "motivo": "Control general"
   }
   Response: { "success": true, "data": { "citaId": 1, ... } }
   ```

### Flujo 2: Búsqueda de Pacientes

1. **GET /api/patients/search?searchTerm=Juan&epsId=1&page=1&pageSize=20**
   ```json
   Response: {
     "success": true,
     "data": {
       "items": [{ "pacienteId": 1, "nombres": "Juan", ... }],
       "pagination": { "total": 1, "page": 1, "pageSize": 20 }
     }
   }
   ```

---

## Notas Importantes

1. **Seguridad**: Nunca transmitir contraseñas en texto plano (usar HTTPS)
2. **Validación**: Validar en cliente Y servidor
3. **Errores**: Nunca exponer detalles internos de BD en mensajes de error
4. **Timestamps**: Usar UTC para fechas/horas
5. **Idioma**: Las mensajes de error deben localizarse
6. **Rate Limiting**: Considerar para endpoints de autenticación

---

**Versión**: 1.0.0 | **Última actualización**: 2025-12-05
