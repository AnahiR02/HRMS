Imports System
Imports System.ComponentModel
Imports System.Text.RegularExpressions
Imports Microsoft.Win32

Public Class clsConexionSQL
    Inherits clsConexionBDDBase

#Region "Rutinas de Inicializacion"

    Sub New(ByVal p_eNombreBDD As NombreBDD, ByVal p_bConectar As Boolean)
        MyBase.New()

        Try
            b_eNombreBDD = p_eNombreBDD
            b_sNombreBDD = [Enum].GetName(GetType(NombreBDD), p_eNombreBDD)

            b_eTipoConexion = TipoBDD.SQL_Server
            b_sTipoConexion = [Enum].GetName(GetType(TipoBDD), TipoBDD.SQL_Server)

            b_sServidor = "TECNOLOGIA03\IPU"
            b_sInstancia = ""
            b_sUsuario = "sa"
            b_sPassword = "INPRE09admin"
            b_sIntegratedSecurity = "false"

            Select Case p_eNombreBDD
                Case NombreBDD.Hrms_Seguridad
                    b_sCatalogo = "HRMS.Seguridad"

                Case NombreBDD.Hrms_Empleados
                    b_sCatalogo = "HRMS.Empleados"

                Case NombreBDD.Hrms_Planillas
                    b_sCatalogo = "HRMS.Planillas"


            End Select

            PrepararConnectionString()

            If p_bConectar Then
                Conectar()
            End If

        Catch ex As Exception
        End Try

    End Sub

    Sub New(ByVal p_sNombreBDD As String, ByVal p_eTipoConexion As TipoBDD, ByVal p_sConnectionString As String, ByVal p_bClaveEncriptada As Boolean, ByVal vConectar As Boolean)
        MyBase.New()

        Try
            b_sNombreBDD = p_sNombreBDD

            b_eTipoConexion = TipoBDD.SQL_Server
            b_sTipoConexion = [Enum].GetName(GetType(TipoBDD), TipoBDD.SQL_Server)

            b_sConnString = p_sConnectionString
            b_bClaveEncriptada = p_bClaveEncriptada

            ParsearConnectionString()
            PrepararConnectionString()

            If vConectar Then
                Conectar()
            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub PrepararConnectionString()
        Try

            b_sConnString = String.Format("Data Source={0};Initial Catalog={1};User Id={2};Password={3};Integrated Security={4};", b_sInstancia, b_sCatalogo, b_sUsuario, b_sPassword, If(Not b_sIntegratedSecurity = String.Empty, b_sIntegratedSecurity, "false"))

        Catch ex As Exception

        End Try

    End Sub
    Private Sub ParsearConnectionString()
        Try
            Dim regEx As New Regex("Data Source=([a-zA-Z0-9\.\-\\_])+")
            Dim match As Match = regEx.Match(b_sConnString)
            b_sInstancia = Mid(match.Value, 13)

            regEx = New Regex("Data Source=([a-zA-Z0-9\.\-_])+")
            match = regEx.Match(b_sConnString)
            b_sServidor = Mid(match.Value, 13)

            regEx = New Regex("Integrated Security=([a-zA-Z0-9.-])+;", RegexOptions.IgnoreCase)
            match = regEx.Match(b_sConnString)
            b_sIntegratedSecurity = Mid(match.Value, 21)

            regEx = New Regex("User Id=([a-zA-Z0-9\.\-_])+")
            match = regEx.Match(b_sConnString)
            b_sUsuario = Mid(match.Value, 9)

            regEx = New Regex("Password=([a-zA-Z0-9\-\+\=\/])+")
            match = regEx.Match(b_sConnString)
            b_sPassword = If(b_bClaveEncriptada, b_oEncriptador.Desencriptar(Mid(match.Value, 10)), Mid(match.Value, 10))

            regEx = New Regex("Initial Catalog=([a-zA-Z0-9\.\-_])+")
            match = regEx.Match(b_sConnString)
            b_sCatalogo = Mid(match.Value, 17)


        Catch ex As Exception

        End Try

    End Sub

#End Region

#Region "Funciones Publicas"

    Public Overrides Function Cerrar() As Boolean
        Dim bResult As Boolean = False

        Try
            If Not IsNothing(b_oConn) Then
                Data.SqlClient.SqlConnection.ClearPool(CType(b_oConn, Data.SqlClient.SqlConnection))
                b_oConn.Close()
                b_oConn.Dispose()
                b_oConn = Nothing
            End If

            bResult = True

        Catch ex As Exception

        End Try

        Return bResult

    End Function

    Public Overrides Function Conectar() As Boolean
        Dim bResult As Boolean = False

        Try
            If IsNothing(b_oConn) Then
                If b_sServidor = String.Empty Or b_sInstancia = String.Empty Or b_sCatalogo = String.Empty Then
                    Exit Try
                End If

                b_oConn = New Data.SqlClient.SqlConnection(b_sConnString)
            End If

            If (b_oConn.State = Data.ConnectionState.Closed) Then
                b_oConn.Open()
            End If

            bResult = True

        Catch ex As Exception

        End Try

        Return bResult

    End Function

    Public Overrides Function Reconectar() As Boolean
        Dim bResult As Boolean = False

        Try
            If Not IsNothing(b_oConn) Then
                b_oConn.Close()
            End If

            bResult = Conectar()

        Catch ex As Exception

        End Try

        Return bResult

    End Function

#End Region

End Class