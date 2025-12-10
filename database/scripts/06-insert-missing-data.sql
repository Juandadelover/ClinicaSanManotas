-- ============================================================
-- CLINICA SAN MANOTAS - Insert Missing Data
-- Inserta Médicos, Pacientes y Citas que faltan
-- ============================================================

USE clinica_san_manotas;

-- ============================================================
-- INSERT: Medico (Doctors)
-- ============================================================
INSERT INTO Medico (Nombres, Apellidos, Email, Telefono, Licencia, EspecialidadId, HorarioInicio, HorarioFin, DiasAtencion, Estado) VALUES
('Juan Carlos', 'García López', 'dr_garcia@clinicamanotas.com', '+573001234567', 'MED001', 11, '08:00:00', '17:00:00', 'Lunes-Viernes', 'Activo'),
('María', 'Martínez Rodríguez', 'dr_martinez@clinicamanotas.com', '+573009876543', 'MED002', 13, '07:00:00', '16:00:00', 'Lunes-Viernes', 'Activo'),
('Luis Felipe', 'Pérez Silva', 'luis.perez@clinicamanotas.com', '+573005555555', 'MED003', 12, '09:00:00', '18:00:00', 'Martes-Sábado', 'Activo'),
('Sandra', 'Ramírez Gómez', 'sandra.ramirez@clinicamanotas.com', '+573003333333', 'MED004', 14, '10:00:00', '19:00:00', 'Lunes-Viernes', 'Activo'),
('Carlos', 'López Hernández', 'carlos.lopez@clinicamanotas.com', '+573007777777', 'MED005', 15, '08:30:00', '17:30:00', 'Lunes-Viernes', 'Activo'),
('Ana María', 'González García', 'ana.gonzalez@clinicamanotas.com', '+573004444444', 'MED006', 16, '08:00:00', '17:00:00', 'Lunes-Viernes', 'Activo'),
('Roberto', 'Sánchez Díaz', 'roberto.sanchez@clinicamanotas.com', '+573002222222', 'MED007', 17, '09:00:00', '18:00:00', 'Lunes-Viernes', 'Activo'),
('Patricia', 'Ruiz Torres', 'patricia.ruiz@clinicamanotas.com', '+573008888888', 'MED008', 18, '07:00:00', '16:00:00', 'Lunes-Sábado', 'Activo');

-- ============================================================
-- INSERT: Paciente (Sample Patients)
-- ============================================================
INSERT INTO Paciente (Nombres, Apellidos, Email, Telefono, FechaNacimiento, Genero, Documento, EPSId, Direccion, Ciudad, Estado) VALUES
('Pedro', 'González Ramírez', 'pedro.gonzalez@email.com', '+573101234567', '1985-03-15', 'M', '79512345', 9, 'Calle 123 #45-67', 'Bogotá', 'Activo'),
('María', 'López García', 'maria.lopez@email.com', '+573109876543', '1990-07-22', 'F', '52987654', 10, 'Carrera 50 #12-34', 'Medellín', 'Activo'),
('Juan', 'Pérez Martínez', 'juan.perez@email.com', '+573105555555', '1980-11-08', 'M', '88765432', 11, 'Avenida 19 #8-90', 'Cali', 'Activo'),
('Ana', 'Rodríguez Silva', 'ana.rodriguez@email.com', '+573103333333', '1995-05-12', 'F', '45123456', 12, 'Calle 5 #20-40', 'Barranquilla', 'Activo'),
('Carlos', 'García Díaz', 'carlos.garcia@email.com', '+573107777777', '1988-09-30', 'M', '67543210', 13, 'Carrera 7 #15-25', 'Bucaramanga', 'Activo'),
('Sandra', 'Martínez López', 'sandra.martinez@email.com', '+573102222222', '1992-02-18', 'F', '56234567', 14, 'Calle 10 #30-50', 'Cúcuta', 'Activo'),
('Fernando', 'Silva García', 'fernando.silva@email.com', '+573108888888', '1987-08-25', 'M', '78901234', 15, 'Avenida 6 #40-60', 'Pasto', 'Activo'),
('Rosa', 'Gómez Ramírez', 'rosa.gomez@email.com', '+573104444444', '1993-12-03', 'F', '34567890', 16, 'Carrera 45 #5-15', 'Santa Marta', 'Activo'),
('Miguel', 'Torres Hernández', 'miguel.torres@email.com', '+573106666666', '1986-04-14', 'M', '91234567', 9, 'Calle 25 #50-70', 'Bogotá', 'Activo'),
('Isabel', 'Flores García', 'isabel.flores@email.com', '+573110000000', '1991-06-09', 'F', '23456789', 10, 'Avenida 11 #22-44', 'Medellín', 'Activo');

-- ============================================================
-- INSERT: Cita (Sample Appointments)
-- ============================================================
INSERT INTO Cita (PacienteId, MedicoId, Fecha, Hora, Motivo, Estado) VALUES
(1, 1, DATE_ADD(CURDATE(), INTERVAL 5 DAY), '10:00:00', 'Control de presión arterial', 'Confirmada'),
(2, 2, DATE_ADD(CURDATE(), INTERVAL 7 DAY), '14:30:00', 'Revisión general', 'Pendiente'),
(3, 3, DATE_ADD(CURDATE(), INTERVAL 3 DAY), '09:00:00', 'Consulta dermatológica', 'Confirmada'),
(4, 4, DATE_ADD(CURDATE(), INTERVAL 6 DAY), '11:00:00', 'Limpieza dental', 'Pendiente'),
(5, 5, DATE_ADD(CURDATE(), INTERVAL 4 DAY), '15:00:00', 'Revisión oftalmológica', 'Confirmada'),
(6, 6, DATE_ADD(CURDATE(), INTERVAL 8 DAY), '10:30:00', 'Evaluación ORL', 'Pendiente'),
(7, 7, DATE_ADD(CURDATE(), INTERVAL 2 DAY), '13:00:00', 'Consulta pediátrica', 'Confirmada'),
(8, 8, DATE_ADD(CURDATE(), INTERVAL 10 DAY), '09:30:00', 'Evaluación traumatológica', 'Pendiente'),
(1, 1, DATE_ADD(CURDATE(), INTERVAL 12 DAY), '16:00:00', 'Seguimiento cardíaco', 'Pendiente'),
(2, 2, DATE_ADD(CURDATE(), INTERVAL 9 DAY), '08:30:00', 'Chequeo de rutina', 'Confirmada');

-- ============================================================
-- Verification
-- ============================================================
SELECT 'DATOS INSERTADOS EXITOSAMENTE' as Estado;

SELECT CONCAT('Médicos: ', COUNT(*)) as Total FROM Medico;
SELECT CONCAT('Pacientes: ', COUNT(*)) as Total FROM Paciente;
SELECT CONCAT('Citas: ', COUNT(*)) as Total FROM Cita;

-- Display inserted data
SELECT '--- MEDICOS INSERTADOS ---' as Info;
SELECT MedicoId, CONCAT(Nombres, ' ', Apellidos) as Medico FROM Medico;

SELECT '--- PACIENTES INSERTADOS ---' as Info;
SELECT PacienteId, CONCAT(Nombres, ' ', Apellidos) as Paciente FROM Paciente;

SELECT '--- CITAS INSERTADAS ---' as Info;
SELECT CitaId, Fecha, Hora FROM Cita;

COMMIT;
