using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppForDoctorWebServices.Models
{
    public class Medecin :Personne
    {
        public virtual ICollection<Alerte> Alerte { get; set; }
        public virtual ICollection<Medicament> Medicament { get; set; }
        public virtual ICollection<Consultation> Consultation { get; set; }
        public virtual ICollection<DemandeExamen> DemandeExamen { get; set; }
        public virtual ICollection<DemandeModification> DemandeModification { get; set; }

        public string Specialite { get; set; }
        public string Motdepasse { get; set; }
        public virtual ICollection<Hospitalisation> Hospitalisation { get; set; }

    }
}