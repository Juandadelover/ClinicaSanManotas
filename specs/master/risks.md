# CLINICA SAN MANOTAS - Análisis de Riesgos

**Versión**: 1.0.0 | **Fecha**: 2025-12-05 | **Matriz de Riesgos**: 12 riesgos identificados

---

## 📊 Matriz de Riesgos

| # | Riesgo | Probabilidad | Impacto | Severidad | Mitigación |
|---|--------|--------------|---------|-----------|-----------|
| R1 | Retrasos en implementación | 🟡 Media | 🔴 Alto | **🔴 CRÍTICO** | Sprint planning agresivo |
| R2 | Errores en validaciones BD | 🟡 Media | 🔴 Alto | **🔴 CRÍTICO** | Tests integración exhaustivos |
| R3 | Performance degradada | 🟢 Baja | 🟡 Medio | 🟡 MEDIO | Índices optimizados, caché |
| R4 | Falta de comprensión de reqs | 🟡 Media | 🟡 Medio | 🟡 MEDIO | Documentación detallada |
| R5 | Conflictos de datos concurrentes | 🟡 Media | 🔴 Alto | **🔴 CRÍTICO** | Transacciones ACID |
| R6 | Vulnerabilidades de seguridad | 🟢 Baja | 🔴 Alto | 🔴 CRÍTICO | Validación, Serilog, Hash |
| R7 | Incompatibilidad .NET 8 | 🟢 Baja | 🟡 Medio | 🟡 MEDIO | Testing en .NET 8.0 |
| R8 | Problemas con Entity Framework | 🟡 Media | 🟡 Medio | 🟡 MEDIO | Pruebas EF early |
| R9 | Deuda técnica acumulada | 🟡 Media | 🟡 Medio | 🟡 MEDIO | Code reviews regulares |
| R10 | Testing incompleto | 🟡 Media | 🟡 Medio | 🟡 MEDIO | 75% coverage target |
| R11 | Cambios en requisitos | 🟢 Baja | 🟡 Medio | 🟡 MEDIO | Speckit + documentación |
| R12 | Problemas MySQL versioning | 🟢 Baja | 🟡 Medio | 🟡 MEDIO | Scripts versionados |

---

## 🔴 RIESGOS CRÍTICOS

### R1: Retrasos en Implementación

**Descripción**  
Falta de tiempo/recursos para completar las 157 tareas en 63-79 horas estimadas.

**Probabilidad**: 🟡 Media (35%)  
**Impacto**: 🔴 Alto (Proyecto incompleto)  
**Severidad**: **🔴 CRÍTICO**

**Causas Raíz**:
- Subestimación de complejidad
- Interrupciones/cambios de scope
- Limitaciones de recursos
- Problemas técnicos inesperados

**Mitigación**:
1. ✅ Desglosen tareas en sprints de 1 semana
2. ✅ Daily standups de 15 minutos
3. ✅ Buffer del 20% en estimaciones
4. ✅ Identificar camino crítico: Phase 2 → US2 → US4
5. ✅ Paralelizar cuando sea posible

**Contingencia**:
- Priorizar: Auth → Patients → Appointments
- Diferir: Reportes, optimización avanzada
- Scope reduction: Cortar features no críticas

**Owner**: Project Manager  
**Review**: Semanal  

---

### R2: Errores en Validaciones de BD

**Descripción**  
Constraints, relaciones o validaciones incorrectas causan integridad de datos comprometida.

**Probabilidad**: 🟡 Media (40%)  
**Impacto**: 🔴 Alto (Data corruption)  
**Severidad**: **🔴 CRÍTICO**

**Causas Raíz**:
- Falta de sincronización entre modelo C# y BD
- Testing insuficiente de constraints
- Cambios no documentados en schema
- EF Core mapping incorrectos

**Mitigación**:
1. ✅ Validar constraints en scripts SQL (task T010)
2. ✅ Tests integración BD (T037-T040)
3. ✅ Verificar unique indexes: documento, licencia, username, email
4. ✅ Tests de integridad referencial: paciente → EPS, médico → especialidad
5. ✅ Tests de no-duplicidad: citas (medico, fecha, hora)

**Validaciones Críticas**:
```sql
-- Verificar constraints
SELECT CONSTRAINT_NAME, CONSTRAINT_TYPE 
FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS 
WHERE TABLE_NAME = 'Cita';

-- Verificar índices únicos
SHOW INDEX FROM Paciente WHERE Non_Unique=0;
```

**Contingencia**:
- Rollback a scripts anteriores si hay corrupción
- Restaurar desde backup si es necesario
- Reconstruir índices si se degradan

**Owner**: DBA / QA  
**Review**: Post-implementación de cada modelo

---

### R5: Conflictos de Datos Concurrentes

**Descripción**  
Múltiples usuarios editando simultáneamente causan sobrescritura o inconsistencia.

**Probabilidad**: 🟡 Media (30%)  
**Impacto**: 🔴 Alto (Data loss)  
**Severidad**: **🔴 CRÍTICO**

**Causas Raíz**:
- Falta de versionamiento optimista
- Transacciones no implementadas correctamente
- UnitOfWork no garantiza atomicidad
- Caché sin invalidación

**Mitigación**:
1. ✅ Implementar UnitOfWork con transacciones (T019)
2. ✅ Usar optimistic locking con timestamp o version
3. ✅ Implementar retry logic para conflictos
4. ✅ Tests concurrencia (T155)

**Implementación**:
```csharp
// Agregar a modelos
public byte[] RowVersion { get; set; }

// En DbContext
modelBuilder.Entity<Patient>()
    .Property(p => p.RowVersion)
    .IsRowVersion();
```

**Contingencia**:
- Detectar conflicto y pedir al usuario reintentar
- Usar last-write-wins como fallback
- Auditoría completa de cambios

**Owner**: Backend Lead  
**Review**: Code review de UnitOfWork

---

### R6: Vulnerabilidades de Seguridad

**Descripción**  
SQL Injection, contraseñas débiles, falta de validación causan breach de seguridad.

**Probabilidad**: 🟢 Baja (15%) - Mitigado por design  
**Impacto**: 🔴 Alto (Data breach)  
**Severidad**: 🔴 CRÍTICO

**Causas Raíz**:
- Consultas SQL dinámicas sin parámetros
- Almacenamiento seguro de contraseñas
- Validación insuficiente de entrada
- No usar HTTPS
- Logs exponen datos sensibles

**Mitigación** (Diseño ya incluido):
1. ✅ EF Core con consultas parametrizadas
2. ✅ BCrypt para hash de contraseñas (T029)
3. ✅ Validación exhaustiva (T032-T036)
4. ✅ Serilog estructurado (T143)
5. ✅ Audit log de cambios (T145)
6. ✅ HTTPS en producción (recomendación)

**Pre-Launch Checklist**:
- [ ] Scan OWASP Top 10
- [ ] Penetration testing
- [ ] Dependency scan (NuGet vulnerabilities)
- [ ] Code review seguridad

**Owner**: Security Lead  
**Review**: Pre-producción

---

## 🟡 RIESGOS MEDIOS

### R3: Performance Degradada

**Descripción**  
Listas grandes, queries lentas, UI congelada durante operaciones.

**Probabilidad**: 🟢 Baja (20%)  
**Impacto**: 🟡 Medio (User experience)  
**Severidad**: 🟡 MEDIO

**Mitigación**:
1. ✅ Índices en columnas usadas en WHERE (búsquedas)
2. ✅ Paginación en todas las listas (T150)
3. ✅ Caché de datos de referencia (T151)
4. ✅ Lazy loading deshabilitado en EF Core
5. ✅ Queries optimizadas con Stored Procedures
6. ✅ Async/await en operaciones I/O

**Targets de Performance**:
- Login: < 1 segundo
- Listar 100 pacientes: < 2 segundos
- Buscar citas: < 1 segundo
- Cambiar idioma: < 500ms

**Testing**:
- Performance tests (T156)
- Load testing: 100 users simultaneos

**Owner**: Performance Engineer  
**Review**: Phase 10 (Testing)

---

### R4: Falta de Comprensión de Requerimientos

**Descripción**  
Ambigüedades o malinterpretación de especificaciones causan rework.

**Probabilidad**: 🟡 Media (25%)  
**Impacto**: 🟡 Medio (Rework, retrasos)  
**Severidad**: 🟡 MEDIO

**Mitigación**:
1. ✅ Documentación exhaustiva (4,300+ líneas)
2. ✅ Wireframes visuales (9 formularios)
3. ✅ Contratos API detallados
4. ✅ Examples concretos en especificación
5. ✅ Weekly sync con stakeholders

**Owner**: Product Manager  
**Review**: Semanal

---

### R8: Problemas con Entity Framework Core

**Descripción**  
Incompatibilidades, bugs de EF o queries ineficientes.

**Probabilidad**: 🟡 Media (25%)  
**Impacto**: 🟡 Medio (Retraso en backend)  
**Severidad**: 🟡 MEDIO

**Mitigación**:
1. ✅ Spike de EF Core temprano (Phase 2 T014-T015)
2. ✅ Tests de mapping antes de usar
3. ✅ Usar raw SQL si EF es ineficiente
4. ✅ Profiling de queries (T156)

**Contingencia**:
- Usar Dapper si EF es problema
- Raw SQL con parámetros
- Cambiar a procedimientos almacenados

**Owner**: Backend Lead  
**Review**: Phase 2 early

---

### R9: Deuda Técnica Acumulada

**Descripción**  
Shortcuts en código causan mantenimiento difícil y bugs futuros.

**Probabilidad**: 🟡 Media (35%)  
**Impacto**: 🟡 Medio (Maintenance nightmare)  
**Severidad**: 🟡 MEDIO

**Mitigación**:
1. ✅ Code reviews obligatorios
2. ✅ Coding standards desde inicio
3. ✅ Refactor schedule (cada 2 sprints)
4. ✅ Technical debt backlog
5. ✅ SonarQube analysis

**Owner**: Tech Lead  
**Review**: Bi-weekly

---

### R10: Testing Incompleto

**Descripción**  
Falta de cobertura permite bugs en producción.

**Probabilidad**: 🟡 Media (30%)  
**Impacto**: 🟡 Medio (Production issues)  
**Severidad**: 🟡 MEDIO

**Mitigación**:
1. ✅ Target: 75% code coverage
2. ✅ 80+ test cases (specs/master/testing.md)
3. ✅ Tests antes de merge (pre-commit hooks)
4. ✅ E2E tests de caminos críticos

**Owner**: QA Lead  
**Review**: Phase 4 testing

---

## 🟢 RIESGOS BAJOS

### R7: Incompatibilidad .NET 8

**Mitigación**: Desarrollar enteramente en .NET 8.0  
**Probabilidad**: 🟢 Baja (5%)

---

### R11: Cambios en Requisitos

**Mitigación**: Especificación Speckit + documentación  
**Probabilidad**: 🟢 Baja (10%)  
**Contingencia**: Agregar tareas al backlog, no cambiar scope existente

---

### R12: Problemas MySQL Versioning

**Mitigación**: Scripts numerados (01, 02, 03), tabla migrations  
**Probabilidad**: 🟢 Baja (5%)

---

## 📋 Risk Register Template

```
Risk ID: R13-[NUEVO]
Title: 
Description:
Cause:
Probability: 🟢/🟡/🔴
Impact: 
Severity:
Mitigation:
Contingency:
Owner:
Status: Open/In Progress/Closed
Date Created:
```

---

## 🔄 Risk Review Schedule

- **Weekly**: Revisar riesgos críticos en daily standup
- **Bi-weekly**: Risk review formal con team
- **Monthly**: Escalación a stakeholders si necesario

---

## 📊 Escalation Matrix

| Severidad | Acción | Owner |
|-----------|--------|-------|
| CRÍTICO | Escalate inmediatamente | Project Manager |
| MEDIO | Weekly review | Tech Lead |
| BAJO | Monthly review | Team Lead |

---

## ✅ Risk Closure Criteria

Un riesgo se cierra cuando:
1. Mitigación está implementada 100%
2. Tests pasan
3. Code review aprobado
4. Documentado en lessons learned

---

**Total Riesgos Identificados**: 12  
**Riesgos Críticos**: 3  
**Riesgos Medios**: 6  
**Riesgos Bajos**: 3  

**Riesgo General del Proyecto**: 🟡 MEDIO (Controlable)

Última actualización: 2025-12-05
