using System;
using Capa_Negocio;
using System.Data;

namespace LoginExm.CapaPresentacion
{
    public partial class DocenteMenu : System.Web.UI.Page
    {
        private CN_Usuarios cnUsuarios = new CN_Usuarios();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["usuario"] != null && Session["tipo"] != null && Session["id"] != null)
                {
                    string nombre = Session["usuario"].ToString();
                    string perfil = Session["tipo"].ToString();
                    int idUsuario = Convert.ToInt32(Session["id"]);

                    lblBienvenida.Text = $"Bienvenido al sistema {nombre} – {perfil}";

                    DataRow detalles = cnUsuarios.ObtenerDetallesUsuario(idUsuario);

                    if (detalles != null)
                    {
                        string fechaNacimiento = Convert.ToDateTime(detalles["usu_fechanacimiento"]).ToString("dd/MM/yyyy");
                        string signo = detalles["usu_signozodiacal"].ToString();
                        int edadMeses = Convert.ToInt32(detalles["usu_edadmeses"]);
                        string clasificacionEdad = detalles["usu_clasificacionxedad"].ToString();

                        lblDatos.Text = $"Fecha de nacimiento: {fechaNacimiento} <br />" +
                                        $"Signo zodiacal: {signo} <br />" +
                                        $"Edad en meses: {edadMeses} <br />" +
                                        $"Clasificación: {clasificacionEdad}";
                    }
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
            }
        }
    }
}
