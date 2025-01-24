using SistemaContable.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaContable.Presentacion.Modulo_pago_proveedores
{
    public partial class FrmRetencion : Form
    {
        PagoProveedores pago=new PagoProveedores();
        public FrmRetencion(PagoProveedores pago)
        {
            InitializeComponent();
            this.pago = pago;
        }

        private void btnAplicar_Click(object sender, EventArgs e)
        {
            txtSubTotal
        }
    }
}
