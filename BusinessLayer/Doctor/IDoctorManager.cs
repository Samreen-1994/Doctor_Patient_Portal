using BusinessLayer.DTOModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Doctor
{
    public interface IDoctorManager
    {
        List<PatientAppointmentResponse> GetDoctorAppointmentList(int doctorId);
    }
}
