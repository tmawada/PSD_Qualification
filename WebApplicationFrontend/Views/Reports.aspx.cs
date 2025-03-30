using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplicationFrontend.Controller;
using WebApplicationFrontend.CrystalReport;
using WebApplicationFrontend.Datasets;
using WebApplicationFrontend.Model;
using WebApplicationFrontend.Modules;

namespace WebApplicationFrontend.Views
{
    public partial class Reports : System.Web.UI.Page
    {
        ProductController productController = new ProductController();
        TransactionController transactionController = new TransactionController();

        MsUser user;

        protected void Page_Load(object sender, EventArgs e)
        {

            user = Session["user"] as MsUser;

            if (user == null)
            {
                Response.Redirect("LoginPage.aspx");
            }

            CrystalReport1 report1 = new CrystalReport1();
            CrystalReportViewer1.ReportSource = report1;
            DataSet ds = getDataset(user.Id);
        }

        public DataSet getDataset(int userId)
        {
            DataSet dataset = new DataSet();
            var headerTable = dataset.TransactionHeader;
            var detailTable = dataset.TransactionDetail;

            List<TransactionHeader> transactionList = transactionController.getTransaction(user.Id);

            foreach(TransactionHeader th in transactionList)
            {
                var hrow = headerTable.NewRow();
                hrow["user_Id"] = user.Id;
                hrow["Transaction_Id"] = th.transaction_id;
                headerTable.Rows.Add(hrow);

                List<TransactionDetail> products = transactionController.getTransactionDetail(th.transaction_id);

                foreach (TransactionDetail product in products)
                {
                    var drow = detailTable.NewRow();
                    drow["Transaction_Id"] = product.transaction_id;
                    drow["Product_Id"] = product.product_id;
                }
                break;
            }

            return dataset;
        }

    }
}