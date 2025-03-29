using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Qualif_PSD.Handler;
using Qualif_PSD.Model;

namespace WebApplicationFrontend.Controller
{
    public class CartController
    {
        CartHandler cartHandler = new CartHandler();

        public string addToCart(int userId, int productId)
        {
            CartDetail cart = cartHandler.addToCart(userId, productId);
            if (cart == null)
            {
                return "Item added successful";
            }
            return "Item already in cart";
        }

        public string removeFromCart(int cartId)
        {
            CartDetail cart = cartHandler.removeFromCart(cartId);

            if (cart == null)
            {
                return "Item not found";
            }
            return "Item removed";

        }

        public List<object> getUserCartDetails(int userId)
        {
            return cartHandler.getUserCartDetails(userId);
        }

        public int getTotalPrice(int userId)
        {
            return cartHandler.getTotalPrice(userId);
        }
    }
}