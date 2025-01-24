using SistemaContable.Modelos;
using SistemaContable.Repositorios;
using SistemaContable.Repositorios.Utilitarios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace SistemaContable.Presentacion
{
    public partial class FrmPagoMensajeros : Form
    {
        CONEXION conexion = new CONEXION();
        PagoMensajeros pago=new PagoMensajeros();
        Trabajador trabajador;
        public FrmPagoMensajeros(Trabajador trabajador)
        {
            InitializeComponent();
            this.trabajador = trabajador;
            lbDocumento.Text = trabajador.Documento;
            lbNombre.Text = trabajador.Nombre;

        }
        private void FrmPagoMensajeros_Load(object sender, EventArgs e)
        {
            TraerPrestamos();
            dgvDeudas.ClearSelection();
        }
        private void TraerPrestamos()
        {
            try
            {
                string consulta = @"select pm.iDPrestamo,pm.Fecha, pm.Valor, pm.Concepto, pm.Caja, pm.Cajero  
                            from MENSAJEROS m 
                            inner join PRESTAMOS_MENSAJEROS pm on m.IdTrabajador = pm.IdTrabajador
                            where (m.nombre = @nombre or m.IdTrabajador = @documento) 
                            and pm.Pagado = 0";

          
                using (SqlConnection connection = new SqlConnection(conexion.conexionLaBodegaDeNacho()))
                {
                    using (SqlCommand cmd = new SqlCommand(consulta, connection))
                    {

                        cmd.Parameters.AddWithValue("@nombre", string.IsNullOrEmpty(trabajador.Nombre) ? DBNull.Value : (object)trabajador.Nombre);
                        cmd.Parameters.AddWithValue("@documento", string.IsNullOrEmpty(trabajador.Documento) ? DBNull.Value : (object)trabajador.Documento);

                        connection.Open();

                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            dgvDeudas.DataSource = dt;
                            if (dgvDeudas.Columns.Contains("iDPrestamo"))
                            {
                                dgvDeudas.Columns["iDPrestamo"].Visible = false;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ActualizarPago()
        {
            
            pago.FichosSemana=Convertir(txtFichos.Text);
            pago.FichosDomingo = Convertir(txtFichosDomingo.Text);
            pago.OtrosServicios = Convertir(txtOtrosServicios.Text);
            pago.Pendiente = Convertir(txtPendiente.Text);


            pago.calcularPago(cbAprobo.Checked);
            lbPago.Text = pago.TotalPago.ToString("C0");
        }

        private decimal Convertir(string valor)
        {
            decimal resultado = 0;
            decimal.TryParse(valor, out resultado);
            return resultado;
        }

        private void dgvDeudas_SelectionChanged(object sender, EventArgs e)
        {
            pago.Deuda = 0;
            foreach (DataGridViewRow row in dgvDeudas.SelectedRows)
            {
                pago.Deuda += Convert.ToDecimal(row.Cells["Valor"].Value);
            }
            lbDeuda.Text = pago.Deuda.ToString("C0");
            ActualizarPago();
        }

        private void txtFichos_TextChanged(object sender, EventArgs e)
        {
            ActualizarPago();
        }

        private void txtPendiente_TextChanged(object sender, EventArgs e)
        {
            ActualizarPago();
        }

        private void txtFichosDomingo_TextChanged(object sender, EventArgs e)
        {
            ActualizarPago();
        }

        private void txtOtrosServicios_TextChanged(object sender, EventArgs e)
        {
            ActualizarPago();
        }

        private void lbDeuda_Click(object sender, EventArgs e)
        {
            ActualizarPago();
        }

        private void lbDeuda_TextChanged(object sender, EventArgs e)
        {
            ActualizarPago();
        }

        private void cbAprobo_CheckedChanged(object sender, EventArgs e)
        {
            ActualizarPago();
        }
        private void btnGenerarPago_Click(object sender, EventArgs e)
        {
            try
            {
                CuentaDeCobroRepository cuenta = new CuentaDeCobroRepository();
                int numeroCuenta = cuenta.hallarCuentaCobro(trabajador);
                string valorEnLetras = ConvertirRepository.ConvertirNumeroALetras(pago.TotalPago);
                CuentaCobro cuentaCobro = new CuentaCobro
                {
                    Nombre = trabajador.Nombre,
                    Documento = trabajador.Documento,
                    Fecha = DateTime.Now,
                    Valor = pago.Valor,
                    Fichos=pago.FichosTotales,
                    deuda = pago.Deuda,
                    TotalPago = pago.TotalPago,
                    Concepto = "Prestación de servicios de entregas de mercancia",
                    NumeroCuenta =numeroCuenta,
                    ValorLetras = valorEnLetras,
                    OtrosServicios=pago.OtrosServicios
                };
                string nombreArchivo = string.Join("_", trabajador.Nombre.Split(Path.GetInvalidFileNameChars()));
                string NumeroCuenta = numeroCuenta.ToString();
                string rutaArchivo = Path.Combine(@"Z:\APP BODEGA DE NACHO\Nuevos projectos\proyecto_Tesoreria\Cuenta de cobro prueba", $"{nombreArchivo}_CUENTA DE COBRO N°{numeroCuenta}.pdf");
                //string rutaLogo = @"Z:\APP BODEGA DE NACHO\Nuevos projectos\Formatos windows Forms\Logo.png"; 

                cuenta.GenerarPDF(cuentaCobro, rutaArchivo);
                PagoMensajerosRepository mensajerosRepository = new PagoMensajerosRepository();
                foreach (DataGridViewRow row in dgvDeudas.SelectedRows)
                {
                    int idPrestamo = Convert.ToInt32(row.Cells["iDPrestamo"].Value);
                    mensajerosRepository.ActualizarPrestamo(idPrestamo);
                }
                mensajerosRepository.InsertarPago(cuentaCobro);

                MessageBox.Show("Cuenta de cobro generado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar el PDF: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }




        }
    }
}
