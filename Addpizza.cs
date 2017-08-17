using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Pizzeria
{
    public partial class Addpizza : Form
    {
        public Addpizza()
        {
            InitializeComponent();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
            } 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection connection = null;
            SqlCommand cmd = null;
            try
            {
                connection = new SqlConnection("server=(local)\\SQLEXPRESS01;database=pizzeria;Integrated Security=SSPI");
                cmd.CommandText = "INSERT INTO pizza (nombre,imagen) VALUES (@nombre,@imagen)";

                cmd.Parameters.Add("@nombre", System.Data.SqlDbType.NVarChar);
                cmd.Parameters.Add("@imagen", System.Data.SqlDbType.Image);

                cmd.Parameters["@nombre"].Value = textBox1.Text;

                // Stream usado como buffer
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                // Se guarda la imagen en el buffer
                pictureBox1.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                // Se extraen los bytes del buffer para asignarlos como valor para el 
                // parámetro.
                cmd.Parameters["@imagen"].Value = ms.GetBuffer();

                connection.Open();
                cmd.ExecuteNonQuery();
            }
            catch(System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                cmd.Dispose();
                connection.Close();
            }
        }

        private void Addpizza_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'pizzeriaDataSet.ingrediente' Puede moverla o quitarla según sea necesario.
            this.ingredienteTableAdapter.Fill(this.pizzeriaDataSet.ingrediente);

        }
    }
}
