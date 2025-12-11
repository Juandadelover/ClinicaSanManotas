-- Script para crear usuarios de doctores en la BD
-- Contraseña: 123456
-- Hash SHA256 Base64: jZae727K08KaOmKSgOaGzww/XVqGr/PKEgIMkjrcbJI=

-- Primero, verificar que la tabla Usuario existe
-- Si no existe la columna UserId en Medico, agregarla
ALTER TABLE Medico ADD COLUMN UserId INT NULL UNIQUE;

-- Crear los usuarios de doctores
INSERT INTO Usuario (Username, Contraseña, Rol, Estado) VALUES
('luis_felipe', 'jZae727K08KaOmKSgOaGzww/XVqGr/PKEgIMkjrcbJI=', 'Doctor', 'Activo'),
('sandra_ramirez', 'jZae727K08KaOmKSgOaGzww/XVqGr/PKEgIMkjrcbJI=', 'Doctor', 'Activo'),
('carlos_lopez', 'jZae727K08KaOmKSgOaGzww/XVqGr/PKEgIMkjrcbJI=', 'Doctor', 'Activo'),
('roberto_sanchez', 'jZae727K08KaOmKSgOaGzww/XVqGr/PKEgIMkjrcbJI=', 'Doctor', 'Activo'),
('patricia_ruiz', 'jZae727K08KaOmKSgOaGzww/XVqGr/PKEgIMkjrcbJI=', 'Doctor', 'Activo');

-- Relacionar usuarios con médicos (obtener IDs según la BD)
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

-- Verificar que los usuarios fueron creados y vinculados correctamente
SELECT u.UserId, u.Username, u.Rol, m.MedicoId, m.Nombres
FROM Usuario u
LEFT JOIN Medico m ON u.UserId = m.UserId
WHERE u.Rol = 'Doctor'
ORDER BY u.UserId;
