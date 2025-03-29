using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Qualif_PSD.Handler;
using Qualif_PSD.Modules;

namespace Qualif_PSD.WebServices
{
    /// <summary>
    /// Summary description for UserWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class UserWebService : System.Web.Services.WebService
    {

        UserHandler userHandler = new UserHandler();

        [WebMethod]
        public string createUser(string username, string email, string password, string gender)
        {
            return Json.Encode(userHandler.createUser(username, email, password, gender));
        }

        [WebMethod]
        public string getUser(string username, string password)
        {
            return Json.Encode(userHandler.getUser(username, password));
        }
    }
}
