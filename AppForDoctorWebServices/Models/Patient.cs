using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppForDoctorWebServices.Models
{
    public class Patient : Personne
    {
        [JsonIgnore]
        public virtual DossierMedical DossierMedical { get; set; }
    }
}