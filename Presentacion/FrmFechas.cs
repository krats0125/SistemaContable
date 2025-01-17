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
    public partial class FrmFechas : Form
    {
        string fechaInicio;
        string fechaFin;
        public FrmFechas()
        {
            InitializeComponent();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            fechaInicio = dpFechaInicio.Value.ToString("yyyy-MM-dd");
            fechaFin = dpFechaFin.Value.ToString("yyyy-MM-dd");

            if(fechaInicio!=null && fechaFin!=null)
            {
                FrmPrestamosMesMensajeros prestamosForm = new FrmPrestamosMesMensajeros(fechaInicio, fechaFin);
                prestamosForm.Show();
            }
          
        }
    }
}
