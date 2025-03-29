using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Qualif_PSD.Repository;
using Qualif_PSD.Model;

namespace Qualif_PSD.Handler
{
    public class UserHandler
    {
        UserRepository userRepository = new UserRepository();

        public MsUser createUser(string username, string email, string password, string gender)
        {
            return userRepository.createUser(username, email, password, gender);
        }

        public MsUser getUser(string username, string password)
        {
            return userRepository.getUser(username, password);
        }

    }
}