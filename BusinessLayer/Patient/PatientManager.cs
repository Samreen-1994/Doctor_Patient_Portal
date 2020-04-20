using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Doctor_Patient_Portal.Classes;
using DTO;
using DTO.Context;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer.Patient
{
    public class PatientManager : IPatientManager
    {
        public List<User> GetNearByDoctors(LocationRequest patientRequest)
        {
            using (UserContext userContext = new UserContext())
            {
                List<User> data = userContext.Users
                          .FromSql("exec GetNearByDoctors {0},{1}", patientRequest.latitude, patientRequest.longitude)
                          .ToList();

                return data;
            }
        }

        public List<User> SearchDoctorbyNameOrSpeciality(string searchText)
        {
            using (UserContext userContext = new UserContext())
            {
                List<User> data = userContext.Users
                          .Where(x => (x.userType == 1 && x.speciality.Contains(searchText) && x.deleted == false) ||
                          (x.userType == 1 && x.city.Contains(searchText) && x.deleted == false) ||
                          (x.userType == 1 && x.firstName.Contains(searchText) && x.deleted == false) ||
                          (x.userType == 1 && x.lastName.Contains(searchText) && x.deleted == false)).ToList();

                return data;
            }
        }
    }
}
