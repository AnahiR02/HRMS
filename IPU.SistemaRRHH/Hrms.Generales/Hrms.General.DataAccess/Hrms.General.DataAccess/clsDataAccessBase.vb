Imports System.Data
Imports System.Data.Common

Public Class clsDataAccessBase
    Implements IDisposable

    Private b_bDisposed As Boolean = False

    Protected b_sTipoConexion As String
    Protected b_oConexionBDD As clsConexionBDD
    Protected b_oDA As DbDataAdapter
    Protected b_oCommand As DbCommand
    Protected b_oDS As DataSet
    Protected b_oParam As DbParameter

    Protected b_DALock As New Object

#Region "Rutinas de Inicialización"

    Sub New(ByVal p_oConexionBDD As clsConexionBDD)
        Try
            b_oConexionBDD = p_oConexionBDD
            b_sTipoConexion = b_oConexionBDD.TipoConexion

            'If Not b_oConexionBDD.Conectado Then
            '  b_oConexionBDD.Reconectar()
            'End If

        Catch ex As Exception

        End Try

    End Sub

    Public Overloads Sub Dispose() Implements IDisposable.Dispose
        Dispose(True)
        GC.SuppressFinalize(Me)

    End Sub

    Public Overridable Overloads Sub Dispose(ByVal p_bDisposing As Boolean)
        If Not Me.b_bDisposed Then
            If p_bDisposing Then
                b_oParam = Nothing

                b_oDS.Dispose()
                b_oDS = Nothing

                b_oCommand.Dispose()
                b_oCommand = Nothing

                b_oDA.Dispose()
                b_oDA = Nothing
            End If
        End If

        b_bDisposed = True

    End Sub

    Protected Overrides Sub Finalize()
        Dispose(False)
        MyBase.Finalize()

    End Sub

#End Region

#Region "Propiedades"

    Public ReadOnly Property ConexionBDD() As clsConexionBDD
        Get
            Return b_oConexionBDD
        End Get
    End Property

    Public ReadOnly Property TipoConexion() As String
        Get
            Return b_sTipoConexion
        End Get
    End Property

#End Region

#Region "Rutinas de BDD"

    Protected Overridable Sub PrepararComandos()

    End Sub

    Public Overridable Function Buscar(ByVal strSql As String, ByVal strTabla As String) As DataSet
        Return b_oDS

    End Function
    Public Overridable Function Buscar(ByVal strSql As String, ByVal strTabla As String, ByRef ds As DataSet) As Boolean
        Dim bReturn As Boolean = False

        Return bReturn

    End Function
    Public Overridable Function Buscar(ByVal strSql As String, ByVal strTabla As String, ByRef ds As DataSet, ByVal iTimeout As Integer) As Boolean
        Dim bReturn As Boolean = False

        Return bReturn

    End Function

    Public Overridable Function BuscarRegistro(ByVal strSql As String, ByVal strTabla As String) As DataRow
        Dim dr As DataRow = Nothing

        Return dr

    End Function

    Public Overridable Function ObtenerDecimal(ByVal strSql As String) As Decimal
        Dim dResult As Decimal = 0

        Return dResult

    End Function
    Public Overridable Function ObtenerDato(ByVal strSql As String) As String
        Dim sResult As String = String.Empty

        Return sResult

    End Function

    Public Overridable Function ObtenerDateTime() As DateTime
        Dim tResult As DateTime = Nothing

        Return tResult

    End Function

    Public Overridable Function ObtenerDataView(ByVal strSql As String, ByVal strTabla As String) As DataView
        Dim dv As DataView = Nothing

        Return dv

    End Function

    Public Overridable Function Relacionar(ByVal strSQL1 As String, ByVal strTabla1 As String, ByVal aColumnas1 As String, ByVal strSQL2 As String, ByVal strTabla2 As String, ByVal aColumnas2 As String, ByVal strRelacion As String) As DataSet
        Return b_oDS

    End Function
    Public Overridable Function Relacionar(ByVal strTabla1 As String, ByVal aColumnas1 As String, ByVal strTabla2 As String, ByVal aColumnas2 As String, ByVal strRelacion As String, ByRef ds As DataSet) As Boolean
        Dim bReturn As Boolean = False

        Return bReturn

    End Function
    Public Overridable Function Relacionar(ByVal strTabla1 As String, ByVal aColumnas1() As DataColumn, ByVal strTabla2 As String, ByVal aColumnas2() As DataColumn, ByVal strRelacion As String, ByRef ds As DataSet) As Boolean
        Dim bReturn As Boolean = False

        Return bReturn

    End Function

    Public Overridable Function Registrar(ByVal strSql As String) As Boolean
        Dim bResult As Boolean = False

        Return bResult

    End Function
    Public Overridable Function Registrar(ByVal strSql As String, ByVal iTimeout As Integer) As Boolean
        Dim bResult As Boolean = False

        Return bResult

    End Function
    Public Overridable Function Registrar(ByVal strSql As String, ByVal paramImagen() As Byte) As Boolean
        Dim bResult As Boolean = False

        Return bResult

    End Function

    Public Overridable Function CompactarBDD() As Boolean
        Dim bReturn As Boolean = False

        Return bReturn

    End Function

    Public Overridable Function RespaldarBDD(ByVal sLocation As String) As Boolean
        Dim bReturn As Boolean = False

        Return bReturn

    End Function

    Public Overridable Function RestaurarBDD(ByVal sSource As String, ByVal sLocation As String, ByVal bRename As Boolean) As Boolean
        Dim bReturn As Boolean = False

        Return bReturn

    End Function

    Public Overridable Function TruncarLogBDD() As Boolean
        Dim bReturn As Boolean = False

        Return bReturn

    End Function

#End Region
End Class
