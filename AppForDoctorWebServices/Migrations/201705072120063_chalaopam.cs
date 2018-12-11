namespace AppForDoctorWebServices.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class chalaopam : DbMigration
    {
        public override void Up()
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
                        PatientId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ConsultationId)
                .ForeignKey("dbo.DossierMedicals", t => t.PatientId, cascadeDelete: true)
                .ForeignKey("dbo.Medecins", t => t.PersonneId, cascadeDelete: true)
                .Index(t => t.PersonneId)
                .Index(t => t.PatientId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Consultations", "PersonneId", "dbo.Medecins");
            DropForeignKey("dbo.Consultations", "PatientId", "dbo.DossierMedicals");
            DropIndex("dbo.Consultations", new[] { "PatientId" });
            DropIndex("dbo.Consultations", new[] { "PersonneId" });
            DropTable("dbo.Consultations");
        }
    }
}
