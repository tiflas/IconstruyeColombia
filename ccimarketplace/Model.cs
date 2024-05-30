using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;

namespace ccimarketplace
{
    class Model
    {
        public void cargarfacturacion(DataGridView dgv)
        {
            SqlConnection conectar = ConexionBD.obtenerconexion();            
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("Select oc.idoc,emp2.idempresa idEmpresaCompradora,emp2.nombempresa EmpresaCompradora,orc.idorgc idOrgCompra,orc.nombre nombreOrgCompra,emp.idempresa idEmpresaProveedora,emp.nombempresa EmpresaProveedora,orv.idorgv idSucursalVenta,orv.nombre SucursalVenta,oc.fechaenvio,oc.numoc NoOC,oc.idmoneda,REPLACE(CONVERT(VARCHAR(MAX), (CAST(oc.total - oc.descuentos AS DECIMAL(18, 2)))), '.', ',') total,ed.idestadodoc idEstadoDoc,ed.descripcion estadodoc from oc inner join empresas emp on emp.idempresa = oc.idempresav inner join empresas emp2 on emp2.idempresa = oc.idempresa inner join orgc orc on orc.idorgc = oc.idorgc inner join orgv orv on orv.idorgv = oc.idorgv inner join estadosdoc ed on oc.idestadodoc = ed.idestadodoc left join oclineas ocl on ocl.idoc = oc.idoc where convert(varchar(8), oc.fechaenvio, 112) between case when MONTH(DATEADD(M, -1, GETDATE())) < 12 then CONVERT(VARCHAR, YEAR(GETDATE())) + replicate('0', 2 - len(CONVERT(VARCHAR, MONTH(DATEADD(M, -1, GETDATE()))))) + CONVERT(VARCHAR, MONTH(DATEADD(M, -1, GETDATE()))) + '01' else CONVERT(VARCHAR, YEAR(DATEADD(m, -1, GETDATE()))) + replicate('0', 2 - len(CONVERT(VARCHAR, MONTH(DATEADD(M, -1, GETDATE()))))) + CONVERT(VARCHAR, MONTH(DATEADD(M, -1, GETDATE()))) + '01' end and CONVERT(VARCHAR, YEAR(GETDATE())) + replicate('0', 2 - len(convert(varchar, MONTH(GETDATE())))) + convert(varchar, MONTH(GETDATE())) + '01' group by oc.idoc, oc.numoc, oc.idempresav, rutorgv, emp.nombempresa, emp2.nombempresa, orc.nombre,oc.nomoc,oc.fechaenvio,ed.descripcion,oc.idmoneda,emp2.idempresa,orc.idorgc,emp.idempresa,orv.idorgv,orv.nombre,oc.total,oc.descuentos,ed.idestadodoc order by oc.fechaenvio", conectar);
                DataTable data = new DataTable();
                da.Fill(data);
                dgv.DataSource = data;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo llenar la lista: " + ex.ToString());

            }
        }       
    }
}
