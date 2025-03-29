using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Qualif_PSD.Handler;
using Qualif_PSD.Model;

namespace Qualif_PSD.Controller
{
    public class TransactionController
    {   
        TransactionHandler transactionHandler = new TransactionHandler();
        public void checkout(int userId)
        {
            transactionHandler.checkout(userId);
        }

        public List<TransactionHeader> getTransaction(int userId)
        {
            return transactionHandler.getTransaction(userId);
        }

    }
}