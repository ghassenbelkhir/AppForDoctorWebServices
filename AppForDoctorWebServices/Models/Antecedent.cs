using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppForDoctorWebServices.Models
{
    public class Antecedent
    {

        public int AntecedentId { get; set; }

        public string Diagnostic { get; set; }
        public string Etat { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        public int PatientId { get; set; }
        public virtual DossierMedical DossierMedical { get; set; }

        public virtual ICollection<DemandeModification> DemandeModification { get; set; }
    }
}