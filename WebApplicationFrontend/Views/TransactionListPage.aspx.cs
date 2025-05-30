﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplicationFrontend.Controller;
using WebApplicationFrontend.Model;

namespace WebApplicationFrontend.Views
{
    public partial class TransactionListPage : System.Web.UI.Page
    {
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

            List<TransactionHeader> transactions = transactionController.getTransaction(userId);
            if (transactions != null)
            {
                TransactionGV.DataSource = transactions;
                TransactionGV.DataBind();
            }
        }

        protected void BackBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }
    }
}