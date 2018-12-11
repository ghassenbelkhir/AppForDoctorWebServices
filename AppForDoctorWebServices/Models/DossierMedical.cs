using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AppForDoctorWebServices.Models
{
    public partial class DossierMedical
    {
        [Key, ForeignKey("patient")]
        public int PatientId { get; set; }
        public virtual Patient patient { get; set; }

        public virtual ICollection<Alerte> Alerte { get; set; }

        public virtual ICollection<Examen> Examen { get; set; }

        public virtual ICollection<Antecedent> Antecedent { get; set; }

        public virtual ICollection<Immunisation> Immunisation { get; set; }

        public virtual ICollection<Medicament> Medicament { get; set; }

        public virtual ICollection<Consultation> Consultation { get; set; }

        public virtual ICollection<Hospitalisation> Hospitalisation { get; set; }

        public virtual ICollection<DemandeExamen> DemandeExamen { get; set; }
    }
}