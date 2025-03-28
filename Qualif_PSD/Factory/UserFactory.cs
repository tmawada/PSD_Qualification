using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Qualif_PSD.Model;

namespace Qualif_PSD.Factory
{
    public class UserFactory
    {
        public MsUser createUser(string username, string email, string password, string gender)
        {
            MsUser user = new MsUser();
            user.username = username;
            user.email = email;
            user.password = password;
            user.gender = gender;
            user.role = "Guest";

            return user;
        }

    }
}