<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TransactionListPage.aspx.cs" Inherits="Qualif_PSD.Views.TransactionListPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Transaction List</h1> 

            <asp:Button ID="BackBtn" runat="server" Text="Back" OnClick="BackBtn_Click" /> <br><br>

            <asp:GridView ID="TransactionGV" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="transaction_id" HeaderText="transaction_id" SortExpression="transaction_id" />
                    <asp:BoundField DataField="transaction_date" HeaderText="transaction_date" SortExpression="transaction_date" />
                </Columns>

            </asp:GridView>
        </div>
    </form>
</body>
</html>
