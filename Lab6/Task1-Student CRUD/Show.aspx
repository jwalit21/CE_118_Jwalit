<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Show.aspx.cs" Inherits="Lab6_1_Student_CRUD.Show" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Student Details<br />
            <br />
            <asp:Label ID="msg" runat="server" ForeColor="Red"></asp:Label>
            <br />
            <asp:GridView ID="GridView1" runat="server">
            </asp:GridView>
            <br />
            <br />
            <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Insert Data" />
&nbsp;
            <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Update Data" />
&nbsp;
            <asp:Button ID="Button5" runat="server" OnClick="Button5_Click" Text="Delete Data" />
        </div>
    </form>
</body>
</html>
