using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Contador_avance
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            using (Conexion.Conectar())
            {

                SqlCommand inisesion = new SqlCommand("_iniciosesion", Conexion.Conectar());
                inisesion.CommandType = System.Data.CommandType.StoredProcedure;
                inisesion.Parameters.AddWithValue("@usuario", textBox1.Text.Trim());
                inisesion.Parameters.AddWithValue("@contrasenia", textBox2.Text.Trim());
                int count = Convert.ToInt32(inisesion.ExecuteScalar());
                if (count == 1)
                {
                    SqlCommand rol = new SqlCommand("obtenerRol", Conexion.Conectar());
                    rol.CommandType = System.Data.CommandType.StoredProcedure;
                    rol.Parameters.AddWithValue("@usuario", textBox1.Text.Trim());
                    rol.Parameters.AddWithValue("@contrasenia", textBox2.Text.Trim());
                    int count2 = Convert.ToInt32(rol.ExecuteScalar());
                    if (count2 == 1)
                    {
                        Form2 F2 = new Form2();
                        F2.Show();
                        Hide();
                    }
                    if (count2 == 2)
                    {
                        Form3 F3 = new Form3();
                        F3.Show();
                        Hide();
                    }
                   
                }
                else
                {
                    // Initializes the variables to pass to the MessageBox.Show method.
                    string message = "Contraseña y/o Usuario incorrecto";
                    string caption = "Error de Inicio de Sesion";
                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                    DialogResult result;

                    // Displays the MessageBox.
                    result = MessageBox.Show(message, caption, buttons);
                }
            }
            
            
        }


    }
}
