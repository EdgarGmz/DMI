# Desarrollo Movil Integral (DMI)

Repositorio base de la materia DMI con una app .NET MAUI llamada AppCRUD.

## 1. Stack del proyecto

- Framework principal: .NET MAUI
- Lenguaje: C#
- UI: XAML
- Base de datos local: SQLite (paquete sqlite-net-pcl)
- Targets definidos en AppCRUD.csproj:
  - net10.0-android
  - net10.0-ios
  - net10.0-maccatalyst
  - net10.0-windows10.0.19041.0

## 2. Prerrequisitos

Para inicializar y ejecutar el repo en Windows necesitas:

1. Git
2. .NET SDK 10.x (el proyecto usa net10.0)
3. Workload de .NET MAUI
4. Visual Studio 2022 (o superior) con:
   - .NET Multi-platform App UI development
   - Windows 10/11 SDK
   - Android SDK/Emulator (si correrás Android)

Opcional para iOS/MacCatalyst:

- Una Mac con Xcode para compilación remota

## 3. Clonar e inicializar el repositorio

Ejecuta en PowerShell:

   git clone <URL_DEL_REPOSITORIO>
   cd DMI

Si ya lo tienes clonado, solo entra a la carpeta del repo:

   cd c:\Users\edgar\OneDrive\Escritorio\DMI

## 4. Instalar dependencias de SDK y workloads

Verifica tu SDK instalado:

   dotnet --info

Si no tienes MAUI instalado en tu SDK actual:

   dotnet workload install maui

Actualiza workloads (recomendado si hay errores de compilación):

   dotnet workload update

Restaura paquetes NuGet del proyecto:

   dotnet restore AppCRUD/AppCRUD.csproj

## 5. Ejecutar la app

### Opción A: Windows (recomendada para inicio rápido)

   dotnet build AppCRUD/AppCRUD.csproj -f net10.0-windows10.0.19041.0
   dotnet run --project AppCRUD/AppCRUD.csproj -f net10.0-windows10.0.19041.0

### Opción B: Android

1. Abre Android Device Manager y arranca un emulador.
2. Compila/ejecuta:

   dotnet build AppCRUD/AppCRUD.csproj -f net10.0-android
   dotnet run --project AppCRUD/AppCRUD.csproj -f net10.0-android

## 6. Abrir en Visual Studio

1. Abre la carpeta raíz DMI o la solución/proyecto dentro de AppCRUD.
2. Espera restauración de paquetes.
3. Selecciona target (Windows Machine o Android Emulator).
4. Ejecuta con F5.

## 7. Archivos que SI deben versionarse

- Código fuente C# y XAML
- AppCRUD.csproj
- Recursos dentro de AppCRUD/Resources
- Configuración de plataformas dentro de AppCRUD/Platforms
- README.md y .gitignore

## 8. Archivos que NO deben versionarse

Este repo ya ignora artefactos generados con .gitignore:

- carpetas bin y obj
- archivos de usuario (*.user, *.suo)
- carpetas de IDE (.vs, .vscode)
- temporales y logs

Si quieres validar antes de commit:

   git status

## 9. Flujo recomendado para primer commit

   git add .
   git status
   git commit -m "Inicializa proyecto MAUI AppCRUD"

## 10. Solución de problemas comunes

1. Error de workload MAUI faltante:
   - Ejecuta dotnet workload install maui

2. Error de paquetes NuGet:
   - Ejecuta dotnet restore AppCRUD/AppCRUD.csproj

3. Error de target de Windows:
   - Verifica que tengas instalado Windows SDK en Visual Studio Installer

4. Android no despliega:
   - Verifica que el emulador esté iniciado y que Android SDK esté instalado

## 11. Información académica

- Materia: Desarrollo Movil Integral
- Cuatrimestre: Decimo
- Carrera: Desarrollo Software
- Universidad: Tecnológica Santa Catarina

Ultima actualización: 2026-05-12
