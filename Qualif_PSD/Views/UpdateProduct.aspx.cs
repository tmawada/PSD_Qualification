using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Qualif_PSD.Controller;
using Qualif_PSD.Model;

namespace Qualif_PSD.Views
{
    public partial class WebForm5 : System.Web.UI.Page
    {
        
        ProductController productController = new ProductController();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string id = Request["id"];
                if (!string.IsNullOrEmpty(id))
                {
                    int productId = int.Parse(id);

                    MsProduct product = productController.getProduct(productId); 

                    if(product != null)
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
            int id =int.Parse(ProductIDTB.Text);
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
    }
}