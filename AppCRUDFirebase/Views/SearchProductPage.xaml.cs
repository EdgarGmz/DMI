using AppCRUDFirebase.Models;
using AppCRUDFirebase.Helpers;

namespace AppCRUDFirebase.Views;

public partial class SearchProductPage : ContentPage
{
	FirebaseHelper firebaseHelper = new FirebaseHelper();
	public SearchProductPage()
	{
		InitializeComponent();
	}

    private async void btnBuscar_Clicked(object sender, EventArgs e)
    {
		string searchText = SearchEntry.Text;
		var productos = await firebaseHelper.GetAllProductos();
		var filteredProductos = productos.Where(p => p.Nombre.Contains(searchText, 
			StringComparison.OrdinalIgnoreCase))
			.ToList();

		ResultListView.ItemsSource = filteredProductos;
    }
}