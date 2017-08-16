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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 ss = new Form1();
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
            SqlConnection connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=pizzeria;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            connection.Open();

            try
            {
                SqlCommand sqlInsert = new SqlCommand("INSERT INTO users VALUES ('" + textBox1.Text + "','" + textBox3.Text + "','" + textBox2.Text + "'", connection);
                {

                    sqlInsert.Parameters.Add(new SqlParameter());
                    sqlInsert.Parameters.Add(new SqlParameter());
                    sqlInsert.Parameters.Add(new SqlParameter());


                }
                sqlInsert.ExecuteNonQuery();
                Console.WriteLine("Table Inserted");
            }
            catch (Exception x)
            {
                Console.WriteLine(x.Message);
            }
        }
    }
}
