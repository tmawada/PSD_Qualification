using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Qualif_PSD.Controller;
using Qualif_PSD.Model;

namespace Qualif_PSD.Views
{
    public partial class AdminPage : System.Web.UI.Page
    {

        ProductController productController = new ProductController();

        protected void Page_Load(object sender, EventArgs e)
        {
            refreshGrid();
        }

        public void refreshGrid()
        {
            List<MsProduct> products = productController.getAllProduct();
            if (products != null)
            {
                ProductGV.DataSource = products;
                ProductGV.DataBind();
            }
            else
            {
                Message.Text = "There is no products";
            }
        }

        protected void AddProductBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddProduct.aspx");

        }

        protected void ProductGV_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = ProductGV.Rows[e.RowIndex];
            int id = int.Parse(row.Cells[0].Text);

            productController.deleteProduct(id);

            refreshGrid();
        }

        protected void ProductGV_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewRow row = ProductGV.Rows[e.NewEditIndex];
            int id = int.Parse(row.Cells[0].Text);

            Response.Redirect("UpdateProduct.aspx?Id=" + id);
        }
    }
}