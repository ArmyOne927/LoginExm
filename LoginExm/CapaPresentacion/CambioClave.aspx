<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CambioClave.aspx.cs" Inherits="LoginExm.CapaPresentacion.CambioClave" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Cambio de Clave</title>
    <style>
        body {
            background-color: #f0f5ff;
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
        }

        .container {
            max-width: 600px;
            margin: 80px auto;
            padding: 30px;
            background-color: #0d3b66;
            border-radius: 12px;
            box-shadow: 0 4px 12px rgba(0, 0, 0, 0.2);
            color: #ffffff;
        }

        h2 {
            text-align: center;
            color: #61a5c2;
            margin-bottom: 30px;
        }

        label {
            display: block;
            margin: 15px 0 5px 0;
            font-weight: bold;
            color: #d9e8f5;
        }

        input[type="password"] {
            width: 100%;
            padding: 12px;
            border: 1px solid #ccc;
            border-radius: 8px;
            font-size: 16px;
            margin-bottom: 15px;
        }

        .btn-primary {
            background-color: #1c5d99;
            color: #fff;
            border: none;
            padding: 12px 20px;
            font-size: 16px;
            border-radius: 8px;
            cursor: pointer;
            width: 100%;
        }

        .mensaje {
            margin-top: 20px;
            text-align: center;
            color: #ffd166;
            font-weight: bold;
            font-size: 16px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h2>Cambiar Contraseña</h2>

            <label for="txtNuevaClave">Nueva Contraseña:</label>
            <asp:TextBox ID="txtNuevaClave" runat="server" TextMode="Password" />

            <label for="txtConfirmarClave">Confirmar Contraseña:</label>
            <asp:TextBox ID="txtConfirmarClave" runat="server" TextMode="Password" />

            <asp:Button ID="btnCambiar" runat="server" Text="Cambiar Clave" OnClick="btnCambiar_Click" CssClass="btn-primary" />

            <asp:Label ID="lblMensaje" runat="server" CssClass="mensaje" />
        </div>
    </form>
</body>
</html>

