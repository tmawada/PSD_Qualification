﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Qualif_PSD.Controller;
using Qualif_PSD.Factory;

namespace Qualif_PSD.Views
{
    public partial class WebForm2 : System.Web.UI.Page
    {

        UserController userController = new UserController();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void RegisterBtn_Click(object sender, EventArgs e)
        {
            string username = UsernameTB.Text;
            string email = EmailTB.Text;
            string password = PasswordTB.Text;
            string confirmPassword = ConfirmPassTB.Text;
            string gender = GenderRBL.SelectedValue;

            string errMsg = userController.createUser(username, email, password, confirmPassword, gender);

            if (string.IsNullOrEmpty(errMsg))
            {
                Response.Redirect("LoginPage.aspx"); 
            }
            else
            {
                ErrorMes.Text = errMsg;
            }
        }
    }
}