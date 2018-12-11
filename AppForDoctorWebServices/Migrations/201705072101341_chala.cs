namespace AppForDoctorWebServices.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class chala : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Alertes",
                c => new
                    {
                        AlerteId = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Contenu = c.String(maxLength: 4000),
                        PersonneId = c.Int(),
                        PatientId = c.Int(),
                    })
                .PrimaryKey(t => t.AlerteId)
                .ForeignKey("dbo.DossierMedicals", t => t.PatientId)
                .ForeignKey("dbo.Medecins", t => t.PersonneId)
                .Index(t => t.PersonneId)
                .Index(t => t.PatientId);
            
            CreateTable(
                "dbo.Consultations",
                c => new
                    {
                        ConsultationId = c.Int(nullable: false, identity: true),
                        Etablissement = c.String(maxLength: 4000),
                        Raison = c.String(maxLength: 4000),
                        Date = c.DateTime(nullable: false),
                        PersonneId = c.Int(),
                        DossierMedical_PatientId = c.Int(),
                    })
                .PrimaryKey(t => t.ConsultationId)
                .ForeignKey("dbo.DossierMedicals", t => t.DossierMedical_PatientId)
                .ForeignKey("dbo.Medecins", t => t.PersonneId)
                .Index(t => t.PersonneId)
                .Index(t => t.DossierMedical_PatientId);
            
            CreateTable(
                "dbo.Hospitalisations",
                c => new
                    {
                        HospitalisationId = c.Int(nullable: false, identity: true),
                        Etablissement = c.String(maxLength: 4000),
                        DateEntree = c.DateTime(nullable: false),
                        DateSortie = c.DateTime(nullable: false),
                        PatientId = c.Int(),
                        PersonneId = c.Int(),
                    })
                .PrimaryKey(t => t.HospitalisationId)
                .ForeignKey("dbo.DossierMedicals", t => t.PatientId)
                .ForeignKey("dbo.Medecins", t => t.PersonneId)
                .Index(t => t.PatientId)
                .Index(t => t.PersonneId);
            
            CreateTable(
                "dbo.Examen",
                c => new
                    {
                        ExamenId = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Type = c.String(maxLength: 4000),
                        PatientId = c.Int(),
                        HospitalisationID = c.Int(),
                    })
                .PrimaryKey(t => t.ExamenId)
                .ForeignKey("dbo.DossierMedicals", t => t.PatientId)
                .ForeignKey("dbo.Hospitalisations", t => t.HospitalisationID)
                .Index(t => t.PatientId)
                .Index(t => t.HospitalisationID);
            
            CreateTable(
                "dbo.ExamenImages",
                c => new
                    {
                        ExamenImageId = c.Int(nullable: false, identity: true),
                        Image = c.Binary(),
                        ExamenId = c.Int(),
                    })
                .PrimaryKey(t => t.ExamenImageId)
                .ForeignKey("dbo.Examen", t => t.ExamenId)
                .Index(t => t.ExamenId);
            
            CreateTable(
                "dbo.FicheDeSoins",
                c => new
                    {
                        HospitalisationId = c.Int(nullable: false),
                        Motif = c.String(maxLength: 4000),
                        RevueDeSysteme = c.String(maxLength: 4000),
                        ExamenCardiovasculaire = c.String(maxLength: 4000),
                        ExamenTeteEtCou = c.String(maxLength: 4000),
                        ExamenMembresInferieurs = c.String(maxLength: 4000),
                        AutresExamen = c.String(maxLength: 4000),
                        Decision = c.String(maxLength: 4000),
                        Temperature = c.Single(nullable: false),
                        FrequenceCardiaque = c.Int(nullable: false),
                        TensionArterielle = c.Int(nullable: false),
                        FrequenceRespiratoire = c.Int(nullable: false),
                        Inspection = c.String(maxLength: 4000),
                        Palpation = c.String(maxLength: 4000),
                        Percussion = c.String(maxLength: 4000),
                        Auscultation = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => t.HospitalisationId)
                .ForeignKey("dbo.Hospitalisations", t => t.HospitalisationId)
                .Index(t => t.HospitalisationId);
            
            CreateTable(
                "dbo.Medicaments",
                c => new
                    {
                        MedicamentId = c.Int(nullable: false, identity: true),
                        NomMedicamment = c.String(maxLength: 4000),
                        Ordonnance = c.String(maxLength: 4000),
                        Date = c.DateTime(nullable: false),
                        PersonneId = c.Int(),
                        PatientId = c.Int(),
                    })
                .PrimaryKey(t => t.MedicamentId)
                .ForeignKey("dbo.DossierMedicals", t => t.PatientId)
                .ForeignKey("dbo.Medecins", t => t.PersonneId)
                .Index(t => t.PersonneId)
                .Index(t => t.PatientId);
            
            CreateTable(
                "dbo.Antecedents",
                c => new
                    {
                        AntecedentId = c.Int(nullable: false, identity: true),
                        Diagnostic = c.String(maxLength: 4000),
                        Etat = c.String(maxLength: 4000),
                        Date = c.DateTime(nullable: false),
                        PatientId = c.Int(),
                    })
                .PrimaryKey(t => t.AntecedentId)
                .ForeignKey("dbo.DossierMedicals", t => t.PatientId)
                .Index(t => t.PatientId);
            
            CreateTable(
                "dbo.Immunisations",
                c => new
                    {
                        ImmunisationId = c.Int(nullable: false, identity: true),
                        Type = c.String(maxLength: 4000),
                        Date = c.DateTime(nullable: false),
                        Nombre = c.Int(nullable: false),
                        PatientId = c.Int(),
                    })
                .PrimaryKey(t => t.ImmunisationId)
                .ForeignKey("dbo.DossierMedicals", t => t.PatientId)
                .Index(t => t.PatientId);
            
            AddColumn("dbo.Medecins", "Motdepasse", c => c.String(maxLength: 4000));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Immunisations", "PatientId", "dbo.DossierMedicals");
            DropForeignKey("dbo.Antecedents", "PatientId", "dbo.DossierMedicals");
            DropForeignKey("dbo.Medicaments", "PersonneId", "dbo.Medecins");
            DropForeignKey("dbo.Medicaments", "PatientId", "dbo.DossierMedicals");
            DropForeignKey("dbo.Hospitalisations", "PersonneId", "dbo.Medecins");
            DropForeignKey("dbo.FicheDeSoins", "HospitalisationId", "dbo.Hospitalisations");
            DropForeignKey("dbo.Examen", "HospitalisationID", "dbo.Hospitalisations");
            DropForeignKey("dbo.ExamenImages", "ExamenId", "dbo.Examen");
            DropForeignKey("dbo.Examen", "PatientId", "dbo.DossierMedicals");
            DropForeignKey("dbo.Hospitalisations", "PatientId", "dbo.DossierMedicals");
            DropForeignKey("dbo.Consultations", "PersonneId", "dbo.Medecins");
            DropForeignKey("dbo.Consultations", "DossierMedical_PatientId", "dbo.DossierMedicals");
            DropForeignKey("dbo.Alertes", "PersonneId", "dbo.Medecins");
            DropForeignKey("dbo.Alertes", "PatientId", "dbo.DossierMedicals");
            DropIndex("dbo.Immunisations", new[] { "PatientId" });
            DropIndex("dbo.Antecedents", new[] { "PatientId" });
            DropIndex("dbo.Medicaments", new[] { "PatientId" });
            DropIndex("dbo.Medicaments", new[] { "PersonneId" });
            DropIndex("dbo.FicheDeSoins", new[] { "HospitalisationId" });
            DropIndex("dbo.ExamenImages", new[] { "ExamenId" });
            DropIndex("dbo.Examen", new[] { "HospitalisationID" });
            DropIndex("dbo.Examen", new[] { "PatientId" });
            DropIndex("dbo.Hospitalisations", new[] { "PersonneId" });
            DropIndex("dbo.Hospitalisations", new[] { "PatientId" });
            DropIndex("dbo.Consultations", new[] { "DossierMedical_PatientId" });
            DropIndex("dbo.Consultations", new[] { "PersonneId" });
            DropIndex("dbo.Alertes", new[] { "PatientId" });
            DropIndex("dbo.Alertes", new[] { "PersonneId" });
            DropColumn("dbo.Medecins", "Motdepasse");
            DropTable("dbo.Immunisations");
            DropTable("dbo.Antecedents");
            DropTable("dbo.Medicaments");
            DropTable("dbo.FicheDeSoins");
            DropTable("dbo.ExamenImages");
            DropTable("dbo.Examen");
            DropTable("dbo.Hospitalisations");
            DropTable("dbo.Consultations");
            DropTable("dbo.Alertes");
        }
    }
}
