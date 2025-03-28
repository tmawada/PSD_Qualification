<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CartPage.aspx.cs" Inherits="Qualif_PSD.Views.CartPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Cart Page</h1>
            <asp:Button ID="BackBtn" runat="server" Text="Back" OnClick="BackBtn_Click"/><br><br>
            <asp:GridView ID="CartGV" runat="server" AutoGenerateColumns="False" OnRowDeleting="CartGV_RowDeleting">
                <Columns>
                    <asp:BoundField DataField="product_name" HeaderText="product_name" SortExpression="product_name" />
                    <asp:BoundField DataField="product_price" HeaderText="price" SortExpression="product_price" />
                    <asp:TemplateField HeaderText="Actions">
                        <ItemTemplate>
                            <asp:Button ID="DeleteBtn" runat="server" Text="Remove" UseSubmitBehavior="false" CommandName="Delete"/>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>

            </asp:GridView><br>
            <asp:Label ID="MessageLB" runat="server" Text=" " ForeColor="Red"></asp:Label>

            <asp:Label ID="Rp" runat="server" Text="Rp." Font-Size="Large"></asp:Label>
            <asp:Label ID="PriceLB" runat="server" Text=" " Font-Size="Large"></asp:Label><br>
            <asp:Button ID="CheckoutBtn" runat="server" Text="Check Out" OnClick="CheckoutBtn_Click"/>

        </div>
    </form>
</body>
</html>
