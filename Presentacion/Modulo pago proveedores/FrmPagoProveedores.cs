using SistemaContable.Modelos;
using SistemaContable.Presentacion.Modulo_pago_proveedores;
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
    public partial class FrmPagoProveedores : Form
    {
        CONEXION conexion =new CONEXION();
        DataTable datos;
        PagoProveedores pago=new PagoProveedores();
        public FrmPagoProveedores(FrmMenu menu)
        {
            InitializeComponent();
        }
        private void FrmPagoProveedores_Load(object sender, EventArgs e)
        {
            TraerProveedores();
        }

        private void TraerProveedores()
        {
            try
            {
                string consulta = @"select lngIDProveedor as Id,strNombre as Proveedores from tbl_Proveedor
                                  where strNombre is not null and strNombre!= ''
                                  order by strNombre";
                DataTable dt =new SentenciasSqlServer().TraerDatos(consulta, conexion.conexionLaBodegaDeNacho());
                dgvProveedores.DataSource = dt;
                datos = dt.Copy();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al traer los proveedores: " + ex.Message);
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            string filtro = txtBuscar.Text.ToLower();
            if (filtro.Length > 0)
            {
                DataTable dt = datos.Copy();
                dt.DefaultView.RowFilter = $"Proveedores like '%{filtro}%'";
                dgvProveedores.DataSource = dt;
            }
            else
            {
                dgvProveedores.DataSource = datos;
            }
        }

        private void dgvProveedores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvProveedores.SelectedRows.Count > 0)
            {
                string proveedor = dgvProveedores.SelectedRows[0].Cells[1].Value.ToString();
                lbProveedores.Text = proveedor;
            }
        }

        private void HabilitarCampos()
        {
            string mediopago = cbMedioPago.SelectedItem.ToString();
            if(mediopago == "Efectivo")
            {
                cbBanco.Enabled = false;
                dtpFechaVencimiento.Enabled = false;
                dtpFechaVencimiento.Value = DateTime.Now;
            }
            if(mediopago == "Transacción PAC")
            {
                cbBanco.Enabled = false;
                dtpFechaVencimiento.Enabled = false;
                dtpFechaVencimiento.Value = DateTime.Now;
            }
            if(mediopago == "Consignación")
            {
                cbBanco.Enabled = true;
                dtpFechaVencimiento.Enabled = false;
                dtpFechaVencimiento.Value = DateTime.Now;
            }
            if (mediopago == "Bonos sodexo")
            {
                cbBanco.Enabled = false;
                dtpFechaVencimiento.Enabled = false;
                dtpFechaVencimiento.Value = DateTime.Now;
            }
        }
        private void calcularPago()
        {
            decimal descontar = 0;
            decimal descuentoCalculado = 0;
            if (string.IsNullOrEmpty(txtValorFactura.Text))
            {
                pago.valor = 0;
            }
            else 
            {
                pago.valor = Convert.ToDecimal(txtValorFactura.Text);
            }
            if (string.IsNullOrEmpty(txtDescuento.Text))
            {
                pago.Descuento = 0;
            }
            else
            {
                pago.Descuento = Convert.ToDecimal(txtDescuento.Text);
                descuentoCalculado = (pago.valor * (pago.Descuento / 100));
            }
            if (string.IsNullOrEmpty(txtDescontar.Text))
            {
                descontar = 0;
            }
            else
            {
                descontar = Convert.ToDecimal(txtDescontar.Text);
            }
            if (!string.IsNullOrEmpty(txtValorPagado.Text))
            {
                lbTotal.Text="$0";
                pago.valorPagado = Convert.ToDecimal(txtValorPagado.Text);
                lbTotal.Text=pago.valorPagado.ToString("C0");
            }
            else
            {
                    
                lbTotal.Text = (pago.valor -descuentoCalculado - descontar).ToString("C0");
            }
        }

        private void cbMedioPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            HabilitarCampos();
        }

        private void txtValorFactura_TextChanged(object sender, EventArgs e)
        {
            calcularPago();
        }

        private void txtValorPagado_TextChanged(object sender, EventArgs e)
        {
            calcularPago();
        }

        private void txtDescuento_TextChanged(object sender, EventArgs e)
        {
            calcularPago();
        }

        private void txtDescontar_TextChanged(object sender, EventArgs e)
        {
            calcularPago();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            

        }

        private void cbCredito_CheckedChanged(object sender, EventArgs e)
        {
            if(cbCredito.Checked)
            {
                txtBanco.Visible = false;
                txtMedioPago.Visible = false;
                cbBanco.Visible = false;
                cbMedioPago.Visible = false;
                txtValorPagado.Enabled = false;
                dtpFechaVencimiento.Enabled = true;
            }
            else
            {
                txtBanco.Visible = true;
                txtMedioPago.Visible = true;
                cbBanco.Visible = true;
                cbMedioPago.Visible = true;
                txtValorPagado.Enabled = true;
                dtpFechaVencimiento.Enabled = false;
            }

        }

        private void cbRetencion_CheckedChanged(object sender, EventArgs e)
        {
            if (cbRetencion.Checked)
            {
                FrmRetencion frmRetencion = new FrmRetencion();
                frmRetencion.Show();
            }
        }
    }
}
