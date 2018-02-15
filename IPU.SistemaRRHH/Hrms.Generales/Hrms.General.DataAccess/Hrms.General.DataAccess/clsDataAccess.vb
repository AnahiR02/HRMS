Imports System.Data

Public Class clsDataAccess
    Implements IDisposable

    Private c_bDisposed As Boolean = False
    Private c_oDataAccess As clsDataAccessBase


#Region "Rutinas de Inicialización"

    Sub New(ByVal vConexionBDD As clsConexionBDD)
        Try
            Select Case vConexionBDD.TipoConexion
                Case "SQL_Server"
                    c_oDataAccess = New clsDataAccessSQL(vConexionBDD)
                Case Else
            End Select

        Catch ex As Exception

        End Try

    End Sub

    Public Overloads Sub Dispose() Implements IDisposable.Dispose
        Dispose(True)
        GC.SuppressFinalize(Me)

    End Sub

    Public Overridable Overloads Sub Dispose(ByVal disposing As Boolean)
        If Not Me.c_bDisposed Then
            If disposing Then
                'aqui se dispose los managed resources
                c_oDataAccess = Nothing
            End If

            'aqui se dispose los unmanaged resources
        End If

        c_bDisposed = True

    End Sub

    Protected Overrides Sub Finalize()
        Dispose(False)
        MyBase.Finalize()

    End Sub

#End Region

#Region "Propiedades"

    Public ReadOnly Property ConexionBDD() As clsConexionBDD
        Get
            Return c_oDataAccess.ConexionBDD
        End Get
    End Property

    Public ReadOnly Property TipoConexion() As String
        Get
            Return c_oDataAccess.TipoConexion
        End Get
    End Property

#End Region

#Region "Rutinas de BDD"

    Public Function Buscar(ByVal strSql As String, ByVal strTabla As String) As DataSet
        Dim ds As DataSet = Nothing

        Try

            ds = c_oDataAccess.Buscar(strSql, strTabla)

        Catch ex As Exception

        End Try

        Return ds

    End Function
    Public Function Buscar(ByVal strSql As String, ByVal strTabla As String, ByRef ds As DataSet) As Boolean
        Dim bReturn As Boolean = False

        Try

            bReturn = c_oDataAccess.Buscar(strSql, strTabla, ds)

        Catch ex As Exception

        End Try

        Return bReturn
    End Function

    Public Function Buscar(ByVal strSql As String, ByVal strTabla As String, ByRef ds As DataSet, ByVal iTimeout As Integer) As Boolean
        Dim bReturn As Boolean = False

        Try
            bReturn = c_oDataAccess.Buscar(strSql, strTabla, ds, iTimeout)
        Catch ex As Exception

        End Try

        Return bReturn
    End Function

    Public Function BuscarRegistro(ByVal strSql As String, ByVal strTabla As String) As DataRow
        Dim dr As DataRow = Nothing

        Try
            dr = c_oDataAccess.BuscarRegistro(strSql, strTabla)
        Catch ex As Exception

        End Try



        Return dr
    End Function

    Public Function ObtenerDecimal(ByVal strSql As String) As Decimal
        Dim dResult As Decimal = 0

        Try
            dResult = c_oDataAccess.ObtenerDecimal(strSql)
        Catch ex As Exception

        End Try

        Return dResult
    End Function
    Public Function ObtenerDato(ByVal strSql As String) As String
        Dim sResult As String = String.Empty


        Try
            sResult = c_oDataAccess.ObtenerDato(strSql)

        Catch ex As Exception

        End Try

        Return sResult
    End Function

    Public Function ObtenerDateTime() As DateTime
        Dim tResult As DateTime = Nothing

        Try
            tResult = c_oDataAccess.ObtenerDateTime()
        Catch ex As Exception

        End Try

        Return tResult
    End Function

    Public Function ObtenerDataView(ByVal strSql As String, ByVal strTabla As String) As DataView
        Dim dv As DataView = Nothing

        Try
            dv = c_oDataAccess.ObtenerDataView(strSql, strTabla)
        Catch ex As Exception

        End Try

        Return dv
    End Function

    Public Function Relacionar(ByVal strSQL1 As String, ByVal strTabla1 As String, ByVal aColumnas1 As String, ByVal strSQL2 As String, ByVal strTabla2 As String, ByVal aColumnas2 As String, ByVal strRelacion As String) As DataSet
        Dim ds As DataSet = Nothing

        Try
            ds = c_oDataAccess.Relacionar(strSQL1, strTabla1, aColumnas1, strSQL2, strTabla2, aColumnas2, strRelacion)
        Catch ex As Exception

        End Try

        Return ds
    End Function
    Public Function Relacionar(ByVal strTabla1 As String, ByVal aColumnas1 As String, ByVal strTabla2 As String, ByVal aColumnas2 As String, ByVal strRelacion As String, ByRef ds As DataSet) As Boolean
        Dim bReturn As Boolean = False

        Try
            bReturn = c_oDataAccess.Relacionar(strTabla1, aColumnas1, strTabla2, aColumnas2, strRelacion, ds)
        Catch ex As Exception

        End Try

        Return bReturn
    End Function
    Public Function Relacionar(ByVal strTabla1 As String, ByVal aColumnas1() As DataColumn, ByVal strTabla2 As String, ByVal aColumnas2() As DataColumn, ByVal strRelacion As String, ByRef ds As DataSet) As Boolean
        Dim bReturn As Boolean = False

        Try
            bReturn = c_oDataAccess.Relacionar(strTabla1, aColumnas1, strTabla2, aColumnas2, strRelacion, ds)
        Catch ex As Exception

        End Try

        Return bReturn
    End Function

    Public Function Registrar(ByVal strSql As String) As Boolean
        Dim bResult As Boolean = False

        Try
            bResult = c_oDataAccess.Registrar(strSql)
        Catch ex As Exception

        End Try

        Return bResult
    End Function
    Public Function Registrar(ByVal strSql As String, ByVal iTimeout As Integer) As Boolean
        Dim bResult As Boolean = False

        Try
            bResult = c_oDataAccess.Registrar(strSql, iTimeout)
        Catch ex As Exception

        End Try

        Return bResult
    End Function
    Public Function Registrar(ByVal strSql As String, ByVal paramImagen() As Byte) As Boolean
        Dim bResult As Boolean = False

        Try
            bResult = c_oDataAccess.Registrar(strSql, paramImagen)
        Catch ex As Exception

        End Try

        Return bResult
    End Function

    Public Function CompactarBDD() As Boolean
        Dim bReturn As Boolean = False

        Try
            bReturn = c_oDataAccess.CompactarBDD
        Catch ex As Exception

        End Try

        Return bReturn
    End Function

    Public Overridable Function TruncarLogBDD() As Boolean
        Dim bReturn As Boolean = False

        Try
            bReturn = c_oDataAccess.TruncarLogBDD()
        Catch ex As Exception

        End Try

        Return bReturn
    End Function

    Public Function RespaldarBDD(ByVal sLocation As String) As Boolean
        Dim bReturn As Boolean = False

        Try
            bReturn = c_oDataAccess.RespaldarBDD(sLocation)

        Catch ex As Exception

        End Try

        Return bReturn
    End Function

    Public Function RestaurarBDD(ByVal sSource As String, ByVal sLocation As String, Optional ByVal bRename As Boolean = False) As Boolean
        Dim bReturn As Boolean = False

        Try
            bReturn = c_oDataAccess.RestaurarBDD(sSource, sLocation, bRename)
        Catch ex As Exception

        End Try

        Return bReturn
    End Function

#End Region


End Class
