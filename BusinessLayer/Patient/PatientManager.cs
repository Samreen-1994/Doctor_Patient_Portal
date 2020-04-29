using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using BusinessLayer.DTOModel;
using Doctor_Patient_Portal.Classes;
using DTO;
using DTO.Context;
using DTO.DBModels;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer.Patient
{
    public class PatientManager : IPatientManager
    {
        public bool CreateUpdateAppointment(Appointment appointment)
        {
            using (UserContext userContext = new UserContext())
            {
                var app = userContext.Appointments.Where(x => x.appointmentId == appointment.appointmentId && x.deleted == false).FirstOrDefault();
                if (app != null)
                {
                    app.deleted = appointment.deleted;
                    app.appointmentApproved = appointment.appointmentApproved;
                    app.appointmentCompleted = appointment.appointmentCompleted;
                    app.appointmentSchedule = appointment.appointmentSchedule;
                    app.appointmentTitle = appointment.appointmentTitle;
                    app.appointmentDescription = appointment.appointmentDescription;
                    userContext.Appointments.Update(app);
                    userContext.SaveChanges();
                }
                else
                {
                    userContext.Appointments.Add(appointment);
                    userContext.SaveChanges();
                    return true;
                }
            }
            return false;
        }

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

        public List<PatientAppointmentResponse> GetPatientAppointmentList(int patientId)
        {
            using (UserContext userContext = new UserContext())
            {
                var results = userContext.Query<PatientAppointmentResponse>()
                     .FromSql("EXEC getPatientAppointments {0}", patientId)
                     .ToList();

                return results;
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
