using DTO;
using DTO.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Collections;

namespace BusinessLayer.User
{
    public class UserManager : IUserManager
    {
        public Users Login(string emailAddress, string password)
        {
            using (UserContext dc = new UserContext())
            {
                var query = from u in dc.Users
                            where u.Email_Address == emailAddress
                            select u;
                var user = query.FirstOrDefault<Users>();
                return user;
            }
        }


        public List<Users> Register(Users user)
        {
            using (UserContext dc = new UserContext())
            {
      
            var userModel = dc.Users.Include("Users")
                           .Select(u => new Users()
                           {
                               ID = u.ID,
                               User_Name = u.User_Name,
                               Email_Address = u.Email_Address,
                               Password = u.Password,
                               User_Type = u.User_Type,
                               Permission_Flag = u.Permission_Flag,
                               Phone = u.Phone,
                               isDeleted = u.isDeleted,
                               First_Name = u.First_Name,
                               Last_Name=u.Last_Name,
                               Speciality=u.Speciality,
                               BloodGroup=u.BloodGroup,
                               Age=u.Age,
                               City=u.City,
                               Address=u.Address,
                               StoreName=u.StoreName
                           }).ToList<Users>();

                if (userModel.Count == 0)
                {
                    return null;
                }
                return (userModel);
            }
             
        }
    }
}
