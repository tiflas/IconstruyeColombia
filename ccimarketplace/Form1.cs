using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ccimarketplace
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            facturacion fac = new facturacion();
            fac.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Producto prod = new Producto();
            prod.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            /*Proveedores prove = new Proveedores();
            prove.Show();
            this.Hide();*/
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Materiales mate = new Materiales();
            mate.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            cotizaciones coti = new cotizaciones();
            coti.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            oc orden = new oc();
            orden.Show();
            this.Hide();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            CentrosdeCosto centcos = new CentrosdeCosto();
            centcos.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Proveedoresinte_nointe proveeinte = new Proveedoresinte_nointe();
            proveeinte.Show();
            this.Hide();
        }
    }
}
