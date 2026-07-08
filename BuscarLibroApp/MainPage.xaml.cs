using System.Collections.ObjectModel;
using System.Net;
using Newtonsoft.Json;

namespace BuscarLibroApp;

public partial class MainPage : ContentPage
{
	private readonly ObservableCollection<Book> books;
	private static readonly HttpClient httpClient = new HttpClient();

	public MainPage()
	{
		InitializeComponent();
		books = new ObservableCollection<Book>();
		booksListView.ItemsSource = books;
	}

	private async void btnBuscar_Clicked(object sender, EventArgs e)
	{
		// Obtener el término de búsqueda ingresado por el usuario
		string query = queryEnter.Text?.Trim() ?? string.Empty;
		if (string.IsNullOrWhiteSpace(query))
		{
			await DisplayAlertAsync("Error", "Por favor ingrese el título del libro.", "OK");
			return;
		}

		// Llamar al método para obtener los datos de los libros desde la API de Google Books
		BooksResponse? booksResponse = await GetBooksDataAsync(query);
		if (booksResponse != null)
		{
			// Limpiar la colección ObservableCollection antes de agregar los nuevos libros
			books.Clear();

			// Agregar los libros obtenidos a la colección ObservableCollection
			if (booksResponse?.Items != null && booksResponse.Items.Length > 0)
			{
				foreach(var book in booksResponse.Items)
				{
					// Agregar el libro a la colección ObservableCollection
					books.Add(book);
				}
			}
			else
			{
				await DisplayAlertAsync("Sin resultados", $"No se encontraron libros para: '{query}'.", "OK");
			}
		} 
		else
		{
			await DisplayAlertAsync("Error", "No se pudieron obtener datos del servidor.", "OK");
		}

	}

	private async Task<BooksResponse?> GetBooksDataAsync(string query)
	{
		string apiKey = "AIzaSyDdJIEMdZmyY3MUkOL45SsHH3-2r2ASbrQ";
		try
		{
			// Codificar el término evita búsquedas inválidas cuando hay espacios o caracteres especiales.
			string encodedQuery = WebUtility.UrlEncode(query);
			string url = $"https://www.googleapis.com/books/v1/volumes?q={encodedQuery}&maxResults=20&printType=books&key={apiKey}";

			// Realizar la solicitud HTTP GET a la API de Google Books
			HttpResponseMessage response = await httpClient.GetAsync(url);
			string content = await response.Content.ReadAsStringAsync();

			if (!response.IsSuccessStatusCode)
			{
				await DisplayAlertAsync("Error de API", $"HTTP {(int)response.StatusCode}: {response.ReasonPhrase}\nDetalle: {content}", "OK");
				return null;
			}

			var booksResponse = JsonConvert.DeserializeObject<BooksResponse>(content);
			if (!string.IsNullOrWhiteSpace(booksResponse?.Error?.Message))
			{
				await DisplayAlertAsync("Error de API", booksResponse!.Error!.Message!, "OK");
				return null;
			}

			return booksResponse;
		}
		catch (Exception ex)
		{
			// Mostrar un mensaje de error al usuario en caso de que ocurra una excepción
			await DisplayAlertAsync("Excepción de Red", $"Ocurrió un error al obtener los datos: {ex.Message}", "OK");
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
		public int TotalItems { get; set; }
		public Book[]? Items { get; set; }
		public ApiError? Error { get; set; }
	}

	public class ApiError
	{
		public string? Message { get; set; }
	}
	
}
