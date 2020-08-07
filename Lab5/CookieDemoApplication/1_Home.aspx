<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="1_Home.aspx.cs" Inherits="cookieWebapplication.home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="username_label" runat="server" Text="" ForeColor="DarkRed"></asp:Label>
        </div>
        <br />
        <div>
            <asp:Button ID="know_credentials" runat="server" Text="Let me know my credentials" OnClick="know_credentials_Click" />&nbsp;
            <asp:Button ID="forget_credentials" runat="server" Text="Forget my credentials" OnClick="forget_credentials_Click" />
        </div>
        <br />
        <div>
            <asp:Label ID="success" runat="server" Text="" ForeColor="Green"></asp:Label>
        </div>
        <br />
        <div>
            <div>
                <asp:Label ID="name" runat="server" Text=""></asp:Label>
            </div>
            <div>
                <asp:Label ID="username" runat="server" Text=""></asp:Label>
            </div>
            <div>
                <asp:Label ID="password" runat="server" Text=""></asp:Label>
            </div>
        </div>
    </form>
</body>
</html>
