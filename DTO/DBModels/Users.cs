using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTO
{
    [Table("Users")]
    public class Users
    {
        public string User_Name { get; set; }
        public string Email_Address { get; set; }
        public string Password { get; set; }
        public string User_Type { get; set; }
        public bool? Permission_Flag { get; set; }
        public string Phone { get; set; }
        public bool? isDeleted { get; set; }
        [Key]
        public int? ID { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Speciality { get; set; }
        public string BloodGroup { get; set; }
        public int? Age { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string StoreName { get; set; }
    }

}
