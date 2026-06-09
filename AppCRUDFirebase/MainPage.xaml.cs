using AppCRUDFirebase.Views;

namespace AppCRUDFirebase;

public partial class MainPage : ContentPage
{     

    public MainPage()
    {
        InitializeComponent();
    }        

    private async void btnAgregarP_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AddProductPage());
    }

    private async void btnListarP_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ListProductPage());
    }

    private async void btnBuscarP_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new SearchProductPage());
    }
}
