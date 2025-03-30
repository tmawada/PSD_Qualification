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
    public partial class UpdateProduct : System.Web.UI.Page
    {
        ProductController productController = new ProductController();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("LoginPage.aspx");
            }

            if (!IsPostBack)
            {
                string id = Request["id"];
                if (!string.IsNullOrEmpty(id))
                {
                    int productId = int.Parse(id);

                    MsProduct product = productController.getProduct(productId);

                    if (product != null)
                    {
                        ProductIDTB.Text = Convert.ToString(product.Id);
                        ProductNameTB.Text = product.product_name;
                        ProductPriceTB.Text = Convert.ToString(product.product_price);
                    }
                }
            }
        }

        protected void UpdateProductBtn_Click(object sender, EventArgs e)
        {
            int id = int.Parse(ProductIDTB.Text);
            string name = ProductNameTB.Text;
            int price = int.Parse(ProductPriceTB.Text);
            string productType = ProductTypeDD.SelectedValue;

            MsProduct product = productController.updateProduct(id, name, price, productType);

            if (product != null)
            {
                Response.Redirect("AdminPage.aspx");
            }
            else
            {
                errorMes.Text = "Can't update product";
            }

        }

        protected void BackBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminPage.aspx");
        }
    }
}