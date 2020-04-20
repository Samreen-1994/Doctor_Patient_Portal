using Doctor_Patient_Portal.Classes;
using DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Patient
{
    public interface IPatientManager
    {
        List<User> GetNearByDoctors(LocationRequest patientRequest);
        List<User> SearchDoctorbyNameOrSpeciality(string searchText);
    }
}
