using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplicationFrontend.Controller;
using WebApplicationFrontend.Model;

namespace WebApplicationFrontend.Views
{
    public partial class HomePage : System.Web.UI.Page
    {
        ProductController productController = new ProductController();

        CartController cartController = new CartController();

        private string role = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("LoginPage.aspx");
            }

            if (!IsPostBack)
            {
                MsUser user = Session["user"] as MsUser;

                if (user != null)
                {
                    role = user.role;
                }

                refreshGrid();
            }
        }
        public void refreshGrid()
        {
            List<MsProduct> products = productController.getAllProduct();
            if (products != null)
            {
                ProductGV.DataSource = products;
                ProductGV.DataBind();
            }
        }

        protected void ProductGV_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "AddToCart")
            {
                int productId = Convert.ToInt32(e.CommandArgument);

                MsUser user = Session["user"] as MsUser;

                int userId = user.Id;

                string message = cartController.addToCart(userId, productId);

                ShowAlert(message);
            }
        }

        protected void ShowAlert(string message)
        {
            string script = $"alert('{message}');";
            ClientScript.RegisterStartupScript(this.GetType(), "Alert", script, true);
        }

        protected void CartBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("CartPage.aspx");
        }
        protected void TransactionBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("TransactionListPage.aspx");
        }
    }
}