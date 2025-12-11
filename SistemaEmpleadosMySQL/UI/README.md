# UI Forms

Formularios Windows Forms de la clínica.

## Formularios Principales

### LoginForm
Login con validación de credenciales. Redirige según rol: Admin → MainForm, Recepcionista → RecepcionForm, Doctor → DoctorForm.

### MainForm
Panel administrativo con acceso completo: pacientes, médicos, citas, usuarios, especialidades.

### RecepcionForm
Panel de recepción: gestión de pacientes y citas.

### DoctorForm
Panel de doctor: citas y pacientes propios.

## Gestión de Datos

### PacientesForm
CRUD completo de pacientes con búsqueda, paginación y validaciones.

### MedicosForm
Gestión de médicos y especialidades.

### CitasForm
Programación y seguimiento de citas médicas.

### UsuariosForm
Administración de usuarios del sistema.

### EspecialidadesForm
Catálogo de especialidades médicas.

### EPSForm
Gestión de entidades prestadoras de salud.

## Estructura

```
LoginForm → MainForm (Admin) → Todos los formularios
         ├─ RecepcionForm (Recepcionista) → Pacientes, Citas
         └─ DoctorForm (Doctor) → Mis Citas, Mis Pacientes
```

SessionManager maneja permisos según rol de usuario.
