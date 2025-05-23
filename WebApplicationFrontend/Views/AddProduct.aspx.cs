﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplicationFrontend.Controller;

namespace WebApplicationFrontend.Views
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        ProductController productController = new ProductController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("LoginPage.aspx");
            }
        }

        protected void AddProductBtn_Click(object sender, EventArgs e)
        {
            string productName = ProductNameTB.Text;
            int productPrice = int.Parse(ProductPriceTB.Text);
            string productType = ProductTypeDD.SelectedValue;

            productController.addProduct(productName, productPrice, productType);

            Response.Redirect("AdminPage.aspx");

        }

        protected void BackBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminPage.aspx");
        }
    }
}