using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Qualif_PSD.Handler;
using Qualif_PSD.Model;

namespace WebApplicationFrontend.Controller
{
    public class ProductController
    {
        ProductHandler productHandler = new ProductHandler();

        public void addProduct(string productName, int productPrice, string productType)
        {
            productHandler.addProduct(productName, productPrice, productType);
        }

        public void deleteProduct(int productId)
        {
            productHandler.deleteProduct(productId);
        }

        public MsProduct getProduct(int productId)
        {
            return productHandler.getProduct(productId);
        }

        public MsProduct updateProduct(int id, string productName, int productPrice, string productType)
        {

            MsProduct product = productHandler.updateProduct(id, productName, productPrice, productType);

            if (product != null)
            {
                return product;
            }
            return null;
        }

        public List<MsProduct> getAllProduct()
        {
            return productHandler.getAllProduct();
        }
    }
}