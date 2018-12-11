using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppForDoctorWebServices.Models
{
    public class Immunisation
    {

        public int ImmunisationId { get; set; }
        public string Type { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
        public int Nombre { get; set; }

        public int PatientId { get; set; }
        public virtual DossierMedical DossierMedical { get; set; }
    }
}