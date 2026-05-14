# 📱 Desarrollo Móvil Integral (DMI)

<div align="center">

![.NET MAUI](https://img.shields.io/badge/.NET%20MAUI-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)
![SQLite](https://img.shields.io/badge/SQLite-07405E?style=for-the-badge&logo=sqlite&logoColor=white)

</div>

Este repositorio contiene las **actividades y proyectos** de la materia **Desarrollo Móvil Integral** utilizando **.NET MAUI**.

---

## 📂 Actividades del Repositorio

| 📁 Proyecto | 📝 Descripción | 🔗 Acceso |
|------------|---------------|-----------|
| **AppCRUD** | Aplicación CRUD con SQLite para gestión de empleados | [Ver código](./AppCRUD) |

> 💡 **Nota:** Más actividades se agregarán conforme avance el cuatrimestre.

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

### 💻 3. **Visual Studio 2022 o superior**
IDE recomendado para desarrollo.

🔗 **Descargar:** [Visual Studio Community](https://visualstudio.microsoft.com/) (gratis)

**Durante la instalación, selecciona:**
- ✅ **Desarrollo de aplicaciones móviles con .NET** (incluye .NET MAUI)
- ✅ **Windows 10/11 SDK**
- ✅ **Android SDK y Emulador** (si quieres ejecutar en Android)

---

## 🚀 Pasos para Ejecutar el Proyecto

### 📋 **Paso 1: Clonar el Repositorio**

Abre **PowerShell** o **Terminal** y ejecuta:

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

### 🔧 **Paso 2: Instalar las Herramientas de .NET MAUI**

**Verifica que tengas .NET instalado:**

```bash
dotnet --version
```

> ✅ **Debería mostrar algo como:** `10.0.x` o superior

**Instala las herramientas de MAUI:**

```bash
dotnet workload install maui
```

<details>
<summary>🔄 <b>Actualizar workloads (si ya los tienes instalados)</b></summary>

```bash
dotnet workload update
```
</details>

---

### 📦 **Paso 3: Restaurar Dependencias**

Desde la carpeta raíz del repositorio, ejecuta:

```bash
dotnet restore
```

> ⏱️ **Esto puede tardar unos minutos la primera vez.**

---

### ▶️ **Paso 4: Ejecutar la Aplicación**

Elige la plataforma en la que quieres ejecutar:

---

#### 🪟 **Opción A: Windows** (Recomendado para empezar)

**Entra a la carpeta del proyecto:**

```bash
cd AppCRUD
```

**Ejecuta la aplicación:**

```bash
dotnet run --framework net10.0-windows10.0.19041.0
```

> 🎉 **¡Listo!** Se abrirá una ventana con la aplicación funcionando.

<details>
<summary>🏗️ <b>Compilar sin ejecutar</b></summary>

Si solo quieres compilar sin ejecutar:

```bash
dotnet build --framework net10.0-windows10.0.19041.0
```
</details>

---

#### 🤖 **Opción B: Android**

**Método 1: Usando Visual Studio (Más fácil)**

1. 🔵 Abre **Visual Studio 2022**
2. 📂 Abre el proyecto: `DMI/AppCRUD/AppCRUD.csproj`
3. 📱 En la barra superior, selecciona un **emulador de Android**
4. ▶️ Presiona **F5** o haz clic en el botón de ejecutar

**Método 2: Usando línea de comandos**

```bash
cd AppCRUD
dotnet build --framework net10.0-android
```

> 📱 **Nota:** Necesitas tener un emulador de Android ejecutándose o un dispositivo conectado.

---

#### 🍎 **Opción C: iOS/Mac**

Para ejecutar en iOS necesitas:
- 🖥️ Una Mac con Xcode instalado
- 🔗 Configurar Visual Studio para conectarse a la Mac

📚 **Guía completa:** [Documentación oficial de Microsoft](https://learn.microsoft.com/es-es/dotnet/maui/ios/)

---

## 🎯 Guía Rápida con Visual Studio

> 💡 **Recomendado para principiantes** - Interfaz gráfica más amigable

### 📝 Pasos:

1. 🔵 **Abre Visual Studio 2022**

2. 📂 **Abre el proyecto:**
   - Haz clic en **"Abrir un proyecto o solución"**
   - Navega a: `DMI/AppCRUD/AppCRUD.csproj`
   - Haz clic en **"Abrir"**

3. ⏳ **Espera la restauración de paquetes**
   - Mira la barra de estado en la parte inferior
   - Verás: *"Restaurando paquetes NuGet..."*
   - Espera a que termine (puede tardar unos minutos la primera vez)

4. 🎮 **Selecciona la plataforma:**

   En la barra superior, verás un menú desplegable:

   | Opción | Para ejecutar en |
   |--------|------------------|
   | 🪟 **Windows Machine** | Tu computadora con Windows |
   | 🤖 **Android Emulator** | Emulador de Android |
   | 📱 **Android Device** | Dispositivo físico conectado |

5. ▶️ **Ejecuta la aplicación:**
   - Presiona **F5** en tu teclado
   - O haz clic en el botón verde ▶️ de ejecutar

6. ✅ **¡Listo!**
   - La aplicación se abrirá automáticamente
   - Si es la primera vez, puede tardar un poco en compilar

---

### 🎨 Capturas de Visual Studio

```
Barra de herramientas:
┌────────────────────────────────────────────────────────┐
│ [Windows Machine ▼]  [Any CPU ▼]  [▶️ AppCRUD]        │
└────────────────────────────────────────────────────────┘
      ↑ Aquí seleccionas la plataforma
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

### ⚠️ **Error: "No se encuentra el Windows SDK"**

**💡 Solución:**

1. 🔧 Abre **Visual Studio Installer**
2. ⚙️ Haz clic en **"Modificar"** en tu instalación de Visual Studio
3. ✅ Asegúrate de tener seleccionado **"Windows 10/11 SDK"**
4. 💾 Haz clic en **"Modificar"** para instalar

---

### ⚠️ **La aplicación de Android no se despliega**

**💡 Solución:**

1. 📱 Verifica que tengas un emulador iniciado:
   ```
   Visual Studio → Herramientas → Android → Android Device Manager
   ```

2. ▶️ Crea o inicia un emulador

3. 🔄 Vuelve a intentar ejecutar

<details>
<summary>🔍 <b>Crear un nuevo emulador de Android</b></summary>

1. Abre **Android Device Manager** en Visual Studio
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
Remove-Item -Recurse -Force bin, obj

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
| **Carrera** | Desarrollo de Software |
| **Universidad** | Tecnológica Santa Catarina |
| **Profesor** | *(Agregar nombre)* |
| **Periodo** | Enero - Abril 2025 |

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

**Última actualización:** Enero 2025

**Hecho con ❤️ para la comunidad de DMI**

[⬆️ Volver arriba](#-desarrollo-móvil-integral-dmi)

</div>
