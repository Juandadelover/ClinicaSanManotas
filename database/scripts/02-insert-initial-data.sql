-- ============================================================
-- CLINICA SAN MANOTAS - Initial Data Script
-- Version: 1.0.0
-- Date: 2025-12-05
-- Description: Insert reference data and test users
-- NOTE: Passwords are bcrypt hashes. To generate new ones use:
--       BCrypt.Net-Next: BCrypt.HashPassword("password", 12)
-- ============================================================

USE clinica_san_manotas;

-- ============================================================
-- INSERT: Especialidades (Medical Specialties)
-- ============================================================
INSERT INTO Especialidad (Nombre, Descripcion) VALUES
('Cardiología', 'Especialidad dedicada al diagnóstico y tratamiento de enfermedades del corazón'),
('Dermatología', 'Especialidad enfocada en enfermedades de la piel'),
('Medicina General', 'Atención médica general y diagnóstico inicial'),
('Odontología', 'Cuidado y tratamiento de dientes y encías'),
('Oftalmología', 'Tratamiento de enfermedades del ojo'),
('Otorrinolaringología', 'Especialidad de oído, nariz y garganta'),
('Pediatría', 'Cuidado médico de niños y adolescentes'),
('Traumatología', 'Tratamiento de lesiones y enfermedades del aparato locomotor'),
('Neurología', 'Diagnóstico y tratamiento de enfermedades del sistema nervioso'),
('Psiquiatría', 'Tratamiento de trastornos mentales y emocionales');

-- ============================================================
-- INSERT: EPS (Health Insurance Companies)
-- ============================================================
INSERT INTO EPS (Nombre, Nit, Telefono, Email, Contacto, Estado) VALUES
('SURA', '800161056', '+57 1 5938300', 'contacto@sura.com', 'Departamento Servicio al Cliente', 'Activa'),
('Axa Colpatria', '830001815', '+57 1 5917070', 'servicio@axacolpatria.com.co', 'Atención al Cliente', 'Activa'),
('Coomeva', '860002608', '+57 1 5910000', 'contacto@coomeva.com.co', 'Centro de Atención', 'Activa'),
('Sanitas', '901034942', '+57 1 4249000', 'info@sanitas.com.co', 'Servicio al Cliente', 'Activa'),
('Compensar', '860001069', '+57 1 2001000', 'contact@compensar.com.co', 'Atención al Afiliado', 'Activa'),
('Famisanar', '860001503', '+57 1 6000700', 'servicios@famisanar.com.co', 'Central de Atención', 'Activa'),
('Salud Total', '860002609', '+57 1 3100900', 'info@saludtotal.com.co', 'Servicio al Cliente', 'Activa'),
('Digna', '899001487', '+57 1 3000300', 'contact@dignasalud.com.co', 'Centro de Llamadas', 'Activa');

-- ============================================================
-- INSERT: Usuario (System Users - Test Accounts)
-- ============================================================
-- Note: Password hashes are SHA256 Base64 encoded. For testing purposes only.
-- Admin user password: admin123
-- Recepcionista password: recep123
-- Doctor password: doctor123

INSERT INTO Usuario (Username, Email, PasswordHash, Role, Estado) VALUES
-- Admin user (password: admin123)
-- SHA256 Base64 hash for "admin123"
('admin', 'admin@clinicamanotas.com', 'JAvlGPq9JyTdtvBO6x2llnRI1+gxwIyPqCKAn3THIKk=', 'Admin', 'Activo'),

-- Recepcionista users (password: recep123)
-- SHA256 Base64 hash for "recep123"
('recepcionista1', 'recepcionista1@clinicamanotas.com', 'XTftMUzytchGK1KxLNUS4qxKGA51WY2k8Sv7DeptCmc=', 'Recepcionista', 'Activo'),
('recepcionista2', 'recepcionista2@clinicamanotas.com', 'XTftMUzytchGK1KxLNUS4qxKGA51WY2k8Sv7DeptCmc=', 'Recepcionista', 'Activo'),

-- Doctor users (password: doctor123)
-- SHA256 Base64 hash for "doctor123"
('dr_garcia', 'garcia@clinicamanotas.com', '80jVYoYh89j1nIyr2g+OsKp+BRSpC+dXECCxM28mwRM=', 'Doctor', 'Activo'),
('dr_martinez', 'martinez@clinicamanotas.com', '80jVYoYh89j1nIyr2g+OsKp+BRSpC+dXECCxM28mwRM=', 'Doctor', 'Activo');

-- ============================================================
-- INSERT: Medico (Doctors)
-- ============================================================
INSERT INTO Medico (Nombres, Apellidos, Email, Telefono, Licencia, EspecialidadId, HorarioInicio, HorarioFin, DiasAtencion, Estado) VALUES
('Juan Carlos', 'García López', 'dr_garcia@clinicamanotas.com', '+573001234567', 'MED001', 1, '08:00:00', '17:00:00', 'Lunes-Viernes', 'Activo'),
('María', 'Martínez Rodríguez', 'dr_martinez@clinicamanotas.com', '+573009876543', 'MED002', 3, '07:00:00', '16:00:00', 'Lunes-Viernes', 'Activo'),
('Luis Felipe', 'Pérez Silva', 'luis.perez@clinicamanotas.com', '+573005555555', 'MED003', 2, '09:00:00', '18:00:00', 'Martes-Sábado', 'Activo'),
('Sandra', 'Ramírez Gómez', 'sandra.ramirez@clinicamanotas.com', '+573003333333', 'MED004', 4, '10:00:00', '19:00:00', 'Lunes-Viernes', 'Activo'),
('Carlos', 'López Hernández', 'carlos.lopez@clinicamanotas.com', '+573007777777', 'MED005', 5, '08:30:00', '17:30:00', 'Lunes-Viernes', 'Activo'),
('Ana María', 'González García', 'ana.gonzalez@clinicamanotas.com', '+573004444444', 'MED006', 6, '08:00:00', '17:00:00', 'Lunes-Viernes', 'Activo'),
('Roberto', 'Sánchez Díaz', 'roberto.sanchez@clinicamanotas.com', '+573002222222', 'MED007', 7, '09:00:00', '18:00:00', 'Lunes-Viernes', 'Activo'),
('Patricia', 'Ruiz Torres', 'patricia.ruiz@clinicamanotas.com', '+573008888888', 'MED008', 8, '07:00:00', '16:00:00', 'Lunes-Sábado', 'Activo');

-- ============================================================
-- INSERT: Paciente (Sample Patients)
-- ============================================================
INSERT INTO Paciente (Nombres, Apellidos, Email, Telefono, FechaNacimiento, Genero, Documento, EPSId, Direccion, Ciudad, Estado) VALUES
('Pedro', 'González Ramírez', 'pedro.gonzalez@email.com', '+573101234567', '1985-03-15', 'M', '79512345', 1, 'Calle 123 #45-67', 'Bogotá', 'Activo'),
('María', 'López García', 'maria.lopez@email.com', '+573109876543', '1990-07-22', 'F', '52987654', 2, 'Carrera 50 #12-34', 'Medellín', 'Activo'),
('Juan', 'Pérez Martínez', 'juan.perez@email.com', '+573105555555', '1980-11-08', 'M', '88765432', 3, 'Avenida 19 #8-90', 'Cali', 'Activo'),
('Ana', 'Rodríguez Silva', 'ana.rodriguez@email.com', '+573103333333', '1995-05-12', 'F', '45123456', 4, 'Calle 5 #20-40', 'Barranquilla', 'Activo'),
('Carlos', 'García Díaz', 'carlos.garcia@email.com', '+573107777777', '1988-09-30', 'M', '67543210', 5, 'Carrera 7 #15-25', 'Bucaramanga', 'Activo'),
('Sandra', 'Martínez López', 'sandra.martinez@email.com', '+573102222222', '1992-02-18', 'F', '56234567', 6, 'Calle 10 #30-50', 'Cúcuta', 'Activo'),
('Fernando', 'Silva García', 'fernando.silva@email.com', '+573108888888', '1987-08-25', 'M', '78901234', 7, 'Avenida 6 #40-60', 'Pasto', 'Activo'),
('Rosa', 'Gómez Ramírez', 'rosa.gomez@email.com', '+573104444444', '1993-12-03', 'F', '34567890', 8, 'Carrera 45 #5-15', 'Santa Marta', 'Activo'),
('Miguel', 'Torres Hernández', 'miguel.torres@email.com', '+573106666666', '1986-04-14', 'M', '91234567', 1, 'Calle 25 #50-70', 'Bogotá', 'Activo'),
('Isabel', 'Flores García', 'isabel.flores@email.com', '+573110000000', '1991-06-09', 'F', '23456789', 2, 'Avenida 11 #22-44', 'Medellín', 'Activo');

-- ============================================================
-- INSERT: Cita (Sample Appointments)
-- ============================================================
-- Note: Using dates relative to today for demo purposes
-- In production, adjust dates appropriately

INSERT INTO Cita (PacienteId, MedicoId, Fecha, Hora, Motivo, Estado) VALUES
(1, 1, DATE_ADD(CURDATE(), INTERVAL 5 DAY), '10:00:00', 'Control de presión arterial', 'Confirmada'),
(2, 2, DATE_ADD(CURDATE(), INTERVAL 7 DAY), '14:30:00', 'Revisión general', 'Pendiente'),
(3, 3, DATE_ADD(CURDATE(), INTERVAL 3 DAY), '09:00:00', 'Consulta dermatológica', 'Confirmada'),
(4, 4, DATE_ADD(CURDATE(), INTERVAL 6 DAY), '11:00:00', 'Limpieza dental', 'Pendiente'),
(5, 5, DATE_ADD(CURDATE(), INTERVAL 4 DAY), '15:00:00', 'Revisión oftalmológica', 'Confirmada'),
(6, 6, DATE_ADD(CURDATE(), INTERVAL 8 DAY), '10:30:00', 'Evaluación ORL', 'Pendiente'),
(7, 7, DATE_ADD(CURDATE(), INTERVAL 2 DAY), '13:00:00', 'Consulta pediátrica', 'Confirmada'),
(8, 8, DATE_ADD(CURDATE(), INTERVAL 10 DAY), '09:30:00', 'Evaluación traumatológica', 'Pendiente'),
(9, 1, DATE_ADD(CURDATE(), INTERVAL 12 DAY), '16:00:00', 'Seguimiento cardíaco', 'Pendiente'),
(10, 2, DATE_ADD(CURDATE(), INTERVAL 9 DAY), '08:30:00', 'Chequeo de rutina', 'Confirmada');

-- ============================================================
-- Record completed migrations
-- ============================================================
UPDATE migrations SET applied_at = NOW() WHERE name = '03-insert-initial-data';

COMMIT;

-- ============================================================
-- Summary of Initial Data
-- ============================================================
-- Especialidades inserted: 10
-- EPS companies inserted: 8
-- Users inserted: 5 (1 Admin, 2 Recepcionistas, 2 Doctors)
-- Doctors inserted: 8
-- Sample Patients inserted: 10
-- Sample Appointments inserted: 10
--
-- Ready for testing!
-- ============================================================
