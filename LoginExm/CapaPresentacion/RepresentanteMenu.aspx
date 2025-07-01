<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RepresentanteMenu.aspx.cs" Inherits="LoginExm.CapaPresentacion.RepresentanteMenu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Menú Representante</title>
    <style>
        body {
            background-color: #fff0f5;
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
        }

        .container {
            max-width: 800px;
            margin: 50px auto;
            padding: 30px;
            background-color: #d291bc;
            border-radius: 12px;
            box-shadow: 0 4px 12px rgba(0, 0, 0, 0.2);
            color: #ffffff;
        }

        .bienvenida {
            font-size: 28px;
            text-align: center;
            font-weight: bold;
            margin-bottom: 30px;
            color: #ffe5ec;
        }

        .datos {
            font-size: 18px;
            text-align: center;
            line-height: 1.8;
            color: #fff0f5;
            background-color: #c47189;
            padding: 20px;
            border-radius: 10px;
            box-shadow: 0 3px 8px rgba(0, 0, 0, 0.15);
        }

        .titulo-seccion {
            font-size: 22px;
            margin-bottom: 15px;
            color: #fcd5ce;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="bienvenida">
                <asp:Label ID="lblBienvenida" runat="server" Text=""></asp:Label>
            </div>

            <div class="datos">
                <asp:Label ID="lblDatos" runat="server" Text=""></asp:Label>
            </div>
        </div>
    </form>
</body>
</html>
