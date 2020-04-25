using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Doctor_Patient_Portal.Classes
{
    public class LoginModel
    {
        public string email { get; set; }
        public string password { get; set; }
    }

    public class LocationRequest
    {
        public double latitude { get; set; }
        public double longitude { get; set; }
    }
}
