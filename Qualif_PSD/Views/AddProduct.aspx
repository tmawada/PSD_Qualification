<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddProduct.aspx.cs" Inherits="Qualif_PSD.Views.WebForm4" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Add Product</h1><br>
            <asp:Label ID="ProductNameLB" runat="server" Text="ProductName"></asp:Label><br>
            <asp:TextBox ID="ProductNameTB" runat="server"></asp:TextBox><br>
            <asp:Label ID="ProductPriceLB" runat="server" Text="ProductPrice"></asp:Label><br>
            <asp:TextBox ID="ProductPriceTB" runat="server" TextMode="Number"></asp:TextBox><br>
            <asp:DropDownList ID="ProductTypeDD" runat="server">
                <asp:ListItem Value="CPU">CPU</asp:ListItem>
                <asp:ListItem Value="GPU">GPU</asp:ListItem>
            </asp:DropDownList><br><br>

            <asp:Button ID="AddProductBtn" runat="server" Text="Add Product"/>
        </div>
    </form>
</body>
</html>
