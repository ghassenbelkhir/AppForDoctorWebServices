using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AppForDoctorWebServices.Models
{
    public class DemandeExamen
    {
        public int DemandeExamenId { get; set; }
        public string NomExamen { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        public int PatientId { get; set; }
        public virtual DossierMedical DossierMedical { get; set; }

        public int PersonneId { get; set; }
        public virtual Medecin Medecin { get; set; }

        public virtual ICollection<Examen> Examen { get; set; }
    }
}