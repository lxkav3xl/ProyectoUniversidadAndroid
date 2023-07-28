using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
//using SQLiteNetExtensions.Attributes;

namespace appMoviles_Sabado.Models
{
    [Table ("tblPacienteIMC")]
    public class PacienteIMC
    {
        [PrimaryKey, AutoIncrement]
        public int Codigo { get; set; }
        [MaxLength(20)]
        public string Documento { get; set; }
        [MaxLength(100)]
        public string Nombre { get; set; }
        [MaxLength(100)]
        public string Apellidos { get; set; }
        public double Peso { get; set; }
        public double Estatura { get; set; }
        public double IMC { get; set; }
        public string EvalucionIMC { get; set; }
    }
    [Table ("tblProveedor")]
    public class Proveedor
    {
        [PrimaryKey, MaxLength(20)]
        public string NIT { get; set; }
        [MaxLength(100)]
        public string Nombre { get; set; }
        [MaxLength(100)]
        public string Direccion { get; set; }
        [MaxLength(20)]
        public string Telefono { get; set; }
        [MaxLength(100)]
        public string Email { get; set; }
        [MaxLength(150)]
        public string Contacto { get; set; }
    }
    public class Producto
    {
        [PrimaryKey, AutoIncrement]
        public int Codigo { get; set; }
        [MaxLength(50)]
        public string Nombre { get; set; }
        public double Precio { get; set; }
        public int Cantidad { get; set; }
    }
    

    [Table("tblVehiculo")]
    public class Vehiculo
    {
        [PrimaryKey, MaxLength(20)]
        public string Placa { get; set; }
        [MaxLength(100)]
        public string Marca { get; set; }
        [MaxLength(100)]
        public string Modelo { get; set; }
        [MaxLength(20)]
        public string NombreProp { get; set; }
        [MaxLength(250)]
        public string Descripcion { get; set; }

        [MaxLength(150)]
        public string Fecha { get; set; }

        [MaxLength(150)]
        public string Contacto { get; set; }
        
        [MaxLength(100)]

        public string Documento { get; set; }
        [MaxLength(100)]

        public Int64 ValorPagar { get; set; }

        public string Tipo { get; set; }
        
    }
    [Table("tblMantenimiento")]
    public class TMantenimiento
    {
        [PrimaryKey, MaxLength(20)]
        public string Placa { get; set; }
        [MaxLength(50)]
        public string Fecha { get; set; }
        [MaxLength(100)]
        public string Tipo { get; set; }
        [MaxLength(100)]
        public string Estado { get; set; }
        
    }

        
}
