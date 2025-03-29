using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Qualif_PSD.Controller;
using Qualif_PSD.Model;

namespace WebApplicationFrontend.Views
{
    public partial class CartPage : System.Web.UI.Page
    {
        CartController cartController = new CartController();

        protected void Page_Load(object sender, EventArgs e)
        {
            refreshGrid();
        }
        public void refreshGrid()
        {
            MsUser user = Session["user"] as MsUser;
            int userId = user.Id;

            string message = "";

            //List<CartDetail> listItems = cartController.getAllItems(userId, out message);
            List<object> listItems = cartController.getUserCartDetails(userId);
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
            // 1️⃣ Get User from Session
            MsUser user = Session["user"] as MsUser;

            if (user == null)
            {
                ShowAlert("User not logged in.");
                return;
            }

            int userId = user.Id;

            List<CartDetail> cartItems = db.CartDetails.Where(c => c.customer_id == userId).ToList();
            if (cartItems.Count == 0)
            {
                ShowAlert("Cart is empty!");
                return;
            }

            // 3️⃣ Create Transaction Header
            TransactionHeader newTransaction = new TransactionHeader
            {
                user_id = userId,
                transaction_date = DateTime.Now
            };
            db.TransactionHeaders.Add(newTransaction);
            db.SaveChanges(); // Save to get transaction ID

            int transactionId = newTransaction.transaction_id; // Get generated Transaction ID

            //// 4️⃣ Insert into TransactionDetail
            foreach (CartDetail item in cartItems)
            {
                TransactionDetail detail = new TransactionDetail
                {
                    transaction_id = transactionId,
                    product_id = item.product_id
                };

                Debug.WriteLine("Product Id: " + detail.product_id);

                db.TransactionDetails.Add(detail);
                db.SaveChanges(); // Save transaction details
            }

            db.CartDetails.RemoveRange(cartItems);
            db.SaveChanges();

            ShowAlert("Checkout successful!");

            Response.Redirect("HomePage.aspx");
        }

        protected void BackBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }
    }
}