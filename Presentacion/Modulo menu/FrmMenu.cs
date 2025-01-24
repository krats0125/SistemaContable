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
    public partial class FrmMenu : Form
    {
        public FrmMenu()
        {
            InitializeComponent();
        }

        private void BtnMenu_Click(object sender, EventArgs e)
        {
            menu();
        }
        private void menu()
        {
            if(this.PanelMenu.Width>180)
            {
                PanelMenu.Width = 60;
                pbLogo.Visible = false;
                BtnMenu.Location = new Point(15,5);
                panelCentral.Width = 1005;
            }
            else
            {
                PanelMenu.Width = 200;
                pbLogo.Visible = true;
                BtnMenu.Location = new Point(150, 5);
            }
        }
        private Dictionary<Type, Form> InstanciaDelFormulario = new Dictionary<Type, Form>();
        private void AbrirFormularioEnPanel<T>(FrmMenu menu) where T : Form
        {
            Type formType = typeof(T);

            // Verificar si ya existe una instancia del formulario
            if (InstanciaDelFormulario.ContainsKey(formType))
            {
                Form ExisteFormulario = InstanciaDelFormulario[formType];
                if (!ExisteFormulario.IsDisposed)
                {
                    ExisteFormulario.BringToFront(); // Traer el formulario al frente si está oculto detrás de otros controles
                    return;
                }
                // Si el formulario está desechado, eliminar la instancia
                InstanciaDelFormulario.Remove(formType);
            }

            // Crear una nueva instancia del formulario con el formulario Principal como parámetro
            Form FormularioHijo = (Form)Activator.CreateInstance(typeof(T), menu); // Usar Activator para pasar parámetros
            FormularioHijo.TopLevel = false;
            FormularioHijo.FormBorderStyle = FormBorderStyle.None;
            FormularioHijo.Dock = DockStyle.Fill;

            // Agregar el formulario al panel
            panelCentral.Controls.Add(FormularioHijo);
            FormularioHijo.Show();

            // Almacenar la instancia del formulario en el diccionario
            InstanciaDelFormulario.Add(formType, FormularioHijo);
        }

        private void btnTrabajadores_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel<FrmTrabajadores>(this);
        }

        private void FrmMenu_Load(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel<FrmPagoProveedores>(this);
            AbrirFormularioEnPanel<FrmTrabajadores>(this);
        }

        private void btnPagoProveedores_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel<FrmPagoProveedores>(this);
        }
    }
}
