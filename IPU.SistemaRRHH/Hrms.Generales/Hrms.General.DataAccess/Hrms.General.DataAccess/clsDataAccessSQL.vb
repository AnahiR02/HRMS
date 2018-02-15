
Imports System.Threading
Imports System.Data

Public Class clsDataAccessSQL
    Inherits clsDataAccessBase

#Region "Rutinas de Inicialización"

    Sub New(ByVal vConexionBDD As clsConexionBDD)
        MyBase.New(vConexionBDD)

        Try
            PrepararComandos()
        Catch ex As Exception

        End Try

    End Sub

#End Region

#Region "Rutinas de BDD"

    Protected Overrides Sub PrepararComandos()
        Try
            b_oDA = New SqlClient.SqlDataAdapter()
            b_oDA.SelectCommand = New SqlClient.SqlCommand("", CType(b_oConexionBDD.Conexion, SqlClient.SqlConnection))
            b_oDA.InsertCommand = New SqlClient.SqlCommand("", CType(b_oConexionBDD.Conexion, SqlClient.SqlConnection))
            b_oDA.UpdateCommand = New SqlClient.SqlCommand("", CType(b_oConexionBDD.Conexion, SqlClient.SqlConnection))
            b_oDA.DeleteCommand = New SqlClient.SqlCommand("", CType(b_oConexionBDD.Conexion, SqlClient.SqlConnection))

            b_oCommand = New SqlClient.SqlCommand("", CType(b_oConexionBDD.Conexion, SqlClient.SqlConnection))
            b_oParam = New SqlClient.SqlParameter()

            If IsNothing(b_oDS) Then
                b_oDS = New DataSet()
            End If
        Catch ex As Exception

        End Try

    End Sub

    Public Overrides Function Buscar(ByVal strSql As String, ByVal strTabla As String) As DataSet
        Try
            Monitor.Enter(Me)

            If Not b_oConexionBDD.Conectado Then
                b_oConexionBDD.Reconectar()
                PrepararComandos()
            End If

            If b_oDS.Tables.Contains(strTabla) Then
                b_oDS.Tables(strTabla).Clear()
            End If

            b_oDA.SelectCommand.CommandText = strSql
            b_oDA.AcceptChangesDuringFill = True
            b_oDA.Fill(b_oDS, strTabla)


        Catch sex As SqlClient.SqlException
            Select Case sex.Number
                Case 208
                    Return b_oDS
                Case Else
                    Throw
            End Select

        Catch ex As Exception

        Finally
            Monitor.Exit(Me)

        End Try

        Return b_oDS

    End Function
    Public Overrides Function Buscar(ByVal strSql As String, ByVal strTabla As String, ByRef ds As DataSet) As Boolean
        Dim bReturn As Boolean = False

        Try
            Monitor.Enter(Me)

            If Not b_oConexionBDD.Conectado Then
                b_oConexionBDD.Reconectar()
                PrepararComandos()
            End If

            b_oDA.SelectCommand.CommandText = strSql
            b_oDA.AcceptChangesDuringFill = True
            b_oDA.Fill(ds, strTabla)
            bReturn = True

        Catch sex As SqlClient.SqlException
            Select Case sex.Number
                Case 208
                    Return False
                Case Else
                    Throw
            End Select

        Catch ex As Exception
        Finally
            Monitor.Exit(Me)

        End Try

        Return bReturn

    End Function
    Public Overrides Function Buscar(ByVal strSql As String, ByVal strTabla As String, ByRef ds As DataSet, ByVal iTimeout As Integer) As Boolean
        Dim bReturn As Boolean = False

        Try
            Monitor.Enter(Me)

            If Not b_oConexionBDD.Conectado Then
                b_oConexionBDD.Reconectar()
            End If

            PrepararComandos()

            b_oDA.SelectCommand.CommandTimeout = iTimeout
            b_oDA.SelectCommand.CommandText = strSql
            b_oDA.AcceptChangesDuringFill = True
            b_oDA.Fill(ds, strTabla)
            bReturn = True

        Catch sex As SqlClient.SqlException
            Select Case sex.Number
                Case 208
                    Return False
                Case Else
                    Throw
            End Select

        Catch ex As Exception

        Finally
            Monitor.Exit(Me)

        End Try

        Return bReturn

    End Function

    Public Overrides Function BuscarRegistro(ByVal strSql As String, ByVal strTabla As String) As DataRow
        Dim dr As DataRow = Nothing

        Try
            Monitor.Enter(Me)

            If Not b_oConexionBDD.Conectado Then
                b_oConexionBDD.Reconectar()
                PrepararComandos()
            End If

            If b_oDS.Tables.Contains(strTabla) Then
                b_oDS.Tables(strTabla).Clear()
            End If

            b_oDA.SelectCommand.CommandText = strSql
            b_oDA.AcceptChangesDuringFill = True
            b_oDA.Fill(b_oDS, strTabla)

            If b_oDS.Tables.Contains(strTabla) Then
                If b_oDS.Tables(strTabla).Rows.Count > 0 Then
                    dr = b_oDS.Tables(strTabla).Rows(0)
                End If
            End If

        Catch sex As SqlClient.SqlException
            Select Case sex.Number
                Case 208
                    Return dr
                Case Else
                    Throw
            End Select

        Catch ex As Exception

        Finally
            Monitor.Exit(Me)

        End Try

        Return dr

    End Function

    Public Overrides Function ObtenerDecimal(ByVal strSql As String) As Decimal
        Dim dResult As Decimal = 0
        Dim oResult As Object

        Try
            Monitor.Enter(Me)

            If Not b_oConexionBDD.Conectado Then
                b_oConexionBDD.Reconectar()
                PrepararComandos()
            End If

            b_oCommand.CommandText = strSql
            oResult = b_oCommand.ExecuteScalar()
            If IsDBNull(oResult) Then
                dResult = 0
            Else
                dResult = CDec(oResult)
            End If

        Catch sex As SqlClient.SqlException
            Throw
        Catch ex As Exception

        Finally
            Monitor.Exit(Me)

        End Try

        Return dResult

    End Function
    Public Overrides Function ObtenerDato(ByVal strSql As String) As String
        Dim sResult As String = String.Empty
        Dim oResult As Object

        Try
            Monitor.Enter(Me)

            If Not b_oConexionBDD.Conectado Then
                b_oConexionBDD.Reconectar()
                PrepararComandos()
            End If

            b_oCommand.CommandText = strSql
            oResult = b_oCommand.ExecuteScalar()
            If IsDBNull(oResult) Then
                sResult = String.Empty
            Else
                sResult = CStr(oResult)
            End If

        Catch sex As SqlClient.SqlException
            Throw
        Catch ex As Exception
        Finally
            Monitor.Exit(Me)

        End Try

        Return sResult

    End Function

    Public Overrides Function ObtenerDateTime() As DateTime
        Dim tResult As DateTime = Nothing
        Dim oResult As Object

        Try
            Monitor.Enter(Me)

            If Not b_oConexionBDD.Conectado Then
                b_oConexionBDD.Reconectar()
                PrepararComandos()
            End If

            b_oCommand.CommandText = "SELECT GETDATE()"
            oResult = b_oCommand.ExecuteScalar()
            If Not IsDBNull(oResult) Then
                tResult = CDate(oResult)
            End If

        Catch sex As SqlClient.SqlException
            Throw
        Catch ex As Exception

        Finally
            Monitor.Exit(Me)

        End Try

        Return tResult

    End Function

    Public Overrides Function ObtenerDataView(ByVal strSql As String, ByVal strTabla As String) As DataView
        Dim dv As DataView = Nothing

        Try
            Monitor.Enter(Me)

            If Not b_oConexionBDD.Conectado Then
                b_oConexionBDD.Reconectar()
                PrepararComandos()
            End If

            If b_oDS.Tables.Contains(strTabla) Then
                b_oDS.Tables(strTabla).Clear()
            End If

            b_oDA.SelectCommand.CommandText = strSql
            b_oDA.AcceptChangesDuringFill = True
            b_oDA.Fill(b_oDS, strTabla)

            If b_oDS.Tables(0).Rows.Count > 0 Then
                dv = New DataView(b_oDS.Tables(strTabla))
            End If

        Catch sex As SqlClient.SqlException
            Throw
        Catch ex As Exception
        Finally
            Monitor.Exit(Me)

        End Try

        Return dv

    End Function

    Public Overrides Function Relacionar(ByVal strSQL1 As String, ByVal strTabla1 As String, ByVal aColumnas1 As String, ByVal strSQL2 As String, ByVal strTabla2 As String, ByVal aColumnas2 As String, ByVal strRelacion As String) As DataSet
        Try
            Monitor.Enter(Me)

            If Not b_oConexionBDD.Conectado Then
                b_oConexionBDD.Reconectar()
                PrepararComandos()
            End If

            If b_oDS.Tables.Contains(strTabla1) Then
                b_oDS.Tables(strTabla1).Clear()
            End If

            If b_oDS.Tables.Contains(strTabla2) Then
                b_oDS.Tables(strTabla2).Clear()
            End If

            b_oDA.SelectCommand.CommandText = strSQL1
            b_oDA.AcceptChangesDuringFill = True
            b_oDA.Fill(b_oDS, strTabla1)

            b_oDA.SelectCommand.CommandText = strSQL2
            b_oDA.AcceptChangesDuringFill = True
            b_oDA.Fill(b_oDS, strTabla2)

            If Not b_oDS.Relations.Contains(strRelacion) Then
                Dim oRelacion As DataRelation = b_oDS.Relations.Add(strRelacion, b_oDS.Tables(strTabla1).Columns(aColumnas1), b_oDS.Tables(strTabla2).Columns(aColumnas2), False)
                oRelacion.Nested = True
            End If

        Catch sex As SqlClient.SqlException
            Throw
        Catch ex As Exception
        Finally
            Monitor.Exit(Me)

        End Try

        Return b_oDS

    End Function
    Public Overrides Function Relacionar(ByVal strTabla1 As String, ByVal aColumnas1 As String, ByVal strTabla2 As String, ByVal aColumnas2 As String, ByVal strRelacion As String, ByRef ds As DataSet) As Boolean
        Dim bReturn As Boolean = False

        Try
            Monitor.Enter(Me)

            If Not ds.Relations.Contains(strRelacion) Then
                Dim oRelacion As DataRelation = ds.Relations.Add(strRelacion, ds.Tables(strTabla1).Columns(aColumnas1), ds.Tables(strTabla2).Columns(aColumnas2), False)
                oRelacion.Nested = True
            End If

            bReturn = True

        Catch sex As SqlClient.SqlException
            Throw
        Catch ex As Exception
        Finally
            Monitor.Exit(Me)

        End Try

        Return bReturn

    End Function
    Public Overrides Function Relacionar(ByVal strTabla1 As String, ByVal aColumnas1() As DataColumn, ByVal strTabla2 As String, ByVal aColumnas2() As DataColumn, ByVal strRelacion As String, ByRef ds As DataSet) As Boolean
        Dim bReturn As Boolean = False

        Try
            Monitor.Enter(Me)

            If Not ds.Relations.Contains(strRelacion) Then
                Dim oRelacion As DataRelation = ds.Relations.Add(strRelacion, aColumnas1, aColumnas2, False)
                oRelacion.Nested = True
            End If

            bReturn = True

        Catch sex As SqlClient.SqlException
            Throw
        Catch ex As Exception
        Finally
            Monitor.Exit(Me)

        End Try

        Return bReturn

    End Function

    Public Overrides Function Registrar(ByVal strSql As String) As Boolean
        Dim bResult As Boolean = False

        Try
            If Not b_oConexionBDD.Conectado Then
                b_oConexionBDD.Reconectar()
                PrepararComandos()
            End If

            b_oCommand.CommandText = strSql
            b_oCommand.CommandTimeout = 30

            SyncLock b_DALock
                b_oCommand.ExecuteNonQuery()

            End SyncLock

            bResult = True

        Catch sex As SqlClient.SqlException
            Select Case sex.Number
                Case 547
                    Return False
                Case Else
                    Throw
            End Select

        Catch ex As Exception
        End Try

        Return bResult

    End Function
    Public Overrides Function Registrar(ByVal strSql As String, ByVal iTimeout As Integer) As Boolean
        Dim bResult As Boolean = False

        Try
            If Not b_oConexionBDD.Conectado Then
                b_oConexionBDD.Reconectar()
                PrepararComandos()
            End If

            b_oCommand.CommandText = strSql
            b_oCommand.CommandTimeout = iTimeout

            SyncLock b_DALock
                b_oCommand.ExecuteNonQuery()
            End SyncLock

            bResult = True

        Catch sex As SqlClient.SqlException
            Select Case sex.Number
                Case 547
                    Return False
                Case Else
                    Throw
            End Select
        Catch ex As Exception
        End Try

        Return bResult

    End Function
    Public Overrides Function Registrar(ByVal strSql As String, ByVal paramImagen() As Byte) As Boolean
        Dim bResult As Boolean = False

        Try
            Monitor.Enter(Me)

            If Not b_oConexionBDD.Conectado Then
                b_oConexionBDD.Reconectar()
                PrepararComandos()
            End If

            b_oCommand.CommandText = strSql

            Dim imageParam As SqlClient.SqlParameter = New SqlClient.SqlParameter("@Imagen", SqlDbType.Image)
            imageParam.Value = paramImagen
            b_oCommand.Parameters.Clear()
            b_oCommand.Parameters.Add(imageParam)
            b_oCommand.ExecuteNonQuery()

            bResult = True

        Catch sex As SqlClient.SqlException
            Select Case sex.Number
                Case 547
                    Return False
                Case Else
                    Throw
            End Select
        Catch ex As Exception
        Finally
            Monitor.Exit(Me)

        End Try

        Return bResult

    End Function

    'Public Overrides Function CompactarBDD() As Boolean
    '    Dim srv As Server
    '    Dim bReturn As Boolean = False

    '    Try
    '        Monitor.Enter(Me)

    '        Dim conn As ServerConnection = New ServerConnection(CType(b_oConexionBDD.Conexion, SqlClient.SqlConnection))
    '        Dim sLogin As String = b_oConexionBDD.Usuario
    '        Dim sServer As String = b_oConexionBDD.Instancia
    '        Dim sBDD As String = b_oConexionBDD.Catalogo

    '        srv = New Server(conn)

    '        Dim db As Database = srv.Databases(sBDD)
    '        If Not IsNothing(db) Then
    '            db.Shrink(10, ShrinkMethod.Default)
    '            db.TruncateLog()
    '            bReturn = True
    '        End If

    '    Catch sex As SqlClient.SqlException
    '        Throw New clsExcepcion(System.Reflection.Assembly.GetExecutingAssembly.GetName.Name(), Me.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod.Name, sex.Message, sex)

    '    Catch sx As clsExcepcion
    '        Throw New clsExcepcion(System.Reflection.Assembly.GetExecutingAssembly.GetName.Name(), Me.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod.Name, sx.Mensaje, sx)

    '    Catch smx As SmoException
    '        Throw New clsExcepcion(My.Application.Info.AssemblyName, Me.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod.Name, PrepararMensaje(smx))

    '    Catch ex As Exception
    '        Throw New clsExcepcion(System.Reflection.Assembly.GetExecutingAssembly.GetName.Name(), Me.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod.Name, ex.Message, ex)

    '    Finally
    '        Monitor.Exit(Me)

    '    End Try

    '    Return bReturn

    'End Function

    'Public Overrides Function RespaldarBDD(ByVal sLocation As String) As Boolean
    '    Dim bk As Backup
    '    Dim srv As Server
    '    Dim bReturn As Boolean = False

    '    Try
    '        Monitor.Enter(Me)

    '        Dim conn As ServerConnection = New ServerConnection(CType(b_oConexionBDD.Conexion, SqlClient.SqlConnection))
    '        Dim sLogin As String = b_oConexionBDD.Usuario
    '        Dim sServer As String = b_oConexionBDD.Instancia
    '        Dim sBDD As String = b_oConexionBDD.Catalogo

    '        srv = New Server(conn)

    '        bk = New Backup
    '        bk.Action = BackupActionType.Database
    '        bk.Database = sBDD
    '        Dim bdi As BackupDeviceItem = New BackupDeviceItem(sLocation, DeviceType.File)
    '        bk.Devices.Add(bdi)
    '        bk.Initialize = True
    '        bk.Incremental = False
    '        bk.SqlBackup(srv)
    '        TruncarLogBDD()

    '        bReturn = True

    '    Catch sex As SqlClient.SqlException
    '        Throw New clsExcepcion(System.Reflection.Assembly.GetExecutingAssembly.GetName.Name(), Me.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod.Name, sex.Message, sex)

    '    Catch sx As clsExcepcion
    '        Throw New clsExcepcion(System.Reflection.Assembly.GetExecutingAssembly.GetName.Name(), Me.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod.Name, sx.Mensaje, sx)

    '    Catch smx As SmoException
    '        Throw New clsExcepcion(My.Application.Info.AssemblyName, Me.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod.Name, PrepararMensaje(smx))

    '    Catch ex As Exception
    '        Throw New clsExcepcion(System.Reflection.Assembly.GetExecutingAssembly.GetName.Name(), Me.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod.Name, ex.Message, ex)

    '    Finally
    '        Monitor.Exit(Me)

    '    End Try

    '    Return bReturn

    'End Function

    'Public Overrides Function RestaurarBDD(ByVal sSource As String, ByVal sLocation As String, ByVal bRename As Boolean) As Boolean
    '    Dim rs As Restore
    '    Dim srv As Server
    '    Dim bReturn As Boolean = False

    '    Try
    '        Monitor.Enter(Me)

    '        Dim conn As ServerConnection
    '        If IsNothing(b_oConexionBDD.Conexion) Then
    '            conn = New ServerConnection(b_oConexionBDD.Instancia, b_oConexionBDD.Usuario, b_oConexionBDD.Password)
    '        Else
    '            conn = New ServerConnection(CType(b_oConexionBDD.Conexion, SqlClient.SqlConnection))
    '        End If
    '        Dim sLogin As String = b_oConexionBDD.Usuario
    '        Dim sServer As String = b_oConexionBDD.Instancia
    '        Dim sBDD As String = b_oConexionBDD.Catalogo
    '        Dim sBDDOriginal As String = sBDD

    '        If sBDD.Contains("TMP") Then
    '            If sBDD.LastIndexOf("TMP") = sBDD.Length - 3 Then
    '                sBDDOriginal = sBDD.Substring(0, sBDD.Length - 3)
    '            End If
    '        End If

    '        srv = New Server(conn)

    '        rs = New Restore
    '        rs.Database = sBDD

    '        Dim db As Database = srv.Databases(sBDD)
    '        If Not IsNothing(db) Then
    '            srv.KillAllProcesses(sBDD)
    '        End If

    '        rs.Devices.Clear()
    '        rs.Devices.AddDevice(sSource, DeviceType.File)

    '        Dim sOldDataFileLocation As String = ""
    '        Dim sOldLogFileLocation As String = ""
    '        Dim sDataLogicalName As String = ""
    '        Dim sLogLogicalName As String = ""

    '        Dim dt As DataTable = rs.ReadFileList(srv)
    '        Dim foundrows As DataRow() = dt.Select(Nothing)
    '        For Each dr As DataRow In foundrows
    '            If dr("Type").ToString = "L" Then
    '                sLogLogicalName = dr("LogicalName").ToString
    '                sOldLogFileLocation = dr("PhysicalName").ToString
    '            Else
    '                sDataLogicalName = dr("LogicalName").ToString
    '                sOldDataFileLocation = dr("PhysicalName").ToString
    '            End If
    '        Next

    '        Dim sTmp As String = ""
    '        If bRename Then
    '            sTmp = "TMP"
    '        End If

    '        Dim i As Integer = sOldDataFileLocation.LastIndexOf("\")
    '        Dim sDataFileLocation As String = sLocation & "\" & sTmp & sOldDataFileLocation.Substring(i + 1)

    '        i = sOldLogFileLocation.LastIndexOf("\")
    '        Dim sLogFileLocation As String = sLocation & "\" & sTmp & sOldLogFileLocation.Substring(i + 1)

    '        rs.RelocateFiles.Add(New RelocateFile(sDataLogicalName, sDataFileLocation))
    '        rs.RelocateFiles.Add(New RelocateFile(sLogLogicalName, sLogFileLocation))

    '        If IsNothing(db) Then
    '            rs.ReplaceDatabase = False
    '            rs.NoRecovery = False
    '        Else
    '            rs.ReplaceDatabase = True
    '        End If

    '        rs.SqlRestore(srv)

    '        db = srv.Databases(sBDD)
    '        db.SetOnline()

    '        rs.Devices.Clear()

    '        If LCase(b_oConexionBDD.AutenticacionIntegrada) <> "true" Then
    '            If sLogin <> "sa" Then
    '                db = srv.Databases(sBDD)

    '                Dim dbUser As User = db.Users(sLogin)
    '                If Not IsNothing(dbUser) Then
    '                    dbUser.Drop()
    '                End If

    '                Dim dbLogin As Login = srv.Logins(sLogin)

    '                dbUser = New User(db, sLogin)
    '                dbUser.Login = sLogin
    '                dbUser.Create()

    '                Dim dbrol As DatabaseRole = db.Roles("db_owner")
    '                dbrol.AddMember(dbLogin.Name)
    '                dbrol = db.Roles("db_backupoperator")
    '                dbrol.AddMember(dbLogin.Name)
    '                dbrol = db.Roles("db_datareader")
    '                dbrol.AddMember(dbLogin.Name)
    '                dbrol = db.Roles("db_datawriter")
    '                dbrol.AddMember(dbLogin.Name)
    '            End If
    '        End If

    '        bReturn = True

    '    Catch sex As SqlClient.SqlException
    '        Throw New clsExcepcion(System.Reflection.Assembly.GetExecutingAssembly.GetName.Name(), Me.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod.Name, sex.Message, sex)

    '    Catch sx As clsExcepcion
    '        Throw New clsExcepcion(System.Reflection.Assembly.GetExecutingAssembly.GetName.Name(), Me.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod.Name, sx.Mensaje, sx)

    '    Catch smx As SmoException
    '        Throw New clsExcepcion(My.Application.Info.AssemblyName, Me.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod.Name, PrepararMensaje(smx))

    '    Catch ex As Exception
    '        Throw New clsExcepcion(System.Reflection.Assembly.GetExecutingAssembly.GetName.Name(), Me.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod.Name, ex.Message, ex)

    '    Finally
    '        Monitor.Exit(Me)

    '    End Try

    '    Return bReturn

    'End Function

    'Public Overrides Function TruncarLogBDD() As Boolean
    '    Dim srv As Server
    '    Dim bReturn As Boolean = False

    '    Try
    '        Monitor.Enter(Me)

    '        Dim conn As ServerConnection = New ServerConnection(CType(b_oConexionBDD.Conexion, SqlClient.SqlConnection))
    '        Dim sLogin As String = b_oConexionBDD.Usuario
    '        Dim sServer As String = b_oConexionBDD.Instancia
    '        Dim sBDD As String = b_oConexionBDD.Catalogo

    '        srv = New Server(conn)

    '        Dim db As Database
    '        db = srv.Databases(sBDD)

    '        db.Shrink(20, ShrinkMethod.NoTruncate)

    '        db.TruncateLog()
    '        bReturn = True

    '    Catch sex As SqlClient.SqlException
    '        Throw New clsExcepcion(System.Reflection.Assembly.GetExecutingAssembly.GetName.Name(), Me.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod.Name, sex.Message, sex)

    '    Catch sx As clsExcepcion
    '        Throw New clsExcepcion(System.Reflection.Assembly.GetExecutingAssembly.GetName.Name(), Me.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod.Name, sx.Mensaje, sx)

    '    Catch smx As SmoException
    '        Throw New clsExcepcion(My.Application.Info.AssemblyName, Me.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod.Name, PrepararMensaje(smx))

    '    Catch ex As Exception
    '        Throw New clsExcepcion(System.Reflection.Assembly.GetExecutingAssembly.GetName.Name(), Me.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod.Name, ex.Message, ex)

    '    Finally
    '        Monitor.Exit(Me)

    '    End Try

    '    Return bReturn

    'End Function

#End Region
End Class
