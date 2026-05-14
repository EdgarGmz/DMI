using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using AppCRUD.Models;

namespace AppCRUD.Data;
public class SQLiteHelper
{
    SQLiteAsyncConnection db;
    public SQLiteHelper(string dbPath)
    {
        db = new SQLiteAsyncConnection(dbPath);
        db.CreateTableAsync<Empleados>().Wait();
    }

    // CRUD operations:

    // CREATE
    public Task<int> SaveEmpleadoAsync(Empleados emp)
    {
        if (emp.IdEmp != 0)
        {
            return db.UpdateAsync(emp);
        }
        else
        {
            return db.InsertAsync(emp);
        }
    }

    // READ
    public Task<List<Empleados>> GetEmpleadosAsync()
    {
        return db.Table<Empleados>().ToListAsync();
    }

    // READ by ID
    public Task<Empleados> GetEmpleadosIdAsync(int IdEmpleado)
    {
        return db.Table<Empleados>().Where(a => a.IdEmp == IdEmpleado).FirstOrDefaultAsync();
    }

    // DELETE
    public Task<int> DeleteEmpleadoAsync(Empleados empleado)
    {
        return db.DeleteAsync(empleado);
    } 


}
