# TASKS - NUEVAS FASES (Filtros, i18n, Cambio Contraseña, Email, Fotos)

**Generado**: 2025-12-06  
**Basado en**: Análisis completo de contex.md  
**Status**: 📋 LISTOS PARA AGREGAR A tasks.md

---

## PHASE 9: FILTROS AVANZADOS (UI) - PRIORIDAD CRÍTICA

### Especificación
**Goal**: Interfaz para aplicar todos los filtros del contex.md  
**Criterios Independientes**:
- ✓ Filtrar citas por estado, fecha, paciente, médico
- ✓ Filtrar pacientes por género, edad, EPS, fecha registro
- ✓ Filtrar médicos por especialidad, nombre

### UI (Windows Forms)

- [X] T158 [CRÍTICA] Agregar panel de filtros a CitasForm
  - ComboBox: Estado (Todos, Pendiente, Confirmada, Realizada, Cancelada)
  - DateTimePicker: Fecha Inicio
  - DateTimePicker: Fecha Fin
  - ComboBox: Paciente
  - ComboBox: Médico
  - Button: Filtrar (azul)
  - Button: Limpiar Filtros (gris)
  - Conectar a métodos existentes: FiltrarPorEstado, FiltrarPorFechas, FiltrarPorPaciente, FiltrarPorMedico
  - ~80-100 líneas

- [X] T159 [P] [CRÍTICA] Agregar panel de filtros a PacientesForm
  - TextBox: Nombre/Documento
  - ComboBox: Género (Todos, Masculino, Femenino, Otro)
  - NumericUpDown: Edad Mínima
  - NumericUpDown: Edad Máxima
  - ComboBox: EPS
  - DateTimePicker: Fecha Registro
  - Crear métodos: FiltrarPorGenero, FiltrarPorEdad, FiltrarPorEPS, FiltrarPorFechaRegistro, FiltrarPorNombre
  - ~120-140 líneas

- [X] T160 [P] [CRÍTICA] Agregar panel de filtros a MedicosForm
  - TextBox: Nombre/Apellido
  - ComboBox: Especialidad
  - Crear métodos: FiltrarPorEspecialidad, FiltrarPorNombre
  - ~120-140 líneas

### Repositories

- [ ] T161 [P] Agregar métodos de filtrado en PacienteRepository
  - BuscarPorGenero(string genero)
  - BuscarPorEdad(int edad)
  - BuscarPorEPS(int epsId)
  - BuscarPorFechaRegistro(DateTime fecha)
  - BuscarPorNombre(string nombre)
  - ~50-70 líneas

- [ ] T162 [P] Agregar métodos de filtrado en MedicoRepository
  - BuscarPorEspecialidad(int especialidadId)
  - BuscarPorNombre(string nombre)
  - ~30-40 líneas

### Testing

- [ ] T163 [CRÍTICA] Tests para filtros avanzados
  - Test: Filtrar citas por estado
  - Test: Filtrar citas por fecha
  - Test: Filtrar pacientes por género
  - Test: Filtrar pacientes por edad
  - Test: Filtrar médicos por especialidad
  - ~150-200 líneas

- [ ] T164 [P] [CRÍTICA] Tests combinación de múltiples filtros
  - Test: Múltiples filtros simultáneamente
  - Test: Resultados vacíos
  - ~100-150 líneas

**Subtotal**: 7 tareas | **Horas**: 4-5 | **Complejidad**: M

---

## PHASE 10: LOCALIZACIÓN (i18n) - PRIORIDAD CRÍTICA

### Especificación
**Goal**: Interfaz completamente traducible español/inglés en tiempo de ejecución  
**Criterios Independientes**:
- ✓ LocalizationManager centralizado
- ✓ Cambio dinámico sin reinicio
- ✓ Archivos de traducción (es, en)
- ✓ SettingsForm para selector de idioma

### Servicios

- [ ] T165 [CRÍTICA] Crear LocalizationManager
  - Enum: Language (Spanish, English)
  - Propiedad: CurrentLanguage (estática)
  - Evento: OnLanguageChanged
  - Método: GetString(key) - retorna traducción
  - Método: SetLanguage(Language) - cambia idioma
  - Método: LoadTranslations() - carga desde JSON
  - Diccionario interno para idiomas
  - ~150-180 líneas

- [ ] T166 [P] [CRÍTICA] Implementar carga de traducciones JSON
  - Cargar es.json desde Resources/Translations/
  - Cargar en.json desde Resources/Translations/
  - Validación de claves faltantes
  - Fallback a inglés si falta traducción
  - ~50-70 líneas

- [ ] T167 [P] Crear evento OnLanguageChanged
  - Notificación a todos los formularios
  - Refresh automático de UI
  - Persistencia de preferencia en archivo config
  - ~40-60 líneas

### Recursos

- [ ] T168 [CRÍTICA] Crear es.json con todas las traducciones
  - app.title, app.version
  - login.* (10-15 keys)
  - main.* (20-25 keys)
  - button.* (10-12 keys)
  - validation.* (8-10 keys)
  - error.* (10-15 keys)
  - success.* (5-8 keys)
  - forms.* (50+ keys para todos los formularios)
  - grid.* (10-15 keys)
  - Total: ~250-300 claves

- [ ] T169 [P] [CRÍTICA] Crear en.json con traducciones
  - Traducción completa de es.json al inglés
  - ~250-300 claves

### UI (Windows Forms)

- [ ] T170 [US6] Crear SettingsForm
  - ComboBox: Idioma (Español, English)
  - Label: "Idioma Actual"
  - Button: "Aplicar"
  - Button: "Aceptar"
  - Button: "Cancelar"
  - Preview de cambios
  - Guardar preferencia
  - ~150-180 líneas

- [ ] T171 [P] [US6] Implementar selector de idioma
  - Evento: SelectedIndexChanged en ComboBox
  - Cargar configuración al abrir
  - Mostrar idioma actual seleccionado
  - ~40-60 líneas

- [ ] T172 [P] [US6] Aplicar i18n a LoginForm
  - Cambiar todos los Text de controles
  - Suscribir a OnLanguageChanged
  - Implementar RefreshUI()
  - ~30-50 líneas

- [ ] T173 [P] [US6] Aplicar i18n a MainForm
  - Cambiar todos los botones
  - Cambiar todos los labels
  - Suscribir a OnLanguageChanged
  - Implementar RefreshUI()
  - ~40-60 líneas

- [ ] T174 [P] [US6] Aplicar i18n a otros formularios
  - PacientesForm, MedicosForm, CitasForm, etc.
  - Cada formulario suscribe a OnLanguageChanged
  - Implementar RefreshUI() en cada uno
  - ~200+ líneas distribuidas

- [ ] T175 [US6] Implementar refresh dinámico
  - Cambio de idioma sin reiniciar la app
  - Todos los formularios abiertos se actualizan
  - DataGridView columnas se recargan
  - Mensajes dinámicos se retraducen
  - ~50-100 líneas en cada formulario

### Testing

- [ ] T176 [US6] Tests para cambio de idioma
  - Test: Cambiar a Inglés
  - Test: Cambiar a Español
  - Test: Verificar strings correctos
  - ~100-150 líneas

- [ ] T177 [P] [US6] Tests persistencia de preferencia
  - Test: Guardar preferencia de idioma
  - Test: Cargar preferencia en siguiente ejecución
  - ~50-80 líneas

**Subtotal**: 13 tareas | **Horas**: 6-8 | **Complejidad**: M/A

---

## PHASE 11: CAMBIO DE CONTRASEÑA - PRIORIDAD IMPORTANTE

### Especificación
**Goal**: Permitir al usuario cambiar su contraseña de forma segura  
**Criterios Independientes**:
- ✓ Validación de contraseña actual
- ✓ Nueva contraseña con requisitos mínimos
- ✓ Hash BCrypt
- ✓ Confirmación en BD

### UI (Windows Forms)

- [ ] T178 [IMPORTANTE] Crear ChangePasswordForm
  - TextBox: "Contraseña Actual" (PasswordChar)
  - TextBox: "Nueva Contraseña" (PasswordChar)
  - TextBox: "Confirmar Contraseña" (PasswordChar)
  - Label: "Requisitos: Min 8 caracteres, mayúscula, minúscula, número"
  - Button: "Cambiar"
  - Button: "Cancelar"
  - ~120-150 líneas

- [ ] T179 [P] Implementar validaciones
  - Verificar contraseña actual es correcta (comparar hash)
  - Nueva contraseña != contraseña actual
  - Nueva contraseña == Confirmar contraseña
  - Longitud mínima 8 caracteres
  - Incluir mayúscula
  - Incluir minúscula
  - Incluir número
  - Mensajes de error claros
  - ~50-70 líneas

- [ ] T180 [P] Integrar en MainForm
  - Agregar Button "Cambiar Contraseña"
  - Conectar evento Click
  - ShowDialog de ChangePasswordForm
  - ~15-20 líneas

### Servicios

- [ ] T181 [P] Implementar lógica de cambio en AuthenticationService
  - Método ChangePassword(usuarioId, oldPassword, newPassword)
  - Hash la nueva contraseña
  - Guardar en BD
  - Validar contraseña anterior
  - ~40-60 líneas

- [ ] T182 [P] Validar contraseña anterior
  - BCrypt.Verify(inputPassword, hashedPassword)
  - Manejo de error si no coincide
  - ~20-30 líneas

### Testing

- [ ] T183 [P] Tests cambio de contraseña
  - Test: Cambio exitoso
  - Test: Contraseña anterior incorrecta (debe fallar)
  - Test: Nueva == Actual (debe fallar)
  - ~80-120 líneas

- [ ] T184 [P] Tests validación de requisitos
  - Test: Contraseña < 8 caracteres (debe fallar)
  - Test: Sin mayúscula (debe fallar)
  - Test: Sin minúscula (debe fallar)
  - Test: Sin número (debe fallar)
  - Test: Válida completa (debe pasar)
  - ~80-120 líneas

**Subtotal**: 7 tareas | **Horas**: 2-3 | **Complejidad**: M

---

## PHASE 12: RECUPERACIÓN DE CONTRASEÑA (Email) - PRIORIDAD MEDIA

### Especificación
**Goal**: Permitir recuperación de contraseña mediante email  
**Criterios Independientes**:
- ✓ Token temporal (24 horas)
- ✓ Envío de email con link
- ✓ Validación y reset de contraseña

### Base de Datos

- [ ] T185 [IMPORTANTE] Crear tabla PasswordResetTokens
  ```sql
  CREATE TABLE PasswordResetTokens (
      TokenId INT AUTO_INCREMENT PRIMARY KEY,
      UsuarioId INT NOT NULL,
      Token VARCHAR(255) UNIQUE NOT NULL,
      ExpiresAt DATETIME NOT NULL,
      UsedAt DATETIME NULL,
      CreatedAt DATETIME DEFAULT CURRENT_TIMESTAMP,
      FOREIGN KEY (UsuarioId) REFERENCES Usuarios(UsuarioId)
  );
  ```
  - ~15 líneas

- [ ] T186 [P] Script de migración
  - Crear script de migración
  - Verificar tabla existe
  - ~20 líneas

### Servicios

- [ ] T187 [IMPORTANTE] Crear EmailService (SMTP)
  - Configuración SMTP (Gmail/Office365)
  - Método SendPasswordResetEmail(usuario, token)
  - Validación de email
  - Manejo de excepciones
  - Logging de envíos
  - ~100-120 líneas

- [ ] T188 [P] Crear PasswordTokenGenerator
  - Generar token seguro (32 caracteres aleatorios)
  - Método GenerateToken() - retorna string único
  - Método ValidateToken(token, expiresAt)
  - Método CreateResetLink(token)
  - ~40-60 líneas

- [ ] T189 [P] Implementar validación de tokens
  - Verificar token existe en BD
  - Verificar no ha expirado (24 horas)
  - Verificar no fue usado ya
  - Marcar como usado después de reset
  - ~50-70 líneas

### UI (Windows Forms)

- [ ] T190 [IMPORTANTE] Crear RecuperarContraseñaForm - PASO 1
  - Label: "Ingrese su email registrado"
  - TextBox: "Email"
  - Button: "Enviar"
  - Button: "Cancelar"
  - Validar que email existe en BD
  - Generar token (válido 24 horas)
  - Enviar email con link de reset
  - Mostrar mensaje de confirmación
  - ~120-150 líneas

- [ ] T191 [P] Crear RecuperarContraseñaForm - PASO 2
  - Parámetro URL: ?token=xxx
  - Validar token (no expirado, no usado)
  - TextBox: "Nueva Contraseña"
  - TextBox: "Confirmar Contraseña"
  - Button: "Cambiar Contraseña"
  - Button: "Cancelar"
  - Mostrar error si token inválido
  - Hash y guardar nueva contraseña
  - Marcar token como usado
  - ~150-180 líneas

- [ ] T192 [P] Integrar link en LoginForm
  - Agregar Link "¿Olvidó su contraseña?"
  - Conectar a RecuperarContraseñaForm
  - Abrir en modo PASO 1
  - ~15-20 líneas

### Testing

- [ ] T193 [P] Tests token generation
  - Test: Token generado es único
  - Test: Token tiene 32 caracteres
  - Test: Token válido por 24 horas
  - ~60-80 líneas

- [ ] T194 [P] Tests envío de email
  - Test: Email se envía correctamente (mock SMTP)
  - Test: Email contiene link correcto
  - Test: Link contiene token
  - ~80-100 líneas

- [ ] T195 [P] Tests validación de token
  - Test: Token válido acepta reset
  - Test: Token expirado rechaza reset
  - Test: Token usado rechaza reset
  - Test: Token inválido rechaza reset
  - ~80-120 líneas

**Subtotal**: 9 tareas | **Horas**: 4-5 | **Complejidad**: M/A

---

## PHASE 13: SISTEMA DE FOTOS - PRIORIDAD MEDIA

### Especificación
**Goal**: Permitir subir y gestionar fotos de usuarios  
**Criterios Independientes**:
- ✓ Upload de archivo
- ✓ Validación (tipo, tamaño)
- ✓ Almacenamiento en carpeta
- ✓ Download en formulario

### Infraestructura

- [ ] T196 [IMPORTANTE] Crear carpeta Uploads/Usuarios/
  - Crear estructura de carpetas
  - Verificar permisos de lectura/escritura
  - ~5 líneas

- [ ] T197 [P] Crear .gitignore para Uploads/
  - Agregar Uploads/** a .gitignore
  - Evitar subir fotos al repo
  - ~5 líneas

### Servicios

- [ ] T198 [IMPORTANTE] Crear FileManager para file operations
  - Método SaveUserPhoto(usuarioId, foto) - byte[] → archivo
  - Método GetUserPhoto(usuarioId) - archivo → byte[]
  - Método DeleteUserPhoto(usuarioId)
  - Ruta: Uploads/Usuarios/{usuarioId}.jpg
  - ~80-120 líneas

- [ ] T199 [P] Implementar validación de foto
  - Método ValidatePhotoSize(size) - máx 2MB
  - Método ValidatePhotoFormat(extension) - solo JPG, PNG
  - Mensajes de error claros
  - ~40-60 líneas

- [ ] T200 [P] Implementar almacenamiento de foto
  - Convertir Image a byte[]
  - Guardar en carpeta Uploads/Usuarios/
  - Crear nombre de archivo único
  - Manejo de sobrescritura
  - ~40-60 líneas

### UI (Windows Forms)

- [ ] T201 [IMPORTANTE] Agregar PictureBox a UsuariosForm
  - Control: PictureBox (250x250)
  - Mostrar foto en modo edición
  - Mostrar placeholder si no hay foto
  - ~50-80 líneas en Designer

- [ ] T202 [P] Agregar botón "Cargar Foto"
  - OpenFileDialog
  - Validar selección
  - Mostrar preview
  - Guardar en byte[]
  - ~50-70 líneas

- [ ] T203 [P] Agregar botón "Eliminar Foto"
  - Confirmar eliminación
  - Borrar archivo
  - Actualizar UI
  - ~30-50 líneas

- [ ] T204 [P] Implementar preview de foto
  - Mostrar foto en PictureBox
  - SizeMode: StretchImage
  - Actualizar en tiempo real
  - ~20-40 líneas

### Testing

- [ ] T205 [P] Tests upload de foto
  - Test: Subir foto válida (JPG)
  - Test: Subir foto válida (PNG)
  - Test: Verificar se guarda en carpeta correcta
  - ~80-100 líneas

- [ ] T206 [P] Tests validación de formato/tamaño
  - Test: Rechazar extensión inválida (.bmp)
  - Test: Rechazar foto > 2MB
  - Test: Aceptar foto < 2MB
  - ~80-120 líneas

- [ ] T207 [P] Tests eliminación de foto
  - Test: Eliminar foto existente
  - Test: Verificar archivo se borra
  - Test: Verificar BD se actualiza
  - ~60-80 líneas

**Subtotal**: 12 tareas | **Horas**: 3-4 | **Complejidad**: M

---

## PHASE 14: COMPLETACIÓN Y VALIDACIÓN

### Verificación Final

- [ ] T208 [CRÍTICA] Compilación sin errores (0 errores)
- [ ] T209 [P] Compilación sin warnings críticos
- [ ] T210 [P] Verificación de todas las funcionalidades
- [ ] T211 [P] Testing exhaustivo de UI/UX
- [ ] T212 [P] Validación de requisitos del contex.md

**Subtotal**: 5 tareas | **Horas**: 2-3 | **Complejidad**: S

---

## 📊 RESUMEN FINAL

**Total Nuevas Tareas**: 50 (T158-T212)  
**Total de Tareas Original**: 157  
**Total de Tareas Final**: 207

**Nuevas Horas**: 19-25  
**Horas Totales**: 110-125  

**Distribución por Prioridad**:
- 🔴 CRÍTICA: 5 tareas (Filtros UI, i18n base, Compilación)
- 🟡 IMPORTANTE: 15 tareas (resto de filtros, idiomas, cambio contraseña)
- 🟢 NORMAL: 30 tareas (testing, servicios, infraestructura)

---

Generado: 2025-12-06  
Basado en: ANALISIS-CONTEX-VS-IMPLEMENTADO.md + TAREAS-PENDIENTES-PRIORITARIAS.md
