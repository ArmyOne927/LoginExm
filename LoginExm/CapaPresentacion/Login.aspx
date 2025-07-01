<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="LoginExm.CapaPresentacion.Login" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Iniciar Sesión</title>

    <!-- Evita que el navegador guarde copia en caché -->
    <meta http-equiv="Cache-Control" content="no-cache, no-store, must-revalidate" />
    <meta http-equiv="Pragma" content="no-cache" />
    <meta http-equiv="Expires" content="0" />

    <link href="<%= ResolveUrl("~/Styles/Estilos.css") %>" rel="stylesheet" type="text/css" />

</head>
<body>
    <form id="form1" runat="server">
        <h2>Iniciar Sesión</h2>

        <asp:Label ID="lblMensaje" runat="server" ForeColor="Red"></asp:Label><br />
        <br />

        Nick:
        <asp:TextBox ID="txtUsuario" runat="server" /><br />
        <br />
        Contraseña:
        <asp:TextBox ID="txtClave" runat="server" TextMode="Password" /><br />
        <asp:Label ID="lblError" runat="server" CssClass="error" />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnLogin" runat="server" Text="Ingresar" OnClick="btnLogin_Click" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

        <asp:Button ID="btnRegistrar" runat="server" Text="Registrarse" OnClick="btnRegistrar_Click" />
        <br />
        <asp:LinkButton ID="lnkGenerarClaveTemporal" runat="server" OnClick="lnkGenerarClaveTemporal_Click" CssClass="btn-link">
    ¿Olvidó su contraseña? Generar clave temporal
        </asp:LinkButton>

    </form>
</body>
</html>
