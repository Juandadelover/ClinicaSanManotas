# CLINICA SAN MANOTAS - Tareas Detalladas (tasks.md)

**Versión**: 1.0.0 | **Fecha**: 2025-12-05 | **Status**: 📋 DESGLOSE COMPLETO

---

## 📋 Resumen Ejecutivo

**Total de Tareas**: 87  
**Phases**: 5 (Setup, Foundational, 7 User Stories, Polish)  
**Horas Estimadas**: 63-79 horas  
**Path Crítico**: 45-50 horas (Phase 2: Backend)

---

## PHASE 1: SETUP (Preparación del Proyecto)

### Infraestructura Base

- [ ] T001 Crear estructura de carpetas del proyecto (Core, Data, Services, UI)
- [ ] T002 Configurar .csproj con target framework .NET 8.0
- [ ] T003 [P] Instalar NuGet packages (EF Core, BCrypt, Serilog, Newtonsoft.Json)
- [ ] T004 Crear appsettings.json con cadena de conexión MySQL
- [ ] T005 Configurar archivo .gitignore (bin, obj, packages, appsettings.local)
- [ ] T006 Inicializar Git repository y primer commit

**Subtotal**: 6 tareas | **Horas**: 2-3 | **Complejidad**: S/M

---

## PHASE 2: FOUNDATIONAL (Bases Compartidas)

### Base de Datos

- [ ] T007 Ejecutar script 01-create-database.sql en MySQL
- [ ] T008 Ejecutar script 02-insert-initial-data.sql
- [ ] T009 Ejecutar script 03-stored-procedures.sql
- [ ] T010 [P] Verificar integridad de BD (todas las tablas y relaciones)

### Configuración de Entity Framework Core

- [ ] T011 Crear DbContext (ClinicaContext) con 8 DbSets
- [ ] T012 [P] Configurar FluentAPI para relaciones (1:N, N:1)
- [ ] T013 [P] Configurar validaciones en FluentAPI (Required, MaxLength, etc)
- [ ] T014 Crear primera EF Core Migration
- [ ] T015 [P] Aplicar migration a BD

### Patrón Repository + UnitOfWork

- [ ] T016 Crear interface IRepository<T> genérica
- [ ] T017 [P] Implementar Repository<T> genérico
- [ ] T018 Crear interface IUnitOfWork
- [ ] T019 [P] Implementar UnitOfWork con transacciones
- [ ] T020 [P] Crear IUnitOfWork con properties para cada entidad

### Modelos de Dominio

- [ ] T021 Crear clase Usuario con validaciones
- [ ] T022 [P] Crear clase Especialidad
- [ ] T023 [P] Crear clase EPS
- [ ] T024 [P] Crear clase Medico con relación a Especialidad
- [ ] T025 [P] Crear clase Paciente con relación a EPS
- [ ] T026 [P] Crear clase Cita con relaciones a Paciente y Medico
- [ ] T027 [P] Crear clase AuditLog

### Servicios de Seguridad

- [ ] T028 Crear AuthenticationService (login, validación)
- [ ] T029 [P] Implementar BCrypt para hash de contraseñas
- [ ] T030 [P] Implementar validación de credenciales
- [ ] T031 Crear PasswordValidator con requisitos mínimos

### Servicios de Validación

- [ ] T032 Crear ValidatorService centralizado
- [ ] T033 [P] Implementar validaciones de email
- [ ] T034 [P] Implementar validaciones de teléfono
- [ ] T035 [P] Implementar validaciones de fechas
- [ ] T036 Crear CustomValidationException

### Tests Unitarios (Phase 2)

- [ ] T037 [P] Crear tests para Repository<T>
- [ ] T038 [P] Crear tests para UnitOfWork
- [ ] T039 [P] Crear tests para AuthenticationService
- [ ] T040 [P] Crear tests para ValidatorService

**Subtotal**: 34 tareas | **Horas**: 18-22 | **Complejidad**: S/M/L

---

## PHASE 3: USER STORY 1 - Autenticación y Gestión de Usuarios

### Especificación
**Goal**: Usuario administrativo inicia sesión con credenciales y accede al sistema  
**Criterios Independientes**:
- ✓ Login exitoso con credenciales correctas
- ✓ Rechazo de credenciales inválidas
- ✓ Cambio de contraseña funcional
- ✓ Recuperación de contraseña vía email

### Modelos y Datos

- [ ] T041 Crear clase LoginRequest DTO
- [ ] T042 [P] Crear clase LoginResponse DTO
- [ ] T043 [P] Crear clase ChangePasswordRequest DTO
- [ ] T044 Crear clase UserResponse DTO

### Servicios de Lógica de Negocio

- [ ] T045 Crear UserService (CRUD de usuarios)
- [ ] T046 [P] Implementar GetUserByUsername
- [ ] T047 [P] Implementar CreateUser con validaciones
- [ ] T048 [P] Implementar ChangePassword con verificación
- [ ] T049 Crear EmailService para envío de contraseña

### UI (Windows Forms)

- [ ] T050 [US1] Crear LoginForm con validación visual
- [ ] T051 [P] [US1] Implementar data binding de Login
- [ ] T052 [P] [US1] Crear ChangePasswordForm
- [ ] T053 [US1] Conectar LoginForm con AuthenticationService

### Testing

- [ ] T054 [US1] Tests unitarios para UserService
- [ ] T055 [P] [US1] Tests integración BD - UserService
- [ ] T056 [P] [US1] Tests E2E - flujo login completo

**Subtotal**: 16 tareas | **Horas**: 10-12 | **Complejidad**: M

---

## PHASE 4: USER STORY 2 - Gestión de Pacientes

### Especificación
**Goal**: Personal administrativo puede registrar, editar y consultar pacientes  
**Criterios Independientes**:
- ✓ Crear paciente con validaciones
- ✓ Editar datos de paciente
- ✓ Eliminar paciente
- ✓ Listar pacientes con paginación

### Modelos y DTOs

- [ ] T057 Crear CreatePatientRequest DTO
- [ ] T058 [P] Crear UpdatePatientRequest DTO
- [ ] T059 [P] Crear PatientResponse DTO
- [ ] T060 [P] Crear PatientListResponse DTO

### Servicios de Lógica de Negocio

- [ ] T061 Crear PatientService (CRUD completo)
- [ ] T062 [P] Implementar CreatePatient con validaciones
- [ ] T063 [P] Implementar UpdatePatient
- [ ] T064 [P] Implementar DeletePatient (soft delete)
- [ ] T065 [P] Implementar GetPatientById
- [ ] T066 [P] Implementar GetAllPatients con paginación
- [ ] T067 Crear PatientValidator

### UI (Windows Forms)

- [ ] T068 [US2] Crear PatientForm (CRUD principal)
- [ ] T069 [P] [US2] Crear PatientListDataGrid
- [ ] T070 [P] [US2] Implementar agregar paciente
- [ ] T071 [P] [US2] Implementar editar paciente
- [ ] T072 [P] [US2] Implementar eliminar paciente
- [ ] T073 [US2] Crear dialogo de confirmación para delete

### Localización (i18n)

- [ ] T074 [US2] Crear recursos en es.resx (strings de pacientes)
- [ ] T075 [P] [US2] Crear recursos en en.resx

### Testing

- [ ] T076 [US2] Tests unitarios PatientService
- [ ] T077 [P] [US2] Tests integración BD
- [ ] T078 [P] [US2] Tests validaciones

**Subtotal**: 22 tareas | **Horas**: 12-14 | **Complejidad**: M

---

## PHASE 5: USER STORY 3 - Gestión de Médicos

### Especificación
**Goal**: Administrador gestiona médicos, especialidades y horarios  
**Criterios Independientes**:
- ✓ Crear médico con especialidad y horarios
- ✓ Asignar horarios de atención
- ✓ Validar licencia única
- ✓ Listar médicos con filtros

### Modelos y DTOs

- [ ] T079 Crear CreateDoctorRequest DTO
- [ ] T080 [P] Crear DoctorResponse DTO
- [ ] T081 [P] Crear SpecialtyResponse DTO

### Servicios de Lógica de Negocio

- [ ] T082 Crear DoctorService (CRUD)
- [ ] T083 [P] Implementar CreateDoctor con validación de licencia única
- [ ] T084 [P] Implementar validación de horarios (inicio < fin)
- [ ] T085 [P] Implementar GetDoctorsBySpecialty
- [ ] T086 Crear SpecialtyService (CRUD)
- [ ] T087 [P] Implementar GetAllSpecialties (caché en memoria)

### UI (Windows Forms)

- [ ] T088 [US3] Crear DoctorForm (CRUD)
- [ ] T089 [P] [US3] Crear SpecialtyComboBox reutilizable
- [ ] T090 [P] [US3] Implementar agregar médico
- [ ] T091 [P] [US3] Implementar editar médico

### Testing

- [ ] T092 [US3] Tests unitarios DoctorService
- [ ] T093 [P] [US3] Tests validaciones

**Subtotal**: 15 tareas | **Horas**: 10-12 | **Complejidad**: M

---

## PHASE 6: USER STORY 4 - Gestión de Citas

### Especificación
**Goal**: Crear, consultar y gestionar citas médicas  
**Criterios Independientes**:
- ✓ Agendar cita validando disponibilidad
- ✓ Confirmar cita
- ✓ Cancelar cita
- ✓ Ver historial de citas por paciente

### Modelos y DTOs

- [ ] T094 Crear CreateAppointmentRequest DTO
- [ ] T095 [P] Crear AppointmentResponse DTO
- [ ] T096 [P] Crear AvailableSlotResponse DTO

### Servicios de Lógica de Negocio

- [ ] T097 Crear AppointmentService (CRUD)
- [ ] T098 [P] Implementar CreateAppointment con validación de disponibilidad
- [ ] T099 [P] Implementar verificación: no duplicar citas (mismo médico, hora)
- [ ] T100 [P] Implementar GetAvailableSlots (usando SP)
- [ ] T101 [P] Implementar ConfirmAppointment
- [ ] T102 [P] Implementar CancelAppointment (solo si Pendiente)
- [ ] T103 [P] Implementar GetPatientAppointmentHistory

### UI (Windows Forms)

- [ ] T104 [US4] Crear AppointmentForm (CRUD)
- [ ] T105 [P] [US4] Crear selector de horarios disponibles
- [ ] T106 [P] [US4] Implementar agregar cita
- [ ] T107 [P] [US4] Implementar cambiar estado (Confirmada/Cancelada)
- [ ] T108 [US4] Crear vista de historial de citas

### Testing

- [ ] T109 [US4] Tests unitarios AppointmentService
- [ ] T110 [P] [US4] Tests validación de disponibilidad
- [ ] T111 [P] [US4] Tests no permitir duplicadas

**Subtotal**: 18 tareas | **Horas**: 12-14 | **Complejidad**: M/L

---

## PHASE 7: USER STORY 5 - Filtros y Búsquedas Avanzadas

### Especificación
**Goal**: Personal administrativo puede filtrar y buscar información  
**Criterios Independientes**:
- ✓ Buscar médicos por especialidad
- ✓ Buscar pacientes por múltiples criterios
- ✓ Filtrar citas por estado y fecha

### Servicios de Lógica de Negocio

- [ ] T112 Crear SearchService (búsquedas)
- [ ] T113 [P] Implementar SearchPatients (por nombre, género, EPS, edad)
- [ ] T114 [P] Implementar SearchDoctors (por especialidad, nombre)
- [ ] T115 [P] Implementar GetAppointmentsByStatus
- [ ] T116 [P] Implementar GetAppointmentsByDate

### UI (Windows Forms)

- [ ] T117 [US5] Crear SearchForm con 3 tabs (Pacientes, Médicos, Citas)
- [ ] T118 [P] [US5] Implementar búsqueda de pacientes
- [ ] T119 [P] [US5] Implementar búsqueda de médicos
- [ ] T120 [P] [US5] Implementar búsqueda de citas
- [ ] T121 [US5] Implementar exportación de resultados (CSV)

### Testing

- [ ] T122 [US5] Tests SearchService
- [ ] T123 [P] [US5] Tests filtros combinados

**Subtotal**: 12 tareas | **Horas**: 8-10 | **Complejidad**: M

---

## PHASE 8: USER STORY 6 - Localización (Español/Inglés)

### Especificación
**Goal**: Interfaz completamente traducible español/inglés  
**Criterios Independientes**:
- ✓ Cambio dinámico de idioma sin reiniciar
- ✓ Todos los textos localizados
- ✓ Formatos localizados (fechas, moneda)

### Recursos

- [ ] T124 Crear es.resx master con todos los strings
- [ ] T125 [P] Crear en.resx con traducciones
- [ ] T126 [P] Implementar LocalizationService

### UI (Windows Forms)

- [ ] T127 [US6] Crear SettingsForm (cambio de idioma)
- [ ] T128 [P] [US6] Implementar selector de idioma
- [ ] T129 [P] [US6] Implementar refresh dinámico de UI al cambiar idioma

### Testing

- [ ] T130 [US6] Tests cambio de idioma
- [ ] T131 [P] [US6] Tests que todos strings estén localizados

**Subtotal**: 8 tareas | **Horas**: 5-6 | **Complejidad**: S/M

---

## PHASE 9: USER STORY 7 - EPS y Especialidades

### Especificación
**Goal**: Gestionar datos de referencia (EPS y Especialidades)  
**Criterios Independientes**:
- ✓ CRUD de EPS
- ✓ CRUD de Especialidades
- ✓ Caché en memoria

### Servicios

- [ ] T132 Crear EPSService (CRUD)
- [ ] T133 [P] Implementar caché de EPS en memoria
- [ ] T134 [P] Implementar invalidar caché cuando sea necesario

### UI (Windows Forms)

- [ ] T135 [US7] Crear EPSForm (CRUD)
- [ ] T136 [P] [US7] Crear SpecialtyForm (CRUD)

### Testing

- [ ] T137 [US7] Tests EPSService
- [ ] T138 [P] [US7] Tests caché

**Subtotal**: 7 tareas | **Horas**: 4-5 | **Complejidad**: S

---

## PHASE 10: POLISH & CROSS-CUTTING

### UI Mejorada

- [ ] T139 Crear MainForm (Dashboard) con widgets
- [ ] T140 [P] Implementar validación visual en todos los formularios
- [ ] T141 [P] Crear dialogo de confirmación reutilizable
- [ ] T142 [P] Implementar mensajes de error/éxito

### Logging y Auditoría

- [ ] T143 Configurar Serilog (archivo + consola)
- [ ] T144 [P] Implementar logging en todos los Services
- [ ] T145 [P] Implementar auditoría en tabla AuditLog

### Reportes

- [ ] T146 Crear ReportService (generación PDF)
- [ ] T147 [P] Implementar reporte de citas por rango de fechas
- [ ] T148 [P] Implementar reporte de pacientes por EPS

### Optimización y Performance

- [ ] T149 Optimizar índices de BD
- [ ] T150 [P] Implementar paginación en todas las listas
- [ ] T151 [P] Implementar caché de datos de referencia

### Documentación Técnica

- [ ] T152 Crear README.md del código
- [ ] T153 [P] Documentar APIs públicas
- [ ] T154 [P] Crear guía de arquitectura

### Tests Finales

- [ ] T155 Tests E2E - flujo completo login → crear paciente → agendar cita
- [ ] T156 [P] Tests de rendimiento (carga de datos)
- [ ] T157 [P] Tests de seguridad (SQL injection, validation)

**Subtotal**: 19 tareas | **Horas**: 10-12 | **Complejidad**: M/L

---

## 📊 RESUMEN POR PHASE

| Phase | Tareas | Horas | Complejidad |
|-------|--------|-------|-------------|
| Phase 1: Setup | 6 | 2-3 | S |
| Phase 2: Foundational | 34 | 18-22 | S/M/L |
| Phase 3: US1 (Auth) | 16 | 10-12 | M |
| Phase 4: US2 (Patients) | 22 | 12-14 | M |
| Phase 5: US3 (Doctors) | 15 | 10-12 | M |
| Phase 6: US4 (Appointments) | 18 | 12-14 | M/L |
| Phase 7: US5 (Search) | 12 | 8-10 | M |
| Phase 8: US6 (i18n) | 8 | 5-6 | S/M |
| Phase 9: US7 (EPS/Specialty) | 7 | 4-5 | S |
| Phase 10: Polish | 19 | 10-12 | M/L |
| **TOTAL** | **157** | **91-100** | |

---

## 🔄 Paralelización Recomendada

### Por User Story (después de Phase 2)
- US1, US2, US3 pueden hacerse **en paralelo** (no tienen dependencias mutuas)
- US4 (Citas) requiere US2 (Pacientes) y US3 (Médicos) **completados**
- US5 (Search) puede hacerse **en paralelo** con otros
- US6 (i18n) puede hacerse **en paralelo** con otros
- US7 (EPS) **paralelo** con otros

### Secuencia Recomendada
```
Phase 1 → Phase 2 → (US1, US2, US3 en paralelo) → US4 → (US5, US6, US7) → Phase 10
```

---

## ⏱️ Path Crítico

**Ruta más larga (45-50 horas)**:
1. Phase 1: Setup (2-3 hrs)
2. Phase 2: Foundational (18-22 hrs)
3. US2: Gestión de Pacientes (12-14 hrs) - CRITICA
4. US4: Gestión de Citas (12-14 hrs) - DEPENDE DE US2
5. Phase 10: Polish (10-12 hrs)

---

## 📍 Dependencias Clave

```
T001-T006 (Setup)
    ↓
T007-T040 (Foundational)
    ├→ T041-T056 (US1: Auth) [10-12 hrs]
    ├→ T057-T078 (US2: Patients) [12-14 hrs]
    │   ├→ T094-T111 (US4: Appointments) [12-14 hrs]
    │   └→ T112-T123 (US5: Search) [8-10 hrs]
    ├→ T079-T093 (US3: Doctors) [10-12 hrs]
    │   └→ T094-T111 (US4: Appointments) [12-14 hrs]
    ├→ T124-T131 (US6: i18n) [5-6 hrs]
    └→ T132-T138 (US7: EPS) [4-5 hrs]
        ↓
    T139-T157 (Phase 10: Polish) [10-12 hrs]
```

---

## ✅ Criterios de Aceptación por Task

Cada tarea tiene un criterio de aceptación:

**T001 Ejemplo**:
```
Criterio: Todas las carpetas Core, Data, Services, UI, Resources creadas
          sin errores en estructura
Status: ✓ ACEPTADO cuando: 
  - Carpetas existen en Solution Explorer
  - .csproj compila sin errores
```

---

**Total de Tareas**: 157  
**Total Horas**: 91-100  
**Recomendación**: Ejecutar Phases 1-2 secuencial, luego paralelizar US1-US3, después US4, finalmente Polish.

Última actualización: 2025-12-05
