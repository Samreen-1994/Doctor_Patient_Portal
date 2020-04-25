using BusinessLayer.DTOModel;
using Doctor_Patient_Portal.Classes;
using DTO;
using DTO.DBModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Patient
{
    public interface IPatientManager
    {
        List<User> GetNearByDoctors(LocationRequest patientRequest);
        List<User> SearchDoctorbyNameOrSpeciality(string searchText);

        bool CreateUpdateAppointment(Appointment appointment);
        List<PatientAppointmentResponse> GetPatientAppointmentList(int patientId);
    }
}
