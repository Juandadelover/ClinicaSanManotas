-- ============================================
-- CLINICA SAN MANOTAS - Datos Iniciales
-- Ejecutar después de crear la base de datos
-- ============================================

USE clinica_san_manotas;

-- EPS
INSERT INTO eps (Nombre, Nit, Telefono, Email, Contacto) VALUES
('SURA', '800161056', '+57 1 5938300', 'contacto@sura.com', 'Servicio al Cliente'),
('Axa Colpatria', '830001815', '+57 1 5917070', 'servicio@axacolpatria.com.co', 'Atención al Cliente'),
('Coomeva', '860002608', '+57 1 5910000', 'contacto@coomeva.com.co', 'Centro de Atención'),
('Sanitas', '901034942', '+57 1 4249000', 'info@sanitas.com.co', 'Servicio al Cliente'),
('Compensar', '860001069', '+57 1 2001000', 'contact@compensar.com.co', 'Atención al Afiliado'),
('Famisanar', '860001503', '+57 1 6000700', 'servicios@famisanar.com.co', 'Central de Atención'),
('Salud Total', '860002609', '+57 1 3100900', 'info@saludtotal.com.co', 'Servicio al Cliente'),
('Digna', '899001487', '+57 1 3000300', 'contact@dignasalud.com.co', 'Centro de Llamadas');

-- Especialidades
INSERT INTO especialidad (Nombre, Descripcion) VALUES
('Cardiología', 'Diagnóstico y tratamiento de enfermedades del corazón'),
('Dermatología', 'Enfermedades de la piel'),
('Medicina General', 'Atención médica general y diagnóstico inicial'),
('Odontología', 'Cuidado de dientes y encías'),
('Oftalmología', 'Tratamiento de enfermedades del ojo'),
('Otorrinolaringología', 'Oído, nariz y garganta'),
('Pediatría', 'Cuidado médico de niños'),
('Traumatología', 'Lesiones del aparato locomotor'),
('Neurología', 'Enfermedades del sistema nervioso'),
('Psiquiatría', 'Trastornos mentales y emocionales');

-- Usuarios (contraseña: admin123 para admin, recep123 para recepcionistas, doctor123 para doctores)
-- Hash SHA256 de admin123: jZae727K08KaOmKSgOaGzww/XVqGr/PKEgIMkjrcbJI=
INSERT INTO usuario (Username, Email, PasswordHash, Role, Estado) VALUES
('admin', 'admin@clinicamanotas.com', 'jZae727K08KaOmKSgOaGzww/XVqGr/PKEgIMkjrcbJI=', 'Admin', 'Activo'),
('recepcionista1', 'recepcionista1@clinicamanotas.com', 'XTftMUzytchGK1KxLNUS4qxKGA51WY2k8Sv7DeptCmc=', 'Recepcionista', 'Activo'),
('recepcionista2', 'recepcionista2@clinicamanotas.com', 'XTftMUzytchGK1KxLNUS4qxKGA51WY2k8Sv7DeptCmc=', 'Recepcionista', 'Activo'),
('dr_garcia', 'garcia@clinicamanotas.com', '80jVYoYh89j1nIyr2g+OsKp+BRSpC+dXECCxM28mwRM=', 'Doctor', 'Activo'),
('dr_martinez', 'martinez@clinicamanotas.com', '80jVYoYh89j1nIyr2g+OsKp+BRSpC+dXECCxM28mwRM=', 'Doctor', 'Activo');

-- Médicos (con referencia a especialidades)
INSERT INTO medico (Nombres, Apellidos, Email, Telefono, Licencia, EspecialidadId, HorarioInicio, HorarioFin, DiasAtencion) VALUES
('Juan Carlos', 'García López', 'dr_garcia@clinicamanotas.com', '+573001234567', 'MED001', 1, '08:00:00', '17:00:00', 'Lunes-Viernes'),
('María', 'Martínez Rodríguez', 'dr_martinez@clinicamanotas.com', '+573009876543', 'MED002', 3, '07:00:00', '16:00:00', 'Lunes-Viernes'),
('Luis Felipe', 'Pérez Silva', 'luis.perez@clinicamanotas.com', '+573005555555', 'MED003', 2, '09:00:00', '18:00:00', 'Martes-Sábado'),
('Sandra', 'Ramírez Gómez', 'sandra.ramirez@clinicamanotas.com', '+573003333333', 'MED004', 4, '10:00:00', '19:00:00', 'Lunes-Viernes'),
('Carlos', 'López Hernández', 'carlos.lopez@clinicamanotas.com', '+573007777777', 'MED005', 5, '08:30:00', '17:30:00', 'Lunes-Viernes'),
('Ana María', 'González García', 'ana.gonzalez@clinicamanotas.com', '+573004444444', 'MED006', 6, '08:00:00', '17:00:00', 'Lunes-Viernes'),
('Roberto', 'Sánchez Díaz', 'roberto.sanchez@clinicamanotas.com', '+573002222222', 'MED007', 7, '09:00:00', '18:00:00', 'Lunes-Viernes'),
('Patricia', 'Ruiz Torres', 'patricia.ruiz@clinicamanotas.com', '+573008888888', 'MED008', 8, '07:00:00', '16:00:00', 'Lunes-Sábado');

-- Pacientes
INSERT INTO paciente (Nombres, Apellidos, Email, Telefono, FechaNacimiento, Genero, Documento, EPSId, Direccion, Ciudad) VALUES
('Pedro', 'González Ramírez', 'pedro.gonzalez@email.com', '+573101234567', '1985-03-15', 'M', '79512345', 5, 'Calle 123 #45-67', 'Bogotá'),
('María', 'López García', 'maria.lopez@email.com', '+573109876543', '1990-07-22', 'F', '52987654', 5, 'Carrera 50 #12-34', 'Medellín'),
('Juan', 'Pérez Martínez', 'juan.perez@email.com', '+573105555555', '1980-11-08', 'M', '88765432', 1, 'Avenida 19 #8-90', 'Cali'),
('Ana', 'Rodríguez Silva', 'ana.rodriguez@email.com', '+573103333333', '1995-05-12', 'F', '45123456', 4, 'Calle 5 #20-40', 'Barranquilla'),
('Carlos', 'García Díaz', 'carlos.garcia@email.com', '+573107777777', '1988-09-30', 'M', '67543210', 5, 'Carrera 7 #15-25', 'Bucaramanga'),
('Sandra', 'Martínez López', 'sandra.martinez@email.com', '+573102222222', '1992-02-18', 'F', '56234567', 6, 'Calle 10 #30-50', 'Cúcuta'),
('Fernando', 'Silva García', 'fernando.silva@email.com', '+573108888888', '1987-08-25', 'M', '78901234', 7, 'Avenida 6 #40-60', 'Pasto'),
('Rosa', 'Gómez Ramírez', 'rosa.gomez@email.com', '+573104444444', '1993-12-03', 'F', '34567890', 8, 'Carrera 45 #5-15', 'Santa Marta'),
('Miguel', 'Torres Hernández', 'miguel.torres@email.com', '+573106666666', '1986-04-14', 'M', '91234567', 1, 'Calle 25 #50-70', 'Bogotá'),
('Isabel', 'Flores García', 'isabel.flores@email.com', '+573110000000', '1991-06-09', 'F', '23456789', 2, 'Avenida 11 #22-44', 'Medellín');

-- Citas de ejemplo
INSERT INTO cita (PacienteId, MedicoId, Fecha, Hora, Motivo, Estado) VALUES
(1, 1, '2025-12-15', '09:00:00', 'Consulta General', 'Confirmada'),
(2, 2, '2025-12-15', '14:30:00', 'Seguimiento', 'Confirmada'),
(3, 3, '2025-12-16', '10:15:00', 'Revisión', 'Pendiente'),
(4, 4, '2025-12-16', '11:00:00', 'Limpieza dental', 'Confirmada'),
(5, 5, '2025-12-17', '15:00:00', 'Control visual', 'Pendiente'),
(6, 6, '2025-12-17', '09:30:00', 'Consulta oído', 'Confirmada'),
(7, 7, '2025-12-18', '10:00:00', 'Control pediátrico', 'Pendiente'),
(8, 8, '2025-12-18', '13:00:00', 'Dolor de rodilla', 'Pendiente'),
(9, 1, '2025-12-19', '11:30:00', 'Chequeo cardiológico', 'Pendiente'),
(10, 2, '2025-12-19', '16:00:00', 'Consulta general', 'Pendiente');

SELECT 'Datos insertados correctamente' AS Resultado;
SELECT CONCAT(COUNT(*), ' EPS') AS Registros FROM eps
UNION SELECT CONCAT(COUNT(*), ' Especialidades') FROM especialidad
UNION SELECT CONCAT(COUNT(*), ' Usuarios') FROM usuario
UNION SELECT CONCAT(COUNT(*), ' Médicos') FROM medico
UNION SELECT CONCAT(COUNT(*), ' Pacientes') FROM paciente
UNION SELECT CONCAT(COUNT(*), ' Citas') FROM cita;
