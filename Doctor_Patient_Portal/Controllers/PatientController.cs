using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Patient;
using Doctor_Patient_Portal.Classes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Doctor_Patient_Portal.Controllers
{
    [Route("api/patients")]
    [ApiController]
    [Produces("application/json")]
    public class PatientController : ControllerBase
    {
        private readonly IPatientManager patientManager;

        public PatientController(IPatientManager _patientManager)
        {
            this.patientManager = _patientManager;
        }

        [HttpPost]
        [Route("GetNearByDoctorList")]
        public IActionResult GetNearByDoctorList(LocationRequest patientRequest)
        {
            var doctor = this.patientManager.GetNearByDoctors(patientRequest);
            return Ok(doctor);
        }

        [HttpGet]
        [Route("SearchDoctorByNameOrSpeciality")]
        public IActionResult SearchDoctorByNameOrSpeciality(string searchText)
        {
            var doctor = this.patientManager.SearchDoctorbyNameOrSpeciality(searchText);
            return Ok(doctor);
        }
    }
}