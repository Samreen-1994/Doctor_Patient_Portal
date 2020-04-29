using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTO
{
    [Table("Users")]
    public class User
    {
        [Key]
        public int? userId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public long? phone { get; set; }
        public string speciality { get; set; }
        public string gender { get; set; }
        public string bloodGroup { get; set; }
        public int? age { get; set; }
        public string city { get; set; }
        public int? userType { get; set; }
        public string address { get; set; }
        public string storeName { get; set; }
        public double? latitude { get; set; }
        public double? longitude { get; set; }
        public bool deleted { get; set; }
        public bool blocked { get; set; }
    }

}
