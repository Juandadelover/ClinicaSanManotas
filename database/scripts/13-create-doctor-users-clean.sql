-- Script para crear usuarios de doctores en la BD
-- Contraseña: 123456
-- Hash SHA256 Base64: jZae727K08KaOmKSgOaGzww/XVqGr/PKEgIMkjrcbJI=

-- Crear los usuarios de doctores
INSERT INTO Usuario (Username, Email, PasswordHash, Role, Estado) VALUES
('luis_felipe', 'luis.felipe@clinica.com', 'jZae727K08KaOmKSgOaGzww/XVqGr/PKEgIMkjrcbJI=', 'Doctor', 'Activo'),
('sandra_ramirez', 'sandra.ramirez@clinica.com', 'jZae727K08KaOmKSgOaGzww/XVqGr/PKEgIMkjrcbJI=', 'Doctor', 'Activo'),
('carlos_lopez', 'carlos.lopez@clinica.com', 'jZae727K08KaOmKSgOaGzww/XVqGr/PKEgIMkjrcbJI=', 'Doctor', 'Activo'),
('roberto_sanchez', 'roberto.sanchez@clinica.com', 'jZae727K08KaOmKSgOaGzww/XVqGr/PKEgIMkjrcbJI=', 'Doctor', 'Activo'),
('patricia_ruiz', 'patricia.ruiz@clinica.com', 'jZae727K08KaOmKSgOaGzww/XVqGr/PKEgIMkjrcbJI=', 'Doctor', 'Activo');

-- Relacionar usuarios con médicos
-- Luis Felipe Pérez Silva
UPDATE Medico SET UserId = (SELECT UserId FROM Usuario WHERE Username = 'luis_felipe') 
WHERE Nombres = 'Luis Felipe Pérez Silva';

-- Sandra Ramírez Gómez
UPDATE Medico SET UserId = (SELECT UserId FROM Usuario WHERE Username = 'sandra_ramirez') 
WHERE Nombres = 'Sandra Ramírez Gómez';

-- Carlos López Hernández
UPDATE Medico SET UserId = (SELECT UserId FROM Usuario WHERE Username = 'carlos_lopez') 
WHERE Nombres = 'Carlos López Hernández';

-- Roberto Sánchez Díaz
UPDATE Medico SET UserId = (SELECT UserId FROM Usuario WHERE Username = 'roberto_sanchez') 
WHERE Nombres = 'Roberto Sánchez Díaz';

-- Patricia Ruiz Torres
UPDATE Medico SET UserId = (SELECT UserId FROM Usuario WHERE Username = 'patricia_ruiz') 
WHERE Nombres = 'Patricia Ruiz Torres';

-- Verificar resultados
SELECT u.UserId, u.Username, u.Role, m.MedicoId, m.Nombres
FROM Usuario u
LEFT JOIN Medico m ON u.UserId = m.UserId
WHERE u.Role = 'Doctor'
ORDER BY u.UserId;
