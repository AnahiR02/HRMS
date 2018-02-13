Public Class Planillas1
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click


        Try

            Select Case ddlTipoPlanilla.SelectedIndex

                Case 1
                    Response.Redirect("Planillas.EmpleadosPermanentes.aspx")
                Case 2
                    Response.Redirect("Planillas.EmpleadosContrato.aspx")
                Case 3
                    Response.Redirect("Planillas.SIREP.aspx")
                Case 4
                    Response.Redirect("Planillas.INJUPEMP.aspx")
                Case 5
                    Response.Redirect("Planillas.IAIPPermanentes.aspx")
                Case 6
                    Response.Redirect("Planillas.IAIPContrato.aspx")
            End Select



        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnCancelarCambios_Click(sender As Object, e As EventArgs) Handles btnCancelarCambios.Click
        pPlanillas.Visible = True
        pConfiguracionesAvanzadas.Visible = False
    End Sub

    Private Sub btnConfigAvanzadas_ServerClick(sender As Object, e As EventArgs) Handles btnConfigAvanzadas.ServerClick
        pPlanillas.Visible = False
        pConfiguracionesAvanzadas.Visible = True
    End Sub

End Class