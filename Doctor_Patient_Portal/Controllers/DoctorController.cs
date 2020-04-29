using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Doctor;
using BusinessLayer.Patient;
using Doctor_Patient_Portal.Classes;
using DTO.DBModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Doctor_Patient_Portal.Controllers
{
    [Route("api/doctor")]
    [ApiController]
    [Produces("application/json")]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorManager doctorManager;
        public DoctorController(IDoctorManager _doctorManager)
        {
            this.doctorManager = _doctorManager;
        }

        [HttpGet]
        [Route("GetDoctorAppointments")]
        public IActionResult GetPatientAppointments(int doctorId)
        {
            var appointments = this.doctorManager.GetDoctorAppointmentList(doctorId);
            return Ok(appointments);
        }
    }
}