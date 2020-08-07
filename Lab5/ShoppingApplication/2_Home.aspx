<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="2_Home.aspx.cs" Inherits="shoppingApplication.Home" %>

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
        <asp:Label runat="server" Text="Please select the catagory from given"></asp:Label>
        <br />
        <div>
            <asp:RadioButtonList ID="catagory" runat="server" AutoPostBack="True" Height="84px" OnSelectedIndexChanged="catagory_SelectedIndexChanged" Width="169px">
                <asp:ListItem Selected="True">Electronics</asp:ListItem>
                <asp:ListItem>Books</asp:ListItem>
            </asp:RadioButtonList>
        </div>
        <br />
        <asp:Label ID="selected" runat="server" ForeColor="Green"></asp:Label>
        <br />
        <asp:Label runat="server" Text="Select the items"></asp:Label>
        <div>
            <asp:ListBox ID="items" runat="server" AutoPostBack="True" OnSelectedIndexChanged="items_SelectedIndexChanged">
                <asp:ListItem>TV</asp:ListItem>
                <asp:ListItem>Keyboard</asp:ListItem>
                <asp:ListItem>Fridge</asp:ListItem>
                <asp:ListItem>Mobile</asp:ListItem>
            </asp:ListBox>
        </div>
        <br />
        <br />
        <asp:Button ID="order" runat="server" OnClick="order_Click" Text="Place order" />
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="logout" runat="server" OnClick="logout_Click" Text="Logout" />
    </form>
</body>
</html>
