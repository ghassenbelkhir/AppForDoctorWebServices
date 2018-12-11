namespace AppForDoctorWebServices.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class blap : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Examen",
                c => new
                    {
                        ExamenId = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Type = c.String(maxLength: 4000),
                        DossierMedicalId = c.Int(nullable: false),
                        HospitalisationID = c.Int(),
                        DossierMedical_PatientId = c.Int(),
                    })
                .PrimaryKey(t => t.ExamenId)
                .ForeignKey("dbo.DossierMedicals", t => t.DossierMedical_PatientId)
                .ForeignKey("dbo.Hospitalisations", t => t.HospitalisationID)
                .Index(t => t.HospitalisationID)
                .Index(t => t.DossierMedical_PatientId);
            
            CreateTable(
                "dbo.ExamenImages",
                c => new
                    {
                        ExamenImageId = c.Int(nullable: false, identity: true),
                        Image = c.Binary(),
                        ExamenId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ExamenImageId)
                .ForeignKey("dbo.Examen", t => t.ExamenId, cascadeDelete: true)
                .Index(t => t.ExamenId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Examen", "HospitalisationID", "dbo.Hospitalisations");
            DropForeignKey("dbo.ExamenImages", "ExamenId", "dbo.Examen");
            DropForeignKey("dbo.Examen", "DossierMedical_PatientId", "dbo.DossierMedicals");
            DropIndex("dbo.ExamenImages", new[] { "ExamenId" });
            DropIndex("dbo.Examen", new[] { "DossierMedical_PatientId" });
            DropIndex("dbo.Examen", new[] { "HospitalisationID" });
            DropTable("dbo.ExamenImages");
            DropTable("dbo.Examen");
        }
    }
}
