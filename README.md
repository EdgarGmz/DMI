# 📱 Desarrollo Móvil Integral (DMI)

<div align="center">

![.NET MAUI](https://img.shields.io/badge/.NET%20MAUI-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)
![SQLite](https://img.shields.io/badge/SQLite-07405E?style=for-the-badge&logo=sqlite&logoColor=white)

</div>

Este repositorio contiene las **actividades y proyectos** de la materia **Desarrollo Móvil Integral** utilizando **.NET MAUI**.

En esta materia desarrollaremos aplicaciones multiplataforma durante el **décimo cuatrimestre** de la carrera **Ingeniería en Desarrollo y Gestión de Software** en la **Universidad Tecnológica Santa Catarina**, trabajando de forma guiada con el profesor para fortalecer fundamentos de arquitectura móvil, interfaces, persistencia de datos y despliegue.

---

## 🎨 Sistema Visual de Consulta

Usa esta leyenda para ubicar rápido qué pasos seguir en clase y cuáles aplicar en tu equipo:

| Color | Contexto | Uso |
|------|----------|-----|
| 🟦 Azul | Clase del profesor (Windows + Visual Studio) | Referencia de lo que se explica en aula |
| 🟩 Verde | Tu entorno (macOS + VS Code) | Ruta recomendada para practicar en tu Mac |
| 🟨 Amarillo | Comandos compartidos | Funciona en Windows/macOS/Linux con .NET |
| 🟥 Rojo | Solución de errores | Diagnóstico rápido y corrección |

### 🧭 Mapa rápido por plataforma

- 🟦 **En clase:** Visual Studio + Windows (flujo guiado por el profesor)
- 🟩 **En tu Mac:** VS Code + terminal + Xcode/Android Studio
- 🟨 **Común a todos:** `dotnet restore`, `dotnet list package`, `dotnet add package`

---

## ⚡ Guía Ultra Rápida (10 comandos clave)

Usa esta sección como acordeón de clase.

| # | Objetivo | Comando |
|---|----------|---------|
| 1 | Verificar .NET instalado | `dotnet --version` |
| 2 | Ver workloads instalados | `dotnet workload list` |
| 3 | Crear app MAUI nueva | `dotnet new maui -n MiNuevaAppMaui` |
| 4 | Entrar al proyecto | `cd MiNuevaAppMaui` |
| 5 | Restaurar dependencias | `dotnet restore` |
| 6 | Instalar paquete NuGet | `dotnet add package CommunityToolkit.Maui` |
| 7 | Ver paquetes instalados | `dotnet list package` |
| 8 | Compilar (sin ejecutar) Mac | `dotnet build -f net10.0-maccatalyst` |
| 9 | Ejecutar en MacCatalyst | `dotnet build -t:Run -f net10.0-maccatalyst` |
| 10 | Ejecutar en Android | `dotnet build -t:Run -f net10.0-android` |

Atajo mental para memorizar:

**Crear → Restaurar → Instalar → Listar → Compilar → Ejecutar**

---

## 🛠️ Requisitos Previos

Antes de empezar, asegúrate de tener instalado lo siguiente:

### 📥 1. **Git**
Para clonar el repositorio.

🔗 **Descargar:** [git-scm.com](https://git-scm.com/)

---

### ⚙️ 2. **.NET SDK 10** (o superior)
Framework necesario para trabajar con proyectos .NET y .NET MAUI.

🔗 **Descargar:** [dotnet.microsoft.com](https://dotnet.microsoft.com/download)

---

### 💻 3. **Editor/IDE**

Puedes trabajar con cualquiera de estas opciones según tu sistema operativo:
- **Windows:** Visual Studio 2022 (con carga de trabajo de .NET MAUI) o VS Code
- **macOS:** VS Code (recomendado en este repositorio)
- **Linux:** VS Code para revisar código, documentación y gestión de proyectos .NET

🔗 **Descargar:** [code.visualstudio.com](https://code.visualstudio.com/)

**Extensiones recomendadas en VS Code:**
- ✅ **C# Dev Kit**
- ✅ **C#**
- ✅ **.NET Install Tool**

---

## 🖥️ Configuración por Sistema Operativo

### 🪟 Windows

- Instala **Visual Studio 2022** con la carga de trabajo **Desarrollo de aplicaciones móviles con .NET**.
- Instala Android SDK/Emulador si ejecutarás Android.
- Para ejecutar en Windows, usa target `net10.0-windows10.0.19041.0`.

### 🍎 macOS

- Instala VS Code y .NET SDK.
- Para iOS/MacCatalyst, instala Xcode y acepta licencia.
- Para Android, instala Android Studio con SDK y emulador.

### 🐧 Linux

- Puedes usar VS Code + .NET SDK para estudiar estructura, editar código y restaurar paquetes.
- Para desarrollo y ejecución completa de apps .NET MAUI (Android/iOS/MacCatalyst/Windows), usa Windows o macOS.

---

### 🍎 4. **Xcode** (solo macOS, para iOS y MacCatalyst)

Instala Xcode desde App Store y después ejecuta:

```bash
sudo xcode-select -s /Applications/Xcode.app/Contents/Developer
sudo xcodebuild -license accept
```

### 🤖 5. **Android SDK + Emulador** (Windows/macOS)

Instala Android Studio, luego configura al menos:
- Android SDK Platform
- Android SDK Command-line Tools
- Android Emulator
- Una imagen de sistema (por ejemplo API 34)

#### 🟩 Configuración validada en este repositorio (macOS + VS Code)

Si trabajas en macOS con terminal, este flujo ya fue validado para `AppGrabarAudio`:

```bash
# 1) Java + herramientas Android
brew install --cask microsoft-openjdk@17 android-commandlinetools android-platform-tools

# 2) Variables de entorno (zsh)
export ANDROID_SDK_ROOT="/opt/homebrew/share/android-commandlinetools"
export ANDROID_HOME="$ANDROID_SDK_ROOT"
export JAVA_HOME="$(/usr/libexec/java_home -v 17)"
export PATH="$JAVA_HOME/bin:$ANDROID_SDK_ROOT/cmdline-tools/latest/bin:$ANDROID_SDK_ROOT/platform-tools:$ANDROID_SDK_ROOT/emulator:$PATH"

# 3) Licencias y paquetes mínimos del SDK
yes | sdkmanager --sdk_root="$ANDROID_SDK_ROOT" --licenses
sdkmanager --sdk_root="$ANDROID_SDK_ROOT" "platform-tools" "emulator" "platforms;android-36" "platforms;android-36.1" "build-tools;36.1.0" "system-images;android-36;google_apis;arm64-v8a"

# 4) Crear AVD (una sola vez)
echo no | avdmanager create avd -n Pixel_7_API_36 -k "system-images;android-36;google_apis;arm64-v8a" -d pixel_7

# 5) Iniciar emulador
"$ANDROID_SDK_ROOT/emulator/emulator" -avd Pixel_7_API_36
```

Luego, en la carpeta del proyecto:

```bash
dotnet build -t:Run -f net10.0-android
```

---

## 🧑‍🏫 Clase (Visual Studio) vs 🧑‍💻 Tu Mac (VS Code)

Esta tabla te permite seguir la clase sin perderte, aunque uses otro entorno.

| Paso | 🟦 Lo que hace el profesor (Windows/Visual Studio) | 🟩 Lo que haces tú (macOS/VS Code) |
|------|-----------------------------------------------------|------------------------------------|
| 1 | Crear proyecto MAUI desde Visual Studio | `dotnet new maui -n MiNuevaAppMaui` |
| 2 | Abrir solución y restaurar paquetes automáticamente | `cd MiNuevaAppMaui` y `dotnet restore` |
| 3 | Agregar paquete NuGet desde interfaz gráfica | `dotnet add package NOMBRE_PAQUETE` |
| 4 | Revisar paquetes instalados desde NuGet Manager | `dotnet list package` |
| 5 | Ejecutar en perfil Windows/Android/iOS | `dotnet build -t:Run -f net10.0-maccatalyst` (o Android/iOS) |
| 6 | Corregir errores en Output/Errores | Revisar terminal y sección de troubleshooting de este README |

Regla pedagógica: **mismo objetivo, diferente herramienta**.

---

## 🚀 Flujo General del Repositorio (Windows/macOS/Linux)

### 📋 **Paso 1: Clonar el repositorio**

```bash
git clone https://github.com/EdgarGmz/DMI.git
cd DMI
```

### 📦 **Paso 2: Restaurar dependencias**

```bash
dotnet restore
```

### ▶️ **Paso 3: Ejecutar un proyecto existente**

Ejemplo con `AppCRUD`:

```bash
cd AppCRUD
```

Windows:

```bash
dotnet build -t:Run -f net10.0-windows10.0.19041.0
```

macOS (MacCatalyst):

```bash
dotnet build -t:Run -f net10.0-maccatalyst
```

Android (Windows/macOS, con emulador activo):

```bash
dotnet build -t:Run -f net10.0-android
```

---

## 🍎 macOS + VS Code: Crear una App MAUI Nueva e Instalar NuGet

Este apartado es exclusivo para macOS con VS Code, debido a que Visual Studio para Mac ya no es la opción actual del ecosistema.

### ✅ Checklist rápido antes de empezar

- [ ] `dotnet --version` funciona
- [ ] `xcode-select -p` apunta a `.../Xcode.app/Contents/Developer`
- [ ] Tienes Android Studio y un emulador creado (si usarás Android)
- [ ] Estás dentro de la carpeta correcta del proyecto

### 📋 **Paso 1: Verificar instalación base de .NET**

Abre una terminal y ejecuta:

```bash
dotnet --version
dotnet workload list
```

Si MAUI no aparece en la lista, instala workloads:

```bash
dotnet workload install maui
dotnet workload install android ios maccatalyst
```

---

### 🆕 **Paso 2: Crear una aplicación MAUI nueva**

Ubícate en la carpeta donde guardarás tus proyectos y ejecuta:

```bash
dotnet new maui -n MiNuevaAppMaui
```

Entra a la carpeta:

```bash
cd MiNuevaAppMaui
```

---

### 💻 **Paso 3: Abrir el proyecto en VS Code**

Desde la carpeta del proyecto:

```bash
code .
```

---

### 📦 **Paso 4: Restaurar dependencias NuGet**

```bash
dotnet restore
```

---

### 📦 **Paso 5: Instalar paquetes con NuGet (exacto)**

| Acción | Comando |
|--------|---------|
| Instalar paquete | `dotnet add package CommunityToolkit.Maui` |
| Instalar versión específica | `dotnet add package sqlite-net-pcl --version 1.9.172` |
| Ver paquetes instalados | `dotnet list package` |
| Quitar paquete | `dotnet remove package sqlite-net-pcl` |
| Restaurar dependencias | `dotnet restore` |

**A) Instalar un paquete:**

```bash
dotnet add package CommunityToolkit.Maui
```

**B) Instalar una versión específica:**

```bash
dotnet add package sqlite-net-pcl --version 1.9.172
```

**C) Ver paquetes instalados en el proyecto:**

```bash
dotnet list package
```

**D) Quitar un paquete:**

```bash
dotnet remove package sqlite-net-pcl
```

**E) Restaurar nuevamente (si cambiaste paquetes):**

```bash
dotnet restore
```

> 💡 Recomendación académica: instala paquetes uno por uno y documenta por qué lo agregaste.

### ✅ **Regla para evitar conflictos de versiones (NU1605)**

Aplica siempre esta secuencia al agregar paquetes:

1. Instala el paquete:

```bash
dotnet add package NOMBRE_PAQUETE
```

2. Revisa dependencias resueltas:

```bash
dotnet list package
```

3. Si aparece degradación de paquete (downgrade), fija versión explícita del paquete en conflicto en tu `.csproj` con la versión mínima requerida por la dependencia.

Ejemplo típico en MAUI:

- `CommunityToolkit.Maui 14.2.0` requiere `Microsoft.Maui.Controls >= 10.0.60`
- entonces debes mantener `Microsoft.Maui.Controls` en `10.0.60` o superior

4. Valida de nuevo:

```bash
dotnet restore
dotnet list package
```

Regla corta para memorizar:

**Instalar → Listar → Ajustar versión → Restaurar → Listar**

---

### ▶️ **Paso 6: Ejecutar la app desde terminal**

| Plataforma | Comando |
|------------|---------|
| 🍎 MacCatalyst | `dotnet build -t:Run -f net10.0-maccatalyst` |
| 🤖 Android | `dotnet build -t:Run -f net10.0-android` |
| 📱 iOS | `dotnet build -t:Run -f net10.0-ios` |

#### 🍎 MacCatalyst

```bash
dotnet build -t:Run -f net10.0-maccatalyst
```

#### 🤖 Android

Primero inicia un emulador desde Android Studio. Después:

```bash
dotnet build -t:Run -f net10.0-android
```

#### 📱 iOS (solo en macOS con Xcode configurado)

```bash
dotnet build -t:Run -f net10.0-ios
```

---

### 🔄 **Paso 7: Flujo recomendado en cada práctica**

```bash
dotnet restore
```

Usa el comando de ejecución según tu sistema operativo:

- **Windows:** `dotnet build -t:Run -f net10.0-windows10.0.19041.0`
- **macOS:** `dotnet build -t:Run -f net10.0-maccatalyst`
- **Android:** `dotnet build -t:Run -f net10.0-android`

No uses el target de Windows en macOS; ese comando solo funciona en equipos con Windows.

| Sistema operativo | Comando principal |
|-------------------|-------------------|
| Windows | `dotnet build -t:Run -f net10.0-windows10.0.19041.0` |
| macOS | `dotnet build -t:Run -f net10.0-maccatalyst` |
| Android | `dotnet build -t:Run -f net10.0-android` |

---

## 📋 Tecnologías Utilizadas

<div align="center">

| 🔧 Tecnología | 📝 Descripción |
|--------------|---------------|
| ![.NET MAUI](https://img.shields.io/badge/.NET%20MAUI-512BD4?style=flat-square&logo=dotnet&logoColor=white) | Framework multiplataforma |
| ![C#](https://img.shields.io/badge/C%23-239120?style=flat-square&logo=c-sharp&logoColor=white) | Lenguaje de programación |
| ![XAML](https://img.shields.io/badge/XAML-0C54C2?style=flat-square&logo=xaml&logoColor=white) | Diseño de interfaz |
| ![SQLite](https://img.shields.io/badge/SQLite-07405E?style=flat-square&logo=sqlite&logoColor=white) | Base de datos local |

</div>

### 📱 Plataformas Soportadas:

- ✅ 🪟 **Windows 10/11**
- ✅ 🤖 **Android 5.0+** (API 21+)
- ✅ 🍎 **iOS 11+**
- ✅ 🖥️ **macOS 10.15+**

---

## ❓ Solución de Problemas Comunes

> 🟥 Usa esta sección como "ruta de rescate" cuando un comando no funcione.

### ⚠️ **Error: "No se encuentra el workload de MAUI"**

**💡 Solución:**

```bash
dotnet workload install maui
```

---

### ⚠️ **Error: "No se pueden restaurar los paquetes NuGet"**

**💡 Solución:**

```bash
dotnet restore
```

Si persiste el problema, limpia y restaura:

```bash
dotnet clean
dotnet restore
```

---

### ⚠️ **Error en iOS/MacCatalyst por Xcode no configurado**

**💡 Solución:**

Si ves un error como:

"A valid Xcode installation was not found at '/Library/Developer/CommandLineTools'"

primero verifica la ruta activa:

```bash
xcode-select -p
```

Debe apuntar a una ruta similar a:

`/Applications/Xcode.app/Contents/Developer`

Si no apunta ahí, corrige con:

```bash
sudo xcode-select -s /Applications/Xcode.app/Contents/Developer
sudo xcodebuild -license accept
```

Opcional (primera configuración de Xcode):

```bash
sudo xcodebuild -runFirstLaunch
```

Luego reinicia terminal y vuelve a compilar.

---

### ⚠️ **La aplicación de Android no se despliega**

**💡 Solución:**

1. 📱 Verifica que tengas un emulador iniciado desde Android Studio (Device Manager) en Windows o macOS.

2. ▶️ Crea o inicia un emulador con API reciente.

3. 🔄 Vuelve a intentar ejecutar

<details>
<summary>🔍 <b>Crear un nuevo emulador de Android</b></summary>

1. Abre **Device Manager** en Android Studio
2. Haz clic en **"Nuevo dispositivo"**
3. Selecciona un perfil (recomendado: **Pixel 5**)
4. Descarga la imagen del sistema (Android 12 o superior)
5. Haz clic en **"Crear"**
6. Inicia el emulador haciendo clic en ▶️

</details>

#### 🟥 Error `XA5300`: No se encontró el directorio Android SDK

Este error indica que .NET Android no encuentra un SDK válido.

**💡 Solución rápida (macOS):**

```bash
brew install --cask microsoft-openjdk@17 android-commandlinetools android-platform-tools
```

Define variables de entorno y recarga terminal:

```bash
export ANDROID_SDK_ROOT="/opt/homebrew/share/android-commandlinetools"
export ANDROID_HOME="$ANDROID_SDK_ROOT"
export JAVA_HOME="$(/usr/libexec/java_home -v 17)"
export PATH="$JAVA_HOME/bin:$ANDROID_SDK_ROOT/cmdline-tools/latest/bin:$ANDROID_SDK_ROOT/platform-tools:$ANDROID_SDK_ROOT/emulator:$PATH"
```

Instala paquetes del SDK:

```bash
yes | sdkmanager --sdk_root="$ANDROID_SDK_ROOT" --licenses
sdkmanager --sdk_root="$ANDROID_SDK_ROOT" "platform-tools" "platforms;android-36" "platforms;android-36.1" "build-tools;36.1.0"
```

#### 🟥 Error `XA0010`: No hay ningún dispositivo disponible

Este error ocurre cuando usas `-t:Run` sin un emulador/dispositivo activo.

**💡 Solución:**

```bash
"$ANDROID_SDK_ROOT/emulator/emulator" -avd Pixel_7_API_36
adb devices
```

Debes ver algo como `emulator-5554   device` antes de ejecutar:

```bash
dotnet build -t:Run -f net10.0-android
```

---

### ⚠️ **Advertencias sobre ListView obsoleto**

**💡 No te preocupes:**

Son solo advertencias, la aplicación funciona correctamente. En versiones futuras se puede migrar a `CollectionView`.

---

### ⚠️ **Error: "No se puede compilar para Android"**

**💡 Solución:**

Instala los componentes de Android:

```bash
dotnet workload install android
```

Si persiste, verifica SDKs desde Android Studio y reinicia terminal.

---

### ⚠️ **El comando `dotnet` no se reconoce**

**💡 Solución:**

1. 🔗 Descarga e instala el [.NET SDK](https://dotnet.microsoft.com/download)
2. 🔄 Reinicia tu terminal
3. ✅ Verifica la instalación:
   ```bash
   dotnet --version
   ```

---

### 🆘 **¿Nada funciona?**

Reinicia desde cero:

```bash
# Limpia todo
dotnet clean

# Elimina carpetas temporales
rm -rf bin obj

# Restaura y compila
dotnet restore
dotnet build
```

En Linux recuerda que puedes editar y gestionar paquetes .NET, pero para ejecutar aplicaciones MAUI completas se recomienda Windows o macOS.

---

## 📚 Estructura del Proyecto AppCRUD

```
📁 AppCRUD/
│
├── 📂 Models/                    # 📊 Modelos de datos
│   └── Empleados.cs             # Clase de empleado
│
├── 📂 Platforms/                # 🔧 Código específico por plataforma
│   ├── Android/                 # Configuración de Android
│   ├── iOS/                     # Configuración de iOS
│   ├── MacCatalyst/             # Configuración de Mac
│   └── Windows/                 # Configuración de Windows
│
├── 📂 Resources/                # 🎨 Recursos de la aplicación
│   ├── Images/                  # Imágenes
│   ├── Fonts/                   # Fuentes personalizadas
│   └── Styles/                  # Estilos XAML
│
├── 📄 App.xaml                  # ⚙️ Configuración global de la app
├── 📄 App.xaml.cs               # Lógica de inicialización
├── 📄 MainPage.xaml             # 🖼️ Interfaz principal (Vista)
├── 📄 MainPage.xaml.cs          # 💻 Lógica de la interfaz (Código)
├── 📄 MauiProgram.cs            # 🚀 Punto de entrada de la aplicación
└── 📄 AppCRUD.csproj            # 📦 Archivo de proyecto
```

### 📖 Descripción de archivos importantes:

| Archivo | Descripción |
|---------|-------------|
| `App.xaml` | Define recursos globales, colores y estilos |
| `MainPage.xaml` | Diseño de la interfaz usando XAML |
| `MainPage.xaml.cs` | Lógica de eventos (botones, listas, etc.) |
| `MauiProgram.cs` | Configura servicios y fuentes de la app |
| `Models/Empleados.cs` | Define la estructura de datos del empleado |

---

## 🤝 Contribuir

Si encuentras algún error o quieres mejorar el código:

### 📝 Pasos para contribuir:

1. 🍴 **Haz un Fork del repositorio**
   ```bash
   # Haz clic en el botón "Fork" en GitHub
   ```

2. 📥 **Clona tu fork**
   ```bash
   git clone https://github.com/TU_USUARIO/DMI.git
   cd DMI
   ```

3. 🌿 **Crea una rama para tu mejora**
   ```bash
   git checkout -b mejora-descripcion
   ```

4. ✏️ **Haz tus cambios y commitea**
   ```bash
   git add .
   git commit -m "Descripción clara del cambio"
   ```

5. 📤 **Sube los cambios**
   ```bash
   git push origin mejora-descripcion
   ```

6. 🔀 **Abre un Pull Request en GitHub**

---

## 📖 Recursos Adicionales

### 📚 Documentación oficial:

| Recurso | Descripción | Enlace |
|---------|-------------|--------|
| 📘 **Documentación .NET MAUI** | Guía oficial completa | [Ver docs](https://learn.microsoft.com/es-es/dotnet/maui/) |
| 🗄️ **Tutorial SQLite en MAUI** | Aprende a usar bases de datos | [Ver tutorial](https://learn.microsoft.com/es-es/dotnet/maui/data-cloud/database-sqlite) |
| 💻 **Ejemplos de código** | Proyectos de ejemplo oficiales | [Ver ejemplos](https://github.com/dotnet/maui-samples) |
| 🎨 **Guía de UI/UX** | Mejores prácticas de diseño | [Ver guía](https://learn.microsoft.com/es-es/dotnet/maui/user-interface/) |
| 🔧 **Referencia de API** | Documentación de todas las clases | [Ver API](https://learn.microsoft.com/es-es/dotnet/api/?view=net-maui-8.0) |

### 🎥 Videos tutoriales recomendados:

- 📹 [Introducción a .NET MAUI](https://www.youtube.com/results?search_query=.net+maui+tutorial+español)
- 📹 [CRUD con SQLite en MAUI](https://www.youtube.com/results?search_query=maui+sqlite+crud)

### 🛠️ Herramientas útiles:

- 🔍 **[.NET MAUI Check](https://github.com/Redth/dotnet-maui-check)** - Verifica tu instalación
  ```bash
  dotnet tool install -g Redth.Net.Maui.Check
  maui-check
  ```

---

## 🎓 Información Académica

<div align="center">

| 📚 Campo | 📝 Detalle |
|----------|-----------|
| **Materia** | Desarrollo Móvil Integral |
| **Cuatrimestre** | Décimo |
| **Carrera** | Ingeniería en Desarrollo y Gestión de Software |
| **Universidad** | Tecnológica Santa Catarina |
| **Profesor** | Profesor titular de la materia DMI |
| **Periodo** | Décimo cuatrimestre |

</div>

---

## 📝 Notas para el Profesor/Compañeros

### ➕ Para agregar una nueva actividad al repositorio:

1. 📁 **Crea una nueva carpeta** en la raíz del repositorio:
   ```bash
   mkdir Actividad02
   cd Actividad02
   ```

2. 🆕 **Crea tu nuevo proyecto MAUI:**
   ```bash
   dotnet new maui -n Actividad02
   ```

3. 📝 **Actualiza este README.md:**
   - Agrega la actividad en la sección "📂 Actividades del Repositorio"
   - Incluye una descripción breve de lo que hace

4. 💾 **Commitea y sube los cambios:**
   ```bash
   git add .
   git commit -m "Agrega Actividad02: [descripción]"
   git push origin main
   ```

### 📋 Plantilla para documentar nuevas actividades:

```markdown
| **Actividad02** | Descripción de lo que hace la actividad | [Ver código](./Actividad02) |
```

---

## 📊 Estado del Proyecto

![GitHub last commit](https://img.shields.io/github/last-commit/EdgarGmz/DMI?style=flat-square)
![GitHub repo size](https://img.shields.io/github/repo-size/EdgarGmz/DMI?style=flat-square)
![GitHub](https://img.shields.io/github/license/EdgarGmz/DMI?style=flat-square)

---

## 📞 Contacto y Soporte

### 💬 ¿Tienes dudas o problemas?

- 🐛 **Reportar un bug:** [Abrir un Issue](https://github.com/EdgarGmz/DMI/issues/new?labels=bug&template=bug_report.md)
- 💡 **Sugerir una mejora:** [Abrir un Issue](https://github.com/EdgarGmz/DMI/issues/new?labels=enhancement&template=feature_request.md)
- 📧 **Contacto directo:** *(Agregar correo o Discord)*

### 🌟 Si te fue útil este repositorio:

Dale una ⭐ en GitHub para ayudar a otros compañeros a encontrarlo.

---

<div align="center">

**Última actualización:** Mayo 2026


[⬆️ Volver arriba](#-desarrollo-móvil-integral-dmi)

</div>
