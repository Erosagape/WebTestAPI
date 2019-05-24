Imports System.Data.SqlClient
Imports System.Net
Imports MySql.Data.MySqlClient

Friend Class CResult
    Friend Sub New()

    End Sub
    Friend Property Message As String
    Friend Property IsError As Boolean
    Friend Property Result As Object
End Class
Friend Class CUtil
#Region "Constructor and Declarations"
    Private m_ConnType As Integer
    Friend Sub New()
        SetConnection(DefaultDatabaseType)
    End Sub
    Friend Sub New(pDBType As Integer)
        SetConnection(pDBType)
    End Sub
#End Region
#Region "Database Functions"
    Friend Function GetConnection() As String
        Return GetConnection(m_ConnType)
    End Function
    Friend Sub SetConnection(dbType As Integer)
        m_ConnType = dbType
    End Sub
    Friend Function GetConnection(dbType As Integer) As String
        Dim cnStr As String = ""
        Select Case dbType
            Case DatabaseType.MSSQL
                cnStr = If(IsLocalHost(), My.Settings.MSSQLTestConnect, My.Settings.MSSQLMainConnect)
            Case DatabaseType.MYSQL
                cnStr = If(IsLocalHost(), My.Settings.MYSQLTestConnect, My.Settings.MYSQLMainConnect)
        End Select
        Return cnStr
    End Function
    Friend Function TestConnection() As CResult
        Dim cnStr As String = GetConnection(m_ConnType)
        Dim result As New CResult With {
            .Result = cnStr
        }
        Try
            Select Case m_ConnType
                Case DatabaseType.MSSQL
                    Using cn As New SqlConnection(cnStr)
                        cn.Open()
                        cn.Close()
                        result.Message = "Connect MSSQL Completed!"
                    End Using
                Case DatabaseType.MYSQL
                    Using cn As New MySqlConnection(cnStr)
                        cn.Open()
                        cn.Close()
                        result.Message = "Connect MYSQL Completed!"
                    End Using
            End Select
        Catch ex As Exception
            result.IsError = True
            result.Message = ex.Message
        End Try
        Return result
    End Function
    Friend Function DBExecute(pSQL As String, Optional pDBType As Integer = 0) As CResult
        Dim result As New CResult
        If pDBType = 0 Then pDBType = m_ConnType
        Select Case pDBType
            Case DatabaseType.MYSQL
                Using cn As New MySqlConnection(GetConnection(DatabaseType.MYSQL))
                    Try
                        cn.Open()
                        Using cm As New MySqlCommand
                            cm.Connection = cn
                            cm.CommandText = pSQL
                            cm.CommandType = CommandType.Text
                            result.Result = cm.ExecuteNonQuery()
                            result.Message = "OK"
                        End Using

                    Catch ex As Exception
                        result.IsError = True
                        result.Message = "[ERROR]" & ex.Message
                    End Try
                End Using
            Case DatabaseType.MSSQL
                Using cn As New SqlConnection(GetConnection(DatabaseType.MSSQL))
                    Try
                        cn.Open()
                        Using cm As New SqlCommand
                            cm.Connection = cn
                            cm.CommandText = pSQL
                            cm.CommandType = CommandType.Text
                            result.Result = cm.ExecuteNonQuery()
                            result.Message = "OK"
                        End Using

                    Catch ex As Exception
                        result.IsError = True
                        result.Message = "[ERROR]" & ex.Message
                    End Try
                End Using
        End Select
        Return result
    End Function
    Friend Function GetSqlReader(pSQL As String) As SqlDataReader
        Using cn As New SqlConnection(GetConnection(DatabaseType.MSSQL))
            Try
                cn.Open()
                Dim rd As SqlDataReader = New SqlCommand(pSQL, cn).ExecuteReader()
                Return rd
            Catch ex As Exception
            End Try
        End Using
        Return Nothing
    End Function
    Friend Function GetData(pSQL As String, Optional pDBType As Integer = 0) As CResult
        Dim result As New CResult
        Dim dt As New DataTable
        If pDBType = 0 Then pDBType = m_ConnType
        Select Case pDBType
            Case DatabaseType.MSSQL
                Using cn As New SqlConnection(GetConnection(DatabaseType.MSSQL))
                    Try
                        cn.Open()
                        Using da As New SqlDataAdapter(pSQL, cn)
                            da.Fill(dt)
                            result.Result = dt
                        End Using
                        result.Message = "OK"
                    Catch ex As Exception
                        result.IsError = True
                        result.Message = "[ERROR]" & ex.Message
                    End Try
                End Using
            Case DatabaseType.MYSQL
                Using cn As New MySqlConnection(GetConnection(DatabaseType.MYSQL))
                    Try
                        cn.Open()
                        Using da As New MySqlDataAdapter(pSQL, cn)
                            da.Fill(dt)
                            result.Result = dt
                        End Using
                        result.Message = "OK"
                    Catch ex As Exception
                        result.IsError = True
                        result.Message = "[ERROR]" & ex.Message
                    End Try
                End Using
        End Select
        Return result
    End Function
    Friend Function UpdateData(pSQL As String, func As AssignValue, Optional pDBType As Integer = 0) As CResult
        Dim result As New CResult()
        If pDBType = 0 Then pDBType = m_ConnType
        Select Case pDBType
            Case DatabaseType.MYSQL
                Using cn As New MySqlConnection(GetConnection(pDBType))
                    Try
                        cn.Open()
                        Using da As New MySqlDataAdapter(pSQL, cn)
                            Using cb As New MySqlCommandBuilder(da)
                                Using dt As New DataTable
                                    da.Fill(dt)
                                    Dim dr As DataRow = dt.NewRow
                                    If dt.Rows.Count > 0 Then dr = dt.Rows(0)
                                    func(dr)
                                    If dr.RowState = DataRowState.Detached Then dt.Rows.Add(dr)
                                    da.Update(dt)
                                    result.Result = dr
                                    result.Message = "Save Complete"
                                End Using
                            End Using
                        End Using
                    Catch ex As Exception
                        result.IsError = True
                        result.Message = ex.Message
                    End Try
                End Using
            Case DatabaseType.MSSQL
                Using cn As New SqlConnection(GetConnection(pDBType))
                    Try
                        cn.Open()
                        Using da As New SqlDataAdapter(pSQL, cn)
                            Using cb As New SqlCommandBuilder(da)
                                Using dt As New DataTable
                                    da.Fill(dt)
                                    Dim dr As DataRow = dt.NewRow
                                    If dt.Rows.Count > 0 Then dr = dt.Rows(0)
                                    func(dr)
                                    If dr.RowState = DataRowState.Detached Then dt.Rows.Add(dr)
                                    da.Update(dt)
                                    result.Result = dr
                                    result.Message = "Save Complete"
                                End Using
                            End Using
                        End Using
                    Catch ex As Exception
                        result.IsError = True
                        result.Message = ex.Message
                    End Try
                End Using
        End Select
        Return result
    End Function
    Friend Function ReadData(pSQL As String, func As ReadValue, Optional pDbType As Integer = 0) As CResult
        Dim result As New CResult()
        If pDbType = 0 Then pDbType = m_ConnType
        Select Case pDbType
            Case DatabaseType.MSSQL
                Try
                    Dim rd As SqlDataReader = GetSqlReader(pSQL)
                    result.Result = rd
                    If rd.HasRows Then
                        func(rd)
                    End If
                    result.Message = "OK"
                Catch ex As Exception
                    result.IsError = True
                    result.Message = ex.Message
                End Try
            Case DatabaseType.MYSQL
                Try
                    Using cn As New MySqlConnection(GetConnection(DatabaseType.MYSQL))
                        cn.Open()
                        Dim rd As MySqlDataReader = New MySqlCommand(pSQL, cn).ExecuteReader()
                        result.Result = rd
                        If rd.HasRows Then
                            func(rd)
                        End If
                        result.Message = "OK"
                    End Using
                Catch ex As Exception
                    result.IsError = True
                    result.Message = ex.Message
                End Try
        End Select
        Return result
    End Function
#End Region
#Region "Utility Functions"
    Friend Function GetServerIP() As String
        Dim hostInfo = Dns.GetHostEntry(Dns.GetHostName())
        Dim ipAddr = hostInfo.AddressList(0).ToString()
        Return ipAddr
    End Function
    Friend Function GetClientIP() As String
        Return HttpContext.Current.Request.UserHostAddress
    End Function
    Friend Function GetHostName() As String
        Return Dns.GetHostName()
    End Function
    Friend Function IsLocalHost() As Boolean
        Return HttpContext.Current.Request.IsLocal
    End Function
#End Region
End Class
