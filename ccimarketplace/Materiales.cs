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
using System.Globalization;
using System.Threading;

namespace ccimarketplace
{
    public partial class Materiales : Form
    {
        SqlConnection conectar = ConexionBD.obtenerconexion();
        
        void ocultarlista()
        {
            listaempremateri.Hide();
            label1.Hide();
            tbconsultamateri.Hide();      
        }

        void ocultarlista2()
        {
            listaempremateri.Show();
            label3.Hide();
            tbconsultamateri.Show();
            btconsultatodas.Hide();
            label1.Show();
        }

        public void imagen_load()
        {
            Thread.Sleep(3000);
        }
        public Materiales()
        {
            InitializeComponent();
        }

        private void tbsalirmate_Click(object sender, EventArgs e)
        {
            Form1 inicio = new Form1();
            inicio.Show();
            this.Hide();
        }

        private void Materiales_Load(object sender, EventArgs e)
        {
            listaempremateri.DropDownStyle = ComboBoxStyle.DropDownList;
            imagencargar.Hide();
            label10.Hide();
            label11.Hide();
            label3.Hide();
            cubocargar.Hide();
            btconsultatodas.Hide();  
            {
                string query = "SELECT * from EMPRESAS where IDTIPOEMPRESA = 1 AND ELIMINADO = 0 and NOMBFANTASIA <> '' order by NOMBFANTASIA";

                SqlCommand cmd = new SqlCommand(query, conectar);
                SqlDataAdapter da1 = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da1.Fill(dt);
                listaempremateri.ValueMember = "IDEMPRESA";
                listaempremateri.DisplayMember = "NOMBEMPRESA";
                listaempremateri.DataSource = dt;               
            }
        }

        private async void tbconsultamateri_Click(object sender, EventArgs e)
        {
            Task oTask = new Task(imagen_load);
            listamateriales.DataSource = null;
            listamateriales.Refresh();
            if (listaempremateri.Text == "")
            {
                MessageBox.Show("Porfavor seleccione la empresa");
            }
            if (fechainicio.Text == "")
            {
                MessageBox.Show("Porfavor seleccione la fecha inicial");
            }
            else if (fechafinal.Text == "")
            {
                MessageBox.Show("Porfavor seleccione la fecha final");
            }
            else
            {
                label10.Hide();
                imagencargar.Visible = true;
                oTask.Start();
                await oTask;
                DateTime date1 = new DateTime(fechainicio.Value.Year, fechainicio.Value.Month, fechainicio.Value.Day);
                string dato2 = (date1.ToString("yyyyMMdd", CultureInfo.InvariantCulture));
                DateTime date3 = new DateTime(fechafinal.Value.Year, fechafinal.Value.Month, fechafinal.Value.Day);
                string dato4 = (date3.ToString("yyyyMMdd", CultureInfo.InvariantCulture));
                string idempre = listaempremateri.SelectedValue.ToString();
                SqlDataAdapter da = new SqlDataAdapter(String.Format("select ei.coditem CodigoItem, replace(replace(replace(ei.descripcion, char(9), ''), char(13),''), char(10), '') DescripcionItem, ei.iduom IdUnidadMedida,u.DESCRIPLARGA unidadMedida, ei.ACTIVO, ei.porcimpuesto, ei.fechacreacion, ei.fechaactualizacion,replace(replace(replace(mc.descripcion, char(9),''), char(13),''), char(10), '') DescripcionClasificacion,replace(replace(replace(mc.ruta, char(9), ''), char(13),''), char(10), '') RutaItem from empitem ei inner join MSTRITEM mi on ei.IDMSTRITEM = mi.IDMSTRITEM inner join uom u on ei.iduom = u.iduom inner join MSTRCLASIFICACION mc on mc.IDNODO = mi.IDNODO where idempresa = " + idempre + " and convert(varchar(8), ei.FECHAACTUALIZACION, 112) between '" + dato2 + "' and '" + dato4 + "'"), conectar);
                DataTable data = new DataTable();
                da.Fill(data);
                listamateriales.DataSource = data;
                label10.Text = "Total Registros " + data.Rows.Count.ToString();
                label10.Show();
                imagencargar.Visible = false;
            }           
        }

        private async void tbexportalexcelmateri_Click(object sender, EventArgs e)
        {
            Task oTask = new Task(imagen_load);
            label11.Show();
            cubocargar.Visible = true;
            oTask.Start();
            await oTask;
            new exportar().exportaraexcel(listamateriales);
            cubocargar.Visible = false;
            label11.Hide();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            ocultarlista();
            label3.Show();
            btconsultatodas.Show();
        }

        private async void btconsultatodas_Click(object sender, EventArgs e)
        {
            Task oTask = new Task(imagen_load);
            listamateriales.DataSource = null;
            listamateriales.Refresh();           
            if (fechainicio.Text == "")
            {
                MessageBox.Show("Porfavor seleccione la fecha inicial");
            }
            else if (fechafinal.Text == "")
            {
                MessageBox.Show("Porfavor seleccione la fecha final");
            }
            else
            {
                label10.Hide();
                imagencargar.Visible = true;
                oTask.Start();
                await oTask;
                DateTime date1 = new DateTime(fechainicio.Value.Year, fechainicio.Value.Month, fechainicio.Value.Day);
                string dato2 = (date1.ToString("yyyyMMdd", CultureInfo.InvariantCulture));
                DateTime date3 = new DateTime(fechafinal.Value.Year, fechafinal.Value.Month, fechafinal.Value.Day);
                string dato4 = (date3.ToString("yyyyMMdd", CultureInfo.InvariantCulture));
                //string fechainicial = fechainicio.Value.Year + "" + fechainicio.Value.Month + "" + fechainicio.Value.Day;
                SqlDataAdapter da = new SqlDataAdapter(String.Format("select ei.coditem CodigoItem, replace(replace(replace(ei.descripcion, char(9), ''), char(13),''), char(10), '') DescripcionItem, ei.iduom IdUnidadMedida,u.DESCRIPLARGA unidadMedida, ei.ACTIVO, ei.porcimpuesto, ei.fechacreacion, ei.fechaactualizacion,replace(replace(replace(mc.descripcion, char(9),''), char(13),''), char(10), '') DescripcionClasificacion,replace(replace(replace(mc.ruta, char(9), ''), char(13),''), char(10), '') RutaItem from empitem ei inner join MSTRITEM mi on ei.IDMSTRITEM = mi.IDMSTRITEM inner join uom u on ei.iduom = u.iduom inner join MSTRCLASIFICACION mc on mc.IDNODO = mi.IDNODO where convert(varchar(8), ei.FECHAACTUALIZACION, 112) between '" + dato2 + "' and '" + dato4 + "'"), conectar);
                DataTable data = new DataTable();
                da.Fill(data);
                listamateriales.DataSource = data;
                label10.Text = "Total Registros " + data.Rows.Count.ToString();
                label10.Show();
                imagencargar.Visible = false;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            ocultarlista2();
        }
    }
}