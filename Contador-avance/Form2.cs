using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Contador_avance
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text) ||
               string.IsNullOrEmpty(textBox3.Text) || string.IsNullOrEmpty(textBox4.Text) || string.IsNullOrEmpty(comboBox1.Text) ||
               string.IsNullOrEmpty(comboBox3.Text)|| string.IsNullOrEmpty(comboBox2.Text))
            {
                MessageBox.Show("Debe completar la informacion");
                return;
            }
            Conexion.Conectar();
            string insertar = "insert into prospectos(nombreInteresado,nombreProspecto,apellidosProspecto,telefono,medioCon,medioDif,fecha,hora,asunto) " +
                "values (@nombreInteresado,@nombreProspecto,@apellidosProspecto,@telefono,@medioCon,@medioDif,convert(date,@fecha),@hora,@asunto)";
            SqlCommand cmd1 = new SqlCommand(insertar, Conexion.Conectar());
            cmd1.Parameters.AddWithValue("@nombreInteresado", textBox1.Text.Trim());
            cmd1.Parameters.AddWithValue("@nombreProspecto", textBox2.Text.Trim());
            cmd1.Parameters.AddWithValue("@apellidosProspecto", textBox5.Text.Trim());
            cmd1.Parameters.AddWithValue("@asunto", textBox3.Text.Trim());
            cmd1.Parameters.AddWithValue("@telefono", textBox4.Text.Trim());
            cmd1.Parameters.AddWithValue("@medioCon", comboBox1.Text.Trim());
            cmd1.Parameters.AddWithValue("@medioDif", comboBox2.Text.Trim());
            cmd1.Parameters.AddWithValue("@fecha", dateTimePicker1.Value.ToShortDateString());
            cmd1.Parameters.AddWithValue("@hora", comboBox3.Text.Trim());
            cmd1.ExecuteScalar();
            string message = "El prospecto fue guardado con exito ";
            string caption = "Archivo guardado con exito";
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            DialogResult result;

            // Displays the MessageBox.
            result = MessageBox.Show(message, caption, buttons);
            textBox2.Text = "";
            textBox1.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Initializes the variables to pass to the MessageBox.Show method.
            string message = "Esta seguro de cerrar sesion?";
            string caption = "Cerrar sesión";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            // Displays the MessageBox.
            result = MessageBox.Show(message, caption, buttons);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                // Closes the parent form.
                Form1 F1 = new Form1();
                F1.Show();
                this.Close();
            }
        }
    }
}



