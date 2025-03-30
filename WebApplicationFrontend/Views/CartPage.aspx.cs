using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplicationFrontend.Controller;
using WebApplicationFrontend.Model;

namespace WebApplicationFrontend.Views
{
    public partial class CartPage : System.Web.UI.Page
    {
        CartController cartController = new CartController();

        TransactionController transactionController = new TransactionController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("LoginPage.aspx");
            }
            refreshGrid();
        }
        public void refreshGrid()
        {
            MsUser user = Session["user"] as MsUser;
            int userId = user.Id;

            string message = "";

            List<CartDetail> listItems = cartController.getUserCartDetails(userId);
            
            int totalPrice = 0;

            if (listItems.Count > 0)
            {
                CartGV.DataSource = listItems;
                CartGV.DataBind();
                totalPrice = cartController.getTotalPrice(userId);
                PriceLB.Text = totalPrice.ToString();
            }
            else
            {
                MessageLB.Text = message;
            }
        }

        protected void CartGV_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = CartGV.Rows[e.RowIndex];
            int id = int.Parse(row.Cells[0].Text);

            string message = cartController.removeFromCart(id);

            ShowAlert(message);

            refreshGrid();
        }

        protected void ShowAlert(string message)
        {
            string script = $"alert('{message}');";
            ClientScript.RegisterStartupScript(this.GetType(), "Alert", script, true);
        }

        DatabaseEntities db = new DatabaseEntities();
        protected void CheckoutBtn_Click(object sender, EventArgs e)
        {
            MsUser user = Session["user"] as MsUser;

            if (user == null)
            {
                ShowAlert("Not logged in.");
                return;
            }

            int userId = user.Id;
            
            transactionController.checkout(userId);

            ShowAlert("Checkout successful!");

            Response.Redirect("HomePage.aspx");
        }

        protected void BackBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }
    }
}