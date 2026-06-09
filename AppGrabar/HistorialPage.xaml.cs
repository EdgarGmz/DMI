using AppGrabar.Database;
using AppGrabar.Models;

namespace AppGrabar;

public partial class HistorialPage : ContentPage
{
	AppDatabase database;
	public HistorialPage(AppDatabase db)
	{
		InitializeComponent();
		database = db;
	}

	protected override async void OnAppearing()
	{
		base.OnAppearing();
		ListaVideos.ItemsSource = await database.ObtenerVideo();
	}

    private async void ListaVideos_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
		var video = e.CurrentSelection.FirstOrDefault() as VideoModel;
		if(video == null)
		{
			await DisplayAlertAsync("Error", "Video vacío", "Ok");
			return;
		}
		else
		{
			await Launcher.Default.OpenAsync(
					new OpenFileRequest
					{
						File = new ReadOnlyFile(video.RutaArchivo)
					}
				);
		}
    }
}