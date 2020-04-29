using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DTO.DBModels
{
    [Table("medicinerequest")]
    public class MedicineRequest
    {
        [Key]
        public int requestId { get; set; }
        public int patientId { get; set; }
        public int medicalStoreId { get; set; }
        public string requestText { get; set; }
        public string requestResponse { get; set; }
        public string requestImage { get; set; }
        public bool deleted { get; set; }
    }
}
