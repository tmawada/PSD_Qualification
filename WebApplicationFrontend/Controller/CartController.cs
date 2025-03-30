using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Qualif_PSD.Modules;
using WebApplicationFrontend.Model;

namespace WebApplicationFrontend.Controller
{
    public class CartController
    {
        CartWebService.CartWebService cartWebService = new CartWebService.CartWebService();

        public string addToCart(int userId, int productId)
        {
            CartDetail cart = Json.Decode<CartDetail>(cartWebService.addToCart(userId, productId));
            if (cart == null)
            {
                return "Item added successful";
            }
            return "Item already in cart";
        }

        public string removeFromCart(int cartId)
        {
            CartDetail cart = Json.Decode<CartDetail>(cartWebService.removeFromCart(cartId));

            if (cart == null)
            {
                return "Item not found";
            }
            return "Item removed";

        }

        public List<CartDetail> getUserCartDetails(int userId)
        {
            List<CartDetail> userCartDetail = Json.Decode<List<CartDetail>>(cartWebService.getUserCartDetails(userId));

            return userCartDetail;
        }

        public int getTotalPrice(int userId)
        {
            int total = Json.Decode<int>(cartWebService.getTotalPrice(userId));

            return total;
        }
    }
}