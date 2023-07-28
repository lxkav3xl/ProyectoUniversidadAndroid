using System;
using System.Collections.Generic;
using System.Text;
using SQLite;//Para manipular los datos en la base de datos
using appMoviles_Sabado.Models;//Para utilizar los modelos (vistas) de las clases
using System.Threading.Tasks;



namespace appMoviles_Sabado.Datos
{
    public class bVehiculo
    {
        readonly SQLiteAsyncConnection baseDatos;
        public Vehiculo vehiculo { get; set; }
        public bVehiculo(string RutaDB)
        {
            //Abre la conexión a la base de datos
            baseDatos = new SQLiteAsyncConnection(RutaDB);
        }
       
        public Task<int> GrabarVehiculo()
        {
          
            //Se debe consultar el paciente, antes de procesarlo
            Vehiculo _vehiculo = ConsultarXPlaca(vehiculo.Placa).Result;

            if (_vehiculo == null)
            {
                //El paciente no existe, se debe grabar
                return baseDatos.InsertAsync(vehiculo);
            }
            else
            {
                vehiculo.Placa = _vehiculo.Placa;
                //Existe, se debe actualizar
                return baseDatos.UpdateAsync(vehiculo);
            }
        }
        public Task<Vehiculo> ConsultarXPlaca(string Placa)
        {
            return baseDatos.Table<Vehiculo>()
                    .Where(p => p.Placa == Placa)
                    .FirstOrDefaultAsync();
        }
        public Task<int> Eliminar()
        {
            return baseDatos.DeleteAsync(vehiculo);
        }
        public Task<List<Vehiculo>> ConsultarTodos()
        {
            return baseDatos.Table<Vehiculo>()
                .ToListAsync();
        }

    }
}
