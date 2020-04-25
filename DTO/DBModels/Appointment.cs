using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DTO.DBModels
{
    [Table("appointment")]
    public class Appointment
    {
        [Key]
        public int appointmentId { get; set; }
        public string appointmentTitle { get; set; }
        public string appointmentDescription { get; set; }
        public int doctorId { get; set; }
        public int patientId { get; set; }
        public DateTime appointmentSchedule { get; set; }
        public bool deleted { get; set; }
        public bool appointmentApproved { get; set; }
        public bool appointmentCompleted { get; set; }
    }
}
