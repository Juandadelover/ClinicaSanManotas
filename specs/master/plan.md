# CLINICA SAN MANOTAS - Plan de Implementación

**Rama**: master | **Fecha**: 2025-12-05

---

## PHASE 0: Investigación y Clarificación

### Estado: EN PROGRESO

#### Contexto Técnico

| Aspecto | Valor | Estado |
|--------|-------|--------|
| Framework | Windows Forms .NET 8 | ✓ DEFINIDO |
| Base de Datos | MySQL 8.0+ | ✓ DEFINIDO |
| ORM | Entity Framework Core 8 | ✓ DEFINIDO |
| Autenticación | Usuario/Contraseña con Hash | ✓ DEFINIDO |
| Idiomas | Español/Inglés (i18n) | ✓ DEFINIDO |
| Logging | NEEDS CLARIFICATION |  |
| Email (Recuperación contraseña) | NEEDS CLARIFICATION |  |
| Caché local | NEEDS CLARIFICATION |  |
| Exportación de reportes | NEEDS CLARIFICATION |  |

#### Tareas de Investigación (Phase 0)

- [ ] **ARCH-001**: Investigar mejores prácticas para Entity Framework Core en Windows Forms
- [ ] **ARCH-002**: Definir estrategia de localización (i18n) en WinForms
- [ ] **SEC-001**: Seleccionar algoritmo seguro para hash de contraseñas
- [ ] **DB-001**: Definir versionamiento de scripts SQL
- [ ] **MAIL-001**: Investigar servicio de correo para recuperación de contraseña
- [ ] **PATTERN-001**: Diseñar patrón Repository + UnitOfWork para DAL

---

## PHASE 1: Diseño e Artefactos

**Prerrequisito**: Phase 0 completado

### Tareas Principales

#### 1.1 Modelo de Datos (data-model.md)
- [ ] Entidades principales: Usuario, Paciente, Médico, Cita, EPS, Especialidad
- [ ] Relaciones y restricciones
- [ ] Validaciones de negocio por entidad
- [ ] Estados y transiciones (ej. Cita: pendiente → confirmada → realizada)

#### 1.2 Contratos API (contracts/)
- [ ] Endpoints de Autenticación
- [ ] CRUD de Pacientes
- [ ] CRUD de Médicos
- [ ] Gestión de Citas
- [ ] Gestión de EPS
- [ ] Filtros y búsquedas
- [ ] Cambio de idioma
- [ ] Recuperación de contraseña

#### 1.3 Base de Datos (database/scripts/)
- [ ] 01-create-database.sql - Crear BD y usuario
- [ ] 02-create-tables.sql - Tablas principales
- [ ] 03-create-indexes.sql - Índices para performance
- [ ] 04-create-stored-procedures.sql - Procedimientos almacenados (si aplica)
- [ ] 05-insert-initial-data.sql - Datos de prueba
- [ ] README-DATABASE.md - Instrucciones de instalación

#### 1.4 Quickstart (quickstart.md)
- [ ] Pasos para setup local
- [ ] Instalación de dependencias
- [ ] Configuración de BD
- [ ] First run de la aplicación

#### 1.5 Wireframes y UI (UI/wireframes/)
- [ ] Login
- [ ] Dashboard/Home
- [ ] Gestión de Pacientes
- [ ] Gestión de Citas
- [ ] Gestión de Médicos
- [ ] Filtros y búsquedas
- [ ] Configuración de idioma y usuario

---

## PHASE 2: Implementación Base (Backend)

**Prerrequisito**: Phase 1 completado

### 2.1 Estructura del Proyecto
```
CLINICA_SAN_MANOTAS/
├── CLINICA_SAN_MANOTAS.csproj
├── Program.cs
├── Core/
│   ├── Models/          # Entidades del negocio
│   ├── Enums/           # Enumeraciones
│   └── Constants/       # Constantes
├── Data/
│   ├── Context/         # DbContext de EF
│   ├── Repositories/    # Pattern Repository
│   └── Migrations/      # EF Migrations
├── Services/
│   ├── Authentication/  # Servicio de autenticación
│   ├── Patient/         # Servicio de pacientes
│   ├── Doctor/          # Servicio de médicos
│   ├── Appointment/     # Servicio de citas
│   ├── Email/           # Servicio de correo
│   └── Localization/    # Servicio de idiomas
├── Validators/          # Validaciones de negocio
├── Utils/               # Utilidades
├── Resources/
│   ├── es.resx          # Strings español
│   └── en.resx          # Strings inglés
├── Config/
│   └── appsettings.json # Configuración
├── UI/
│   ├── Forms/           # Formularios WinForms
│   └── Controls/        # Controles personalizados
└── database/
    └── scripts/         # Scripts SQL
```

### 2.2 Tareas Backend
- [ ] **BLL-001**: Implementar Models y DbContext
- [ ] **BLL-002**: Implementar Repositories
- [ ] **BLL-003**: Implementar UnitOfWork
- [ ] **BLL-004**: Servicio de Autenticación (Login)
- [ ] **BLL-005**: Servicio de Pacientes (CRUD)
- [ ] **BLL-006**: Servicio de Médicos (CRUD)
- [ ] **BLL-007**: Servicio de Citas (CRUD)
- [ ] **BLL-008**: Servicio de EPS (CRUD)
- [ ] **BLL-009**: Servicio de búsquedas y filtros
- [ ] **BLL-010**: Servicio de correo (recuperación contraseña)
- [ ] **BLL-011**: Validadores de negocio
- [ ] **TEST-001**: Tests unitarios de servicios (70% cobertura)

---

## PHASE 3: Implementación UI

**Prerrequisito**: Phase 2 completado

### 3.1 Formularios principales
- [ ] **UI-001**: LoginForm
- [ ] **UI-002**: MainForm (Dashboard)
- [ ] **UI-003**: PatientForm (Gestión de Pacientes)
- [ ] **UI-004**: DoctorForm (Gestión de Médicos)
- [ ] **UI-005**: AppointmentForm (Gestión de Citas)
- [ ] **UI-006**: EPSForm (Gestión de EPS)
- [ ] **UI-007**: SearchForm (Filtros avanzados)
- [ ] **UI-008**: SettingsForm (Idioma, usuario)
- [ ] **UI-009**: ChangePasswordForm

### 3.2 Características UI
- [ ] **FEAT-001**: Binding de datos a controles
- [ ] **FEAT-002**: Validación visual de formularios
- [ ] **FEAT-003**: Mensajes de confirmación
- [ ] **FEAT-004**: Manejo visual de errores
- [ ] **FEAT-005**: Cambio de idioma en tiempo de ejecución
- [ ] **FEAT-006**: DataGridViews con paginación
- [ ] **FEAT-007**: Búsquedas con filtros dinámicos

---

## PHASE 4: Testing e Integración

- [ ] **TEST-002**: Tests de integración BD
- [ ] **TEST-003**: Tests E2E de flujos principales
- [ ] **PERF-001**: Optimización de consultas SQL
- [ ] **SEC-001**: Revisión de seguridad
- [ ] **DOC-001**: Documentación técnica completa

---

## Gateways de Calidad

### Antes de Phase 1 (Diseño)
- ✓ Especificación de características claras
- ✓ Constitution aprobada
- ✓ Todas las clarificaciones resueltas

### Antes de Phase 2 (Backend)
- ✓ data-model.md aprobado
- ✓ Contratos definidos
- ✓ Scripts BD listos
- ✓ Arquitectura de capas diseñada

### Antes de Phase 3 (UI)
- ✓ Wireframes aprobados
- ✓ Servicios de backend completados
- ✓ Tests unitarios al 70%
- ✓ BD lista en desarrollo

### Antes de Phase 4 (Testing)
- ✓ Todas las funcionalidades de UI implementadas
- ✓ Sin warnings de compilación
- ✓ Logging funcionando

### Antes de Producción
- ✓ 70% cobertura de tests
- ✓ Auditoría de seguridad pasada
- ✓ Documentación completa
- ✓ Scripts de BD versionados
- ✓ Guía de instalación probada

---

## Progress Tracking

| Phase | Status | Completion |
|-------|--------|-----------|
| Phase 0 | ⏳ EN PROGRESO | 0% |
| Phase 1 | ⏳ PENDIENTE | 0% |
| Phase 2 | ⏳ PENDIENTE | 0% |
| Phase 3 | ⏳ PENDIENTE | 0% |
| Phase 4 | ⏳ PENDIENTE | 0% |

---

## Notas Importantes

1. **Seguridad**: Todos los accesos a BD deben ser a través de Entity Framework Core con consultas parametrizadas.
2. **Localización**: Usar archivos .resx para todas las cadenas de la UI.
3. **Logging**: Implementar desde el inicio, no como adición posterior.
4. **Errores**: Capturar TODAS las excepciones potenciales, especialmente conexión a BD.
5. **Configuración**: Usar appsettings.json para cadena de conexión y settings.

