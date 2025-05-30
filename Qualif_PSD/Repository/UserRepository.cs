﻿using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using Qualif_PSD.Factory;
using Qualif_PSD.Model;

namespace Qualif_PSD.Repository
{
    public class UserRepository
    {
        DatabaseEntities1 db = new DatabaseEntities1();

        UserFactory userFactory = new UserFactory();

        public MsUser createUser(string username, string email, string password, string gender)
        {
            MsUser user= userFactory.createUser(username, email, password, gender);

            db.MsUsers.Add(user);
            db.SaveChanges();

            return user;
        }

        public MsUser getUser(string username, string password)
        {
            MsUser user = (from usr in db.MsUsers where usr.username == username && usr.password == password select usr).FirstOrDefault();
            return user;
        }

    }
}