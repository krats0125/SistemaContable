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
        bool esMensajero = false;
        public FrmFechas(bool esMensajero)
        {
            InitializeComponent();
            this.esMensajero = esMensajero;
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            fechaInicio = dpFechaInicio.Value.ToString("yyyy-MM-dd");
            fechaFin = dpFechaFin.Value.ToString("yyyy-MM-dd");

            if (!string.IsNullOrEmpty(fechaInicio) && !string.IsNullOrEmpty(fechaFin))
            {
                if (esMensajero)
                {
                    FrmPrestamosMesMensajeros prestamosForm = new FrmPrestamosMesMensajeros(fechaInicio, fechaFin);
                    prestamosForm.Show();
                }
                else
                {
                    FrmPrestamosMesTrabajadores prestamosForm = new FrmPrestamosMesTrabajadores(fechaInicio, fechaFin);
                    prestamosForm.Show();
                }
               
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un rango de fechas válido.");
            }
        }
    }
}
