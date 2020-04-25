using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.DTOModel
{
    public class PatientAppointmentResponse
    {
        public int appointmentId { get; set; }
        public string doctorName { get; set; }
        public int doctorId { get; set; }
        public int patientId { get; set; }
        public string appointmentTitle { get; set; }
        public DateTime appointmentSchedule { get; set; }
        public string appointmentDescription { get; set; }
        public bool appointmentCompleted { get; set; }
        public bool appointmentApproved { get; set; }
    }
}
