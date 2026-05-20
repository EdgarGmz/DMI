using AppCRUDFirebase.Models;
using AppCRUDFirebase.Helpers;

namespace AppCRUDFirebase.Views;

public partial class ListProductPage : ContentPage
{
    FirebaseHelper firebaseHelper = new FirebaseHelper();
	public ListProductPage()
	{
		InitializeComponent();
        LoadProducts();
        
    }

    // Método para cargar los productos desde Firebase y mostrarlos en la ListView
    private async void LoadProducts()
    {
        // Obtener la lista de productos desde Firebase
        var productos = await firebaseHelper.GetAllProductos();

        // Asignar la lista de productos a la propiedad ItemsSource de la ListView
        ProductListView.ItemsSource = productos;
    }

    private async void btnEditar_Clicked(object sender, EventArgs e)
    {
        // Obtener el producto asociado al botón de editar
        var button = sender as Button;
        // El BindingContext del botón es el producto al que está asociado
        var producto = button?.BindingContext as Producto;

        if(producto != null)
        {
            // Navegar a la página de edición de producto, pasando el producto seleccionado
            await Navigation.PushAsync(new EditProductPage(producto));
        }
    }

    private async void btnEliminarP_Clicked(object sender, EventArgs e)
    {
        // Obtener el producto asociado al botón de eliminar
        var button = sender as Button;

        // El BindingContext del botón es el producto al que está asociado
        var producto = button?.BindingContext as Producto;

        if(producto != null && !string.IsNullOrEmpty(producto.Id))
        {
            // Eliminar el producto de Firebase utilizando su ID
            await firebaseHelper.DeleteProducto(producto.Id);

            // Mostrar mensaje de confirmación
            await DisplayAlertAsync("Producto Eliminado", $"El producto '{producto.Nombre}' ha sido eliminado.", "OK");

            // Recargar la lista de productos después de eliminar uno
            LoadProducts();
        }
        else
        {
            // Mostrar mensaje de error si no se pudo eliminar el producto
            await DisplayAlertAsync("Error", "No se pudo encontrar el producto para eliminar. Inténtalo de nuevo.", "OK");
        }
    }

    private async void btnRegresar_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}