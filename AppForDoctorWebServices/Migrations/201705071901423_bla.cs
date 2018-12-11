namespace AppForDoctorWebServices.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bla : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Examen", "DossierMedical_PatientId", "dbo.DossierMedicals");
            DropForeignKey("dbo.ExamenImages", "Examen_ExamenId", "dbo.Examen");
            DropForeignKey("dbo.Examen", "Hospitalisation_HospitalisationId", "dbo.Hospitalisations");
            DropIndex("dbo.Examen", new[] { "DossierMedical_PatientId" });
            DropIndex("dbo.Examen", new[] { "Hospitalisation_HospitalisationId" });
            DropIndex("dbo.ExamenImages", new[] { "Examen_ExamenId" });
            AddColumn("dbo.Alertes", "MedecinId", c => c.Int(nullable: false));
            AddColumn("dbo.Alertes", "DossierMedicalId", c => c.Int(nullable: false));
            AddColumn("dbo.Consultations", "MedecinId", c => c.Int(nullable: false));
            AddColumn("dbo.Consultations", "DossierMedicalId", c => c.Int(nullable: false));
            AddColumn("dbo.Hospitalisations", "MedecinId", c => c.Int(nullable: false));
            AddColumn("dbo.Medicaments", "MedecinId", c => c.Int(nullable: false));
            AddColumn("dbo.Medicaments", "DossierMedicalId", c => c.Int(nullable: false));
            DropTable("dbo.Examen");
            DropTable("dbo.ExamenImages");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ExamenImages",
                c => new
                    {
                        ExamenImageId = c.Int(nullable: false, identity: true),
                        Image = c.Binary(),
                        Examen_ExamenId = c.Int(),
                    })
                .PrimaryKey(t => t.ExamenImageId);
            
            CreateTable(
                "dbo.Examen",
                c => new
                    {
                        ExamenId = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Type = c.String(maxLength: 4000),
                        DossierMedical_PatientId = c.Int(),
                        Hospitalisation_HospitalisationId = c.Int(),
                    })
                .PrimaryKey(t => t.ExamenId);
            
            DropColumn("dbo.Medicaments", "DossierMedicalId");
            DropColumn("dbo.Medicaments", "MedecinId");
            DropColumn("dbo.Hospitalisations", "MedecinId");
            DropColumn("dbo.Consultations", "DossierMedicalId");
            DropColumn("dbo.Consultations", "MedecinId");
            DropColumn("dbo.Alertes", "DossierMedicalId");
            DropColumn("dbo.Alertes", "MedecinId");
            CreateIndex("dbo.ExamenImages", "Examen_ExamenId");
            CreateIndex("dbo.Examen", "Hospitalisation_HospitalisationId");
            CreateIndex("dbo.Examen", "DossierMedical_PatientId");
            AddForeignKey("dbo.Examen", "Hospitalisation_HospitalisationId", "dbo.Hospitalisations", "HospitalisationId");
            AddForeignKey("dbo.ExamenImages", "Examen_ExamenId", "dbo.Examen", "ExamenId");
            AddForeignKey("dbo.Examen", "DossierMedical_PatientId", "dbo.DossierMedicals", "PatientId");
        }
    }
}
