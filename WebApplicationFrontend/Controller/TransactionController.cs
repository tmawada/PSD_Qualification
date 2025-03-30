using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplicationFrontend.Modules;
using WebApplicationFrontend.Model;
using Qualif_PSD.Repository;

namespace WebApplicationFrontend.Controller
{
    public class TransactionController
    {
        public string checkout(int userId)
        {
            TransactionWebService.TransactionWebService transactionWebService = new TransactionWebService.TransactionWebService();

            string jsonResponse = transactionWebService.checkout(userId);

            return Json.Decode<string>(jsonResponse);
        }

        public List<TransactionHeader> getTransaction(int userId)
        {
            TransactionWebService.TransactionWebService transactionWebService = new TransactionWebService.TransactionWebService();

            string jsonResponse = transactionWebService.getTransaction(userId);

            return Json.Decode<List<TransactionHeader>>(jsonResponse);
        }

        public List<TransactionDetail> getTransactionDetail(int transactionId)
        {
            TransactionWebService.TransactionWebService transactionWebService = new TransactionWebService.TransactionWebService();

            string jsonResponse = transactionWebService.getTransactionDetail(transactionId);

            return Json.Decode<List<TransactionDetail>>(jsonResponse);
        }
    }
}