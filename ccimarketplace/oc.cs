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
    public partial class oc : Form
    {
        SqlConnection conectar = ConexionBD.obtenerconexion();
        void ocultarlista()
        {
            listaempreoc.Hide();
            label3.Hide();
            label7.Hide();
            btgenerar.Hide();
            label5.Hide();
            label6.Hide();
            visibilidad_prove.Hide();
            estadooc.Hide();
            btestadosoc.Hide();
            check_estados_todo.Hide();
            check_todas_empre.Hide();
        }

        void ocultarlista2()
        {
            listaempreoc.Show();
            label4.Hide();
            label5.Hide();
            label6.Hide();
            label7.Hide();
            btgenerar.Show();
            btconsultatodas.Hide();
            label3.Show();
            visibilidad_prove.Hide();
            estadooc.Hide();
            btestadosoc.Hide();
            check_estados_todo.Hide();
            check_todas_empre.Hide();
        }

        void ocultarlista3()
        {
            listaempreoc.Show();
            label4.Hide();
            label7.Hide();
            label5.Show();
            label6.Show();
            btgenerar.Hide();
            btconsultatodas.Hide();
            label3.Show();
            visibilidad_prove.Show();
            estadooc.Show();
            btestadosoc.Show();
            check_estados_todo.Show();
            check_todas_empre.Show();
        }

        public void imagen_load()
        {
            Thread.Sleep(3000);
        }
        public oc()
        {
            InitializeComponent();
        }

        private void btsalir_Click(object sender, EventArgs e)
        {
            Form1 inicio = new Form1();
            inicio.Show();
            this.Hide();
        }

        private async void btgenerar_Click(object sender, EventArgs e)
        {
            Task oTask = new Task(imagen_load);
            listaoc.DataSource = null;
            listaoc.Refresh();
            if (listaempreoc.Text == "")
            {
                MessageBox.Show("Porfavor seleccione la empresa");
            }
            else if (fechainioc.Text == "")
            {
                MessageBox.Show("Porfavor seleccione la fecha");
            }
            else if (fechafinaloc.Text == "")
            {
                MessageBox.Show("Porfavor seleccione la fecha");
            }
            else
            {
                label10.Hide();
                imagencargar.Visible = true;
                oTask.Start();
                await oTask;
                DateTime date1 = new DateTime(fechainioc.Value.Year, fechainioc.Value.Month, fechainioc.Value.Day);
                string dato2 = (date1.ToString("yyyyMMdd",CultureInfo.InvariantCulture));
                DateTime date3 = new DateTime(fechafinaloc.Value.Year, fechafinaloc.Value.Month, fechafinaloc.Value.Day);
                string dato4 = (date3.ToString("yyyyMMdd", CultureInfo.InvariantCulture));
                string idempre = listaempreoc.SelectedValue.ToString();
                //string fecha1 = fechainioc.Value.Year + "" + fechainioc.Value.Month + "" + fechainioc.Value.Day;
                //string fecha2 = fechafinaloc.Value.Year + "" + fechafinaloc.Value.Month + "" + fechafinaloc.Value.Day;

                SqlDataAdapter da = new SqlDataAdapter(String.Format("select oc.idoc idoc, emp2.idempresa idEmpresaCompradora, emp2.nombempresa EmpresaCompradora,orc.idorgc idOrgCompra, orc.nombre nombreOrgCompra, emp.idempresa idEmpresaProveedora, emp.nombempresa EmpresaProveedora, orv.idorgv idSucursalVenta, orv.nombre SucursalVenta,oc.fechaenvio, oc.numoc NoOC, oc.idmoneda, REPLACE(CONVERT(VARCHAR(MAX),(CAST(oc.total - oc.descuentos AS DECIMAL (18,2)))), '.', ',') total,ed.idestadodoc idEstadoDoc, ed.descripcion estadodoc from oc inner join empresas emp on emp.idempresa = oc.idempresav inner join empresas emp2 on emp2.idempresa = oc.idempresa inner join orgc orc on orc.idorgc = oc.idorgc inner join orgv orv on orv.idorgv = oc.idorgv inner join estadosdoc ed on oc.idestadodoc = ed.idestadodoc left join oclineas ocl on ocl.idoc = oc.idoc where emp2.IDEMPRESA = " + idempre + " and convert(varchar(8),oc.fechaenvio,112) between '" + dato2 + "' and '" + dato4 + "' group by oc.idoc,oc.numoc,oc.idempresav,rutorgv,emp.nombempresa,emp2.nombempresa,orc.nombre,oc.nomoc, oc.fechaenvio,ed.descripcion,oc.idmoneda,emp2.idempresa,orc.idorgc,emp.idempresa, orv.idorgv,orv.nombre,oc.total,oc.descuentos,ed.idestadodoc order by oc.fechaenvio"), conectar);
                DataTable data = new DataTable();
                da.Fill(data);
                listaoc.DataSource = data;
                label10.Text = "Total Registros " + data.Rows.Count.ToString();
                label10.Show();
                imagencargar.Visible = false;
            }
            /*else if ((fechainioc.Value.Month < 10 & fechainioc.Value.Day < 10) & (fechafinaloc.Value.Month < 10 & fechafinaloc.Value.Day < 10))
            {
                string fecha1 = fechainioc.Value.Year + "0" + fechainioc.Value.Month + "0" + fechainioc.Value.Day;
                string fecha2 = fechafinaloc.Value.Year + "0" + fechafinaloc.Value.Month + "0" + fechafinaloc.Value.Day;
                SqlDataAdapter da = new SqlDataAdapter(String.Format("select oc.idoc, emp2.idempresa idEmpresaCompradora, emp2.nombempresa EmpresaCompradora,orc.idorgc idOrgCompra, orc.nombre nombreOrgCompra, emp.idempresa idEmpresaProveedora, emp.nombempresa EmpresaProveedora, orv.idorgv idSucursalVenta, orv.nombre SucursalVenta,oc.fechaenvio, oc.numoc NoOC, oc.idmoneda, REPLACE(CONVERT(VARCHAR(MAX),(CAST(oc.total - oc.descuentos AS DECIMAL (18,2)))), '.', ',') total,ed.idestadodoc idEstadoDoc, ed.descripcion estadodoc from oc inner join empresas emp on emp.idempresa = oc.idempresav inner join empresas emp2 on emp2.idempresa = oc.idempresa inner join orgc orc on orc.idorgc = oc.idorgc inner join orgv orv on orv.idorgv = oc.idorgv inner join estadosdoc ed on oc.idestadodoc = ed.idestadodoc left join oclineas ocl on ocl.idoc = oc.idoc where convert(varchar(8),oc.fechaenvio,112) between '" + fecha1 + "' and '" + fecha2 + "' group by oc.idoc,oc.numoc,oc.idempresav,rutorgv,emp.nombempresa,emp2.nombempresa,orc.nombre,oc.nomoc, oc.fechaenvio,ed.descripcion,oc.idmoneda,emp2.idempresa,orc.idorgc,emp.idempresa, orv.idorgv,orv.nombre,oc.total,oc.descuentos,ed.idestadodoc order by oc.fechaenvio"), conectar);
                DataTable data = new DataTable();
                da.Fill(data);
                listaoc.DataSource = data;
            }
            else if ((fechainioc.Value.Day < 10 & fechainioc.Value.Month >= 10) & (fechafinaloc.Value.Day < 10 & fechafinaloc.Value.Month >= 10))
            {
                string fecha1 = fechainioc.Value.Year + "" + fechainioc.Value.Month + "0" + fechainioc.Value.Day;
                string fecha2 = fechafinaloc.Value.Year + "" + fechafinaloc.Value.Month + "0" + fechafinaloc.Value.Day;
                SqlDataAdapter da = new SqlDataAdapter(String.Format("select oc.idoc, emp2.idempresa idEmpresaCompradora, emp2.nombempresa EmpresaCompradora,orc.idorgc idOrgCompra, orc.nombre nombreOrgCompra, emp.idempresa idEmpresaProveedora, emp.nombempresa EmpresaProveedora, orv.idorgv idSucursalVenta, orv.nombre SucursalVenta,oc.fechaenvio, oc.numoc NoOC, oc.idmoneda, REPLACE(CONVERT(VARCHAR(MAX),(CAST(oc.total - oc.descuentos AS DECIMAL (18,2)))), '.', ',') total,ed.idestadodoc idEstadoDoc, ed.descripcion estadodoc from oc inner join empresas emp on emp.idempresa = oc.idempresav inner join empresas emp2 on emp2.idempresa = oc.idempresa inner join orgc orc on orc.idorgc = oc.idorgc inner join orgv orv on orv.idorgv = oc.idorgv inner join estadosdoc ed on oc.idestadodoc = ed.idestadodoc left join oclineas ocl on ocl.idoc = oc.idoc where convert(varchar(8),oc.fechaenvio,112) between '" + fecha1 + "' and '" + fecha2 + "' group by oc.idoc,oc.numoc,oc.idempresav,rutorgv,emp.nombempresa,emp2.nombempresa,orc.nombre,oc.nomoc, oc.fechaenvio,ed.descripcion,oc.idmoneda,emp2.idempresa,orc.idorgc,emp.idempresa, orv.idorgv,orv.nombre,oc.total,oc.descuentos,ed.idestadodoc order by oc.fechaenvio"), conectar);
                DataTable data = new DataTable();
                da.Fill(data);
                listaoc.DataSource = data;
            }
            else if ((fechainioc.Value.Month < 10 & fechainioc.Value.Day >= 10) & (fechafinaloc.Value.Month < 10 & fechafinaloc.Value.Day >= 10))
            {
                string fecha1 = fechainioc.Value.Year + "0" + fechainioc.Value.Month + "" + fechainioc.Value.Day;
                string fecha2 = fechafinaloc.Value.Year + "0" + fechafinaloc.Value.Month + "" + fechafinaloc.Value.Day;
                SqlDataAdapter da = new SqlDataAdapter(String.Format("select oc.idoc, emp2.idempresa idEmpresaCompradora, emp2.nombempresa EmpresaCompradora,orc.idorgc idOrgCompra, orc.nombre nombreOrgCompra, emp.idempresa idEmpresaProveedora, emp.nombempresa EmpresaProveedora, orv.idorgv idSucursalVenta, orv.nombre SucursalVenta,oc.fechaenvio, oc.numoc NoOC, oc.idmoneda, REPLACE(CONVERT(VARCHAR(MAX),(CAST(oc.total - oc.descuentos AS DECIMAL (18,2)))), '.', ',') total,ed.idestadodoc idEstadoDoc, ed.descripcion estadodoc from oc inner join empresas emp on emp.idempresa = oc.idempresav inner join empresas emp2 on emp2.idempresa = oc.idempresa inner join orgc orc on orc.idorgc = oc.idorgc inner join orgv orv on orv.idorgv = oc.idorgv inner join estadosdoc ed on oc.idestadodoc = ed.idestadodoc left join oclineas ocl on ocl.idoc = oc.idoc where convert(varchar(8),oc.fechaenvio,112) between '" + fecha1 + "' and '" + fecha2 + "' group by oc.idoc,oc.numoc,oc.idempresav,rutorgv,emp.nombempresa,emp2.nombempresa,orc.nombre,oc.nomoc, oc.fechaenvio,ed.descripcion,oc.idmoneda,emp2.idempresa,orc.idorgc,emp.idempresa, orv.idorgv,orv.nombre,oc.total,oc.descuentos,ed.idestadodoc order by oc.fechaenvio"), conectar);
                DataTable data = new DataTable();
                da.Fill(data);
                listaoc.DataSource = data;
            }
            else if ((fechainioc.Value.Month <= 10 & fechainioc.Value.Day <= 10) & (fechafinaloc.Value.Month >= 10 & fechafinaloc.Value.Day >= 10))
            {
                string fecha1 = fechainioc.Value.Year + "0" + fechainioc.Value.Month + "0" + fechainioc.Value.Day;
                string fecha2 = fechafinaloc.Value.Year + "" + fechafinaloc.Value.Month + "" + fechafinaloc.Value.Day;
                SqlDataAdapter da = new SqlDataAdapter(String.Format("select oc.idoc, emp2.idempresa idEmpresaCompradora, emp2.nombempresa EmpresaCompradora,orc.idorgc idOrgCompra, orc.nombre nombreOrgCompra, emp.idempresa idEmpresaProveedora, emp.nombempresa EmpresaProveedora, orv.idorgv idSucursalVenta, orv.nombre SucursalVenta,oc.fechaenvio, oc.numoc NoOC, oc.idmoneda, REPLACE(CONVERT(VARCHAR(MAX),(CAST(oc.total - oc.descuentos AS DECIMAL (18,2)))), '.', ',') total,ed.idestadodoc idEstadoDoc, ed.descripcion estadodoc from oc inner join empresas emp on emp.idempresa = oc.idempresav inner join empresas emp2 on emp2.idempresa = oc.idempresa inner join orgc orc on orc.idorgc = oc.idorgc inner join orgv orv on orv.idorgv = oc.idorgv inner join estadosdoc ed on oc.idestadodoc = ed.idestadodoc left join oclineas ocl on ocl.idoc = oc.idoc where convert(varchar(8),oc.fechaenvio,112) between '" + fecha1 + "' and '" + fecha2 + "' group by oc.idoc,oc.numoc,oc.idempresav,rutorgv,emp.nombempresa,emp2.nombempresa,orc.nombre,oc.nomoc, oc.fechaenvio,ed.descripcion,oc.idmoneda,emp2.idempresa,orc.idorgc,emp.idempresa, orv.idorgv,orv.nombre,oc.total,oc.descuentos,ed.idestadodoc order by oc.fechaenvio"), conectar);
                DataTable data = new DataTable();
                da.Fill(data);
                listaoc.DataSource = data;
            }
            else
            {
                string fecha = fechainioc.Value.Year + "" + fechainioc.Value.Month + "" + fechainioc.Value.Day;
                SqlDataAdapter da = new SqlDataAdapter(String.Format("select oc.idoc, emp2.idempresa idEmpresaCompradora, emp2.nombempresa EmpresaCompradora,orc.idorgc idOrgCompra, orc.nombre nombreOrgCompra, emp.idempresa idEmpresaProveedora, emp.nombempresa EmpresaProveedora, orv.idorgv idSucursalVenta, orv.nombre SucursalVenta,oc.fechaenvio, oc.numoc NoOC, oc.idmoneda, REPLACE(CONVERT(VARCHAR(MAX),(CAST(oc.total - oc.descuentos AS DECIMAL (18,2)))), '.', ',') total,ed.idestadodoc idEstadoDoc, ed.descripcion estadodoc from oc inner join empresas emp on emp.idempresa = oc.idempresav inner join empresas emp2 on emp2.idempresa = oc.idempresa inner join orgc orc on orc.idorgc = oc.idorgc inner join orgv orv on orv.idorgv = oc.idorgv inner join estadosdoc ed on oc.idestadodoc = ed.idestadodoc left join oclineas ocl on ocl.idoc = oc.idoc where convert(varchar(8),oc.fechaenvio,112) >= '" + fecha + "' group by oc.idoc,oc.numoc,oc.idempresav,rutorgv,emp.nombempresa,emp2.nombempresa,orc.nombre,oc.nomoc, oc.fechaenvio,ed.descripcion,oc.idmoneda,emp2.idempresa,orc.idorgc,emp.idempresa, orv.idorgv,orv.nombre,oc.total,oc.descuentos,ed.idestadodoc order by oc.fechaenvio"), conectar);
                DataTable data = new DataTable();
                da.Fill(data);
                listaoc.DataSource = data;
            }*/
        }

        private async void btexportarexcel_Click(object sender, EventArgs e)
        {
            Task oTask = new Task(imagen_load);
            label11.Show();
            cubocargar.Visible = true;
            oTask.Start();
            await oTask;
            new exportar().exportaraexcel(listaoc);
            cubocargar.Visible = false;
            label11.Hide();
        }

        private void oc_Load(object sender, EventArgs e)
        {
            listaempreoc.DropDownStyle = ComboBoxStyle.DropDownList;
            visibilidad_prove.DropDownStyle = ComboBoxStyle.DropDownList;
            estadooc.DropDownStyle = ComboBoxStyle.DropDownList;
            imagencargar.Hide();
            label4.Hide();
            label5.Hide();
            label6.Hide();
            label7.Hide();
            label10.Hide();
            label11.Hide();
            cubocargar.Hide();
            visibilidad_prove.Hide();
            estadooc.Hide();
            btconsultatodas.Hide();
            btestadosoc.Hide();
            check_estados_todo.Hide();
            check_todas_empre.Hide();
            {
                string query = "SELECT * from EMPRESAS where IDTIPOEMPRESA = 1 AND ELIMINADO = 0 and NOMBFANTASIA <> '' order by NOMBFANTASIA";

                SqlCommand cmd = new SqlCommand(query, conectar);
                SqlDataAdapter da1 = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da1.Fill(dt);
                listaempreoc.ValueMember = "IDEMPRESA";
                listaempreoc.DisplayMember = "NOMBEMPRESA";
                listaempreoc.DataSource = dt;
            }

            {
                string query = "SELECT * from estadosdoc order by DESCRIPCION";

                SqlCommand cmd1 = new SqlCommand(query, conectar);
                SqlDataAdapter da2 = new SqlDataAdapter(cmd1);
                DataTable dtt = new DataTable();
                da2.Fill(dtt);
                estadooc.ValueMember = "IDESTADODOC";
                estadooc.DisplayMember = "DESCRIPCION";
                estadooc.DataSource = dtt;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            ocultarlista();
            label4.Show();
            btconsultatodas.Show();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            ocultarlista2();
        }

        private async void btconsultatodas_Click(object sender, EventArgs e)
        {
            Task oTask = new Task(imagen_load);
            listaoc.DataSource = null;
            listaoc.Refresh();
            if (listaempreoc.Text == "")
            {
                MessageBox.Show("Porfavor seleccione la empresa");
            }
            else if (fechainioc.Text == "")
            {
                MessageBox.Show("Porfavor seleccione la fecha");
            }
            else if (fechafinaloc.Text == "")
            {
                MessageBox.Show("Porfavor seleccione la fecha");
            }
            else
            {
                label10.Hide();
                imagencargar.Visible = true;
                oTask.Start();
                await oTask;
                DateTime date1 = new DateTime(fechainioc.Value.Year, fechainioc.Value.Month, fechainioc.Value.Day);
                string dato2 = (date1.ToString("yyyyMMdd", CultureInfo.InvariantCulture));
                DateTime date3 = new DateTime(fechafinaloc.Value.Year, fechafinaloc.Value.Month, fechafinaloc.Value.Day);
                string dato4 = (date3.ToString("yyyyMMdd", CultureInfo.InvariantCulture));
                SqlDataAdapter da = new SqlDataAdapter(String.Format("select oc.idoc, emp2.idempresa idEmpresaCompradora, emp2.nombempresa EmpresaCompradora,orc.idorgc idOrgCompra, orc.nombre nombreOrgCompra, emp.idempresa idEmpresaProveedora, emp.nombempresa EmpresaProveedora, orv.idorgv idSucursalVenta, orv.nombre SucursalVenta,oc.fechaenvio, oc.numoc NoOC, oc.idmoneda, REPLACE(CONVERT(VARCHAR(MAX),(CAST(oc.total - oc.descuentos AS DECIMAL (18,2)))), '.', ',') total,ed.idestadodoc idEstadoDoc, ed.descripcion estadodoc from oc inner join empresas emp on emp.idempresa = oc.idempresav inner join empresas emp2 on emp2.idempresa = oc.idempresa inner join orgc orc on orc.idorgc = oc.idorgc inner join orgv orv on orv.idorgv = oc.idorgv inner join estadosdoc ed on oc.idestadodoc = ed.idestadodoc left join oclineas ocl on ocl.idoc = oc.idoc where convert(varchar(8),oc.fechaenvio,112) between '" + dato2 + "' and '" + dato4 + "' group by oc.idoc,oc.numoc,oc.idempresav,rutorgv,emp.nombempresa,emp2.nombempresa,orc.nombre,oc.nomoc, oc.fechaenvio,ed.descripcion,oc.idmoneda,emp2.idempresa,orc.idorgc,emp.idempresa, orv.idorgv,orv.nombre,oc.total,oc.descuentos,ed.idestadodoc order by oc.fechaenvio"), conectar);
                DataTable data = new DataTable();
                da.Fill(data);
                listaoc.DataSource = data;
                label10.Text = "Total Registros " + data.Rows.Count.ToString();
                label10.Show();
                imagencargar.Visible = false;
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            ocultarlista3();
        }

        private async void btestadosoc_Click(object sender, EventArgs e)
        {
            Task oTask = new Task(imagen_load);
            listaoc.DataSource = null;
            listaoc.Refresh();
            int numvisi = Convert.ToInt32(visibilidad_prove.SelectedIndex);
            //string estadooctodos = radiooctodos.Text;
            if (listaempreoc.Text == "")
            {
                MessageBox.Show("Porfavor seleccione la empresa");
            }
            else if (fechainioc.Text == "")
            {
                MessageBox.Show("Porfavor seleccione la fecha");
            }
            else if (fechafinaloc.Text == "")
            {
                MessageBox.Show("Porfavor seleccione la fecha");
            }
            else if (visibilidad_prove.Text == "")
            {
                MessageBox.Show("Porfavor seleccione Visibilidad de proveedor");
            }
            else if (estadooc.Text == "")
            {
                MessageBox.Show("Porfavor seleccione el estado de la OC");
            }
            else if(numvisi != 4 & check_estados_todo.Checked == false & check_todas_empre.Checked == false) 
            {
                label10.Hide();
                imagencargar.Visible = true;
                oTask.Start();
                await oTask;
                DateTime date1 = new DateTime(fechainioc.Value.Year, fechainioc.Value.Month, fechainioc.Value.Day);
                string dato2 = (date1.ToString("yyyyMMdd", CultureInfo.InvariantCulture));
                DateTime date3 = new DateTime(fechafinaloc.Value.Year, fechafinaloc.Value.Month, fechafinaloc.Value.Day);
                string dato4 = (date3.ToString("yyyyMMdd", CultureInfo.InvariantCulture));
                string idempre = listaempreoc.SelectedValue.ToString();
                string idestadoc = estadooc.SelectedValue.ToString();
                SqlDataAdapter da = new SqlDataAdapter(String.Format("SELECT oc.idoc idoc,emp2.idempresa idEmpresaCompradora,emp2.nombempresa EmpresaCompradora,orc.idorgc idOrgCompra,orc.nombre nombreOrgCompra,emp.idempresa idEmpresaProveedora,emp.nombempresa EmpresaProveedora,razo.RUT Nit,CASE WHEN orv.ESINTEGRADO = 0 THEN 'INTEGRADO' WHEN  orv.ESINTEGRADO = 1 THEN 'NO INTEGRADO' ELSE 'NO DEFINIDO' END as VISIBILIDAD,CASE WHEN emp.ELIMINADO = 1 THEN 'Eliminado' ELSE 'Activo' END as EstadoProveedor,orv.idorgv idSucursalVenta,orv.nombre SucursalVenta,conta.NOMCONTACTO 'Contacto',conta.EMAIL 'CorreoContacto',conta.TELEFONO 'Telefono',Conta.MOVIL 'Celular',dire.DIRECCION1 direccion,COMUNA.NOMCOMUNA ciudad,oc.fechaenvio fechaenvio,oc.numoc NoOC,oc.idmoneda moneda,REPLACE(CONVERT(VARCHAR(MAX),(CAST(oc.total - oc.descuentos AS DECIMAL (18,2)))), '.', ',') total,ed.idestadodoc idEstadoDoc,ed.descripcion estadodoc from oc inner join empresas emp on emp.idempresa = oc.idempresav inner join empresas emp2 on emp2.idempresa = oc.idempresa inner join orgc orc on orc.idorgc = oc.idorgc inner join orgv orv on orv.idorgv = oc.idorgv inner join estadosdoc ed on oc.idestadodoc = ed.idestadodoc left join oclineas ocl on ocl.idoc = oc.idoc inner join ORGVCONTACTO orgvcon on orgvcon.IDORGV = orv.IDORGV inner join CONTACTOS conta on conta.IDCONTACTO = orgvcon.IDCONTACTO inner join ORGVDIRECCION orgdi on orgdi.IDORGV = OC.IDORGV inner join DIRECCION dire on dire.IDDIRECCION = orgdi.IDDIRECCION inner join COMUNA on COMUNA.IDCOMUNA = dire.IDCOMUNA inner join RAZONSOCIAL razo on razo.IDEMPRESA = emp.IDEMPRESA where convert(varchar(8),oc.fechaenvio,112) between '" + dato2 + "' and '" + dato4 + "' and emp2.IDEMPRESA = '"+ idempre +"' and ed.IDESTADODOC  = '"+ idestadoc + "'  and orv.ESINTEGRADO = '"+ numvisi + "' group by oc.idoc,oc.numoc,oc.idempresav,rutorgv,emp.nombempresa,emp2.nombempresa,orc.nombre,oc.nomoc,oc.fechaenvio,ed.descripcion,oc.idmoneda,emp2.idempresa,orc.idorgc,emp.idempresa,orv.idorgv,orv.nombre,oc.total,oc.descuentos,ed.idestadodoc,conta.NOMCONTACTO,conta.EMAIL,conta.TELEFONO,conta.LOCALCONTACTO,conta.MOVIL,dire.DIRECCION1,COMUNA.NOMCOMUNA,emp.VISIBILIDAD,emp.ELIMINADO,razo.RUT, orv.ESINTEGRADO order by oc.fechaenvio"), conectar);
                DataTable data = new DataTable();
                da.Fill(data);
                listaoc.DataSource = data;
                label10.Text = "Total Registros "+ data.Rows.Count.ToString();
                label10.Show();
                imagencargar.Visible = false;
            }
            else if(numvisi == 4 & check_estados_todo.Checked == false & check_todas_empre.Checked == false)
            {
                label10.Hide();
                imagencargar.Visible = true;
                oTask.Start();
                await oTask;
                imagencargar.Visible = true;
                DateTime date1 = new DateTime(fechainioc.Value.Year, fechainioc.Value.Month, fechainioc.Value.Day);
                string dato2 = (date1.ToString("yyyyMMdd", CultureInfo.InvariantCulture));
                DateTime date3 = new DateTime(fechafinaloc.Value.Year, fechafinaloc.Value.Month, fechafinaloc.Value.Day);
                string dato4 = (date3.ToString("yyyyMMdd", CultureInfo.InvariantCulture));
                string idempre = listaempreoc.SelectedValue.ToString();
                string idestadoc = estadooc.SelectedValue.ToString();
                SqlDataAdapter da = new SqlDataAdapter(String.Format("SELECT oc.idoc idoc,emp2.idempresa idEmpresaCompradora,emp2.nombempresa EmpresaCompradora,orc.idorgc idOrgCompra,orc.nombre nombreOrgCompra,emp.idempresa idEmpresaProveedora,emp.nombempresa EmpresaProveedora,razo.RUT Nit,CASE WHEN orv.ESINTEGRADO = 0 THEN 'INTEGRADO' WHEN  orv.ESINTEGRADO = 1 THEN 'NO INTEGRADO' ELSE 'NO DEFINIDO' END as VISIBILIDAD,CASE WHEN emp.ELIMINADO = 1 THEN 'Eliminado' ELSE 'Activo' END as EstadoProveedor,orv.idorgv idSucursalVenta,orv.nombre SucursalVenta,conta.NOMCONTACTO 'Contacto',conta.EMAIL 'CorreoContacto',conta.TELEFONO 'Telefono',Conta.MOVIL 'Celular',dire.DIRECCION1 direccion,COMUNA.NOMCOMUNA ciudad,oc.fechaenvio fechaenvio,oc.numoc NoOC,oc.idmoneda moneda,REPLACE(CONVERT(VARCHAR(MAX),(CAST(oc.total - oc.descuentos AS DECIMAL (18,2)))), '.', ',') total,ed.idestadodoc idEstadoDoc,ed.descripcion estadodoc from oc inner join empresas emp on emp.idempresa = oc.idempresav inner join empresas emp2 on emp2.idempresa = oc.idempresa inner join orgc orc on orc.idorgc = oc.idorgc inner join orgv orv on orv.idorgv = oc.idorgv inner join estadosdoc ed on oc.idestadodoc = ed.idestadodoc left join oclineas ocl on ocl.idoc = oc.idoc inner join ORGVCONTACTO orgvcon on orgvcon.IDORGV = orv.IDORGV inner join CONTACTOS conta on conta.IDCONTACTO = orgvcon.IDCONTACTO inner join ORGVDIRECCION orgdi on orgdi.IDORGV = OC.IDORGV inner join DIRECCION dire on dire.IDDIRECCION = orgdi.IDDIRECCION inner join COMUNA on COMUNA.IDCOMUNA = dire.IDCOMUNA inner join RAZONSOCIAL razo on razo.IDEMPRESA = emp.IDEMPRESA where convert(varchar(8),oc.fechaenvio,112) between '" + dato2 + "' and '" + dato4 + "' and emp2.IDEMPRESA = '" + idempre + "' and ed.IDESTADODOC = '" + idestadoc + "' group by oc.idoc,oc.numoc,oc.idempresav,rutorgv,emp.nombempresa,emp2.nombempresa,orc.nombre,oc.nomoc,oc.fechaenvio,ed.descripcion,oc.idmoneda,emp2.idempresa,orc.idorgc,emp.idempresa,orv.idorgv,orv.nombre,oc.total,oc.descuentos,ed.idestadodoc,conta.NOMCONTACTO,conta.EMAIL,conta.TELEFONO,conta.LOCALCONTACTO,conta.MOVIL,dire.DIRECCION1,COMUNA.NOMCOMUNA,emp.VISIBILIDAD,emp.ELIMINADO,razo.RUT, orv.ESINTEGRADO order by oc.fechaenvio"), conectar);
                DataTable data = new DataTable();
                da.Fill(data);
                listaoc.DataSource = data;
                label10.Text = "Total Registros " + data.Rows.Count.ToString();
                label10.Show();
                imagencargar.Visible = false;
            }
            else if (numvisi != 4 & check_estados_todo.Checked == true & check_todas_empre.Checked == false)
            {
                label10.Hide();
                imagencargar.Visible = true;
                oTask.Start();
                await oTask;
                imagencargar.Visible = true;
                DateTime date1 = new DateTime(fechainioc.Value.Year, fechainioc.Value.Month, fechainioc.Value.Day);
                string dato2 = (date1.ToString("yyyyMMdd", CultureInfo.InvariantCulture));
                DateTime date3 = new DateTime(fechafinaloc.Value.Year, fechafinaloc.Value.Month, fechafinaloc.Value.Day);
                string dato4 = (date3.ToString("yyyyMMdd", CultureInfo.InvariantCulture));
                string idempre = listaempreoc.SelectedValue.ToString();
                SqlDataAdapter da = new SqlDataAdapter(String.Format("SELECT oc.idoc idoc,emp2.idempresa idEmpresaCompradora,emp2.nombempresa EmpresaCompradora,orc.idorgc idOrgCompra,orc.nombre nombreOrgCompra,emp.idempresa idEmpresaProveedora,emp.nombempresa EmpresaProveedora,razo.RUT Nit,CASE WHEN orv.ESINTEGRADO = 0 THEN 'INTEGRADO' WHEN  orv.ESINTEGRADO = 1 THEN 'NO INTEGRADO' ELSE 'NO DEFINIDO' END as VISIBILIDAD,CASE WHEN emp.ELIMINADO = 1 THEN 'Eliminado' ELSE 'Activo' END as EstadoProveedor,orv.idorgv idSucursalVenta,orv.nombre SucursalVenta,conta.NOMCONTACTO 'Contacto',conta.EMAIL 'CorreoContacto',conta.TELEFONO 'Telefono',Conta.MOVIL 'Celular',dire.DIRECCION1 direccion,COMUNA.NOMCOMUNA ciudad,oc.fechaenvio fechaenvio,oc.numoc NoOC,oc.idmoneda moneda,REPLACE(CONVERT(VARCHAR(MAX),(CAST(oc.total - oc.descuentos AS DECIMAL (18,2)))), '.', ',') total,ed.idestadodoc idEstadoDoc,ed.descripcion estadodoc from oc inner join empresas emp on emp.idempresa = oc.idempresav inner join empresas emp2 on emp2.idempresa = oc.idempresa inner join orgc orc on orc.idorgc = oc.idorgc inner join orgv orv on orv.idorgv = oc.idorgv inner join estadosdoc ed on oc.idestadodoc = ed.idestadodoc left join oclineas ocl on ocl.idoc = oc.idoc inner join ORGVCONTACTO orgvcon on orgvcon.IDORGV = orv.IDORGV inner join CONTACTOS conta on conta.IDCONTACTO = orgvcon.IDCONTACTO inner join ORGVDIRECCION orgdi on orgdi.IDORGV = OC.IDORGV inner join DIRECCION dire on dire.IDDIRECCION = orgdi.IDDIRECCION inner join COMUNA on COMUNA.IDCOMUNA = dire.IDCOMUNA inner join RAZONSOCIAL razo on razo.IDEMPRESA = emp.IDEMPRESA where convert(varchar(8),oc.fechaenvio,112) between '" + dato2 + "' and '" + dato4 + "' and emp2.IDEMPRESA = '" + idempre + "' and orv.ESINTEGRADO = '" + numvisi + "' group by oc.idoc,oc.numoc,oc.idempresav,rutorgv,emp.nombempresa,emp2.nombempresa,orc.nombre,oc.nomoc,oc.fechaenvio,ed.descripcion,oc.idmoneda,emp2.idempresa,orc.idorgc,emp.idempresa,orv.idorgv,orv.nombre,oc.total,oc.descuentos,ed.idestadodoc,conta.NOMCONTACTO,conta.EMAIL,conta.TELEFONO,conta.LOCALCONTACTO,conta.MOVIL,dire.DIRECCION1,COMUNA.NOMCOMUNA,emp.VISIBILIDAD,emp.ELIMINADO,razo.RUT, orv.ESINTEGRADO order by oc.fechaenvio"), conectar);
                DataTable data = new DataTable();
                da.Fill(data);
                listaoc.DataSource = data;
                check_estados_todo.Checked = false;
                check_todas_empre.Checked = false;
                label10.Text = "Total Registros " + data.Rows.Count.ToString();
                label10.Show();
                imagencargar.Visible = false;
            }
            else if (numvisi == 4 & check_estados_todo.Checked == true & check_todas_empre.Checked == false)
            {
                label10.Hide();
                imagencargar.Visible = true;
                oTask.Start();
                await oTask;
                imagencargar.Visible = true;
                DateTime date1 = new DateTime(fechainioc.Value.Year, fechainioc.Value.Month, fechainioc.Value.Day);
                string dato2 = (date1.ToString("yyyyMMdd", CultureInfo.InvariantCulture));
                DateTime date3 = new DateTime(fechafinaloc.Value.Year, fechafinaloc.Value.Month, fechafinaloc.Value.Day);
                string dato4 = (date3.ToString("yyyyMMdd", CultureInfo.InvariantCulture));
                string idempre = listaempreoc.SelectedValue.ToString();
                SqlDataAdapter da = new SqlDataAdapter(String.Format("SELECT oc.idoc idoc,emp2.idempresa idEmpresaCompradora,emp2.nombempresa EmpresaCompradora,orc.idorgc idOrgCompra,orc.nombre nombreOrgCompra,emp.idempresa idEmpresaProveedora,emp.nombempresa EmpresaProveedora,razo.RUT Nit,CASE WHEN orv.ESINTEGRADO = 0 THEN 'INTEGRADO' WHEN  orv.ESINTEGRADO = 1 THEN 'NO INTEGRADO' ELSE 'NO DEFINIDO' END as VISIBILIDAD,CASE WHEN emp.ELIMINADO = 1 THEN 'Eliminado' ELSE 'Activo' END as EstadoProveedor,orv.idorgv idSucursalVenta,orv.nombre SucursalVenta,conta.NOMCONTACTO 'Contacto',conta.EMAIL 'CorreoContacto',conta.TELEFONO 'Telefono',Conta.MOVIL 'Celular',dire.DIRECCION1 direccion,COMUNA.NOMCOMUNA ciudad,oc.fechaenvio fechaenvio,oc.numoc NoOC,oc.idmoneda moneda,REPLACE(CONVERT(VARCHAR(MAX),(CAST(oc.total - oc.descuentos AS DECIMAL (18,2)))), '.', ',') total,ed.idestadodoc idEstadoDoc,ed.descripcion estadodoc from oc inner join empresas emp on emp.idempresa = oc.idempresav inner join empresas emp2 on emp2.idempresa = oc.idempresa inner join orgc orc on orc.idorgc = oc.idorgc inner join orgv orv on orv.idorgv = oc.idorgv inner join estadosdoc ed on oc.idestadodoc = ed.idestadodoc left join oclineas ocl on ocl.idoc = oc.idoc inner join ORGVCONTACTO orgvcon on orgvcon.IDORGV = orv.IDORGV inner join CONTACTOS conta on conta.IDCONTACTO = orgvcon.IDCONTACTO inner join ORGVDIRECCION orgdi on orgdi.IDORGV = OC.IDORGV inner join DIRECCION dire on dire.IDDIRECCION = orgdi.IDDIRECCION inner join COMUNA on COMUNA.IDCOMUNA = dire.IDCOMUNA inner join RAZONSOCIAL razo on razo.IDEMPRESA = emp.IDEMPRESA where convert(varchar(8),oc.fechaenvio,112) between '" + dato2 + "' and '" + dato4 + "' and emp2.IDEMPRESA = '" + idempre + "' group by oc.idoc,oc.numoc,oc.idempresav,rutorgv,emp.nombempresa,emp2.nombempresa,orc.nombre,oc.nomoc,oc.fechaenvio,ed.descripcion,oc.idmoneda,emp2.idempresa,orc.idorgc,emp.idempresa,orv.idorgv,orv.nombre,oc.total,oc.descuentos,ed.idestadodoc,conta.NOMCONTACTO,conta.EMAIL,conta.TELEFONO,conta.LOCALCONTACTO,conta.MOVIL,dire.DIRECCION1,COMUNA.NOMCOMUNA,emp.VISIBILIDAD,emp.ELIMINADO,razo.RUT, orv.ESINTEGRADO order by oc.fechaenvio"), conectar);
                DataTable data = new DataTable();
                da.Fill(data);
                listaoc.DataSource = data;
                check_estados_todo.Checked = false;
                check_todas_empre.Checked = false;
                label10.Text = "Total Registros " + data.Rows.Count.ToString();
                label10.Show();
                imagencargar.Visible = false;
            }
            else if (numvisi == 4 & check_estados_todo.Checked == true & check_todas_empre.Checked == true)
            {
                label10.Hide();
                imagencargar.Visible = true;
                oTask.Start();
                await oTask;
                DateTime date1 = new DateTime(fechainioc.Value.Year, fechainioc.Value.Month, fechainioc.Value.Day);
                string dato2 = (date1.ToString("yyyyMMdd", CultureInfo.InvariantCulture));
                DateTime date3 = new DateTime(fechafinaloc.Value.Year, fechafinaloc.Value.Month, fechafinaloc.Value.Day);
                string dato4 = (date3.ToString("yyyyMMdd", CultureInfo.InvariantCulture));
                SqlDataAdapter da = new SqlDataAdapter(String.Format("SELECT oc.idoc idoc,emp2.idempresa idEmpresaCompradora,emp2.nombempresa EmpresaCompradora,orc.idorgc idOrgCompra,orc.nombre nombreOrgCompra,emp.idempresa idEmpresaProveedora,emp.nombempresa EmpresaProveedora,razo.RUT Nit,CASE WHEN orv.ESINTEGRADO = 0 THEN 'INTEGRADO' WHEN  orv.ESINTEGRADO = 1 THEN 'NO INTEGRADO' ELSE 'NO DEFINIDO' END as VISIBILIDAD,CASE WHEN emp.ELIMINADO = 1 THEN 'Eliminado' ELSE 'Activo' END as EstadoProveedor,orv.idorgv idSucursalVenta,orv.nombre SucursalVenta,conta.NOMCONTACTO 'Contacto',conta.EMAIL 'CorreoContacto',conta.TELEFONO 'Telefono',Conta.MOVIL 'Celular',dire.DIRECCION1 direccion,COMUNA.NOMCOMUNA ciudad,oc.fechaenvio fechaenvio,oc.numoc NoOC,oc.idmoneda moneda,REPLACE(CONVERT(VARCHAR(MAX),(CAST(oc.total - oc.descuentos AS DECIMAL (18,2)))), '.', ',') total,ed.idestadodoc idEstadoDoc,ed.descripcion estadodoc from oc inner join empresas emp on emp.idempresa = oc.idempresav inner join empresas emp2 on emp2.idempresa = oc.idempresa inner join orgc orc on orc.idorgc = oc.idorgc inner join orgv orv on orv.idorgv = oc.idorgv inner join estadosdoc ed on oc.idestadodoc = ed.idestadodoc left join oclineas ocl on ocl.idoc = oc.idoc inner join ORGVCONTACTO orgvcon on orgvcon.IDORGV = orv.IDORGV inner join CONTACTOS conta on conta.IDCONTACTO = orgvcon.IDCONTACTO inner join ORGVDIRECCION orgdi on orgdi.IDORGV = OC.IDORGV inner join DIRECCION dire on dire.IDDIRECCION = orgdi.IDDIRECCION inner join COMUNA on COMUNA.IDCOMUNA = dire.IDCOMUNA inner join RAZONSOCIAL razo on razo.IDEMPRESA = emp.IDEMPRESA where convert(varchar(8),oc.fechaenvio,112) between '" + dato2 + "' and '" + dato4 + "' group by oc.idoc,oc.numoc,oc.idempresav,rutorgv,emp.nombempresa,emp2.nombempresa,orc.nombre,oc.nomoc,oc.fechaenvio,ed.descripcion,oc.idmoneda,emp2.idempresa,orc.idorgc,emp.idempresa,orv.idorgv,orv.nombre,oc.total,oc.descuentos,ed.idestadodoc,conta.NOMCONTACTO,conta.EMAIL,conta.TELEFONO,conta.LOCALCONTACTO,conta.MOVIL,dire.DIRECCION1,COMUNA.NOMCOMUNA,emp.VISIBILIDAD,emp.ELIMINADO,razo.RUT, orv.ESINTEGRADO order by oc.fechaenvio"), conectar);
                DataTable data = new DataTable();
                da.Fill(data);
                listaoc.DataSource = data;
                check_estados_todo.Checked = false;
                check_todas_empre.Checked = false;
                label10.Text = "Total Registros " + data.Rows.Count.ToString();
                label10.Show();
                imagencargar.Visible = false;
            }
            else if (numvisi != 4 & check_estados_todo.Checked == true & check_todas_empre.Checked == true)
            {
                label10.Hide();
                imagencargar.Visible = true;
                oTask.Start();
                await oTask;
                DateTime date1 = new DateTime(fechainioc.Value.Year, fechainioc.Value.Month, fechainioc.Value.Day);
                string dato2 = (date1.ToString("yyyyMMdd", CultureInfo.InvariantCulture));
                DateTime date3 = new DateTime(fechafinaloc.Value.Year, fechafinaloc.Value.Month, fechafinaloc.Value.Day);
                string dato4 = (date3.ToString("yyyyMMdd", CultureInfo.InvariantCulture));
                SqlDataAdapter da = new SqlDataAdapter(String.Format("SELECT oc.idoc idoc,emp2.idempresa idEmpresaCompradora,emp2.nombempresa EmpresaCompradora,orc.idorgc idOrgCompra,orc.nombre nombreOrgCompra,emp.idempresa idEmpresaProveedora,emp.nombempresa EmpresaProveedora,razo.RUT Nit,CASE WHEN orv.ESINTEGRADO = 0 THEN 'INTEGRADO' WHEN  orv.ESINTEGRADO = 1 THEN 'NO INTEGRADO' ELSE 'NO DEFINIDO' END as VISIBILIDAD,CASE WHEN emp.ELIMINADO = 1 THEN 'Eliminado' ELSE 'Activo' END as EstadoProveedor,orv.idorgv idSucursalVenta,orv.nombre SucursalVenta,conta.NOMCONTACTO 'Contacto',conta.EMAIL 'CorreoContacto',conta.TELEFONO 'Telefono',Conta.MOVIL 'Celular',dire.DIRECCION1 direccion,COMUNA.NOMCOMUNA ciudad,oc.fechaenvio fechaenvio,oc.numoc NoOC,oc.idmoneda moneda,REPLACE(CONVERT(VARCHAR(MAX),(CAST(oc.total - oc.descuentos AS DECIMAL (18,2)))), '.', ',') total,ed.idestadodoc idEstadoDoc,ed.descripcion estadodoc from oc inner join empresas emp on emp.idempresa = oc.idempresav inner join empresas emp2 on emp2.idempresa = oc.idempresa inner join orgc orc on orc.idorgc = oc.idorgc inner join orgv orv on orv.idorgv = oc.idorgv inner join estadosdoc ed on oc.idestadodoc = ed.idestadodoc left join oclineas ocl on ocl.idoc = oc.idoc inner join ORGVCONTACTO orgvcon on orgvcon.IDORGV = orv.IDORGV inner join CONTACTOS conta on conta.IDCONTACTO = orgvcon.IDCONTACTO inner join ORGVDIRECCION orgdi on orgdi.IDORGV = OC.IDORGV inner join DIRECCION dire on dire.IDDIRECCION = orgdi.IDDIRECCION inner join COMUNA on COMUNA.IDCOMUNA = dire.IDCOMUNA inner join RAZONSOCIAL razo on razo.IDEMPRESA = emp.IDEMPRESA where convert(varchar(8),oc.fechaenvio,112) between '" + dato2 + "' and '" + dato4 + "' and orv.ESINTEGRADO = '" + numvisi + "' group by oc.idoc,oc.numoc,oc.idempresav,rutorgv,emp.nombempresa,emp2.nombempresa,orc.nombre,oc.nomoc,oc.fechaenvio,ed.descripcion,oc.idmoneda,emp2.idempresa,orc.idorgc,emp.idempresa,orv.idorgv,orv.nombre,oc.total,oc.descuentos,ed.idestadodoc,conta.NOMCONTACTO,conta.EMAIL,conta.TELEFONO,conta.LOCALCONTACTO,conta.MOVIL,dire.DIRECCION1,COMUNA.NOMCOMUNA,emp.VISIBILIDAD,emp.ELIMINADO,razo.RUT, orv.ESINTEGRADO order by oc.fechaenvio"), conectar);
                DataTable data = new DataTable();
                da.Fill(data);
                listaoc.DataSource = data;
                check_estados_todo.Checked = false;
                check_todas_empre.Checked = false;
                label10.Text = "Total Registros " + data.Rows.Count.ToString();
                label10.Show();
                imagencargar.Visible = false;
            }
            else if (numvisi == 4 & check_estados_todo.Checked == false & check_todas_empre.Checked == true)
            {
                label10.Hide();
                imagencargar.Visible = true;
                oTask.Start();
                await oTask;
                DateTime date1 = new DateTime(fechainioc.Value.Year, fechainioc.Value.Month, fechainioc.Value.Day);
                string dato2 = (date1.ToString("yyyyMMdd", CultureInfo.InvariantCulture));
                DateTime date3 = new DateTime(fechafinaloc.Value.Year, fechafinaloc.Value.Month, fechafinaloc.Value.Day);
                string dato4 = (date3.ToString("yyyyMMdd", CultureInfo.InvariantCulture));
                string idestadoc = estadooc.SelectedValue.ToString();
                SqlDataAdapter da = new SqlDataAdapter(String.Format("SELECT oc.idoc idoc,emp2.idempresa idEmpresaCompradora,emp2.nombempresa EmpresaCompradora,orc.idorgc idOrgCompra,orc.nombre nombreOrgCompra,emp.idempresa idEmpresaProveedora,emp.nombempresa EmpresaProveedora,razo.RUT Nit,CASE WHEN orv.ESINTEGRADO = 0 THEN 'INTEGRADO' WHEN  orv.ESINTEGRADO = 1 THEN 'NO INTEGRADO' ELSE 'NO DEFINIDO' END as VISIBILIDAD,CASE WHEN emp.ELIMINADO = 1 THEN 'Eliminado' ELSE 'Activo' END as EstadoProveedor,orv.idorgv idSucursalVenta,orv.nombre SucursalVenta,conta.NOMCONTACTO 'Contacto',conta.EMAIL 'CorreoContacto',conta.TELEFONO 'Telefono',Conta.MOVIL 'Celular',dire.DIRECCION1 direccion,COMUNA.NOMCOMUNA ciudad,oc.fechaenvio fechaenvio,oc.numoc NoOC,oc.idmoneda moneda,REPLACE(CONVERT(VARCHAR(MAX),(CAST(oc.total - oc.descuentos AS DECIMAL (18,2)))), '.', ',') total,ed.idestadodoc idEstadoDoc,ed.descripcion estadodoc from oc inner join empresas emp on emp.idempresa = oc.idempresav inner join empresas emp2 on emp2.idempresa = oc.idempresa inner join orgc orc on orc.idorgc = oc.idorgc inner join orgv orv on orv.idorgv = oc.idorgv inner join estadosdoc ed on oc.idestadodoc = ed.idestadodoc left join oclineas ocl on ocl.idoc = oc.idoc inner join ORGVCONTACTO orgvcon on orgvcon.IDORGV = orv.IDORGV inner join CONTACTOS conta on conta.IDCONTACTO = orgvcon.IDCONTACTO inner join ORGVDIRECCION orgdi on orgdi.IDORGV = OC.IDORGV inner join DIRECCION dire on dire.IDDIRECCION = orgdi.IDDIRECCION inner join COMUNA on COMUNA.IDCOMUNA = dire.IDCOMUNA inner join RAZONSOCIAL razo on razo.IDEMPRESA = emp.IDEMPRESA where convert(varchar(8),oc.fechaenvio,112) between '" + dato2 + "' and '" + dato4 + "' and orv.ESINTEGRADO = '" + numvisi + "' and ed.IDESTADODOC = '" + idestadoc + "' group by oc.idoc,oc.numoc,oc.idempresav,rutorgv,emp.nombempresa,emp2.nombempresa,orc.nombre,oc.nomoc,oc.fechaenvio,ed.descripcion,oc.idmoneda,emp2.idempresa,orc.idorgc,emp.idempresa,orv.idorgv,orv.nombre,oc.total,oc.descuentos,ed.idestadodoc,conta.NOMCONTACTO,conta.EMAIL,conta.TELEFONO,conta.LOCALCONTACTO,conta.MOVIL,dire.DIRECCION1,COMUNA.NOMCOMUNA,emp.VISIBILIDAD,emp.ELIMINADO,razo.RUT, orv.ESINTEGRADO order by oc.fechaenvio"), conectar);
                DataTable data = new DataTable();
                da.Fill(data);
                listaoc.DataSource = data;
                check_estados_todo.Checked = false; // Desativa la casilla que corresponde a estados
                check_todas_empre.Checked = false;
                label10.Text = "Total Registros " + data.Rows.Count.ToString();// Para hacer conteo de las columnas en el datagriew
                label10.Show();
                imagencargar.Visible = false;
            }
        }

        private void check_todas_empre_CheckedChanged(object sender, EventArgs e)
        {
            label4.Show();
            listaempreoc.Hide();

            if(check_todas_empre.Checked == false)
            {
                label4.Hide();
                listaempreoc.Show();
            }
        }

        private void check_estados_todo_CheckedChanged(object sender, EventArgs e)
        {
            label7.Show();
            estadooc.Hide();

            if(check_estados_todo.Checked == false)
            {
                label7.Hide();
                estadooc.Show();
            }
        }
    }
}