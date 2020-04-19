using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Doctor_Patient_Portal;
using BusinessLayer.User;
using Doctor_Patient_Portal.Classes;

namespace Doctor_Patient_Portal.Controllers
{
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly IUserManager userManager;
        public UsersController(IUserManager _userManager)
        {
            this.userManager = _userManager;
        }


        [Route("getCurrentUser")]
        [HttpPost]
        public IActionResult Login(LoginModel model)
        {
            if (string.IsNullOrEmpty(model.email) && string.IsNullOrEmpty(model.password))
            {
                return Ok("No User exists");
            }
            if (model.email == null)
            {
                return Ok("Please enter email address");
            }
            var user = userManager.Login(model.email,model.password);
            return Ok(user);
        }
    }
}
