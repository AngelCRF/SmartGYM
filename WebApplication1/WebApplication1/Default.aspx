<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1.Default" %>
<%
    //Declaracion de Varianles
    String Mensaje = "Ingresa tus Datos:";
%>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title><%Response.Write("Haciendo Login"); %></title>
    <link rel="stylesheet" href="Styles/miestilo.css" type="text/css" />
</head>
<body>
    <%="Bienvenido al sistema en ASP <br/>" %>
    <%:Mensaje%> <br/>
    <form id="form1" method="post" action="validar.aspx">
        <table>
            <tr>
                <td>
                    <label>Login</label>
                </td>
                <td>
                    <input type="text" name="Login" placeholder="Ingresa tu nombre de usuario"/>
                </td>
            </tr>
             <tr>
                <td>
                    <label>Password:</label>
                </td>
                <td>
                    <input type="password" name="pass" placeholder="Ingresa tu contraseña"/>
                </td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <input type="submit" value="Ingresar" />
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
