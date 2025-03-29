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
    public partial class LoginPage : System.Web.UI.Page
    {
        UserController userController = new UserController();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LoginBtn_Click(object sender, EventArgs e)
        {

            string username = UsernameTB.Text;
            string password = PasswordTB.Text;
            string role = "";

            string message = userController.getUser(username, password, out role);

            if (string.IsNullOrEmpty(message))
            {
                if (role == "Guest")
                {
                    Response.Redirect("HomePage.aspx");
                }
                else
                {
                    Response.Redirect("AdminPage.aspx");
                }
            }
            else
            {
                ErrorMes.Text = message;
            }

        }
    }
}