using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Capa_Datos;
using Capa_Negocio;

namespace LoginExm.CapaPresentacion
{
    public partial class RegistroUsuarios : System.Web.UI.Page
    {
        private CN_Usuarios negocioUsuarios = new CN_Usuarios();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarTiposUsuarios();
            }

        }

        private void CargarTiposUsuarios()
        {
            CD_TipoUsuario datosTipoUsuario = new CD_TipoUsuario();
            DataTable dt = datosTipoUsuario.ListarTiposUsuarios();

            ddlTipoUsuario.DataSource = dt;
            ddlTipoUsuario.DataTextField = "tpus_descripcion";
            ddlTipoUsuario.DataValueField = "tpus_id";
            ddlTipoUsuario.DataBind();
            ddlTipoUsuario.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Seleccione--", "0"));
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (ddlTipoUsuario.SelectedIndex == 0)
            {
                lblMensaje.Text = "Seleccione un tipo de usuario.";
                return;
            }

            try
            {
                string nickGenerado = negocioUsuarios.RegistrarUsuario(
                    txtCedula.Text,
                    txtNombre.Text,
                    txtApellido.Text,
                    DateTime.Parse(txtFechaNacimiento.Text),
                    txtClave.Text,
                    int.Parse(ddlTipoUsuario.SelectedValue)
                );

                if (nickGenerado != null)
                {
                    lblMensaje.Text = "Registro exitoso. Su NickName de acceso es: <b>" + nickGenerado + "</b>. NO LO PIERDA.";
                }
                else
                {
                    lblMensaje.Text = "Error al registrar usuario.";
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = ex.Message;
            }
        }


    }
}

    