# CLINICA SAN MANOTAS - Plan de Testing Completo

**Versión**: 1.0.0 | **Fecha**: 2025-12-05 | **Cobertura Objetivo**: 75%+

---

## 📋 Resumen Ejecutivo

- **Unit Tests**: 45+ tests
- **Integration Tests**: 25+ tests
- **E2E Tests**: 10+ tests
- **Total Tests**: 80+ test cases
- **Herramienta**: xUnit + Moq
- **Coverage Objetivo**: 75%

---

## 1. UNIT TESTS - Core Services

### 1.1 AuthenticationService Tests

```csharp
[Fact]
public void Login_WithValidCredentials_ReturnsUser()
{
  // Arrange
  var authService = new AuthenticationService(mockRepo);
  var request = new LoginRequest { Username = "admin", Password = "admin123" };
  
  // Act
  var result = authService.Login(request);
  
  // Assert
  Assert.NotNull(result);
  Assert.Equal("admin", result.Username);
}

[Fact]
public void Login_WithInvalidPassword_ThrowsException()
{
  // Arrange
  var request = new LoginRequest { Username = "admin", Password = "wrongpass" };
  
  // Act & Assert
  Assert.Throws<UnauthorizedException>(() => authService.Login(request));
}

[Fact]
public void ChangePassword_WithValidOldPassword_Success()
{
  // Should update password in BD
}

[Fact]
public void ChangePassword_WithInvalidOldPassword_Fails()
{
  // Should throw exception
}
```

**Total Tests**: 8  
**Cobertura**: 90%

---

### 1.2 PatientService Tests

```csharp
[Fact]
public void CreatePatient_WithValidData_Success()
{
  // Should create patient and return ID
}

[Fact]
public void CreatePatient_WithDuplicateDocument_Fails()
{
  // Should throw ValidationException
}

[Fact]
public void CreatePatient_WithInvalidEmail_Fails()
{
  // Should reject invalid email format
}

[Fact]
public void CreatePatient_WithInvalidAge_Fails()
{
  // Should reject edad < 0 or > 150
}

[Fact]
public void UpdatePatient_WithValidData_Success()
{
  // Should update and return modified patient
}

[Fact]
public void DeletePatient_RemovesFromDatabase()
{
  // Should soft delete (estado = Inactivo)
}

[Fact]
public void GetPatients_WithPagination_ReturnsCorrectPage()
{
  // Should return page 1 with 10 records
}

[Fact]
public void GetPatients_FilterByEPS_ReturnsOnlyMatchingEPS()
{
  // Should filter correctly
}
```

**Total Tests**: 12  
**Cobertura**: 85%

---

### 1.3 AppointmentService Tests

```csharp
[Fact]
public void CreateAppointment_WithAvailableSlot_Success()
{
  // Should create appointment
}

[Fact]
public void CreateAppointment_WithOccupiedSlot_Fails()
{
  // Should throw ConflictException
}

[Fact]
public void CreateAppointment_WithPastDate_Fails()
{
  // Should reject cita en el pasado
}

[Fact]
public void CreateAppointment_DateMoreThan6Months_Fails()
{
  // Should reject > 6 meses adelante
}

[Fact]
public void CreateAppointment_OutsideDochorHours_Fails()
{
  // Should validate hora dentro de horario médico
}

[Fact]
public void ConfirmAppointment_ChangesStatus()
{
  // Should change Pendiente → Confirmada
}

[Fact]
public void CancelAppointment_OnlyIfPending()
{
  // Should only allow cancel si Estado = Pendiente
}

[Fact]
public void GetAvailableSlots_ReturnsCorrectSlots()
{
  // Should return 30-min slots within doctor hours
}

[Fact]
public void GetPatientAppointmentHistory_ReturnsAllPatientCitas()
{
  // Should return ordered by date DESC
}
```

**Total Tests**: 12  
**Cobertura**: 88%

---

### 1.4 DoctorService Tests

```csharp
[Fact]
public void CreateDoctor_WithUniqueLicense_Success()
{
  // Should create doctor
}

[Fact]
public void CreateDoctor_WithDuplicateLicense_Fails()
{
  // Should throw exception
}

[Fact]
public void CreateDoctor_WithInvalidHours_Fails()
{
  // Should validate HorarioInicio < HorarioFin
}

[Fact]
public void GetDoctorsBySpecialty_ReturnsOnlyMatchingSpecialty()
{
  // Should filter by specialty
}

[Fact]
public void GetDoctorsByName_ReturnsPartialMatches()
{
  // Should support partial name search
}
```

**Total Tests**: 8  
**Cobertura**: 85%

---

### 1.5 ValidatorService Tests

```csharp
[Theory]
[InlineData("test@example.com")]
[InlineData("valid.email@domain.co.uk")]
public void ValidateEmail_WithValidEmails_ReturnsTrue(string email)
{
  // Should accept valid emails
}

[Theory]
[InlineData("invalid.email")]
[InlineData("@nodomain.com")]
public void ValidateEmail_WithInvalidEmails_ReturnsFalse(string email)
{
  // Should reject invalid emails
}

[Theory]
[InlineData("+573001234567")]
[InlineData("3001234567")]
public void ValidatePhone_WithValidPhones_ReturnsTrue(string phone)
{
  // Should validate phone format
}

[Fact]
public void ValidateDateRange_WithFutureDate_ReturnsTrue()
{
  // Should accept future dates
}

[Fact]
public void ValidateDateRange_WithPastDate_ReturnsFalse()
{
  // Should reject past dates
}
```

**Total Tests**: 10  
**Cobertura**: 92%

---

## 2. INTEGRATION TESTS - Database Layer

### 2.1 Repository<T> Integration Tests

```csharp
[Fact]
public async Task Repository_Add_PersistsToDatabase()
{
  // Given a new entity
  // When added to repository
  // Then should be in database
}

[Fact]
public async Task Repository_Update_ChangesPersistedInDatabase()
{
  // Should update existing entity
}

[Fact]
public async Task Repository_Delete_RemovesFromDatabase()
{
  // Should soft delete
}

[Fact]
public async Task Repository_GetAll_ReturnAllRecords()
{
  // Should return all entities
}

[Fact]
public async Task Repository_Find_ReturnsFilteredRecords()
{
  // Should filter by predicate
}
```

**Total Tests**: 8  
**Cobertura**: 80%

---

### 2.2 UnitOfWork Integration Tests

```csharp
[Fact]
public async Task UnitOfWork_Transaction_CommitsAllChanges()
{
  // Should persist all changes when SaveAsync called
}

[Fact]
public async Task UnitOfWork_Transaction_RollsBackOnException()
{
  // Should rollback if exception during transaction
}

[Fact]
public async Task UnitOfWork_MultipleRepositories_MaintenConsistency()
{
  // Should maintain data consistency across repos
}
```

**Total Tests**: 5  
**Cobertura**: 85%

---

### 2.3 Patient-EPS Relationship Tests

```csharp
[Fact]
public async Task Patient_LinkedToEPS_CanNotDeleteEPS()
{
  // Should enforce foreign key constraint
}

[Fact]
public async Task Patient_LinkedToMultiplePatients_EPSNotDeleted()
{
  // Should prevent cascade delete of EPS with patients
}
```

**Total Tests**: 3  
**Cobertura**: 75%

---

### 2.4 Appointment Validation Tests

```csharp
[Fact]
public async Task Appointment_NoDuplicateSlots_EnforcedInDatabase()
{
  // Should have unique constraint on (MedicoId, Fecha, Hora)
}

[Fact]
public async Task Appointment_ForeignKeyConstraints_Enforced()
{
  // Should not allow invalid PacienteId or MedicoId
}
```

**Total Tests**: 2  
**Cobertura**: 80%

---

### 2.5 StoredProcedure Tests

```csharp
[Fact]
public void SP_GetAvailableAppointmentSlots_ReturnsCorrectSlots()
{
  // Should call SP and get available time slots
}

[Fact]
public void SP_GetAppointmentsByStatus_FiltersCorrectly()
{
  // Should return only appointments with specified status
}

[Fact]
public void SP_SearchPatients_ReturnsFilteredResults()
{
  // Should apply all filters (name, gender, EPS, age)
}
```

**Total Tests**: 5  
**Cobertura**: 90%

---

## 3. END-TO-END (E2E) TESTS

### 3.1 Complete Login Flow

```csharp
[Fact]
public void E2E_LoginFlow_AdminUserSuccessful()
{
  // 1. Open LoginForm
  // 2. Enter valid credentials
  // 3. Click Login
  // 4. Assert: MainForm opens
  // 5. Assert: User is authenticated
}

[Fact]
public void E2E_LoginFlow_InvalidCredentialsFails()
{
  // 1. Open LoginForm
  // 2. Enter invalid password
  // 3. Assert: Error message shown
  // 4. Assert: LoginForm remains open
}
```

**Total Tests**: 2

---

### 3.2 Complete Patient Management Flow

```csharp
[Fact]
public void E2E_PatientManagement_CreateEditDelete()
{
  // 1. Login
  // 2. Open PatientForm
  // 3. Create new patient
  // 4. Verify patient in list
  // 5. Edit patient data
  // 6. Verify changes saved
  // 7. Delete patient
  // 8. Verify removed from list
}

[Fact]
public void E2E_PatientSearch_ByMultipleCriteria()
{
  // 1. Navigate to SearchForm
  // 2. Search by name + EPS + Gender
  // 3. Verify filtered results
}
```

**Total Tests**: 2

---

### 3.3 Complete Appointment Flow

```csharp
[Fact]
public void E2E_AppointmentFlow_CreateConfirmCancel()
{
  // 1. Login
  // 2. Open AppointmentForm
  // 3. Select patient and doctor
  // 4. Choose available time slot
  // 5. Create appointment
  // 6. Confirm appointment
  // 7. Verify status changed
  // 8. Cancel appointment
  // 9. Verify canceled
}

[Fact]
public void E2E_AppointmentAvailability_ShowsCorrectSlots()
{
  // 1. Select doctor with working hours 08:00-17:00
  // 2. Request available slots
  // 3. Verify 30-min intervals are shown
  // 4. Verify no occupied slots are shown
}
```

**Total Tests**: 2

---

### 3.4 Localization E2E

```csharp
[Fact]
public void E2E_LanguageChange_RefreshesAllUI()
{
  // 1. Open app (English)
  // 2. Open SettingsForm
  // 3. Change to Spanish
  // 4. Assert: All UI texts changed to Spanish
  // 5. Navigate to different forms
  // 6. Verify Spanish persists
}
```

**Total Tests**: 1

---

### 3.5 Security E2E

```csharp
[Fact]
public void E2E_SQLInjection_NotPossible()
{
  // 1. Try SQL injection in search field
  // 2. Assert: Query fails safely or returns nothing
}

[Fact]
public void E2E_InvalidDataEntry_Rejected()
{
  // 1. Try entering invalid email in patient form
  // 2. Assert: Form validation prevents submission
}
```

**Total Tests**: 2

---

## 4. TESTING STRATEGY

### 4.1 Test Framework Setup

```csharp
// Arrange setup
var mockRepository = new Mock<IRepository<Patient>>();
var mockUnitOfWork = new Mock<IUnitOfWork>();
var service = new PatientService(mockUnitOfWork.Object);

// Configure mocks
mockRepository
  .Setup(r => r.GetByIdAsync(It.IsAny<int>()))
  .ReturnsAsync(new Patient { PacienteId = 1, Nombres = "Juan" });
```

### 4.2 Database Testing Strategy

- **In-Memory Database**: xUnit with EF Core InMemory for fast tests
- **Real Database**: Integration tests against MySQL test instance
- **Cleanup**: Each test uses fresh dataset

### 4.3 UI Testing Strategy

- **Unit Tests**: Test form logic separately
- **Integration Tests**: Test forms with mock services
- **E2E Tests**: Full application flow

---

## 5. TEST EXECUTION PLAN

### Phase 1: Unit Tests (Week 1-2)
```
dotnet test --filter "Category=Unit"
Coverage Report: 75%+ target
```

### Phase 2: Integration Tests (Week 2-3)
```
dotnet test --filter "Category=Integration"
Database: Use test MySQL instance
```

### Phase 3: E2E Tests (Week 3-4)
```
dotnet test --filter "Category=E2E"
Against: Staging environment
```

### Phase 4: Performance Tests (Week 4)
```
- Load test: 1000 concurrent logins
- Query performance: < 1 second for lists
- Memory usage: < 200MB baseline
```

---

## 6. TEST DATA REQUIREMENTS

### Seed Data for Tests

```csharp
// Setup 100 test patients
// Setup 10 test doctors
// Setup 50 test appointments
// Setup sample EPS and Specialties
```

---

## 7. COVERAGE GOALS

| Component | Target | Current |
|-----------|--------|---------|
| AuthService | 90% | 0% |
| PatientService | 85% | 0% |
| AppointmentService | 88% | 0% |
| ValidatorService | 92% | 0% |
| Repositories | 80% | 0% |
| **Overall** | **75%** | **0%** |

---

## 8. REGRESSION TEST SUITE

Critical paths to test on every build:

1. ✓ Login workflow
2. ✓ Create/Edit/Delete Patient
3. ✓ Check appointment availability
4. ✓ Appointment lifecycle
5. ✓ Data validation
6. ✓ Database constraints

---

## 9. TESTING METRICS

### Build Requirements

```
- All tests must pass: 100%
- Code coverage: 75%+
- No security warnings
- No performance regressions
```

---

**Total Test Cases**: 80+  
**Estimated Time**: 2-3 weeks  
**Coverage Target**: 75%+  

Última actualización: 2025-12-05
