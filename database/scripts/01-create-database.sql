-- ============================================================
-- CLINICA SAN MANOTAS - Database Creation Script
-- Version: 1.0.0
-- Date: 2025-12-05
-- Description: Complete database schema for clinic management system
-- ============================================================

-- Step 1: Create Database
DROP DATABASE IF EXISTS clinica_san_manotas;
CREATE DATABASE clinica_san_manotas 
  CHARACTER SET utf8mb4 
  COLLATE utf8mb4_unicode_ci;

USE clinica_san_manotas;

-- Step 2: Create Migrations Table (for version control)
CREATE TABLE IF NOT EXISTS migrations (
  id INT AUTO_INCREMENT PRIMARY KEY,
  name VARCHAR(255) NOT NULL UNIQUE,
  applied_at DATETIME DEFAULT CURRENT_TIMESTAMP,
  description VARCHAR(500) NULL
);

-- Step 3: Create main tables

-- ============================================================
-- TABLE: Usuario
-- ============================================================
CREATE TABLE IF NOT EXISTS Usuario (
  UserId INT AUTO_INCREMENT PRIMARY KEY,
  Username VARCHAR(50) NOT NULL UNIQUE,
  Email VARCHAR(100) NOT NULL UNIQUE,
  PasswordHash VARCHAR(255) NOT NULL COMMENT 'BCrypt hash',
  Foto LONGBLOB NULL,
  Role ENUM('Admin','Recepcionista','Doctor') NOT NULL,
  FechaCreacion DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
  FechaUltimoLogin DATETIME NULL,
  Estado ENUM('Activo','Inactivo','Bloqueado') NOT NULL DEFAULT 'Activo',
  
  INDEX idx_username (Username),
  INDEX idx_email (Email),
  INDEX idx_estado (Estado)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- ============================================================
-- TABLE: Especialidad
-- ============================================================
CREATE TABLE IF NOT EXISTS Especialidad (
  EspecialidadId INT AUTO_INCREMENT PRIMARY KEY,
  Nombre VARCHAR(100) NOT NULL UNIQUE,
  Descripcion TEXT NULL,
  
  INDEX idx_nombre (Nombre)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- ============================================================
-- TABLE: EPS
-- ============================================================
CREATE TABLE IF NOT EXISTS EPS (
  EPSId INT AUTO_INCREMENT PRIMARY KEY,
  Nombre VARCHAR(100) NOT NULL UNIQUE,
  Nit VARCHAR(20) NOT NULL UNIQUE,
  Telefono VARCHAR(20) NULL,
  Email VARCHAR(100) NULL,
  Contacto VARCHAR(100) NULL,
  FechaRegistro DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
  Estado ENUM('Activa','Inactiva') NOT NULL DEFAULT 'Activa',
  
  INDEX idx_nombre (Nombre),
  INDEX idx_nit (Nit),
  INDEX idx_estado (Estado)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- ============================================================
-- TABLE: Medico
-- ============================================================
CREATE TABLE IF NOT EXISTS Medico (
  MedicoId INT AUTO_INCREMENT PRIMARY KEY,
  Nombres VARCHAR(100) NOT NULL,
  Apellidos VARCHAR(100) NOT NULL,
  Email VARCHAR(100) NOT NULL UNIQUE,
  Telefono VARCHAR(20) NOT NULL,
  Licencia VARCHAR(50) NOT NULL UNIQUE COMMENT 'Professional license number',
  EspecialidadId INT NOT NULL,
  HorarioInicio TIME NOT NULL,
  HorarioFin TIME NOT NULL,
  DiasAtencion VARCHAR(50) NOT NULL DEFAULT 'Lunes-Viernes' COMMENT 'e.g., Lunes-Viernes',
  FechaRegistro DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
  Estado ENUM('Activo','Inactivo','Licencia') NOT NULL DEFAULT 'Activo',
  
  CONSTRAINT fk_medico_especialidad FOREIGN KEY (EspecialidadId) 
    REFERENCES Especialidad(EspecialidadId) ON DELETE RESTRICT,
  
  UNIQUE INDEX idx_licencia (Licencia),
  INDEX idx_especialidad (EspecialidadId),
  INDEX idx_estado (Estado),
  INDEX idx_email (Email)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- ============================================================
-- TABLE: Paciente
-- ============================================================
CREATE TABLE IF NOT EXISTS Paciente (
  PacienteId INT AUTO_INCREMENT PRIMARY KEY,
  Nombres VARCHAR(100) NOT NULL,
  Apellidos VARCHAR(100) NOT NULL,
  Email VARCHAR(100) NULL,
  Telefono VARCHAR(20) NOT NULL,
  FechaNacimiento DATE NOT NULL,
  Genero ENUM('M','F','Otro') NOT NULL,
  Documento VARCHAR(20) NOT NULL UNIQUE COMMENT 'National ID',
  EPSId INT NOT NULL,
  Direccion VARCHAR(200) NOT NULL,
  Ciudad VARCHAR(100) NOT NULL,
  FechaRegistro DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
  Estado ENUM('Activo','Inactivo','Suspendido') NOT NULL DEFAULT 'Activo',
  
  CONSTRAINT fk_paciente_eps FOREIGN KEY (EPSId) 
    REFERENCES EPS(EPSId) ON DELETE RESTRICT,
  
  UNIQUE INDEX idx_documento (Documento),
  INDEX idx_eps (EPSId),
  INDEX idx_genero (Genero),
  INDEX idx_fecha_nacimiento (FechaNacimiento),
  INDEX idx_estado (Estado),
  INDEX idx_ciudad (Ciudad)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- ============================================================
-- TABLE: Cita
-- ============================================================
CREATE TABLE IF NOT EXISTS Cita (
  CitaId INT AUTO_INCREMENT PRIMARY KEY,
  PacienteId INT NOT NULL,
  MedicoId INT NOT NULL,
  Fecha DATE NOT NULL,
  Hora TIME NOT NULL,
  Motivo VARCHAR(500) NOT NULL,
  Estado ENUM('Pendiente','Confirmada','Cancelada','Realizada') NOT NULL DEFAULT 'Pendiente',
  Notas TEXT NULL,
  FechaCreacion DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
  FechaActualizacion DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  
  CONSTRAINT fk_cita_paciente FOREIGN KEY (PacienteId) 
    REFERENCES Paciente(PacienteId) ON DELETE RESTRICT,
  CONSTRAINT fk_cita_medico FOREIGN KEY (MedicoId) 
    REFERENCES Medico(MedicoId) ON DELETE RESTRICT,
  
  UNIQUE INDEX idx_no_duplicadas (MedicoId, Fecha, Hora),
  INDEX idx_paciente (PacienteId),
  INDEX idx_medico (MedicoId),
  INDEX idx_fecha (Fecha),
  INDEX idx_estado (Estado),
  INDEX idx_paciente_fecha (PacienteId, Fecha)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- ============================================================
-- TABLE: AuditLog (for tracking important changes)
-- ============================================================
CREATE TABLE IF NOT EXISTS AuditLog (
  AuditId INT AUTO_INCREMENT PRIMARY KEY,
  UserId INT NULL,
  Tabla VARCHAR(100) NOT NULL,
  RegistroId INT NOT NULL,
  Operacion ENUM('INSERT','UPDATE','DELETE') NOT NULL,
  ValoresAnteriores JSON NULL,
  ValoresNuevos JSON NULL,
  FechaOperacion DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
  
  INDEX idx_tabla (Tabla),
  INDEX idx_usuario (UserId),
  INDEX idx_fecha (FechaOperacion)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- ============================================================
-- Record migrations
-- ============================================================
INSERT INTO migrations (name, description) VALUES
  ('01-create-database', 'Initial database and table creation'),
  ('02-create-indexes', 'Performance indexes'),
  ('03-insert-initial-data', 'Reference data (Especialidades, EPS)'),
  ('04-create-triggers', 'Database triggers for audit');

COMMIT;

-- ============================================================
-- Summary
-- ============================================================
-- Tables created: 8
-- - Usuario (authentication and system users)
-- - Especialidad (medical specialties - reference data)
-- - EPS (health insurance companies - reference data)
-- - Medico (doctors with schedule and specialty)
-- - Paciente (patients with insurance)
-- - Cita (appointments linking patients and doctors)
-- - AuditLog (audit trail for compliance)
-- - migrations (version control table)
--
-- All tables use InnoDB for ACID compliance
-- All text uses utf8mb4 for full Unicode support
-- ============================================================
