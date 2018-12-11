namespace AppForDoctorWebServices.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class chalaopa : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Consultations", "DossierMedical_PatientId", "dbo.DossierMedicals");
            DropForeignKey("dbo.Consultations", "PersonneId", "dbo.Medecins");
            DropIndex("dbo.Consultations", new[] { "PersonneId" });
            DropIndex("dbo.Consultations", new[] { "DossierMedical_PatientId" });
            DropTable("dbo.Consultations");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Consultations",
                c => new
                    {
                        ConsultationId = c.Int(nullable: false, identity: true),
                        Etablissement = c.String(maxLength: 4000),
                        Raison = c.String(maxLength: 4000),
                        Date = c.DateTime(nullable: false),
                        PersonneId = c.Int(nullable: false),
                        DossierMedical_PatientId = c.Int(),
                    })
                .PrimaryKey(t => t.ConsultationId);
            
            CreateIndex("dbo.Consultations", "DossierMedical_PatientId");
            CreateIndex("dbo.Consultations", "PersonneId");
            AddForeignKey("dbo.Consultations", "PersonneId", "dbo.Medecins", "PersonneId", cascadeDelete: true);
            AddForeignKey("dbo.Consultations", "DossierMedical_PatientId", "dbo.DossierMedicals", "PatientId");
        }
    }
}
