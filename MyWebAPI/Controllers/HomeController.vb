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
        Dim msg = "Cannot Get Connection"
        Dim dbms = My.Settings.MainDBMS
        If Not Request.QueryString("DBMS") Is Nothing Then
            dbms = Request.QueryString("DBMS").ToString()
        End If
        msg = New CUtil().GetConnection(dbms)
        Return Content(msg, "text/html")
    End Function
    Function TestConnect() As ActionResult
        Dim msg = "Cannot Test Connection"
        Dim dbms = My.Settings.MainDBMS
        If Not Request.QueryString("DBMS") Is Nothing Then
            dbms = Request.QueryString("DBMS").ToString()
        End If
        Dim cnStr As String = New CUtil().GetConnection(dbms)
        Select Case dbms.Substring(0, 2).ToLower
            Case "ms"
                msg = New CUtil(cnStr).TestConnectMSSQL().Message.ToString()
            Case "my"
                msg = New CUtil(cnStr).TestConnectMYSQL().Message.ToString()
        End Select
        Return Content(msg, "text/html")
    End Function
End Class
