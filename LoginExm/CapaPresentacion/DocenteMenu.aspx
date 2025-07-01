<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DocenteMenu.aspx.cs" Inherits="LoginExm.CapaPresentacion.DocenteMenu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Menú Docente</title>
    <style>
        body {
            background-color: #eef6fb;
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
        }

        .container {
            max-width: 800px;
            margin: 50px auto;
            padding: 30px;
            background-color: #003566;
            border-radius: 12px;
            box-shadow: 0 4px 12px rgba(0, 0, 0, 0.2);
            color: #ffffff;
        }

        .bienvenida {
            font-size: 28px;
            text-align: center;
            font-weight: bold;
            margin-bottom: 30px;
            color: #90e0ef;
        }

        .datos {
            font-size: 18px;
            text-align: center;
            line-height: 1.8;
            color: #caf0f8;
            background-color: #00509d;
            padding: 20px;
            border-radius: 10px;
            box-shadow: 0 3px 8px rgba(0, 0, 0, 0.15);
        }

        .titulo-seccion {
            font-size: 22px;
            margin-bottom: 15px;
            color: #ade8f4;
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
