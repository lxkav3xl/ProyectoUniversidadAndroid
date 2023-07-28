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
    public partial class IngresarVehiculo : ContentPage
    {
        private bVehiculo bvehiculo = new bVehiculo(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "AlquilerVehiculos.db3"));
        List<string> ListaTipo = new List<string>();
        public IngresarVehiculo()
        {
            InitializeComponent();
            ListaTipo.Add("Motocicleta");
            ListaTipo.Add("Automovil");
            ListaTipo.Add("Camion");
            txtTipo.ItemsSource = ListaTipo;
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
                Vehiculo vehiculo = new Vehiculo();

                vehiculo.Placa = placa;

                bvehiculo.vehiculo = vehiculo;
                await bvehiculo.Eliminar();
                await DisplayAlert("¡BORRADO!", "Se ha borrado el alquiler correctamente", "Cerrar");
                txtPlaca.Text = "";
                txtMarca.Text = "";
                txtModelo.Text = "";
                txtNombreProp.Text = "";
                txtDescripcion.Text = "";
                txtFecha.Text = "";
                txtContacto.Text = "";
                txtDocumento.Text = "";
                
            }
        }

        //Para poder ejecutar una tarea (Asíncrona), se debe crear el método como asincrono y consultar con await
        async private void btnConsultar_Clicked(object sender, EventArgs e)
        {

            string placa = txtPlaca.Text;

            Vehiculo vehiculo = await bvehiculo.ConsultarXPlaca(placa);
            txtPlaca.Text = vehiculo.Placa;
            txtMarca.Text = vehiculo.Marca;
            txtModelo.Text = vehiculo.Modelo;
            txtNombreProp.Text = vehiculo.NombreProp;
            txtDescripcion.Text = vehiculo.Descripcion;
            txtFecha.Text = vehiculo.Fecha;
            txtContacto.Text = vehiculo.Contacto;
            txtDocumento.Text = vehiculo.Documento;
            txtTipo.SelectedItem = vehiculo.Tipo;
            txtValor.Text = "El valor a pagar es: $" + vehiculo.ValorPagar.ToString();
            await DisplayAlert("¡CONSULTA!", "Se ha consultado el alquiler correctamente", "Cerrar");

        }
        async private void btnGuardar_Clicked(object sender, EventArgs e)
        {
            string Placa, Marca, Modelo, NombreProp, Descripcion, Fecha, Contacto, Documento, Tipo; 
            Int64 Valor = 0;

            Placa = txtPlaca.Text;
            Marca = txtMarca.Text;
            Modelo = txtModelo.Text;
            NombreProp = txtNombreProp.Text;
            Descripcion = txtDescripcion.Text;
            Fecha = txtFecha.Text;
            Contacto = txtContacto.Text;
            Documento = txtDocumento.Text;
            Tipo = txtTipo.SelectedItem.ToString();
            if (Tipo == "Camion")
            {
                Valor = Int64.Parse(txtDescripcion.Text) * 20300;
            }
            else if (Tipo == "Automovil")
            {
                Valor = Int64.Parse(txtDescripcion.Text) * 15400;
            }
            else if (Tipo == "Motocicleta")
            {
                Valor = Int64.Parse(txtDescripcion.Text) * 9750;
            }

            Vehiculo vehiculo = new Vehiculo();

            vehiculo.Placa = Placa;
            vehiculo.Marca = Marca;
            vehiculo.Modelo = Modelo;
            vehiculo.NombreProp = NombreProp;
            vehiculo.Descripcion = Descripcion;
            vehiculo.Fecha = Fecha;
            vehiculo.Contacto = Contacto;
            vehiculo.Documento = Documento;
            vehiculo.ValorPagar = Valor;
            vehiculo.Tipo = Tipo;
            txtValor.Text = "El valor a pagar es: $"+Valor.ToString();




            bvehiculo.vehiculo = vehiculo;
            await bvehiculo.GrabarVehiculo();
            await DisplayAlert("¡REGISTRO!", "Se ha registrado el alquiler correctamente", "Cerrar");
            



        }
        async private void btnActualizar_Clicked(object sender, EventArgs e)
        {
            string Placa, Marca, Modelo, NombreProp, Descripcion, Fecha, Contacto, Documento, Tipo;
            Int64 Valor = 0;

            Placa = txtPlaca.Text;
            Marca = txtMarca.Text;
            Modelo = txtModelo.Text;
            NombreProp = txtNombreProp.Text;
            Descripcion = txtDescripcion.Text;
            Fecha = txtFecha.Text;
            Contacto = txtContacto.Text;
            Documento = txtDocumento.Text;
            Tipo = txtTipo.SelectedItem.ToString();
            if (Tipo == "Camion")
            {
                Valor = Int64.Parse(txtDescripcion.Text) * 20300;
            }
            else if (Tipo == "Automovil")
            {
                Valor = Int64.Parse(txtDescripcion.Text) * 15400;
            }
            else if (Tipo == "Motocicleta")
            {
                Valor = Int64.Parse(txtDescripcion.Text) * 9750;
            }

            Vehiculo vehiculo = new Vehiculo();

           

            

            vehiculo.Placa = Placa;
            vehiculo.Marca = Marca;
            vehiculo.Modelo = Modelo;
            vehiculo.NombreProp = NombreProp;
            vehiculo.Descripcion = Descripcion;
            vehiculo.Fecha = Fecha;
            vehiculo.Contacto = Contacto;
            vehiculo.Documento = Documento;
            vehiculo.ValorPagar = Valor;
            vehiculo.Tipo = Tipo;
            txtValor.Text = "El valor a pagar es: $" + vehiculo.ValorPagar.ToString();




            bvehiculo.vehiculo = vehiculo;
            await bvehiculo.GrabarVehiculo();
            await DisplayAlert("¡ACTUALIZACIÓN!", "Se ha actualizado el alquiler correctamente", "Cerrar");
           


        }

        private void btnLimpiar_Clicked(object sender, EventArgs e)
        {
            txtPlaca.Text = "";
            txtMarca.Text = "";
            txtModelo.Text = "";
            txtNombreProp.Text = "";
            txtDescripcion.Text = "";
            txtFecha.Text = "";
            txtContacto.Text = "";
            txtDocumento.Text = "";
            txtTipo.SelectedItem = "";
            txtValor.Text = "";


        }

        private void btnTodos_Clicked(object sender, EventArgs e)
        {
            IrTodos();
        }
        private void IrTodos()
        {
            Shell.Current.GoToAsync(nameof(listadoAutos));
        }
    }
}