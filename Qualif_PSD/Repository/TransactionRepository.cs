using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Qualif_PSD.Factory;
using Qualif_PSD.Model;


namespace Qualif_PSD.Repository
{
    public class TransactionRepository
    {
        DatabaseEntities1 db = new DatabaseEntities1();
        public string checkout(int userId)
        {
            List<CartDetail> cartItems = db.CartDetails.Where(c => c.customer_id == userId).ToList();

            if (cartItems.Count == 0)
            {
                return "There's no item in cart";
            }

            TransactionHeader newTransaction = createTransactionHeader(userId);

            int transactionId = newTransaction.transaction_id;

            createTransactionDetail(cartItems, transactionId);

            removeCart(cartItems);

            return "Checkout successful";
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

        public List<TransactionHeader> getTransaction(int userId)
        {
            List<TransactionHeader> transactionList = db.TransactionHeaders.Where(t => t.user_id == userId).ToList();

            return transactionList;

        }

    }
}