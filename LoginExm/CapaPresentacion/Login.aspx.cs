using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Capa_Negocio;

namespace LoginExm.CapaPresentacion
{
    public partial class Login : System.Web.UI.Page
    {
        CN_Usuarios cnUsuarios = new CN_Usuarios();
        protected void Page_Load(object sender, EventArgs e)
        {
            // Evitar que el navegador cachee esta página
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.UtcNow.AddSeconds(-1));
            Response.Cache.SetNoStore();
            Response.AppendHeader("Cache-Control", "no-store, no-cache, must-revalidate, private");
            Response.AppendHeader("Pragma", "no-cache");

            if (!IsPostBack)
            {
                Session.Clear();
                txtUsuario.Text = string.Empty;
                txtClave.Text = string.Empty;
            }
        }

        protected void lnkGenerarClaveTemporal_Click(object sender, EventArgs e)
        {
            string nick = txtUsuario.Text;

            if (string.IsNullOrEmpty(nick))
            {
                lblError.Text = "Ingrese su Nick para generar la clave temporal.";
                return;
            }

            CN_Usuarios cnUsuarios = new CN_Usuarios();

            string claveTemporal = cnUsuarios.GenerarClaveTemporal(nick);

            if (claveTemporal != null)
            {
                // Guardamos la clave temporal en sesión para mostrarla en la nueva vista
                Session["ClaveTemporal"] = claveTemporal;
                Response.Redirect("MostrarClaveTemporal.aspx");
            }
            else
            {
                lblError.Text = "No se pudo generar la clave temporal. Verifique el Nick.";
            }
        }



        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string nick = txtUsuario.Text.Trim();

            // Validación simple de campos vacíos
            if (string.IsNullOrEmpty(nick) || string.IsNullOrEmpty(txtClave.Text.Trim()))
            {
                lblError.Text = "Ingrese Nick y Contraseña.";
                return;
            }

            // Verificamos si está bloqueado
            if (Session[$"bloqueado_{nick}"] != null)
            {
                DateTime bloqueadoHasta = (DateTime)Session[$"bloqueado_{nick}"];

                if (DateTime.Now < bloqueadoHasta)
                {
                    TimeSpan restante = bloqueadoHasta - DateTime.Now;
                    lblError.Text = $"Usuario bloqueado. Espere {restante.Seconds} segundos antes de volver a intentar.";
                    return;
                }
                else
                {
                    Session[$"bloqueado_{nick}"] = null;
                    Session[$"intentos_{nick}"] = 0;
                }
            }

            int intentos = Session[$"intentos_{nick}"] != null ? (int)Session[$"intentos_{nick}"] : 0;

            // Validamos el login
            var usuario = cnUsuarios.ValidarLogin(nick, txtClave.Text.Trim());

            if (usuario != null)
            {
                string estado = usuario["usu_estado"].ToString();

                if (estado == "T")
                {
                    Session["id"] = usuario["usu_id"];
                    Response.Redirect("CambioClave.aspx");
                    return;
                }

                if (usuario != null)
                {
                    string estado2 = usuario["usu_estado"].ToString();
                    if (estado == "T")
                    {
                        Response.Redirect("CambioClave.aspx");
                        return;
                    }

                    // Si no está en estado temporal, continuamos normal:
                    string nombre = usuario["usu_nombre"].ToString();
                    string tipoUsuario = usuario["tpus_descripcion"].ToString(); // <- Aquí recuperamos la descripción para redirigir

                    Session["usuario"] = nombre;
                    Session["tipo"] = tipoUsuario;
                    Session["id"] = usuario["usu_id"];

                    // Reiniciamos intentos fallidos al loguearse correctamente
                    Session[$"intentos_{nick}"] = 0;

                    // Redireccionamos según el tipo de usuario:
                    if (tipoUsuario == "Docente")
                    {
                        Response.Redirect("DocenteMenu.aspx");
                    }
                    else if (tipoUsuario == "Representante")
                    {
                        Response.Redirect("RepresentanteMenu.aspx");
                    }
                    else if (tipoUsuario == "Estudiante")
                    {
                        Response.Redirect("EstudiantesMenu.aspx");
                    }
                    else
                    {
                        lblError.Text = "Tipo de usuario no reconocido.";
                    }
                }
                else
                {
                    intentos++;
                    Session[$"intentos_{nick}"] = intentos;

                    if (intentos >= 3)
                    {
                        Session[$"bloqueado_{nick}"] = DateTime.Now.AddSeconds(10);
                        lblError.Text = "Usuario bloqueado debido a múltiples intentos fallidos. Espere 10 segundos para volver a intentar.";
                    }
                    else
                    {
                        lblError.Text = $"Datos incorrectos. Intento #{intentos}";
                    }
                }

            }
        }
   



        protected void btnRegistrar_Click(object sender, EventArgs e)
        {

            Response.Redirect("~/CapaPresentacion/RegistroUsuarios.aspx");
        }
    }
}
