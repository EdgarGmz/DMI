using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace BuscarLibroApp;

public partial class MainPage : ContentPage
{
	private readonly ObservableCollection<Book> books;

	public MainPage()
	{
		InitializeComponent();
		books = new ObservableCollection<Book>();
		booksListView.ItemsSource = books;
	}

	private async void btnBuscar_Clicked(object sender, EventArgs e)
	{
		// Obtener el término de búsqueda ingresado por el usuario
		string? query = queryEnter.Text;
		if(string.IsNullOrWhiteSpace(query))
		{
			await DisplayAlertAsync("Error", "Por favor ingrese el título del libro.", "OK");
			return;
		}

		// Llamar al método para obtener los datos de los libros desde la API de Google Books
		string? booksData = await GetBooksDataAsync(query);
		if(booksData != null)
		{
			// Deserializar la respuesta JSON en un objeto BooksResponse
			var booksResponse = JsonConvert.DeserializeObject<BooksResponse>(booksData);

			// Limpiar la colección ObservableCollection antes de agregar los nuevos libros
			books.Clear();

			// Agregar los libros obtenidos a la colección ObservableCollection
			if (booksResponse?.Items != null)
			{
				foreach(var book in booksResponse.Items)
				{
					// Agregar el libro a la colección ObservableCollection
					books.Add(book);
				}
			}
		} 
		else
		{
			await DisplayAlertAsync("Error", "No se encontraron libros para el término de búsqueda ingresado.", "OK");
		}

	}

	private async Task<string?> GetBooksDataAsync(string query)
	{
		using (HttpClient client = new HttpClient())
		{
			try
			{
				// Construir la URL de la API de Google Books con el término de búsqueda
				string url = $"https://www.googleapis.com/books/v1/volumes?q={Uri.EscapeDataString(query)}";

				// Realizar la solicitud HTTP GET a la API de Google Books
				HttpResponseMessage response = await client.GetAsync(url);

				// Verificar si la respuesta fue exitosa
				if (response.IsSuccessStatusCode)
				{
					// Leer el contenido de la respuesta como una cadena JSON
					return await response.Content.ReadAsStringAsync();
				}
			}
			catch (Exception ex)
			{
				// Mostrar un mensaje de error al usuario en caso de que ocurra una excepción
				await DisplayAlertAsync("Error", $"Ocurrió un error al obtener los datos: {ex.Message}", "OK");				
			}
		}

		return null;	
	}

	 public class VolumeInfo
	{
		public string? Title { get; set; }
		public string[]? Authors { get; set; }
		
	}

	public class Book
	{
		public VolumeInfo? VolumeInfo { get; set; }
		
	}

	public class BooksResponse
	{
		public Book[]? Items { get; set; }
	}
	
}
