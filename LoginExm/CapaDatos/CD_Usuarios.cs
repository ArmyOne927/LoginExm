using System;
using System.Data;
using System.Data.SqlClient;

namespace Capa_Datos
{
    public class CD_Usuarios
    {
        private CD_Conexion conexion = new CD_Conexion();

        public DataRow ValidarLogin(string nick, byte[] claveHash)
        {
            using (SqlConnection con = conexion.abrir_conexion())
            {
                string query = @"
                    SELECT TOP 1 u.usu_id, u.usu_nombre,u.usu_estado, t.tpus_id, t.tpus_descripcion
                    FROM Tbl_Usuario u
                    INNER JOIN Tbl_TipoUsuario t ON u.usu_tpus_id = t.tpus_id
                    WHERE u.usu_nick = @Nick AND u.usu_clave = @Clave";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.Add("@Nick", SqlDbType.VarChar, 50).Value = nick;
                cmd.Parameters.Add("@Clave", SqlDbType.VarBinary, 64).Value = claveHash;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt.Rows.Count > 0 ? dt.Rows[0] : null;
            }
        }

        public bool ActualizarClaveTemporal(string nick, byte[] claveHash)
        {
            using (SqlConnection cn = conexion.abrir_conexion())
            {
                string query = @"UPDATE Tbl_Usuario SET usu_clave = @Clave, usu_estado = 'T' WHERE usu_nick = @Nick";

                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@Clave", claveHash);
                cmd.Parameters.AddWithValue("@Nick", nick);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool ActualizarClaveFinal(int id, byte[] claveHash)
        {
            using (SqlConnection cn = conexion.abrir_conexion())
            {
                string query = @"UPDATE Tbl_Usuario SET usu_clave = @Clave, usu_estado = 'A' WHERE usu_id = @Id";

                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@Clave", claveHash);
                cmd.Parameters.AddWithValue("@Id", id);

                return cmd.ExecuteNonQuery() > 0;
            }
        }



        public DataRow ObtenerDetallesUsuario(int id)
        {
            using (SqlConnection cn = conexion.abrir_conexion())
            {
                string query = @"
            SELECT usu_nombre, usu_fechanacimiento, usu_signozodiacal, usu_edadmeses, usu_clasificacionxedad, usu_nick
            FROM Tbl_Usuario 
            WHERE usu_id = @Id";

                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt.Rows.Count > 0 ? dt.Rows[0] : null;
                }
            }
        }


        public bool InsertarUsuario(string cedula, string nombre, string apellido, byte[] clave, DateTime fechaNacimiento, string signoZodiacal, int edadMeses, string clasificacionEdad, string nick, int tipoUsuarioId)
        {
            using (SqlConnection cn = conexion.abrir_conexion())
            {
                string query = @"
                    INSERT INTO Tbl_Usuario 
                    (usu_cedula, usu_nombre, usu_apellido, usu_clave, usu_fechanacimiento, usu_signozodiacal, usu_edadmeses, usu_clasificacionxedad, usu_nick, usu_fechaderegistro, usu_estado, usu_tpus_id)
                    VALUES 
                    (@Cedula, @Nombre, @Apellido, @Clave, @FechaNacimiento, @SignoZodiacal, @EdadMeses, @ClasificacionEdad, @Nick, GETDATE(), 'A', @TipoUsuarioId)";

                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@Cedula", cedula);
                cmd.Parameters.AddWithValue("@Nombre", nombre);
                cmd.Parameters.AddWithValue("@Apellido", apellido);
                cmd.Parameters.AddWithValue("@Clave", clave);
                cmd.Parameters.AddWithValue("@FechaNacimiento", fechaNacimiento);
                cmd.Parameters.AddWithValue("@SignoZodiacal", signoZodiacal);
                cmd.Parameters.AddWithValue("@EdadMeses", edadMeses);
                cmd.Parameters.AddWithValue("@ClasificacionEdad", clasificacionEdad);
                cmd.Parameters.AddWithValue("@Nick", nick);
                cmd.Parameters.AddWithValue("@TipoUsuarioId", tipoUsuarioId);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public DataTable ListarUsuarios()
        {
            using (SqlConnection cn = conexion.abrir_conexion())
            {
                string query = @"
                    SELECT u.usu_id, u.usu_cedula, u.usu_nombre, u.usu_apellido, u.usu_nick, t.tpus_descripcion
                    FROM Tbl_Usuario u
                    INNER JOIN Tbl_TipoUsuario t ON u.usu_tpus_id = t.tpus_id
                    WHERE u.usu_estado = 'A'";

                SqlCommand cmd = new SqlCommand(query, cn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public bool EliminarUsuario(int id)
        {
            using (SqlConnection cn = conexion.abrir_conexion())
            {
                string query = @"UPDATE Tbl_Usuario SET usu_estado = 'I' WHERE usu_id = @Id";
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@Id", id);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public DataRow ObtenerEstadoUsuario(int id)
        {
            using (SqlConnection cn = conexion.abrir_conexion())
            {
                string query = @"SELECT usu_estado FROM Tbl_Usuario WHERE usu_id = @Id";
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@Id", id);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt.Rows.Count > 0 ? dt.Rows[0] : null;
            }
        }

    }
}
