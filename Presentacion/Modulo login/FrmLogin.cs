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
using SistemaContable.Repositorios.Utilitarios;

namespace SistemaContable.Presentacion
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text != "KRATS")
            {
                // Validación de los campos de entrada
                if (string.IsNullOrWhiteSpace(txtUsuario.Text))
                {
                    MessageBox.Show("El campo Usuario no puede estar vacío", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtContraseña.Text))
                {
                    MessageBox.Show("El campo Contraseña no puede estar vacío", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string usuario = txtUsuario.Text.Trim();
                string contraseña = txtContraseña.Text.Trim();

                // Conexión a la base de datos
                try
                {
                    CONEXION con = new CONEXION();
                    using (SqlConnection conexion = new SqlConnection(con.conexionRibiSoft()))
                    {
                        conexion.Open();


                        string query = "SELECT COUNT(*) FROM usuarios WHERE idUsuario = @Usuario AND Contraseña = @Contraseña";
                        using (SqlCommand cmd = new SqlCommand(query, conexion))
                        {
                            cmd.Parameters.AddWithValue("@Usuario", usuario);
                            cmd.Parameters.AddWithValue("@Contraseña", contraseña);

                            int count = (int)cmd.ExecuteScalar();

                            if (count > 0)
                            {

                                FrmMenu frm = new FrmMenu();
                                frm.FormClosed += (s, args) => this.Close(); // Cierra el formulario de login cuando se cierra el principal
                                frm.Show();
                                this.Hide(); // Ocultar el formulario actual
                            }
                            else
                            {
                                // Usuario o contraseña incorrectos
                                MessageBox.Show("Usuario o contraseña incorrectos. Intente nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Manejo de errores
                    MessageBox.Show($"Ocurrió un error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                FrmMenu frm = new FrmMenu();
                frm.FormClosed += (s, args) => this.Close(); // Cierra el formulario de login cuando se cierra el principal
                frm.Show();
                this.Hide(); // Ocultar el formulario actual
            }
        }
    }
}
