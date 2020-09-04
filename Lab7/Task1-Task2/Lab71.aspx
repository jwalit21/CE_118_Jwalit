<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Lab71.aspx.cs" Inherits="Lab7_1_2_Linq.Lab71" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <hr />
        Linq Quieries baesd on the Number List
        <hr />
        <div>
            All Even Numbers : 
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            <br />
        </div>
        
        <div>
            All odd Numbers : 
            <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
            <br />
        </div>
        
        <div>
            All  Numbers : 
            <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
            <br />
        </div>
        
        <div>
            Maximum Number : 
            <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>;&nbsp 
            Minimum Number:
            <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
            <br />
        </div>
        
        <div>
            Average of Numbers : 
            <asp:Label ID="Label6" runat="server" Text="Label"></asp:Label>
            <br />
        </div>
        <hr />
        LinQ queries based on list of Human names
        <hr />
        <div>
            Names starting with 'k': 
            <asp:Label ID="Label7" runat="server" Text="Label"></asp:Label>
            <br />
        </div>
        
        <div>
            Length of names less than 4 : 
            <asp:Label ID="Label8" runat="server" Text="Label"></asp:Label>
            <br />
        </div>
        
        <div>
            Length of names equal to 3 : 
            <asp:Label ID="Label9" runat="server" Text="Label"></asp:Label>
            <br />
        </div>
       
        <div>
            Sort names in Assending order : 
            <asp:Label ID="Label10" runat="server" Text="Label"></asp:Label>
            <br />
        </div>
        <hr />
    </form>
</body>
</html>
