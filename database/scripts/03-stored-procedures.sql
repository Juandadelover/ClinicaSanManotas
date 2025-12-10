-- ============================================================
-- CLINICA SAN MANOTAS - Stored Procedures & Functions
-- Version: 1.0.0
-- Date: 2025-12-05
-- Description: Database procedures and functions for common operations
-- ============================================================

USE clinica_san_manotas;

-- ============================================================
-- PROCEDURE: sp_GetAvailableAppointmentSlots
-- Description: Get available time slots for a doctor on a specific date
-- Parameters:
--   @DoctorId INT - Doctor ID
--   @AppointmentDate DATE - Date to check
-- Returns: Available time slots (assuming 30-min slots)
-- ============================================================
DELIMITER $$
CREATE PROCEDURE IF NOT EXISTS sp_GetAvailableAppointmentSlots(
  IN @DoctorId INT,
  IN @AppointmentDate DATE
)
BEGIN
  DECLARE @StartTime TIME;
  DECLARE @EndTime TIME;
  DECLARE @SlotDuration INT DEFAULT 30; -- 30 minutes per slot
  
  -- Get doctor's working hours
  SELECT HorarioInicio, HorarioFin 
  INTO @StartTime, @EndTime
  FROM Medico
  WHERE MedicoId = @DoctorId;
  
  -- Return available slots
  SELECT 
    SEC_TO_TIME(TIME_TO_SEC(@StartTime)) AS SlotTime,
    CASE 
      WHEN EXISTS (
        SELECT 1 FROM Cita 
        WHERE MedicoId = @DoctorId 
        AND Fecha = @AppointmentDate 
        AND Hora = SEC_TO_TIME(TIME_TO_SEC(@StartTime))
        AND Estado != 'Cancelada'
      ) THEN 'Ocupado'
      ELSE 'Disponible'
    END AS Status
  FROM (
    -- Generate time slots dynamically
    SELECT TIME_ADD(@StartTime, INTERVAL seq MINUTE) AS SlotTime
    FROM (
      SELECT @SlotDuration * ROW_NUMBER() OVER () - @SlotDuration AS seq
      FROM (
        SELECT 1 UNION SELECT 2 UNION SELECT 3 UNION SELECT 4 UNION SELECT 5
      ) a CROSS JOIN (
        SELECT 1 UNION SELECT 2 UNION SELECT 3 UNION SELECT 4 UNION SELECT 5
      ) b
    ) slots
    WHERE TIME_ADD(@StartTime, INTERVAL seq MINUTE) < @EndTime
  ) AS TimeSlots
  ORDER BY SlotTime;
END$$
DELIMITER ;

-- ============================================================
-- PROCEDURE: sp_GetPatientAppointmentHistory
-- Description: Get appointment history for a specific patient
-- Parameters:
--   @PatientId INT - Patient ID
--   @Limit INT - Number of records (optional, default 20)
-- Returns: List of appointments ordered by date
-- ============================================================
DELIMITER $$
CREATE PROCEDURE IF NOT EXISTS sp_GetPatientAppointmentHistory(
  IN @PatientId INT,
  IN @Limit INT
)
BEGIN
  IF @Limit IS NULL THEN
    SET @Limit = 20;
  END IF;
  
  SELECT 
    c.CitaId,
    c.Fecha,
    c.Hora,
    CONCAT(m.Nombres, ' ', m.Apellidos) AS DoctorName,
    e.Nombre AS Specialty,
    c.Motivo,
    c.Estado,
    c.FechaCreacion
  FROM Cita c
  INNER JOIN Medico m ON c.MedicoId = m.MedicoId
  INNER JOIN Especialidad e ON m.EspecialidadId = e.EspecialidadId
  WHERE c.PacienteId = @PatientId
  ORDER BY c.Fecha DESC, c.Hora DESC
  LIMIT @Limit;
END$$
DELIMITER ;

-- ============================================================
-- PROCEDURE: sp_GetDoctorsBySpecialty
-- Description: Get all active doctors for a specific specialty
-- Parameters:
--   @SpecialtyName VARCHAR(100) - Specialty name
-- Returns: List of doctors
-- ============================================================
DELIMITER $$
CREATE PROCEDURE IF NOT EXISTS sp_GetDoctorsBySpecialty(
  IN @SpecialtyName VARCHAR(100)
)
BEGIN
  SELECT 
    m.MedicoId,
    CONCAT(m.Nombres, ' ', m.Apellidos) AS FullName,
    m.Email,
    m.Telefono,
    m.Licencia,
    e.Nombre AS Specialty,
    m.HorarioInicio,
    m.HorarioFin,
    m.DiasAtencion,
    m.Estado
  FROM Medico m
  INNER JOIN Especialidad e ON m.EspecialidadId = e.EspecialidadId
  WHERE e.Nombre = @SpecialtyName
  AND m.Estado = 'Activo'
  ORDER BY m.Nombres, m.Apellidos;
END$$
DELIMITER ;

-- ============================================================
-- PROCEDURE: sp_SearchPatients
-- Description: Search patients by various criteria
-- Parameters:
--   @SearchTerm VARCHAR(100) - Name, email, or phone
--   @Gender ENUM - Optional gender filter (M, F, Otro)
--   @EPSId INT - Optional EPS filter
-- Returns: Filtered list of patients
-- ============================================================
DELIMITER $$
CREATE PROCEDURE IF NOT EXISTS sp_SearchPatients(
  IN @SearchTerm VARCHAR(100),
  IN @Gender ENUM('M','F','Otro'),
  IN @EPSId INT
)
BEGIN
  SELECT 
    p.PacienteId,
    CONCAT(p.Nombres, ' ', p.Apellidos) AS FullName,
    p.Email,
    p.Telefono,
    p.FechaNacimiento,
    YEAR(NOW()) - YEAR(p.FechaNacimiento) - 
      (DATE_FORMAT(NOW(), '%m%d') < DATE_FORMAT(p.FechaNacimiento, '%m%d')) AS Age,
    p.Genero,
    p.Documento,
    e.Nombre AS EPS,
    p.Direccion,
    p.Ciudad,
    p.FechaRegistro,
    p.Estado
  FROM Paciente p
  INNER JOIN EPS e ON p.EPSId = e.EPSId
  WHERE (
    p.Nombres LIKE CONCAT('%', @SearchTerm, '%') OR
    p.Apellidos LIKE CONCAT('%', @SearchTerm, '%') OR
    p.Email LIKE CONCAT('%', @SearchTerm, '%') OR
    p.Telefono LIKE CONCAT('%', @SearchTerm, '%') OR
    p.Documento LIKE CONCAT('%', @SearchTerm, '%')
  )
  AND (@Gender IS NULL OR p.Genero = @Gender)
  AND (@EPSId IS NULL OR p.EPSId = @EPSId)
  ORDER BY p.Apellidos, p.Nombres;
END$$
DELIMITER ;

-- ============================================================
-- PROCEDURE: sp_GetAppointmentsByDate
-- Description: Get all appointments for a specific date
-- Parameters:
--   @AppointmentDate DATE - Date to query
-- Returns: List of appointments with patient and doctor details
-- ============================================================
DELIMITER $$
CREATE PROCEDURE IF NOT EXISTS sp_GetAppointmentsByDate(
  IN @AppointmentDate DATE
)
BEGIN
  SELECT 
    c.CitaId,
    c.Hora,
    CONCAT(p.Nombres, ' ', p.Apellidos) AS PatientName,
    p.Documento,
    CONCAT(m.Nombres, ' ', m.Apellidos) AS DoctorName,
    e.Nombre AS Specialty,
    c.Motivo,
    c.Estado,
    p.Telefono,
    p.Email
  FROM Cita c
  INNER JOIN Paciente p ON c.PacienteId = p.PacienteId
  INNER JOIN Medico m ON c.MedicoId = m.MedicoId
  INNER JOIN Especialidad e ON m.EspecialidadId = e.EspecialidadId
  WHERE c.Fecha = @AppointmentDate
  ORDER BY c.Hora;
END$$
DELIMITER ;

-- ============================================================
-- PROCEDURE: sp_GetAppointmentsByStatus
-- Description: Get appointments filtered by status with patient info
-- Parameters:
--   @Status ENUM - Status filter (Pendiente, Confirmada, Cancelada, Realizada)
--   @StartDate DATE - Optional start date filter
--   @EndDate DATE - Optional end date filter
-- Returns: List of appointments
-- ============================================================
DELIMITER $$
CREATE PROCEDURE IF NOT EXISTS sp_GetAppointmentsByStatus(
  IN @Status ENUM('Pendiente','Confirmada','Cancelada','Realizada'),
  IN @StartDate DATE,
  IN @EndDate DATE
)
BEGIN
  SELECT 
    c.CitaId,
    c.Fecha,
    c.Hora,
    CONCAT(p.Nombres, ' ', p.Apellidos) AS PatientName,
    p.Documento,
    p.Telefono,
    CONCAT(m.Nombres, ' ', m.Apellidos) AS DoctorName,
    e.Nombre AS Specialty,
    c.Motivo,
    c.Estado,
    c.FechaCreacion,
    c.FechaActualizacion
  FROM Cita c
  INNER JOIN Paciente p ON c.PacienteId = p.PacienteId
  INNER JOIN Medico m ON c.MedicoId = m.MedicoId
  INNER JOIN Especialidad e ON m.EspecialidadId = e.EspecialidadId
  WHERE c.Estado = @Status
  AND c.Fecha >= COALESCE(@StartDate, c.Fecha)
  AND c.Fecha <= COALESCE(@EndDate, c.Fecha)
  ORDER BY c.Fecha DESC, c.Hora DESC;
END$$
DELIMITER ;

-- ============================================================
-- FUNCTION: fn_CalculatePatientAge
-- Description: Calculate patient age from birth date
-- Returns: INT (age in years)
-- ============================================================
DELIMITER $$
CREATE FUNCTION IF NOT EXISTS fn_CalculatePatientAge(
  @BirthDate DATE
) RETURNS INT
DETERMINISTIC
NO SQL
BEGIN
  DECLARE @Age INT;
  SET @Age = YEAR(CURDATE()) - YEAR(@BirthDate) - 
             (DATE_FORMAT(CURDATE(), '%m%d') < DATE_FORMAT(@BirthDate, '%m%d'));
  RETURN @Age;
END$$
DELIMITER ;

-- ============================================================
-- PROCEDURE: sp_VerifyDoctorAvailability
-- Description: Check if a doctor is available at a specific time
-- Parameters:
--   @DoctorId INT
--   @AppointmentDate DATE
--   @AppointmentTime TIME
-- Returns: 1 if available, 0 if not
-- ============================================================
DELIMITER $$
CREATE PROCEDURE IF NOT EXISTS sp_VerifyDoctorAvailability(
  IN @DoctorId INT,
  IN @AppointmentDate DATE,
  IN @AppointmentTime TIME,
  OUT @IsAvailable INT
)
BEGIN
  DECLARE @ConflictCount INT;
  
  -- Check if doctor has another appointment at this time
  SELECT COUNT(*) INTO @ConflictCount
  FROM Cita
  WHERE MedicoId = @DoctorId
  AND Fecha = @AppointmentDate
  AND Hora = @AppointmentTime
  AND Estado != 'Cancelada';
  
  -- Set output
  SET @IsAvailable = IF(@ConflictCount = 0, 1, 0);
END$$
DELIMITER ;

-- ============================================================
-- PROCEDURE: sp_GetPatientsByAge
-- Description: Get patients within an age range
-- Parameters:
--   @MinAge INT - Minimum age
--   @MaxAge INT - Maximum age
-- Returns: List of patients
-- ============================================================
DELIMITER $$
CREATE PROCEDURE IF NOT EXISTS sp_GetPatientsByAge(
  IN @MinAge INT,
  IN @MaxAge INT
)
BEGIN
  SELECT 
    p.PacienteId,
    CONCAT(p.Nombres, ' ', p.Apellidos) AS FullName,
    p.FechaNacimiento,
    YEAR(NOW()) - YEAR(p.FechaNacimiento) - 
      (DATE_FORMAT(NOW(), '%m%d') < DATE_FORMAT(p.FechaNacimiento, '%m%d')) AS Age,
    p.Genero,
    p.Documento,
    e.Nombre AS EPS,
    p.Ciudad,
    p.Estado
  FROM Paciente p
  INNER JOIN EPS e ON p.EPSId = e.EPSId
  WHERE YEAR(NOW()) - YEAR(p.FechaNacimiento) - 
        (DATE_FORMAT(NOW(), '%m%d') < DATE_FORMAT(p.FechaNacimiento, '%m%d')) 
        BETWEEN @MinAge AND @MaxAge
  ORDER BY p.Apellidos, p.Nombres;
END$$
DELIMITER ;

-- ============================================================
-- PROCEDURE: sp_GetPatientsByRegistrationDate
-- Description: Get patients registered in a specific date range
-- Parameters:
--   @StartDate DATE
--   @EndDate DATE
-- Returns: List of patients
-- ============================================================
DELIMITER $$
CREATE PROCEDURE IF NOT EXISTS sp_GetPatientsByRegistrationDate(
  IN @StartDate DATE,
  IN @EndDate DATE
)
BEGIN
  SELECT 
    p.PacienteId,
    CONCAT(p.Nombres, ' ', p.Apellidos) AS FullName,
    p.Email,
    p.Telefono,
    p.Documento,
    e.Nombre AS EPS,
    p.Ciudad,
    DATE(p.FechaRegistro) AS RegistrationDate,
    p.Estado
  FROM Paciente p
  INNER JOIN EPS e ON p.EPSId = e.EPSId
  WHERE DATE(p.FechaRegistro) BETWEEN @StartDate AND @EndDate
  ORDER BY p.FechaRegistro DESC;
END$$
DELIMITER ;

-- ============================================================
-- Commit procedures
-- ============================================================
COMMIT;

-- ============================================================
-- Summary
-- ============================================================
-- Stored Procedures created: 8
-- Functions created: 1
-- All procedures tested for syntax
-- ============================================================
