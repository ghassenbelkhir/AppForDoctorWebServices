namespace AppForDoctorWebServices.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class koip : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Alertes", "DossierMedical_PatientId", "dbo.DossierMedicals");
            DropForeignKey("dbo.Antecedents", "DossierMedical_PatientId", "dbo.DossierMedicals");
            DropForeignKey("dbo.Consultations", "DossierMedical_PatientId", "dbo.DossierMedicals");
            DropForeignKey("dbo.ExamenImages", "ExamenId", "dbo.Examen");
            DropForeignKey("dbo.Examen", "HospitalisationID", "dbo.Hospitalisations");
            DropForeignKey("dbo.FicheDeSoins", "HospitalisationId", "dbo.Hospitalisations");
            DropForeignKey("dbo.Examen", "DossierMedical_PatientId", "dbo.DossierMedicals");
            DropForeignKey("dbo.Hospitalisations", "DossierMedical_PatientId", "dbo.DossierMedicals");
            DropForeignKey("dbo.Immunisations", "DossierMedical_PatientId", "dbo.DossierMedicals");
            DropForeignKey("dbo.Medicaments", "DossierMedical_PatientId", "dbo.DossierMedicals");
            DropForeignKey("dbo.Alertes", "Medecin_PersonneId", "dbo.Medecins");
            DropForeignKey("dbo.Consultations", "Medecin_PersonneId", "dbo.Medecins");
            DropForeignKey("dbo.Hospitalisations", "Medecin_PersonneId", "dbo.Medecins");
            DropForeignKey("dbo.Medicaments", "Medecin_PersonneId", "dbo.Medecins");
            DropIndex("dbo.Alertes", new[] { "DossierMedical_PatientId" });
            DropIndex("dbo.Alertes", new[] { "Medecin_PersonneId" });
            DropIndex("dbo.Antecedents", new[] { "DossierMedical_PatientId" });
            DropIndex("dbo.Consultations", new[] { "DossierMedical_PatientId" });
            DropIndex("dbo.Consultations", new[] { "Medecin_PersonneId" });
            DropIndex("dbo.Examen", new[] { "HospitalisationID" });
            DropIndex("dbo.Examen", new[] { "DossierMedical_PatientId" });
            DropIndex("dbo.ExamenImages", new[] { "ExamenId" });
            DropIndex("dbo.Hospitalisations", new[] { "DossierMedical_PatientId" });
            DropIndex("dbo.Hospitalisations", new[] { "Medecin_PersonneId" });
            DropIndex("dbo.FicheDeSoins", new[] { "HospitalisationId" });
            DropIndex("dbo.Immunisations", new[] { "DossierMedical_PatientId" });
            DropIndex("dbo.Medicaments", new[] { "DossierMedical_PatientId" });
            DropIndex("dbo.Medicaments", new[] { "Medecin_PersonneId" });
            DropTable("dbo.Alertes");
            DropTable("dbo.Antecedents");
            DropTable("dbo.Consultations");
            DropTable("dbo.Examen");
            DropTable("dbo.ExamenImages");
            DropTable("dbo.Hospitalisations");
            DropTable("dbo.FicheDeSoins");
            DropTable("dbo.Immunisations");
            DropTable("dbo.Medicaments");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Medicaments",
                c => new
                    {
                        MedicamentId = c.Int(nullable: false, identity: true),
                        NomMedicamment = c.String(maxLength: 4000),
                        Ordonnance = c.String(maxLength: 4000),
                        Date = c.DateTime(nullable: false),
                        DossierMedical_PatientId = c.Int(),
                        Medecin_PersonneId = c.Int(),
                    })
                .PrimaryKey(t => t.MedicamentId);
            
            CreateTable(
                "dbo.Immunisations",
                c => new
                    {
                        ImmunisationId = c.Int(nullable: false, identity: true),
                        Type = c.String(maxLength: 4000),
                        Date = c.DateTime(nullable: false),
                        Nombre = c.Int(nullable: false),
                        DossierMedical_PatientId = c.Int(),
                    })
                .PrimaryKey(t => t.ImmunisationId);
            
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
                .PrimaryKey(t => t.HospitalisationId);
            
            CreateTable(
                "dbo.Hospitalisations",
                c => new
                    {
                        HospitalisationId = c.Int(nullable: false, identity: true),
                        Etablissement = c.String(maxLength: 4000),
                        DateEntree = c.DateTime(nullable: false),
                        DateSortie = c.DateTime(nullable: false),
                        DossierMedical_PatientId = c.Int(),
                        Medecin_PersonneId = c.Int(),
                    })
                .PrimaryKey(t => t.HospitalisationId);
            
            CreateTable(
                "dbo.ExamenImages",
                c => new
                    {
                        ExamenImageId = c.Int(nullable: false, identity: true),
                        Image = c.Binary(),
                        ExamenId = c.Int(),
                    })
                .PrimaryKey(t => t.ExamenImageId);
            
            CreateTable(
                "dbo.Examen",
                c => new
                    {
                        ExamenId = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Type = c.String(maxLength: 4000),
                        HospitalisationID = c.Int(),
                        DossierMedical_PatientId = c.Int(),
                    })
                .PrimaryKey(t => t.ExamenId);
            
            CreateTable(
                "dbo.Consultations",
                c => new
                    {
                        ConsultationId = c.Int(nullable: false, identity: true),
                        Etablissement = c.String(maxLength: 4000),
                        Raison = c.String(maxLength: 4000),
                        Date = c.DateTime(nullable: false),
                        DossierMedical_PatientId = c.Int(),
                        Medecin_PersonneId = c.Int(),
                    })
                .PrimaryKey(t => t.ConsultationId);
            
            CreateTable(
                "dbo.Antecedents",
                c => new
                    {
                        AntecedentId = c.Int(nullable: false, identity: true),
                        Diagnostic = c.String(maxLength: 4000),
                        Etat = c.String(maxLength: 4000),
                        Date = c.DateTime(nullable: false),
                        DossierMedical_PatientId = c.Int(),
                    })
                .PrimaryKey(t => t.AntecedentId);
            
            CreateTable(
                "dbo.Alertes",
                c => new
                    {
                        AlerteId = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Contenu = c.String(maxLength: 4000),
                        DossierMedical_PatientId = c.Int(),
                        Medecin_PersonneId = c.Int(),
                    })
                .PrimaryKey(t => t.AlerteId);
            
            CreateIndex("dbo.Medicaments", "Medecin_PersonneId");
            CreateIndex("dbo.Medicaments", "DossierMedical_PatientId");
            CreateIndex("dbo.Immunisations", "DossierMedical_PatientId");
            CreateIndex("dbo.FicheDeSoins", "HospitalisationId");
            CreateIndex("dbo.Hospitalisations", "Medecin_PersonneId");
            CreateIndex("dbo.Hospitalisations", "DossierMedical_PatientId");
            CreateIndex("dbo.ExamenImages", "ExamenId");
            CreateIndex("dbo.Examen", "DossierMedical_PatientId");
            CreateIndex("dbo.Examen", "HospitalisationID");
            CreateIndex("dbo.Consultations", "Medecin_PersonneId");
            CreateIndex("dbo.Consultations", "DossierMedical_PatientId");
            CreateIndex("dbo.Antecedents", "DossierMedical_PatientId");
            CreateIndex("dbo.Alertes", "Medecin_PersonneId");
            CreateIndex("dbo.Alertes", "DossierMedical_PatientId");
            AddForeignKey("dbo.Medicaments", "Medecin_PersonneId", "dbo.Medecins", "PersonneId");
            AddForeignKey("dbo.Hospitalisations", "Medecin_PersonneId", "dbo.Medecins", "PersonneId");
            AddForeignKey("dbo.Consultations", "Medecin_PersonneId", "dbo.Medecins", "PersonneId");
            AddForeignKey("dbo.Alertes", "Medecin_PersonneId", "dbo.Medecins", "PersonneId");
            AddForeignKey("dbo.Medicaments", "DossierMedical_PatientId", "dbo.DossierMedicals", "PatientId");
            AddForeignKey("dbo.Immunisations", "DossierMedical_PatientId", "dbo.DossierMedicals", "PatientId");
            AddForeignKey("dbo.Hospitalisations", "DossierMedical_PatientId", "dbo.DossierMedicals", "PatientId");
            AddForeignKey("dbo.Examen", "DossierMedical_PatientId", "dbo.DossierMedicals", "PatientId");
            AddForeignKey("dbo.FicheDeSoins", "HospitalisationId", "dbo.Hospitalisations", "HospitalisationId");
            AddForeignKey("dbo.Examen", "HospitalisationID", "dbo.Hospitalisations", "HospitalisationId");
            AddForeignKey("dbo.ExamenImages", "ExamenId", "dbo.Examen", "ExamenId");
            AddForeignKey("dbo.Consultations", "DossierMedical_PatientId", "dbo.DossierMedicals", "PatientId");
            AddForeignKey("dbo.Antecedents", "DossierMedical_PatientId", "dbo.DossierMedicals", "PatientId");
            AddForeignKey("dbo.Alertes", "DossierMedical_PatientId", "dbo.DossierMedicals", "PatientId");
        }
    }
}
