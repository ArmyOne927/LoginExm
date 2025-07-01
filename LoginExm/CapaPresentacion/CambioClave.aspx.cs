using System;
using Capa_Negocio;

namespace LoginExm.CapaPresentacion
{
    public partial class CambioClave : System.Web.UI.Page
    {
        private CN_Usuarios cnUsuarios = new CN_Usuarios();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Validar que haya una sesión activa con el ID
                if (Session["id"] == null)
                {
                    Response.Redirect("Login.aspx");
                }
            }
        }

        protected void btnCambiar_Click(object sender, EventArgs e)
        {
            if (txtNuevaClave.Text != txtConfirmarClave.Text)
            {
                lblMensaje.Text = "Las contraseñas no coinciden.";
                return;
            }

            int idUsuario = Convert.ToInt32(Session["id"]);
            bool resultado = cnUsuarios.CambiarClave(idUsuario, txtNuevaClave.Text);

            if (resultado)
            {
                lblMensaje.Text = "Clave actualizada correctamente.";
                // Puedes redirigirlo si deseas
                Response.Redirect("Login.aspx");
            }
            else
            {
                lblMensaje.Text = "Error al actualizar la clave.";
            }
        }
    }
}
