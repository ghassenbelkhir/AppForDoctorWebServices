using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppForDoctorWebServices.Models
{
    public class Hospitalisation
    {
        public int HospitalisationId { get; set; }
        public virtual FicheDeSoins FicheDeSoins { get; set; }
        public string Etablissement { get; set; }


        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateEntree { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateSortie { get; set; }


        public int PatientId { get; set; }
        public virtual DossierMedical DossierMedical { get; set; }

        public int PersonneId { get; set; }
        public virtual Medecin Medecin { get; set; }

        public virtual ICollection<Examen> Examen { get; set; }
        public virtual ICollection<DemandeModification> DemandeModification { get; set; }
    }
}