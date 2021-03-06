﻿using DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.UserManager
{
    public interface IUserManager
    {
        User Login(string emailAddress, string password);
        bool Register(User user);
        bool UpdateUser(User user);

        List<User> FetchAllUsers(int userType, string userSearch);
    }
}
