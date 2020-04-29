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
                if (user.userType == 2 || user.userType == 3)
                {
                    user.blocked = true;
                }

                dc.Users.Add(user);
                dc.SaveChanges();

                return true;
            }
        }

        public bool UpdateUser(User user)
        {
            using (UserContext dc = new UserContext())
            {
                var u = dc.Users.Where(x => x.userId == user.userId).FirstOrDefault();
                u.deleted = user.deleted;
                u.blocked = user.blocked;
                u.city = user.city;
                u.firstName = user.firstName;
                u.lastName = user.lastName;

                dc.Users.Update(u);
                dc.SaveChanges();

                return true;
            }
        }

        public List<User> FetchAllUsers()
        {
            using (UserContext dc = new UserContext())
            {
                var u = dc.Users.Where(x => x.deleted == false && x.userType !=0).ToList();
                if (u != null)
                {
                    return u;
                }
                else
                {
                    return new List<User>();
                }
            }
        }
    }
}
