# Script para iniciar emulador de Android
# Uso: .\start-emulator.ps1 <nombre-del-avd>

param(
	[Parameter(Mandatory=$false)]
	[string]$EmulatorName
)

$androidHome = "$env:LOCALAPPDATA\Android\Sdk"
$emulatorPath = "$androidHome\emulator\emulator.exe"

if (-not (Test-Path $emulatorPath)) {
	Write-Host "❌ Emulador no encontrado en: $emulatorPath" -ForegroundColor Red
	Write-Host "Ejecuta setup-android.ps1 primero" -ForegroundColor Yellow
	exit
}

# Listar emuladores disponibles
$avds = & $emulatorPath -list-avds

if ($avds.Count -eq 0) {
	Write-Host "❌ No hay emuladores configurados" -ForegroundColor Red
	Write-Host "Crea uno desde Visual Studio → Herramientas → Android → Administrador de dispositivos Android" -ForegroundColor Yellow
	exit
}

# Si no se especificó nombre, mostrar lista
if (-not $EmulatorName) {
	Write-Host "📱 Emuladores disponibles:" -ForegroundColor Cyan
	for ($i = 0; $i -lt $avds.Count; $i++) {
		Write-Host "  $($i+1). $($avds[$i])" -ForegroundColor White
	}

	Write-Host ""
	$selection = Read-Host "Selecciona el número del emulador a iniciar"
	$index = [int]$selection - 1

	if ($index -ge 0 -and $index -lt $avds.Count) {
		$EmulatorName = $avds[$index]
	} else {
		Write-Host "❌ Selección inválida" -ForegroundColor Red
		exit
	}
}

# Iniciar emulador
Write-Host ""
Write-Host "🚀 Iniciando emulador: $EmulatorName" -ForegroundColor Cyan
Write-Host "⏳ Esto puede tardar 1-2 minutos..." -ForegroundColor Yellow
Write-Host ""

Start-Process -FilePath $emulatorPath -ArgumentList "-avd", $EmulatorName

Write-Host "✅ Emulador iniciándose en segundo plano" -ForegroundColor Green
Write-Host ""
Write-Host "Una vez que el emulador esté completamente iniciado, ejecuta:" -ForegroundColor Cyan
Write-Host "cd AppCRUD" -ForegroundColor Gray
Write-Host "dotnet run --framework net10.0-android" -ForegroundColor Gray
