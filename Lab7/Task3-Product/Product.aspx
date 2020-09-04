<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Product.aspx.cs" Inherits="Lab72_Product_CRUD.Product" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            margin-left: 3px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Your Selected Product details :<br />
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" DeleteCommand="DELETE FROM [Products] WHERE [Id] = @Id" InsertCommand="INSERT INTO [Products] ([name], [description], [catagory], [price]) VALUES (@name, @description, @catagory, @price)" SelectCommand="SELECT * FROM [Products] WHERE ([Id] = @Id)" UpdateCommand="UPDATE [Products] SET [name] = @name, [description] = @description, [catagory] = @catagory, [price] = @price WHERE [Id] = @Id">
                <DeleteParameters>
                    <asp:Parameter Name="Id" Type="Int32" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="name" Type="String" />
                    <asp:Parameter Name="description" Type="String" />
                    <asp:Parameter Name="catagory" Type="String" />
                    <asp:Parameter Name="price" Type="Decimal" />
                </InsertParameters>
                <SelectParameters>
                    <asp:QueryStringParameter Name="Id" QueryStringField="id" Type="Int32" />
                </SelectParameters>
                <UpdateParameters>
                    <asp:Parameter Name="name" Type="String" />
                    <asp:Parameter Name="description" Type="String" />
                    <asp:Parameter Name="catagory" Type="String" />
                    <asp:Parameter Name="price" Type="Decimal" />
                    <asp:Parameter Name="Id" Type="Int32" />
                </UpdateParameters>
            </asp:SqlDataSource>
            <asp:DetailsView ID="DetailsView1" runat="server" Height="177px" Width="257px" AutoGenerateRows="False" CssClass="auto-style1" DataKeyNames="Id" DataSourceID="SqlDataSource1">
                <Fields>
                    <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="Id" />
                    <asp:BoundField DataField="name" HeaderText="name" SortExpression="name" />
                    <asp:BoundField DataField="description" HeaderText="description" SortExpression="description" />
                    <asp:BoundField DataField="catagory" HeaderText="catagory" SortExpression="catagory" />
                    <asp:BoundField DataField="price" HeaderText="price" SortExpression="price" />
                    <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" ShowInsertButton="True" />
                </Fields>
            </asp:DetailsView>
            <br />
            Go to all Products page :
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="All products" />
        </div>
    </form>
</body>
</html>
