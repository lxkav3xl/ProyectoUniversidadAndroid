using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using appMoviles_Sabado.Datos;
using System.IO;

namespace appMoviles_Sabado.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class listadoAutos : ContentPage
    {
        private bVehiculo bvehiculo = new bVehiculo(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "AlquilerVehiculos.db3"));

        public listadoAutos()
        {
            InitializeComponent();
            LlenarListado();
        }
        
        async private void LlenarListado()
        {
            lstVehiculos.ItemsSource = await bvehiculo.ConsultarTodos();
        }
    }
}