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
    public partial class register : Form
    {
        public register()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            login ss = new login();
            ss.Show();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                textBox3.Focus();
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                textBox2.Focus();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection connection = null;
            SqlCommand cmd = null;
         try
            {
                connection = new SqlConnection("server=(local)\\SQLEXPRESS01;database=pizzeria;Integrated Security=SSPI");
                cmd = new SqlCommand("Insert into usuario (Id,nombre,pass,correo) values (@id,@nombre,@pass,@correo)", connection);
                cmd.Parameters.AddWithValue("@id", Guid.NewGuid());
                cmd.Parameters.AddWithValue("@nombre", textBox1.Text);
                cmd.Parameters.AddWithValue("@pass", textBox3.Text);
                cmd.Parameters.AddWithValue("@correo", textBox2.Text);
                connection.Open();
                SqlDataAdapter adapt = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapt.Fill(ds);
                MessageBox.Show("Se ha registrado con exito.");
                this.Hide();
            }
            catch (Exception x)
            {
                Console.WriteLine(x.Message);
            }
            finally
            {
                cmd.Dispose();
                connection.Close();
            }
        }
    }
}
