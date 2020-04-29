using BusinessLayer.DTOModel;
using DTO.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLayer.Doctor
{
    public class DoctorManager : IDoctorManager
    {
        public List<PatientAppointmentResponse> GetDoctorAppointmentList(int doctorId)
        {
            using (UserContext userContext = new UserContext())
            {
                var results = userContext.Query<PatientAppointmentResponse>()
                     .FromSql("EXEC getDoctorAppointments {0}", doctorId)
                     .ToList();

                return results;
            }
        }
    }
}
