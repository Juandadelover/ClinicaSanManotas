-- ============================================================
-- CLINICA SAN MANOTAS - Database Verification Script
-- Check what data is currently in the database
-- ============================================================

USE clinica_san_manotas;

-- ============================================================
-- 1. DATABASE STRUCTURE CHECK
-- ============================================================
SELECT '========== VERIFICACIÓN DE TABLAS ==========' as Verificacion;

-- Check if tables exist
SELECT 
  TABLE_NAME,
  TABLE_ROWS as Registros
FROM INFORMATION_SCHEMA.TABLES 
WHERE TABLE_SCHEMA = 'clinica_san_manotas'
ORDER BY TABLE_NAME;

-- ============================================================
-- 2. COUNT DATA IN EACH TABLE
-- ============================================================
SELECT '========== CONTEO DE DATOS ==========' as Datos;

SELECT CONCAT('Especialidades: ', COUNT(*)) as Total FROM Especialidad;
SELECT CONCAT('EPS: ', COUNT(*)) as Total FROM EPS;
SELECT CONCAT('Usuarios: ', COUNT(*)) as Total FROM Usuario;
SELECT CONCAT('Médicos: ', COUNT(*)) as Total FROM Medico;
SELECT CONCAT('Pacientes: ', COUNT(*)) as Total FROM Paciente;
SELECT CONCAT('Citas: ', COUNT(*)) as Total FROM Cita;
SELECT CONCAT('AuditLog: ', COUNT(*)) as Total FROM AuditLog;

-- ============================================================
-- 3. ESPECIALIDADES (Medical Specialties)
-- ============================================================
SELECT '========== ESPECIALIDADES ==========' as Especialidades;
SELECT 
  EspecialidadId,
  Nombre,
  Descripcion
FROM Especialidad
ORDER BY EspecialidadId;

-- ============================================================
-- 4. EPS (Insurance Companies)
-- ============================================================
SELECT '========== EPS ==========' as EPS;
SELECT 
  EPSId,
  Nombre,
  Nit,
  Telefono,
  Email,
  Estado
FROM EPS
ORDER BY EPSId;

-- ============================================================
-- 5. USUARIOS (Users)
-- ============================================================
SELECT '========== USUARIOS ==========' as Usuarios;
SELECT 
  UserId,
  Username,
  Email,
  Role,
  Estado,
  FechaCreacion,
  FechaUltimoLogin
FROM Usuario
ORDER BY UserId;

-- ============================================================
-- 6. MEDICOS (Doctors)
-- ============================================================
SELECT '========== MEDICOS ==========' as Medicos;
SELECT 
  MedicoId,
  CONCAT(Nombres, ' ', Apellidos) as NombreCompleto,
  Email,
  Telefono,
  Licencia,
  (SELECT Nombre FROM Especialidad WHERE EspecialidadId = Medico.EspecialidadId) as Especialidad,
  HorarioInicio,
  HorarioFin,
  DiasAtencion,
  Estado
FROM Medico
ORDER BY MedicoId;

-- ============================================================
-- 7. PACIENTES (Patients)
-- ============================================================
SELECT '========== PACIENTES ==========' as Pacientes;
SELECT 
  PacienteId,
  CONCAT(Nombres, ' ', Apellidos) as NombreCompleto,
  Email,
  Telefono,
  FechaNacimiento,
  Genero,
  Documento,
  (SELECT Nombre FROM EPS WHERE EPSId = Paciente.EPSId) as EPS,
  Direccion,
  Ciudad,
  Estado
FROM Paciente
ORDER BY PacienteId;

-- ============================================================
-- 8. CITAS (Appointments)
-- ============================================================
SELECT '========== CITAS ==========' as Citas;
SELECT 
  CitaId,
  (SELECT CONCAT(Nombres, ' ', Apellidos) FROM Paciente WHERE PacienteId = Cita.PacienteId) as Paciente,
  (SELECT CONCAT(Nombres, ' ', Apellidos) FROM Medico WHERE MedicoId = Cita.MedicoId) as Medico,
  Fecha,
  Hora,
  Motivo,
  Estado
FROM Cita
ORDER BY CitaId;

-- ============================================================
-- 9. SUMMARY REPORT
-- ============================================================
SELECT '========== RESUMEN FINAL ==========' as Resumen;
SELECT 'BASE DE DATOS: clinica_san_manotas' as Info;
SELECT CONCAT('Fecha/Hora: ', NOW()) as FechaVerificacion;

-- Show connection info
SELECT 'Conexión exitosa a la base de datos' as Estado;
