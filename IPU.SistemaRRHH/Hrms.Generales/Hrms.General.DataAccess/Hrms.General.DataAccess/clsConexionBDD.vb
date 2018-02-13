Imports System.Data.Common
Imports System.Runtime.InteropServices
Imports System.Threading
Imports Microsoft.Win32


Public Class clsConexionBDD
    Implements IDisposable

    Private c_bDisposed As Boolean = False
    Private c_oConexion As clsConexionBDDBase


#Region "Rutinas de Inicializacion"

    Sub New(ByVal p_eNombreBDD As NombreBDD, Optional ByVal p_bConectar As Boolean = True)

        Try
            c_oConexion = New clsConexionSQL(p_eNombreBDD, p_bConectar)

        Catch ex As Exception

        End Try


    End Sub

    Sub New(ByVal p_sNombreBDD As String, ByVal p_eTipoConexion As TipoBDD, ByVal p_sConnectionString As String, ByVal p_bClaveEncriptada As Boolean, Optional ByVal p_bConectar As Boolean = True)
        Try

            Select Case p_eTipoConexion
                Case TipoBDD.SQL_Server
                    c_oConexion = New clsConexionSQL(p_sNombreBDD, p_eTipoConexion, p_sConnectionString, p_bClaveEncriptada, p_bConectar)
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
                c_oConexion = Nothing
            End If
        End If

        c_bDisposed = True

    End Sub

    Protected Overrides Sub Finalize()
        Dispose(False)
        MyBase.Finalize()

    End Sub

#End Region

#Region "Propiedades"

    Public ReadOnly Property Conectado() As Boolean
        Get
            If IsNothing(c_oConexion) Then
                Return False
            Else
                Return c_oConexion.Conectado
            End If
        End Get
    End Property

    Public ReadOnly Property Conexion() As DbConnection
        Get
            If IsNothing(c_oConexion) Then
                Return Nothing
            Else
                Return c_oConexion.Conexion
            End If
        End Get
    End Property

    Public ReadOnly Property TipoConexion() As String
        Get
            If IsNothing(c_oConexion) Then
                Return ""
            Else
                Return c_oConexion.TipoConexion
            End If
        End Get
    End Property
    Public ReadOnly Property Servidor() As String
        Get
            If IsNothing(c_oConexion) Then
                Return ""
            Else
                Return c_oConexion.Servidor
            End If
        End Get
    End Property
    Public ReadOnly Property Instancia() As String
        Get
            If IsNothing(c_oConexion) Then
                Return ""
            Else
                Return c_oConexion.Instancia
            End If
        End Get
    End Property
    Public ReadOnly Property NombreBaseDatos() As String
        Get
            If IsNothing(c_oConexion) Then
                Return ""
            Else
                Return c_oConexion.NombreBaseDatos
            End If
        End Get
    End Property
    Public ReadOnly Property Catalogo() As String
        Get
            If IsNothing(c_oConexion) Then
                Return ""
            Else
                Return c_oConexion.Catalogo
            End If
        End Get
    End Property
    Public ReadOnly Property Usuario() As String
        Get
            If IsNothing(c_oConexion) Then
                Return ""
            Else
                Return c_oConexion.Usuario
            End If
        End Get
    End Property
    Public ReadOnly Property Password() As String
        Get
            If IsNothing(c_oConexion) Then
                Return ""
            Else
                Return c_oConexion.Password
            End If
        End Get
    End Property
    Public ReadOnly Property AutenticacionIntegrada() As String
        Get
            If IsNothing(c_oConexion) Then
                Return ""
            Else
                Return c_oConexion.AutenticacionIntegrada
            End If
        End Get
    End Property

#End Region

#Region "Funciones Publicas"

    Public Overridable Function Conectar() As Boolean
        If IsNothing(c_oConexion) Then
            Return False
        Else
            Return c_oConexion.Conectar
        End If

    End Function

    Public Overridable Function Reconectar() As Boolean
        If IsNothing(c_oConexion) Then
            Return False
        Else
            Return c_oConexion.Reconectar
        End If

    End Function

    Public Overridable Function Cerrar() As Boolean
        If IsNothing(c_oConexion) Then
            Return False
        Else
            Return c_oConexion.Cerrar
        End If

    End Function

#End Region
End Class
