-- ============================================================
-- CLINICA SAN MANOTAS - Complete Setup Script
-- This script executes all database setup in the correct order
-- ============================================================

-- Execute in this order:
-- 1. First: 01-create-database.sql (creates database and tables)
-- 2. Second: 02-insert-initial-data.sql (inserts all reference data)
-- 3. Optional: 04-reset-data.sql (when you need to reset data)

-- ============================================================
-- INSTRUCTIONS / INSTRUCCIONES
-- ============================================================

-- OPCIÓN 1: Ejecutar desde línea de comandos MySQL
-- En PowerShell:
-- mysql -u root -p12345 < "ruta/al/01-create-database.sql"
-- mysql -u root -p12345 < "ruta/al/02-insert-initial-data.sql"

-- OPCIÓN 2: Ejecutar en MySQL Workbench
-- 1. Abre MySQL Workbench
-- 2. Conecta a tu servidor MySQL (usuario: root, contraseña: 12345)
-- 3. File > Open SQL Script > selecciona 01-create-database.sql
-- 4. Ejecuta (Ctrl+Shift+Enter)
-- 5. Repite para 02-insert-initial-data.sql

-- OPCIÓN 3: Copiar y pegar en MySQL CLI
-- mysql -u root -p
-- (ingresa contraseña: 12345)
-- source "C:/ruta/a/01-create-database.sql";
-- source "C:/ruta/a/02-insert-initial-data.sql";

-- ============================================================
-- Verification Queries
-- ============================================================

-- After running all scripts, verify the data:

USE clinica_san_manotas;

-- Check table counts
SELECT 'VERIFICACION DE TABLAS' as Verificacion;
SELECT COUNT(*) as TotalEspecialidades FROM Especialidad;
SELECT COUNT(*) as TotalEPS FROM EPS;
SELECT COUNT(*) as TotalUsuarios FROM Usuario;
SELECT COUNT(*) as TotalMedicos FROM Medico;
SELECT COUNT(*) as TotalPacientes FROM Paciente;
SELECT COUNT(*) as TotalCitas FROM Cita;

-- Display login users
SELECT '--- USUARIOS PARA LOGIN ---' as Usuario;
SELECT Username, Role, Email FROM Usuario WHERE Estado = 'Activo' ORDER BY Role;

-- Display sample data
SELECT '--- ESPECIALIDADES ---' as Datos;
SELECT * FROM Especialidad LIMIT 5;

SELECT '--- PACIENTES ---' as Datos;
SELECT PacienteId, Nombres, Apellidos, Genero, FechaNacimiento FROM Paciente LIMIT 5;

SELECT '--- MEDICOS ---' as Datos;
SELECT MedicoId, Nombres, Apellidos, Licencia FROM Medico LIMIT 5;

-- ============================================================
-- END OF VERIFICATION
-- ============================================================
