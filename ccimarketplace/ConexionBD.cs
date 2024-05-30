using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ccimarketplace
{
    class ConexionBD
    {
        public static SqlConnection obtenerconexion()
        {
            SqlConnection conn = new SqlConnection(@"Data Source=172.30.5.14\BDCCI01;Initial Catalog=dbMarketplaceColombia;User ID=Usr_Consultas;Password=Acceso2017");
            try
            {
                conn.Open();
            }
            catch 
            {
                MessageBox.Show("Se ha presentado problemas de conexión con la base de datos,Por favor verificar si VPN se encuentra conectada", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            return conn;
        }
    }
}
