using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppForDoctorWebServices.Models
{
    public class ExamenImage
    {
        public int ExamenImageId { get; set; }
        [MaxLength]
        public byte[] Image { get; set; }


        public int ExamenId { get; set; }
        public virtual Examen Examen { get; set; }
    }
}