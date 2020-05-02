using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Doctor_Patient_Portal;
using BusinessLayer.UserManager;
using Doctor_Patient_Portal.Classes;
using DTO;
using Microsoft.AspNetCore.Cors;

namespace Doctor_Patient_Portal.Controllers
{
    [Route("api/users")]
    [Produces("application/json")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserManager userManager;
        public UsersController(IUserManager _userManager)
        {
            this.userManager = _userManager;
        }


        [Route("loginUser")]
        [HttpPost]
        public IActionResult Login([FromBody]LoginModel model)
        {
            if (string.IsNullOrEmpty(model.email) && string.IsNullOrEmpty(model.password))
            {
                return Ok("noUserFound");
            }
            var user = userManager.Login(model.email, model.password);
            if (user != null)
            {
                return Ok(user);
            }
            else
            {
                return Ok("noUserFound");
            }
        }

        [Route("registerUser")]
        [HttpPost]
        public IActionResult Register(User user)
        {
            try
            {
                var success = userManager.Register(user);
                return Ok(success);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [Route("editUser")]
        [HttpPost]
        public IActionResult EditUser(User user)
        {
            try
            {
                var success = userManager.UpdateUser(user);
                return Ok(success);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [Route("fetchAllUsers")]
        [HttpGet]
        public IActionResult FetchAllUsers(int userType, string userSearch)
        {
            try
            {
                var success = userManager.FetchAllUsers(userType,userSearch);
                return Ok(success);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [Route("ConfirmPatientEmail")]
        [HttpGet]
        public IActionResult ConfirmPatientEmail(int patientId)
        {
            try
            {
                var user = new User();
                user.userId = patientId;
                user.blocked = false;
                user.deleted = false;

                var success = userManager.UpdateUser(user);
                return Redirect(@"http://localhost:4200/");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
