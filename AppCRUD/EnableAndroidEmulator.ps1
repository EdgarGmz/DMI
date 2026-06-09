# Script para habilitar características necesarias para el emulador de Android
# EJECUTAR COMO ADMINISTRADOR

Write-Host "=== Configuración del Emulador de Android ===" -ForegroundColor Cyan
Write-Host ""

# Verificar si se ejecuta como administrador
$isAdmin = ([Security.Principal.WindowsPrincipal] [Security.Principal.WindowsIdentity]::GetCurrent()).IsInRole([Security.Principal.WindowsBuiltInRole]::Administrator)

if (-not $isAdmin) {
	Write-Host "ERROR: Este script debe ejecutarse como Administrador" -ForegroundColor Red
	Write-Host "Haz clic derecho en PowerShell y selecciona 'Ejecutar como administrador'" -ForegroundColor Yellow
	pause
	exit
}

Write-Host "Paso 1: Verificando virtualización en BIOS..." -ForegroundColor Yellow
$virtEnabled = (Get-ComputerInfo).HyperVRequirementVirtualizationFirmwareEnabled

if (-not $virtEnabled) {
	Write-Host "ADVERTENCIA: La virtualización NO está habilitada en la BIOS" -ForegroundColor Red
	Write-Host ""
	Write-Host "Debes habilitar la virtualización en la BIOS/UEFI:" -ForegroundColor Yellow
	Write-Host "1. Reinicia tu PC" -ForegroundColor White
	Write-Host "2. Presiona F2, F10, Del o Esc al iniciar (depende de tu PC)" -ForegroundColor White
	Write-Host "3. Busca 'Intel VT-x' o 'AMD-V' y habilítalo" -ForegroundColor White
	Write-Host "4. Guarda y reinicia" -ForegroundColor White
	Write-Host ""
	$continue = Read-Host "¿Ya habilitaste la virtualización en BIOS? (S/N)"
	if ($continue -ne "S" -and $continue -ne "s") {
		Write-Host "Por favor, habilita la virtualización en BIOS primero." -ForegroundColor Red
		pause
		exit
	}
}

Write-Host ""
Write-Host "Paso 2: Habilitando Plataforma de Máquina Virtual..." -ForegroundColor Yellow
try {
	Enable-WindowsOptionalFeature -Online -FeatureName VirtualMachinePlatform -All -NoRestart
	Write-Host "✓ Plataforma de Máquina Virtual habilitada" -ForegroundColor Green
} catch {
	Write-Host "✗ Error al habilitar Plataforma de Máquina Virtual: $_" -ForegroundColor Red
}

Write-Host ""
Write-Host "Paso 3: Habilitando Plataforma de Hipervisor de Windows..." -ForegroundColor Yellow
try {
	Enable-WindowsOptionalFeature -Online -FeatureName HypervisorPlatform -All -NoRestart
	Write-Host "✓ Plataforma de Hipervisor habilitada" -ForegroundColor Green
} catch {
	Write-Host "✗ Error al habilitar Plataforma de Hipervisor: $_" -ForegroundColor Red
}

Write-Host ""
Write-Host "Paso 4 (Opcional): Habilitando Hyper-V..." -ForegroundColor Yellow
Write-Host "Nota: Hyper-V solo está disponible en Windows 10/11 Pro, Enterprise o Education" -ForegroundColor Gray
try {
	Enable-WindowsOptionalFeature -Online -FeatureName Microsoft-Hyper-V-All -All -NoRestart
	Write-Host "✓ Hyper-V habilitado" -ForegroundColor Green
} catch {
	Write-Host "✗ Hyper-V no disponible o no se pudo habilitar (normal en Windows Home)" -ForegroundColor Yellow
}

Write-Host ""
Write-Host "=== CONFIGURACIÓN COMPLETADA ===" -ForegroundColor Green
Write-Host ""
Write-Host "IMPORTANTE: Debes REINICIAR tu PC para que los cambios surtan efecto." -ForegroundColor Cyan
Write-Host ""
Write-Host "Después de reiniciar:" -ForegroundColor Yellow
Write-Host "1. Abre Visual Studio" -ForegroundColor White
Write-Host "2. Ve a Herramientas > Administrador de dispositivos Android" -ForegroundColor White
Write-Host "3. Crea un nuevo emulador" -ForegroundColor White
Write-Host "4. Ejecuta tu aplicación MAUI" -ForegroundColor White
Write-Host ""

$restart = Read-Host "¿Deseas reiniciar ahora? (S/N)"
if ($restart -eq "S" -or $restart -eq "s") {
	Write-Host "Reiniciando en 5 segundos..." -ForegroundColor Yellow
	Start-Sleep -Seconds 5
	Restart-Computer -Force
} else {
	Write-Host "Recuerda reiniciar manualmente para aplicar los cambios." -ForegroundColor Yellow
}

pause
