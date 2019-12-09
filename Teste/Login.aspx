<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>LOGIN</title>

    <style>
        html {
            
            background-image: url("/imagens/homeFundo2.png");
            background-repeat:no-repeat;
            background-size:700px;
            background-color:#878787;
        }
        #divLogin{
            
        }
        #frmLogin{
            margin-left:50%;
            margin-top:20%;
        }
        #tbLogin{
            

        }
    </style>

    <script>
        function resizeMyWebPage() {
            resizeTo(50, 50);
            window.focus();
        }


    </script>
</head>


<body onload="resizeMyWebPage();">
    
    <form id="frmLogin" runat="server">
        <div id="divLogin" >
            <table id="tbLogin" >
                <tr>
                    <td>
                        <b>Login:</b><br />
                        <asp:TextBox runat="server" ID="txtLogin" Width="150px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <b>Senha:</b><br />
                        <asp:TextBox runat="server" ID="txtSenha" Width="150px"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td>
                        <asp:Button runat="server" Text="Login" ID="btnLogin" Width="50px" OnClick="btnLogin_Click" />
                    </td>
                </tr>
            </table>

        </div>
    </form>
</body>
</html>
