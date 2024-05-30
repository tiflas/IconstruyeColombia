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
    public partial class Producto : Form
    {
        SqlConnection conectar = ConexionBD.obtenerconexion();

        public void imagen_load()
        {
            Thread.Sleep(3000);
        }
        public Producto()
        {
            InitializeComponent();
        }

        private async void btgenerar_Click(object sender, EventArgs e)
        {
            Task oTask = new Task(imagen_load);
            listararticulo.DataSource = null;
            listararticulo.Refresh();
            if (txtarticulo.Text == "")
            {
                MessageBox.Show("Porfavor escriba el articulo");
            }
            else if (fechainicio.Text == "")
            {
                MessageBox.Show("Porfavor seleccione la fecha");
            }
            else if (fechafinal.Text == "")
            {
                MessageBox.Show("Porfavor seleccione la fecha");
            }
            else 
            {
                label10.Hide();
                imagencargar.Visible = true;
                oTask.Start();
                await oTask;
                string articulo = txtarticulo.Text.Trim();
                DateTime date1 = new DateTime(fechainicio.Value.Year, fechainicio.Value.Month, fechainicio.Value.Day);
                string dato2 = (date1.ToString("yyyyMMdd", CultureInfo.InvariantCulture));
                DateTime date3 = new DateTime(fechafinal.Value.Year, fechafinal.Value.Month, fechafinal.Value.Day);
                string dato4 = (date3.ToString("yyyyMMdd", CultureInfo.InvariantCulture));
                SqlDataAdapter da = new SqlDataAdapter(String.Format("SELECT e.NOMBEMPRESA as EMPRESACOMPRADORA,em.NOMBEMPRESA as EMPRESAVENDEDORA,ol.NOMBARTICULO 'ARTICULO',ol.DESCRIPPARTIDA 'DESCRIPCION',ol.COMENTARIOS 'COMENTARIOS',ol.GLOSA 'OBSERVACION',ceiling(sum(ol.CANTIDAD))as CANTIDAD, ceiling(sum(ol.cantidad * ol.preciounitario)) VALOR, OC.FECHAENVIO from oc inner join oclineas ol on oc.idempresa = ol.idempresa inner join empresas e on e.idempresa = oc.idempresa and oc.idorgc =  ol.idorgc and oc.idoc = ol.idoc inner join empresas em on em.IDEMPRESA = oc.IDEMPRESAV where ( (convert(varchar(8), oc.fechaenvio, 112) between '" + dato2 + "' and '" + dato4 + "' and ol.NOMBARTICULO like '%" + articulo + "%') or (convert(varchar(8), oc.fechaenvio, 112) between '" + dato2 + "' and '" + dato4 + "' and ol.COMENTARIOS like '%" + articulo + "%') or (convert(varchar(8), oc.fechaenvio, 112) between '" + dato2 + "' and '" + dato4 + "' and ol.DESCRIPPARTIDA like '%" + articulo + "%') or (convert(varchar(8), oc.fechaenvio, 112) between '" + dato2 + "' and '" + dato4 + "' and ol.GLOSA like '%" + articulo + "%')) group by e.NOMBEMPRESA,em.VISIBILIDAD,em.NOMBEMPRESA,ol.CANTIDAD,ol.NOMBARTICULO,ol.DESCRIPPARTIDA,ol.COMENTARIOS,ol.GLOSA , OC.FECHAENVIO order by  e.NOMBEMPRESA"), conectar);
                DataTable data = new DataTable();
                da.Fill(data);
                listararticulo.DataSource = data;
                label10.Text = "Total Registros " + data.Rows.Count.ToString();
                label10.Show();
                imagencargar.Visible = false;
            }
            
        }

        private async void btexportarexcel_Click(object sender, EventArgs e)
        {
            Task oTask = new Task(imagen_load);
            label11.Show();
            cubocargar.Visible = true;
            oTask.Start();
            await oTask;
            new exportar().exportaraexcel(listararticulo);
            cubocargar.Visible = false;
            label11.Hide();
        }

        private void btsalir_Click(object sender, EventArgs e)
        {
            Form1 inicio = new Form1();
            inicio.Show();
            this.Hide();
        }

        private void Producto_Load(object sender, EventArgs e)
        {
            imagencargar.Hide();
            label10.Hide();
            label11.Hide();
            cubocargar.Hide();
            btintegrados_noint.Hide();
            btinsumoprovee.Hide();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            btgenerar.Hide();
            btinsumoprovee.Hide();
            btintegrados_noint.Show();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            btgenerar.Show();
            btinsumoprovee.Hide();
            btintegrados_noint.Hide();
        }

        private async void btintegrados_noint_Click(object sender, EventArgs e)
        {
            Task oTask = new Task(imagen_load);
            listararticulo.DataSource = null;
            listararticulo.Refresh();
            if (txtarticulo.Text == "")
            {
                MessageBox.Show("Porfavor escriba el articulo");
            }
            else if (fechainicio.Text == "")
            {
                MessageBox.Show("Porfavor seleccione la fecha");
            }
            else if (fechafinal.Text == "")
            {
                MessageBox.Show("Porfavor seleccione la fecha");
            }
            else
            {
                label10.Hide();
                imagencargar.Visible = true;
                oTask.Start();
                await oTask;
                string articulo = txtarticulo.Text.Trim();
                DateTime date1 = new DateTime(fechainicio.Value.Year, fechainicio.Value.Month, fechainicio.Value.Day);
                string dato2 = (date1.ToString("yyyyMMdd", CultureInfo.InvariantCulture));
                DateTime date3 = new DateTime(fechafinal.Value.Year, fechafinal.Value.Month, fechafinal.Value.Day);
                string dato4 = (date3.ToString("yyyyMMdd", CultureInfo.InvariantCulture));
                SqlDataAdapter da = new SqlDataAdapter(String.Format("SELECT e.NOMBEMPRESA as EMPRESACOMPRADORA,em.NOMBEMPRESA as EMPRESAVENDEDORA,em.IDEMPRESA IDEMPRESAVENDEDORA,CASE WHEN orgv.ESINTEGRADO = 1 THEN 'INTEGRADO' WHEN  orgv.ESINTEGRADO = 0 THEN 'NO INTEGRADO' ELSE 'NO DEFINIDO' END as VISIBILIDAD,orgv.TELEFONO 'TELEFONO',orgv.EMAIL 'EMAIL',ol.NOMBARTICULO 'ARTICULO',ceiling(sum(ol.CANTIDAD))as CANTIDAD, ceiling(sum(ol.cantidad * ol.preciounitario)) VALOR from oc inner join oclineas ol on oc.idempresa = ol.idempresa inner join empresas e on e.idempresa = oc.idempresa and oc.idorgc =  ol.idorgc and oc.idoc = ol.idoc inner join empresas em on em.IDEMPRESA= oc.IDEMPRESAV inner join ORGV orgv on orgv.idorgv = oc.idorgv where convert(varchar(8), oc.fechaenvio, 112) between '" + dato2 + "' and '" + dato4 + "' and ol.NOMBARTICULO like '%" + articulo + "%' group by e.NOMBEMPRESA,em.VISIBILIDAD,em.NOMBEMPRESA,ol.CANTIDAD,ol.NOMBARTICULO,orgv.TELEFONO,orgv.EMAIL,orgv.ESINTEGRADO,em.IDEMPRESA"), conectar);
                DataTable data = new DataTable();
                da.Fill(data);
                listararticulo.DataSource = data;
                label10.Text = "Total Registros " + data.Rows.Count.ToString();
                label10.Show();
                imagencargar.Visible = false;
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            btgenerar.Hide();
            btinsumoprovee.Show();
            btintegrados_noint.Hide();
        }

        private async void btinsumoprovee_Click(object sender, EventArgs e)
        {
            Task oTask = new Task(imagen_load);
            listararticulo.DataSource = null;
            listararticulo.Refresh();
            if (txtarticulo.Text == "")
            {
                MessageBox.Show("Porfavor escriba el articulo");
            }
            else if (fechainicio.Text == "")
            {
                MessageBox.Show("Porfavor seleccione la fecha");
            }
            else if (fechafinal.Text == "")
            {
                MessageBox.Show("Porfavor seleccione la fecha");
            }
            else
            {
                label10.Hide();
                imagencargar.Visible = true;
                oTask.Start();
                await oTask;
                string articulo = txtarticulo.Text.Trim();
                DateTime date1 = new DateTime(fechainicio.Value.Year, fechainicio.Value.Month, fechainicio.Value.Day);
                string dato2 = (date1.ToString("yyyyMMdd", CultureInfo.InvariantCulture));
                DateTime date3 = new DateTime(fechafinal.Value.Year, fechafinal.Value.Month, fechafinal.Value.Day);
                string dato4 = (date3.ToString("yyyyMMdd", CultureInfo.InvariantCulture));
                SqlDataAdapter da = new SqlDataAdapter(String.Format("SELECT distinct em.NOMBFANTASIA as proveedor , razo.RUT rut,em.IDEMPRESA idempresa from oc inner join oclineas ol on oc.idempresa = ol.idempresa inner join empresas e on e.idempresa = oc.idempresa and oc.idorgc =  ol.idorgc and oc.idoc = ol.idoc inner join empresas em on em.IDEMPRESA= oc.IDEMPRESAV inner join RAZONSOCIAL razo on razo.IDEMPRESA = em.IDEMPRESA where ( (convert(varchar(8), oc.fechaenvio, 112) between '" + dato2 + "' and '" + dato4 + "' and ol.NOMBARTICULO like '%" + articulo + "%') or (convert(varchar(8), oc.fechaenvio, 112) between '" + dato2 + "' and '" + dato4 + "' and ol.COMENTARIOS like '%" + articulo + "%') or (convert(varchar(8), oc.fechaenvio, 112) between '" + dato2 + "' and '" + dato4 + "' and ol.DESCRIPPARTIDA like '%" + articulo + "%') or (convert(varchar(8), oc.fechaenvio, 112) between '" + dato2 + "' and '" + dato4 + "' and ol.GLOSA like '%" + articulo + "%')) group by e.NOMBEMPRESA,em.VISIBILIDAD,em.NOMBFANTASIA,ol.CANTIDAD,ol.NOMBARTICULO,ol.DESCRIPPARTIDA,ol.COMENTARIOS,ol.GLOSA , OC.FECHAENVIO,em.IDEMPRESA,razo.RUT order by em.NOMBFANTASIA"), conectar);
                DataTable data = new DataTable();
                da.Fill(data);
                listararticulo.DataSource = data;
                label10.Text = "Total Registros " + data.Rows.Count.ToString();
                label10.Show();
                imagencargar.Visible = false;
            }
        }
    }
}

