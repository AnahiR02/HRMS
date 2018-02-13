Imports System
Imports System.Data.Common
Imports System.ComponentModel
Imports System.Text.RegularExpressions
Imports Microsoft.Win32


Public Enum TipoBDD
    SQL_Server = 1
End Enum

Public Enum NombreBDD
    Hrms_Seguridad = 1
    Hrms_Empleados = 2
    Hrms_Planillas = 3
End Enum

Public MustInherit Class clsConexionBDDBase
    Implements IDisposable

    Private b_bDisposed As Boolean = False

    Protected b_oEncriptador As clsEncriptador = New clsEncriptador()

    Protected b_sNombreBDD As String
    Protected b_eNombreBDD As NombreBDD
    Protected b_sTipoConexion As String
    Protected b_eTipoConexion As TipoBDD
    Protected b_sConnString As String
    Protected b_bClaveEncriptada As Boolean
    Protected b_PathMDW As String

    Protected b_oConn As DbConnection = Nothing

    Protected b_sServidor As String
    Protected b_sInstancia As String
    Protected b_sCatalogo As String
    Protected b_sUsuario As String
    Protected b_sPassword As String
    Protected b_sIntegratedSecurity As String

#Region "Rutinas de Inicializacion"

    Sub New()
        Try
            'b_oConfig.Load()

            b_oConn = Nothing

        Catch ex As Exception
            '  Throw New clsExcepcion(System.Reflection.Assembly.GetExecutingAssembly.GetName.Name(), Me.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod.Name, ex.Message, ex)

        End Try

    End Sub

    Public Overloads Sub Dispose() Implements IDisposable.Dispose
        Dispose(True)
        GC.SuppressFinalize(Me)

    End Sub

    Public Overridable Overloads Sub Dispose(ByVal disposing As Boolean)
        If Not Me.b_bDisposed Then
            If disposing Then
                b_oConn.Close()
                b_oConn.Dispose()
                b_oConn = Nothing
            End If

        End If

        b_bDisposed = True

    End Sub

    Protected Overrides Sub Finalize()
        Dispose(False)
        MyBase.Finalize()

    End Sub

#End Region

#Region "Funciones Publicas"

    Public Overridable Function Cerrar() As Boolean
        Dim bResult As Boolean = False

        Return bResult

    End Function

    Public Overridable Function Conectar() As Boolean
        Dim bResult As Boolean = False

        Return bResult

    End Function

    Public Overridable Function Reconectar() As Boolean
        Dim bResult As Boolean = False

        Return bResult

    End Function

#End Region

#Region "Propiedades"

    Public ReadOnly Property AutenticacionIntegrada() As String
        Get
            Return b_sIntegratedSecurity
        End Get
    End Property

    Public ReadOnly Property Catalogo() As String
        Get
            Return b_sCatalogo
        End Get
    End Property

    Public ReadOnly Property Conectado() As Boolean
        Get
            If IsNothing(b_oConn) Then
                Return False
            Else
                Return (b_oConn.State = Data.ConnectionState.Executing) Or (b_oConn.State = Data.ConnectionState.Fetching) Or (b_oConn.State = Data.ConnectionState.Open)
            End If
        End Get
    End Property

    Public ReadOnly Property Conexion() As DbConnection
        Get
            Return b_oConn
        End Get
    End Property

    Public ReadOnly Property Instancia() As String
        Get
            Return b_sInstancia
        End Get
    End Property

    Public ReadOnly Property NombreBaseDatos() As String
        Get
            Return b_sNombreBDD
        End Get
    End Property

    Public ReadOnly Property Password() As String
        Get
            Return b_sPassword
        End Get
    End Property

    Public ReadOnly Property Servidor() As String
        Get
            Return b_sServidor
        End Get
    End Property

    Public ReadOnly Property TipoConexion() As String
        Get
            Return b_sTipoConexion
        End Get
    End Property

    Public ReadOnly Property Usuario() As String
        Get
            Return b_sUsuario
        End Get
    End Property

#End Region

End Class
