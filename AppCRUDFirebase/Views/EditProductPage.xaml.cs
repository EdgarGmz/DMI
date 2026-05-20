using AppCRUDFirebase.Models;
using AppCRUDFirebase.Helpers;

using Firebase.Database;

namespace AppCRUDFirebase.Views;

public partial class EditProductPage : ContentPage
{
    FirebaseHelper firebaseHelper = new FirebaseHelper();
    private Producto producto;
    public EditProductPage(Producto producto)
	{
		InitializeComponent();

        this.producto = producto;

        NombreEntry.Text = producto.Nombre;
        DescripcionEntry.Text = producto.Descripcion;
        PrecioEntry.Text = producto.Precio.ToString();
	}

    private async void btnActualizar_Clicked(object sender, EventArgs e)
    {
        producto.Nombre = NombreEntry.Text;
        producto.Descripcion = DescripcionEntry.Text;
        producto.Precio = decimal.Parse(PrecioEntry.Text);

        await firebaseHelper.UpdateProducto(producto.Id, producto);
        await DisplayAlertAsync("Éxito", $"Producto {producto.Id} actualizado correctamente", "OK");
        await Navigation.PopAsync();
    }
}