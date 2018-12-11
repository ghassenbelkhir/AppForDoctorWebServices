using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AppForDoctorWebServices.Models
{
    public abstract class Personne
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int PersonneId { get; set; }

        public string Nom { get; set; }
        public string Prenom { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DNaissance { get; set; }
        public string Adresse { get; set; }
        public string Sexe { get; set; }
        public string Statut { get; set; }
        public string Email { get; set; }
        public int Tel { get; set; }
        [MaxLength]
        public byte[] Photo { get; set; }
    }
}