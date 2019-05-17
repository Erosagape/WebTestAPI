Imports System.Data.SqlClient
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
