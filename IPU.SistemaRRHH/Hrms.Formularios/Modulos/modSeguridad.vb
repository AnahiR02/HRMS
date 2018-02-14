Module modSeguridad

    Public Class clsSeguridadControl

        Private c_sIntentosUsuario As String = String.Empty

        Public Function VerificarUsuario(ByVal p_sUsuarioNombre As String, ByVal p_sUsuarioClave As String) As Boolean

            Dim bResultado As Boolean = False
            Dim sCommand As String

            If c_sIntentosUsuario <> p_sUsuarioNombre Then
                '  c_iIntentosInvalidos = 1
            Else
                ' c_iIntentosInvalidos += 1
            End If

            Try

            Catch ex As Exception

            End Try




            'If c_iIntentosInvalidos <= c_iClaveMaxIntentoInvalido Then

            '    Try
            '        VerificarDataAccess()

            '        sCommand = c_sSeleccionarUsuarioPorNombre
            '        sCommand = sCommand.Replace("@UsuarioNombre", p_sUsuarioNombre)

            '        ' Buscar el Usuario
            '        Monitor.Enter(c_oDataAccess)
            '        If Not IsNothing(c_dsData.Tables("Usuarios")) Then
            '            c_dsData.Tables("Usuarios").Clear()
            '        End If
            '        c_oDataAccess.Buscar(sCommand, "Usuarios", c_dsData)
            '        Monitor.Exit(c_oDataAccess)
            '        ' Termina buscar el Usuario

            '        If c_dsData.Tables("Usuarios").Rows.Count > 0 Then
            '            c_sUsuarioId = c_dsData.Tables("Usuarios").Rows(0)("UsuarioId").ToString()
            '            c_sIntentosUsaurio = c_dsData.Tables("Usuarios").Rows(0)("UsuarioNombre")
            '            If c_oSeguridad.Desencriptar(c_dsData.Tables("Usuarios").Rows(0)("UsuarioClave")) = p_sUsuarioClave Then
            '                If Not CBool(c_dsData.Tables("Usuarios").Rows(0)("UsuarioBloqueado")) Then
            '                    ' Guardar información del Usaurio en memoria
            '                    c_sUsuarioNombre = c_dsData.Tables("Usuarios").Rows(0)("UsuarioNombre")
            '                    c_sUsuarioNombreCompleto = c_dsData.Tables("Usuarios").Rows(0)("UsuarioNombreCompleto")
            '                    c_sUsuarioClave = c_oSeguridad.Desencriptar(c_dsData.Tables("Usuarios").Rows(0)("UsuarioClave"))
            '                    c_bUsuarioMultiUbicacion = c_dsData.Tables("Usuarios").Rows(0)("UsuarioMultiUbicacion")
            '                    c_bUsuarioBloqueado = c_dsData.Tables("Usuarios").Rows(0)("UsuarioBloqueado")
            '                    ' Termina guardar información del Usaurio en memoria

            '                    sCommand = c_sSeleccionarPrivilegios
            '                    sCommand = sCommand.Replace("@UsuarioId", c_sUsuarioId.ToString())

            '                    ' Buscar los Privilegios del Usuario
            '                    Monitor.Enter(c_oDataAccess)
            '                    If Not IsNothing(c_dsData.Tables("Privilegios")) Then
            '                        c_dsData.Tables("Privilegios").Clear()
            '                    End If
            '                    c_oDataAccess.Buscar(sCommand, "Privilegios", c_dsData)
            '                    Monitor.Exit(c_oDataAccess)
            '                    ' Termina buscar los Privilegios del Usuario

            '                    If c_dsData.Tables("Privilegios").Rows.Count > 0 Then
            '                        ' Guardar información de los Privilegios del Usaurio en memoria
            '                        Dim pos As Integer = 0
            '                        ReDim c_sPrivilegioCodigo(c_dsData.Tables("Privilegios").Rows.Count - 1)
            '                        For Each drPrivilegio As DataRow In c_dsData.Tables("Privilegios").Rows
            '                            c_sPrivilegioCodigo(pos) = drPrivilegio("PrivilegioCodigo")
            '                            pos += 1
            '                        Next
            '                        ' Termina guardar información de los Privilegios del Usaurio en memoria
            '                    End If

            '                    ' Actualiza el campo "UsuarioFechaUltimaEntrada" de la tabla de Usuarios
            '                    ActualizarUsuarioData(ActualizarUsuario.Entrada)

            '                    bResultado = True
            '                Else
            '                    c_sMensaje = PrepararMensaje(c_sErrorUsuarioBloqueo, False)
            '                End If
            '            Else
            '                c_sMensaje = PrepararMensaje(c_sErrorUsuarioClaveIncorrecta, False)
            '            End If
            '        Else
            '            c_sMensaje = PrepararMensaje(c_sErrorUsuarioDB, False)
            '        End If

            '    Catch ex As Exception

            '    End Try

            'Else
            '    ' Actualiza los campos "UsuarioBloqueado", "UsuarioFechaUltimoBloqueo" y "UsuarioComentarioUltimoBloqueo" de la tabla de Usuarios
            '    ActualizarUsuarioData(ActualizarUsuario.Bloqueo, True, c_sErrorUsuarioIntentos)

            '    c_sMensaje = PrepararMensaje(c_sErrorUsuarioIntentos, False)
            'End If

            Return bResultado

        End Function

    End Class





    Private g_oSeguridadControl As clsSeguridadControl

    Public ReadOnly Property SeguridadControl As clsSeguridadControl
        Get
            Return g_oSeguridadControl
        End Get
    End Property

End Module
