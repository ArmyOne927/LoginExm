using System;
using System.Data;
using System.Data.SqlClient;

namespace Capa_Datos
{
    public class CD_TipoUsuario
    {
        private CD_Conexion conexion = new CD_Conexion();
        public DataTable ListarTiposUsuarios()
        {
            using (SqlConnection cn = conexion.abrir_conexion())
            {
                string query = "SELECT tpus_id, tpus_descripcion FROM Tbl_TipoUsuario WHERE tpus_estado = 'A'";

                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
    }
}
