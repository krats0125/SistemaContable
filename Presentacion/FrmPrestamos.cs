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
        bool esMensajero = false;
        public FrmPrestamos(Trabajador trabajador,bool esMensajero)
        {
            InitializeComponent();
            this.trabajador = trabajador;
            lbNombre.Text = trabajador.Nombre;
            lbDocumento.Text = trabajador.Documento;
            this.esMensajero = esMensajero;
        }
        private void FrmPrestamos_Load(object sender, EventArgs e)
        {
            traerDeudasMensajeros();
            traerDeudasTrabajadores();
        }

        private void traerDeudasMensajeros()
        {
            if (esMensajero)
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
                catch { }
            }
        }
        private void traerDeudasTrabajadores()
        {
            if (esMensajero==false)
            {
                try
                {
                    string consulta = @"select p.iDPrestamo,p.Fecha, p.Valor, p.Concepto, p.Caja, p.Cajero  
                            from TRABAJADORES t 
                            inner join PRESTAMOS p on t.IdTrabajador = p.IdTrabajador
                            where (t.nombre = @nombre or t.IdTrabajador = @documento) 
                            and p.Pagado = 0";
                    using (SqlConnection cn = new SqlConnection(conexion.conexionLaBodegaDeNacho()))
                    {

                        using (SqlCommand cmd = new SqlCommand(consulta, cn))
                        {
                            cmd.Parameters.AddWithValue("@nombre", string.IsNullOrEmpty(trabajador.Nombre) ? DBNull.Value : (object)trabajador.Nombre);
                            cmd.Parameters.AddWithValue("@documento", string.IsNullOrEmpty(trabajador.Documento) ? DBNull.Value : (object)trabajador.Documento);
                            cn.Open();
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
                catch { }
            }
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (esMensajero)
            {
                GuardarPrestamosMensajero();
            }
            else
            {
                GuardarPrestamosTrabajadores();
            }

        }

        private void GuardarPrestamosMensajero()
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
                    traerDeudasMensajeros();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error al realizar el prestamo");
                }
            }
            catch { }

        }
        private void GuardarPrestamosTrabajadores()
        {
            try
            {
                PrestamoTrabajadores prestamo = new PrestamoTrabajadores();
                prestamo.Documento = trabajador.Documento;
                prestamo.Valor = Convert.ToDecimal(txtValor.Text);
                prestamo.Concepto = cbConcepto.Text;
                prestamo.Autoriza = txtAutoriza.Text;
                prestamo.Observacion = txtObservaciones.Text;
                PrestamoTrabajadoresRepository repository = new PrestamoTrabajadoresRepository();
                if (repository.InsertarPrestamo(prestamo))
                {
                    MessageBox.Show("Prestamo realizado con exito");
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
