Public Class Login
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub btnIniciarSesion_Click(sender As Object, e As EventArgs) Handles btnIniciarSesion.Click

        Dim bInicioValidado As Boolean = False

        Try
            bInicioValidado = SeguridadControl.VerificarUsuario(txtUsuario.Text, txtContraseña.Text)

            'If bInicioValidado Then
            'Verfica los accesos a los modulos.
            ' bInicioValidado = IIf(SeguridadControl.VerificarPrivilegio(c_sPrivilegioCodeCuenta) Or SeguridadControl.VerificarPrivilegio(c_sPrivilegioCodeConfiguracion) Or SeguridadControl.VerificarPrivilegio(c_sPrivilegioCodeCaptura) Or SeguridadControl.VerificarPrivilegio(c_sPrivilegioCodeMaster) Or SeguridadControl.VerificarPrivilegio(c_sPrivilegioCodePublicacion) Or SeguridadControl.VerificarPrivilegio(c_sPrivilegioCodeConsulta), True, False)
            'End If

            If bInicioValidado Then

                MsgBox(bInicioValidado)

                '    lblAcceso.BackColor = Color.LightGreen
                '    lblAcceso.ForeColor = Color.Black
                '    lblAcceso.Text = g_sMensajeAcceso
                '    Application.DoEvents()

                '    Threading.Thread.Sleep(1000)

                '    Me.DialogResult = System.Windows.Forms.DialogResult.OK

                '    Me.Close()
                'Else
                '    lblAcceso.BackColor = Color.Red
                '    lblAcceso.ForeColor = Color.White
                '    lblAcceso.Text = SeguridadControl.Mensaje
                '    Application.DoEvents()
                '    tbxUsuarioNombre.SelectAll()
                '    tbxUsuarioClave.Text = String.Empty
                '    tbxUsuarioNombre.Focus()
                'End If
                'Else
                'If SeguridadControl.ActivarTerminal(tbxCodigo.Text, tbxLlave.Text) Then
                '    lblAcceso.BackColor = Color.LightGreen
                '    lblAcceso.ForeColor = Color.Black
                '    lblAcceso.Text = g_sMensajeTerminal
                '    Application.DoEvents()

                '    Threading.Thread.Sleep(1000)

                '    IniciarLogIn()
                'Else
                '    lblAcceso.BackColor = Color.Red
                '    lblAcceso.ForeColor = Color.White
                '    lblAcceso.Text = SeguridadControl.Mensaje
                '    Application.DoEvents()
                '    tbxLlave.Text = String.Empty
                '    tbxLlave.Focus()
                'End If
            End If

        Catch ex As Exception

        End Try




    End Sub
End Class