<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminPage.aspx.cs" Inherits="WebApplicationFrontend.Views.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Admin Page</h1>
            <asp:Button ID="AddProductBtn" runat="server" Text="AddProduct" OnClick="AddProductBtn_Click" />
            <br><br>
            <asp:GridView ID="ProductGV" runat="server" AutoGenerateColumns="False" OnRowDeleting="ProductGV_RowDeleting" OnRowEditing="ProductGV_RowEditing">
                <Columns>
                    <asp:BoundField DataField="id" HeaderText="product_id" SortExpression="id" />
                    <asp:BoundField DataField="product_name" HeaderText="product_name" SortExpression="product_name" />
                    <asp:BoundField DataField="product_type" HeaderText="product_type" SortExpression="product_type" />
                    <asp:BoundField DataField="product_price" HeaderText="product_price" SortExpression="product_price" />
                    <asp:TemplateField HeaderText="Actions">
                        <ItemTemplate>
                            <asp:Button ID="UpdateBtn" runat="server" Text="Update" UseSubmitBehavior="false" CommandName="Edit"/>
                            <asp:Button ID="DeleteBtn" runat="server" Text="Delete" UseSubmitBehavior="false" CommandName="Delete"/>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>

            </asp:GridView>
            <asp:Label ID="Message" runat="server" Text=" "></asp:Label>
        </div>
    </form>
</body>
</html>
