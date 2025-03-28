using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Qualif_PSD.Model;

namespace Qualif_PSD.Factory
{
    public class CartFactory
    {
        public CartDetail addToCart(int userId, int productId)
        {
            CartDetail cart = new CartDetail
            {
                customer_id = userId,
                product_id = productId,
            };

            return cart;
        }

    }
}