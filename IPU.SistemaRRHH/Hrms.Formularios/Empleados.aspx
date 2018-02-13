<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Hrms.Formularios/Hrms.Master" CodeBehind="Empleados.aspx.vb" Inherits="IPU.SistemaRRHH.Empleados" %>
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
    <li class="active">
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
    <h2>ADMINISTRACIÓN DE EMPLEADOS</h2>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContenidoPrincipal" runat="server">

    <form runat="server" id="mainForm">
        <ajx:ToolkitScriptManager runat="server"></ajx:ToolkitScriptManager>

        <!-- Panel de Empleados -->
        <asp:Panel ID="pListaEmpleados" runat="server" Visible="true">
            <div class="row clearfix">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                    <div class="card">
                        <div class="header bg-teal">
                            <h2>LISTA DE EMPLEADOS</h2>
                        </div>
                        <div class="body">
                            <div class="row">
                                <div class="col-sm-12">

                                    <div class="pull-left">
                                        <asp:Button ID="btnNuevoEmpleado" CssClass="btn bg-light-blue waves-effect" runat="server" Text="NUEVO EMPLEADO" />
                                    </div>

                                    <div class="pull-right">
                                        <asp:Button ID="btnModificarEmpleado" CssClass="btn bg-orange waves-effect" Visible="false" runat="server" Text="MODIFICAR" />
                                        <asp:Button ID="btnInactivar" CssClass="btn bg-grey waves-effect" runat="server" Visible="false" Text="INACTIVAR" />
                                    </div>
                                </div>
                            </div>
                            <div class="table-responsive">
                                <table class="table table-hover dataTable js-exportable" style="font-size:12px;">
                                    <thead>
                                        <tr>
                                            <th>Identidad</th>
                                            <th>Nombre del Empleado</th>
                                            <th>Cargo</th>
                                            <th>Área</th>
                                            <th>Fecha Inicio</th>
                                            <th>Salario</th>
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
                                            <td></td>
                                            <td>
                                                <button type="button" class="btn bg-teal btn-xs waves-effect"><i class="material-icons">touch_app</i></button></td>
                                        </tr>
                                        <tr>
                                            <td></td>
                                            <td></td>
                                            <td></td>
                                            <td></td>
                                            <td></td>
                                            <td></td>
                                            <td></td>
                                            <td>
                                                <button type="button" class="btn bg-teal btn-xs waves-effect"><i class="material-icons">touch_app</i></button></td>
                                        </tr>
                                        <tr>
                                            <td></td>
                                            <td></td>
                                            <td></td>
                                            <td></td>
                                            <td></td>
                                            <td></td>
                                            <td></td>
                                            <td>
                                                <button id="btnSeleccionar" type="button" runat="server" class="btn bg-teal btn-xs waves-effect"><i class="material-icons">touch_app</i></button></td>
                                        </tr>
                                        <tr>
                                            <td></td>
                                            <td></td>
                                            <td></td>
                                            <td></td>
                                            <td></td>
                                            <td></td>
                                            <td></td>
                                            <td>
                                                <button type="button" class="btn bg-teal btn-xs waves-effect"><i class="material-icons">touch_app</i></button></td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </asp:Panel>

        <!-- Panel de Nuevo Empleado -->
        <asp:Panel ID="pNuevoEmpleado" runat="server" Visible="false">
            <div class="row clearfix">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                    <div class="card">
                        <div class="header bg-teal">
                            <h2>NUEVO EMPLEADO</h2>
                        </div>
                        <div class="body">
                            <br />
                            <div class="progress">
                                <div class="progress-bar progress-bar-info progress-bar-striped active" role="progressbar" aria-valuenow="15" aria-valuemin="0" aria-valuemax="100" style="width: 15%;">15% Completado</div>
                            </div>

                            <!-- Tabs de Navegación -->
                            <ul class="nav nav-tabs" role="tablist">
                                <li role="presentation" class="active">
                                    <a href="#perfil" data-toggle="tab">
                                        <i class="material-icons">face</i>&nbsp;PASO 1 - Perfil Personal
                                    </a>
                                </li>
                                <li role="presentation">
                                    <a href="#perfilinstitucional" data-toggle="tab">
                                        <i class="material-icons">supervisor_account</i>&nbsp;PASO 2 - Perfil Institucional
                                    </a>
                                </li>

                                <li role="presentation">
                                    <a href="#documentacion" data-toggle="tab">
                                        <i class="material-icons">assignment</i>&nbsp;PASO 3 - Documentación del Empleado
                                    </a>
                                </li>
                                <%--   <li role="presentation">
                                    <a href="#experiencialaboral" data-toggle="tab">
                                        <i class="material-icons">work</i>&nbsp;Experiencia Laboral
                                    </a>
                                </li>
                                <li role="presentation">
                                    <a href="#referencias" data-toggle="tab">
                                        <i class="material-icons">record_voice_over</i>&nbsp;Referencias
                                    </a>
                                </li>
                                <li role="presentation">
                                    <a href="#otros" data-toggle="tab">
                                        <i class="material-icons">question_answer</i>&nbsp;Otros
                                    </a>
                                </li>--%>
                            </ul>


                            <!-- Tab Paneles -->
                            <div class="tab-content">

                                <!-- Tab de Perfil-->
                                <div role="tabpanel" class="tab-pane fade in active" id="perfil">

                                    <!-- Datos Personales -->
                                    <div class="row">
                                        <div class="col-sm-12">
                                            <h4><span class="label bg-orange">Datos Personales</span></h4>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-sm-12">
                                            <div class="row">
                                                <br />
                                                <!-- Género -->
                                                <div class="col-sm-6">
                                                    <div class="form-group form-float">
                                                        <div class="form-line" style="border-bottom: 1px solid #fff;">
                                                            <div class="demo-radio-button">
                                                                <input name="group1" type="radio" id="radio_2" class="radio-col-light-blue" />
                                                                <label for="radio_2">Masculino</label>
                                                                <input name="group1" type="radio" id="radio_1" class="radio-col-light-blue" checked />
                                                                <label for="radio_1">Femenino</label>
                                                            </div>
                                                            <label class="form-label" style="top: -20px;">Género</label>
                                                        </div>
                                                    </div>
                                                </div>

                                                <!-- Estado Civil -->
                                                <div class="col-sm-6">
                                                    <div class="form-group form-float">
                                                        <div class="form-line">
                                                            <select class="form-control show-tick">
                                                                <option value="">-- Seleccione --</option>
                                                                <option value="1">Soltero(a)</option>
                                                                <option value="2">Comprometido(a)</option>
                                                                <option value="3">Casado(a)</option>
                                                                <option value="4">Divorciado(a)</option>
                                                                <option value="5">Viudo(a)</option>
                                                                <option value="6">Unión Libre</option>
                                                            </select>
                                                            <label class="form-label" style="top: -20px; font-size: 12px;">Estado Civil</label>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="row">
                                                <!-- Primer Nombre -->
                                                <div class="col-lg-3 col-md-3 col-sm-6">
                                                    <div class="form-group form-float">
                                                        <div class="form-line">
                                                            <asp:TextBox ID="txtPrimerNombre" CssClass="form-control" runat="server"></asp:TextBox>
                                                            <label class="form-label">Primer Nombre</label>
                                                        </div>
                                                    </div>
                                                </div>

                                                <!-- Segundo Nombre -->
                                                <div class="col-lg-3 col-md-3 col-sm-6">
                                                    <div class="form-group form-float">
                                                        <div class="form-line">
                                                            <asp:TextBox ID="txtSegundoNombre" CssClass="form-control" runat="server"></asp:TextBox>
                                                            <label class="form-label">Segundo Nombre</label>
                                                        </div>
                                                    </div>
                                                </div>

                                                <!-- Primer Apellido -->
                                                <div class="col-lg-3 col-md-3 col-sm-6">
                                                    <div class="form-group form-float">
                                                        <div class="form-line">
                                                            <asp:TextBox ID="txtPrimerApellido" CssClass="form-control" runat="server"></asp:TextBox>
                                                            <label class="form-label">Primer Apellido</label>
                                                        </div>
                                                    </div>
                                                </div>

                                                <!-- Segundo Apellido -->
                                                <div class="col-lg-3 col-md-3 col-sm-6">
                                                    <div class="form-group form-float">
                                                        <div class="form-line">
                                                            <asp:TextBox ID="txtSegundoApellido" CssClass="form-control" runat="server"></asp:TextBox>
                                                            <label class="form-label">Segundo Apellido</label>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="row">

                                                <!-- País de Residencia -->
                                                <div class="col-lg-3 col-md-3 col-sm-6">
                                                    <div class="form-group form-float">
                                                        <div class="form-line" style="outline: none;">
                                                            <select class="form-control show-tick">
                                                                <option value="">-- Seleccione --</option>
                                                                <option value="1">Honduras</option>
                                                            </select>
                                                            <label class="form-label" style="top: -20px; font-size: 12px;">País de Residencia</label>
                                                        </div>
                                                    </div>
                                                </div>

                                                <!-- Departamento -->
                                                <div class="col-lg-3 col-md-3 col-sm-6">
                                                    <div class="form-group form-float">
                                                        <div class="form-line">
                                                            <select class="form-control show-tick">
                                                                <option value="">-- Seleccione --</option>
                                                                <option value="1">Atlántida</option>
                                                                <option value="2">Choluteca</option>
                                                                <option value="3">Colón</option>
                                                                <option value="4">Comayagua</option>
                                                                <option value="5">Copán Ruinas</option>
                                                                <option value="6">Cortés</option>
                                                                <option value="7">El Paraiso</option>
                                                                <option value="8">Francisco Morazán</option>
                                                                <option value="9">Gracias a Dios</option>
                                                                <option value="10">Intibucá</option>
                                                                <option value="11">Islas de la Bahía</option>
                                                                <option value="12">La Paz</option>
                                                                <option value="13">Lempira</option>
                                                                <option value="14">Ocotepeque</option>
                                                                <option value="15">Olancho</option>
                                                                <option value="16">Santa Bárbara</option>
                                                                <option value="17">Valle</option>
                                                                <option value="18">Yoro</option>
                                                            </select>
                                                            <label class="form-label" style="top: -20px; font-size: 12px;">Departamento</label>
                                                        </div>
                                                    </div>
                                                </div>

                                                <!-- No. de Identidad -->
                                                <div class="col-lg-3 col-md-3 col-sm-6">
                                                    <div class="form-group form-float">
                                                        <div class="form-line">
                                                            <asp:TextBox ID="txtNumIdentidad" CssClass="form-control" runat="server"></asp:TextBox>
                                                            <label class="form-label">No. de Identidad</label>
                                                        </div>
                                                    </div>
                                                </div>

                                                <!-- Fecha de Nacimiento -->
                                                <div class="col-lg-3 col-md-3 col-sm-6">

                                                    <div class="form-group form-float">
                                                        <div class="form-line">
                                                            <asp:TextBox ID="txtFechaNacimiento" CssClass="form-control" runat="server" Enabled="false"></asp:TextBox>
                                                            <label class="form-label" style="top: -20px; font-size: 12px;">Fecha de Nacimiento</label>
                                                        </div>
                                                        <asp:ImageButton ID="imgCalendario1" ImageUrl="../Hrms.Temas/Imagenes/img-calendario.png" ImageAlign="Right"
                                                            runat="server" />
                                                    </div>

                                                    <ajx:CalendarExtender ID="Calendario1" PopupButtonID="imgCalendario1" runat="server" TargetControlID="txtFechaNacimiento"
                                                        Format="dd/MM/yyyy">
                                                    </ajx:CalendarExtender>


                                                </div>


                                            </div>

                                            <div class="row">

                                                <!-- Edad -->
                                                <div class="col-lg-3 col-md-3 col-sm-6">
                                                    <div class="form-group form-float">
                                                        <div class="form-line">
                                                            <asp:TextBox ID="txtEdad" CssClass="form-control" runat="server"></asp:TextBox>
                                                            <label class="form-label">Edad</label>
                                                        </div>
                                                    </div>
                                                </div>

                                                <!-- Estatura -->
                                                <div class="col-lg-3 col-md-3 col-sm-6">
                                                    <div class="form-group form-float">
                                                        <div class="form-line">
                                                            <asp:TextBox ID="txtEstatura" CssClass="form-control" runat="server"></asp:TextBox>
                                                            <label class="form-label">Estatura</label>
                                                        </div>
                                                    </div>
                                                </div>

                                                <!-- Peso -->
                                                <div class="col-lg-3 col-md-3 col-sm-6">
                                                    <div class="form-group form-float">
                                                        <div class="form-line">
                                                            <asp:TextBox ID="txtPeso" CssClass="form-control" runat="server"></asp:TextBox>
                                                            <label class="form-label">Peso</label>
                                                        </div>
                                                    </div>
                                                </div>

                                                <!-- Tipo de Sangre -->
                                                <div class="col-lg-3 col-md-3 col-sm-6">
                                                    <div class="form-group form-float">
                                                        <div class="form-line">
                                                            <select class="form-control show-tick">
                                                                <option value="">-- Seleccione --</option>
                                                                <option value="1">A+</option>
                                                                <option value="2">A-</option>
                                                                <option value="3">B+</option>
                                                                <option value="4">B-</option>
                                                                <option value="5">O+</option>
                                                                <option value="6">O-</option>
                                                                <option value="7">AB+</option>
                                                                <option value="8">AB-</option>
                                                            </select>
                                                            <label class="form-label" style="top: -20px; font-size: 12px;">Tipo de Sangre</label>
                                                        </div>
                                                    </div>
                                                </div>

                                            </div>

                                            <div class="row">

                                                <!-- I.H.S.S. -->
                                                <div class="col-lg-3 col-md-3 col-sm-6">
                                                    <div class="form-group form-float">
                                                        <div class="form-line">
                                                            <asp:TextBox ID="txtNumIHSS" CssClass="form-control" runat="server"></asp:TextBox>
                                                            <label class="form-label"># I.H.S.S.</label>
                                                        </div>
                                                    </div>
                                                </div>

                                                <!-- R.T.N. -->
                                                <div class="col-lg-3 col-md-3 col-sm-6">
                                                    <div class="form-group form-float">
                                                        <div class="form-line">
                                                            <asp:TextBox ID="txtNumRTN" CssClass="form-control" runat="server"></asp:TextBox>
                                                            <label class="form-label"># R.T.N.</label>
                                                        </div>
                                                    </div>
                                                </div>

                                                <!-- I.S.R. -->
                                                <div class="col-lg-3 col-md-3 col-sm-6">
                                                    <div class="form-group form-float">
                                                        <div class="form-line">
                                                            <asp:TextBox ID="txtNumISR" CssClass="form-control" runat="server"></asp:TextBox>
                                                            <label class="form-label"># I.S.R.</label>
                                                        </div>
                                                    </div>
                                                </div>

                                                <!-- Solvencia Municipal -->
                                                <div class="col-lg-3 col-md-3 col-sm-6">
                                                    <div class="form-group form-float">
                                                        <div class="form-line">
                                                            <asp:TextBox ID="txtNumSolvenciaM" CssClass="form-control" runat="server"></asp:TextBox>
                                                            <label class="form-label"># Solvencia Municipal</label>
                                                        </div>
                                                    </div>
                                                </div>

                                            </div>

                                            <div class="row">

                                                <!-- Colegio Profesional -->
                                                <div class="col-lg-3 col-md-3 col-sm-6">
                                                    <div class="form-group form-float">
                                                        <div class="form-line">
                                                            <select class="form-control show-tick">
                                                                <option value="">-- Seleccione --</option>
                                                                <option value="1">Administradores de Empresa</option>
                                                                <option value="2">COHPUCP</option>
                                                                <option value="3">CIMEQH</option>
                                                                <option value="4">Peritos Mercantiles</option>
                                                            </select>
                                                            <label class="form-label" style="top: -20px; font-size: 12px;">Colegio Afiliado</label>
                                                        </div>
                                                    </div>
                                                </div>

                                                <!-- # Colegiación Profesional -->
                                                <div class="col-lg-3 col-md-3 col-sm-6">
                                                    <div class="form-group form-float">
                                                        <div class="form-line">
                                                            <asp:TextBox ID="txtNumColegiacion" CssClass="form-control" runat="server"></asp:TextBox>
                                                            <label class="form-label"># Colegiación</label>
                                                        </div>
                                                    </div>
                                                </div>

                                                <!-- # Licencia de Conducir -->
                                                <div class="col-lg-3 col-md-3 col-sm-6">
                                                    <div class="form-group form-float">
                                                        <div class="form-line">
                                                            <asp:TextBox ID="txtNumLicencia" CssClass="form-control" runat="server"></asp:TextBox>
                                                            <label class="form-label"># Licencia de Conducir</label>
                                                        </div>
                                                    </div>
                                                </div>

                                                <!-- Clase (Licencia) -->
                                                <div class="col-lg-3 col-md-3 col-sm-6">
                                                    <div class="form-group form-float">
                                                        <div class="form-line">
                                                            <asp:TextBox ID="txtClaseLicencia" CssClass="form-control" runat="server"></asp:TextBox>
                                                            <label class="form-label">Clase de Licencia</label>
                                                        </div>
                                                    </div>
                                                </div>

                                            </div>

                                            <div class="row">

                                                <!-- Correo Electrónico -->
                                                <div class="col-lg-3 col-md-3 col-sm-6">
                                                    <div class="form-group form-float">
                                                        <div class="form-line">
                                                            <asp:TextBox ID="txtCorreoElectronico" CssClass="form-control" runat="server"></asp:TextBox>
                                                            <label class="form-label">Correo Electrónico</label>
                                                        </div>
                                                    </div>
                                                </div>

                                                <!-- No. Casa -->
                                                <div class="col-lg-3 col-md-3 col-sm-6">
                                                    <div class="form-group form-float">
                                                        <div class="form-line">
                                                            <asp:TextBox ID="txtNumCasa" CssClass="form-control" runat="server"></asp:TextBox>
                                                            <label class="form-label">No. Casa</label>
                                                        </div>
                                                    </div>
                                                </div>

                                                <!-- No. Celular -->
                                                <div class="col-lg-3 col-md-3 col-sm-6">
                                                    <div class="form-group form-float">
                                                        <div class="form-line">
                                                            <asp:TextBox ID="txtNumCelular" CssClass="form-control" runat="server"></asp:TextBox>
                                                            <label class="form-label">No. Celular</label>
                                                        </div>
                                                    </div>
                                                </div>

                                                <!-- Dirección de Domicilio -->
                                                <div class="col-lg-3 col-md-3 col-sm-6">
                                                    <div class="form-group form-float">
                                                        <div class="form-line">
                                                            <asp:TextBox ID="txtDireccionD" CssClass="form-control" runat="server"></asp:TextBox>
                                                            <label class="form-label">Dirección de Domicilio</label>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>


                                            <div class="row">
                                                <div class="col-sm-12">
                                                    <h5><span class="label bg-grey">Caso de Emergencia</span></h5>
                                                </div>
                                            </div>

                                            <div class="row">

                                                <!-- Nombre de Persona Caso Emergencia -->
                                                <div class="col-lg-3 col-md-3 col-sm-6">
                                                    <div class="form-group form-float">
                                                        <div class="form-line">
                                                            <asp:TextBox ID="txtNombreEmerg" CssClass="form-control" runat="server"></asp:TextBox>
                                                            <label class="form-label">Nombre de Persona</label>
                                                        </div>
                                                    </div>
                                                </div>

                                                <!-- Numero de Teléfono Caso Emergencia -->
                                                <div class="col-lg-3 col-md-3 col-sm-6">
                                                    <div class="form-group form-float">
                                                        <div class="form-line">
                                                            <asp:TextBox ID="txtNumTelEmerg" CssClass="form-control" runat="server"></asp:TextBox>
                                                            <label class="form-label">Numero de Teléfono</label>
                                                        </div>
                                                    </div>
                                                </div>

                                                <!-- Dirección de Domicilio Caso Emergencia -->
                                                <div class="col-lg-6 col-md-6 col-sm-6">
                                                    <div class="form-group form-float">
                                                        <div class="form-line">
                                                            <asp:TextBox ID="txtDireccion" CssClass="form-control" runat="server"></asp:TextBox>
                                                            <label class="form-label">Dirección de Domicilio</label>
                                                        </div>
                                                    </div>
                                                </div>

                                            </div>

                                        </div>
                                    </div>

                                    <!-- Datos Familiares -->
                                    <div class="row">
                                        <div class="col-sm-12">
                                            <h4><span class="label bg-orange">Datos Familiares</span></h4>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-lg-12 col-md-12 col-sm-12">
                                            <div class="align-right">
                                                <a href="#" class="btn bg-light-blue btn-sm waves-effect" role="button">AGREGAR ELEMENTO</a>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-lg-12">
                                            <div class="table-responsive">
                                                <table class="table table-hover" style="font-size: 12px;">
                                                    <thead>
                                                        <tr>
                                                            <th>Parentesco</th>
                                                            <th>Nombre</th>
                                                            <th>Edad</th>
                                                            <th>Ocupación</th>
                                                            <th></th>
                                                        </tr>
                                                    </thead>
                                                    <tbody>
                                                        <tr>
                                                            <td></td>
                                                            <td></td>
                                                            <td></td>
                                                            <td></td>
                                                            <td>
                                                                <button type="button" class="btn bg-red waves-effect btn-xs">
                                                                    <i class="material-icons">delete</i>
                                                                </button>

                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td></td>
                                                            <td></td>
                                                            <td></td>
                                                            <td></td>
                                                            <td>
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

                                        <!-- Con quien vive -->
                                        <div class="col-lg-6 col-md-6 col-sm-6">
                                            <div class="form-group form-float">
                                                <div class="form-line">
                                                    <select class="form-control show-tick">
                                                        <option value="">-- Seleccione --</option>
                                                        <option value="1">Padres</option>
                                                        <option value="2">Familia</option>
                                                        <option value="3">Pariente</option>
                                                        <option value="4">Solo</option>
                                                    </select>
                                                    <label class="form-label" style="top: -20px; font-size: 12px;">¿Con quién vive?</label>
                                                </div>
                                            </div>
                                        </div>

                                        <!-- Personas que dependan -->
                                        <div class="col-lg-6 col-md-6 col-sm-6">
                                            <div class="form-group form-float">
                                                <div class="form-line">
                                                    <asp:TextBox ID="txtPersonasDependen" CssClass="form-control" runat="server"></asp:TextBox>
                                                    <label class="form-label">Personas que dependen del empleado</label>
                                                </div>
                                            </div>
                                        </div>

                                    </div>

                                    <!-- Formación Académica -->

                                    <div class="row">
                                        <div class="col-sm-12">
                                            <h4><span class="label bg-orange">Formación Académica</span></h4>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-lg-12 col-md-12 col-sm-12">
                                            <div class="align-right">
                                                <a href="#" class="btn bg-light-blue btn-sm waves-effect" role="button">AGREGAR ELEMENTO</a>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-lg-12">
                                            <div class="table-responsive">
                                                <table class="table table-hover" style="font-size: 12px;">
                                                    <thead>
                                                        <tr>
                                                            <th>Nombre del Centro Educativo</th>
                                                            <th>Dirección</th>
                                                            <th>Fecha Inicio</th>
                                                            <th>Fecha Fin</th>
                                                            <th>Título Obtenido</th>
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
                                                            <td>
                                                                <button type="button" class="btn bg-red waves-effect btn-xs">
                                                                    <i class="material-icons">delete</i>
                                                                </button>

                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td></td>
                                                            <td></td>
                                                            <td></td>
                                                            <td></td>
                                                            <td></td>
                                                            <td>
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

                                    <!-- Experiencia Laboral -->

                                    <div class="row">
                                        <div class="col-sm-12">
                                            <h4><span class="label bg-orange">Experiencia Laboral</span></h4>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-lg-12 col-md-12 col-sm-12">
                                            <div class="align-right">
                                                <a href="#" class="btn bg-light-blue btn-sm waves-effect" role="button">AGREGAR ELEMENTO</a>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-lg-12">
                                            <div class="table-responsive">
                                                <table class="table table-hover" style="font-size: 12px;">
                                                    <thead>
                                                        <tr>
                                                            <th>Nombre de la Empresa</th>
                                                            <th>Dirección</th>
                                                            <th>Cargo Desempeñado</th>
                                                            <th>Duración</th>
                                                            <th>Sueldo</th>
                                                            <th>Causas de Retiro</th>
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
                                                                <button type="button" class="btn bg-red waves-effect btn-xs">
                                                                    <i class="material-icons">delete</i>
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

                                    <!-- Referencias Bancarias o Comerciales-->

                                    <div class="row">
                                        <div class="col-sm-12">
                                            <h4><span class="label bg-orange">Referencias Comerciales o Bancarias</span></h4>
                                        </div>
                                    </div>

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
                                                <table class="table table-hover" style="font-size: 12px;">
                                                    <thead>
                                                        <tr>
                                                            <th>Nombre de la Institución</th>
                                                            <th>Teléfono</th>
                                                            <th></th>
                                                        </tr>
                                                    </thead>
                                                    <tbody>
                                                        <tr>
                                                            <td></td>
                                                            <td></td>
                                                            <td>
                                                                <button type="button" class="btn bg-red waves-effect btn-xs">
                                                                    <i class="material-icons">delete</i>
                                                                </button>

                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td></td>
                                                            <td></td>
                                                            <td>
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

                                    <!-- Referencias Personales -->

                                    <div class="row">
                                        <div class="col-sm-12">
                                            <h4><span class="label bg-orange">Referencias Personales</span></h4>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-lg-12 col-md-12 col-sm-12">
                                            <div class="align-right">
                                                <a href="#" class="btn bg-light-blue btn-sm waves-effect" role="button">AGREGAR ELEMENTO</a>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                            <div class="table-responsive">
                                                <table class="table table-hover" style="font-size: 12px;">
                                                    <thead>
                                                        <tr>
                                                            <th>Nombre</th>
                                                            <th>Dirección</th>
                                                            <th>Teléfono</th>
                                                            <th></th>
                                                        </tr>
                                                    </thead>
                                                    <tbody>
                                                        <tr>
                                                            <td></td>
                                                            <td></td>
                                                            <td></td>
                                                            <td>
                                                                <button type="button" class="btn bg-red waves-effect btn-xs">
                                                                    <i class="material-icons">delete</i>
                                                                </button>

                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td></td>
                                                            <td></td>
                                                            <td></td>
                                                            <td>
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

                                    <!-- Preguntas -->
                                    <div class="row">
                                        <div class="col-sm-12">
                                            <h4><span class="label bg-orange">Información Adicional</span></h4>
                                        </div>
                                    </div>

                                    <br />

                                    <div class="row">
                                        <!-- Inconveniente con viajar -->
                                        <div class="col-lg-6 col-md-6 col-sm-12">
                                            <div class="form-group form-float">
                                                <div class="form-line" style="border-bottom: 1px solid #fff;">
                                                    <div class="demo-radio-button">
                                                        <input name="group2" type="radio" id="radio_3" class="radio-col-light-blue" />
                                                        <label for="radio_3">Si</label>
                                                        <input name="group2" type="radio" id="radio_4" class="radio-col-light-blue" checked />
                                                        <label for="radio_4">No</label>
                                                    </div>
                                                    <label class="form-label" style="top: -20px;">¿Tiene algún incoveniente con viajar dentro del país?</label>
                                                </div>
                                            </div>
                                            <div class="form-group form-float">
                                                <div class="form-line">
                                                    <asp:TextBox ID="txtPorque" CssClass="form-control" runat="server"></asp:TextBox>
                                                    <label class="form-label" style="top: -20px;">¿Porqué?</label>
                                                </div>
                                            </div>
                                        </div>

                                        <!-- Fianzas -->
                                        <div class="col-lg-6 col-md-6 col-sm-12">
                                            <div class="form-group form-float">
                                                <div class="form-line" style="border-bottom: 1px solid #fff;">
                                                    <div class="demo-radio-button">
                                                        <input name="group4" type="radio" id="radio_5" class="radio-col-light-blue" />
                                                        <label for="radio_5">Si</label>
                                                        <input name="group4" type="radio" id="radio_6" class="radio-col-light-blue" checked />
                                                        <label for="radio_6">No</label>
                                                    </div>
                                                    <label class="form-label" style="top: -20px;">¿A estado afianzado?</label>
                                                </div>
                                            </div>
                                            <div class="form-group form-float">
                                                <div class="form-line">
                                                    <asp:TextBox ID="txtNombreCompania" CssClass="form-control" runat="server"></asp:TextBox>
                                                    <label class="form-label" style="top: -20px;">Nombre de la Compañía</label>
                                                </div>
                                            </div>
                                        </div>

                                    </div>

                                    <div class="row">

                                        <!-- Aceptaría cambiar de residencia? -->
                                        <div class="col-lg-6 col-md-6 col-sm-12">
                                            <div class="form-group form-float">
                                                <div class="form-line" style="border-bottom: 1px solid #fff;">
                                                    <div class="demo-radio-button">
                                                        <input name="group5" type="radio" id="radio_7" class="radio-col-light-blue" />
                                                        <label for="radio_7">Si</label>
                                                        <input name="group5" type="radio" id="radio_8" class="radio-col-light-blue" checked />
                                                        <label for="radio_8">No</label>
                                                    </div>
                                                    <label class="form-label" style="top: -20px;">¿Aceptaría cambiar de residencia?</label>
                                                </div>
                                            </div>

                                        </div>

                                        <!-- Podemos solicitar informes -->
                                        <div class="col-lg-6 col-md-6 col-sm-12">
                                            <div class="form-group form-float">
                                                <div class="form-line" style="border-bottom: 1px solid #fff;">
                                                    <div class="demo-radio-button">
                                                        <input name="group6" type="radio" id="radio_9" class="radio-col-light-blue" />
                                                        <label for="radio_9">Si</label>
                                                        <input name="group6" type="radio" id="radio_10" class="radio-col-light-blue" checked />
                                                        <label for="radio_10">No</label>
                                                    </div>
                                                    <label class="form-label" style="top: -20px;">¿Podemos solicitar informes?</label>
                                                </div>
                                            </div>
                                            <div class="form-group form-float">
                                                <div class="form-line">
                                                    <asp:TextBox ID="txtRazones" CssClass="form-control" runat="server"></asp:TextBox>
                                                    <label class="form-label" style="top: -20px;">Razones:</label>
                                                </div>
                                            </div>
                                        </div>

                                    </div>

                                    <div class="row">

                                        <!-- Parientes en el INPREUNAH -->
                                        <div class="col-lg-6 col-md-6 col-sm-12">
                                            <div class="form-group form-float">
                                                <div class="form-line" style="border-bottom: 1px solid #fff;">
                                                    <div class="demo-radio-button">
                                                        <input name="group7" type="radio" id="radio_11" class="radio-col-light-blue" />
                                                        <label for="radio_11">Si</label>
                                                        <input name="group7" type="radio" id="radio_12" class="radio-col-light-blue" checked />
                                                        <label for="radio_12">No</label>
                                                    </div>
                                                    <label class="form-label" style="top: -20px;">¿Tienes parientes en el INPREUNAH?</label>
                                                </div>
                                            </div>

                                        </div>

                                        <!-- Disponibilidad -->
                                        <div class="col-lg-6 col-md-6 col-sm-12">
                                            <div class="form-group form-float">
                                                <div class="form-line" style="border-bottom: 1px solid #fff;">
                                                    <div class="demo-radio-button">
                                                        <input name="group8" type="radio" id="radio_13" class="radio-col-light-blue" />
                                                        <label for="radio_13">Si</label>
                                                        <input name="group8" type="radio" id="radio_14" class="radio-col-light-blue" checked />
                                                        <label for="radio_14">No</label>
                                                    </div>
                                                    <label class="form-label" style="top: -20px;">¿Tiene disponibilidad inmediata?</label>
                                                </div>
                                            </div>
                                        </div>

                                    </div>

                                    <div class="row">

                                        <!-- Cómo se enteró de la vacante -->
                                        <div class="col-lg-6 col-md-6 col-sm-12">
                                            <div class="form-group form-float">
                                                <div class="form-line" style="border-bottom: 1px solid #fff;">
                                                    <div class="demo-radio-button">
                                                        <input name="group9" type="radio" id="radio_15" class="radio-col-light-blue" />
                                                        <label for="radio_15">Anuncio</label>
                                                        <input name="group9" type="radio" id="radio_16" class="radio-col-light-blue" checked />
                                                        <label for="radio_16">Contacto</label>
                                                        <input name="group9" type="radio" id="radio_17" class="radio-col-light-blue" />
                                                        <label for="radio_17">Web</label>
                                                    </div>
                                                    <label class="form-label" style="top: -20px;">¿Cómo se enteró de la vacante?</label>
                                                </div>
                                                <br />
                                                <div class="form-group form-float">
                                                    <div class="form-line">
                                                        <asp:TextBox ID="txtOtroMedio" CssClass="form-control" runat="server"></asp:TextBox>
                                                        <label class="form-label" style="top: -20px;">Otro Medio</label>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                    </div>

                                </div>

                                <!-- Tab de Perfil Institucional -->
                                <div role="tabpanel" class="tab-pane fade" id="perfilinstitucional">

                                    <div class="row">
                                        <div class="col-sm-12">
                                            <h4><span class="label bg-orange">Datos Personales</span></h4>
                                        </div>
                                    </div>

                                    <div class="row">

                                        <div class="col-sm-3 text-center">
                                            <!-- Imagen del Empleado -->
                                            <div class="row">
                                                <div class="col-sm-12">
                                                    <div class="thumbnail">
                                                        <img src="../Hrms.Temas/Imagenes/avatar_hombre.jpg" style="margin-top: 10px;" />
                                                        <div class="caption">
                                                            <h5>Fotografía del Empleado</h5>
                                                            <div class="align-center">
                                                                <a href="#" class="btn bg-light-blue btn-sm waves-effect" role="button">Subir Fotografía</a>
                                                            </div>

                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                            <!-- Firma del Empleado -->
                                            <div class="row">
                                                <div class="col-sm-12">
                                                    <div class="thumbnail">
                                                        <img src="../Hrms.Temas/Imagenes/Firma.png" style="margin-top: 10px;" />
                                                        <div class="caption">
                                                            <h5>Firma del Empleado</h5>
                                                            <div class="align-center">
                                                                <a href="#" class="btn bg-light-blue btn-sm waves-effect" role="button">Subir Firma</a>
                                                            </div>

                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                        </div>

                                        <div class="col-sm-9">

                                            <div class="row">

                                                <!-- Area/Depto-->
                                                <div class="col-lg-6 col-md-6 col-sm-12">

                                                    <div class="form-group form-float">
                                                        <div class="form-line">
                                                            <select class="form-control show-tick">
                                                                <option value="">-- Seleccione --</option>
                                                                <option value="1">Unidad de Tecnología</option>
                                                                <option value="2">Recursos Humanos</option>
                                                                <option value="3">Previsión Social</option>
                                                            </select>
                                                            <label class="form-label" style="top: -20px; font-size: 12px;">Área/Departamento</label>
                                                        </div>
                                                    </div>
                                                </div>

                                                <!-- Título o Puesto -->
                                                <div class="col-lg-6 col-md-6 col-sm-12">
                                                    <div class="form-group form-float">
                                                        <div class="form-line">
                                                            <select class="form-control show-tick">
                                                                <option value="">-- Seleccione --</option>
                                                                <option value="1">Jefe de Recursos Humanos</option>
                                                                <option value="2">Oficial de Información y Tecnología</option>
                                                                <option value="3">Jefe de Informática</option>
                                                                <option value="4">Jefe de Previsión Social</option>
                                                            </select>
                                                            <label class="form-label" style="top: -20px; font-size: 12px;">Puesto</label>
                                                        </div>
                                                    </div>
                                                </div>


                                            </div>
                                            <div class="row">

                                                <!-- Sucursal/Oficina -->
                                                <div class="col-lg-6 col-md-6 col-sm-12">
                                                    <div class="form-group form-float">
                                                        <div class="form-line">
                                                            <select class="form-control show-tick">
                                                                <option value="">-- Seleccione --</option>
                                                                <option value="1">TGU</option>
                                                                <option value="2">Cortés</option>
                                                                <option value="3">Atlántida</option>
                                                            </select>
                                                            <label class="form-label" style="top: -20px; font-size: 12px;">Sucursal/Oficinas</label>
                                                        </div>
                                                    </div>
                                                </div>

                                                <!-- Tipo de Empleo -->
                                                <div class="col-lg-6 col-md-6 col-sm-12">
                                                    <div class="form-group form-float">
                                                        <div class="form-line">
                                                            <select class="form-control show-tick">
                                                                <option value="">-- Seleccione --</option>
                                                                <option value="1">Permanente</option>
                                                                <option value="2">Contrato</option>
                                                            </select>
                                                            <label class="form-label" style="top: -20px; font-size: 12px;">Tipo de Empleo</label>
                                                        </div>
                                                    </div>
                                                </div>

                                            </div>

                                            <div class="row">

                                                <!-- Correo Instituto -->
                                                <div class="col-lg-6 col-md-6 col-sm-12">
                                                    <div class="form-group form-float">
                                                        <div class="form-line">
                                                            <asp:TextBox ID="txtCorreoInstituto" CssClass="form-control" runat="server"></asp:TextBox>
                                                            <label class="form-label">Correo Institucional</label>
                                                        </div>
                                                    </div>
                                                </div>

                                                <!-- Num. de Ext. -->
                                                <div class="col-lg-6 col-md-6 col-sm-12">
                                                    <div class="form-group form-float">
                                                        <div class="form-line">
                                                            <asp:TextBox ID="txtNumExt" CssClass="form-control" runat="server"></asp:TextBox>
                                                            <label class="form-label">Ext.</label>
                                                        </div>
                                                    </div>
                                                </div>

                                            </div>

                                            <div class="row">

                                                <!-- Fecha de Ingreso -->
                                                <div class="col-lg-6 col-md-6 col-sm-12">
                                                    <div class="form-group form-float">
                                                        <div class="form-line">
                                                            <asp:TextBox ID="txtFechaIngreso" CssClass="form-control" runat="server"></asp:TextBox>
                                                            <label class="form-label" style="top: -20px; font-size: 12px;">Fecha de Ingreso</label>
                                                        </div>
                                                        <asp:ImageButton ID="imgCalendario2" ImageUrl="../Hrms.Temas/Imagenes/img-calendario.png" ImageAlign="Right"
                                                            runat="server" />
                                                    </div>
                                                    <ajx:CalendarExtender ID="CalendarExtender2" PopupButtonID="imgCalendario2" runat="server" TargetControlID="txtFechaIngreso"
                                                        Format="dd/MM/yyyy">
                                                    </ajx:CalendarExtender>
                                                </div>

                                                <!-- Fecha de Egreso -->
                                                <div class="col-lg-6 col-md-6 col-sm-12">
                                                    <div class="form-group form-float">
                                                        <div class="form-line">
                                                            <asp:TextBox ID="txtFechaEgreso" CssClass="form-control" runat="server" Enabled="false"></asp:TextBox>
                                                            <label class="form-label" style="top: -20px; font-size: 12px;">Fecha de Egreso</label>
                                                        </div>
                                                        <asp:ImageButton ID="imgCalendario3" Enabled="false" ImageUrl="../Hrms.Temas/Imagenes/img-calendario.png" ImageAlign="Right"
                                                            runat="server" />
                                                    </div>
                                                    <ajx:CalendarExtender ID="CalendarExtender3" PopupButtonID="imgCalendario3" runat="server" TargetControlID="txtFechaEgreso"
                                                        Format="dd/MM/yyyy">
                                                    </ajx:CalendarExtender>
                                                </div>

                                            </div>

                                            <div class="row">

                                                <!-- Salario -->
                                                <div class="col-lg-6 col-md-6 col-sm-12">
                                                    <div class="form-group form-float">
                                                        <div class="form-line">
                                                            <asp:TextBox ID="txtSalario" CssClass="form-control" runat="server"></asp:TextBox>
                                                            <label class="form-label">Salario</label>
                                                        </div>
                                                    </div>
                                                </div>

                                                <!-- Frecuencia de Pago -->
                                                <div class="col-lg-6 col-md-6 col-sm-12">
                                                    <div class="form-group form-float">
                                                        <div class="form-line">
                                                            <asp:TextBox ID="txtFrecuenciaPago" CssClass="form-control" runat="server"></asp:TextBox>
                                                            <label class="form-label">Frecuencia de Pago</label>
                                                        </div>
                                                    </div>
                                                </div>

                                            </div>


                                            <div class="row">

                                                <!-- Nombre del Banco -->
                                                <div class="col-lg-6 col-md-6 col-sm-12">
                                                    <div class="form-group form-float">
                                                        <div class="form-line">
                                                            <select class="form-control show-tick">
                                                                <option value="">-- Seleccione --</option>
                                                                <option value="1">Davivienda</option>
                                                            </select>
                                                            <label class="form-label" style="top: -20px; font-size: 12px;">Nombre del Banco</label>
                                                        </div>
                                                    </div>
                                                </div>

                                                <!-- Código Banco -->
                                                <div class="col-lg-6 col-md-6 col-sm-12">
                                                    <div class="form-group form-float">
                                                        <div class="form-line">
                                                            <asp:TextBox ID="txtCodigoBanco" CssClass="form-control" runat="server"></asp:TextBox>
                                                            <label class="form-label">Código del Banco </label>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="row">

                                                <!-- Nombre Cuenta Bancaria -->
                                                <div class="col-lg-6 col-md-6 col-sm-12">

                                                    <div class="form-group form-float">
                                                        <div class="form-line">
                                                            <asp:TextBox ID="txtNombreCuentaBancaria" CssClass="form-control" runat="server"></asp:TextBox>
                                                            <label class="form-label">Nombre Cuenta Bancaria</label>
                                                        </div>
                                                    </div>
                                                </div>

                                                <!-- Numero de Cuenta Bancaria -->
                                                <div class="col-lg-6 col-md-6 col-sm-12">


                                                    <div class="form-group form-float">
                                                        <div class="form-line">
                                                            <asp:TextBox ID="txtNumeroCuentaBancaria" CssClass="form-control" runat="server"></asp:TextBox>
                                                            <label class="form-label"># Cuenta Bancaria</label>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="row">
                                                <!-- Tipo de Cuenta -->
                                                <div class="col-lg-6 col-md-6 col-sm-12">
                                                    <div class="form-group form-float">
                                                        <div class="form-line">
                                                            <select class="form-control show-tick">
                                                                <option value="">-- Seleccione --</option>
                                                                <option value="1">Ahorro</option>
                                                                <option value="2">Cheques</option>
                                                            </select>
                                                            <label class="form-label" style="top: -20px; font-size: 12px;">Tipo de Cuenta</label>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-lg-6 col-md-6 col-sm-12">
                                                </div>
                                            </div>

                                            <!-- Póliza de Seguro con INPREUNAH -->

                                            <div class="row">
                                                <div class="col-lg-6 col-md-6 col-sm-12">
                                                    <input type="checkbox" id="md_checkbox_27" class="filled-in chk-col-light-blue">
                                                    <label for="md_checkbox_27">Polizas de seguro con INPREUNAH</label>
                                                </div>
                                            </div>

                                            <div class="row">
                                                <div class="col-lg-12">
                                                    <div class="table-responsive">
                                                        <table class="table table-hover" style="font-size: 12px;">
                                                            <thead>
                                                                <tr>
                                                                    <th>Nombre</th>
                                                                    <th>Domicilio</th>
                                                                    <th></th>
                                                                </tr>
                                                            </thead>
                                                            <tbody>
                                                                <tr>
                                                                    <td></td>
                                                                    <td></td>
                                                                    <td>
                                                                        <button type="button" class="btn bg-red waves-effect btn-xs">
                                                                            <i class="material-icons">delete</i>
                                                                        </button>

                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td></td>
                                                                    <td></td>
                                                                    <td>
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

                                        </div>

                                    </div>
                                </div>

                                <!-- Tab de Documentación -->
                                <div role="tabpanel" class="tab-pane fade" id="documentacion">

                                    <!-- Documentación Requerida -->

                                    <div class="row">
                                        <div class="col-sm-12">
                                            <h4><span class="label bg-orange">Documentación Requerida</span></h4>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                            <div class="table-responsive">
                                                <table class="table table-hover" style="font-size: 12px;">
                                                    <thead>
                                                        <tr>
                                                            <th>Nombre Documento</th>
                                                            <th>Nombre del Archivo</th>
                                                            <th></th>
                                                        </tr>
                                                    </thead>
                                                    <tbody>
                                                        <tr>
                                                            <td>Solicitud de Empleo</td>
                                                            <td></td>
                                                            <td>
                                                                <button type="button" class="btn bg-light-blue waves-effect btn-xs">
                                                                    <i class="material-icons">cloud_upload</i>
                                                                </button>
                                                                <button type="button" class="btn bg-red waves-effect btn-xs">
                                                                    <i class="material-icons">delete</i>
                                                                </button>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Currículum Vitae</td>
                                                            <td></td>
                                                            <td>
                                                                <button type="button" class="btn bg-light-blue waves-effect btn-xs">
                                                                    <i class="material-icons">cloud_upload</i>
                                                                </button>
                                                                <button type="button" class="btn bg-red waves-effect btn-xs">
                                                                    <i class="material-icons">delete</i>
                                                                </button>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Copia de Identidad</td>
                                                            <td></td>
                                                            <td>
                                                                <button type="button" class="btn bg-light-blue waves-effect btn-xs">
                                                                    <i class="material-icons">cloud_upload</i>
                                                                </button>
                                                                <button type="button" class="btn bg-red waves-effect btn-xs">
                                                                    <i class="material-icons">delete</i>
                                                                </button>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Copia de RTN</td>
                                                            <td></td>
                                                            <td>
                                                                <button type="button" class="btn bg-light-blue waves-effect btn-xs">
                                                                    <i class="material-icons">cloud_upload</i>
                                                                </button>
                                                                <button type="button" class="btn bg-red waves-effect btn-xs">
                                                                    <i class="material-icons">delete</i>
                                                                </button>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Tarjeta de Salud</td>
                                                            <td></td>
                                                            <td>
                                                                <button type="button" class="btn bg-light-blue waves-effect btn-xs">
                                                                    <i class="material-icons">cloud_upload</i>
                                                                </button>
                                                                <button type="button" class="btn bg-red waves-effect btn-xs">
                                                                    <i class="material-icons">delete</i>
                                                                </button>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Examen Tipo Sangre</td>
                                                            <td></td>
                                                            <td>
                                                                <button type="button" class="btn bg-light-blue waves-effect btn-xs">
                                                                    <i class="material-icons">cloud_upload</i>
                                                                </button>
                                                                <button type="button" class="btn bg-red waves-effect btn-xs">
                                                                    <i class="material-icons">delete</i>
                                                                </button>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Entrevista</td>
                                                            <td></td>
                                                            <td>
                                                                <button type="button" class="btn bg-light-blue waves-effect btn-xs">
                                                                    <i class="material-icons">cloud_upload</i>
                                                                </button>
                                                                <button type="button" class="btn bg-red waves-effect btn-xs">
                                                                    <i class="material-icons">delete</i>
                                                                </button>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Const. de antecedentes policiales</td>
                                                            <td></td>
                                                            <td>
                                                                <button type="button" class="btn bg-light-blue waves-effect btn-xs">
                                                                    <i class="material-icons">cloud_upload</i>
                                                                </button>
                                                                <button type="button" class="btn bg-red waves-effect btn-xs">
                                                                    <i class="material-icons">delete</i>
                                                                </button>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Const. de antecedentes penales</td>
                                                            <td></td>
                                                            <td>
                                                                <button type="button" class="btn bg-light-blue waves-effect btn-xs">
                                                                    <i class="material-icons">cloud_upload</i>
                                                                </button>
                                                                <button type="button" class="btn bg-red waves-effect btn-xs">
                                                                    <i class="material-icons">delete</i>
                                                                </button>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Test psicométricos</td>
                                                            <td></td>
                                                            <td>
                                                                <button type="button" class="btn bg-light-blue waves-effect btn-xs">
                                                                    <i class="material-icons">cloud_upload</i>
                                                                </button>
                                                                <button type="button" class="btn bg-red waves-effect btn-xs">
                                                                    <i class="material-icons">delete</i>
                                                                </button>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Contrato</td>
                                                            <td></td>
                                                            <td>
                                                                <button type="button" class="btn bg-light-blue waves-effect btn-xs">
                                                                    <i class="material-icons">cloud_upload</i>
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


                                    <!-- Documentación Opcional -->

                                    <div class="row">
                                        <div class="col-sm-12">
                                            <h4><span class="label bg-orange">Documentación Opcional</span></h4>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-lg-12">

                                            <div class="row">
                                                <div class="col-lg-12 col-md-12 col-sm-12">
                                                    <div class="align-right">
                                                        <a href="#" class="btn bg-light-blue btn-sm waves-effect" role="button">Agregar Documento</a>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="row">
                                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                                    <div class="table-responsive">
                                                        <table class="table table-hover" style="font-size: 12px;">
                                                            <thead>
                                                                <tr>
                                                                    <th>Nombre Documento</th>
                                                                    <th>Nombre del Archivo</th>
                                                                    <th></th>
                                                                </tr>
                                                            </thead>
                                                            <tbody>
                                                                <tr>
                                                                    <td>
                                                                        <asp:DropDownList ID="DropDownList1" runat="server">
                                                                            <asp:ListItem>Prueba de Embarazo</asp:ListItem>
                                                                            <asp:ListItem>Constancias de Trabajo</asp:ListItem>
                                                                            <asp:ListItem>Declaración al TSC</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    <td></td>
                                                                    <td>
                                                                        <button type="button" class="btn bg-light-blue waves-effect btn-xs">
                                                                            <i class="material-icons">cloud_upload</i>
                                                                        </button>
                                                                        <button type="button" class="btn bg-red waves-effect btn-xs">
                                                                            <i class="material-icons">delete</i>
                                                                        </button>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:DropDownList ID="DropDownList2" runat="server">
                                                                            <asp:ListItem>Prueba de Embarazo</asp:ListItem>
                                                                            <asp:ListItem>Constancias de Trabajo</asp:ListItem>
                                                                            <asp:ListItem>Declaración al TSC</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    <td></td>
                                                                    <td>
                                                                        <button type="button" class="btn bg-light-blue waves-effect btn-xs">
                                                                            <i class="material-icons">cloud_upload</i>
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

                                        </div>
                                    </div>
                                </div>
                            </div>

                            <!-- Botones Guardar y CANCELAR -->
                            <div class="row">
                                <div class="col-sm-12">
                                    <div class="pull-right">
                                        <asp:Button ID="btnGuardarNuevoEmp" CssClass="btn bg-green waves-effect" runat="server" Text="GUARDAR" />
                                        <a href="Empleados.aspx" class="btn bg-grey waves-effect" runat="server">CANCELAR</a>
                                    </div>
                                </div>
                            </div>

                        </div>
                    </div>
                </div>
            </div>

        </asp:Panel>
        <!-- Fin de Panel de Nuevo Empleado -->
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
