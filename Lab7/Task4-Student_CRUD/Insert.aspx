<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Insert.aspx.cs" Inherits="Lab74.Insert" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form2" runat="server">
        <div>
            Enter The Student Details Here<br />
            <br />
        </div>
        <table>
            <tr>
                <td>Name : </td>
                <td>
                    <asp:TextBox ID="sname" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    CPI : 
                </td>
                <td>
                    <asp:TextBox ID="scpi" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Semester : </td>
                <td>
                    <asp:DropDownList ID="ssem" runat="server">
                        <asp:ListItem Selected="True">1</asp:ListItem>
                        <asp:ListItem>3</asp:ListItem>
                        <asp:ListItem>5</asp:ListItem>
                        <asp:ListItem>7</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>Email : </td>
                <td>
                    <asp:TextBox ID="semail" runat="server" TextMode="Email"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Mobile no : </td>
                <td>
                    <asp:TextBox ID="smobile" runat="server" TextMode="Phone"></asp:TextBox>
                </td>
            </tr>
        </table>
        <br />
        <br />
        <asp:Label ID="msg" runat="server"></asp:Label>
        <br />
        <br />
        <asp:Button ID="Button6" runat="server" OnClick="Button6_Click" Text="Submit" />
        <br />
        <br />
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Update Data" />
        &nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button7" runat="server" OnClick="Button7_Click" Text="Delete Data" />
        &nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button8" runat="server" OnClick="Button8_Click" Text="Show Data" />
    </form>
    </body>
</html>
