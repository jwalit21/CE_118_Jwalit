<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Basic_login_application.login_page" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 33px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td>

                        <asp:Label ID="Label1" runat="server" Text="Username"></asp:Label>

                    </td>
                    <td>

                        <asp:TextBox ID="username" runat="server"></asp:TextBox>

                    </td>
                </tr>
                <tr>
                    <td>

                        <asp:Label ID="Label2" runat="server" Text="Password"></asp:Label>

                    </td>
                    <td>

                        <asp:TextBox ID="password" TextMode="Password" runat="server"></asp:TextBox>

                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">

                        <asp:Button ID="submit" runat="server" OnClick="submit_Click" Text="Submit" />

                    </td>
                    <td class="auto-style1">

                        <asp:Label ID="msg" runat="server"></asp:Label>

                    </td>
                </tr>
                </table>
        </div>
    </form>
</body>
</html>
