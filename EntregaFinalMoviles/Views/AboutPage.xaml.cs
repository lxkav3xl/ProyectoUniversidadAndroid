using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace appMoviles_Sabado.Views
{
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();
        }
        private void btnOp1_Clicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync(nameof(IngresarVehiculo));
        }
        private void btnOp2_Clicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync(nameof(Mantenimiento));
        }
    }
}