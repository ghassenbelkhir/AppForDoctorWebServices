namespace AppForDoctorWebServices.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class blapp : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ExamenImages", "ExamenId", "dbo.Examen");
            DropIndex("dbo.ExamenImages", new[] { "ExamenId" });
            AlterColumn("dbo.Alertes", "MedecinId", c => c.Int());
            AlterColumn("dbo.Alertes", "DossierMedicalId", c => c.Int());
            AlterColumn("dbo.Antecedents", "DossierMedicalId", c => c.Int());
            AlterColumn("dbo.Consultations", "MedecinId", c => c.Int());
            AlterColumn("dbo.Consultations", "DossierMedicalId", c => c.Int());
            AlterColumn("dbo.Hospitalisations", "DossierMedicalId", c => c.Int());
            AlterColumn("dbo.Hospitalisations", "MedecinId", c => c.Int());
            AlterColumn("dbo.Examen", "DossierMedicalId", c => c.Int());
            AlterColumn("dbo.ExamenImages", "ExamenId", c => c.Int());
            AlterColumn("dbo.Medicaments", "MedecinId", c => c.Int());
            AlterColumn("dbo.Medicaments", "DossierMedicalId", c => c.Int());
            AlterColumn("dbo.Immunisations", "DossierMedicalId", c => c.Int());
            CreateIndex("dbo.ExamenImages", "ExamenId");
            AddForeignKey("dbo.ExamenImages", "ExamenId", "dbo.Examen", "ExamenId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ExamenImages", "ExamenId", "dbo.Examen");
            DropIndex("dbo.ExamenImages", new[] { "ExamenId" });
            AlterColumn("dbo.Immunisations", "DossierMedicalId", c => c.Int(nullable: false));
            AlterColumn("dbo.Medicaments", "DossierMedicalId", c => c.Int(nullable: false));
            AlterColumn("dbo.Medicaments", "MedecinId", c => c.Int(nullable: false));
            AlterColumn("dbo.ExamenImages", "ExamenId", c => c.Int(nullable: false));
            AlterColumn("dbo.Examen", "DossierMedicalId", c => c.Int(nullable: false));
            AlterColumn("dbo.Hospitalisations", "MedecinId", c => c.Int(nullable: false));
            AlterColumn("dbo.Hospitalisations", "DossierMedicalId", c => c.Int(nullable: false));
            AlterColumn("dbo.Consultations", "DossierMedicalId", c => c.Int(nullable: false));
            AlterColumn("dbo.Consultations", "MedecinId", c => c.Int(nullable: false));
            AlterColumn("dbo.Antecedents", "DossierMedicalId", c => c.Int(nullable: false));
            AlterColumn("dbo.Alertes", "DossierMedicalId", c => c.Int(nullable: false));
            AlterColumn("dbo.Alertes", "MedecinId", c => c.Int(nullable: false));
            CreateIndex("dbo.ExamenImages", "ExamenId");
            AddForeignKey("dbo.ExamenImages", "ExamenId", "dbo.Examen", "ExamenId", cascadeDelete: true);
        }
    }
}
