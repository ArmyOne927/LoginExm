<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MostrarClaveTemporal.aspx.cs" Inherits="LoginExm.CapaPresentacion.MostrarClaveTemporal" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Clave Temporal</title>
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
            text-align: center;
        }

        h2 {
            color: #61a5c2;
            margin-bottom: 20px;
        }

        .clave {
            font-size: 26px;
            font-weight: bold;
            color: #ffd166;
            margin: 20px 0;
        }

        .btn {
            background-color: #1c5d99;
            color: white;
            padding: 12px 20px;
            font-size: 16px;
            border-radius: 8px;
            text-decoration: none;
            display: inline-block;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h2>Su Clave Temporal ha sido generada</h2>
            <div class="clave">
                <asp:Label ID="lblClaveTemporal" runat="server" Text=""></asp:Label>
            </div>
            <a href="Login.aspx" class="btn">Volver al Login</a>
        </div>
    </form>
</body>
</html>
