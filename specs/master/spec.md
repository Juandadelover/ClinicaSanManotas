# Especificación de Características - CLINICA SAN MANOTAS

## Visión General
Desarrollo de un sistema de gestión integral para clínicas que facilite la administración de pacientes, citas y médicos. Aplicación de escritorio Windows Forms con .NET conectada a base de datos MySQL.

## Requisitos Funcionales

### 1. Autenticación y Gestión de Usuarios
- Login de personal administrativo con usuario y contraseña
- Gestión de usuarios del sistema (foto, ID, contraseña, otros datos)
- Cambio de contraseña
- Recuperación de contraseña vía correo electrónico
- Control de acceso basado en roles

### 2. Gestión de Pacientes
- Registrar nuevos pacientes
- Editar información de pacientes
- Eliminar registros de pacientes
- Consultar datos de pacientes
- Asociación con EPS

### 3. Gestión de Citas
- Crear citas con pacientes y médicos
- Registrar fecha, hora, motivo y estado (pendiente, confirmada, cancelada)
- Editar citas existentes
- Cancelar citas
- Historial de citas por paciente
- Visualizar disponibilidad de médicos

### 4. Gestión de Médicos
- Registrar médicos con especialidad
- Asignar horarios de atención
- Editar información de médicos
- Eliminar médicos

### 5. Gestión de EPS
- Registrar EPS (aseguradoras)
- Asociar múltiples pacientes a una EPS
- Editar información de EPS

### 6. Filtros y Búsquedas
- Buscar médicos por especialidad
- Buscar médicos por nombre/apellido
- Buscar pacientes por género
- Buscar pacientes por edad
- Buscar pacientes por EPS
- Mostrar pacientes con cita en fecha determinada
- Mostrar citas por estado
- Filtrar pacientes registrados en fecha determinada

### 7. Localización
- Interfaz en español e inglés
- Cambio de idioma en tiempo de ejecución

## Requisitos No Funcionales

### Validaciones
- Campos obligatorios no vacíos
- Formato válido de fechas y horas
- Validación de teléfono y correo electrónico
- Edad válida de pacientes

### Manejo de Errores
- Manejo de errores de conexión a BD
- Manejo de errores SQL
- Mensajes claros al usuario
- Prevenir cierres inesperados de la aplicación

### Tecnologías
- Lenguaje: C#
- Framework: .NET (Windows Forms)
- Base de Datos: MySQL
- ORM: Entity Framework Core

## Entregables
1. Modelo relacional y diccionario de datos
2. Wireframes y Mockups
3. Scripts de base de datos (SQL)
4. Aplicación con requisitos funcionales y no funcionales
5. Documentación técnica
6. Sustentación
