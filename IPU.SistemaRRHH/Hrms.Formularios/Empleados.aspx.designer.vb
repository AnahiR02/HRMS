'------------------------------------------------------------------------------
' <generado automáticamente>
'     Este código fue generado por una herramienta.
'
'     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
'     se vuelve a generar el código. 
' </generado automáticamente>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On


Partial Public Class Empleados
    
    '''<summary>
    '''Control mainForm.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents mainForm As Global.System.Web.UI.HtmlControls.HtmlForm
    
    '''<summary>
    '''Control pListaEmpleados.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents pListaEmpleados As Global.System.Web.UI.WebControls.Panel
    
    '''<summary>
    '''Control btnNuevoEmpleado.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents btnNuevoEmpleado As Global.System.Web.UI.WebControls.Button
    
    '''<summary>
    '''Control btnModificarEmpleado.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents btnModificarEmpleado As Global.System.Web.UI.WebControls.Button
    
    '''<summary>
    '''Control btnInactivar.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents btnInactivar As Global.System.Web.UI.WebControls.Button
    
    '''<summary>
    '''Control btnSeleccionar.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents btnSeleccionar As Global.System.Web.UI.HtmlControls.HtmlButton
    
    '''<summary>
    '''Control pNuevoEmpleado.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents pNuevoEmpleado As Global.System.Web.UI.WebControls.Panel
    
    '''<summary>
    '''Control txtPrimerNombre.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents txtPrimerNombre As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''Control txtSegundoNombre.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents txtSegundoNombre As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''Control txtPrimerApellido.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents txtPrimerApellido As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''Control txtSegundoApellido.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents txtSegundoApellido As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''Control txtNumIdentidad.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents txtNumIdentidad As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''Control txtFechaNacimiento.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents txtFechaNacimiento As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''Control imgCalendario1.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents imgCalendario1 As Global.System.Web.UI.WebControls.ImageButton
    
    '''<summary>
    '''Control Calendario1.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Calendario1 As Global.AjaxControlToolkit.CalendarExtender
    
    '''<summary>
    '''Control txtEdad.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents txtEdad As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''Control txtEstatura.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents txtEstatura As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''Control txtPeso.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents txtPeso As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''Control txtNumIHSS.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents txtNumIHSS As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''Control txtNumRTN.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents txtNumRTN As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''Control txtNumISR.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents txtNumISR As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''Control txtNumSolvenciaM.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents txtNumSolvenciaM As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''Control txtNumColegiacion.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents txtNumColegiacion As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''Control txtNumLicencia.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents txtNumLicencia As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''Control txtClaseLicencia.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents txtClaseLicencia As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''Control txtCorreoElectronico.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents txtCorreoElectronico As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''Control txtNumCasa.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents txtNumCasa As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''Control txtNumCelular.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents txtNumCelular As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''Control txtDireccionD.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents txtDireccionD As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''Control txtNombreEmerg.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents txtNombreEmerg As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''Control txtNumTelEmerg.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents txtNumTelEmerg As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''Control txtDireccion.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents txtDireccion As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''Control txtPersonasDependen.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents txtPersonasDependen As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''Control txtPorque.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents txtPorque As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''Control txtNombreCompania.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents txtNombreCompania As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''Control txtRazones.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents txtRazones As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''Control txtOtroMedio.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents txtOtroMedio As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''Control txtCorreoInstituto.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents txtCorreoInstituto As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''Control txtNumExt.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents txtNumExt As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''Control txtFechaIngreso.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents txtFechaIngreso As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''Control imgCalendario2.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents imgCalendario2 As Global.System.Web.UI.WebControls.ImageButton
    
    '''<summary>
    '''Control CalendarExtender2.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents CalendarExtender2 As Global.AjaxControlToolkit.CalendarExtender
    
    '''<summary>
    '''Control txtFechaEgreso.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents txtFechaEgreso As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''Control imgCalendario3.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents imgCalendario3 As Global.System.Web.UI.WebControls.ImageButton
    
    '''<summary>
    '''Control CalendarExtender3.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents CalendarExtender3 As Global.AjaxControlToolkit.CalendarExtender
    
    '''<summary>
    '''Control txtSalario.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents txtSalario As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''Control txtFrecuenciaPago.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents txtFrecuenciaPago As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''Control txtCodigoBanco.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents txtCodigoBanco As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''Control txtNombreCuentaBancaria.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents txtNombreCuentaBancaria As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''Control txtNumeroCuentaBancaria.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents txtNumeroCuentaBancaria As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''Control DropDownList1.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents DropDownList1 As Global.System.Web.UI.WebControls.DropDownList
    
    '''<summary>
    '''Control DropDownList2.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents DropDownList2 As Global.System.Web.UI.WebControls.DropDownList
    
    '''<summary>
    '''Control btnGuardarNuevoEmp.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents btnGuardarNuevoEmp As Global.System.Web.UI.WebControls.Button
End Class
