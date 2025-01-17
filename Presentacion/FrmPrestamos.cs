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

namespace SistemaContable.Presentacion
{
    public partial class FrmPrestamos : Form
    {
        CONEXION conexion = new CONEXION();
        Trabajador trabajador;
        public FrmPrestamos(Trabajador trabajador)
        {
            InitializeComponent();
            this.trabajador = trabajador;
            lbNombre.Text = trabajador.Nombre;
            lbDocumento.Text = trabajador.Documento;
        }
        private void FrmPrestamos_Load(object sender, EventArgs e)
        {
            traerDeudas();
        }

        private void traerDeudas()
        {
            try
            {
                string consulta = @"select pm.iDPrestamo,pm.Fecha, pm.Valor, pm.Concepto, pm.Caja, pm.Cajero  
                            from MENSAJEROS m 
                            inner join PRESTAMOS_MENSAJEROS pm on m.IdTrabajador = pm.IdTrabajador
                            where (m.nombre = @nombre or m.IdTrabajador = @documento) 
                            and pm.Pagado = 0";
                using (SqlConnection cn = new SqlConnection(conexion.conexionLaBodegaDeNacho()))
                {
                   
                    using (SqlCommand cmd = new SqlCommand(consulta, cn))
                    {
                        cmd.Parameters.AddWithValue("@nombre", string.IsNullOrEmpty(trabajador.Nombre) ? DBNull.Value : (object)trabajador.Nombre);
                        cmd.Parameters.AddWithValue("@documento", string.IsNullOrEmpty(trabajador.Documento) ? DBNull.Value : (object)trabajador.Documento);
                        cn.Open();
                        using (SqlDataAdapter adapter=new SqlDataAdapter(cmd))
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
            } catch { }
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                PrestamoMensajero prestamo = new PrestamoMensajero();
                prestamo.Documento = trabajador.Documento;
                prestamo.Valor = Convert.ToDecimal(txtValor.Text);
                prestamo.Concepto = cbConcepto.Text;
                prestamo.Autoriza = txtAutoriza.Text;
                prestamo.Observacion = txtObservaciones.Text;
                PrestamoMensajerosRepository repository = new PrestamoMensajerosRepository();
                if (repository.InsertarPrestamo(prestamo))
                {
                    MessageBox.Show("Prestamo realizado con exito");
                    traerDeudas();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error al realizar el prestamo");
                }
            }
            catch { }
        }
    }
}
