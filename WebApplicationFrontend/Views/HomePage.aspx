<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="WebApplicationFrontend.Views.HomePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Home Page</h1>
            <asp:Button ID="LogOutBtn" runat="server" Text="Logout" OnClick="LogOutBtn_Click"/>
            <asp:Button ID="CartBtn" runat="server" Text="Cart" OnClick="CartBtn_Click"/>
            <asp:Button ID="TransactionBtn" runat="server" Text="Transaction" OnClick="TransactionBtn_Click"/><br><br>

            <asp:GridView ID="ProductGV" runat="server" AutoGenerateColumns="False" OnRowCommand="ProductGV_RowCommand">
                <Columns>
                    <asp:BoundField DataField="id" HeaderText="product_id" SortExpression="id" />
                    <asp:BoundField DataField="product_name" HeaderText="product_name" SortExpression="product_name" />
                    <asp:BoundField DataField="product_price" HeaderText="product_price" SortExpression="product_price" />
                    <asp:TemplateField HeaderText="Actions">
                        <ItemTemplate>
                            <asp:Button ID="AddCartBtn" runat="server" Text="Add to Cart" CommandName="AddToCart" CommandArgument='<%# Eval("id") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>

            </asp:GridView>
        </div>
    </form>
</body>
</html>
