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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text=="" || textBox2.Text=="")
            {
                MessageBox.Show("Rellene los campos de registro");
                return;
            }
            try
            {
                SqlConnection command = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=pizzeria;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                SqlCommand cmd = new SqlCommand("Select Nombre, Pass from users where Nombre=@nombre and Pass=@pass", command);
                cmd.Parameters.AddWithValue("@nombre", textBox1.Text);
                cmd.Parameters.AddWithValue("@pass", textBox2.Text);
                command.Open();
                SqlDataAdapter adapt = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapt.Fill(ds);
                command.Close();
                int count = ds.Tables[0].Rows.Count;
                if (count == 1)
                {
                    MessageBox.Show("Login correcto.");
                    this.Hide();
                    Form2 fm = new Form2();
                    fm.Show();
                }
                else
                {
                    MessageBox.Show("Login fallido.");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            /*SqlDataAdapter sda = new SqlDataAdapter("Select Count(*) From users where Nombre='" + textBox1.Text + "' and Pass='" + textBox2.Text + "'",command);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                this.Hide();

                Form2 ss = new Form2();
                ss.Show();

            } else
            {
                MessageBox.Show("Please check your name or password are correct");
            }*/
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form3 ss = new Form3();
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
