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
using System.Threading;
using System.Globalization;

namespace ccimarketplace
{
    public partial class facturacion : Form
    {
        SqlConnection conectar = ConexionBD.obtenerconexion();
        Model model = new Model();

        void consultageneral()
        {
            generalboton.Show();
            label1.Hide();
            Listaempresas.Hide();
            label3.Hide();
            listadescripcion.Hide();
            button2.Hide();
            soloenvios.Hide();
            allempresas.Hide();
            allenvios.Hide();
            label5.Show();
            label4.Hide();
            label6.Hide();
            label7.Hide();
            button4.Hide();
            label8.Show();
            label10.Hide();
            label9.Hide();
            label11.Hide();
        }

        void todaslasempresas()
        {
            generalboton.Hide();
            label1.Hide();
            Listaempresas.Hide();
            label3.Show();
            listadescripcion.Show();
            button2.Hide();
            soloenvios.Hide();
            allempresas.Show();
            allenvios.Hide();
            label5.Hide();
            label4.Show();
            label6.Hide();
            label7.Hide();
            button4.Hide();
            label8.Hide();
            label9.Hide();
            label10.Hide();
            label11.Show();
        }
        void enviadasgeneral()
        {
            generalboton.Hide();
            label1.Show();
            Listaempresas.Show();
            label3.Hide();
            listadescripcion.Hide();
            button2.Hide();
            soloenvios.Show();
            allempresas.Hide();
            allenvios.Hide();
            label5.Hide();
            label4.Hide();
            label6.Show();
            label7.Hide();
            button4.Hide();
            label8.Hide();
            label9.Hide();
            label10.Show();
            label11.Hide();
        }
        void porempresa()
        {
            generalboton.Hide();
            label1.Show();
            Listaempresas.Show();
            label3.Hide();
            listadescripcion.Hide();
            button2.Hide();
            soloenvios.Hide();
            allempresas.Hide();
            allenvios.Hide();
            label5.Hide();
            label4.Hide();
            label6.Hide();
            label7.Show();
            button4.Show();
            label8.Hide();
            label9.Hide();
            label10.Hide();
            label11.Hide();
        }
        void enviosall()
        {
            generalboton.Hide();
            label1.Hide();
            Listaempresas.Hide();
            label3.Hide();
            listadescripcion.Hide();
            button2.Hide();
            soloenvios.Hide();
            allempresas.Hide();
            allenvios.Hide();
            label5.Hide();
            label4.Hide();
            label6.Hide();
            label7.Hide();
            button4.Hide();
            label8.Hide();
            label9.Hide();
            label10.Hide();
            label11.Hide();
        }

        void individual()
        {
            generalboton.Hide();
            label1.Show();
            Listaempresas.Show();
            label3.Show();
            listadescripcion.Show();
            button2.Show();
            soloenvios.Hide();
            allempresas.Hide();
            allenvios.Hide();
            label5.Hide();
            label4.Hide();
            label6.Hide();
            label7.Show();
            button4.Hide();
            label8.Hide();
            label9.Show();
            label10.Hide();
            label11.Hide();
        }
        public void imagen_load()
        {
            Thread.Sleep(3000);
        }
        public facturacion()
        {
            InitializeComponent();
        }

        private void facturacion_Load(object sender, EventArgs e)
        {
            Listaempresas.DropDownStyle = ComboBoxStyle.DropDownList;
            listadescripcion.DropDownStyle = ComboBoxStyle.DropDownList;
            imagencargar.Hide();
            label4.Hide();
            label5.Hide();
            soloenvios.Hide();
            allempresas.Hide();
            generalboton.Hide();
            allenvios.Hide();
            label6.Hide();
            radioButton4.Hide();
            label8.Hide();
            label9.Hide();
            label10.Hide();
            label11.Hide();
            label10.Hide();
            label11.Hide();
            label14.Hide();
            label15.Hide();
            cubocargar.Hide();
            using (SqlConnection conectar = ConexionBD.obtenerconexion())
            {
                string query = "SELECT * from EMPRESAS where IDTIPOEMPRESA = 1 AND ELIMINADO = 0 and NOMBFANTASIA <> '' order by NOMBFANTASIA";

                SqlCommand cmd = new SqlCommand(query, conectar);
                SqlDataAdapter da1 = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da1.Fill(dt);
                Listaempresas.ValueMember = "IDEMPRESA";
                Listaempresas.DisplayMember = "NOMBEMPRESA";
                Listaempresas.DataSource = dt;

                string query2 = "select * from estadosdoc order by DESCRIPCION";

                SqlCommand cmd2 = new SqlCommand(query2, conectar);
                SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
                DataTable dt2 = new DataTable();
                da2.Fill(dt2);
                listadescripcion.ValueMember = "DESCRIPCION";
                listadescripcion.DisplayMember = "DESCRIPCION";
                listadescripcion.DataSource = dt2;
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            Task oTask = new Task(imagen_load);
            tbfacturacion.DataSource = null;
            tbfacturacion.Refresh();
            if (Listaempresas.Text == "" ) 
            {
                MessageBox.Show("Porfavor seleccione la empresa");
            }
            else if (fechainicio.Text == "")
            {
                MessageBox.Show("Porfavor seleccione la fecha");
            }
            else if (fechafinal.Text == "")
            {
                MessageBox.Show("Porfavor seleccione la fecha");
            }
            else if (listadescripcion.Text == "")
            {
                MessageBox.Show("Porfavor seleccione la descripcion del envio");
            }
            else
            {
                label15.Hide();
                imagencargar.Visible = true;
                oTask.Start();
                await oTask;
                string fecha = fechainicio.Value.Year + "" + fechainicio.Value.Month + "" + fechainicio.Value.Day;
                string idempre = Listaempresas.SelectedValue.ToString();
                string descripcion = listadescripcion.SelectedValue.ToString();
                SqlDataAdapter da = new SqlDataAdapter(String.Format("select oc.idoc,emp2.idempresa idEmpresaCompradora,emp2.nombempresa EmpresaCompradora,orc.idorgc idOrgCompra,orc.nombre nombreOrgCompra,emp.idempresa idEmpresaProveedora,emp.nombempresa EmpresaProveedora,orv.idorgv idSucursalVenta,orv.nombre SucursalVenta,conta.NOMCONTACTO 'Contacto',conta.EMAIL 'Correo Contacto',conta.TELEFONO 'Telefono contacto',Conta.MOVIL 'Celular',dire.DIRECCION1,COMUNA.NOMCOMUNA,oc.fechaenvio,oc.numoc NoOC,oc.idmoneda,REPLACE(CONVERT(VARCHAR(MAX),(CAST(oc.total - oc.descuentos AS DECIMAL (18,2)))), '.', ',') total,ed.idestadodoc idEstadoDoc,ed.descripcion estadodoc from oc inner join empresas emp on emp.idempresa = oc.idempresav inner join empresas emp2 on emp2.idempresa = oc.idempresa inner join orgc orc on orc.idorgc = oc.idorgc inner join orgv orv on orv.idorgv = oc.idorgv inner join estadosdoc ed on oc.idestadodoc = ed.idestadodoc left join oclineas ocl on ocl.idoc = oc.idoc inner join ORGVCONTACTO orgvcon on orgvcon.IDORGV = orv.IDORGV inner join CONTACTOS conta on conta.IDCONTACTO = orgvcon.IDCONTACTO inner join ORGVDIRECCION orgdi on orgdi.IDORGV = OC.IDEMPRESAV inner join DIRECCION dire on dire.IDDIRECCION = orgdi.IDDIRECCION inner join COMUNA on COMUNA.IDCOMUNA = dire.IDCOMUNA where convert(varchar(8), oc.fechaenvio, 112) >= '" + fecha + "' AND emp2.IDEMPRESA = " + idempre + " and ed.descripcion = '" + descripcion + "' group by oc.idoc,oc.numoc,oc.idempresav,rutorgv,emp.nombempresa,emp2.nombempresa,orc.nombre,oc.nomoc,oc.fechaenvio,ed.descripcion,oc.idmoneda,emp2.idempresa,orc.idorgc,emp.idempresa,orv.idorgv,orv.nombre,oc.total,oc.descuentos,ed.idestadodoc,conta.NOMCONTACTO,conta.EMAIL,conta.TELEFONO,conta.LOCALCONTACTO,conta.MOVIL,dire.DIRECCION1,COMUNA.NOMCOMUNA order by oc.fechaenvio"), conectar);
                DataTable data = new DataTable();
                da.Fill(data);
                tbfacturacion.DataSource = data;
                label15.Text = "Total Registros " + data.Rows.Count.ToString();
                label15.Show();
                imagencargar.Visible = false;
            }
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            //exportar ex = new exportar();
            //ex.exportarexcel(tbfacturacion);
            Task oTask = new Task(imagen_load);
            label14.Show();
            cubocargar.Visible = true;
            oTask.Start();
            await oTask;
            new exportar().exportaraexcel(tbfacturacion);
            cubocargar.Visible = false;
            label14.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 inicio = new Form1();
            inicio.Show();
            this.Hide();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            consultageneral();
        }

        private async void generalboton_Click(object sender, EventArgs e)
        {
            Task oTask = new Task(imagen_load);
            tbfacturacion.DataSource = null;
            tbfacturacion.Refresh();
            if (fechainicio.Text == "")
            {
                MessageBox.Show("Porfavor seleccione la fecha");
            }
            if (fechafinal.Text == "")
            {
                MessageBox.Show("Porfavor seleccione la fecha");
            }
            else
            {
                label15.Hide();
                imagencargar.Visible = true;
                oTask.Start();
                await oTask;
                DateTime date1 = new DateTime(fechainicio.Value.Year, fechainicio.Value.Month, fechainicio.Value.Day);
                string dato2 = (date1.ToString("yyyyMMdd", CultureInfo.InvariantCulture));
                DateTime date3 = new DateTime(fechafinal.Value.Year, fechafinal.Value.Month, fechafinal.Value.Day);
                string dato4 = (date3.ToString("yyyyMMdd", CultureInfo.InvariantCulture));
                SqlDataAdapter da = new SqlDataAdapter(String.Format("select oc.idoc,emp2.idempresa idEmpresaCompradora,emp2.nombempresa EmpresaCompradora,orc.idorgc idOrgCompra,orc.nombre nombreOrgCompra,emp.idempresa idEmpresaProveedora,emp.nombempresa EmpresaProveedora,orv.idorgv idSucursalVenta,orv.nombre SucursalVenta,conta.NOMCONTACTO 'Contacto',conta.EMAIL 'Correo Contacto',conta.TELEFONO 'Telefono contacto',Conta.MOVIL 'Celular',dire.DIRECCION1,COMUNA.NOMCOMUNA,oc.fechaenvio,oc.numoc NoOC,oc.idmoneda,REPLACE(CONVERT(VARCHAR(MAX),(CAST(oc.total - oc.descuentos AS DECIMAL (18,2)))), '.', ',') total,ed.idestadodoc idEstadoDoc,ed.descripcion estadodoc from oc inner join empresas emp on emp.idempresa = oc.idempresav inner join empresas emp2 on emp2.idempresa = oc.idempresa inner join orgc orc on orc.idorgc = oc.idorgc inner join orgv orv on orv.idorgv = oc.idorgv inner join estadosdoc ed on oc.idestadodoc = ed.idestadodoc left join oclineas ocl on ocl.idoc = oc.idoc inner join ORGVCONTACTO orgvcon on orgvcon.IDORGV = orv.IDORGV inner join CONTACTOS conta on conta.IDCONTACTO = orgvcon.IDCONTACTO inner join ORGVDIRECCION orgdi on orgdi.IDORGV = OC.IDEMPRESAV inner join DIRECCION dire on dire.IDDIRECCION = orgdi.IDDIRECCION inner join COMUNA on COMUNA.IDCOMUNA = dire.IDCOMUNA where convert(varchar(8), oc.fechaenvio, 112) between '" + dato2 + "' and '" + dato4 + "' group by oc.idoc,oc.numoc,oc.idempresav,rutorgv,emp.nombempresa,emp2.nombempresa,orc.nombre,oc.nomoc,oc.fechaenvio,ed.descripcion,oc.idmoneda,emp2.idempresa,orc.idorgc,emp.idempresa,orv.idorgv,orv.nombre,oc.total,oc.descuentos,ed.idestadodoc,conta.NOMCONTACTO,conta.EMAIL,conta.TELEFONO,conta.LOCALCONTACTO,conta.MOVIL,dire.DIRECCION1,COMUNA.NOMCOMUNA order by oc.fechaenvio"), conectar);
                DataTable data = new DataTable();
                da.Fill(data);
                tbfacturacion.DataSource = data;
                label15.Text = "Total Registros " + data.Rows.Count.ToString();
                label15.Show();
                imagencargar.Visible = false;
            }
        }

        private async void soloenvios_Click(object sender, EventArgs e)
        {
            Task oTask = new Task(imagen_load);
            tbfacturacion.DataSource = null;
            tbfacturacion.Refresh();
            if (Listaempresas.Text == "")
            {
                MessageBox.Show("Porfavor seleccione la empresa");
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
                label15.Hide();
                imagencargar.Visible = true;
                oTask.Start();
                await oTask;
                DateTime date1 = new DateTime(fechainicio.Value.Year, fechainicio.Value.Month, fechainicio.Value.Day);
                string dato2 = (date1.ToString("yyyyMMdd", CultureInfo.InvariantCulture));
                DateTime date3 = new DateTime(fechafinal.Value.Year, fechafinal.Value.Month, fechafinal.Value.Day);
                string dato4 = (date3.ToString("yyyyMMdd", CultureInfo.InvariantCulture));
                string idempre = Listaempresas.SelectedValue.ToString();            
                SqlDataAdapter da = new SqlDataAdapter(String.Format("select oc.idoc,emp2.idempresa idEmpresaCompradora,emp2.nombempresa EmpresaCompradora,orc.idorgc idOrgCompra,orc.nombre nombreOrgCompra,emp.idempresa idEmpresaProveedora,emp.nombempresa EmpresaProveedora,orv.idorgv idSucursalVenta,orv.nombre SucursalVenta,conta.NOMCONTACTO 'Contacto',conta.EMAIL 'Correo Contacto',conta.TELEFONO 'Telefono contacto',Conta.MOVIL 'Celular',dire.DIRECCION1,COMUNA.NOMCOMUNA,oc.fechaenvio,oc.numoc NoOC,oc.idmoneda,REPLACE(CONVERT(VARCHAR(MAX),(CAST(oc.total - oc.descuentos AS DECIMAL (18,2)))), '.', ',') total,ed.idestadodoc idEstadoDoc,ed.descripcion estadodoc from oc inner join empresas emp on emp.idempresa = oc.idempresav inner join empresas emp2 on emp2.idempresa = oc.idempresa inner join orgc orc on orc.idorgc = oc.idorgc inner join orgv orv on orv.idorgv = oc.idorgv inner join estadosdoc ed on oc.idestadodoc = ed.idestadodoc left join oclineas ocl on ocl.idoc = oc.idoc inner join ORGVCONTACTO orgvcon on orgvcon.IDORGV = orv.IDORGV inner join CONTACTOS conta on conta.IDCONTACTO = orgvcon.IDCONTACTO inner join ORGVDIRECCION orgdi on orgdi.IDORGV = OC.IDEMPRESAV inner join DIRECCION dire on dire.IDDIRECCION = orgdi.IDDIRECCION inner join COMUNA on COMUNA.IDCOMUNA = dire.IDCOMUNA where convert(varchar(8), oc.fechaenvio, 112) between '" + dato2 + "' and '" + dato4 + "' AND emp2.IDEMPRESA = " + idempre + " group by oc.idoc,oc.numoc,oc.idempresav,rutorgv,emp.nombempresa,emp2.nombempresa,orc.nombre,oc.nomoc,oc.fechaenvio,ed.descripcion,oc.idmoneda,emp2.idempresa,orc.idorgc,emp.idempresa,orv.idorgv,orv.nombre,oc.total,oc.descuentos,ed.idestadodoc,conta.NOMCONTACTO,conta.EMAIL,conta.TELEFONO,conta.LOCALCONTACTO,conta.MOVIL,dire.DIRECCION1,COMUNA.NOMCOMUNA order by oc.fechaenvio"), conectar);
                DataTable data = new DataTable();
                da.Fill(data);
                tbfacturacion.DataSource = data;
                label15.Text = "Total Registros " + data.Rows.Count.ToString();
                label15.Show();
                imagencargar.Visible = false;
            }
        }

        private async void allempresas_Click(object sender, EventArgs e)
        {
            Task oTask = new Task(imagen_load);
            tbfacturacion.DataSource = null;
            tbfacturacion.Refresh();
            if (fechainicio.Text == "")
            {
                MessageBox.Show("Porfavor seleccione la fecha");
            }
            if (fechafinal.Text == "")
            {
                MessageBox.Show("Porfavor seleccione la fecha");
            }
            else if (listadescripcion.Text == "")
            {
                MessageBox.Show("Porfavor seleccione la descripcion del envio");
            }
            else
            {
                label15.Hide();
                imagencargar.Visible = true;
                oTask.Start();
                await oTask;
                DateTime date1 = new DateTime(fechainicio.Value.Year, fechainicio.Value.Month, fechainicio.Value.Day);
                string dato2 = (date1.ToString("yyyyMMdd", CultureInfo.InvariantCulture));
                DateTime date3 = new DateTime(fechafinal.Value.Year, fechafinal.Value.Month, fechafinal.Value.Day);
                string dato4 = (date3.ToString("yyyyMMdd", CultureInfo.InvariantCulture));
                string descripcion = listadescripcion.SelectedValue.ToString();
                SqlDataAdapter da = new SqlDataAdapter(String.Format("select oc.idoc,emp2.idempresa idEmpresaCompradora,emp2.nombempresa EmpresaCompradora,orc.idorgc idOrgCompra,orc.nombre nombreOrgCompra,emp.idempresa idEmpresaProveedora,emp.nombempresa EmpresaProveedora,orv.idorgv idSucursalVenta,orv.nombre SucursalVenta,conta.NOMCONTACTO 'Contacto',conta.EMAIL 'Correo Contacto',conta.TELEFONO 'Telefono contacto',Conta.MOVIL 'Celular',dire.DIRECCION1,COMUNA.NOMCOMUNA,oc.fechaenvio,oc.numoc NoOC,oc.idmoneda,REPLACE(CONVERT(VARCHAR(MAX),(CAST(oc.total - oc.descuentos AS DECIMAL (18,2)))), '.', ',') total,ed.idestadodoc idEstadoDoc,ed.descripcion estadodoc from oc inner join empresas emp on emp.idempresa = oc.idempresav inner join empresas emp2 on emp2.idempresa = oc.idempresa inner join orgc orc on orc.idorgc = oc.idorgc inner join orgv orv on orv.idorgv = oc.idorgv inner join estadosdoc ed on oc.idestadodoc = ed.idestadodoc left join oclineas ocl on ocl.idoc = oc.idoc inner join ORGVCONTACTO orgvcon on orgvcon.IDORGV = orv.IDORGV inner join CONTACTOS conta on conta.IDCONTACTO = orgvcon.IDCONTACTO inner join ORGVDIRECCION orgdi on orgdi.IDORGV = OC.IDEMPRESAV inner join DIRECCION dire on dire.IDDIRECCION = orgdi.IDDIRECCION inner join COMUNA on COMUNA.IDCOMUNA = dire.IDCOMUNA where convert(varchar(8), oc.fechaenvio, 112) between '" + dato2 + "' and '" + dato4 + "' and ed.descripcion = '" + descripcion + "' group by oc.idoc,oc.numoc,oc.idempresav,rutorgv,emp.nombempresa,emp2.nombempresa,orc.nombre,oc.nomoc,oc.fechaenvio,ed.descripcion,oc.idmoneda,emp2.idempresa,orc.idorgc,emp.idempresa,orv.idorgv,orv.nombre,oc.total,oc.descuentos,ed.idestadodoc,conta.NOMCONTACTO,conta.EMAIL,conta.TELEFONO,conta.LOCALCONTACTO,conta.MOVIL,dire.DIRECCION1,COMUNA.NOMCOMUNA order by oc.fechaenvio"), conectar);
                DataTable data = new DataTable();
                da.Fill(data);
                tbfacturacion.DataSource = data;
                label15.Text = "Total Registros " + data.Rows.Count.ToString();
                label15.Show();
                imagencargar.Visible = false;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            todaslasempresas();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            enviadasgeneral();
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            porempresa();
        }

        private async void allenvios_Click(object sender, EventArgs e)
        {
            Task oTask = new Task(imagen_load);
            tbfacturacion.DataSource = null;
            tbfacturacion.Refresh();
            if (fechainicio.Text == "")
            {
                MessageBox.Show("Porfavor seleccione la fecha");
            }
            else
            {
                label15.Hide();
                imagencargar.Visible = true;
                oTask.Start();
                await oTask;
                DateTime date1 = new DateTime(fechainicio.Value.Year, fechainicio.Value.Month, fechainicio.Value.Day);
                string dato2 = (date1.ToString("yyyyMMdd", CultureInfo.InvariantCulture));
                DateTime date3 = new DateTime(fechafinal.Value.Year, fechafinal.Value.Month, fechafinal.Value.Day);
                string dato4 = (date3.ToString("yyyyMMdd", CultureInfo.InvariantCulture));
                SqlDataAdapter da = new SqlDataAdapter(String.Format("select oc.idoc,emp2.idempresa idEmpresaCompradora,emp2.nombempresa EmpresaCompradora,orc.idorgc idOrgCompra,orc.nombre nombreOrgCompra,emp.idempresa idEmpresaProveedora,emp.nombempresa EmpresaProveedora,orv.idorgv idSucursalVenta,orv.nombre SucursalVenta,conta.NOMCONTACTO 'Contacto',conta.EMAIL 'Correo Contacto',conta.TELEFONO 'Telefono contacto',Conta.MOVIL 'Celular',dire.DIRECCION1,COMUNA.NOMCOMUNA,oc.fechaenvio,oc.numoc NoOC,oc.idmoneda,REPLACE(CONVERT(VARCHAR(MAX),(CAST(oc.total - oc.descuentos AS DECIMAL (18,2)))), '.', ',') total,ed.idestadodoc idEstadoDoc,ed.descripcion estadodoc from oc inner join empresas emp on emp.idempresa = oc.idempresav inner join empresas emp2 on emp2.idempresa = oc.idempresa inner join orgc orc on orc.idorgc = oc.idorgc inner join orgv orv on orv.idorgv = oc.idorgv inner join estadosdoc ed on oc.idestadodoc = ed.idestadodoc left join oclineas ocl on ocl.idoc = oc.idoc inner join ORGVCONTACTO orgvcon on orgvcon.IDORGV = orv.IDORGV inner join CONTACTOS conta on conta.IDCONTACTO = orgvcon.IDCONTACTO inner join ORGVDIRECCION orgdi on orgdi.IDORGV = OC.IDEMPRESAV inner join DIRECCION dire on dire.IDDIRECCION = orgdi.IDDIRECCION inner join COMUNA on COMUNA.IDCOMUNA = dire.IDCOMUNA where convert(varchar(8), oc.fechaenvio, 112) between '" + dato2 + "' and '" + dato4 + "' group by oc.idoc,oc.numoc,oc.idempresav,rutorgv,emp.nombempresa,emp2.nombempresa,orc.nombre,oc.nomoc,oc.fechaenvio,ed.descripcion,oc.idmoneda,emp2.idempresa,orc.idorgc,emp.idempresa,orv.idorgv,orv.nombre,oc.total,oc.descuentos,ed.idestadodoc,conta.NOMCONTACTO,conta.EMAIL,conta.TELEFONO,conta.LOCALCONTACTO,conta.MOVIL,dire.DIRECCION1,COMUNA.NOMCOMUNA order by oc.fechaenvio"), conectar);
                DataTable data = new DataTable();
                da.Fill(data);
                tbfacturacion.DataSource = data;
                label15.Text = "Total Registros " + data.Rows.Count.ToString();
                label15.Show();
                imagencargar.Visible = false;
            } 
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            Task oTask = new Task(imagen_load);
            tbfacturacion.DataSource = null;
            tbfacturacion.Refresh();
            if (Listaempresas.Text == "")
            {
                MessageBox.Show("Porfavor seleccione la empresa");
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
                label15.Hide();
                imagencargar.Visible = true;
                oTask.Start();
                await oTask;
                DateTime date1 = new DateTime(fechainicio.Value.Year, fechainicio.Value.Month, fechainicio.Value.Day);
                string dato2 = (date1.ToString("yyyyMMdd", CultureInfo.InvariantCulture));
                DateTime date3 = new DateTime(fechafinal.Value.Year, fechafinal.Value.Month, fechafinal.Value.Day);
                string dato4 = (date3.ToString("yyyyMMdd", CultureInfo.InvariantCulture));
                string idempre = Listaempresas.SelectedValue.ToString();
                SqlDataAdapter da = new SqlDataAdapter(String.Format("select oc.idoc,emp2.idempresa idEmpresaCompradora,emp2.nombempresa EmpresaCompradora,orc.idorgc idOrgCompra,orc.nombre nombreOrgCompra,emp.idempresa idEmpresaProveedora,emp.nombempresa EmpresaProveedora,orv.idorgv idSucursalVenta,orv.nombre SucursalVenta,conta.NOMCONTACTO 'Contacto',conta.EMAIL 'Correo Contacto',conta.TELEFONO 'Telefono contacto',Conta.MOVIL 'Celular',dire.DIRECCION1,COMUNA.NOMCOMUNA,oc.fechaenvio,oc.numoc NoOC,oc.idmoneda,REPLACE(CONVERT(VARCHAR(MAX),(CAST(oc.total - oc.descuentos AS DECIMAL (18,2)))), '.', ',') total,ed.idestadodoc idEstadoDoc,ed.descripcion estadodoc from oc inner join empresas emp on emp.idempresa = oc.idempresav inner join empresas emp2 on emp2.idempresa = oc.idempresa inner join orgc orc on orc.idorgc = oc.idorgc inner join orgv orv on orv.idorgv = oc.idorgv inner join estadosdoc ed on oc.idestadodoc = ed.idestadodoc left join oclineas ocl on ocl.idoc = oc.idoc inner join ORGVCONTACTO orgvcon on orgvcon.IDORGV = orv.IDORGV inner join CONTACTOS conta on conta.IDCONTACTO = orgvcon.IDCONTACTO inner join ORGVDIRECCION orgdi on orgdi.IDORGV = OC.IDEMPRESAV inner join DIRECCION dire on dire.IDDIRECCION = orgdi.IDDIRECCION inner join COMUNA on COMUNA.IDCOMUNA = dire.IDCOMUNA where convert(varchar(8), oc.fechaenvio, 112) between '" + dato2 + "' and '" + dato4 + "' AND emp2.IDEMPRESA = " + idempre + " group by oc.idoc,oc.numoc,oc.idempresav,rutorgv,emp.nombempresa,emp2.nombempresa,orc.nombre,oc.nomoc,oc.fechaenvio,ed.descripcion,oc.idmoneda,emp2.idempresa,orc.idorgc,emp.idempresa,orv.idorgv,orv.nombre,oc.total,oc.descuentos,ed.idestadodoc,conta.NOMCONTACTO,conta.EMAIL,conta.TELEFONO,conta.LOCALCONTACTO,conta.MOVIL,dire.DIRECCION1,COMUNA.NOMCOMUNA order by oc.fechaenvio"), conectar);
                DataTable data = new DataTable();
                da.Fill(data);
                tbfacturacion.DataSource = data;
                label15.Text = "Total Registros " + data.Rows.Count.ToString();
                label15.Show();
                imagencargar.Visible = false;
            }
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            individual();
        }
    }
}
