Imports System.IO
Imports System.Security.Cryptography
Imports System.Threading
Imports Hrms.General.DataAccess

Module modSeguridad

    Private c_oDataAccess As clsDataAccess
    Private c_dsData As DataSet = New DataSet
    Private c_oConexionBDD As clsConexionBDD
    Private g_oSeguridadControl As clsSeguridadControl
    Private c_oSeguridad As clsEncriptador = New clsEncriptador()

    Public Class clsSeguridadControl

        Private Enum ActualizarUsuario
            Entrada = 1
            Clave = 2
            Bloqueo = 3
        End Enum

        Private c_sUsuarioId As String = Nothing
        Private c_sUsuarioNombre As String = Nothing
        Private c_sUsuarioNombreCompleto As String = Nothing
        Private c_sUsuarioClave As String = Nothing
        Private c_bUsuarioMultiUbicacion As Boolean = False
        Private c_bUsuarioBloqueado As Boolean = False
        Private c_sPrivilegioCodigo As String() = Nothing

        Private c_iClaveMaxIntentoInvalido As Integer = 0
        Private c_sIntentosUsuario As String = String.Empty
        Private c_iIntentosInvalidos As Integer = 0


        Private c_sSeleccionarUsuarioPorNombre As String = "SELECT * FROM Usuarios WHERE UsuarioNombre = '@UsuarioNombre'"
        ' Private c_sSeleccionarPrivilegios As String = "SELECT PrivilegioCodigo FROM Privilegios WHERE PrivilegioId IN (SELECT DISTINCT RP.PrivilegioId FROM RolesPrivilegios RP INNER JOIN UsuariosRoles UR On UR.RolId = RP.RolId WHERE UR.UsuarioId = '@UsuarioId') ORDER BY PrivilegioCodigo"
        Private c_sActualizarUsuarioEntrada As String = "UPDATE Usuarios SET UsuarioFechaUltimaEntrada = GETDATE() WHERE UsuarioId = '@UsuarioId'"
        Private c_sActualizarUsuarioClave As String = "UPDATE Usuarios SET UsuarioClave = '@UsuarioClave', UsuarioFechaUltimoCambioClave = GETDATE() WHERE UsuarioId = '@UsuarioId'"
        Private c_sActualizarUsuarioBloqueo As String = "UPDATE Usuarios SET UsuarioBloqueado = @UsuarioBloqueado, UsuarioFechaUltimoBloqueo = GETDATE() WHERE UsuarioId = '@UsuarioId'"


        Private c_sMensaje = String.Empty
        Private c_sErrorUsuarioDB As String = "El usuario no fue encontrado."
        Private c_sErrorUsuarioIntentos As String = "Número de intentos excedido."
        Private c_sErrorUsuarioClaveIncorrecta As String = "La clave del usuario es incorrecta."
        Private c_sErrorUsuarioBloqueo As String = "El usuario se encuentra bloqueado."
        Private c_sErrorClaveMinLongitud As String = "La clave debe tener como mínimo {0} caracteres."
        Private c_sErrorClaveMinNoAlfaNumerico As String = "La clave debe tener como mínimo {0} caracteres que no sea alfanuméricos."
        Private c_sErrorPrivilegioInsuficiente As String = "No tiene privilegios suficientes."
        Private c_sMensajePreguntarPor As String = "Pregunte al administrador del sistema."

        Public Function VerificarUsuario(ByVal p_sUsuarioNombre As String, ByVal p_sUsuarioClave As String) As Boolean

            Dim bResultado As Boolean = False
            Dim sCommand As String

            If c_sIntentosUsuario <> p_sUsuarioNombre Then
                c_iIntentosInvalidos = 1
            Else
                c_iIntentosInvalidos += 1
            End If

            If c_iIntentosInvalidos <= c_iClaveMaxIntentoInvalido Then

                Try

                    VerificarDataAccess()

                    sCommand = c_sSeleccionarUsuarioPorNombre
                    sCommand = sCommand.Replace("@UsuarioNombre", p_sUsuarioNombre)

                    ' Buscar Usuario
                    Monitor.Enter(c_oDataAccess)
                    If Not IsNothing(c_dsData.Tables("Usuarios")) Then
                        c_dsData.Tables("Usuarios").Clear()
                    End If
                    c_oDataAccess.Buscar(sCommand, "Usuarios", c_dsData)
                    Monitor.Exit(c_oDataAccess)
                    ' Fin Buscar Usuario

                    If c_dsData.Tables("Usuarios").Rows.Count > 0 Then
                        c_sUsuarioId = c_dsData.Tables("Usuarios").Rows(0)("UsuarioId").ToString()
                        c_sIntentosUsuario = c_dsData.Tables("Usuarios").Rows(0)("UsuarioNombre")
                        If c_oSeguridad.Desencriptar(c_dsData.Tables("Usuarios").Rows(0)("UsuarioClave")) = p_sUsuarioClave Then
                            If Not CBool(c_dsData.Tables("Usuarios").Rows(0)("UsuarioBloqueado")) Then

                                ' Guardar información del usuario en memoria.
                                c_sUsuarioNombre = c_dsData.Tables("Usuarios").Rows(0)("UsuarioNombre")
                                c_sUsuarioNombreCompleto = c_dsData.Tables("Usuarios").Rows(0)("UsuarioNombreCompleto")
                                c_sUsuarioClave = c_oSeguridad.Desencriptar(c_dsData.Tables("Usuarios").Rows(0)("UsuarioClave"))
                                c_bUsuarioBloqueado = c_dsData.Tables("Usuarios").Rows(0)("UsuarioBloqueado")
                                ' Fin guardar información del Usuario en memoria.

                                'sCommand = c_sSeleccionarPrivilegios
                                'sCommand = sCommand.Replace("@UsuarioId", c_sUsuarioId.ToString())
                                '
                                '' Buscar privilegios del usuario.
                                'Monitor.Enter(c_oDataAccess)
                                'If Not IsNothing(c_dsData.Tables("Privilegios")) Then
                                '    c_dsData.Tables("Privilegios").Clear()
                                'End If
                                'c_oDataAccess.Buscar(sCommand, "Privilegios", c_dsData)
                                'Monitor.Exit(c_oDataAccess)
                                '' Fin buscar privilegios del usuario.
                                '
                                'If c_dsData.Tables("Privilegios").Rows.Count > 0 Then
                                '    ' Guardar información privilegios del usuario en memoria.
                                '    Dim pos As Integer = 0
                                '    ReDim c_sPrivilegioCodigo(c_dsData.Tables("Privilegios").Rows.Count - 1)
                                '    For Each drPrivilegio As DataRow In c_dsData.Tables("Privilegios").Rows
                                '        c_sPrivilegioCodigo(pos) = drPrivilegio("PrivilegioCodigo")
                                '        pos += 1
                                '    Next
                                '    ' Fin guardar información privilegios del usuario en memoria.
                                'End If

                                ' Actualiza el campo "UsuarioFechaUltimaEntrada" de la tabla de Usuarios
                                ActualizarUsuarioData(ActualizarUsuario.Entrada)

                                bResultado = True
                            Else
                                c_sMensaje = PrepararMensaje(c_sErrorUsuarioBloqueo, False)
                            End If
                        Else
                            c_sMensaje = PrepararMensaje(c_sErrorUsuarioClaveIncorrecta, False)
                        End If
                    Else
                        c_sMensaje = PrepararMensaje(c_sErrorUsuarioDB, False)
                    End If

                Catch ex As Exception

                End Try

            Else
                ' Actualiza los campos "UsuarioBloqueado" y "UsuarioFechaUltimoBloqueo" de la tabla de Usuarios.
                ActualizarUsuarioData(ActualizarUsuario.Bloqueo, True, c_sErrorUsuarioIntentos)

                c_sMensaje = PrepararMensaje(c_sErrorUsuarioIntentos, False)
            End If

            Return bResultado

        End Function

        Private Sub ActualizarUsuarioData(ByVal p_eActualizar As ActualizarUsuario, ByVal ParamArray p_aParametros As Object())
            Dim sCommand As String = String.Empty
            Dim tFechaServidor As DateTime = Nothing

            Try
                VerificarDataAccess()

                Select Case p_eActualizar
                    Case ActualizarUsuario.Entrada
                        sCommand = c_sActualizarUsuarioEntrada
                    Case ActualizarUsuario.Clave
                        sCommand = c_sActualizarUsuarioClave
                        sCommand = sCommand.Replace("@UsuarioClave", CStr(p_aParametros(0)))
                    Case ActualizarUsuario.Bloqueo
                        sCommand = c_sActualizarUsuarioBloqueo
                        sCommand = sCommand.Replace("@UsuarioBloqueado", IIf(CBool(p_aParametros(0)), 1, 0))
                End Select
                sCommand = sCommand.Replace("@UsuarioId", c_sUsuarioId.ToString())

                Monitor.Enter(c_oDataAccess)
                c_oDataAccess.Registrar(sCommand)
                Monitor.Exit(c_oDataAccess)

            Catch ex As Exception

            End Try

        End Sub

        Private Function PrepararMensaje(ByVal p_sMensaje As String, ByVal p_bPreguntarPor As Boolean, ByVal ParamArray p_aParametros As Object()) As String
            p_sMensaje = String.Format(p_sMensaje, p_aParametros)

            If p_bPreguntarPor Then
                Return String.Format("{0} {1}", p_sMensaje, c_sMensajePreguntarPor)
            Else
                Return String.Format("{0}", p_sMensaje)
            End If

        End Function

    End Class


    NotInheritable Class clsEncriptar
        Private c_sClaveBase As String = "pass75dc@avz10"
        Private c_sClaveBase2 As String = "avz10@pass75dc"
        Private c_sValorSalt As String = "s@lAvz13"
        Private c_iIteraciones As Integer = 1
        Private c_sVectorInit As String = "@1B2c3D4e5F6g7H8"
        Private c_iLongitudLlave As Integer = 128

        Public Function Encriptar(ByVal p_sTextoParaEncriptar As String, Optional ByVal p_bClaveBase2 As Boolean = False) As String
            Dim bytesVectorInit As Byte() = Encoding.ASCII.GetBytes(c_sVectorInit)
            Dim bytesValorSalt As Byte() = Encoding.ASCII.GetBytes(c_sValorSalt)
            Dim bytesTextoPlano As Byte() = Encoding.UTF8.GetBytes(p_sTextoParaEncriptar)

            Dim password As Rfc2898DeriveBytes = New Rfc2898DeriveBytes(If(p_bClaveBase2, c_sClaveBase2, c_sClaveBase), bytesValorSalt, c_iIteraciones)
            Dim keyBytes As Byte() = password.GetBytes(c_iLongitudLlave / 8)
            Dim symmetricKey As RijndaelManaged = New RijndaelManaged()
            symmetricKey.Mode = CipherMode.CBC
            Dim encryptor As ICryptoTransform = symmetricKey.CreateEncryptor(keyBytes, bytesVectorInit)
            Dim memoryStream As MemoryStream = New MemoryStream()
            Dim cryptoStream As CryptoStream = New CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write)

            cryptoStream.Write(bytesTextoPlano, 0, bytesTextoPlano.Length)
            cryptoStream.FlushFinalBlock()

            Dim bytesTextoCifrado As Byte() = memoryStream.ToArray()

            memoryStream.Close()
            cryptoStream.Close()

            Dim sTextoCifrado As String = Convert.ToBase64String(bytesTextoCifrado)

            Return sTextoCifrado

        End Function

        Public Function Desencriptar(ByVal p_sTextoEncriptado As String, Optional ByVal p_bClaveBase2 As Boolean = False) As String
            Dim bytesVectorInit As Byte() = Encoding.ASCII.GetBytes(c_sVectorInit)
            Dim bytesValorSalt As Byte() = Encoding.ASCII.GetBytes(c_sValorSalt)
            Dim bytesTextoCifrado As Byte() = Convert.FromBase64String(p_sTextoEncriptado)

            Dim password As Rfc2898DeriveBytes = New Rfc2898DeriveBytes(If(p_bClaveBase2, c_sClaveBase2, c_sClaveBase), bytesValorSalt, c_iIteraciones)
            Dim keyBytes As Byte() = password.GetBytes(c_iLongitudLlave / 8)
            Dim symmetricKey As RijndaelManaged = New RijndaelManaged()
            symmetricKey.Mode = CipherMode.CBC
            Dim decryptor As ICryptoTransform = symmetricKey.CreateDecryptor(keyBytes, bytesVectorInit)
            Dim memoryStream As MemoryStream = New MemoryStream(bytesTextoCifrado)
            Dim cryptoStream As CryptoStream = New CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read)
            Dim bytesTextoPlano As Byte()
            ReDim bytesTextoPlano(bytesTextoCifrado.Length)
            Dim decryptedByteCount As Integer = cryptoStream.Read(bytesTextoPlano, 0, bytesTextoPlano.Length)

            memoryStream.Close()
            cryptoStream.Close()

            Dim sTextoPlano As String = Encoding.UTF8.GetString(bytesTextoPlano, 0, decryptedByteCount)

            Return sTextoPlano

        End Function

    End Class

    Private Sub VerificarDataAccess()
        Try

            If IsNothing(c_oDataAccess) Then
                c_oDataAccess = New clsDataAccess(c_oConexionBDD)
            End If

        Catch ex As Exception

        End Try

    End Sub

    Public ReadOnly Property SeguridadControl As clsSeguridadControl
        Get
            Return g_oSeguridadControl
        End Get
    End Property

End Module
