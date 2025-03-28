<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterPage.aspx.cs" Inherits="Qualif_PSD.Views.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1> Register</h1>
            <asp:Label ID="UsernameLB" runat="server" Text="Username"></asp:Label><br>
            <asp:TextBox ID="UsernameTB" runat="server"></asp:TextBox> <br>
            <asp:Label ID="EmailLB" runat="server" Text="Email"></asp:Label><br>
            <asp:TextBox ID="EmailTB" runat="server" TextMode="Email"></asp:TextBox> <br>
            <asp:Label ID="PasswordLB" runat="server" Text="Password"></asp:Label><br>
            <asp:TextBox ID="PasswordTB" runat="server" TextMode="Password"></asp:TextBox> <br>
            <asp:Label ID="ConfirmPassLB" runat="server" Text="Confirm Password"></asp:Label><br>
            <asp:TextBox ID="ConfirmPassTB" runat="server" TextMode="Password"></asp:TextBox> <br>
            <asp:Label ID="GenderLB" runat="server" Text="Gender"></asp:Label><br>
            <asp:RadioButtonList ID="GenderRBL" runat="server">
                <asp:ListItem Value="Male">Male</asp:ListItem>
                <asp:ListItem Value="Female">Female</asp:ListItem>
            </asp:RadioButtonList><br>
            <asp:Button ID="RegisterBtn" runat="server" Text="Register" OnClick="RegisterBtn_Click"/> <br>
            <asp:Label ID="ErrorMes" runat="server" Text=" " ForeColor="Red"></asp:Label>
        </div>
    </form>
</body>
</html>
