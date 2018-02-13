<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Hrms.Formularios/Hrms.Master" CodeBehind="Dashboard.aspx.vb" Inherits="IPU.SistemaRRHH.Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MenuPrincipal" runat="server">
    <li class="active">
        <a href="Dashboard.aspx">
            <i class="material-icons">dashboard</i>
            <span>Dashboard</span>
        </a>
    </li>
    <li>
        <a href="Empleados.aspx">
            <i class="material-icons">account_circle</i>
            <span>Administración de Empleados</span>
        </a>
    </li>
     <li>
        <a href="Planillas.aspx">
            <i class="material-icons">assignment</i>
            <span>Gestión de Planillas</span>
        </a>
    </li>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="TituloModulo" runat="server">
    <h2>DASHBOARD</h2>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContenidoPrincipal" runat="server">
    <div class="row">
        <div class="col-lg-4 col-md-4 col-sm-6 col-xs-12">
            <div class="info-box-3 bg-teal hover-zoom-effect">
                <a href="Empleados.aspx">
                    <div class="icon">
                        <i class="material-icons">account_circle</i>
                    </div>
                    <div class="content">
                        <div class="text">ADMINISTRACIÓN DE</div>
                        <div class="number">Empleados</div>
                    </div>
                </a>
            </div>

        </div>
        <div class="col-lg-4 col-md-4 col-sm-6 col-xs-12">
            <div class="info-box-3 bg-purple hover-zoom-effect">
                <a href="Planillas.aspx">
                    <div class="icon">
                        <i class="material-icons">assignment</i>
                    </div>
                    <div class="content">
                        <div class="text">GESTIÓN DE</div>
                        <div class="number">Planillas</div>
                    </div>
                </a>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Scripts" runat="server">
</asp:Content>
