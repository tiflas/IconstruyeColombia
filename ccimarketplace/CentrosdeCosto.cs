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
    public partial class CentrosdeCosto : Form
    {
        SqlConnection conectar = ConexionBD.obtenerconexion();

        void ocultarlista()
        {
            listaemprecosto.Hide();
            label1.Hide();
            tbconsultacentco.Hide();
        }

        void ocultarlista2()
        {
            listaemprecosto.Show();
            label3.Hide();
            tbconsultacentco.Show();
            btconsultatodas.Hide();
            label1.Show();
        }

        public void imagen_load()
        {
            Thread.Sleep(3000);
        }
        public CentrosdeCosto()
        {
            InitializeComponent();
        }

        private void CentrosdeCosto_Load(object sender, EventArgs e)
        {
            listaemprecosto.DropDownStyle = ComboBoxStyle.DropDownList;
            imagencargar.Hide();
            label3.Hide();
            label11.Hide();
            label10.Hide();
            cubocargar.Hide();
            btconsultatodas.Hide();
            {
                string query = "SELECT * from EMPRESAS where IDTIPOEMPRESA = 1 AND ELIMINADO = 0 and NOMBFANTASIA <> '' order by NOMBFANTASIA";

                SqlCommand cmd = new SqlCommand(query, conectar);
                SqlDataAdapter da1 = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da1.Fill(dt);
                listaemprecosto.ValueMember = "IDEMPRESA";
                listaemprecosto.DisplayMember = "NOMBEMPRESA";
                listaemprecosto.DataSource = dt;
            }
        }

        private async void tbconsultacentco_Click(object sender, EventArgs e)
        {
            Task oTask = new Task(imagen_load);
            listacentrocos.DataSource = null;
            listacentrocos.Refresh();
            if (listaemprecosto.Text == "")
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
                string idempre = listaemprecosto.SelectedValue.ToString();
                imagencargar.Show();
                SqlDataAdapter da = new SqlDataAdapter(String.Format("SELECT case when ORGC.ACTIVO = 1 then 'ACTIVO' else 'INACTIVO' END AS 'ESTADO' ,em.NOMBEMPRESA 'EMPRESA',ORGC.IDEMPRESA idempresa,orgc.IDORGC idorgc,ORGC.NOMBRE orgcnombre,ORGC.COMENTARIOS orgccomentarios,ORGC.IDMAESTRO orgcmaestro,ORGC.IDUSUARIONNI orgcusuarioini,ORGC.FECHAACTUALIZACION orgcfechaactuali,ORGC.FECHAACTUALIZACIONMONITOR orgcfechaactumoni,ORGC.TELEFONO orgctelefono,ORGC.CODIGO orgccodigo,ORGC.CENTCOSTOUSASC orgccento,ORGC.ESINTEGRADO orgcesinte,case when ORGC.FECHAULTIMACOMPRA = '1894-10-19 00:00:00.000' then '' else ORGC.FECHAULTIMACOMPRA END AS 'Fecha ultima compra' from ORGC inner join EMPRESAS em on em.IDEMPRESA= ORGC.IDEMPRESA where ORGC.IDEMPRESA = " + idempre + " and convert(varchar(8),ORGC.FECHAACTUALIZACION,112) BETWEEN '" + dato2 + "' and '" + dato4 + "' order by ORGC.ACTIVO asc"), conectar);
                DataTable data = new DataTable();
                da.Fill(data);
                listacentrocos.DataSource = data;
                label10.Text = "Total Registros " + data.Rows.Count.ToString();
                label10.Show();
                imagencargar.Visible = false;
            }   
        }

        private async void tbexportalcentcos_Click(object sender, EventArgs e)
        {
            Task oTask = new Task(imagen_load);
            label11.Show();
            cubocargar.Visible = true;
            oTask.Start();
            await oTask;
            new exportar().exportaraexcel(listacentrocos);
            cubocargar.Visible = false;
            label11.Hide();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            ocultarlista();
            label3.Show();
            btconsultatodas.Show();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            ocultarlista2();
            btconsultatodas.Hide();
        }

        private async void btconsultatodas_Click(object sender, EventArgs e)
        {
            Task oTask = new Task(imagen_load);
            imagencargar.Show();
            listacentrocos.DataSource = null;
            listacentrocos.Refresh();
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
                SqlDataAdapter da = new SqlDataAdapter(String.Format("SELECT case when ORGC.ACTIVO = 1 then 'ACTIVO' else 'INACTIVO' END AS 'ESTADO' ,em.NOMBEMPRESA 'EMPRESA',ORGC.IDEMPRESA idempresa,orgc.IDORGC idorgc,ORGC.NOMBRE orgcnombre,ORGC.COMENTARIOS orgccomentarios,ORGC.IDMAESTRO orgcmaestro,ORGC.IDUSUARIONNI orgcusuarioini,ORGC.FECHAACTUALIZACION orgcfechaactuali,ORGC.FECHAACTUALIZACIONMONITOR orgcfechaactumoni,ORGC.TELEFONO orgctelefono,ORGC.CODIGO orgccodigo,ORGC.CENTCOSTOUSASC orgccento,ORGC.ESINTEGRADO orgcesinte,case when ORGC.FECHAULTIMACOMPRA = '1894-10-19 00:00:00.000' then '' else ORGC.FECHAULTIMACOMPRA END AS 'Fecha ultima compra' from ORGC inner join EMPRESAS em on em.IDEMPRESA= ORGC.IDEMPRESA where convert(varchar(8),ORGC.FECHAACTUALIZACION,112) BETWEEN '" + dato2 + "' and '" + dato4 + "' order by ORGC.ACTIVO asc"), conectar);
                DataTable data = new DataTable();
                da.Fill(data);
                listacentrocos.DataSource = data;
                label10.Text = "Total Registros " + data.Rows.Count.ToString();
                label10.Show();
                imagencargar.Visible = false;
            }
            imagencargar.Hide();
        }

        private void tbsalirmate_Click(object sender, EventArgs e)
        {
            Form1 inicio = new Form1();
            inicio.Show();
            this.Hide();
        }
    }
}
