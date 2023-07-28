using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using appMoviles_Sabado.Datos;
using appMoviles_Sabado.Models;
using System.IO;


namespace appMoviles_Sabado.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Mantenimiento : ContentPage
    {
        private bMantenimiento bmantenimiento = new bMantenimiento(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "AlquilerVehiculos.db3"));
        List<string> ListaMantenimiento = new List<string>();
        List<string> ListaEstado = new List<string>();
        public Mantenimiento()
        {
            InitializeComponent();
            ListaMantenimiento.Add("Cambio de llantas");
            ListaMantenimiento.Add("Cambio liquido de frenos");
            ListaMantenimiento.Add("Cambio de aceite");
            ListaMantenimiento.Add("Lavado del vehiculo");
            ListaMantenimiento.Add("Problema en el motor");
            ListaMantenimiento.Add("Calibrar llantas");
            ListaMantenimiento.Add("Tanquear vehiculo");
            ListaMantenimiento.Add("Fallas generales");
            ListaMantenimiento.Add("Pulir rayones");
            ListaEstado.Add("Realizado");
            ListaEstado.Add("En proceso");
            ListaEstado.Add("Pendiente");
            txtMan.ItemsSource = ListaMantenimiento;
            txtEstado.ItemsSource = ListaEstado;
        }

        async private void btnEliminar_Clicked(object sender, EventArgs e)
        {
            if (txtPlaca.Text == "")
            {
                await DisplayAlert("¡ATENCIÓN!", "El campo de placa está vacio, primero debe consultar el registro a eliminar.", "Cerrar");
            }
            else
            {
                String placa = txtPlaca.Text;
                TMantenimiento tmantenimiento = new TMantenimiento();

                tmantenimiento.Placa = placa;

                bmantenimiento.mantenimiento = tmantenimiento;
                await bmantenimiento.Eliminar();
                await DisplayAlert("¡BORRADO!", "Se ha eliminado el registro correctamente.", "Cerrar");
                txtPlaca.Text = "";
                txtFecha.Text = "";
                txtMan.SelectedItem = "";
                txtEstado.SelectedItem = "";

            }
        }

        async private void btnConsultar_Clicked(object sender, EventArgs e)
        {

            string placa = txtPlaca.Text;
            
            TMantenimiento tmantenimiento = await bmantenimiento.ConsultarXPlaca(placa);
            
            txtPlaca.Text = tmantenimiento.Placa;
            txtFecha.Text = tmantenimiento.Fecha;
            txtMan.SelectedItem = tmantenimiento.Tipo;
            txtEstado.SelectedItem = tmantenimiento.Estado;
            await DisplayAlert("¡CONSULTA!", "Se ha consultado el registro correctamente", "Cerrar");

        }

        async private void btnGuardar_Clicked(object sender, EventArgs e)
        {
            string Placa, Fecha, Tipo, Estado;

            Placa = txtPlaca.Text;
            Fecha = txtFecha.Text;
            Tipo = txtMan.SelectedItem.ToString();
            Estado = txtEstado.SelectedItem.ToString();

            TMantenimiento tmantenimiento = new TMantenimiento();

            tmantenimiento.Placa = Placa;
            tmantenimiento.Fecha = Fecha;
            tmantenimiento.Tipo = Tipo;
            tmantenimiento.Estado = Estado;




            bmantenimiento.mantenimiento = tmantenimiento;
            await bmantenimiento.GrabarMantenimiento();

            await DisplayAlert("¡REGISTRO!", "Se ha registrado el mantenimiento correctamente", "Cerrar");
            txtPlaca.Text = "";
            txtFecha.Text = "";
            txtMan.SelectedItem = "";
            txtEstado.SelectedItem = "";

        }

        async private void btnActualizar_Clicked(object sender, EventArgs e)
        {
            string Placa, Fecha, Tipo, Estado;

            Placa = txtPlaca.Text;
            Fecha = txtFecha.Text;
            Tipo = txtMan.SelectedItem.ToString();
            Estado = txtEstado.SelectedItem.ToString();

            TMantenimiento tmantenimiento = new TMantenimiento();

            tmantenimiento.Placa = Placa;
            tmantenimiento.Fecha = Fecha;
            tmantenimiento.Tipo = Tipo;
            tmantenimiento.Estado = Estado;




            bmantenimiento.mantenimiento = tmantenimiento;
            await bmantenimiento.GrabarMantenimiento();

            await DisplayAlert("¡ACTUALIZACIÓN!", "Se ha actualizado correctamente", "Cerrar");
            txtPlaca.Text = "";
            txtFecha.Text = "";
            txtMan.SelectedItem = "";
            txtEstado.SelectedItem = "";

        }

        private void btnLimpiar_Clicked(object sender, EventArgs e)
        {
            txtPlaca.Text = "";
            txtFecha.Text = "";
            txtMan.SelectedItem = "";
            txtEstado.SelectedItem = "";

        }

        private void btnTodos_Clicked(object sender, EventArgs e)
        {
            IrTodos();
        }

        private void IrTodos()
        {
            Shell.Current.GoToAsync(nameof(listadoMantenimiento));
        }

    }
}