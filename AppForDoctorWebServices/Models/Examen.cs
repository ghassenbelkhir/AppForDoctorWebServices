using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppForDoctorWebServices.Models
{
    public class Examen
    {
        public int ExamenId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
        public string Type { get; set; }

        public virtual ICollection<ExamenImage> ExamenImage { get; set; }

        public int PatientId { get; set; }
        public virtual DossierMedical DossierMedical { get; set; }

        public Nullable<int> HospitalisationID { get; set; }
        public virtual Hospitalisation Hospitalisation { get; set; }

        public Nullable<int> DemandeExamenId { get; set; }
        public virtual DemandeExamen DemandeExamen { get; set; }
    }
}