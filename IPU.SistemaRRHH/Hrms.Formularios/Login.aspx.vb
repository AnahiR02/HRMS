Public Class Login
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub btnIniciarSesion_Click(sender As Object, e As EventArgs) Handles btnIniciarSesion.Click

        Dim bInicioValidado As Boolean = False

        Try
            If bInicioValidado = SeguridadControl.VerificarUsuario(txtUsuario.Text, txtContraseña.Text) Then

            End If


        Catch ex As Exception

        End Try




    End Sub
End Class