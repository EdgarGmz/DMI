using System;
using System.Collections.Generic;
using System.Text;
using Firebase.Database;
using Firebase.Auth;
using AppCRUDFirebase.Models;
using Firebase.Database.Query;

namespace AppCRUDFirebase.Helpers;

public class FirebaseHelper
{
    private readonly FirebaseClient firebaseClient;
    public FirebaseHelper()
    {
        // Inicializar el cliente de Firebase con la URL de tu base de datos, la url de tu base de datos
        // se encuentra en la consola de firebase, en la sección de base de datos, en la parte superior
        // derecha, debajo del nombre de tu proyecto, ahí encontrarás la url de tu base de datos
        firebaseClient = new FirebaseClient("https://crudfirebase-d2b25-default-rtdb.firebaseio.com/");
    }

    public async Task<List<Producto>> GetAllProductos()
    {
        // Obtener todos los productos desde Firebase
        var productos = await firebaseClient 
            .Child("Productos")
            .OnceAsync<Producto>();

        // Convertir los datos obtenidos de Firebase a una lista de productos
        return productos.Select(item => new Producto
        {
            Id = item.Key,
            Nombre = item.Object.Nombre,
            Descripcion = item.Object.Descripcion,
            Precio = item.Object.Precio
        }).ToList();
    }

    // Agregar un nuevo producto a Firebase
    public async Task AddProduct(Producto producto)
    {
        await firebaseClient
            .Child("Productos")
            .PostAsync(producto);
    }

    // Actualizar un producto existente en Firebase
    public async Task UpdateProducto(string key, Producto producto)
    {
        await firebaseClient
            .Child("Productos")
            .Child(key)
            .PutAsync(producto);
    }

    // Eliminar un producto de Firebase
    public async Task DeleteProducto(string key)
    {
        await firebaseClient
            .Child("Productos")
            .Child(key)
            .DeleteAsync();
    }  

}
