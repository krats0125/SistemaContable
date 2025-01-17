using SistemaContable.Modelos;
using SistemaContable.Repositorios.Utilitarios;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaContable.Repositorios
{
    public class PrestamoMensajerosRepository
    {
        CONEXION conexion = new CONEXION();
        public bool InsertarPrestamo(PrestamoMensajero oPrestamo)
        {         
            bool respuesta = false;
            using (SqlConnection cn=new SqlConnection(conexion.conexionLaBodegaDeNacho()))
            {
                //string consulta = @"insert into PRESTAMOS_MENSAJEROS(Fecha,IdTrabajador,Valor,Concepto,Autoriza,Observacion)
                //                    values (@fecha,@idtrabajador,@valor,@concepto,@autoriza,@observacion)";
                string consulta = @"insert into PRESTAMOS_MENSAJEROS2(Fecha,IdTrabajador,Valor,Concepto,Autoriza,Observacion)
                                    values (@fecha,@idtrabajador,@valor,@concepto,@autoriza,@observacion)";
                using (SqlCommand cmd = new SqlCommand(consulta, cn))
                {
                    cmd.Parameters.AddWithValue("@IdTrabajador", oPrestamo.Documento);
                    cmd.Parameters.AddWithValue("@Fecha", DateTime.Now);
                    cmd.Parameters.AddWithValue("@Valor", oPrestamo.Valor);
                    cmd.Parameters.AddWithValue("@Concepto", oPrestamo.Concepto);
                    cmd.Parameters.AddWithValue("@autoriza", oPrestamo.Autoriza);
                    cmd.Parameters.AddWithValue("@observacion", oPrestamo.Observacion);
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    respuesta = true;

                }

            }
            return respuesta;
        }
    }
}
