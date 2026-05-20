using AppCRUD.Models;

namespace AppCRUD;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        LlenarDatos();
    }

    private async void btnGuardar_Clicked(object sender, EventArgs e)
    {
        if (validarDatos())
        {
            // Crear un nuevo objeto Empleado con los datos ingresados
            Empleados emp = new Empleados
            {
                Nombre = txtEmpleado.Text,
                ApellidoPaterno = txtApPaterno.Text,
                ApellidoMaterno = txtApMaterno.Text,
                Edad = int.Parse(txtEdad.Text),
                Telefono = double.Parse(txtTelefono.Text)
            };

            // Guardar el nuevo empleado en la base de datos
            await App.SQLiteDB.SaveEmpleadoAsync(emp);

            // Limpiar los campos de entrada después de guardar
            LimpiarDatos();
            await DisplayAlertAsync("Aviso", "Empleado guardado exitosamente.", "OK");

            // Actualizar la lista de empleados en el ListView
            LlenarDatos();
        }
        else
        {
            // Mensaje de error si los datos no son válidos
            await DisplayAlertAsync("Aviso", "Por favor, complete todos los campos.", "OK");
        }
    }

    private async void btnActualizar_Clicked(object sender, EventArgs e)
    {
        Empleados emp = new Empleados()
        {
            IdEmp = Convert.ToInt32(txtIdEmp.Text),
            Nombre = txtEmpleado.Text,
            ApellidoPaterno = txtApPaterno.Text,
            ApellidoMaterno = txtApMaterno.Text,
            Edad = int.Parse(txtEdad.Text),
            Telefono = double.Parse(txtTelefono.Text)
        };

        // Lógica para actualizar el empleado en la base de datos
        await App.SQLiteDB.SaveEmpleadoAsync(emp);
        await DisplayAlertAsync("Aviso", "Empleado actualizado exitosamente.", "OK");

        // Actualizar la lista de empleados en el ListView
        txtIdEmp.Text = string.Empty;
        txtEmpleado.Text = string.Empty;
        txtApPaterno.Text = string.Empty;
        txtApMaterno.Text = string.Empty;
        txtEdad.Text = string.Empty;
        txtTelefono.Text = string.Empty;

        txtIdEmp.IsVisible = false;
        btnActualizar.IsVisible = false;
        btnGuardar.IsVisible = true;

        LlenarDatos();
    }

    private async void btnEliminar_Clicked(object sender, EventArgs e)
    {
        // Obtener Empleado por ID
        var empleado = await App.SQLiteDB.GetEmpleadosIdAsync(Convert.ToInt32(txtIdEmp.Text));

        if(empleado != null)
        {
            // Eliminar el empleado de la base de datos
            await App.SQLiteDB.DeleteEmpleadoAsync(empleado);
            await DisplayAlertAsync("Aviso", $"Empleado {empleado.Nombre} eliminado exitosamente.", "OK");

            // Limpiar los campos de entrada después de eliminar
            txtIdEmp.Text = string.Empty;
            LimpiarDatos();
            txtIdEmp.IsVisible = false;
            btnGuardar.IsVisible = true;
            btnActualizar.IsVisible = false;
            btnEliminar.IsVisible = false;

            // Actualizar la lista de empleados en el ListView
            LlenarDatos();
        }
    }

    private async void lsEmpleados_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        // 
        var obj = (Empleados)e.SelectedItem;
        btnGuardar.IsVisible = false;
        txtIdEmp.IsVisible = true;
        btnActualizar.IsVisible = true;
        btnEliminar.IsVisible = true;

        if (!string.IsNullOrEmpty(obj.IdEmp.ToString()))
        {
            var empleado = await App.SQLiteDB.GetEmpleadosIdAsync(obj.IdEmp);

            if(empleado != null)
            {
                txtIdEmp.Text = empleado.IdEmp.ToString();
                txtEmpleado.Text = empleado.Nombre;
                txtApPaterno.Text = empleado.ApellidoPaterno;
                txtApMaterno.Text = empleado.ApellidoMaterno;
                txtEdad.Text = empleado.Edad.ToString();
                txtTelefono.Text = empleado.Telefono.ToString();
            }
            else
            {
                DisplayAlertAsync("Error", "No se pudo encontrar el empleado seleccionado.", "OK");
            }
        }
    }

    // Utilidades para validar, limpiar y llenar datos
    public bool validarDatos()
    {
        bool res = true;

        if (string.IsNullOrEmpty(txtEmpleado.Text))
        {
            res = false;
        }
        else if (string.IsNullOrEmpty(txtApPaterno.Text))
        {
            res = false;
        }
        else if (string.IsNullOrEmpty(txtApMaterno.Text))
        {
            res = false;
        }
        else if (string.IsNullOrEmpty(txtEdad.Text))
        {
            res = false;
        }
        else if (string.IsNullOrEmpty(txtTelefono.Text))
        {
            res = false;
        }

        return res;
    }

    public void LimpiarDatos()
    {
        txtEmpleado.Text = string.Empty;
        txtApPaterno.Text = string.Empty;
        txtApMaterno.Text = string.Empty;
        txtEdad.Text = string.Empty;
        txtTelefono.Text = string.Empty;
    }

    public async void LlenarDatos()
    {
        // Obtener la lista de empleados desde la base de datos
        var empleadosList = await App.SQLiteDB.GetEmpleadosAsync();

        // Validamos que la lista no sea nula antes de asignarla al ListView
        if (empleadosList != null)
        {
            lsEmpleados.ItemsSource = empleadosList;
        }
    }
}
