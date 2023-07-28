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
    public partial class listadoMantenimiento : ContentPage
    {
        private bMantenimiento bmantenimiento = new bMantenimiento(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "AlquilerVehiculos.db3"));
        public listadoMantenimiento()
        {
            InitializeComponent();
            LlenarListado();
        }
        async private void LlenarListado()
        {
            lstMant.ItemsSource = await bmantenimiento.ConsultarTodos();
        }
    }
}