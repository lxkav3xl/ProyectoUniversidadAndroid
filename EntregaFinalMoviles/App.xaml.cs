using appMoviles_Sabado.Services;
using appMoviles_Sabado.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using appMoviles_Sabado.Datos;
using System.IO;

namespace appMoviles_Sabado
{
    public partial class App : Application
    {
        public static clsBaseDatos _BaseDatos;
        public static clsBaseDatos BaseDatos
        {
            get
            {
                if (_BaseDatos == null)
                {
                    _BaseDatos = new clsBaseDatos(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "AlquilerVehiculos.db3"));
                }
                return _BaseDatos;
            }
        }
        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
            BaseDatos.CrearTablas();
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
