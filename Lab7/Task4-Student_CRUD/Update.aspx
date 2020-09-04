<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Update.aspx.cs" Inherits="Lab74.Update" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">

        .auto-style4 {
            width: 21%;
        }
        .auto-style7 {
            width: 329px;
        }
        .auto-style5 {
            width: 404px;
        }
        .auto-style8 {
            height: 26px;
            width: 329px;
        }
        .auto-style6 {
            height: 26px;
            width: 404px;
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
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Submit" />
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
                    <td>CPI : </td>
                    <td>
                        <asp:TextBox ID="scpi" runat="server"></asp:TextBox>
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
                        <asp:TextBox ID="semail" runat="server" TextMode="Email"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style7">Mobile no : </td>
                    <td class="auto-style5">
                        <asp:TextBox ID="smobile" runat="server" TextMode="Phone"></asp:TextBox>
                    </td>
                </tr>
            </table>
            <br />
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Update" />
            <br />
            <br />
            <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Insert Data" />
            &nbsp;
            <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Delete Data" />
            &nbsp;
            <asp:Button ID="Button5" runat="server" OnClick="Button5_Click" Text="Show Data" />
        </div>
    </form>
</body>
</html>
