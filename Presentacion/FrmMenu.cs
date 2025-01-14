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
    }
}
