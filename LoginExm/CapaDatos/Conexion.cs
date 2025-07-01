using System.Data;
using System.Data.SqlClient;

namespace Capa_Datos
{
    public class CD_Conexion
    {
        private readonly string connectionString = @"Data Source=ARMYONE-LAPTOP;Initial Catalog=BD_FacturacionAvanzada; Integrated Security=True;Encrypt=False";

        private SqlConnection cn;

        public CD_Conexion()
        {
            cn = new SqlConnection(connectionString); // ✅ Esto previene el error
        }

        public SqlConnection abrir_conexion()
        {
            if (cn.State == ConnectionState.Closed)
            {
                cn.Open();
            }
            return cn;
        }

        public SqlConnection cerrar_conexion()
        {
            if (cn.State == ConnectionState.Open)
            {
                cn.Close();
            }
            return cn;
        }
    }
}
