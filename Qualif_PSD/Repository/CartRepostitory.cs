using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Util;
using Qualif_PSD.Factory;
using Qualif_PSD.Model;

namespace Qualif_PSD.Repository
{
    public class CartRepostitory
    {

        DatabaseEntities db = new DatabaseEntities();

        CartFactory factory = new CartFactory();

        public CartDetail addToCart(int userId, int productId)
        {
            CartDetail existingCartItem = db.CartDetails.FirstOrDefault(c => c.customer_id == userId && c.product_id == productId);

            if (existingCartItem == null)
            {
                CartDetail cartDetail = factory.addToCart(userId, productId);

                db.CartDetails.Add(cartDetail);

                db.SaveChanges();
            }

            return existingCartItem;
        }

        public CartDetail removeFromCart(int cartId)
        {
            CartDetail cart = db.CartDetails.Where(carts => carts.product_id == cartId).FirstOrDefault();
            
            if(cart != null)
            {
                db.CartDetails.Remove(cart);
                db.SaveChanges();
            }
            return cart;
        }

        public List<object> getUserCartDetails(int userId)
        {
            var cartItems = (from cart in db.CartDetails
                             join product in db.MsProducts
                             on cart.product_id equals product.Id
                             where cart.customer_id == userId
                             select new
                             {
                                 cart.product_id,
                                 product.product_name,
                                 product.product_price
                             }).ToList();

            return cartItems.Cast<object>().ToList();
        }

        public int getTotalPrice(int userId)
        {
            try
            {
                int total = (from cart in db.CartDetails
                             join product in db.MsProducts
                             on cart.product_id equals product.Id
                             where cart.customer_id == userId
                             select product.product_price).Sum();

                return total;
            }
            catch (Exception ex) { 
                return 0;
            }
        }

        public void checkout(int userId)
        {
            List<CartDetail> cartItems = db.CartDetails.Where(c => c.customer_id == userId).ToList();

            if (cartItems.Count == 0)
            {
                return;
            }

            TransactionHeader newTransaction = createTransactionHeader(userId);

            int transactionId = newTransaction.transaction_id;

            createTransactionDetail(cartItems, transactionId);

            removeCart(cartItems);

        }

        public TransactionHeader createTransactionHeader(int userId)
        {
            TransactionHeader newTransaction = new TransactionHeader
            {
                user_id = userId,
                transaction_date = DateTime.Now
            };
            db.TransactionHeaders.Add(newTransaction);
            db.SaveChanges();

            return newTransaction;
        }

        public void createTransactionDetail(List<CartDetail> cartItems, int transactionId)
        {
            foreach (CartDetail item in cartItems)
            {
                TransactionDetail detail = new TransactionDetail
                {
                    transaction_id = transactionId,
                    product_id = item.product_id
                };

                //Debug.WriteLine("Product Id: " + detail.product_id);

                db.TransactionDetails.Add(detail);
            }
            db.SaveChanges(); 
        }

        public void removeCart(List<CartDetail> cartItems)
        {
            db.CartDetails.RemoveRange(cartItems);
            db.SaveChanges();
        }

    }
}