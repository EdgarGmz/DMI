# 📱 Desarrollo Móvil Integral (DMI)

<div align="center">

![.NET MAUI](https://img.shields.io/badge/.NET%20MAUI-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)
![SQLite](https://img.shields.io/badge/SQLite-07405E?style=for-the-badge&logo=sqlite&logoColor=white)

</div>

Este repositorio contiene las **actividades y proyectos** de la materia **Desarrollo Móvil Integral** utilizando **.NET MAUI**.

En esta materia desarrollaremos aplicaciones multiplataforma durante el **décimo cuatrimestre** de la carrera **Ingeniería en Desarrollo y Gestión de Software** en la **Universidad Tecnológica Santa Catarina**, trabajando de forma guiada con el profesor para fortalecer fundamentos de arquitectura móvil, interfaces, persistencia de datos y despliegue.

---

## 🛠️ Requisitos Previos

Antes de empezar, asegúrate de tener instalado lo siguiente:

### 📥 1. **Git**
Para clonar el repositorio.

🔗 **Descargar:** [git-scm.com](https://git-scm.com/)

---

### ⚙️ 2. **.NET SDK 10** (o superior)
Framework necesario para ejecutar aplicaciones .NET MAUI.

🔗 **Descargar:** [dotnet.microsoft.com](https://dotnet.microsoft.com/download)

---

### 💻 3. **Visual Studio Code**
Editor recomendado en macOS para trabajar con MAUI por línea de comandos.

🔗 **Descargar:** [code.visualstudio.com](https://code.visualstudio.com/)

**Extensiones recomendadas en VS Code:**
- ✅ **C# Dev Kit**
- ✅ **C#**
- ✅ **.NET Install Tool**

### 🍎 4. **Xcode** (para iOS y MacCatalyst)

Instala Xcode desde App Store y después ejecuta:

```bash
sudo xcode-select -s /Applications/Xcode.app/Contents/Developer
sudo xcodebuild -license accept
```

### 🤖 5. **Android SDK + Emulador** (para Android)

Instala Android Studio, luego configura al menos:
- Android SDK Platform
- Android SDK Command-line Tools
- Android Emulator
- Una imagen de sistema (por ejemplo API 34)

---

## 🚀 Pasos Exactos para Iniciar un Nuevo Proyecto MAUI en VS Code (macOS)

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

### 🆕 **Paso 2: Crear el proyecto MAUI**

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

---

### ▶️ **Paso 6: Ejecutar por plataforma desde terminal**

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
dotnet build
dotnet build -t:Run -f net10.0-maccatalyst
```

---

## 📥 Clonar este repositorio (opcional para las actividades de clase)

Si lo que quieres es trabajar sobre este repositorio de la materia:

Abre **Terminal** y ejecuta:

```bash
git clone https://github.com/EdgarGmz/DMI.git
```

Entra a la carpeta del repositorio:

```bash
cd DMI
```

<details>
<summary>💡 <b>¿Ya lo tienes clonado?</b></summary>

Si ya clonaste el repositorio anteriormente, solo necesitas actualizarlo:

```bash
cd DMI
git pull origin main
```
</details>

---

```bash
cd DMI
dotnet restore
```

Para ejecutar un proyecto existente (ejemplo AppCRUD):

```bash
cd AppCRUD
dotnet build -t:Run -f net10.0-maccatalyst
```

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

### ⚠️ **Error: "No se encuentra el workload de MAUI"**

**💡 Solución:**

```bash
dotnet workload install maui
```

---

### ⚠️ **Error: "No se pueden restaurar los paquetes NuGet"**

**💡 Solución:**

```bash
cd AppCRUD
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

```bash
sudo xcode-select -s /Applications/Xcode.app/Contents/Developer
sudo xcodebuild -license accept
```

Luego reinicia terminal y vuelve a compilar.

---

### ⚠️ **La aplicación de Android no se despliega**

**💡 Solución:**

1. 📱 Verifica que tengas un emulador iniciado desde Android Studio (Device Manager).

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
