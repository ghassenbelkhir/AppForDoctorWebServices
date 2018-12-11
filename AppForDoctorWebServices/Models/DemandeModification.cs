using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AppForDoctorWebServices.Models
{
    public class DemandeModification
    {
        public int DemandeModificationId { get; set; }
        public string Raison { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public Nullable<int> PersonneId { get; set; }
        public virtual Medecin Medecin { get; set; }


        public Nullable<int> AlerteId { get; set; }
        public virtual Alerte Alerte { get; set; }


        public Nullable<int> AntecedentId { get; set; }
        public virtual Antecedent Antecedent { get; set; }

        public Nullable<int> ConsultationId { get; set; }
        public virtual Consultation Consultation { get; set; }

        public Nullable<int> HospitalisationId { get; set; }
        public virtual Hospitalisation Hospitalisation { get; set; }

    }
}