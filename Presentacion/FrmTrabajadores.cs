using SistemaContable.Modelos;
using SistemaContable.Repositorios.Utilitarios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaContable.Presentacion
{
    public partial class FrmTrabajadores : Form
    {
        CONEXION conexion= new CONEXION();
        DataTable datos;
        PagoMensajeros pago = new PagoMensajeros();
        Trabajador trabajador = new Trabajador();
        public FrmTrabajadores()
        {
            InitializeComponent();
        }

        private void FrmTrabajadores_Load(object sender, EventArgs e)
        {
            TraerMensajeros();
            TraerPagosDiaMensajeros();
            TraerPrestamosMensajerosDia();
        }

        #region Mensajeros
        private void TraerMensajeros()
        {
            try
            {
                string consulta = "select IdTrabajador 'Documento',nombre 'Nombre' from MENSAJEROS where estado=1";
                DataTable dt = new SentenciasSqlServer().TraerDatos(consulta,conexion.conexionLaBodegaDeNacho());
                dgvMensajeros.DataSource = dt;
                datos=dt.Copy();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void TraerPagosDiaMensajeros()
        {
            try
            {
                string consulta = @"select pm.Fecha,m.nombre as Nombre,pm.Fichos,pm.Valor,pm.Adelanto,pm.TotalPago
                                  from tbl_PagoMensajeros pm inner join MENSAJEROS m on pm.Id_Mensajero=m.IdTrabajador
                                  where Fecha=GETDATE()";
                DataTable dt = new SentenciasSqlServer().TraerDatos(consulta, conexion.conexionLaBodegaDeNacho());
                dgvPagosDiaMensajeros.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TraerPrestamosMensajerosDia()
        {
            try
            {
                string consulta = @"select pm.Fecha,m.nombre,pm.Valor,pm.Concepto,pm.Caja,pm.Cajero 
                                  from MENSAJEROS m inner join PRESTAMOS_MENSAJEROS pm on m.IdTrabajador=pm.IdTrabajador
                                  where Fecha=GETDATE()";
                DataTable dt = new SentenciasSqlServer().TraerDatos(consulta, conexion.conexionLaBodegaDeNacho());
                dgvPrestamosDiaMensajeros.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            string filtro = txtBuscar.Text.ToLower();
            if (filtro.Length > 0)
            {
                DataTable dt = datos.Copy();
                dt.DefaultView.RowFilter = $"Nombre like '%{filtro}%' or Documento like '%{filtro}%'";
                dgvMensajeros.DataSource = dt;
            }
            else
            {
                dgvMensajeros.DataSource = datos;
            }
        }
        private void btnPrestarMensajero_Click(object sender, EventArgs e)
        {
            if (dgvMensajeros.SelectedRows.Count > 0)
            {
                trabajador.Documento = dgvMensajeros.SelectedRows[0].Cells["Documento"].Value.ToString();
                trabajador.Nombre = dgvMensajeros.SelectedRows[0].Cells["Nombre"].Value.ToString();
                FrmPrestamos frm = new FrmPrestamos(trabajador);
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Seleccione un mensajero", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnPagarMensajero_Click(object sender, EventArgs e)
        {
            if (dgvMensajeros.SelectedRows.Count > 0)
            {
                trabajador.Documento = dgvMensajeros.SelectedRows[0].Cells["Documento"].Value.ToString();
                trabajador.Nombre = dgvMensajeros.SelectedRows[0].Cells["Nombre"].Value.ToString();
                FrmPagoMensajeros frm = new FrmPagoMensajeros(trabajador);
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Seleccione un mensajero", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
 
        }
        #endregion

        #region Trabajadores

        private void TraerTrabajadores()
        {
            try
            {
                string consulta = "select IdTrabajador 'Documento',nombre 'Nombre' from TRABAJADORES where estado=1";
                DataTable dt = new SentenciasSqlServer().TraerDatos(consulta, conexion.conexionLaBodegaDeNacho());
                dgvTrabajadores.DataSource = dt;
                datos = dt.Copy();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TraerPagosDiaTrabajadores()
        {
            try
            {
                string consulta = @"select pm.FechaRealizacion,m.nombre as Nombre,pm.Pago,pm.Adelanto,pm.Total_Pago,pm.Concepto,pm.MedioPago
                                  from tbl_Pagos pm inner join TRABAJADORES m on pm.Idtrabajador=m.IdTrabajador";
                DataTable dt = new SentenciasSqlServer().TraerDatos(consulta, conexion.conexionLaBodegaDeNacho());
                dgvPagosDiaTrabajador.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TraerPrestamosTrabajadoresDia()
        {
            try
            {
                string consulta = @"select p.Fecha,t.nombre as Nombre,t.cargo as Cargo,p.Valor,p.Concepto,p.Caja,p.Cajero from TRABAJADORES t inner join PRESTAMOS p on t.IdTrabajador=p.IdTrabajador
                                  where Fecha=GETDATE()";
                DataTable dt = new SentenciasSqlServer().TraerDatos(consulta, conexion.conexionLaBodegaDeNacho());
                dgvPrestamosDiaTrabajador.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        private void TabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(TabControl.SelectedIndex==0)
            {
                if (dgvMensajeros.DataSource == null)
                {
                    TraerMensajeros();
                    TraerPagosDiaMensajeros();
                    TraerPrestamosMensajerosDia();
                }
            }
            else if(TabControl.SelectedIndex==1)
            {
                if (dgvTrabajadores.DataSource == null)
                {
                    TraerTrabajadores();
                    //TraerPagosDiaTrabajadores();
                    TraerPrestamosTrabajadoresDia();
                }
            }
        }

        private void btnPrestamosmesMensajero_Click(object sender, EventArgs e)
        {
            FrmFechas frm = new FrmFechas();
            frm.Show();
        }
    }
}
