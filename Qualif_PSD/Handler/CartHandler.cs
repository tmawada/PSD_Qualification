using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Qualif_PSD.Repository;
using Qualif_PSD.Model;

namespace Qualif_PSD.Handler
{
    public class CartHandler
    {
        CartRepostitory cartRepository = new CartRepostitory();
        public CartDetail addToCart(int userId, int productId)
        {
            return cartRepository.addToCart(userId, productId);
        }

        public CartDetail removeFromCart(int cartId)
        {
            return cartRepository.removeFromCart(cartId);
        }

        public List<object> getUserCartDetails(int userId)
        {
            return cartRepository.getUserCartDetails(userId);
        }

        public int getTotalPrice(int userId)
        {
            return cartRepository.getTotalPrice(userId);
        }

        public void checkout(int userId)
        {

        }

    }
}