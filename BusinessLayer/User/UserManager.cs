using DTO;
using DTO.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Collections;

namespace BusinessLayer.UserManager
{
    public class UserManager : IUserManager
    {
        public User Login(string emailAddress, string password)
        {
            using (UserContext dc = new UserContext())
            {
                var user = dc.Users.Where(x => x.email.Equals(emailAddress) && x.password.Equals(password)).FirstOrDefault();
                return user;
            }
        }


        public bool Register(User user)
        {
            using (UserContext dc = new UserContext())
            {
                dc.Users.Add(user);
                dc.SaveChanges();

                return true;
            }
        }
    }
}
