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
    public class PagoProveedoresRepository
    {
        CONEXION conexion = new CONEXION();
        PagoProveedores pago=new PagoProveedores();
        public void InsertarPago()
        {
            string consulta = @"insert into tbl_PagosProveedores(FechaIngreso,Id_Proveedor,Valor,ValorPagado,Factura,Credito,Descuento,Medio_de_pago,Banco,Pagada,FechaVencimiento,FechaPagado,Pagador,RetencionEnLaFuente)
                              values(@FechaIngreso,@Id_Proveedor,@Valor,@ValorPagado,@Factura,@Credito,@Descuento,@Medio_de_pago,@Banco,@Pagada,@FechaVencimiento,@FechaPagado,@Pagador,@RetencionEnLaFuente)";
            using (SqlConnection cn = new SqlConnection(conexion.conexionLaBodegaDeNacho()))
            {
                cn.Open();
                using (SqlCommand cmd=new SqlCommand(consulta,cn))
                {
                    cmd.Parameters.AddWithValue("@FechaIngreso", DateTime.Now);
                    cmd.Parameters.AddWithValue("@Id_Proveedor", pago.idProveedor);
                    cmd.Parameters.AddWithValue("@Valor", pago.valor);
                    cmd.Parameters.AddWithValue("@ValorPagado", pago.valorPagado);
                    cmd.Parameters.AddWithValue("@Factura", pago.Factura);
                    cmd.Parameters.AddWithValue("@Credito", pago.Credito);
                    cmd.Parameters.AddWithValue("@Descuento", pago.Descuento);
                    cmd.Parameters.AddWithValue("@Medio_de_pago", pago.MedioPago);
                    cmd.Parameters.AddWithValue("@Banco", pago.Banco);
                    cmd.Parameters.AddWithValue("@Pagada", pago.Pagado);
                    cmd.Parameters.AddWithValue("@FechaVencimiento", pago.fechaVencimiento);
                    cmd.Parameters.AddWithValue("@FechaPagado", DateTime.Now);
                    cmd.Parameters.AddWithValue("@Pagador", pago.Pagador);
                    cmd.Parameters.AddWithValue("@RetencionEnLaFuente", pago.retencionFuente);
                    cmd.ExecuteNonQuery();
                }
            }

        }
    }
}
