<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Delete.aspx.cs" Inherits="Lab6_1_Student_CRUD.Delete" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Delete the Student data<br />
            <br />
            Enter Student ID:&nbsp;
            <asp:TextBox ID="sid_delete" runat="server"></asp:TextBox>
&nbsp;&nbsp;
            <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="Button1_Click" />
            <br />
            <br />
            <asp:Label ID="msg" runat="server"></asp:Label>
            <br />
            <br />
            <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Insert Data" />
&nbsp;
            <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Update Data" />
&nbsp;
            <asp:Button ID="Button5" runat="server" OnClick="Button5_Click" Text="Show Data" />
            <br />
        </div>
    </form>
</body>
</html>
