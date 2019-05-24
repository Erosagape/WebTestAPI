Public Class HomeController
    Inherits System.Web.Mvc.Controller

    Function Index() As ActionResult
        ViewData("Title") = "Home Page"

        Return View()
    End Function
    Function GetServerIP() As ActionResult
        Return Content("Server IP=" & New CUtil().GetServerIP(), "text/html")
    End Function
    Function GetClientIP() As ActionResult
        Return Content("Client IP=" & New CUtil().GetClientIP(), "text/html")
    End Function
    Function GetHostName() As ActionResult
        Return Content(New CUtil().GetHostName(), "text/html")
    End Function
    Function GetConnect() As ActionResult
        Dim dbms = My.Settings.MainDBMS
        If Not Request.QueryString("DBMS") Is Nothing Then
            dbms = Request.QueryString("DBMS").ToString()
        End If
        Dim msg As String = New CUtil().GetConnection(dbms)
        Return Content(msg, "text/html")
    End Function
    Function TestConnect() As ActionResult
        Dim dbms = My.Settings.MainDBMS
        If Not Request.QueryString("DBMS") Is Nothing Then
            dbms = Request.QueryString("DBMS").ToString()
        End If
        Dim msg As String = New CUtil(If(dbms.ToLower = "my", DatabaseType.MYSQL, DatabaseType.MSSQL)).TestConnection().Message
        Return Content(msg, "text/html")
    End Function
    Function TestSaveData() As ActionResult
        Dim dbms = My.Settings.MainDBMS
        If Not Request.QueryString("DBMS") Is Nothing Then
            dbms = Request.QueryString("DBMS").ToString()
        End If
        Dim cnType As Integer = If(dbms.ToLower = "my", DatabaseType.MYSQL, DatabaseType.MSSQL)
        Dim oData As New clsCitizen(cnType)
        oData.FindData("3100905271924")
        Return Content(oData.SaveData(), "text/html")
    End Function
End Class
