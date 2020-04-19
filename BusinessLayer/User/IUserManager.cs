using DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.User
{
   public interface IUserManager
    {
        //string Signup (Users user);
        Users Login(string emailAddress,string password);
    }
}
