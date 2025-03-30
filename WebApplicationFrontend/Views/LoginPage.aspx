<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="WebApplicationFrontend.Views.LoginPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1> LOGIN</h1>
            <asp:Label ID="UsernameLB" runat="server" Text="Username"></asp:Label><br>
            <asp:TextBox ID="UsernameTB" runat="server"></asp:TextBox> <br>
            <asp:Label ID="PasswordLB" runat="server" Text="Password"></asp:Label><br>
            <asp:TextBox ID="PasswordTB" runat="server" TextMode="Password"></asp:TextBox> <br><br>
            <asp:Button ID="LoginBtn" runat="server" Text="Login" OnClick="LoginBtn_Click"/><br>
            <asp:Label ID="ErrorMes" runat="server" Text=" " ForeColor="Red"></asp:Label><br>
            <asp:HyperLink ID="RegisterHL" runat="server" NavigateUrl="~/Views/RegisterPage.aspx">Don't have account ? Register here</asp:HyperLink>
        </div>
    </form>
</body>
</html>
