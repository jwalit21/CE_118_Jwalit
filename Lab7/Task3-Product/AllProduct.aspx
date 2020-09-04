<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AllProduct.aspx.cs" Inherits="Lab72_Product_CRUD.AllProduct" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            All Products List<br />
            <br />
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" DeleteCommand="DELETE FROM [Products] WHERE [Id] = @Id" InsertCommand="INSERT INTO [Products] ([name], [description], [catagory], [price]) VALUES (@name, @description, @catagory, @price)" SelectCommand="SELECT * FROM [Products] ORDER BY [Id], [name], [price]" UpdateCommand="UPDATE [Products] SET [name] = @name, [description] = @description, [catagory] = @catagory, [price] = @price WHERE [Id] = @Id">
                <DeleteParameters>
                    <asp:Parameter Name="Id" Type="Int32" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="name" Type="String" />
                    <asp:Parameter Name="description" Type="String" />
                    <asp:Parameter Name="catagory" Type="String" />
                    <asp:Parameter Name="price" Type="Decimal" />
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="name" Type="String" />
                    <asp:Parameter Name="description" Type="String" />
                    <asp:Parameter Name="catagory" Type="String" />
                    <asp:Parameter Name="price" Type="Decimal" />
                    <asp:Parameter Name="Id" Type="Int32" />
                </UpdateParameters>
            </asp:SqlDataSource>
            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="SqlDataSource2">
                <Columns>
                    <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" ShowSelectButton="True" />
                    <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="Id" />
                    <asp:BoundField DataField="name" HeaderText="name" SortExpression="name" />
                    <asp:BoundField DataField="description" HeaderText="description" SortExpression="description" />
                    <asp:BoundField DataField="catagory" HeaderText="catagory" SortExpression="catagory" />
                    <asp:BoundField DataField="price" HeaderText="price" SortExpression="price" />
                </Columns>
            </asp:GridView>
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Search Product" />
        </div>
    </form>
</body>
</html>
