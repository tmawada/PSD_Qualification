using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Qualif_PSD.Controller;

namespace Qualif_PSD.Views
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        ProductController productController = new ProductController();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void AddProductBtn_Click(object sender, EventArgs e)
        {
            string productName = ProductNameTB.Text;
            int productPrice = int.Parse(ProductPriceTB.Text);
            string productType = ProductTypeDD.SelectedValue;

            productController.addProduct(productName, productPrice, productType);

            Response.Redirect("AdminPage.aspx");

        }
    }
}