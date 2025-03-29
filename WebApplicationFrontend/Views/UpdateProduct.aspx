<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateProduct.aspx.cs" Inherits="WebApplicationFrontend.Views.UpdateProduct" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Update Product</h1>
            <asp:Label ID="ProductIDLB" runat="server" Text="ProductID"></asp:Label><br>
            <asp:TextBox ID="ProductIDTB" runat="server" ReadOnly="true"></asp:TextBox><br>
            <asp:Label ID="ProductNameLB" runat="server" Text="ProductName"></asp:Label><br>
            <asp:TextBox ID="ProductNameTB" runat="server"></asp:TextBox><br>
            <asp:Label ID="ProductPriceLB" runat="server" Text="ProductPrice"></asp:Label><br>
            <asp:TextBox ID="ProductPriceTB" runat="server" TextMode="Number"></asp:TextBox><br>
            <asp:DropDownList ID="ProductTypeDD" runat="server">
                <asp:ListItem Value="CPU">CPU</asp:ListItem>
                <asp:ListItem Value="GPU">GPU</asp:ListItem>
            </asp:DropDownList><br><br>

            <asp:Button ID="UpdateProductBtn" runat="server" Text="Update Product" OnClick="UpdateProductBtn_Click"/>
            <asp:Label ID="errorMes" runat="server" Text=" " ForeColor="Red"></asp:Label>
        </div>
    </form>
</body>
</html>
