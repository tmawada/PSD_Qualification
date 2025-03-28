using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using Qualif_PSD.Factory;
using Qualif_PSD.Model;

namespace Qualif_PSD.Repository
{
    public class ProductRepository
    {

        ProductFactory productFactory = new ProductFactory();

        DatabaseEntities db = new DatabaseEntities();

        public void addProduct(string productName, int productPrice, string productType)
        {
            MsProduct product = productFactory.addProduct(productName, productPrice, productType);

            db.MsProducts.Add(product);
            db.SaveChanges();
        }

        public void deleteProduct(int productId)
        {
            MsProduct product = db.MsProducts.Find(productId);
            db.MsProducts.Remove(product);
            db.SaveChanges();
        }

        public MsProduct getProduct(int productId)
        {
            MsProduct product = db.MsProducts.Find(productId);

            return product;
        }

        public MsProduct updateProduct(int id, string productName, int productPrice, string productType)
        {
            MsProduct product = db.MsProducts.Find(id);

            product.product_name = productName;
            product.product_price = productPrice;
            product.product_type = productType;

            db.SaveChanges();

            return product;
        }

        public List<MsProduct> getAllProduct()
        {
            return db.MsProducts.ToList();
        }
            
    }
}