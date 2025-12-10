-- ============================================================
-- SCRIPT DE PRUEBA - CRUD PACIENTES
-- Verifica todas las operaciones de pacientes
-- ============================================================

USE clinica_san_manotas;

-- ============================================================
-- 1. LECTURA - Listar todos los pacientes
-- ============================================================
SELECT 'TEST 1: Lectura de Pacientes' AS Paso;
SELECT COUNT(*) as 'Total Pacientes' FROM paciente WHERE Estado = 'Activo';
SELECT PacienteId, Nombres, Apellidos, Email, Telefono, Documento, Estado 
FROM paciente 
WHERE Estado = 'Activo' 
LIMIT 5;

-- ============================================================
-- 2. CREATE - Insertar nuevo paciente
-- ============================================================
SELECT 'TEST 2: Insertar Nuevo Paciente' AS Paso;

-- Verificar que el documento no exista
SET @documento_test = 'TEST123456789';
SELECT COUNT(*) as 'Documento Existe' FROM paciente WHERE Documento = @documento_test;

-- Insertar
INSERT INTO paciente (
    Nombres, 
    Apellidos, 
    Email, 
    Telefono, 
    FechaNacimiento, 
    Genero, 
    Documento, 
    EPSId, 
    Direccion, 
    Ciudad, 
    Estado
) VALUES (
    'Juan Pablo',
    'García López',
    'juanpablo@test.com',
    '3105556666',
    '1990-05-15',
    'M',
    @documento_test,
    (SELECT EPSId FROM eps LIMIT 1),
    'Calle 10 #25-30',
    'Bogotá',
    'Activo'
);

-- Obtener ID del paciente insertado
SET @paciente_id = LAST_INSERT_ID();
SELECT @paciente_id AS 'ID Paciente Insertado';

-- Verificar inserción
SELECT PacienteId, Nombres, Apellidos, Email, Documento, Estado 
FROM paciente 
WHERE PacienteId = @paciente_id;

-- ============================================================
-- 3. UPDATE - Actualizar paciente
-- ============================================================
SELECT 'TEST 3: Actualizar Paciente' AS Paso;

UPDATE paciente SET 
    Email = 'juanpablo.nuevo@test.com',
    Telefono = '3101111111',
    Ciudad = 'Medellín'
WHERE PacienteId = @paciente_id;

-- Verificar actualización
SELECT PacienteId, Nombres, Email, Telefono, Ciudad 
FROM paciente 
WHERE PacienteId = @paciente_id;

-- ============================================================
-- 4. BÚSQUEDA - Buscar pacientes por nombre
-- ============================================================
SELECT 'TEST 4: Búsqueda por Nombre' AS Paso;

SELECT PacienteId, Nombres, Apellidos, Email, Documento 
FROM paciente 
WHERE Nombres LIKE '%Juan%' AND Estado = 'Activo'
LIMIT 10;

-- ============================================================
-- 5. FILTROS - Filtrar por características
-- ============================================================
SELECT 'TEST 5: Filtros Avanzados' AS Paso;

-- Filtro por Género
SELECT 'Filtro por Género (Masculino):' AS Filtro;
SELECT COUNT(*) as 'Total Hombres' FROM paciente 
WHERE Genero = 'M' AND Estado = 'Activo';

-- Filtro por Rango de Edad
SELECT 'Filtro por Edad (20-40 años):' AS Filtro;
SELECT COUNT(*) as 'Total en Rango' FROM paciente 
WHERE Estado = 'Activo' 
AND YEAR(CURDATE()) - YEAR(FechaNacimiento) BETWEEN 20 AND 40;

-- Filtro por EPS
SELECT 'Filtro por EPS:' AS Filtro;
SELECT eps.Nombre, COUNT(p.PacienteId) as 'Cantidad Pacientes'
FROM paciente p
JOIN eps ON p.EPSId = eps.EPSId
WHERE p.Estado = 'Activo'
GROUP BY eps.EPSId, eps.Nombre;

-- Filtro por Ciudad
SELECT 'Filtro por Ciudad:' AS Filtro;
SELECT Ciudad, COUNT(*) as 'Cantidad Pacientes'
FROM paciente
WHERE Estado = 'Activo'
GROUP BY Ciudad
ORDER BY COUNT(*) DESC
LIMIT 5;

-- ============================================================
-- 6. PAGINACIÓN - Primeros 10 registros
-- ============================================================
SELECT 'TEST 6: Paginación (LIMIT 10)' AS Paso;

SELECT PacienteId, Nombres, Apellidos, Email, Estado 
FROM paciente 
WHERE Estado = 'Activo'
ORDER BY PacienteId
LIMIT 10;

-- ============================================================
-- 7. SOFT DELETE - Eliminar paciente (marcar inactivo)
-- ============================================================
SELECT 'TEST 7: Soft Delete' AS Paso;

-- Estado antes del delete
SELECT PacienteId, Nombres, Estado FROM paciente WHERE PacienteId = @paciente_id;

-- Realizar soft delete
UPDATE paciente SET Estado = 'Inactivo' WHERE PacienteId = @paciente_id;

-- Estado después del delete
SELECT PacienteId, Nombres, Estado FROM paciente WHERE PacienteId = @paciente_id;

-- ============================================================
-- 8. VALIDACIONES - Verificar restricciones
-- ============================================================
SELECT 'TEST 8: Validaciones' AS Paso;

-- Documento único
SELECT 'Documentos Únicos:' AS Validacion;
SELECT Documento, COUNT(*) as 'Repeticiones'
FROM paciente
GROUP BY Documento
HAVING COUNT(*) > 1;

-- Email único (si no es nulo)
SELECT 'Emails Únicos:' AS Validacion;
SELECT Email, COUNT(*) as 'Repeticiones'
FROM paciente
WHERE Email IS NOT NULL
GROUP BY Email
HAVING COUNT(*) > 1;

-- ============================================================
-- 9. JOINS - Información completa de pacientes
-- ============================================================
SELECT 'TEST 9: Join con EPS' AS Paso;

SELECT 
    p.PacienteId,
    CONCAT(p.Nombres, ' ', p.Apellidos) as 'Paciente',
    p.Email,
    p.Telefono,
    eps.Nombre as 'EPS',
    p.Ciudad,
    p.Estado
FROM paciente p
LEFT JOIN eps ON p.EPSId = eps.EPSId
WHERE p.Estado = 'Activo'
LIMIT 5;

-- ============================================================
-- RESUMEN FINAL
-- ============================================================
SELECT 'RESUMEN FINAL' AS Resultado;
SELECT 
    'Total Pacientes Activos' as Metrica,
    COUNT(*) as Cantidad
FROM paciente 
WHERE Estado = 'Activo'
UNION ALL
SELECT 
    'Total Pacientes Inactivos',
    COUNT(*)
FROM paciente 
WHERE Estado = 'Inactivo'
UNION ALL
SELECT 
    'Total Pacientes (Todos)',
    COUNT(*)
FROM paciente;

-- ============================================================
-- LIMPIAR DATOS DE PRUEBA (Opcional)
-- ============================================================
-- Descomentar para limpiar
-- DELETE FROM paciente WHERE Documento LIKE 'TEST%';
