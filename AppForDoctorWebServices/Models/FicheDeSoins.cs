using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AppForDoctorWebServices.Models
{
    public class FicheDeSoins
    {
        [Key, ForeignKey("Hospitalisation")]
        public int HospitalisationId { get; set; }
        public virtual Hospitalisation Hospitalisation { get; set; }


        public string Motif { get; set; }
        public string RevueDeSysteme { get; set; }
        public string ExamenCardiovasculaire { get; set; }
        public string ExamenTeteEtCou { get; set; }
        public string ExamenMembresInferieurs { get; set; }
        public string AutresExamen { get; set; }
        public string Decision { get; set; }

        // Examen physique
        public float Temperature { get; set; }
        public int FrequenceCardiaque { get; set; }
        public int TensionArterielle { get; set; }
        public int FrequenceRespiratoire { get; set; }

        //Exmaen examenPleuroPulomnaire

        public string Inspection { get; set; }
        public string Palpation { get; set; }
        public string Percussion { get; set; }
        public string Auscultation { get; set; }


    }
}