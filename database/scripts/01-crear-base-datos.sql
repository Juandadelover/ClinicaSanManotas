-- ============================================
-- CLINICA SAN MANOTAS - Script de Creación
-- Ejecutar primero este script
-- ============================================

DROP DATABASE IF EXISTS clinica_san_manotas;
CREATE DATABASE clinica_san_manotas CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;
USE clinica_san_manotas;

-- Tabla EPS
CREATE TABLE eps (
    EPSId INT NOT NULL AUTO_INCREMENT,
    Nombre VARCHAR(100) NOT NULL,
    Nit VARCHAR(20) NOT NULL,
    Telefono VARCHAR(20),
    Email VARCHAR(100),
    Contacto VARCHAR(100),
    FechaRegistro DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    Estado ENUM('Activa','Inactiva') NOT NULL DEFAULT 'Activa',
    PRIMARY KEY (EPSId),
    UNIQUE KEY (Nombre),
    UNIQUE KEY (Nit)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- Tabla Especialidad
CREATE TABLE especialidad (
    EspecialidadId INT NOT NULL AUTO_INCREMENT,
    Nombre VARCHAR(100) NOT NULL,
    Descripcion TEXT,
    PRIMARY KEY (EspecialidadId),
    UNIQUE KEY (Nombre)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- Tabla Usuario
CREATE TABLE usuario (
    UserId INT NOT NULL AUTO_INCREMENT,
    Username VARCHAR(50) NOT NULL,
    Email VARCHAR(100) NOT NULL,
    PasswordHash VARCHAR(255) NOT NULL,
    Foto LONGBLOB,
    Role ENUM('Admin','Recepcionista','Doctor') NOT NULL,
    FechaCreacion DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    FechaUltimoLogin DATETIME,
    Estado ENUM('Activo','Inactivo','Bloqueado') NOT NULL DEFAULT 'Activo',
    PRIMARY KEY (UserId),
    UNIQUE KEY (Username),
    UNIQUE KEY (Email)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- Tabla Medico
CREATE TABLE medico (
    MedicoId INT NOT NULL AUTO_INCREMENT,
    Nombres VARCHAR(100) NOT NULL,
    Apellidos VARCHAR(100) NOT NULL,
    Email VARCHAR(100) NOT NULL,
    Telefono VARCHAR(20) NOT NULL,
    Licencia VARCHAR(50) NOT NULL,
    EspecialidadId INT NOT NULL,
    HorarioInicio TIME NOT NULL,
    HorarioFin TIME NOT NULL,
    DiasAtencion VARCHAR(50) NOT NULL DEFAULT 'Lunes-Viernes',
    FechaRegistro DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    Estado ENUM('Activo','Inactivo','Licencia') NOT NULL DEFAULT 'Activo',
    UserId INT,
    PRIMARY KEY (MedicoId),
    UNIQUE KEY (Email),
    UNIQUE KEY (Licencia),
    UNIQUE KEY (UserId),
    CONSTRAINT fk_medico_especialidad FOREIGN KEY (EspecialidadId) REFERENCES especialidad(EspecialidadId),
    CONSTRAINT fk_medico_usuario FOREIGN KEY (UserId) REFERENCES usuario(UserId) ON DELETE SET NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- Tabla Paciente
CREATE TABLE paciente (
    PacienteId INT NOT NULL AUTO_INCREMENT,
    Nombres VARCHAR(100) NOT NULL,
    Apellidos VARCHAR(100) NOT NULL,
    Email VARCHAR(100),
    Telefono VARCHAR(20) NOT NULL,
    FechaNacimiento DATE NOT NULL,
    Genero ENUM('M','F','Otro') NOT NULL,
    Documento VARCHAR(20) NOT NULL,
    EPSId INT NOT NULL,
    Direccion VARCHAR(200) NOT NULL,
    Ciudad VARCHAR(100) NOT NULL,
    FechaRegistro DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    Estado ENUM('Activo','Inactivo','Suspendido') NOT NULL DEFAULT 'Activo',
    PRIMARY KEY (PacienteId),
    UNIQUE KEY (Documento),
    CONSTRAINT fk_paciente_eps FOREIGN KEY (EPSId) REFERENCES eps(EPSId)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- Tabla Cita
CREATE TABLE cita (
    CitaId INT NOT NULL AUTO_INCREMENT,
    PacienteId INT NOT NULL,
    MedicoId INT NOT NULL,
    Fecha DATE NOT NULL,
    Hora TIME NOT NULL,
    Motivo VARCHAR(500) NOT NULL,
    Estado ENUM('Pendiente','Confirmada','Cancelada','Realizada') NOT NULL DEFAULT 'Pendiente',
    Notas TEXT,
    FechaCreacion DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    FechaActualizacion DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    PRIMARY KEY (CitaId),
    UNIQUE KEY idx_no_duplicadas (MedicoId, Fecha, Hora),
    CONSTRAINT fk_cita_paciente FOREIGN KEY (PacienteId) REFERENCES paciente(PacienteId),
    CONSTRAINT fk_cita_medico FOREIGN KEY (MedicoId) REFERENCES medico(MedicoId)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- Tabla AuditLog
CREATE TABLE auditlog (
    AuditId INT NOT NULL AUTO_INCREMENT,
    UserId INT,
    Tabla VARCHAR(100) NOT NULL,
    RegistroId INT NOT NULL,
    Operacion ENUM('INSERT','UPDATE','DELETE') NOT NULL,
    ValoresAnteriores JSON,
    ValoresNuevos JSON,
    FechaOperacion DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    PRIMARY KEY (AuditId)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

SELECT 'Base de datos creada correctamente' AS Resultado;
