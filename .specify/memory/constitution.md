# CLINICA SAN MANOTAS - Constitution

## Core Principles

### I. Separación de Capas (Layered Architecture)
Arquitectura de capas clara: Presentación (UI) → Lógica de Negocio (BLL) → Acceso a Datos (DAL) → Base de Datos. Cada capa debe ser independiente y testeable.

### II. Seguridad por Defecto (Security First)
Validación de entrada en TODAS las capas, hashing seguro de contraseñas (bcrypt/Argon2), encriptación de conexión a BD, prevención de SQL Injection, control de acceso RBAC.

### III. Manejo Robusto de Errores
Ningún error debe causar cierre inesperado. Logging centralizado, mensajes amigables al usuario, recuperación ante fallos de conexión, transacciones ACID.

### IV. Internacionalización (i18n)
Interfaz completamente traducible. Archivos de recursos (resx) separados, gestión centralizada de strings, formatos localizados (fechas, moneda).

### V. Testing Obligatorio
Unit tests para lógica de negocio (mínimo 70% cobertura). Integration tests para flujos críticos. TDD donde sea posible.

### VI. Código Limpio y Documentado
SOLID principles, nombres significativos, XML comments en métodos públicos, sin hardcoding de configuración.

## Security Requirements

- Autenticación obligatoria para todo usuario
- Almacenamiento seguro de contraseñas (nunca texto plano)
- Encriptación TLS para conexión a BD
- Validación paramétrica en todas las consultas SQL
- Audit log de operaciones críticas
- Timeouts de sesión configurables

## Technology Stack - REQUIRED

- C# 10+ (.NET 8 Windows Forms)
- Entity Framework Core 8 (ORM)
- MySQL 8.0+ (Base de Datos)
- Newtonsoft.Json (Serialización)
- NLog o Serilog (Logging)
- xUnit o NUnit (Testing)

## Quality Gates - NON-NEGOTIABLE

✓ Código sin warnings de compilación
✓ Todas las entidades con validaciones
✓ Scripts BD con versionamiento
✓ UI responsive y accesible
✓ Manejo de excepciones en todos los métodos públicos
✓ Sin hardcoding de strings o configuración
✓ Sin acceso directo a BD desde UI

## Governance

Esta constitución prevalece sobre todas las otras prácticas. Cualquier violación debe ser documentada y justificada. Cambios requieren revisión de arquitectura.

**Version**: 1.0.0 | **Ratified**: 2025-12-05 | **Last Amended**: 2025-12-05
