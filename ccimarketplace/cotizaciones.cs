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
    public partial class cotizaciones : Form
    {
        SqlConnection conectar = ConexionBD.obtenerconexion();
        void ocultarlista()
        {
            listaemprecotiza.Hide();
            label1.Hide();
            tbconsultacotiza.Hide();
            btenviadascom.Hide();
            check_todas_empre.Hide();
            btczenviadas.Hide();
            btczocitems.Hide();
        }

        void ocultarlista2()
        {
            listaemprecotiza.Show();
            label3.Hide();
            btontodasempre.Hide();
            label1.Show();
            tbconsultacotiza.Show();
            btenviadascom.Hide();
            check_todas_empre.Hide();
            btczenviadas.Hide();
            btczocitems.Hide();
        }

        public void imagen_load()
        {
            Thread.Sleep(3000);
        }
        public cotizaciones()
        {
            InitializeComponent();
        }

        private void cotizaciones_Load(object sender, EventArgs e)
        {
            listaemprecotiza.DropDownStyle = ComboBoxStyle.DropDownList;
            imagencargar.Hide();
            label10.Hide();
            label11.Hide();
            cubocargar.Hide();
            label3.Hide();
            btontodasempre.Hide();
            btenviadascom.Hide();
            btczenviadas.Hide();
            check_todas_empre.Hide();
            btczocitems.Hide();
            string query = "SELECT * from EMPRESAS where IDTIPOEMPRESA = 1 AND ELIMINADO = 0 and NOMBFANTASIA <> '' order by NOMBFANTASIA";

            SqlCommand cmd = new SqlCommand(query, conectar);
            SqlDataAdapter da1 = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da1.Fill(dt);
            listaemprecotiza.ValueMember = "IDEMPRESA";
            listaemprecotiza.DisplayMember = "NOMBEMPRESA";
            listaemprecotiza.DataSource = dt;
        }

        private async void tbconsultacotiza_Click(object sender, EventArgs e)
        {
            Task oTask = new Task(imagen_load);
            listacotizaciones.DataSource = null;
            listacotizaciones.Refresh();
            if (listaemprecotiza.Text == "")
            {
                MessageBox.Show("Porfavor seleccione la empresa");
            }
            else if (fechainicio.Text == "")
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
                string idempre = listaemprecotiza.SelectedValue.ToString();
                SqlDataAdapter da = new SqlDataAdapter(String.Format("select cz.idempresa empresaCompradora, rtrim(replace(replace(replace(replace(ec.NOMBEMPRESA, char(44), ''), char(9), ''),char(13),''),char(10),'')) nombreEmpresaCompradora, cz.idorgc idcentrocostoCompradora,rtrim(replace(replace(replace(replace(oc.NOMBRE, char(44), ''), char(9), ''), char(13), ''), char(10), '')) nombreCcostosCompradora, cz.numcz, rtrim(replace(replace(replace(replace(cz.nomcz, char(9), ''), char(44), ''), char(13), ''), char(10), '')) nombreCotizacion,cz.FECHACREACION FechaCreacionCotizacion, ed.DESCRIPCION estadoCotizacion, czp.IDEMPRESAV IDEmpresaInvitada,rtrim(replace(replace(replace(replace(eczp.NOMBEMPRESA, char(44), ''), char(9), ''), char(13), ''), char(10), '')) nombreempresaInvitada,ofe.IDOF idOferta, rtrim(replace(replace(replace(replace(ofe.NOMOF, char(44), ''), char(9), ''), char(13), ''), char(10), '')) nombreOferta,rtrim(replace(replace(replace(replace(eo.NOMBEMPRESA, char(44), ''), char(9), ''), char(13), ''), char(10), '')) nombreempresaOferto,rtrim(replace(replace(replace(replace(oo.nombre, char(44), ''), char(9), ''), char(13), ''), char(10), '')) sucursalOferto, rtrim(replace(replace(replace(replace((case when ofe.IDESTADOADJ = 1 then 'Adjudicada' else 'NO Adjudicada' end), char(9), ''), char(44), ''), char(13), ''), char(10), ''))   EstadoAdjudicacionOferta,rtrim(replace(replace(replace(replace((select descripcion from estadosdoc where IDESTADODOC = ofe.IDESTADODOC), char(44), ''), char(9), ''),char(13),''),char(10),'')) estadoOferta,case when(select descripcion from estadosdoc where IDESTADODOC = ofe.IDESTADODOC) = 'Oferta Guardada' or(select sum(precio* cantidad) from oflineas o where o.IDOF = ofe.IDOF ) <= 0 then 'NO' else 'SI' end Ofertó,replace((select sum(precio * cantidad) from oflineas o where o.IDOF = ofe.IDOF ),'.',',') valorOfertado from cz inner join CZPARTICIPANTES czp on czp.idcz = cz.idcz and cz.IDEMPRESA = czp.idempresac and cz.idorgc = czp.idorgc inner join[OF] ofe on ofe.idcz = czp.idcz and ofe.IDEMPRESAC = czp.IDEMPRESAC and ofe.IDORGC = czp.IDORGC and ofe.IDEMPRESAV = czp.IDEMPRESAV and ofe.idorgv = czp.idorgv inner join empresas ec on ec.IDEMPRESA = cz.idempresa inner join orgc oc on oc.IDEMPRESA = cz.idempresa and oc.idorgc = cz.idorgc inner join ESTADOSDOC ed on cz.IDESTADODOC = ed.IDESTADODOC inner join empresas eczp on eczp.IDEMPRESA = czp.IDEMPRESAV inner join empresas eo on eo.IDEMPRESA = ofe.IDEMPRESAV inner join orgv oo on ofe.IDEMPRESAV = oo.IDEMPRESA and oo.IDORGV = ofe.IDORGV where convert(varchar(8), cz.FECHACREACION, 112) between '" + dato2 + "' and '" + dato4 + "' and cz.idempresa = "+ idempre + ""), conectar);
                DataTable data = new DataTable();
                da.Fill(data);
                listacotizaciones.DataSource = data;
                label10.Text = "Total Registros " + data.Rows.Count.ToString();
                label10.Show();
                imagencargar.Visible = false;
            }
        }

        private void tbsalirmate_Click(object sender, EventArgs e)
        {
            Form1 inicio = new Form1();
            inicio.Show();
            this.Hide();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            ocultarlista();
            label3.Show();
            btontodasempre.Show();
            btenviadascom.Hide();
            check_todas_empre.Hide();
            btczenviadas.Hide();
            btczocitems.Hide();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            ocultarlista2();
        }

        private async void btontodasempre_Click(object sender, EventArgs e)
        {
            Task oTask = new Task(imagen_load);
            listacotizaciones.DataSource = null;
            listacotizaciones.Refresh();
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
                SqlDataAdapter da = new SqlDataAdapter(String.Format("select cz.idempresa empresaCompradora, rtrim(replace(replace(replace(replace(ec.NOMBEMPRESA, char(44), ''), char(9), ''),char(13),''),char(10),'')) nombreEmpresaCompradora, cz.idorgc idcentrocostoCompradora,rtrim(replace(replace(replace(replace(oc.NOMBRE, char(44), ''), char(9), ''), char(13), ''), char(10), '')) nombreCcostosCompradora, cz.numcz, rtrim(replace(replace(replace(replace(cz.nomcz, char(9), ''), char(44), ''), char(13), ''), char(10), '')) nombreCotizacion,cz.FECHACREACION FechaCreacionCotizacion, ed.DESCRIPCION estadoCotizacion, czp.IDEMPRESAV IDEmpresaInvitada,rtrim(replace(replace(replace(replace(eczp.NOMBEMPRESA, char(44), ''), char(9), ''), char(13), ''), char(10), '')) nombreempresaInvitada,ofe.IDOF idOferta, rtrim(replace(replace(replace(replace(ofe.NOMOF, char(44), ''), char(9), ''), char(13), ''), char(10), '')) nombreOferta,rtrim(replace(replace(replace(replace(eo.NOMBEMPRESA, char(44), ''), char(9), ''), char(13), ''), char(10), '')) nombreempresaOferto,rtrim(replace(replace(replace(replace(oo.nombre, char(44), ''), char(9), ''), char(13), ''), char(10), '')) sucursalOferto, rtrim(replace(replace(replace(replace((case when ofe.IDESTADOADJ = 1 then 'Adjudicada' else 'NO Adjudicada' end), char(9), ''), char(44), ''), char(13), ''), char(10), ''))   EstadoAdjudicacionOferta,rtrim(replace(replace(replace(replace((select descripcion from estadosdoc where IDESTADODOC = ofe.IDESTADODOC), char(44), ''), char(9), ''),char(13),''),char(10),'')) estadoOferta,case when(select descripcion from estadosdoc where IDESTADODOC = ofe.IDESTADODOC) = 'Oferta Guardada' or(select sum(precio* cantidad) from oflineas o where o.IDOF = ofe.IDOF ) <= 0 then 'NO' else 'SI' end Ofertó,replace((select sum(precio * cantidad) from oflineas o where o.IDOF = ofe.IDOF ),'.',',') valorOfertado from cz inner join CZPARTICIPANTES czp on czp.idcz = cz.idcz and cz.IDEMPRESA = czp.idempresac and cz.idorgc = czp.idorgc inner join[OF] ofe on ofe.idcz = czp.idcz and ofe.IDEMPRESAC = czp.IDEMPRESAC and ofe.IDORGC = czp.IDORGC and ofe.IDEMPRESAV = czp.IDEMPRESAV and ofe.idorgv = czp.idorgv inner join empresas ec on ec.IDEMPRESA = cz.idempresa inner join orgc oc on oc.IDEMPRESA = cz.idempresa and oc.idorgc = cz.idorgc inner join ESTADOSDOC ed on cz.IDESTADODOC = ed.IDESTADODOC inner join empresas eczp on eczp.IDEMPRESA = czp.IDEMPRESAV inner join empresas eo on eo.IDEMPRESA = ofe.IDEMPRESAV inner join orgv oo on ofe.IDEMPRESAV = oo.IDEMPRESA and oo.IDORGV = ofe.IDORGV where convert(varchar(8), cz.FECHACREACION, 112) between '" + dato2 + "' and '" + dato4 + "'"), conectar);
                DataTable data = new DataTable();
                da.Fill(data);
                listacotizaciones.DataSource = data;
                label10.Text = "Total Registros " + data.Rows.Count.ToString();
                label10.Show();
                imagencargar.Visible = false;
            }
        }

        private async void tbexportalexcelcoti_Click(object sender, EventArgs e)
        {
            Task oTask = new Task(imagen_load);
            label11.Show();
            cubocargar.Visible = true;
            oTask.Start();
            await oTask;
            new exportar().exportaraexcel(listacotizaciones);
            cubocargar.Visible = false;
            label11.Hide();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            label1.Show();
            label3.Hide();
            listaemprecotiza.Show();
            btontodasempre.Hide();
            tbconsultacotiza.Hide();
            btenviadascom.Show();
            check_todas_empre.Show();
            btczenviadas.Hide();
            btczocitems.Hide();
        }

        private void check_todas_empre_CheckedChanged(object sender, EventArgs e)
        {
            label3.Show();
            listaemprecotiza.Hide();

            if (check_todas_empre.Checked == false)
            {
                label3.Hide();
                listaemprecotiza.Show();
            }
        }

        private async void btenviadascom_Click(object sender, EventArgs e)
        {
            Task oTask = new Task(imagen_load);
            listacotizaciones.DataSource = null;
            listacotizaciones.Refresh();
            if (fechainicio.Text == "")
            {
                MessageBox.Show("Porfavor seleccione la fecha inicial");
            }
            else if (fechafinal.Text == "")
            {
                MessageBox.Show("Porfavor seleccione la fecha final");
            }
            else if(check_todas_empre.Checked == false)
            {
                label10.Hide();
                imagencargar.Visible = true;
                oTask.Start();
                await oTask;
                DateTime date1 = new DateTime(fechainicio.Value.Year, fechainicio.Value.Month, fechainicio.Value.Day);
                string dato2 = (date1.ToString("yyyyMMdd", CultureInfo.InvariantCulture));
                DateTime date3 = new DateTime(fechafinal.Value.Year, fechafinal.Value.Month, fechafinal.Value.Day);
                string dato4 = (date3.ToString("yyyyMMdd", CultureInfo.InvariantCulture));
                string idempre = listaemprecotiza.SelectedValue.ToString();
                SqlDataAdapter da = new SqlDataAdapter(String.Format("SELECT cz.idempresa empresaCompradora, rtrim(replace(replace(replace(replace(ec.NOMBEMPRESA, char(44), ''), char(9), ''),char(13),''),char(10),'')) nombreEmpresaCompradora, cz.idorgc idcentrocostoCompradora,rtrim(replace(replace(replace(replace(oc.NOMBRE, char(44), ''), char(9), ''),char(13),''),char(10),'')) nombreCcostosCompradora, cz.numcz, rtrim(replace(replace(replace(replace(cz.nomcz, char(9), ''), char(44), ''),char(13),''),char(10),'')) nombreCotizacion,cz.FECHACREACION FechaCreacionCotizacion, ed.DESCRIPCION estadoCotizacion, czp.IDEMPRESAV IDEmpresaInvitada,rtrim(replace(replace(replace(replace(eczp.NOMBEMPRESA, char(44), ''), char(9), ''),char(13),''),char(10),'')) nombreempresaInvitada,ofe.IDOF idOferta, rtrim(replace(replace(replace(replace(ofe.NOMOF, char(44), ''), char(9), ''),char(13),''),char(10),'')) nombreOferta,rtrim(replace(replace(replace(replace(eo.NOMBEMPRESA, char(44), ''), char(9), ''),char(13),''),char(10),'')) nombreempresaOferto,rtrim(replace(replace(replace(replace(oo.nombre, char(44), ''), char(9), ''),char(13),''),char(10),'')) sucursalOferto, rtrim(replace(replace(replace(replace(czlinea.NOMBARTICULO, char(44), ''), char(9), ''),char(13),''),char(10),'')) Detalle,czlinea.CANTIDAD cantidad,rtrim(replace(replace(replace(replace((case when ofe.IDESTADOADJ = 1 then 'Adjudicada' else 'NO Adjudicada' end), char(9), ''), char(44), ''),char(13),''),char(10),''))   EstadoAdjudicacionOferta,rtrim(replace(replace(replace(replace((select descripcion from estadosdoc where IDESTADODOC = ofe.IDESTADODOC), char(44), ''), char(9), ''),char(13),''),char(10),'')) estadoOferta,case when (select descripcion from estadosdoc where IDESTADODOC = ofe.IDESTADODOC) = 'Oferta Guardada' or (select sum(precio*cantidad) from oflineas o where o.IDOF = ofe.IDOF ) <= 0 then 'NO' else 'SI' end Ofertó, replace((select sum(precio*cantidad) from oflineas o where o.IDOF = ofe.IDOF ),'.',',') valorOfertado from cz inner join CZPARTICIPANTES czp on czp.idcz = cz.idcz and cz.IDEMPRESA = czp.idempresac and cz.idorgc = czp.idorgc inner join [OF] ofe on ofe.idcz = czp.idcz and ofe.IDEMPRESAC = czp.IDEMPRESAC and ofe.IDORGC = czp.IDORGC and ofe.IDEMPRESAV = czp.IDEMPRESAV and ofe.idorgv = czp.idorgv inner join empresas ec on ec.IDEMPRESA = cz.idempresa inner join orgc oc on oc.IDEMPRESA = cz.idempresa and oc.idorgc = cz.idorgc inner join ESTADOSDOC ed on cz.IDESTADODOC = ed.IDESTADODOC inner join empresas eczp on eczp.IDEMPRESA = czp.IDEMPRESAV inner join empresas eo on eo.IDEMPRESA = ofe.IDEMPRESAV inner join orgv oo on ofe.IDEMPRESAV = oo.IDEMPRESA and oo.IDORGV = ofe.IDORGV inner join CZLINEAS czlinea on czlinea.IDCZ = CZ.IDCZ where convert(varchar(8), cz.FECHACREACION, 112) between '" + dato2 + "' and '" + dato4 + "' and cz.IDEMPRESA = " + idempre + ""), conectar);
                DataTable data = new DataTable();
                da.Fill(data);
                listacotizaciones.DataSource = data;
                label10.Text = "Total Registros " + data.Rows.Count.ToString();
                label10.Show();
                imagencargar.Visible = false;
                check_todas_empre.Checked = false;
            }
            else if (check_todas_empre.Checked == true)
            {
                label10.Hide();
                imagencargar.Visible = true;
                oTask.Start();
                await oTask;
                DateTime date1 = new DateTime(fechainicio.Value.Year, fechainicio.Value.Month, fechainicio.Value.Day);
                string dato2 = (date1.ToString("yyyyMMdd", CultureInfo.InvariantCulture));
                DateTime date3 = new DateTime(fechafinal.Value.Year, fechafinal.Value.Month, fechafinal.Value.Day);
                string dato4 = (date3.ToString("yyyyMMdd", CultureInfo.InvariantCulture));
                string idempre = listaemprecotiza.SelectedValue.ToString();
                SqlDataAdapter da = new SqlDataAdapter(String.Format("SELECT cz.idempresa empresaCompradora, rtrim(replace(replace(replace(replace(ec.NOMBEMPRESA, char(44), ''), char(9), ''),char(13),''),char(10),'')) nombreEmpresaCompradora, cz.idorgc idcentrocostoCompradora,rtrim(replace(replace(replace(replace(oc.NOMBRE, char(44), ''), char(9), ''),char(13),''),char(10),'')) nombreCcostosCompradora, cz.numcz, rtrim(replace(replace(replace(replace(cz.nomcz, char(9), ''), char(44), ''),char(13),''),char(10),'')) nombreCotizacion,cz.FECHACREACION FechaCreacionCotizacion, ed.DESCRIPCION estadoCotizacion, czp.IDEMPRESAV IDEmpresaInvitada,rtrim(replace(replace(replace(replace(eczp.NOMBEMPRESA, char(44), ''), char(9), ''),char(13),''),char(10),'')) nombreempresaInvitada,ofe.IDOF idOferta, rtrim(replace(replace(replace(replace(ofe.NOMOF, char(44), ''), char(9), ''),char(13),''),char(10),'')) nombreOferta,rtrim(replace(replace(replace(replace(eo.NOMBEMPRESA, char(44), ''), char(9), ''),char(13),''),char(10),'')) nombreempresaOferto,rtrim(replace(replace(replace(replace(oo.nombre, char(44), ''), char(9), ''),char(13),''),char(10),'')) sucursalOferto, rtrim(replace(replace(replace(replace(czlinea.NOMBARTICULO, char(44), ''), char(9), ''),char(13),''),char(10),'')) Detalle,czlinea.CANTIDAD cantidad,rtrim(replace(replace(replace(replace((case when ofe.IDESTADOADJ = 1 then 'Adjudicada' else 'NO Adjudicada' end), char(9), ''), char(44), ''),char(13),''),char(10),''))   EstadoAdjudicacionOferta,rtrim(replace(replace(replace(replace((select descripcion from estadosdoc where IDESTADODOC = ofe.IDESTADODOC), char(44), ''), char(9), ''),char(13),''),char(10),'')) estadoOferta,case when (select descripcion from estadosdoc where IDESTADODOC = ofe.IDESTADODOC) = 'Oferta Guardada' or (select sum(precio*cantidad) from oflineas o where o.IDOF = ofe.IDOF ) <= 0 then 'NO' else 'SI' end Ofertó, replace((select sum(precio*cantidad) from oflineas o where o.IDOF = ofe.IDOF ),'.',',') valorOfertado from cz inner join CZPARTICIPANTES czp on czp.idcz = cz.idcz and cz.IDEMPRESA = czp.idempresac and cz.idorgc = czp.idorgc inner join [OF] ofe on ofe.idcz = czp.idcz and ofe.IDEMPRESAC = czp.IDEMPRESAC and ofe.IDORGC = czp.IDORGC and ofe.IDEMPRESAV = czp.IDEMPRESAV and ofe.idorgv = czp.idorgv inner join empresas ec on ec.IDEMPRESA = cz.idempresa inner join orgc oc on oc.IDEMPRESA = cz.idempresa and oc.idorgc = cz.idorgc inner join ESTADOSDOC ed on cz.IDESTADODOC = ed.IDESTADODOC inner join empresas eczp on eczp.IDEMPRESA = czp.IDEMPRESAV inner join empresas eo on eo.IDEMPRESA = ofe.IDEMPRESAV inner join orgv oo on ofe.IDEMPRESAV = oo.IDEMPRESA and oo.IDORGV = ofe.IDORGV inner join CZLINEAS czlinea on czlinea.IDCZ = CZ.IDCZ where convert(varchar(8), cz.FECHACREACION, 112) between '" + dato2 + "' and '" + dato4 + "'"), conectar);
                DataTable data = new DataTable();
                da.Fill(data);
                listacotizaciones.DataSource = data;
                label10.Text = "Total Registros " + data.Rows.Count.ToString();
                label10.Show();
                imagencargar.Visible = false;
                check_todas_empre.Checked = false;
            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            label1.Hide();
            label3.Hide();
            listaemprecotiza.Hide();
            btontodasempre.Hide();
            tbconsultacotiza.Hide();
            btenviadascom.Hide();
            check_todas_empre.Hide();
            btczenviadas.Show();
            btczocitems.Hide();
        }

        private async void btczenviadas_Click(object sender, EventArgs e)
        {
            Task oTask = new Task(imagen_load);
            listacotizaciones.DataSource = null;
            listacotizaciones.Refresh();
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
                SqlDataAdapter da = new SqlDataAdapter(String.Format("SELECT distinct cz.NUMCZ numcz,estadoc.DESCRIPCION descricz,oc.NUMOC numoc,estadocc.DESCRIPCION descrioc,em.NOMBFANTASIA emprecompra,emv.NOMBFANTASIA proveedor,USUARIOS.NOMBRE usuario,REPLACE(CONVERT(VARCHAR(MAX),(CAST(oc.total - oc.descuentos AS DECIMAL (18,2)))), '.', ',') total,cz.FECHACREACION fechacz from cz inner join CZLINEAS on CZLINEAS.IDCZ = cz.IDCZ inner join pm on pm.IDPM = CZLINEAS.IDPM inner join OCLINEAS ocli on ocli.IDPM = pm.IDPM left join oc on oc.IDOC = ocli.IDOC inner join ESTADOSDOC estadoc on estadoc.IDESTADODOC = CZLINEAS.IDESTADODOC inner join ESTADOSDOC estadocc on estadocc.IDESTADODOC = oc.IDESTADODOC inner join usuarios on USUARIOS.IDUSUARIO = oc.IDUSUARIO inner join empresas em on em.IDEMPRESA = oc.IDEMPRESA inner join EMPRESAS emv on emv.IDEMPRESA = oc.IDEMPRESAV  where convert(varchar(8), cz.FECHACREACION,112) between '" + dato2 + "' and '" + dato4 + "'"), conectar);
                DataTable data = new DataTable();
                da.Fill(data);
                listacotizaciones.DataSource = data;
                label10.Text = "Total Registros " + data.Rows.Count.ToString();
                label10.Show();
                imagencargar.Visible = false;
                check_todas_empre.Checked = false;
            }
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            label1.Show();
            label3.Hide();
            listaemprecotiza.Show();
            btontodasempre.Hide();
            tbconsultacotiza.Hide();
            btenviadascom.Hide();
            check_todas_empre.Show();
            btczenviadas.Hide();
            btczocitems.Show();
        }

        private async void btczocitems_Click(object sender, EventArgs e)
        {
            Task oTask = new Task(imagen_load);
            listacotizaciones.DataSource = null;
            listacotizaciones.Refresh();
            if (fechainicio.Text == "")
            {
                MessageBox.Show("Porfavor seleccione la fecha inicial");
            }
            else if (fechafinal.Text == "")
            {
                MessageBox.Show("Porfavor seleccione la fecha final");
            }
            else if (check_todas_empre.Checked == false)
            {
                label10.Hide();
                imagencargar.Visible = true;
                oTask.Start();
                await oTask;
                DateTime date1 = new DateTime(fechainicio.Value.Year, fechainicio.Value.Month, fechainicio.Value.Day);
                string dato2 = (date1.ToString("yyyyMMdd", CultureInfo.InvariantCulture));
                DateTime date3 = new DateTime(fechafinal.Value.Year, fechafinal.Value.Month, fechafinal.Value.Day);
                string dato4 = (date3.ToString("yyyyMMdd", CultureInfo.InvariantCulture));
                string idempre = listaemprecotiza.SelectedValue.ToString();
                SqlDataAdapter da = new SqlDataAdapter(String.Format("SELECT distinct  rtrim(replace(replace(replace(replace(ec.NOMBEMPRESA, char(44), ''), char(9), ''),char(13),''),char(10),'')) nombreEmpresaCompradora,rtrim(replace(replace(replace(replace(oc.NOMBRE, char(44), ''), char(9), ''),char(13),''),char(10),'')) nombreCcostosCompradora,cz.numcz, rtrim(replace(replace(replace(replace(cz.nomcz, char(9), ''), char(44), ''),char(13),''),char(10),'')) nombreCotizacion,cz.FECHACREACION FechaCreacionCotizacion, ed.DESCRIPCION estadoCotizacion, czp.IDEMPRESAV IDEmpresaInvitada,rtrim(replace(replace(replace(replace(eczp.NOMBEMPRESA, char(44), ''), char(9), ''),char(13),''),char(10),'')) nombreempresaInvitada,rtrim(replace(replace(replace(replace(ofe.NOMOF, char(44), ''), char(9), ''),char(13),''),char(10),'')) nombreOferta,rtrim(replace(replace(replace(replace(eo.NOMBEMPRESA, char(44), ''), char(9), ''),char(13),''),char(10),'')) nombreempresaOferto,rtrim(replace(replace(replace(replace(oo.nombre, char(44), ''), char(9), ''),char(13),''),char(10),'')) sucursalOferto,rtrim(replace(replace(replace(replace(czlinea.NOMBARTICULO, char(44), ''), char(9), ''),char(13),''),char(10),'')) Detalle,rtrim(replace(replace(replace(replace(czlinea.IDARTICULO , char(44), ''), char(9), ''),char(13),''),char(10),'')) codigoitems,REPLACE(CONVERT(VARCHAR(MAX),(CAST(ofl.PRECIO AS DECIMAL (18,2)))), '.', ',') precioitem,czlinea.CANTIDAD cantidad,rtrim(replace(replace(replace(replace((case when ofe.IDESTADOADJ = 1 then 'Adjudicada' else 'NO Adjudicada' end), char(9), ''), char(44), ''),char(13),''),char(10),''))   EstadoAdjudicacionOferta,rtrim(replace(replace(replace(replace((select descripcion from estadosdoc where IDESTADODOC = ofe.IDESTADODOC), char(44), ''), char(9), ''),char(13),''),char(10),'')) estadoOferta,case when (select descripcion from estadosdoc where IDESTADODOC = ofe.IDESTADODOC) = 'Oferta Guardada' or (select sum(precio*cantidad) from oflineas o where o.IDOF = ofe.IDOF ) <= 0 then 'NO' else 'SI' end Oferto from cz inner join CZPARTICIPANTES czp on czp.idcz = cz.idcz and cz.IDEMPRESA = czp.idempresac and cz.idorgc = czp.idorgc inner join [OF] ofe on ofe.idcz = czp.idcz and ofe.IDEMPRESAC = czp.IDEMPRESAC and ofe.IDORGC = czp.IDORGC and ofe.IDEMPRESAV = czp.IDEMPRESAV and ofe.idorgv = czp.idorgv inner join empresas ec on ec.IDEMPRESA = cz.idempresa inner join orgc oc on oc.IDEMPRESA =cz.idempresa and oc.idorgc = cz.idorgc inner join ESTADOSDOC ed on cz.IDESTADODOC = ed.IDESTADODOC inner join empresas eczp on eczp.IDEMPRESA = czp.IDEMPRESAV inner join empresas eo on eo.IDEMPRESA = ofe.IDEMPRESAV inner join orgv oo on ofe.IDEMPRESAV = oo.IDEMPRESA and oo.IDORGV = ofe.IDORGV inner join CZLINEAS czlinea on czlinea.IDCZ = CZ.IDCZ inner join OFLINEAS ofl on ofl.IDOF = ofe.IDOF where convert(varchar(8), cz.FECHACREACION, 112) between '" + dato2 + "' and '" + dato4 + "' and ec.IDEMPRESA = " + idempre + ""), conectar);
                DataTable data = new DataTable();
                da.Fill(data);
                listacotizaciones.DataSource = data;
                label10.Text = "Total Registros " + data.Rows.Count.ToString();
                label10.Show();
                imagencargar.Visible = false;
                check_todas_empre.Checked = false;
            }
            else if (check_todas_empre.Checked == true)
            {
                label10.Hide();
                imagencargar.Visible = true;
                oTask.Start();
                await oTask;
                DateTime date1 = new DateTime(fechainicio.Value.Year, fechainicio.Value.Month, fechainicio.Value.Day);
                string dato2 = (date1.ToString("yyyyMMdd", CultureInfo.InvariantCulture));
                DateTime date3 = new DateTime(fechafinal.Value.Year, fechafinal.Value.Month, fechafinal.Value.Day);
                string dato4 = (date3.ToString("yyyyMMdd", CultureInfo.InvariantCulture));
                string idempre = listaemprecotiza.SelectedValue.ToString();
                SqlDataAdapter da = new SqlDataAdapter(String.Format("SELECT cz.idempresa empresaCompradora, rtrim(replace(replace(replace(replace(ec.NOMBEMPRESA, char(44), ''), char(9), ''),char(13),''),char(10),'')) nombreEmpresaCompradora, cz.idorgc idcentrocostoCompradora,rtrim(replace(replace(replace(replace(oc.NOMBRE, char(44), ''), char(9), ''),char(13),''),char(10),'')) nombreCcostosCompradora, cz.numcz, rtrim(replace(replace(replace(replace(cz.nomcz, char(9), ''), char(44), ''),char(13),''),char(10),'')) nombreCotizacion,cz.FECHACREACION FechaCreacionCotizacion, ed.DESCRIPCION estadoCotizacion, czp.IDEMPRESAV IDEmpresaInvitada,rtrim(replace(replace(replace(replace(eczp.NOMBEMPRESA, char(44), ''), char(9), ''),char(13),''),char(10),'')) nombreempresaInvitada,ofe.IDOF idOferta, rtrim(replace(replace(replace(replace(ofe.NOMOF, char(44), ''), char(9), ''),char(13),''),char(10),'')) nombreOferta,rtrim(replace(replace(replace(replace(eo.NOMBEMPRESA, char(44), ''), char(9), ''),char(13),''),char(10),'')) nombreempresaOferto,rtrim(replace(replace(replace(replace(oo.nombre, char(44), ''), char(9), ''),char(13),''),char(10),'')) sucursalOferto, rtrim(replace(replace(replace(replace(czlinea.NOMBARTICULO, char(44), ''), char(9), ''),char(13),''),char(10),'')) Detalle,czlinea.CANTIDAD cantidad,rtrim(replace(replace(replace(replace((case when ofe.IDESTADOADJ = 1 then 'Adjudicada' else 'NO Adjudicada' end), char(9), ''), char(44), ''),char(13),''),char(10),''))   EstadoAdjudicacionOferta,rtrim(replace(replace(replace(replace((select descripcion from estadosdoc where IDESTADODOC = ofe.IDESTADODOC), char(44), ''), char(9), ''),char(13),''),char(10),'')) estadoOferta,case when (select descripcion from estadosdoc where IDESTADODOC = ofe.IDESTADODOC) = 'Oferta Guardada' or (select sum(precio*cantidad) from oflineas o where o.IDOF = ofe.IDOF ) <= 0 then 'NO' else 'SI' end Ofertó, replace((select sum(precio*cantidad) from oflineas o where o.IDOF = ofe.IDOF ),'.',',') valorOfertado from cz inner join CZPARTICIPANTES czp on czp.idcz = cz.idcz and cz.IDEMPRESA = czp.idempresac and cz.idorgc = czp.idorgc inner join [OF] ofe on ofe.idcz = czp.idcz and ofe.IDEMPRESAC = czp.IDEMPRESAC and ofe.IDORGC = czp.IDORGC and ofe.IDEMPRESAV = czp.IDEMPRESAV and ofe.idorgv = czp.idorgv inner join empresas ec on ec.IDEMPRESA = cz.idempresa inner join orgc oc on oc.IDEMPRESA = cz.idempresa and oc.idorgc = cz.idorgc inner join ESTADOSDOC ed on cz.IDESTADODOC = ed.IDESTADODOC inner join empresas eczp on eczp.IDEMPRESA = czp.IDEMPRESAV inner join empresas eo on eo.IDEMPRESA = ofe.IDEMPRESAV inner join orgv oo on ofe.IDEMPRESAV = oo.IDEMPRESA and oo.IDORGV = ofe.IDORGV inner join CZLINEAS czlinea on czlinea.IDCZ = CZ.IDCZ where convert(varchar(8), cz.FECHACREACION, 112) between '" + dato2 + "' and '" + dato4 + "'"), conectar);
                DataTable data = new DataTable();
                da.Fill(data);
                listacotizaciones.DataSource = data;
                label10.Text = "Total Registros " + data.Rows.Count.ToString();
                label10.Show();
                imagencargar.Visible = false;
                check_todas_empre.Checked = false;
            }
        }
    }
}
