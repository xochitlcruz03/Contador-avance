using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Net;

namespace Contador_avance
{
    public partial class Form3 : Form
    {
        
        double Total;
        public Form3()
        {
            InitializeComponent();
           
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'sysContableDataSet9.concentrado' Puede moverla o quitarla según sea necesario.
            this.concentradoTableAdapter.Fill(this.sysContableDataSet9.concentrado);
            // TODO: esta línea de código carga datos en la tabla 'sysContableDataSet7.seleccionar_contrato' Puede moverla o quitarla según sea necesario.
            this.seleccionar_contratoTableAdapter1.Fill(this.sysContableDataSet7.seleccionar_contrato);
            // TODO: esta línea de código carga datos en la tabla 'sysContableDataSet6.seleccionar_proceso' Puede moverla o quitarla según sea necesario.
            this.seleccionar_procesoTableAdapter.Fill(this.sysContableDataSet6.seleccionar_proceso);
            // TODO: esta línea de código carga datos en la tabla 'sysContableDataSet5.seleccionar_consulta' Puede moverla o quitarla según sea necesario.
            this.seleccionar_consultaTableAdapter1.Fill(this.sysContableDataSet5.seleccionar_consulta);
            // TODO: esta línea de código carga datos en la tabla 'sysContableDataSet4.seleccionar_contrato' Puede moverla o quitarla según sea necesario.
            this.seleccionar_contratoTableAdapter.Fill(this.sysContableDataSet4.seleccionar_contrato);
            // TODO: esta línea de código carga datos en la tabla 'sysContableDataSet3.seleccionar_consulta' Puede moverla o quitarla según sea necesario.
            this.seleccionar_consultaTableAdapter.Fill(this.sysContableDataSet3.seleccionar_consulta);
            // TODO: esta línea de código carga datos en la tabla 'sysContableDataSet1.prospectos' Puede moverla o quitarla según sea necesario.
            this.prospectosTableAdapter1.Fill(this.sysContableDataSet1.prospectos);
            
        }
       
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
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

        private void button3_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
            groupBox2.Visible = true;
            string id = comboBox1.Text;
            char delimitador = '-';
            string[] valores = id.Split(delimitador);
            textBox2.Text = valores[0];

        }

        private void button1_Click(object sender, EventArgs e)
        {
            double t = Double.Parse(textBox1.Text)/100;
            double r = Double.Parse(textBox4.Text);
          
            Total = t * r;
            label10.Text = ""+Total;
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text)|| string.IsNullOrEmpty(textBox2.Text)|| 
                string.IsNullOrEmpty(textBox3.Text)|| string.IsNullOrEmpty(textBox4.Text)|| string.IsNullOrEmpty(textBox5.Text)||
                string.IsNullOrEmpty(comboBox3.Text))
            {
                MessageBox.Show("Debe completar la informacion");
                return;
            }
                Conexion.Conectar();
                string insertar = "INSERT INTO consultas(folioProspecto,semanasCotizadas,afore ,descripcionCaso,estado,validacion,totalCobro) " +
                    "VALUES(@folioProspecto,@semanasCotizadas,@afore,@descripcionCaso,@estado, @validacion, @totalCobro)";
                SqlCommand cmd1 = new SqlCommand(insertar, Conexion.Conectar());
                cmd1.Parameters.AddWithValue("@folioProspecto", textBox2.Text.Trim());
                cmd1.Parameters.AddWithValue("@semanasCotizadas", textBox3.Text.Trim());
                cmd1.Parameters.AddWithValue("@afore", textBox4.Text.Trim());
                cmd1.Parameters.AddWithValue("@descripcionCaso", textBox5.Text.Trim());
                cmd1.Parameters.AddWithValue("@validacion", "true");
                cmd1.Parameters.AddWithValue("@estado", comboBox3.Text.Trim());
                cmd1.Parameters.AddWithValue("@totalCobro", label10.Text.Trim());
                cmd1.ExecuteScalar();
            string message = "La consulta fue guardada con exito ";
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
            label10.Text = "";
            comboBox3.Text = "";
            groupBox3.Visible = false;
            button5.Visible = false;
            // TODO: esta línea de código carga datos en la tabla 'sysContableDataSet4.seleccionar_contrato' Puede moverla o quitarla según sea necesario.
            this.seleccionar_contratoTableAdapter.Fill(this.sysContableDataSet4.seleccionar_contrato);
            // TODO: esta línea de código carga datos en la tabla 'sysContableDataSet3.seleccionar_consulta' Puede moverla o quitarla según sea necesario.
            this.seleccionar_consultaTableAdapter.Fill(this.sysContableDataSet3.seleccionar_consulta);
            // TODO: esta línea de código carga datos en la tabla 'sysContableDataSet7.seleccionar_contrato' Puede moverla o quitarla según sea necesario.
            this.seleccionar_contratoTableAdapter1.Fill(this.sysContableDataSet7.seleccionar_contrato);
            // TODO: esta línea de código carga datos en la tabla 'sysContableDataSet6.seleccionar_proceso' Puede moverla o quitarla según sea necesario.
            this.seleccionar_procesoTableAdapter.Fill(this.sysContableDataSet6.seleccionar_proceso);
            // TODO: esta línea de código carga datos en la tabla 'sysContableDataSet9.concentrado' Puede moverla o quitarla según sea necesario.
            this.concentradoTableAdapter.Fill(this.sysContableDataSet9.concentrado);


        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            groupBox3.Visible = true;
            button5.Visible = true;
            string id = comboBox2.Text;
            char delimitador = '-';
            string[] valores = id.Split(delimitador);
            textBox7.Text = valores[0];


        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (checkBox4.Checked)
                {
                button6.Visible = true;
                button5.Visible = false;
                Conexion.Conectar();
                string contrato = "insert into contrato (folioProspecto,estado) values(@folio,@estado)";
                SqlCommand cmd2 = new SqlCommand(contrato, Conexion.Conectar());
                cmd2.Parameters.AddWithValue("@estado", "true");
                cmd2.Parameters.AddWithValue("@folio", textBox7.Text.Trim());
                cmd2.ExecuteScalar();
                // TODO: esta línea de código carga datos en la tabla 'sysContableDataSet4.seleccionar_contrato' Puede moverla o quitarla según sea necesario.
                this.seleccionar_contratoTableAdapter.Fill(this.sysContableDataSet4.seleccionar_contrato);
                // TODO: esta línea de código carga datos en la tabla 'sysContableDataSet3.seleccionar_consulta' Puede moverla o quitarla según sea necesario.
                this.seleccionar_consultaTableAdapter.Fill(this.sysContableDataSet3.seleccionar_consulta);
                // TODO: esta línea de código carga datos en la tabla 'sysContableDataSet7.seleccionar_contrato' Puede moverla o quitarla según sea necesario.
                this.seleccionar_contratoTableAdapter1.Fill(this.sysContableDataSet7.seleccionar_contrato);
                // TODO: esta línea de código carga datos en la tabla 'sysContableDataSet6.seleccionar_proceso' Puede moverla o quitarla según sea necesario.
                this.seleccionar_procesoTableAdapter.Fill(this.sysContableDataSet6.seleccionar_proceso);
                // TODO: esta línea de código carga datos en la tabla 'sysContableDataSet9.concentrado' Puede moverla o quitarla según sea necesario.
                this.concentradoTableAdapter.Fill(this.sysContableDataSet9.concentrado);
            }
            else{
                // Initializes the variables to pass to the MessageBox.Show method.
                string message = "El cliente debe hacer los terminos";
                string caption = "ERROR";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;

                // Displays the MessageBox.
                result = MessageBox.Show(message, caption, buttons);
                
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string remoteUri = "https://drive.google.com/uc?id=10mzxPBf1_b4QGwOpytVnXjGnypV7JcQD&export=download";
            string fileName = "contrato.pdf", myStringWebResource = null;
            using (var fd = new FolderBrowserDialog())
            {
                if (fd.ShowDialog() == System.Windows.Forms.DialogResult.OK && !string.IsNullOrWhiteSpace(fd.SelectedPath))
                {
                   
                    fileName = fd.SelectedPath + "\\contrato.pdf";
                }
            }

            // Create a new WebClient instance.
            WebClient myWebClient = new WebClient();
            // Concatenate the domain with the Web resource filename.
            myStringWebResource = remoteUri+"contrato.pdf";
            // Download the Web resource and save it into the current filesystem folder.
            myWebClient.DownloadFile(myStringWebResource,fileName);
           // Initializes the variables to pass to the MessageBox.Show method.
            string message = "El contrato fue guardado con exito en la siguiente ruta: \n"+ fileName;
            string caption = "Archivo guardado con exito";
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            // Displays the MessageBox.
            DialogResult result1;
            result1 = MessageBox.Show(message, caption, buttons);
        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void fillToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.seleccionar_consultaTableAdapter.Fill(this.sysContableDataSet3.seleccionar_consulta);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void button8_Click(object sender, EventArgs e)
        {
            groupBox4.Visible = true;
            button9.Visible = true;
            string id = comboBox4.Text;
            char delimitador = '-';
            string[] valores = id.Split(delimitador);
            textBox7.Text = valores[0];
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string estado = null;
            if (radioButton1.Checked)
            {
                estado = "Pension";

                if (radioButton1.Checked)
                {
                    estado = "Fiscal";

                    if (radioButton1.Checked)
                    {
                        estado = "Juridico";
                    }
                }
            }
            else
            {
                // Initializes the variables to pass to the MessageBox.Show method.
                string message1 = "Debe seleccionar algun termino";
                string caption1 = "ERROR";
                MessageBoxButtons buttons1 = MessageBoxButtons.OK;
                DialogResult result1;

                // Displays the MessageBox.
                result1 = MessageBox.Show(message1, caption1, buttons1);

            }
            Conexion.Conectar();
            string contrato = "insert into tipo_proceso (folioProspecto,estado,texto) values(@folio,@estado,@texto)";
            SqlCommand cmd2 = new SqlCommand(contrato, Conexion.Conectar());
            cmd2.Parameters.AddWithValue("@estado", "true");
            cmd2.Parameters.AddWithValue("@folio", textBox7.Text.Trim());
            cmd2.Parameters.AddWithValue("@texto", estado);
            cmd2.ExecuteScalar();
            // TODO: esta línea de código carga datos en la tabla 'sysContableDataSet4.seleccionar_contrato' Puede moverla o quitarla según sea necesario.
            this.seleccionar_contratoTableAdapter.Fill(this.sysContableDataSet4.seleccionar_contrato);
            // TODO: esta línea de código carga datos en la tabla 'sysContableDataSet3.seleccionar_consulta' Puede moverla o quitarla según sea necesario.
            this.seleccionar_consultaTableAdapter.Fill(this.sysContableDataSet3.seleccionar_consulta);
            // TODO: esta línea de código carga datos en la tabla 'sysContableDataSet7.seleccionar_contrato' Puede moverla o quitarla según sea necesario.
            this.seleccionar_contratoTableAdapter1.Fill(this.sysContableDataSet7.seleccionar_contrato);
            // TODO: esta línea de código carga datos en la tabla 'sysContableDataSet6.seleccionar_proceso' Puede moverla o quitarla según sea necesario.
            this.seleccionar_procesoTableAdapter.Fill(this.sysContableDataSet6.seleccionar_proceso);
            // TODO: esta línea de código carga datos en la tabla 'sysContableDataSet9.concentrado' Puede moverla o quitarla según sea necesario.
            this.concentradoTableAdapter.Fill(this.sysContableDataSet9.concentrado);
            string message = "La seleccion fue guardada con exito ";
            string caption = "Informacion guardada con exito";
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            DialogResult result;
            // Displays the MessageBox.
            result = MessageBox.Show(message, caption, buttons);
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            groupBox4.Visible = false;
            button9.Visible = false;
        }
    }
}
