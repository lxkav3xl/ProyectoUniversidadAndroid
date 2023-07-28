using appMoviles_Sabado.ViewModels;
using appMoviles_Sabado.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace appMoviles_Sabado
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(IngresarVehiculo), typeof(IngresarVehiculo));
            Routing.RegisterRoute(nameof(Mantenimiento), typeof(Mantenimiento));
            Routing.RegisterRoute(nameof(listadoAutos), typeof(listadoAutos));
            Routing.RegisterRoute(nameof(listadoMantenimiento), typeof(listadoMantenimiento));


        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            //await Shell.Current.GoToAsync("//LoginPage");nameof(listadoAutos)
            await Shell.Current.GoToAsync(nameof(IngresarVehiculo)); 
        }
    }
}
