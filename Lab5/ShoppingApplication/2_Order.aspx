<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="2_Order.aspx.cs" Inherits="shoppingApplication.Order" %>

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
        <div>
            <br />
            <asp:Table ID="Table1" runat="server" Width="766px">
                <asp:TableRow runat="server">
                    <asp:TableCell runat="server" ForeColor="Red">Item</asp:TableCell>
                    <asp:TableCell runat="server" ForeColor="Red">Quantity</asp:TableCell>
                    <asp:TableCell runat="server" ForeColor="Red">Total Price</asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </div>
        <br />
        <br />
        <asp:Label ID="total" runat="server"></asp:Label>
        <br />
        <br />
        <asp:Button ID="logout" runat="server" OnClick="logout_Click" Text="Logout" />
    </form>
</body>
</html>
