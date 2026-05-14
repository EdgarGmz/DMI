using Microsoft.Extensions.DependencyInjection;
using AppCRUD.Data;

namespace AppCRUD;

public partial class App : Application
{
    static SQLiteHelper db;
    public App()
    {
        InitializeComponent();

    }
    public static SQLiteHelper SQLiteDB
    {
        get
        {
            if (db == null)
            {
                // Si no existe la base de datos, se crea en la carpeta de datos local de la aplicación
                db = new SQLiteHelper(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Empresa.db3"));
            }

            return db;
        }


        
    }
    protected override Window CreateWindow(IActivationState? activationState)
    {
        return new Window(new AppShell());
    }
}