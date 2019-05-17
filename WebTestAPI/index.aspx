<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="index.aspx.vb" Inherits="WebTestAPI.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:DropDownList ID="cboDatabase" runat="server" AutoPostBack="True">
                <asp:ListItem Value="0">Local</asp:ListItem>
                <asp:ListItem Value="1">Server</asp:ListItem>
            </asp:DropDownList>
            <br />
            <asp:Label ID="Label1" runat="server" Text="Enter ID Here :"></asp:Label>
            <br />
            <asp:TextBox ID="txtCitizenid" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="btnFind" runat="server" Text="Find" />

            <br />
            <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>

        </div>
    </form>
</body>
</html>
