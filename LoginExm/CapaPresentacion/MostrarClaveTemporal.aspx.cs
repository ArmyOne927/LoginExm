using System;

namespace LoginExm.CapaPresentacion
{
    public partial class MostrarClaveTemporal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["ClaveTemporal"] != null)
                {
                    lblClaveTemporal.Text = Session["ClaveTemporal"].ToString();
                }
                else
                {
                    lblClaveTemporal.Text = "No hay clave generada.";
                }
            }
        }
    }
}
