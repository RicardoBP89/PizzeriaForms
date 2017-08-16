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
    public partial class NuestrasPizzas : Form
    {
        public NuestrasPizzas()
        {
            InitializeComponent();
        }


        public void pictureBox5_Click(object sender, EventArgs e)
        {
            if (this.panel5.Controls.Count > 0)
                this.panel5.Controls.RemoveAt(0);
            Nuestraspizzas1 form = Application.OpenForms.OfType<Nuestraspizzas1>().FirstOrDefault();
            Nuestraspizzas1 hijo1 = form ?? new Nuestraspizzas1();
            hijo1.TopLevel = false;
            hijo1.FormBorderStyle = FormBorderStyle.None;
            hijo1.Dock = DockStyle.Fill;
            this.panel5.Controls.Add(hijo1);
            this.panel5.Tag = hijo1;
            hijo1.Show();
        }
    }
}
