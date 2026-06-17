using Plugin.Maui.Audio;
namespace AppGrabarAudio;

public partial class MainPage : ContentPage
{
	readonly IAudioManager _audioManager;
	readonly IAudioRecorder _audioRecorder;

	public MainPage(IAudioManager audioManager)
	{
		InitializeComponent();
		_audioManager = audioManager;
		_audioRecorder = audioManager.CreateRecorder();
	}

	private async void BtnIniciarGrabacion_Clicked(object sender, EventArgs e)
	{
		// Solicitar permiso de micrófono
		if(await Permissions.RequestAsync<Permissions.Microphone>() != PermissionStatus.Granted)
		{
			await DisplayAlertAsync("¡Permiso denegado!", "Permiso de micrófono no habilitado.", "OK");
			return;
		}

		// Iniciar grabación de audio
		if(!_audioRecorder.IsRecording)
		{
			await _audioRecorder.StartAsync();
			BtnIniciarGrabacion.Text = "Detener Grabación";
			return;
		}
		else
		{
			// Detener grabación de audio
			BtnIniciarGrabacion.Text = "Procesando...";
			BtnIniciarGrabacion.IsEnabled = false;
			

			// Detener la grabación y obtener el audio grabado
			var recorderAudio = await _audioRecorder.StopAsync();
			
			BtnIniciarGrabacion.IsEnabled = true;
			var player = AudioManager.Current.CreatePlayer(recorderAudio.GetAudioStream());

			// Reproducir el audio grabado
			player.Play();
			BtnIniciarGrabacion.Text = "Iniciar Grabación";
			BtnIniciarGrabacion.IsEnabled = false;
		}
	}
}
