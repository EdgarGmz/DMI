# 🤖 Guía Completa: Ejecutar AppCRUD en Android

## 📋 Tabla de Contenidos
- [Método 1: Visual Studio (Recomendado)](#método-1-visual-studio-recomendado)
- [Método 2: Línea de Comandos](#método-2-línea-de-comandos)
- [Problemas Comunes](#problemas-comunes)

---

## Método 1: Visual Studio (Recomendado)

### ✅ **Ventajas:**
- ✨ Interfaz gráfica fácil de usar
- 🔧 Configuración automática
- 🐛 Depuración integrada
- 📱 Gestión visual de emuladores

### 📝 **Pasos detallados:**

#### 1️⃣ **Abrir el proyecto**
```
Visual Studio → Archivo → Abrir → Proyecto/Solución
Navegar a: DMI/AppCRUD/AppCRUD.csproj
```

#### 2️⃣ **Esperar restauración de paquetes**
- Observa la barra inferior de Visual Studio
- Verás: "Restaurando paquetes NuGet..."
- ⏳ Espera a que termine

#### 3️⃣ **Abrir el Administrador de Dispositivos Android**
```
Menú: Herramientas → Android → Administrador de dispositivos Android
O presiona: Ctrl + Shift + D (en algunas versiones)
```

#### 4️⃣ **Crear un emulador** (si no tienes ninguno)

**Configuración recomendada:**

| Opción | Valor Recomendado |
|--------|-------------------|
| 📱 **Dispositivo** | Pixel 5 o Pixel 7 |
| 🤖 **Sistema** | Android 12 (API 31) o Android 13 (API 33) |
| 💾 **RAM** | 2048 MB (mínimo) |
| 📊 **Espacio** | 2 GB |

**Pasos:**
1. Clic en **"+ Nuevo"** o **"+ Nuevo dispositivo"**
2. Selecciona **"Pixel 5"** de la lista
3. En "Imagen del sistema", selecciona **"Android 12.0 - API 31"**
4. Si no está descargada, haz clic en **"Descargar"** (≈500 MB)
5. Espera la descarga e instalación
6. Haz clic en **"Crear"**
7. Dale un nombre (ej: "Mi Emulador Android 12")

#### 5️⃣ **Iniciar el emulador**
1. En el Device Manager, busca tu emulador
2. Haz clic en el botón **▶️ Iniciar** o **"Start"**
3. ⏳ Espera 1-3 minutos (la primera vez tarda más)
4. ✅ El emulador mostrará la pantalla de Android

#### 6️⃣ **Ejecutar la aplicación**

**En la barra superior de Visual Studio:**

```
┌─────────────────────────────────────────────────┐
│ [Pixel 5 - API 31 ▼]  [Debug ▼]  [▶️ AppCRUD] │
└─────────────────────────────────────────────────┘
	   ↑ Aquí selecciona tu emulador
```

1. En el menú desplegable (donde dice "Windows Machine"), selecciona tu emulador
2. Presiona **F5** o haz clic en **▶️**
3. ⏳ Primera ejecución: 30-60 segundos (compila e instala)
4. ✅ La app se abrirá en el emulador

---

## Método 2: Línea de Comandos

### 🔧 **Prerrequisitos:**

Necesitas tener instalado:
- Android SDK (viene con Visual Studio si seleccionaste desarrollo móvil)
- Android Emulator
- Al menos un AVD (Android Virtual Device) configurado

### 📝 **Pasos:**

#### 1️⃣ **Verificar instalación de Android SDK**

Ejecuta el script que creé:

```powershell
.\setup-android.ps1
```

**Si el script dice que Android SDK no está instalado:**

**Opción A: Instalar desde Visual Studio Installer**
```
1. Abre "Visual Studio Installer"
2. Clic en "Modificar"
3. Marca "Desarrollo de aplicaciones móviles con .NET"
4. En el panel derecho, asegúrate de tener:
   ✅ Android SDK
   ✅ Android SDK Build Tools
   ✅ Android Emulator
5. Clic en "Modificar" y espera la instalación
```

**Opción B: Instalar Android Studio**
```
1. Descarga desde: https://developer.android.com/studio
2. Instala con opciones predeterminadas
3. Abre Android Studio → More Actions → SDK Manager
4. Instala:
   - Android SDK Platform (API 31 o superior)
   - Android SDK Build Tools
   - Android Emulator
```

#### 2️⃣ **Crear un emulador** (si no tienes ninguno)

Desde Visual Studio es más fácil (ver Método 1), pero si quieres usar comandos:

```powershell
# Listar imágenes del sistema disponibles
$env:ANDROID_HOME\cmdline-tools\latest\bin\sdkmanager --list

# Instalar una imagen del sistema
$env:ANDROID_HOME\cmdline-tools\latest\bin\sdkmanager "system-images;android-31;google_apis;x86_64"

# Crear un AVD
$env:ANDROID_HOME\cmdline-tools\latest\bin\avdmanager create avd -n "MiEmulador" -k "system-images;android-31;google_apis;x86_64" -d "pixel_5"
```

#### 3️⃣ **Iniciar el emulador**

**Usando el script que creé:**

```powershell
.\start-emulator.ps1
```

Selecciona el número del emulador que quieres iniciar.

**O manualmente:**

```powershell
# Listar emuladores disponibles
$env:ANDROID_HOME\emulator\emulator.exe -list-avds

# Iniciar un emulador específico
$env:ANDROID_HOME\emulator\emulator.exe -avd NombreDelEmulador
```

#### 4️⃣ **Ejecutar la aplicación**

Una vez que el emulador esté completamente iniciado:

```powershell
cd AppCRUD
dotnet run --framework net10.0-android
```

⏳ **Primera ejecución:** Puede tardar 1-2 minutos
✅ **Siguientes ejecuciones:** 20-30 segundos

---

## 🆘 Problemas Comunes

### ⚠️ **"No aparece ningún emulador en Visual Studio"**

**Solución:**
1. Cierra Visual Studio
2. Abre el Administrador de dispositivos Android de forma independiente:
   ```
   Inicio → Busca "Android Device Manager"
   ```
3. Crea un emulador nuevo
4. Inicia el emulador
5. Abre Visual Studio de nuevo
6. El emulador debería aparecer ahora

---

### ⚠️ **"El emulador no inicia / se queda en pantalla negra"**

**Soluciones:**

**1. Verificar virtualización en BIOS:**
- Reinicia tu PC y entra al BIOS (F2, F10, o DEL)
- Busca "Intel VT-x" o "AMD-V"
- Asegúrate de que esté **Habilitado**

**2. Verificar Hyper-V (Windows):**
```powershell
# Ejecuta como Administrador
Get-WindowsOptionalFeature -Online -FeatureName Microsoft-Hyper-V-All
```

Si está habilitado, intenta deshabilitarlo:
```powershell
# Como Administrador
Disable-WindowsOptionalFeature -Online -FeatureName Microsoft-Hyper-V-All
```

**3. Usar un emulador más ligero:**
- En lugar de Pixel 5, prueba con "Pixel 2" o "Nexus 5"
- Reduce la RAM del emulador a 1536 MB

---

### ⚠️ **"Error: No devices available"**

**Solución:**
```powershell
# Verifica que el emulador esté reconocido
adb devices
```

Debería mostrar algo como:
```
List of devices attached
emulator-5554   device
```

Si no aparece:
```powershell
# Reinicia el servidor ADB
adb kill-server
adb start-server
```

---

### ⚠️ **"La app se instala pero no se abre"**

**Solución:**
1. Desinstala la app del emulador manualmente
2. Limpia el proyecto:
   ```powershell
   dotnet clean
   ```
3. Vuelve a compilar e instalar:
   ```powershell
   dotnet build --framework net10.0-android
   dotnet run --framework net10.0-android
   ```

---

### ⚠️ **"Error: INSTALL_FAILED_INSUFFICIENT_STORAGE"**

**Solución:**
- Tu emulador no tiene espacio suficiente
- Crea un nuevo emulador con más almacenamiento (mínimo 2 GB)

---

## 🎯 Tips y Mejores Prácticas

### ⚡ **Acelerar el emulador:**

1. **Habilitar aceleración por hardware:**
   - Verifica que Intel HAXM esté instalado (en Windows con Intel)
   - O que Windows Hypervisor Platform esté habilitado

2. **Configurar el emulador con más recursos:**
   ```
   Device Manager → Editar emulador → Advanced Settings
   - RAM: 3072 MB (si tu PC tiene 8 GB o más)
   - VM Heap: 256 MB
   - Internal Storage: 2048 MB
   ```

3. **Usar una versión más reciente de API:**
   - Android 12 (API 31) o Android 13 (API 33) son más rápidos que versiones antiguas

### 💾 **Guardar estado del emulador:**

- Al cerrar el emulador, elige **"Save state"** en lugar de apagarlo
- La próxima vez iniciará mucho más rápido (5-10 segundos)

### 🔍 **Ver logs del emulador:**

En Visual Studio:
```
Ver → Output → Mostrar salida de: Debug
```

En terminal:
```powershell
adb logcat
```

---

## 📊 Comparación de Métodos

| Aspecto | Visual Studio | Línea de Comandos |
|---------|--------------|-------------------|
| **Dificultad** | ⭐ Fácil | ⭐⭐⭐ Intermedia |
| **Configuración** | 🟢 Automática | 🟡 Manual |
| **Depuración** | 🟢 Integrada | 🟡 Requiere logs |
| **Gestión de emuladores** | 🟢 Visual | 🔴 Comandos |
| **Velocidad de desarrollo** | 🟢 Rápida | 🟡 Media |
| **Recomendado para** | Principiantes | Usuarios avanzados |

---

## ✅ Checklist de Verificación

Antes de ejecutar en Android, verifica:

- [ ] Visual Studio 2022 instalado
- [ ] Workload ".NET MAUI" instalado
- [ ] Android SDK instalado
- [ ] Al menos un emulador configurado
- [ ] Emulador iniciado y funcionando
- [ ] Proyecto compila sin errores para Android
- [ ] ADB reconoce el emulador (`adb devices`)

---

## 🎓 Recursos Adicionales

- 📘 [Documentación oficial de Android en MAUI](https://learn.microsoft.com/es-es/dotnet/maui/android/)
- 📹 [Video: Configurar Android Emulator](https://www.youtube.com/results?search_query=android+emulator+visual+studio+2022)
- 🔧 [Android Developer: Emulator](https://developer.android.com/studio/run/emulator)

---

**¿Necesitas ayuda?** Abre un issue en GitHub con capturas de pantalla del error.

