<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Hrms.Formularios/Planillas.Master" CodeBehind="Planillas.EmpleadosContrato.aspx.vb" Inherits="IPU.SistemaRRHH.Planillas_EmpleadosContrato" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajx" %>


<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="TituloModulo" runat="server">
    <h2>PLANILLA DE EMPLEADOS POR CONTRATO</h2>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContenidoPrincipal" runat="server">
    <form runat="server" id="mainForm">

        <ajx:ToolkitScriptManager runat="server"></ajx:ToolkitScriptManager>

        <asp:Panel ID="pPlanillaPermanentes" runat="server" Visible="true">
            <div class="row clearfix">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                    <div class="card">
                        <div class="header bg-purple">
                            <h2>PLANILLA MENSUAL</h2>
                        </div>
                        <div class="body">

                              <%--<div class="row">
                                <div class="col-lg-12 pull-right">
                                    <span class="label label-warning">Estado Actual: ELABORANDO</span>
                                </div>
                            </div>--%>

                             <%--<div class="row">
                                <div class="col-lg-2 pull-right">
                                     <asp:Button ID="btnEnviarPlanilla" CssClass="btn bg-green waves-effect" runat="server" Text="ENVIAR" />
                                     <asp:Button ID="btnAutorizarPlanilla" CssClass="btn bg-green waves-effect" runat="server" Text="AUTORIZAR" />
                                     <asp:Button ID="btnDenegarPlanilla" CssClass="btn bg-red waves-effect" runat="server" Text="DENEGAR" />
                                     <asp:Button ID="btnAnularPlanilla" CssClass="btn bg-red waves-effect" runat="server" Text="ANULAR" />
                                     <asp:Button ID="btnPagarPlanilla" CssClass="btn bg-green waves-effect" runat="server" Text="PAGAR" />
                                   
                                </div>
                            </div>--%>

                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>

                                    <div class="row">
                                        <div class="col-lg-12">
                                            <div class="table-responsive">
                                                <table class="table table-hover dataTable js-exportable" style="font-size: 10px;">
                                                    <thead>
                                                        <tr>
                                                            <th>No.</th>
                                                            <th>Identidad Empleado</th>
                                                            <th>Nombre del Empleado</th>
                                                            <th>Cuenta Bancaria</th>
                                                            <th>IHSS</th>
                                                            <th>Total Deducciones</th>
                                                            <th>Sueldo Neto</th>
                                                        </tr>
                                                    </thead>
                                                    <tbody>
                                                        <tr>
                                                            <td>1</td>
                                                            <td></td>
                                                            <td></td>
                                                            <td></td>
                                                            <td></td>
                                                            <td></td>
                                                            <td></td>
                                                        </tr>
                                                        <tr>
                                                            <td>2</td>
                                                            <td></td>
                                                            <td></td>
                                                            <td></td>
                                                            <td></td>
                                                            <td></td>
                                                            <td></td>
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
                                        <asp:Button ID="btnGuardarPlanilla" CssClass="btn bg-orange waves-effect" runat="server" Text="GUARDAR PLANILLA" />
                                        <a href="Planillas.aspx" class="btn bg-grey waves-effect" runat="server">CANCELAR</a>
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
<asp:Content ID="Content4" ContentPlaceHolderID="Scripts" runat="server">
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
    </asp:Content>