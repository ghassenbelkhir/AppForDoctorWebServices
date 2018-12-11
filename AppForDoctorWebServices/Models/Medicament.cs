using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppForDoctorWebServices.Models
{
    public class Medicament
    {

        public int MedicamentId { get; set; }
        public string NomMedicamment { get; set; }
        public string Ordonnance { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }



        public Nullable<int> PersonneId { get; set; }
        public virtual Medecin Medecin { get; set; }

        public Nullable<int> ConsultationId { get; set; }
        public virtual Consultation Consultation { get; set; }

        public int PatientId { get; set; }
        public virtual DossierMedical DossierMedical { get; set; }
    }
}