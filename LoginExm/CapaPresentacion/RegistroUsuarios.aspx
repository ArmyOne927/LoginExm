<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistroUsuarios.aspx.cs" Inherits="LoginExm.CapaPresentacion.RegistroUsuarios" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Registro de Usuarios</title>

    <style>
        .card {
            background-color: #fefefe;
            border-radius: 12px;
            box-shadow: 0 4px 10px rgba(0, 0, 0, 0.1);
            padding: 30px;
            max-width: 700px;
            margin: 0 auto 40px auto;
        }

        h2 {
            text-align: center;
            color: #6a1b9a;
            margin-bottom: 25px;
        }

        label {
            font-weight: bold;
            color: #4a148c;
            display: block;
            margin-top: 10px;
        }

        input[type="text"],
        input[type="password"],
        select {
            width: 100%;
            padding: 10px;
            margin-top: 5px;
            margin-bottom: 15px;
            border: 1px solid #ccc;
            border-radius: 6px;
        }

        .btn {
            margin-top: 10px;
            margin-right: 10px;
            padding: 8px 15px;
            border-radius: 6px;
            font-weight: bold;
        }

        .btn-primary {
            background-color: #6a1b9a;
            color: white;
            border: none;
        }

        .mensaje {
            margin-top: 15px;
            font-size: 14px;
            color: red;
        }
    </style>
</head>

<body>
    <form id="form1" runat="server">
        <div class="card">
            <h2>Registro de Usuario</h2>

            <asp:Label ID="lblMensaje" runat="server" CssClass="mensaje" />

            <label for="txtCedula">Cédula:</label>
            <asp:TextBox ID="txtCedula" runat="server" />

            <label for="txtNombre">Nombre:</label>
            <asp:TextBox ID="txtNombre" runat="server" />

            <label for="txtApellido">Apellido:</label>
            <asp:TextBox ID="txtApellido" runat="server" />

            <label for="txtFechaNacimiento">Fecha de Nacimiento:</label>
            <asp:TextBox ID="txtFechaNacimiento" runat="server" />

            <label for="txtClave">Contraseña:</label>
            <asp:TextBox ID="txtClave" runat="server" TextMode="Password" />

            <label for="ddlTipoUsuario">Tipo de Usuario:</label>
            <asp:DropDownList ID="ddlTipoUsuario" runat="server" />

            <asp:Button ID="btnRegistrar" runat="server" Text="Registrar" OnClick="btnRegistrar_Click" CssClass="btn btn-primary" />
        </div>
    </form>
</body>
</html>
