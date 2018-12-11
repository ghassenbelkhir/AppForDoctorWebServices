using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AppForDoctorWebServices.Context
{
    public class AppForDoctorWebServicesContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public AppForDoctorWebServicesContext() : base("name=DataBase")
        {
            Configuration.ProxyCreationEnabled = false;
        }

        public System.Data.Entity.DbSet<AppForDoctorWebServices.Models.Patient> Patients { get; set; }

        public System.Data.Entity.DbSet<AppForDoctorWebServices.Models.DossierMedical> DossierMedicals { get; set; }

       

        public System.Data.Entity.DbSet<AppForDoctorWebServices.Models.Medecin> Medecins { get; set; }

        public System.Data.Entity.DbSet<AppForDoctorWebServices.Models.Alerte> Alertes { get; set; }

        public System.Data.Entity.DbSet<AppForDoctorWebServices.Models.Antecedent> Antecedents { get; set; }

        public System.Data.Entity.DbSet<AppForDoctorWebServices.Models.Consultation> Consultations { get; set; }

        public System.Data.Entity.DbSet<AppForDoctorWebServices.Models.Medicament> Medicaments { get; set; }

        public System.Data.Entity.DbSet<AppForDoctorWebServices.Models.Examen> Examen { get; set; }

        public System.Data.Entity.DbSet<AppForDoctorWebServices.Models.Hospitalisation> Hospitalisations { get; set; }

        public System.Data.Entity.DbSet<AppForDoctorWebServices.Models.ExamenImage> ExamenImages { get; set; }

        public System.Data.Entity.DbSet<AppForDoctorWebServices.Models.Immunisation> Immunisations { get; set; }

        public System.Data.Entity.DbSet<AppForDoctorWebServices.Models.FicheDeSoins> FicheDeSoins { get; set; }

        public System.Data.Entity.DbSet<AppForDoctorWebServices.Models.DemandeExamen> DemandeExamen { get; set; }

        public System.Data.Entity.DbSet<AppForDoctorWebServices.Models.DemandeModification> DemandeModifications { get; set; }
    }
}
