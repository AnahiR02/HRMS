<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Hrms.Formularios/Hrms.Master" CodeBehind="Planillas.aspx.vb" Inherits="IPU.SistemaRRHH.Planillas1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <link href="../Hrms.Scripts/Plugins/Jquery-Datatable/skin/bootstrap/css/dataTables.bootstrap.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MenuPrincipal" runat="server">
    <li>
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
    <li class="active">
        <a href="Planillas.aspx">
            <i class="material-icons">assignment</i>
            <span>Gestión de Planillas</span>
        </a>
    </li>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="TituloModulo" runat="server">
    <h2>GESTIÓN DE PLANILLAS</h2>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContenidoPrincipal" runat="server">
    <form runat="server" id="mainForm">

        <ajx:ToolkitScriptManager runat="server"></ajx:ToolkitScriptManager>

        <asp:Panel ID="pPlanillas" runat="server" Visible="true">
            <div class="row clearfix">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                    <div class="card">
                        <div class="header bg-purple">
                            <h2>HISTÓRICO DE PLANILLAS</h2>
                             <ul class="header-dropdown m-r--5">
                            <li class="dropdown">
                                <a href="javascript:void(0);" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="true">
                                    <i class="material-icons">build</i>
                                </a>
                                <ul class="dropdown-menu pull-right">
                                    <li><a id="btnConfigAvanzadas" class="waves-effect waves-block" runat="server">Configuraciones Avanzadas</a></li>

                                </ul>
                            </li>
                        </ul>
                        </div>
                       
                        <div class="body">

                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>

                                    <div class="row">
                                        <div class="col-sm-12">
                                            <div class="pull-left">
                                                <asp:Button ID="btnNuevaPlanilla" CssClass="btn bg-light-blue waves-effect" runat="server" Text="NUEVA PLANILLA" data-toggle="modal" data-target="#defaultModal" />
                                            </div>
                                        </div>
                                    </div>

                                </ContentTemplate>
                            </asp:UpdatePanel>

                            <div class="modal fade" id="defaultModal" tabindex="-1" role="dialog" data-backdrop="static">
                                <div class="modal-dialog" role="document">
                                    <div class="modal-content">
                                        <div class="modal-header">
                                            <h4 class="modal-title" id="defaultModalLabel">Nueva Planilla</h4>
                                        </div>
                                        <div class="modal-body">
                                            <p>Seleccione tipo de planilla:</p>
                                            <div class="form-group form-float">
                                                <div class="form-line">
                                                    <asp:DropDownList ID="ddlTipoPlanilla" class="form-control show-tick" runat="server">
                                                        <asp:ListItem Value="0" Text="-- Seleccione --" Selected="True"></asp:ListItem>
                                                        <asp:ListItem Value="1" Text="Empleados Permanentes"></asp:ListItem>
                                                        <asp:ListItem Value="2" Text="Empleados Por Contrato"></asp:ListItem>
                                                        <asp:ListItem Value="3" Text="SIREP"></asp:ListItem>
                                                        <asp:ListItem Value="4" Text="INJUPEMP"></asp:ListItem>
                                                        <asp:ListItem Value="5" Text="IAIP Permanentes"></asp:ListItem>
                                                        <asp:ListItem Value="6" Text="IAIP Por Contrato"></asp:ListItem>
                                                    </asp:DropDownList>

                                                </div>
                                            </div>
                                        </div>
                                        <div class="modal-footer">
                                            <asp:Button ID="btnAceptar" CssClass="btn btn-link waves-effect" runat="server" Text="Aceptar" />
                                            <asp:Button ID="btnCerrar" CssClass="btn btn-link waves-effect" runat="server" data-dismiss="modal" Text="Cerrar" />

                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-lg-12">
                                    <div class="table-responsive">
                                        <table class="table table-hover js-basic-example dataTable" style="font-size: 12px;">
                                            <thead>
                                                <tr>
                                                    <th>Cod.</th>
                                                    <th>TipoPlanilla</th>
                                                    <th>Nombre de la Planilla</th>
                                                    <th>Descripción/Observación</th>
                                                    <th>Fecha de Realización</th>
                                                    <th>Estado</th>
                                                    <th></th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                <tr>
                                                    <td></td>
                                                    <td></td>
                                                    <td></td>
                                                    <td></td>
                                                    <td></td>
                                                    <td></td>
                                                    <td>
                                                        <button type="button" class="btn bg-orange waves-effect btn-xs">
                                                            <i class="material-icons">mode_edit</i>
                                                        </button>
                                                        <button type="button" class="btn bg-red waves-effect btn-xs">
                                                            <i class="material-icons">delete</i>
                                                        </button>
                                                        <button type="button" class="btn bg-blue-grey waves-effect btn-xs">
                                                            <i class="material-icons">cloud_download</i>
                                                        </button>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td></td>
                                                    <td></td>
                                                    <td></td>
                                                    <td></td>
                                                    <td></td>
                                                    <td></td>
                                                    <td>
                                                        <button type="button" class="btn bg-orange waves-effect btn-xs">
                                                            <i class="material-icons">mode_edit</i>
                                                        </button>
                                                        <button type="button" class="btn bg-red waves-effect btn-xs">
                                                            <i class="material-icons">delete</i>
                                                        </button>
                                                        <button type="button" class="btn bg-blue-grey waves-effect btn-xs">
                                                            <i class="material-icons">cloud_download</i>
                                                        </button>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td></td>
                                                    <td></td>
                                                    <td></td>
                                                    <td></td>
                                                    <td></td>
                                                    <td></td>
                                                    <td>
                                                        <button type="button" class="btn bg-orange waves-effect btn-xs">
                                                            <i class="material-icons">mode_edit</i>
                                                        </button>
                                                        <button type="button" class="btn bg-red waves-effect btn-xs">
                                                            <i class="material-icons">delete</i>
                                                        </button>
                                                        <button type="button" class="btn bg-blue-grey waves-effect btn-xs">
                                                            <i class="material-icons">cloud_download</i>
                                                        </button>
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </div>

                                </div>
                            </div>





                        </div>
                    </div>
                </div>
            </div>
        </asp:Panel>

        <asp:Panel ID="pConfiguracionesAvanzadas" runat="server" Visible="false">
            <div class="row clearfix">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                    <div class="card">
                        <div class="header bg-purple">
                            <h2>CONFIGURACIONES AVANZADAS</h2>
                        </div>
                        <div class="body">

                            <div class="row">
                                <div class="col-sm-12">
                                    <h4><span class="label bg-orange">DEDUCCIONES</span></h4>
                                </div>
                            </div>

                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>

                                    <div class="row">
                                        <div class="col-lg-12">
                                            <div class="align-right">
                                                <a href="#" class="btn bg-light-blue btn-sm waves-effect" role="button">AGREGAR ELEMENTO</a>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-lg-12">
                                            <div class="table-responsive">
                                                <table class="table table-hover" style="font-size: 10px;">
                                                    <thead>
                                                        <tr>
                                                            <th>Cód. Deducción</th>
                                                            <th>Nombre de Deducción</th>
                                                            <th>Tipo de Valor</th>
                                                            <th>Valor</th>
                                                            <th></th>
                                                        </tr>
                                                    </thead>
                                                    <tbody>
                                                        <tr>
                                                            <td>1</td>
                                                            <td>IHSS Empleado</td>
                                                            <td></td>
                                                            <td></td>
                                                            <td>
                                                                <button type="button" class="btn bg-orange waves-effect btn-xs">
                                                                    <i class="material-icons">mode_edit</i>
                                                                </button>
                                                                <button type="button" class="btn bg-red waves-effect btn-xs">
                                                                    <i class="material-icons">delete</i>
                                                                </button>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>2</td>
                                                            <td>IHSS Patronal</td>
                                                            <td></td>
                                                            <td></td>
                                                            <td>
                                                                <button type="button" class="btn bg-orange waves-effect btn-xs">
                                                                    <i class="material-icons">mode_edit</i>
                                                                </button>
                                                                <button type="button" class="btn bg-red waves-effect btn-xs">
                                                                    <i class="material-icons">delete</i>
                                                                </button>
                                                            </td>
                                                        </tr>

                                                    </tbody>
                                                </table>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-lg-12">
                                            <div class="table-responsive">
                                                <table class="table table-hover" style="font-size: 10px;">
                                                    <thead>
                                                        <tr>
                                                            <th>Cód. Empleado</th>
                                                            <th>Nombre de Empleado</th>
                                                            <th>IHSS Empleado</th>
                                                            <th>IHSS Patronal</th>
                                                            <th></th>
                                                            <th></th>
                                                        </tr>
                                                    </thead>
                                                    <tbody>
                                                        <tr>
                                                            <td>1</td>
                                                            <td></td>
                                                            <td></td>
                                                            <td></td>
                                                            <td></td>
                                                            <td>
                                                                <button type="button" class="btn bg-orange waves-effect btn-xs">
                                                                    <i class="material-icons">mode_edit</i>
                                                                </button>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>2</td>
                                                            <td></td>
                                                            <td></td>
                                                            <td></td>
                                                            <td></td>
                                                            <td>
                                                                <button type="button" class="btn bg-orange waves-effect btn-xs">
                                                                    <i class="material-icons">mode_edit</i>
                                                                </button>
                                                            </td>
                                                        </tr>

                                                    </tbody>
                                                </table>
                                            </div>
                                        </div>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>

                            <div class="row">
                                <div class="col-sm-12">
                                    <div class="pull-right">
                                        <asp:Button ID="btnCancelarCambios" CssClass="btn bg-grey waves-effect" runat="server" Text="REGRESAR" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </asp:Panel>

    </form>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Scripts" runat="server">
    <script src="../Hrms.Scripts/Plugins/Jquery-slimscroll/jquery.slimscroll.js"></script>
    <script src="../Hrms.Scripts/Plugins/Jquery-Datatable/jquery.dataTables.js"></script>
    <script src="../Hrms.Scripts/Plugins/Jquery-Datatable/skin/bootstrap/js/dataTables.bootstrap.js"></script>
    <script src="../Hrms.Scripts/Plugins/Jquery-Datatable/extensions/export/dataTables.buttons.min.js"></script>
    <script src="../Hrms.Scripts/Plugins/Jquery-Datatable/extensions/export/buttons.flash.min.js"></script>
    <script src="../Hrms.Scripts/Plugins/Jquery-Datatable/extensions/export/jszip.min.js"></script>
    <script src="../Hrms.Scripts/Plugins/Jquery-Datatable/extensions/export/pdfmake.min.js"></script>
    <script src="../Hrms.Scripts/Plugins/Jquery-Datatable/extensions/export/vfs_fonts.js"></script>
    <script src="../Hrms.Scripts/Plugins/Jquery-Datatable/extensions/export/buttons.html5.min.js"></script>
    <script src="../Hrms.Scripts/Plugins/Jquery-Datatable/extensions/export/buttons.print.min.js"></script>
    <script src="../Hrms.Scripts/Plugins/Jquery-Datatable/jquery-datatable.js"></script>
    <script src="../Hrms.Scripts/demo.js"></script>
</asp:Content>
