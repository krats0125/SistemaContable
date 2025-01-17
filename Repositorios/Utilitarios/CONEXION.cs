using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaContable.Repositorios.Utilitarios
{
    public class CONEXION
    {
        public string conexionRibiSoft()
        {
            string servidor = @"SERVIDOR-PC\SQLEXPRESS";
            string NombreBaseDatos = "Administrativo";
            string Usuario = "sa";
            string Contraseña = "abcd.1234";
            string cadena = $"Data Source={servidor};Initial Catalog={NombreBaseDatos};User ID={Usuario};Password={Contraseña};";

            return cadena;
        }
        public string conexionLaBodegaDeNacho()
        {
            string servidor = @"SERVIDOR-PC\SQLEXPRESS";
            string NombreBaseDatos = "LABODEGADENACHO";
            string Usuario = "sa";
            string Contraseña = "abcd.1234";
            string cadena = $"Data Source={servidor};Initial Catalog={NombreBaseDatos};User ID={Usuario};Password={Contraseña};";

            return cadena;
        }

    }
}
