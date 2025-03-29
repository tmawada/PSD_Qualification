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
    /// Summary description for ProductWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class ProductWebService : System.Web.Services.WebService
    {

        ProductHandler productHandler = new ProductHandler();

        [WebMethod]
        public string addProduct(string productName, int productPrice, string productType)
        {
            return Json.Encode(productHandler.addProduct(productName, productPrice, productType));
        }

        [WebMethod]
        public string deleteProduct(int productId)
        {
            return Json.Encode(productHandler.deleteProduct(productId));
        }

        [WebMethod]
        public string getProduct(int productId)
        {
            return Json.Encode(productHandler.getProduct(productId));
        }

        [WebMethod]
        public string updateProduct(int id, string productName, int productPrice, string productType)
        {
            return Json.Encode(productHandler.updateProduct(id, productName, productPrice, productType));
        }

        [WebMethod]
        public string getAllProduct()
        {
            return Json.Encode(productHandler.getAllProduct());
        }

    }
}
