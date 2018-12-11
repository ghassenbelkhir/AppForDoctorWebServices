namespace AppForDoctorWebServices.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class chalao : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Alertes", "PatientId", "dbo.DossierMedicals");
            DropForeignKey("dbo.Antecedents", "PatientId", "dbo.DossierMedicals");
            DropForeignKey("dbo.Examen", "PatientId", "dbo.DossierMedicals");
            DropForeignKey("dbo.Hospitalisations", "PatientId", "dbo.DossierMedicals");
            DropForeignKey("dbo.Immunisations", "PatientId", "dbo.DossierMedicals");
            DropForeignKey("dbo.Medicaments", "PatientId", "dbo.DossierMedicals");
            DropForeignKey("dbo.Consultations", "PersonneId", "dbo.Medecins");
            DropForeignKey("dbo.Hospitalisations", "PersonneId", "dbo.Medecins");
            DropForeignKey("dbo.ExamenImages", "ExamenId", "dbo.Examen");
            DropIndex("dbo.Alertes", new[] { "PatientId" });
            DropIndex("dbo.Consultations", new[] { "PersonneId" });
            DropIndex("dbo.Hospitalisations", new[] { "PatientId" });
            DropIndex("dbo.Hospitalisations", new[] { "PersonneId" });
            DropIndex("dbo.Examen", new[] { "PatientId" });
            DropIndex("dbo.ExamenImages", new[] { "ExamenId" });
            DropIndex("dbo.Medicaments", new[] { "PatientId" });
            DropIndex("dbo.Antecedents", new[] { "PatientId" });
            DropIndex("dbo.Immunisations", new[] { "PatientId" });
            AlterColumn("dbo.Alertes", "PatientId", c => c.Int(nullable: false));
            AlterColumn("dbo.Consultations", "PersonneId", c => c.Int(nullable: false));
            AlterColumn("dbo.Hospitalisations", "PatientId", c => c.Int(nullable: false));
            AlterColumn("dbo.Hospitalisations", "PersonneId", c => c.Int(nullable: false));
            AlterColumn("dbo.Examen", "PatientId", c => c.Int(nullable: false));
            AlterColumn("dbo.ExamenImages", "ExamenId", c => c.Int(nullable: false));
            AlterColumn("dbo.Medicaments", "PatientId", c => c.Int(nullable: false));
            AlterColumn("dbo.Antecedents", "PatientId", c => c.Int(nullable: false));
            AlterColumn("dbo.Immunisations", "PatientId", c => c.Int(nullable: false));
            CreateIndex("dbo.Alertes", "PatientId");
            CreateIndex("dbo.Consultations", "PersonneId");
            CreateIndex("dbo.Hospitalisations", "PatientId");
            CreateIndex("dbo.Hospitalisations", "PersonneId");
            CreateIndex("dbo.Examen", "PatientId");
            CreateIndex("dbo.ExamenImages", "ExamenId");
            CreateIndex("dbo.Medicaments", "PatientId");
            CreateIndex("dbo.Antecedents", "PatientId");
            CreateIndex("dbo.Immunisations", "PatientId");
            AddForeignKey("dbo.Alertes", "PatientId", "dbo.DossierMedicals", "PatientId", cascadeDelete: true);
            AddForeignKey("dbo.Antecedents", "PatientId", "dbo.DossierMedicals", "PatientId", cascadeDelete: true);
            AddForeignKey("dbo.Examen", "PatientId", "dbo.DossierMedicals", "PatientId", cascadeDelete: true);
            AddForeignKey("dbo.Hospitalisations", "PatientId", "dbo.DossierMedicals", "PatientId", cascadeDelete: true);
            AddForeignKey("dbo.Immunisations", "PatientId", "dbo.DossierMedicals", "PatientId", cascadeDelete: true);
            AddForeignKey("dbo.Medicaments", "PatientId", "dbo.DossierMedicals", "PatientId", cascadeDelete: true);
            AddForeignKey("dbo.Consultations", "PersonneId", "dbo.Medecins", "PersonneId", cascadeDelete: true);
            AddForeignKey("dbo.Hospitalisations", "PersonneId", "dbo.Medecins", "PersonneId", cascadeDelete: true);
            AddForeignKey("dbo.ExamenImages", "ExamenId", "dbo.Examen", "ExamenId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ExamenImages", "ExamenId", "dbo.Examen");
            DropForeignKey("dbo.Hospitalisations", "PersonneId", "dbo.Medecins");
            DropForeignKey("dbo.Consultations", "PersonneId", "dbo.Medecins");
            DropForeignKey("dbo.Medicaments", "PatientId", "dbo.DossierMedicals");
            DropForeignKey("dbo.Immunisations", "PatientId", "dbo.DossierMedicals");
            DropForeignKey("dbo.Hospitalisations", "PatientId", "dbo.DossierMedicals");
            DropForeignKey("dbo.Examen", "PatientId", "dbo.DossierMedicals");
            DropForeignKey("dbo.Antecedents", "PatientId", "dbo.DossierMedicals");
            DropForeignKey("dbo.Alertes", "PatientId", "dbo.DossierMedicals");
            DropIndex("dbo.Immunisations", new[] { "PatientId" });
            DropIndex("dbo.Antecedents", new[] { "PatientId" });
            DropIndex("dbo.Medicaments", new[] { "PatientId" });
            DropIndex("dbo.ExamenImages", new[] { "ExamenId" });
            DropIndex("dbo.Examen", new[] { "PatientId" });
            DropIndex("dbo.Hospitalisations", new[] { "PersonneId" });
            DropIndex("dbo.Hospitalisations", new[] { "PatientId" });
            DropIndex("dbo.Consultations", new[] { "PersonneId" });
            DropIndex("dbo.Alertes", new[] { "PatientId" });
            AlterColumn("dbo.Immunisations", "PatientId", c => c.Int());
            AlterColumn("dbo.Antecedents", "PatientId", c => c.Int());
            AlterColumn("dbo.Medicaments", "PatientId", c => c.Int());
            AlterColumn("dbo.ExamenImages", "ExamenId", c => c.Int());
            AlterColumn("dbo.Examen", "PatientId", c => c.Int());
            AlterColumn("dbo.Hospitalisations", "PersonneId", c => c.Int());
            AlterColumn("dbo.Hospitalisations", "PatientId", c => c.Int());
            AlterColumn("dbo.Consultations", "PersonneId", c => c.Int());
            AlterColumn("dbo.Alertes", "PatientId", c => c.Int());
            CreateIndex("dbo.Immunisations", "PatientId");
            CreateIndex("dbo.Antecedents", "PatientId");
            CreateIndex("dbo.Medicaments", "PatientId");
            CreateIndex("dbo.ExamenImages", "ExamenId");
            CreateIndex("dbo.Examen", "PatientId");
            CreateIndex("dbo.Hospitalisations", "PersonneId");
            CreateIndex("dbo.Hospitalisations", "PatientId");
            CreateIndex("dbo.Consultations", "PersonneId");
            CreateIndex("dbo.Alertes", "PatientId");
            AddForeignKey("dbo.ExamenImages", "ExamenId", "dbo.Examen", "ExamenId");
            AddForeignKey("dbo.Hospitalisations", "PersonneId", "dbo.Medecins", "PersonneId");
            AddForeignKey("dbo.Consultations", "PersonneId", "dbo.Medecins", "PersonneId");
            AddForeignKey("dbo.Medicaments", "PatientId", "dbo.DossierMedicals", "PatientId");
            AddForeignKey("dbo.Immunisations", "PatientId", "dbo.DossierMedicals", "PatientId");
            AddForeignKey("dbo.Hospitalisations", "PatientId", "dbo.DossierMedicals", "PatientId");
            AddForeignKey("dbo.Examen", "PatientId", "dbo.DossierMedicals", "PatientId");
            AddForeignKey("dbo.Antecedents", "PatientId", "dbo.DossierMedicals", "PatientId");
            AddForeignKey("dbo.Alertes", "PatientId", "dbo.DossierMedicals", "PatientId");
        }
    }
}
