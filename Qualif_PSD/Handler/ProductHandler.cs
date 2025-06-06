﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Qualif_PSD.Repository;
using Qualif_PSD.Model;

namespace Qualif_PSD.Handler
{
    public class ProductHandler
    {
        ProductRepository productRepository = new ProductRepository();

        public string addProduct(string productName, int productPrice, string productType)
        {
            productRepository.addProduct(productName, productPrice, productType);

            return "Product Added Successful";

        }

        public string deleteProduct(int productId)
        {
            productRepository.deleteProduct(productId);
            return "Product Delete Successful";
        }

        public MsProduct getProduct(int productId)
        {
            return productRepository.getProduct(productId);
        }

        public MsProduct updateProduct(int id, string productName, int productPrice, string productType)
        {
            return productRepository.updateProduct(id, productName, productPrice, productType);
        }

        public List<MsProduct> getAllProduct()
        {
            return productRepository.getAllProduct();
        }

    }
}