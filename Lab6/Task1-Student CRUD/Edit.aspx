<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="Lab6_1_Student_CRUD.Edit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style4 {
            width: 21%;
        }
        .auto-style5 {
            width: 404px;
        }
        .auto-style6 {
            height: 26px;
            width: 404px;
        }
        .auto-style7 {
            width: 329px;
        }
        .auto-style8 {
            height: 26px;
            width: 329px;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Update the Student data<br />
            <br />
            Enter Student ID:&nbsp;
            <asp:TextBox ID="sid_update" runat="server"></asp:TextBox>
&nbsp;&nbsp;
            <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="Button1_Click" />
            <br />
            <br />
            <asp:Label ID="msg" runat="server"></asp:Label>
            <br />
            <br />
            <table class="auto-style4">
                <tr>
                    <td class="auto-style7">Student ID:</td>
                    <td class="auto-style5">
                        <asp:Label ID="sid" runat="server"></asp:Label>
                    </td>
                    
                </tr>
                <tr>
                    <td class="auto-style8">Name : </td>
                    <td class="auto-style6">
                        <asp:TextBox ID="sname" runat="server"></asp:TextBox>
                    </td>
                    
                </tr>
                <tr>
                    <td class="auto-style7">Semester : </td>
                    <td class="auto-style5">
                        <asp:DropDownList ID="ssem" runat="server">
                            <asp:ListItem>1</asp:ListItem>
                            <asp:ListItem>3</asp:ListItem>
                            <asp:ListItem>5</asp:ListItem>
                            <asp:ListItem>7</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style7">Email : </td>
                    <td class="auto-style5">
                        <asp:TextBox ID="semail" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style7">Mobile no : </td>
                    <td class="auto-style5">
                        <asp:TextBox ID="smobile" runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>
            
            <br />
            <asp:Button ID="Button2" runat="server" Text="Update" OnClick="Button2_Click" />
            <br />
            <br />
            <asp:Button ID="Button4" runat="server" Text="Insert Data" OnClick="Button4_Click" />
&nbsp;
            <asp:Button ID="Button3" runat="server" Text="Delete Data" OnClick="Button3_Click" />
&nbsp;
            <asp:Button ID="Button5" runat="server" Text="Show Data" OnClick="Button5_Click" />
        </div>
    &nbsp;</form>
</body>
</html>
