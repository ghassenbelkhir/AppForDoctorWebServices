namespace AppForDoctorWebServices.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class blappo : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Alertes", "MedecinId");
            DropColumn("dbo.Alertes", "DossierMedicalId");
            DropColumn("dbo.Antecedents", "DossierMedicalId");
            DropColumn("dbo.Consultations", "MedecinId");
            DropColumn("dbo.Consultations", "DossierMedicalId");
            DropColumn("dbo.Hospitalisations", "DossierMedicalId");
            DropColumn("dbo.Hospitalisations", "MedecinId");
            DropColumn("dbo.Examen", "DossierMedicalId");
            DropColumn("dbo.Medicaments", "MedecinId");
            DropColumn("dbo.Medicaments", "DossierMedicalId");
            DropColumn("dbo.Immunisations", "DossierMedicalId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Immunisations", "DossierMedicalId", c => c.Int());
            AddColumn("dbo.Medicaments", "DossierMedicalId", c => c.Int());
            AddColumn("dbo.Medicaments", "MedecinId", c => c.Int());
            AddColumn("dbo.Examen", "DossierMedicalId", c => c.Int());
            AddColumn("dbo.Hospitalisations", "MedecinId", c => c.Int());
            AddColumn("dbo.Hospitalisations", "DossierMedicalId", c => c.Int());
            AddColumn("dbo.Consultations", "DossierMedicalId", c => c.Int());
            AddColumn("dbo.Consultations", "MedecinId", c => c.Int());
            AddColumn("dbo.Antecedents", "DossierMedicalId", c => c.Int());
            AddColumn("dbo.Alertes", "DossierMedicalId", c => c.Int());
            AddColumn("dbo.Alertes", "MedecinId", c => c.Int());
        }
    }
}
