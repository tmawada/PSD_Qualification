using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplicationFrontend.Model;
using WebApplicationFrontend.Modules;

namespace WebApplicationFrontend.Controller
{
    public class ProductController
    {

        public string addProduct(string productName, int productPrice, string productType)
        {
            ProductWebService.ProductWebService productWebService = new ProductWebService.ProductWebService();

            string jsonResponse = productWebService.addProduct(productName, productPrice, productType);

            return Json.Decode<string>(jsonResponse);
        }

        public string deleteProduct(int productId)
        {
            ProductWebService.ProductWebService productWebService = new ProductWebService.ProductWebService();

            string jsonResponse = productWebService.deleteProduct(productId);

            return Json.Decode<string>(jsonResponse);
        }

        public MsProduct getProduct(int productId)
        {

            ProductWebService.ProductWebService productWebService = new ProductWebService.ProductWebService();

            string jsonResponse = productWebService.getProduct(productId);

            return Json.Decode<MsProduct>(jsonResponse);

        }

        public MsProduct updateProduct(int id, string productName, int productPrice, string productType)
        {

            ProductWebService.ProductWebService productWebService = new ProductWebService.ProductWebService();

            string jsonResponse = productWebService.updateProduct(id, productName, productPrice, productType);

            return Json.Decode<MsProduct>(jsonResponse);

            //MsProduct product = productHandler.updateProduct(id, productName, productPrice, productType);

            //if (product != null)
            //{
            //    return product;
            //}
            //return null;
        }

        public List<MsProduct> getAllProduct()
        {
            ProductWebService.ProductWebService productWebService = new ProductWebService.ProductWebService();

            string jsonResponse = productWebService.getAllProduct();

            return Json.Decode<List<MsProduct>>(jsonResponse);
        }
    }
}