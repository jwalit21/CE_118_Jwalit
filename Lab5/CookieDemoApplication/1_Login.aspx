<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="1_Login.aspx.cs" Inherits="cookieWebapplication.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text="Your name"></asp:Label>
                    </td>
                    <td>
                         <asp:TextBox ID="name" runat="server"></asp:TextBox>
                    </td>
                </tr>
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

                        <asp:Label ID="msg" runat="server" ForeColor="Red" Visible="False">Invalid credentials</asp:Label>

                    </td>
                </tr>
   
                </table>
        </div>
    </form>
</body>
</html>
