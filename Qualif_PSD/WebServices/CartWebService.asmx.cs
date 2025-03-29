using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Qualif_PSD.Handler;
using Qualif_PSD.Model;
using Qualif_PSD.Modules;
using Qualif_PSD.Repository;

namespace Qualif_PSD.WebServices
{
    /// <summary>
    /// Summary description for CartWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class CartWebService : System.Web.Services.WebService
    {

        CartHandler cartHandler = new CartHandler();

        [WebMethod]
        public string addToCart(int userId, int productId)
        {
            return Json.Encode(cartHandler.addToCart(userId, productId));
        }

        [WebMethod]
        public string removeFromCart(int cartId)
        {
            return Json.Encode(cartHandler.removeFromCart(cartId));
        }

        [WebMethod]
        public string getUserCartDetails(int userId)
        {
            return Json.Encode(cartHandler.getUserCartDetails(userId));
        }

        [WebMethod]
        public string getTotalPrice(int userId)
        {
            return Json.Encode(cartHandler.getTotalPrice(userId));
        }

    }
}
