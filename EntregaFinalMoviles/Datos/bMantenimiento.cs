using System;
using System.Collections.Generic;
using System.Text;
using SQLite;//Para manipular los datos en la base de datos
using appMoviles_Sabado.Models;//Para utilizar los modelos (vistas) de las clases
using System.Threading.Tasks;

namespace appMoviles_Sabado.Datos
{
    public class bMantenimiento
    {
        readonly SQLiteAsyncConnection baseDatos;
        public TMantenimiento mantenimiento { get; set; }

        public bMantenimiento(string RutaDB)
        {
            baseDatos = new SQLiteAsyncConnection(RutaDB);
        }

        public Task<int> GrabarMantenimiento()
        {

            //Se debe consultar el paciente, antes de procesarlo
            TMantenimiento _mantenimiento = ConsultarXPlaca(mantenimiento.Placa).Result;

            if (_mantenimiento == null)
            {
                //El paciente no existe, se debe grabar
                return baseDatos.InsertAsync(mantenimiento);
            }
            else
            {
                mantenimiento.Placa = _mantenimiento.Placa;
                //Existe, se debe actualizar
                return baseDatos.UpdateAsync(mantenimiento);
            }

        }

        public Task<TMantenimiento> ConsultarXPlaca(string Placa)
        {
            
            return baseDatos.Table<TMantenimiento>()
                    .Where(p => p.Placa == Placa)
                    .FirstOrDefaultAsync();
        }

        public Task<int> Eliminar()
        {
            return baseDatos.DeleteAsync(mantenimiento);
        }

        public Task<List<TMantenimiento>> ConsultarTodos()
        {
            return baseDatos.Table<TMantenimiento>()
                .ToListAsync();
        }

    }
}
