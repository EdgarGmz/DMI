using AppGrabar.Database;
using AppGrabar.Models;

namespace AppGrabar;

public partial class MainPage : ContentPage
{
    private readonly AppDatabase database;

    public MainPage(AppDatabase db)
    {
        InitializeComponent();
        database = db;
    }        

    private async void BtnGrabar_Clicked(object sender, EventArgs e)
    {
        try
        {
            if (!MediaPicker.Default.IsCaptureSupported)
            {
                await DisplayAlertAsync("Error", "No Soportado", "Ok");
            }

            var video = await MediaPicker.Default.CaptureVideoAsync();

            if (video == null)
            {
                return;
            }
            else
            {
                var registro = new VideoModel
                {
                    Nombre = video.FileName,
                    RutaArchivo = video.FullPath,
                    FechaGrabacion = DateTime.Now
                };

                await database.GuardarVideo(registro);
                await DisplayAlertAsync("Exito!", $"Video {video.FileName} Guardado", "Ok");
            }

        }
        catch (Exception ex) 
        {
            await DisplayAlertAsync("Error", ex.Message, "Ok");
        }
    }

    private async void BtnHistorial_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new HistorialPage(database));
    }
}
