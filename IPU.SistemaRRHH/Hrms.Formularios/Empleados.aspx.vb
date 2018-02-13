Public Class Empleados
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub btnNuevoEmpleado_Click(sender As Object, e As EventArgs) Handles btnNuevoEmpleado.Click
        pListaEmpleados.Visible = False
        pNuevoEmpleado.Visible = True
    End Sub

    Private Sub btnSeleccionar_ServerClick(sender As Object, e As EventArgs) Handles btnSeleccionar.ServerClick
        btnModificarEmpleado.Visible = True
        btnInactivar.Visible = True
    End Sub

End Class