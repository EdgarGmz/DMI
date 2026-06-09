using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;

using AppGrabar.Database;

namespace AppGrabar
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddSingleton<AppDatabase>(
                    s => 
                    {
                        string ruta = Path.Combine(FileSystem.AppDataDirectory, "video.db3");
                        return new AppDatabase(ruta);
                    }
                );
#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
