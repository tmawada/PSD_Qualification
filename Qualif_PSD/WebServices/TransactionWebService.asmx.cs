using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Qualif_PSD.Handler;
using Qualif_PSD.Model;
using Qualif_PSD.Modules;

namespace Qualif_PSD.WebServices
{
    /// <summary>
    /// Summary description for TransactionWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class TransactionWebService : System.Web.Services.WebService
    {

        TransactionHandler transactionHandler = new TransactionHandler();

        [WebMethod]
        public string checkout(int userId)
        {
            return Json.Encode(transactionHandler.checkout(userId));
        }

        [WebMethod]
        public string getTransaction(int userId)
        {
            return Json.Encode(transactionHandler.getTransaction(userId));
        }

        [WebMethod]
        public string getTransactionDetail(int transactionId)
        {
            return Json.Encode(transactionHandler.GetTransactionDetail(transactionId));
        }
    }
}
