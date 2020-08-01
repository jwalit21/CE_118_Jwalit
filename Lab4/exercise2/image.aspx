<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="image.aspx.cs" Inherits="Basic_login_application.image" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:Image ID="Image1" runat="server" Height="435px" Width="487px" ImageUrl="~/logo2.png" />
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Hide Image" />
    </form>
</body>
</html>
