Imports System.Data.SqlClient
Imports System.Net
Imports MySql.Data.MySqlClient

Public Class CResult
    Public Sub New()

    End Sub
    Public Property Message As String
    Public Property IsError As Boolean
    Public Property Result As Object
End Class
Public Class CUtil
    Private m_ConnStr As String
    Public Sub New(Optional pConnStr As String = "")
        m_ConnStr = pConnStr
    End Sub
    Public Sub SetConnect(pConnStr As String)
        m_ConnStr = pConnStr
    End Sub
    Public Function GetServerIP() As String
        Dim hostInfo = Dns.GetHostEntry(Dns.GetHostName())
        Dim ipAddr = hostInfo.AddressList(0).ToString()
        Return ipAddr
    End Function
    Public Function GetClientIP() As String
        Return HttpContext.Current.Request.UserHostAddress
    End Function
    Public Function GetHostName() As String
        Return Dns.GetHostName()
    End Function
    Public Function IsLocalHost() As Boolean
        Return HttpContext.Current.Request.IsLocal
    End Function
    Public Function GetConnection(dbType As String) As String
        Dim cnStr As String = ""
        Select Case dbType.ToUpper()
            Case "MS"
                cnStr = If(IsLocalHost(), My.Settings.MSSQLTestConnect, My.Settings.MSSQLMainConnect)
            Case "MY"
                cnStr = If(IsLocalHost(), My.Settings.MYSQLTestConnect, My.Settings.MYSQLMainConnect)
        End Select
        Return cnStr
    End Function
    Public Function TestConnectMSSQL() As CResult
        Dim result As New CResult With {
            .Result = m_ConnStr
        }
        Try
            Using cn As New SqlConnection(m_ConnStr)
                cn.Open()
                result.Message = "Connect Completed!"
            End Using
        Catch ex As Exception
            result.IsError = True
            result.Message = ex.Message
        End Try
        Return result
    End Function
    Public Function TestConnectMYSQL() As CResult
        Dim result As New CResult With {
            .Result = m_ConnStr
        }
        Try
            Using cn As New MySqlConnection(m_ConnStr)
                cn.Open()
                result.Message = "Connect Completed!"
            End Using
        Catch ex As Exception
            result.IsError = True
            result.Message = ex.Message
        End Try
        Return result
    End Function
    Public Function ExecuteSQL(pSQL As String) As CResult
        Dim result As New CResult
        Dim dt As New DataTable
        Using cn As New SqlConnection(m_ConnStr)
            Try
                cn.Open()
                Using cm As New SqlCommand
                    cm.Connection = cn
                    cm.CommandText = pSQL
                    cm.CommandType = CommandType.Text
                    cm.ExecuteNonQuery()
                    result.Message = "OK"
                End Using

            Catch ex As Exception
                result.IsError = True
                result.Message = "[ERROR]" & ex.Message
            End Try
        End Using
        Return result
    End Function
    Public Function GetTableFromSQL(pSQL As String) As CResult
        Dim result As New CResult
        Dim dt As New DataTable
        Using cn As New SqlConnection(m_ConnStr)
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
        Return result
    End Function
End Class
