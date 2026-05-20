using AppCRUDFirebase.Models;
using AppCRUDFirebase.Helpers;
 
namespace AppCRUDFirebase.Views;

public partial class AddProductPage : ContentPage
{
	FirebaseHelper firebaseHelper = new FirebaseHelper();
	public AddProductPage()
	{
		InitializeComponent();
	}

    private async void btnAgregar_Clicked(object sender, EventArgs e)
    {
		var producto = new Producto
		{
			Nombre = NombreEntry.Text,
			Descripcion = DescripcionEntry.Text,
			Precio = decimal.Parse(PrecioEntry.Text)
		};

		await firebaseHelper.AddProduct(producto);
		await DisplayAlertAsync("Éxito", $"Producto {producto.Nombre} Agreagado", "Ok");
		await Navigation.PopAsync();
    }
}