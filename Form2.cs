using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pizzeria
{

    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.panel5.Controls.Count > 0)
                this.panel5.Controls.RemoveAt(0);
            NuestrasPizzas form = Application.OpenForms.OfType<NuestrasPizzas>().FirstOrDefault();
            NuestrasPizzas hijo1 = form ?? new NuestrasPizzas();
            hijo1.TopLevel = false;
            hijo1.FormBorderStyle = FormBorderStyle.None;
            hijo1.Dock = DockStyle.Fill;
            this.panel5.Controls.Add(hijo1);
            this.panel5.Tag = hijo1;
            hijo1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.panel5.Controls.Count > 0)
                this.panel5.Controls.RemoveAt(0);
            Addpizza form = Application.OpenForms.OfType<Addpizza>().FirstOrDefault();
            Addpizza hijo1 = form ?? new Addpizza();
            hijo1.TopLevel = false;
            hijo1.FormBorderStyle = FormBorderStyle.None;
            hijo1.Dock = DockStyle.Fill;
            this.panel5.Controls.Add(hijo1);
            this.panel5.Tag = hijo1;
            hijo1.Show();
        }
    }
}
