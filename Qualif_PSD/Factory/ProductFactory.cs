using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Qualif_PSD.Model;

namespace Qualif_PSD.Factory
{
    public class ProductFactory
    {
        DatabaseEntities1 db = new DatabaseEntities1();
        public MsProduct addProduct(string productName, int productPrice, string productType)
        {
            MsProduct product = new MsProduct();
            product.product_name = productName;
            product.product_price = productPrice;
            product.product_type = productType;

            return product;
        }

    }
}