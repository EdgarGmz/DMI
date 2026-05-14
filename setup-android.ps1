# Script para configurar Android SDK y emuladores
# Para ejecutar: .\setup-android.ps1

Write-Host "🤖 Configurando Android SDK para .NET MAUI" -ForegroundColor Cyan
Write-Host ""

# 1. Verificar si Android SDK está instalado
$androidHome = "$env:LOCALAPPDATA\Android\Sdk"

if (-not (Test-Path $androidHome)) {
	Write-Host "❌ Android SDK no encontrado" -ForegroundColor Red
	Write-Host ""
	Write-Host "📥 Opciones para instalar Android SDK:" -ForegroundColor Yellow
	Write-Host ""
	Write-Host "1️⃣  Instalar desde Visual Studio:" -ForegroundColor White
	Write-Host "   - Abre Visual Studio Installer" -ForegroundColor Gray
	Write-Host "   - Haz clic en 'Modificar'" -ForegroundColor Gray
	Write-Host "   - Selecciona 'Desarrollo de aplicaciones móviles con .NET'" -ForegroundColor Gray
	Write-Host "   - Asegúrate de tener marcado 'Android SDK'" -ForegroundColor Gray
	Write-Host ""
	Write-Host "2️⃣  Instalar Android Studio:" -ForegroundColor White
	Write-Host "   - Descarga desde: https://developer.android.com/studio" -ForegroundColor Gray
	Write-Host ""
	exit
}

Write-Host "✅ Android SDK encontrado en: $androidHome" -ForegroundColor Green
$env:ANDROID_HOME = $androidHome

# 2. Verificar emulador
$emulatorPath = "$androidHome\emulator\emulator.exe"
if (-not (Test-Path $emulatorPath)) {
	Write-Host "❌ Emulador no encontrado" -ForegroundColor Red
	Write-Host "Instala el emulador desde Android Studio o Visual Studio" -ForegroundColor Yellow
	exit
}

# 3. Listar emuladores disponibles
Write-Host ""
Write-Host "📱 Emuladores disponibles:" -ForegroundColor Cyan
$avds = & $emulatorPath -list-avds

if ($avds.Count -eq 0) {
	Write-Host "❌ No hay emuladores configurados" -ForegroundColor Red
	Write-Host ""
	Write-Host "Crea un emulador desde:" -ForegroundColor Yellow
	Write-Host "Visual Studio → Herramientas → Android → Administrador de dispositivos Android" -ForegroundColor Gray
} else {
	foreach ($avd in $avds) {
		Write-Host "  📱 $avd" -ForegroundColor White
	}

	Write-Host ""
	Write-Host "🚀 Para iniciar un emulador, ejecuta:" -ForegroundColor Cyan
	Write-Host ".\start-emulator.ps1 <nombre-del-emulador>" -ForegroundColor Gray
}

Write-Host ""
Write-Host "✅ Configuración completada" -ForegroundColor Green
