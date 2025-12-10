# CLINICA SAN_MANOTAS - Matriz de Dependencias

**Versión**: 1.0.0 | **Fecha**: 2025-12-05 | **Critical Path**: 34 horas (Phase 2)

---

## 📊 Matriz de Dependencias (Task Dependencies)

### Phase 1: Setup (T001-T006) - 2-3 horas
```
T001 → T002 → T003 → T004 → T005 → T006
(No hay dependencias externas)
```

**Tasks**:
- T001: Create project structure
- T002: Add NuGet packages
- T003: Configure appsettings.json
- T004: Create DbContext
- T005: Create Repository pattern interfaces
- T006: Initialize Unit of Work pattern

---

## 🔴 CRITICAL PATH - Phase 2: Foundational (T007-T040) - 18-22 horas

**⚠️ CRITICAL**: These 34 tasks BLOCK all feature development. Must complete before Phase 3+

```
T007 ───→ T008 ───→ T009 ───→ T010 ───→ T011 ───→ T012
(Entity Models - Sequential, no parallelization)
  │
  └──────→ T013 ───→ T014 ───→ T015 ───→ T016 ───→ T017
           (DbContext Configuration - Sequential)
             │
             └──→ T018 ───→ T019 ───→ T020
                 (Repository Implementation + UnitOfWork)
                    │
                    └──→ T021 ───→ T022 ───→ T023 ───→ T024
                        (Database Migration & Execution)
                           │
                           ├──→ T025 ───→ T026 [P]
                           │   (Service Layer Base)
                           │
                           ├──→ T027 ───→ T028 [P]
                           │   (Validation Framework)
                           │
                           ├──→ T029 ───→ T030 [P]
                           │   (Password Security - BCrypt)
                           │
                           ├──→ T031 ───→ T032 ───→ T033 ───→ T034 [P]
                           │   (Logging & Audit Framework)
                           │
                           └──→ T035 ───→ T036 ───→ T037 ───→ T038 ───→ T039 ───→ T040
                               (Database Tests)
```

**Dependencia Línea de Tiempo**:
1. **Days 1-2** (8h): T007-T012 (Entity Models)
2. **Days 2-3** (6h): T013-T017 (DbContext)
3. **Days 3-4** (4h): T018-T020 (Repositories)
4. **Days 4-5** (3h): T021-T024 (DB Execution)
5. **Days 5-6** (1h): T025-T040 parallelizable

**Serial Dependencies (MUST do in order)**:
```
T007 → T008 → T009 → T010 → T011 → T012 → [MILESTONE: Models]
T013 → T014 → T015 → T016 → T017 → [MILESTONE: DbContext]
T018 → T019 → T020 → [MILESTONE: Repositories]
T021 → T022 → T023 → T024 → [MILESTONE: DB Ready]
T025 → T026 → [MILESTONE: Services]
T027 → T028 → [MILESTONE: Validation]
T029 → T030 → [MILESTONE: Security]
T031 → T032 → T033 → T034 → [MILESTONE: Logging]
```

---

## 📋 Feature Dependencies (User Stories)

### Dependency Graph

```
┌─────────────────────────────────────────────────────────────┐
│  PHASE 2: Foundational (T007-T040) - CRITICAL PATH - 34 hrs │
├─────────────────────────────────────────────────────────────┤
│ Models, DbContext, Repositories, UnitOfWork, Services Base   │
└────────┬────────────────────────────────────────────────────┘
         │ (All features depend on Phase 2)
         │
    ┌────┴────────────────────────────────────────────────────┐
    │                                                           │
    ▼                                                           ▼
┌─────────────┐                                         ┌──────────────┐
│ PHASE 3:    │                                         │  PHASE 4:    │
│ US1:        │◄────── [Bloqueado por] ────────►     │  US2:        │
│ Auth        │                                         │  Patients    │
│ (16 hrs)    │                                         │  (22 hrs)    │
└────┬────────┘                                         └──────┬───────┘
     │                                                         │
     │ [Proporciona]                                           │ [Proporciona]
     │ - AuthService                                          │ - PatientService
     │ - User validation                                      │ - Patient CRUD
     │ - Role authorization                                   │ - Data model
     │                                                         │
     └──────────────────────┬──────────────────────────────────┘
                            │
                    ┌───────┴────────┐
                    │                │
                    ▼                ▼
              ┌──────────────┐  ┌──────────────┐
              │  PHASE 5:    │  │  PHASE 7:    │
              │  US3:        │  │  US5:        │
              │  Doctors     │  │  Search      │
              │  (15 hrs)    │  │  (12 hrs)    │
              └──────┬───────┘  └────┬─────────┘
                     │               │
                     └──────┬────────┘
                            │
                            ▼
                    ┌──────────────────┐
                    │  PHASE 6:        │
                    │  US4:            │
                    │  Appointments    │
                    │  (18 hrs)        │
                    │ Depende de:      │
                    │ - Auth (US1)     │
                    │ - Patients (US2) │
                    │ - Doctors (US3)  │
                    └────────┬─────────┘
                             │
                    ┌────────┴────────┐
                    │                 │
                    ▼                 ▼
              ┌──────────────┐  ┌──────────────┐
              │  PHASE 8:    │  │  PHASE 9:    │
              │  US6:        │  │  US7:        │
              │  Localization│  │  EPS/Specs   │
              │  (8 hrs)     │  │  (7 hrs)     │
              └──────────────┘  └──────────────┘
                    │                 │
                    └────────┬────────┘
                             │
                             ▼
                    ┌──────────────────┐
                    │  PHASE 10:       │
                    │  Polish &        │
                    │  Cross-cutting   │
                    │  (10-12 hrs)     │
                    └──────────────────┘
```

---

## 🎯 Critical Path Analysis

### Path 1: Sequential Implementation (Conservative - 91-100 hrs)
```
Phase 2 (22h) → Phase 3 (16h) → Phase 4 (22h) → Phase 6 (18h) → Phase 10 (12h)
= 90 horas (Critical path)

Con fases parallelizables:
Phase 5, 7, 8, 9 pueden ejecutarse en paralelo a Phase 6
Total: 100-110 horas
```

### Path 2: Parallel Implementation (Aggressive - 63-79 hrs)
```
[Phase 2] ─────────────────────────────────┐
          │                                 │
          ├──→ [Phase 3] ───────────────────┤
          │      (Auth)                     │
          │                                 ├──→ [Phase 4] ───────┐
          ├──→ [Phase 5] ───────────────────┤     (Patients)       │
          │      (Doctors)                  │                      │
          │                                 │                      ├──→ [Phase 6] (Appointments)
          ├──→ [Phase 7] ───────────────────┤     (In parallel)    │
          │      (Search)                   │                      │
          │                                 │                      │
          └──→ [Phase 8,9] ────────────────┘

Duración: 22 + max(16, 15, 12, 8+7) + 22 + 12 = 22 + 22 + 22 + 12 = 78 horas
```

---

## 📊 Dependency Matrix (Detailed)

### Phase 3: US1 - Authentication (T041-T056)

**Dependencies**:
- ✅ Phase 2 COMPLETE (T007-T040)
- ✅ Services framework ready
- ✅ Validation framework ready

**Provides To**:
- Phase 4: Authentication service
- Phase 5, 6, 7, 8, 9: User context/Authorization

**Can Parallelize**:
- T041-T044: Can run in parallel (no shared state)
- T045-T050: Sequential (each builds on auth service)
- T051-T056: Unit tests (can run while other phases build)

```
T041 ───→ T042 ───→ T043 ───→ T044 [P]
(Usuario Model & DTO)
  │
  └──→ T045 ───→ T046 ───→ T047 ───→ T048 [P]
       (Auth Service - Sequential)
         │
         └──→ T049 ───→ T050 [P]
              (Login Form UI)
                │
                └──→ T051 ───→ T052 ───→ T053 ───→ T054 ───→ T055 ───→ T056
                     (Auth Tests & Integration)
```

---

### Phase 4: US2 - Patient Management (T057-T078)

**Dependencies**:
- ✅ Phase 2 COMPLETE
- ✅ Phase 3 COMPLETE (Auth) - needed for user context
- ❓ Phase 7 (Search) - optional, can use basic search first

**Provides To**:
- Phase 6: Patient list for appointments
- Phase 7: Search infrastructure
- Phase 10: Reporting

**Parallelization**:
```
[From Phase 2]
      │
T057 ┌┴──→ T058 ───→ T059 [P] (Patient Model)
     │
T060 ├┴──→ T061 ───→ T062 [P] (PatientService)
     │
T063 ├┴──→ T064 ───→ T065 [P] (PatientForm UI)
     │
T066 ├┴──→ T067 ───→ T068 ───→ T069 [P] (CRUD Endpoints)
     │
T070 ├┴──→ T071 ───→ T072 ───→ T073 ───→ T074 [P] (Tests)
     │
     └──→ T075 ───→ T076 ───→ T077 ───→ T078 (Integration)
```

**Can Run in Parallel**: T057-T059, T060-T062, T063-T065, T066-T069
**Serial Within**: T057→T058→T059→T060

---

### Phase 5: US3 - Doctor Management (T079-T093)

**Dependencies**:
- ✅ Phase 2 COMPLETE
- ❓ Phase 4 (Patients) - no, independent
- ✅ Especialidad table exists

**Provides To**:
- Phase 6: Doctor list for appointments
- Phase 7: Search infrastructure

**Timeline**: Can start AFTER Phase 2, parallel to Phase 4

---

### Phase 6: US4 - Appointments (T094-T111)

**Dependencies**:
- ✅ Phase 2 COMPLETE (mandatory)
- ✅ Phase 3 COMPLETE (Auth needed)
- ✅ Phase 4 COMPLETE (Patients needed)
- ✅ Phase 5 COMPLETE (Doctors needed)

**Critical**: T094-T111 cannot start until above are done.

**Timeline**: 
- Start: After Phase 5 complete
- Duration: 18 hours
- Can be optimized if Phase 4/5 run in parallel

---

### Phase 7: US5 - Search (T112-T123)

**Dependencies**:
- ✅ Phase 2 COMPLETE
- ✅ Phase 4 COMPLETE (Patient data exists)
- ✅ Phase 5 COMPLETE (Doctor data exists)

**Can Start**: After Phase 2, parallel to Phase 4-5

**Provides To**:
- UI: Search form
- Phase 4-6: Search functionality in existing forms

---

### Phase 8: US6 - Localization (T124-T131)

**Dependencies**:
- ✅ Phase 2 COMPLETE
- ✅ Phase 3-7 PARTIALLY (all forms should exist)

**Can Start**: After Phase 2, but BETTER if Phase 3-7 ~80% done
(Localization works better when forms are stable)

---

### Phase 9: US7 - EPS/Specialties (T132-T138)

**Dependencies**:
- ✅ Phase 2 COMPLETE
- ✅ Phase 4 & 5 COMPLETE (use these data)

**Can Start**: After Phase 2, parallel to Phase 4-5

---

### Phase 10: Polish (T139-T157)

**Dependencies**:
- ✅ Phases 3-9 MOSTLY COMPLETE
- 🔄 Phases 3-9 at 80%+ completion acceptable

**Activities**:
- Performance optimization (T150-T151)
- Integration testing (T152-T155)
- User acceptance testing (T156)
- Bug fixes from testing
- Documentation finalization

---

## 🚀 Parallelization Strategy

### Maximum Parallelization (Aggressive)

**Week 1-2** (Phase 2): 22 hours
- All 34 tasks SEQUENTIAL (critical path)
- T007-T040 must run in exact order

**Week 3-4** (Phase 3, 4, 5, 7, 8, 9 PARALLEL):

```
Developer 1: Phase 3 (Auth)
  T041-T056 (16 hours)
  ↓
  Can support other developers with user context

Developer 2: Phase 4 (Patients)
  T057-T078 (22 hours)
  ↓
  Needed by Dev 4 (Phase 6)

Developer 3: Phase 5 (Doctors)
  T079-T093 (15 hours)
  ↓
  Needed by Dev 4 (Phase 6)

Developer 4: Phase 6 (Appointments) - WAITING
  T094-T111 (18 hours)
  ↓
  STARTS: When Dev 1, 2, 3 complete

Developer 5: Phase 7 (Search) - PARALLEL
  T112-T123 (12 hours)
  ↓
  Starts Week 3, can integrate with Dev 2,3

Developer 6: Phase 8, 9 (Localization, EPS)
  T124-T138 (15 hours)
  ↓
  Can start Week 3, integrates with others

Developer 1+2: Phase 10 (Polish)
  T139-T157 (12 hours)
  ↓
  Final week
```

**Optimal**: 2-3 developers, 5-6 week timeline

---

## 🔗 Inter-Phase Dependencies Table

| Phase | Depends On | Reason | Severity |
|-------|-----------|--------|----------|
| Phase 3 | Phase 2 | Services framework | CRITICAL |
| Phase 4 | Phase 2, 3 | Auth context, DB | CRITICAL |
| Phase 5 | Phase 2 | DB models | CRITICAL |
| Phase 6 | Phase 2, 3, 4, 5 | All data layers | CRITICAL |
| Phase 7 | Phase 2, 4, 5 | Search data | MEDIUM |
| Phase 8 | Phase 2, 3-7 ~80% | Localize forms | MEDIUM |
| Phase 9 | Phase 2, 4, 5 | EPS/Specialty data | MEDIUM |
| Phase 10 | Phase 2-9 | All components | LOW |

---

## 📅 Timeline Scenarios

### Scenario A: Waterfall (Conservative)
```
Phase 2: 22h (Days 1-3)
Phase 3: 16h (Days 4-5)
Phase 4: 22h (Days 6-9)
Phase 5: 15h (Days 10-11)
Phase 6: 18h (Days 12-15)
Phase 7: 12h (Days 16-17)
Phase 8: 8h (Day 18)
Phase 9: 7h (Day 18)
Phase 10: 12h (Days 19-20)
─────────────────────────────
TOTAL: 132 hours (16 days @ 8h/day)
```

### Scenario B: Phase 2 → Parallel Features (Recommended)
```
Week 1-2: Phase 2 (22h) [ALL SEQUENTIAL]
Week 3: Phase 3 + 4 + 5 + 7 (42h in parallel)
        Dev 1: Phase 3 (16h)
        Dev 2: Phase 4 (22h) - BLOCKING Phase 6
        Dev 3: Phase 5 (15h) - BLOCKING Phase 6
        Dev 4: Phase 7 (12h) - INDEPENDENT
Week 4: Phase 6 (18h) [WAITING for Phase 4, 5]
        Phase 8, 9 in parallel (15h)
Week 5: Phase 10 (12h) + Buffer
─────────────────────────────
TOTAL: 100 hours (4 weeks @ 25h/week avg)
WITH PARALLELIZATION: 79 hours max critical path
```

### Scenario C: Aggressive (3 developers)
```
Phase 2: Developer A (22h)
Phases 3,5,7,9: Developers B, C parallel (52h)
Phase 4,6,8,10: Developers A, B, C rotate (52h)
─────────────────────────────
TOTAL: 79 hours critical path
CALENDAR: 3 weeks (5.3 weeks sequential ÷ 2 devs)
```

---

## ⚠️ Blocking Dependencies (CRITICAL)

```
🔴 BLOCKER T021-T024: DB Migration
   ↓
   Blocks: T025+ (all services)
   ↓
   Blocks: T041+ (all features)

🔴 BLOCKER T045-T048: Auth Service
   ↓
   Blocks: Phase 4+ (need user context)

🔴 BLOCKER T060-T062: PatientService
   ↓
   Blocks: Phase 6 (need patient data)

🔴 BLOCKER T079-T081: DoctorService
   ↓
   Blocks: Phase 6 (need doctor data)

🟡 SOFT BLOCKER: Phase 4 for Phase 7
   ↓
   Phase 7 can start with dummy data, integrate later
```

---

## 🎯 Milestones & Gates

```
MILESTONE 1: Phase 2 Complete (22h)
├─ All entity models in DbContext
├─ All repositories working
├─ UnitOfWork tested
├─ Database executing successfully
└─ GATE: All Phase 2 tests pass (T037-T040)

MILESTONE 2: Auth Complete (38h total)
├─ Phase 3 complete (T041-T056)
├─ Login working
├─ User context available
└─ GATE: Auth integration tests pass

MILESTONE 3: Core Data Ready (60h total)
├─ Phase 4 complete (T057-T078)
├─ Phase 5 complete (T079-T093)
├─ Patient & Doctor CRUD working
└─ GATE: Data layer tests pass

MILESTONE 4: Appointment Ready (78h total)
├─ Phase 6 complete (T094-T111)
├─ Appointments CRUD working
├─ Scheduling logic working
└─ GATE: E2E appointment flow passes

MILESTONE 5: Features Complete (103h total)
├─ Phase 7 complete (T112-T123)
├─ Phase 8 complete (T124-T131)
├─ Phase 9 complete (T132-T138)
└─ GATE: All feature tests pass

MILESTONE 6: Production Ready (115h total)
├─ Phase 10 complete (T139-T157)
├─ Performance tests pass
├─ Security audit complete
└─ GATE: All tests pass, UAT complete
```

---

## 📝 Dependency Tracking

### How to Track Dependencies

1. **In tasks.md**: Each task has clear ID and "depends on" section
2. **In Project Manager**: Create dependency graph in Jira/Azure DevOps
3. **In Code**: Comments reference task IDs
4. **In PR**: Title includes "Task: T0XX" for traceability

### Example Task Update
```
## T094: [US4] Create Appointment Model (depends on T090)

**Depends On**:
- T002: NuGet packages installed
- T007: Entity models pattern established
- T040: Database ready
- T056: Auth service ready
- T078: PatientService ready
- T093: DoctorService ready

**Blocks**:
- T095-T111 (other appointment tasks)
- Phase 6 (entire Appointment feature)

**Current Status**: Not Started
**Completed**: 0%
**Assigned To**: Developer B
```

---

## 🔄 Continuous Dependency Validation

**Daily**:
- Check: "Does current task have all dependencies ready?"
- If NO: Block and escalate

**Weekly**:
- Review: Are blockers being cleared on time?
- Risk: Which critical path tasks are at risk?

**Phase Exit**:
- Verify: All phase 2 tests pass before Phase 3
- Verify: All Phase 3 tests pass before Phase 4
- etc.

---

**Total Dependencies Identified**: 47  
**Critical Path Tasks**: 34 (Phase 2)  
**Critical Path Duration**: 22 hours  
**Total Project Duration**: 63-100 hours (depending on parallelization)  
**Maximum Parallelization**: 3 developers recommended  

Última actualización: 2025-12-05
