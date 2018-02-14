<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Login.aspx.vb" Inherits="IPU.SistemaRRHH.Login" %>

<!DOCTYPE html>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>IPU - Recursos Humanos</title>

    <link rel="icon" href="../Hrms.Temas/Imagenes/IPUIcon.ico" type="image/x-icon" />

    <link href="../Hrms.Temas/GoogleFonts/MaterialIcons.css" rel="stylesheet" />
    <link href="../Hrms.Temas/GoogleFonts/Roboto.css" rel="stylesheet" />
    <link href="../Hrms.Temas/Plugins/Bootstrap/bootstrap.css" rel="stylesheet" />
    <link href="../Hrms.Temas/Plugins/Waves/waves.css" rel="stylesheet" />
    <link href="../Hrms.Temas/Plugins/Animate/animate.css" rel="stylesheet" />
    <link href="../Hrms.Temas/style.css" rel="stylesheet" />

</head>

<body class="login-page">
    <div class="login-box">
        <div class="logo">
            <img class="center-block" src="../Hrms.Temas/Imagenes/LogoIPU.png" />
            <br />
            <a href="#">INPREUNAH</a>
            <small><strong>Sistema de Gestión de Recursos Humanos</strong></small>
        </div>
        <div class="card">
            <div class="body">
                <form id="sign_in" runat="server" method="POST">
                    <div class="input-group">
                        <span class="input-group-addon">
                            <i class="material-icons">person</i>
                        </span>
                        <div class="form-line">
                            <asp:TextBox ID="txtUsuario" runat="server" CssClass="form-control" placeholder="Usuario"></asp:TextBox>
                        </div>
                        <asp:RequiredFieldValidator ID="RFV1" runat="server"
                            ControlToValidate="txtUsuario"
                            ErrorMessage="*Campo Requerido"
                            ForeColor="Red"
                            Font-Size="10px">
                        </asp:RequiredFieldValidator>
                    </div>
                    <div class="input-group">
                        <span class="input-group-addon">
                            <i class="material-icons">lock</i>
                        </span>
                        <div class="form-line">
                            <asp:TextBox ID="txtContraseña" runat="server" CssClass="form-control" placeholder="Contraseña" Type="password"></asp:TextBox>

                        </div>
                        <asp:RequiredFieldValidator ID="RFV2" runat="server"
                            ControlToValidate="txtContraseña"
                            ErrorMessage="*Campo Requerido"
                            ForeColor="Red" 
                            Font-Size="10px">
                        </asp:RequiredFieldValidator>
                    </div>
                    <div class="row">
                        <div class="col-xs-12">
                            <asp:Button ID="btnIniciarSesion" runat="server" Text="Iniciar Sesión" CssClass="btn btn-block bg-blue waves-effect" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-12 align-right"><a href="#">¿Olvidó su contraseña?</a></div>
                    </div>
                </form>
            </div>
        </div>
        <div class="align-center">&copy; 2018 INPREUNAH.</div>
    </div>

    <script src="../Hrms.Scripts/Plugins/Jquery/jquery.min.js"></script>
    <script src="../Hrms.Scripts/Plugins/Bootstrap/bootstrap.js"></script>
    <script src="../Hrms.Scripts/Plugins/Waves/waves.js"></script>
    <script src="../Hrms.Scripts/admin.js"></script>

</body>
</html>
