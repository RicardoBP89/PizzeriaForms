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
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection command = null;
            SqlCommand cmd = null;
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Rellene los campos de registro");
                return;
            }
            try
            {
                command = new SqlConnection("server=(local)\\SQLEXPRESS01;database=pizzeria;Integrated Security=SSPI");
                cmd = new SqlCommand("Select nombre, pass from usuario where nombre=@nombre and pass=@pass", command);
                cmd.Parameters.AddWithValue("@nombre", textBox1.Text);
                cmd.Parameters.AddWithValue("@pass", textBox2.Text);
                command.Open();
                //int rownumber = cmd.executescalar();
                SqlDataAdapter adapt = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapt.Fill(ds);
                command.Close();
                int count = ds.Tables[0].Rows.Count;
                if (count == 1)
                {
                    MessageBox.Show("Login correcto.");
                    this.Hide();
                    Main fm = new Main();
                    fm.Show();
                }
                else
                {
                    MessageBox.Show("Login fallido.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                cmd.Dispose();
                command.Close();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            register ss = new register();
            ss.Show();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                textBox2.Focus();
            }
        }
    }
}
