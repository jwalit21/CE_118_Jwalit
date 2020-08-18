<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Product.aspx.cs" Inherits="Lab6_2_Product_Application.Product" %>

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
            Product List<br />
            Available Products<br />
            <asp:GridView ID="GridView1" runat="server">
            </asp:GridView>
            <br />
            Select the items from the list provided<br />
            <asp:ListBox ID="products" runat="server" SelectionMode="Multiple"></asp:ListBox>
            <br />
            <br />
            <asp:Label ID="msg" runat="server"></asp:Label>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="Place Order" OnClick="Button1_Click" style="height: 29px" />
&nbsp;
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Logout" />

        </div>
    </form>
</body>
</html>
