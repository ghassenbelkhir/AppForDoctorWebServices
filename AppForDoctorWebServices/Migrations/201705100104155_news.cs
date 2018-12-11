namespace AppForDoctorWebServices.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class news : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DemandeModifications",
                c => new
                    {
                        DemandeModificationId = c.Int(nullable: false, identity: true),
                        Raison = c.String(maxLength: 4000),
                        Date = c.DateTime(nullable: false),
                        PersonneId = c.Int(),
                        AlerteId = c.Int(),
                        AntecedentId = c.Int(),
                        ConsultationId = c.Int(),
                        HospitalisationId = c.Int(),
                    })
                .PrimaryKey(t => t.DemandeModificationId)
                .ForeignKey("dbo.Alertes", t => t.AlerteId)
                .ForeignKey("dbo.Antecedents", t => t.AntecedentId)
                .ForeignKey("dbo.Consultations", t => t.ConsultationId)
                .ForeignKey("dbo.Hospitalisations", t => t.HospitalisationId)
                .ForeignKey("dbo.Medecins", t => t.PersonneId)
                .Index(t => t.PersonneId)
                .Index(t => t.AlerteId)
                .Index(t => t.AntecedentId)
                .Index(t => t.ConsultationId)
                .Index(t => t.HospitalisationId);
            
            CreateTable(
                "dbo.DemandeExamen",
                c => new
                    {
                        DemandeExamenId = c.Int(nullable: false, identity: true),
                        NomExamen = c.String(maxLength: 4000),
                        Date = c.DateTime(nullable: false),
                        PatientId = c.Int(nullable: false),
                        PersonneId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DemandeExamenId)
                .ForeignKey("dbo.DossierMedicals", t => t.PatientId, cascadeDelete: true)
                .ForeignKey("dbo.Medecins", t => t.PersonneId, cascadeDelete: true)
                .Index(t => t.PatientId)
                .Index(t => t.PersonneId);
            
            AddColumn("dbo.Examen", "DemandeExamenId", c => c.Int());
            AddColumn("dbo.Medicaments", "ConsultationId", c => c.Int());
            CreateIndex("dbo.Examen", "DemandeExamenId");
            CreateIndex("dbo.Medicaments", "ConsultationId");
            AddForeignKey("dbo.Examen", "DemandeExamenId", "dbo.DemandeExamen", "DemandeExamenId");
            AddForeignKey("dbo.Medicaments", "ConsultationId", "dbo.Consultations", "ConsultationId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Medicaments", "ConsultationId", "dbo.Consultations");
            DropForeignKey("dbo.DemandeModifications", "PersonneId", "dbo.Medecins");
            DropForeignKey("dbo.DemandeExamen", "PersonneId", "dbo.Medecins");
            DropForeignKey("dbo.DemandeModifications", "HospitalisationId", "dbo.Hospitalisations");
            DropForeignKey("dbo.Examen", "DemandeExamenId", "dbo.DemandeExamen");
            DropForeignKey("dbo.DemandeExamen", "PatientId", "dbo.DossierMedicals");
            DropForeignKey("dbo.DemandeModifications", "ConsultationId", "dbo.Consultations");
            DropForeignKey("dbo.DemandeModifications", "AntecedentId", "dbo.Antecedents");
            DropForeignKey("dbo.DemandeModifications", "AlerteId", "dbo.Alertes");
            DropIndex("dbo.Medicaments", new[] { "ConsultationId" });
            DropIndex("dbo.Examen", new[] { "DemandeExamenId" });
            DropIndex("dbo.DemandeExamen", new[] { "PersonneId" });
            DropIndex("dbo.DemandeExamen", new[] { "PatientId" });
            DropIndex("dbo.DemandeModifications", new[] { "HospitalisationId" });
            DropIndex("dbo.DemandeModifications", new[] { "ConsultationId" });
            DropIndex("dbo.DemandeModifications", new[] { "AntecedentId" });
            DropIndex("dbo.DemandeModifications", new[] { "AlerteId" });
            DropIndex("dbo.DemandeModifications", new[] { "PersonneId" });
            DropColumn("dbo.Medicaments", "ConsultationId");
            DropColumn("dbo.Examen", "DemandeExamenId");
            DropTable("dbo.DemandeExamen");
            DropTable("dbo.DemandeModifications");
        }
    }
}
