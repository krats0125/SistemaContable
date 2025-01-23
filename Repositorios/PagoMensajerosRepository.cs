using SistemaContable.Modelos;
using SistemaContable.Repositorios.Utilitarios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SistemaContable.Repositorios
{
    public class PagoMensajerosRepository
    {
        CONEXION conexion = new CONEXION(); 
        CuentaCobro cuentaCobro = new CuentaCobro();
        public void ActualizarPrestamo(int idPrestamo)
        {
            //string consulta = "update PRESTAMOS_MENSAJEROS set Pagado=1 where iDPrestamo=@IdPrestamo";
            string consulta = "update PRESTAMOS_MENSAJEROS2 set Pagado=1 where iDPrestamo=@IdPrestamo";
            using (SqlConnection cn = new SqlConnection(conexion.conexionLaBodegaDeNacho()))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(consulta, cn))
                {
                    cmd.Parameters.AddWithValue("@IdPrestamo", idPrestamo);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void InsertarPago(CuentaCobro cuentaCobro)
        {
            //string consulta = @"insert into tbl_PagoMensajeros (Fecha,Id_Mensajero,Nombre,CuentaDeCobro,Valor,ValorTexto,Adelanto,TotalPago,Fichos,OtrosServicios)
                              //values(@fecha,@documento,@nombre,@cuentadecobro,@valor,@valortexto,@adelanto,@totalpago,@fichos,@otrosservicios)";
            string consulta = @"insert into tbl_PagoMensajerosPrueba (Fecha,Id_Mensajero,Nombre,CuentaDeCobro,Valor,ValorTexto,Adelanto,TotalPago,Fichos,OtrosServicios)
                               values (@fecha,@documento,@nombre,@cuentadecobro,@valor,@valortexto,@adelanto,@totalpago,@fichos,@otrosservicios)";
            using (SqlConnection cn = new SqlConnection(conexion.conexionLaBodegaDeNacho()))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(consulta, cn))
                {
                    cmd.Parameters.AddWithValue("@fecha", DateTime.Now);
                    cmd.Parameters.AddWithValue("@documento", cuentaCobro.Documento);
                    cmd.Parameters.AddWithValue("@nombre", cuentaCobro.Nombre);
                    cmd.Parameters.AddWithValue("@cuentadecobro", cuentaCobro.NumeroCuenta);
                    cmd.Parameters.AddWithValue("@valor", cuentaCobro.Valor);
                    cmd.Parameters.AddWithValue("@valortexto", cuentaCobro.ValorLetras);
                    cmd.Parameters.AddWithValue("@adelanto", cuentaCobro.deuda);
                    cmd.Parameters.AddWithValue("@totalpago", cuentaCobro.TotalPago);
                    cmd.Parameters.AddWithValue("@fichos", cuentaCobro.Fichos);
                    cmd.Parameters.AddWithValue("@otrosservicios", cuentaCobro.OtrosServicios);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        
    }
}
