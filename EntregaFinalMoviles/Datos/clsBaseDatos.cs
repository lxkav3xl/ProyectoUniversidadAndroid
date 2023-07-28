using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using appMoviles_Sabado.Models;

namespace appMoviles_Sabado.Datos
{
    public class clsBaseDatos
    {
        //Permite la conexión con la base de datos
        public SQLiteAsyncConnection oBaseDatos;
        //Variables para crear la base de datos
        public bool bPacienteIMC, bProducto, bProveedor, bProveedorProducto, bVehiculo, bMantenimiento;
        public const SQLite.SQLiteOpenFlags Flags =
        // open the database in read/write mode
        SQLite.SQLiteOpenFlags.ReadWrite |
        // create the database if it doesn't exist
        SQLite.SQLiteOpenFlags.Create |
        // enable multi-threaded database access
        SQLite.SQLiteOpenFlags.SharedCache;

        public clsBaseDatos(string RutaBD)
        {
            oBaseDatos = new SQLiteAsyncConnection(RutaBD, Flags);

            bPacienteIMC = true;
            bProducto = true;
            bProveedor = true;
            bProveedorProducto = true;
            bVehiculo = true;
            bMantenimiento = true;
        }

        public void CrearTablas()
        {
            if (bPacienteIMC) { oBaseDatos.CreateTableAsync<PacienteIMC>().Wait(); }
            if (bProveedor) { oBaseDatos.CreateTableAsync<Proveedor>().Wait(); }
            if (bProducto) { oBaseDatos.CreateTableAsync<Producto>().Wait(); }
            if (bVehiculo) { oBaseDatos.CreateTableAsync<Vehiculo>().Wait(); }
            if (bMantenimiento) { oBaseDatos.CreateTableAsync<TMantenimiento>().Wait(); }
        }
    }
}
