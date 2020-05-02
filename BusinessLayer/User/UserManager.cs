using DTO;
using DTO.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Collections;
using System.Net.Mail;

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

        private void SendEmailToPatient(string patientEmail, int? patientId)
        {
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

            mail.From = new MailAddress("samreenfarooqi1994@gmail.com");
            mail.To.Add(patientEmail);
            mail.IsBodyHtml = true;
            mail.Subject = "Confirm your account";
            string htmlString = @"<html>
                      <body>
                      <p>Welcome to Patient Portal</p>
                      <p>Click on : <a href='https://localhost:44376/api/users/ConfirmPatientEmail?patientId=" + patientId + "'>This Link</a> to confirm your account</p>" +
                      "< p>Sincerely, Patient Portal Team</br></p>" +
                      "</body>" +
                      "</html>;";
            mail.Body = htmlString;
            SmtpServer.Port = 587;
            SmtpServer.UseDefaultCredentials = false;
            SmtpServer.Credentials = new System.Net.NetworkCredential("samreenfarooqi1994@gmail.com", "Samreen_oo11"); // Place your credentials here.
            SmtpServer.EnableSsl = true;

            SmtpServer.Send(mail);
        }


        public bool Register(User user)
        {
            using (UserContext dc = new UserContext())
            {
                var found = dc.Users.Where(x => x.email.Equals(user.email) && x.deleted == false).FirstOrDefault();
                if (found != null)
                {
                    return false;
                }
                if (user.userType == 1 || user.userType == 2)
                {
                    user.blocked = true;
                }
                dc.Users.Add(user);
                dc.SaveChanges();

                if (user.userType == 2)
                {
                    this.SendEmailToPatient(user.email, user.userId);
                }

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
                u.email = user.email;
                u.phone = user.phone;
                u.address = user.address;
                u.storeName = user.storeName;
                u.age = user.age;

                dc.Users.Update(u);
                dc.SaveChanges();

                return true;
            }
        }

        public List<User> FetchAllUsers(int userType, string userSearch)
        {
            using (UserContext dc = new UserContext())
            {
                List<User> u = new List<User>();
                if (userSearch == null || userSearch.Equals(""))
                {
                    u = dc.Users.Where(x => x.deleted == false && x.userType != 0 && x.userType == userType).ToList();
                }
                else
                {
                    u = dc.Users.Where(x => x.deleted == false && x.userType != 0 && x.userType == userType && (x.email.Contains(userSearch)
                        || x.firstName.Contains(userSearch) || x.lastName.Contains(userSearch) || x.city.Contains(userSearch))).ToList();
                }

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
