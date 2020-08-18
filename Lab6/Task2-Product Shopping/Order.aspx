<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Order.aspx.cs" Inherits="Lab6_2_Product_Application.Order" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            Hello
            <asp:Label ID="user" runat="server"></asp:Label>
            <br />
            <br />
            <asp:Label ID="msg" runat="server"></asp:Label>
            <br />
            <asp:GridView ID="GridView1" runat="server">
            </asp:GridView>

            <br />
            <asp:Label ID="price" runat="server" ForeColor="Green"></asp:Label>
            <br />
            <br />
            <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Back" />
&nbsp;
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Clear Cart" />
&nbsp;
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Logout" />

        </div>
    </form>
</body>
</html>
