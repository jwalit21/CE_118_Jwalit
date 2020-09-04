<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Show.aspx.cs" Inherits="Lab74.Show" %>

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
        .auto-style9 {
            width: 1630px;
        }
        .auto-style10 {
            width: 2100px;
        }
        </style>
</head>
<body>
    <form id="form2" runat="server">
        <div>
            Student Details<br />
            <br />
            <asp:Label ID="msg" runat="server" ForeColor="Red"></asp:Label>
            <br />
            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" OnRowCommand="Gridview1_RowCommand">
            </asp:GridView>
            <br />
            <asp:Panel ID="Panel1" runat="server">
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
                &nbsp;<br />
                <asp:Button ID="update_data" runat="server" Text="Update" OnClick="update_data_Click" />
                <br />

            </asp:Panel>
            <br />
            <asp:Panel ID="Panel2" runat="server">
                <table class="auto-style4">
                    <tr>
                        <td class="auto-style10">Student ID:</td>
                        <td class="auto-style5">
                            <asp:Label ID="sid_show" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style10">Name :</td>
                        <td class="auto-style5">
                            <asp:Label ID="sname_show" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style10">CPI :</td>
                        <td class="auto-style5">
                            <asp:Label ID="scpi_show" runat="server"></asp:Label>
                        </td>                    </tr>
                    <tr>
                        <td class="auto-style10">Semester : </td>
                        <td class="auto-style5">
                            <asp:Label ID="ssem_show" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style10">Email : </td>
                        <td class="auto-style5">
                            <asp:Label ID="semail_show" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style10">Mobile no : </td>
                        <td class="auto-style5">
                            <asp:Label ID="smobile_show" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <br />
            <br />
            
            <asp:Button ID="Button7" runat="server" OnClick="Button7_Click" Text="Sort By Id" />
&nbsp;
            <asp:Button ID="Button6" runat="server" OnClick="Button6_Click" Text="Sort By Name" />
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
