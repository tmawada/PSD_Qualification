﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Qualif_PSD.Modules;
using WebApplicationFrontend.Model;

namespace WebApplicationFrontend.Controller
{
    public class UserController
    {
        public string createUser(string username, string email, string password, string confirmPassword, string gender)
        {
            if (string.IsNullOrEmpty(username))
            {
                return "Username can't be empty";
            }
            else if (username.Length < 5)
            {
                return "Username must more than 5 character";
            }
            else if (string.IsNullOrEmpty(email))
            {
                return "Email can't be empty";
            }
            else if (password.Length <= 0)
            {
                return "Password can't be empty";
            }
            else if (!confirmPassword.Equals(password))
            {
                return "Password not match";
            }
            else if (string.IsNullOrEmpty(gender))
            {
                return "Gender Must be selected";
            }
            else
            {
                UserWebService.UserWebService userWebService = new UserWebService.UserWebService();
                userWebService.createUser(username, email, password, gender);

                return "";
            }
        }

        public string getUser(string username, string password, out string role)
        {
            role = " ";

            if (string.IsNullOrEmpty(username))
            {
                return "Username can't be empty";
            }
            else if (username.Length < 5)
            {
                return "Username length must more than 5 character";
            }
            else if (string.IsNullOrEmpty(password))
            {
                return "Password can't be empty";
            }
            else
            {
                UserWebService.UserWebService userWebService = new UserWebService.UserWebService();

                string response = userWebService.getUser(username, password);

                MsUser user = Json.Decode<MsUser>(response);

                if (user != null)
                {
                    HttpContext.Current.Session["user"] = user;
                    role = user.role;
                    return "";
                }
                else
                {
                    return "Username or password is incorrect";
                }
            }

        }
    }
}