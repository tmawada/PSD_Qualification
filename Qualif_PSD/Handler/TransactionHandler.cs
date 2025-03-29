using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Qualif_PSD.Repository;
using Qualif_PSD.Model;

namespace Qualif_PSD.Handler
{
    public class TransactionHandler
    {
        TransactionRepository transactionRepository = new TransactionRepository();
        public string checkout(int userId)
        {
            return transactionRepository.checkout(userId);
        }

        public List<TransactionHeader> getTransaction(int userId)
        {
            return transactionRepository.getTransaction(userId);
        }

    }
}