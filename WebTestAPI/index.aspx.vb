Imports System.Data.SqlClient
Public Class index
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnFind_Click(sender As Object, e As EventArgs) Handles btnFind.Click
        Try
            If chkMySql.Checked = False Then
                Dim oCitizen As New clsCitizen(If(cboDatabase.SelectedIndex = 0, My.Settings.testConnectionMSSQL, My.Settings.mainConnectionMSSQL))
                oCitizen.LoadDataMSSQL(txtCitizenid.Text)
                Label2.Text = oCitizen.citizenName
            Else
                Dim oCitizen As New clsCitizen(If(cboDatabase.SelectedIndex = 0, My.Settings.testConnectionMYSQL, My.Settings.mainConnectionMYSQL))
                oCitizen.LoadDataMYSQL(txtCitizenid.Text)
                Label2.Text = oCitizen.citizenName
            End If
        Catch ex As Exception
            Label2.Text = ex.Message
        End Try
    End Sub

    Protected Sub cboDatabase_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboDatabase.SelectedIndexChanged
        TestConnect()
    End Sub
    Protected Sub TestConnect()
        If chkMySql.Checked = True Then
            Dim oConn As New CUtil(If(cboDatabase.SelectedIndex = 0, My.Settings.testConnectionMYSQL, My.Settings.mainConnectionMYSQL))
            Label2.Text = oConn.TestConnectMYSQL().Message
        Else
            Dim oConn As New CUtil(If(cboDatabase.SelectedIndex = 0, My.Settings.testConnectionMSSQL, My.Settings.mainConnectionMSSQL))
            Label2.Text = oConn.TestConnectMSSQL().Message
        End If
    End Sub
    Protected Sub chkMySql_CheckedChanged(sender As Object, e As EventArgs) Handles chkMySql.CheckedChanged
        TestConnect()
    End Sub
End Class