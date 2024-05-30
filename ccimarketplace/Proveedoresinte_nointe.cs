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
    public partial class Proveedoresinte_nointe : Form
    {
        SqlConnection conectar = ConexionBD.obtenerconexion();
        void ocultarlista()
        {
            listaempreprove.Hide();
            label1.Hide();
            tbconsultaprove.Hide();
        }

        void ocultarlista2()
        {
            listaempreprove.Show();
            label3.Hide();
            tbconsultaprove.Show();
            btconsultatodas.Hide();
            label1.Show();
        }

        public void imagen_load()
        {
            Thread.Sleep(3000);
        }
        public Proveedoresinte_nointe()
        {
            InitializeComponent();
        }

        private void Proveedoresinte_nointe_Load(object sender, EventArgs e)
        {
            listaempreprove.DropDownStyle = ComboBoxStyle.DropDownList;
            label3.Hide();
            imagencargar.Hide();
            label10.Hide();
            label11.Hide();
            cubocargar.Hide();
            btconsultatodas.Hide();
            {
                string query = "SELECT * from EMPRESAS where IDTIPOEMPRESA = 1 AND ELIMINADO = 0 and NOMBFANTASIA <> '' order by NOMBFANTASIA";

                SqlCommand cmd = new SqlCommand(query, conectar);
                SqlDataAdapter da1 = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da1.Fill(dt);
                listaempreprove.ValueMember = "IDEMPRESA";
                listaempreprove.DisplayMember = "NOMBEMPRESA";
                listaempreprove.DataSource = dt;
            }
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

        private async void tbconsultaprove_Click(object sender, EventArgs e)
        {
            Task oTask = new Task(imagen_load);
            listaprovinte.DataSource = null;
            listaprovinte.Refresh();
            if (listaempreprove.Text == "")
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
                string idempre = listaempreprove.SelectedValue.ToString();
                SqlDataAdapter da = new SqlDataAdapter(String.Format("SELECT DISTINCT EMPRESAS.IDEMPRESA empresa,razon.RUT nit,CASE WHEN EMPRESAS.ELIMINADO = 1 THEN 'Eliminado' ELSE 'Activo' END as EstadoProveedor,EMPRESAS.NOMBEMPRESA nomempre, EMPRESAS.NOMBFANTASIA emprefan, EMPRESAS.IDTIPOEMPRESA tipoempre, EMPRESAS_1.IDEMPRESA AS Expr1, EMPRESAS_1.NOMBEMPRESA AS Expr2,  USUARIOS.IDUSUARIO usuario,USUARIOS.UBICACION ubicacion, USUARIOS.NOMBRE nomusu, USUARIOS.FECHACREACION creacionusuario, EMPRESAS.FECHACREACION creacionempre, CONTACTOS.IDEMPRESA AS Expr3,  CONTACTOS.NOMCONTACTO nomconta, CONTACTOS.TELEFONO teleconta, CONTACTOS.MOVIL conmovil, CONTACTOS.FAX contfax, CONTACTOS.EMAIL contaemail, CONTACTOS.ACTIVO contactivo, CONTACTOS.ELIMINADO contaeliminado, CONTACTOS.FECHACREACION fechacreacion FROM EMPRESAS AS EMPRESAS_1 INNER JOIN EMPRESASB2B ON EMPRESAS_1.IDEMPRESA = EMPRESASB2B.IDEMPRESAC INNER JOIN EMPRESAS ON EMPRESASB2B.IDEMPRESAV = EMPRESAS.IDEMPRESA INNER JOIN USUARIOS ON EMPRESASB2B.IDEMPRESAV = USUARIOS.IDEMPRESA LEFT OUTER JOIN CONTACTOS ON EMPRESAS.IDEMPRESA = CONTACTOS.IDEMPRESA inner join RAZONSOCIAL razon on razon.IDEMPRESA = EMPRESAS.IDEMPRESA WHERE EMPRESAS_1.IDEMPRESA = " + idempre + " and (EMPRESAS.IDTIPOEMPRESA = 2) AND (convert(varchar(8),EMPRESAS.FECHACREACION,112) BETWEEN '" + dato2 + "' and '" + dato4 + "' ) AND (USUARIOS.IDUSUARIO <> 'operaciones') AND (USUARIOS.IDUSUARIO <> 'SISTEMA') AND (USUARIOS.IDUSUARIO <> 'Admin')"), conectar);
                DataTable data = new DataTable();
                da.Fill(data);
                listaprovinte.DataSource = data;
                label10.Text = "Total Registros " + data.Rows.Count.ToString();
                label10.Show();
                imagencargar.Visible = false;
            }
        }

        private async void btconsultatodas_Click(object sender, EventArgs e)
        {
            Task oTask = new Task(imagen_load);
            listaprovinte.DataSource = null;
            listaprovinte.Refresh();
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
                SqlDataAdapter da = new SqlDataAdapter(String.Format("SELECT DISTINCT EMPRESAS.IDEMPRESA empresa,razon.RUT nit,CASE WHEN EMPRESAS.ELIMINADO = 1 THEN 'Eliminado' ELSE 'Activo' END as EstadoProveedor,EMPRESAS.NOMBEMPRESA nomempre, EMPRESAS.NOMBFANTASIA emprefan, EMPRESAS.IDTIPOEMPRESA tipoempre, EMPRESAS_1.IDEMPRESA AS Expr1, EMPRESAS_1.NOMBEMPRESA AS Expr2,  USUARIOS.IDUSUARIO usuario,USUARIOS.UBICACION ubicacion, USUARIOS.NOMBRE nomusu, USUARIOS.FECHACREACION creacionusuario, EMPRESAS.FECHACREACION creacionempre, CONTACTOS.IDEMPRESA AS Expr3,  CONTACTOS.NOMCONTACTO nomconta, CONTACTOS.TELEFONO teleconta, CONTACTOS.MOVIL conmovil, CONTACTOS.FAX contfax, CONTACTOS.EMAIL contaemail, CONTACTOS.ACTIVO contactivo, CONTACTOS.ELIMINADO contaeliminado, CONTACTOS.FECHACREACION fechacreacion FROM EMPRESAS AS EMPRESAS_1 INNER JOIN EMPRESASB2B ON EMPRESAS_1.IDEMPRESA = EMPRESASB2B.IDEMPRESAC INNER JOIN EMPRESAS ON EMPRESASB2B.IDEMPRESAV = EMPRESAS.IDEMPRESA INNER JOIN USUARIOS ON EMPRESASB2B.IDEMPRESAV = USUARIOS.IDEMPRESA LEFT OUTER JOIN CONTACTOS ON EMPRESAS.IDEMPRESA = CONTACTOS.IDEMPRESA inner join RAZONSOCIAL razon on razon.IDEMPRESA = EMPRESAS.IDEMPRESA WHERE (EMPRESAS.IDTIPOEMPRESA = 2) AND (convert(varchar(8),EMPRESAS.FECHACREACION,112) BETWEEN '" + dato2 + "' and '" + dato4 + "' ) AND (USUARIOS.IDUSUARIO <> 'operaciones') AND (USUARIOS.IDUSUARIO <> 'SISTEMA') AND (USUARIOS.IDUSUARIO <> 'Admin')"), conectar);
                DataTable data = new DataTable();
                da.Fill(data);
                listaprovinte.DataSource = data;
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
            new exportar().exportaraexcel(listaprovinte);
            cubocargar.Visible = false;
            label11.Hide();
        }

        private void tbsalirmate_Click(object sender, EventArgs e)
        {
            Form1 inicio = new Form1();
            inicio.Show();
            this.Hide();
        }
    }
}
