-- Script para insertar datos de prueba en la tabla cita
USE clinica_san_manotas;

-- Limpiar citas previas (opcional)
-- DELETE FROM cita;

-- Insertar 10 citas de prueba con datos válidos
-- Médicos disponibles: 17, 18, 19, 20, 21, 22, 23, 24, 31
-- Pacientes disponibles: 1-12
INSERT INTO cita (PacienteId, MedicoId, Fecha, Hora, Motivo, Estado, Notas) VALUES
(1, 17, '2025-12-11', '09:00:00', 'Consulta general de rutina', 'Confirmada', 'Paciente asintomatico'),
(2, 18, '2025-12-11', '14:30:00', 'Seguimiento post-operatorio', 'Confirmada', 'Control de cicatrizacion'),
(3, 19, '2025-12-12', '10:15:00', 'Revision de lunares', 'Pendiente', 'Primer consulta'),
(4, 20, '2025-12-12', '11:00:00', 'Control de vision', 'Confirmada', 'Revision anual'),
(5, 21, '2025-12-13', '15:00:00', 'Limpieza dental', 'Pendiente', 'Profilaxis'),
(1, 22, '2025-12-13', '09:30:00', 'Control de diabetes', 'Confirmada', 'Seguimiento glicemia'),
(6, 23, '2025-12-14', '10:00:00', 'Electrocardiograma', 'Pendiente', 'Control preventivo'),
(7, 24, '2025-12-14', '13:00:00', 'Endoscopia digestiva', 'Cancelada', 'Reagendar'),
(8, 31, '2025-12-15', '11:30:00', 'Consulta neurologica', 'Realizada', 'Completada exitosamente'),
(9, 17, '2025-12-11', '16:00:00', 'Evaluacion psicologica', 'Pendiente', 'Primera sesion');

SELECT COUNT(*) as Total_Citas FROM cita;
SELECT CitaId, (SELECT Nombres FROM paciente p WHERE p.PacienteId = cita.PacienteId) as Paciente,
       (SELECT Nombres FROM medico m WHERE m.MedicoId = cita.MedicoId) as Medico,
       Fecha, Hora, Estado FROM cita ORDER BY CitaId DESC LIMIT 10;
