Imports System.Data.SqlClient
Public Class index
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnFind_Click(sender As Object, e As EventArgs) Handles btnFind.Click
        Try
            Dim oCitizen As New clsCitizen(If(cboDatabase.SelectedIndex = 0, My.Settings.testConnection, My.Settings.mainConnection))
            oCitizen.LoadData(txtCitizenid.Text)
            Label2.Text = oCitizen.citizenName
        Catch ex As Exception
            Label2.Text = ex.Message
        End Try
    End Sub
End Class