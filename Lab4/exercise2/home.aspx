<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="Basic_login_application.home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 26px;
        }
        .auto-style2 {
            height: 29px;
        }
        .auto-style3 {
            width: 553px;
        }
        .auto-style4 {
            width: 90px;
        }
        .auto-style5 {
            height: 251px;
            width: 395px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td class="auto-style1">
                        <asp:Label ID="success" runat="server" ForeColor="Green"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>Fullname</td>
                    <td>
                        <asp:TextBox ID="fullname" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ForeColor="Red" runat="server" ErrorMessage="Name is required" Tex="Enter a name" ControlToValidate="fullname"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>Age</td>
                    <td>
                        <asp:TextBox ID="age" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RangeValidator ID="RangeValidator1" ForeColor="Red" runat="server" ErrorMessage="Age is not in range" Text="Enter age between 18 to 50" ControlToValidate="age" MaximumValue="50" MinimumValue="18" SetFocusOnError="True" Type="Integer">Enter age between 18 to 50</asp:RangeValidator>
                    </td>
                </tr>
                <tr>
                    <td>Password</td>
                    <td>
                        <asp:TextBox ID="password" runat="server" TextMode="Password"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">Confirm password</td>
                    <td class="auto-style2">
                        <asp:TextBox ID="confirm_password" runat="server" TextMode="Password"></asp:TextBox>
                    </td>
                    <td class="auto-style2">
                        <asp:CompareValidator ID="CompareValidator1" ForeColor="Red" runat="server" ErrorMessage="Password didn't matches" Text="Password should be same as above entered" ControlToCompare="password" ControlToValidate="confirm_password" SetFocusOnError="True"></asp:CompareValidator>
                    </td>
                </tr>
                <tr>
                    <td>Gender</td>
                    <td>
                        <asp:RadioButtonList ID="gender" runat="server">
                            <asp:ListItem>Male</asp:ListItem>
                            <asp:ListItem>Female</asp:ListItem>
                            <asp:ListItem>Other</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td>Mobile no</td>
                    <td>
                        <asp:TextBox ID="mobile" runat="server" MaxLength="14"></asp:TextBox>
                        <br />
                    </td>
                    <td>
                        <asp:RegularExpressionValidator ForeColor="red" ID="RegularExpressionValidator1" runat="server" ErrorMessage="Mobile number format is wrong" ControlToValidate="mobile" SetFocusOnError="True" ValidationExpression="[+]\d{2}[ ]\d{10}">Enter the Mobile number in standard format with country code</asp:RegularExpressionValidator>
                    </td>
                </tr>
                                <tr>
                    <td class="auto-style1">Hobbies</td>
                    <td class="auto-style1">
                        <asp:CheckBoxList ID="hobbies" runat="server">
                            <asp:ListItem>Singing</asp:ListItem>
                            <asp:ListItem>Drawing</asp:ListItem>
                            <asp:ListItem>Cooking</asp:ListItem>
                            <asp:ListItem>Sports</asp:ListItem>
                        </asp:CheckBoxList>
                                    </td>
                </tr>
                <tr>
                    <td>State</td>
                    <td>
                        <asp:DropDownList ID="DropDownList3" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList3_SelectedIndexChanged">
                            <asp:ListItem>Gujarat</asp:ListItem>
                            <asp:ListItem>Maharashtra</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>City</td>
                    <td>
                        <asp:DropDownList ID="DropDownList2" runat="server">
                            <asp:ListItem>Ahmedabad</asp:ListItem>
                            <asp:ListItem>Vadodara</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>PAN no</td>
                    <td>
                        <asp:TextBox ID="pan" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:CustomValidator ID="CustomValidator1" ForeColor="Red" runat="server" ErrorMessage="PAN number format is invalid" ControlToValidate="pan" SetFocusOnError="True" OnServerValidate="pan_Validate"></asp:CustomValidator>
                    </td>
                </tr>
                <tr>
                    <!--<td>
                        <button><asp:HyperLink ID="HyperLink1"  runat="server" NavigateUrl="~/login.aspx">Submit</asp:HyperLink></button>
                    </td>-->
                    <td>
                        <button><asp:HyperLink ID="HyperLink2"  runat="server" NavigateUrl="~/image.aspx">Go to Image Page</asp:HyperLink></button>
                    </td>
                    <td>
                        <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="Button1_Click" />
                    </td>
                    <td>
                        <p>
                            <asp:Label ID="msg" runat="server"></asp:Label>
                        </p>
                    </td>
                </tr>
            </table>
        </div>
    </form>
    <div>
        <table class="auto-style5">
            <tr>
                <td class="auto-style3">
                <asp:Label ID="Label_Fullname" runat="server" Text=""></asp:Label>
                <td class="auto-style4">
                </td>
            </tr>
            <tr>
                <td class="auto-style3"><asp:Label ID="Label_Age" runat="server" Text=""></asp:Label>
                <td class="auto-style4"></td>
            </tr>
            <tr>
                <td class="auto-style3"><asp:Label ID="Label_Gender" runat="server" Text=""></asp:Label>
                <td class="auto-style4"></td>
            </tr>
            <tr>
                <td class="auto-style3"><asp:Label ID="Label_Mobile" runat="server" Text=""></asp:Label>
                <td class="auto-style4"></td>
            </tr>
            <tr>
                <td class="auto-style3"><asp:Label ID="Label_Hobbies" runat="server" Text=""></asp:Label>
                <td class="auto-style4"></td>
            </tr>
            <tr>
                <td class="auto-style3"><asp:Label ID="Label_State" runat="server" Text=""></asp:Label>
                <td class="auto-style4"></td>
            </tr>
            <tr>
                <td class="auto-style3"><asp:Label ID="Label_City" runat="server" Text=""></asp:Label>
                <td class="auto-style4"></td>
            </tr>
            <tr>
                <td class="auto-style3"><asp:Label ID="Label_Pan" runat="server" Text=""></asp:Label>
                <td class="auto-style4"></td>
            </tr>
        </table>
    </div>        
</body>
</html>
