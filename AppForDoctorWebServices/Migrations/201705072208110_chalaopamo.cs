namespace AppForDoctorWebServices.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class chalaopamo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Medecins", "Sexe", c => c.String(maxLength: 4000));
            AddColumn("dbo.Patients", "Sexe", c => c.String(maxLength: 4000));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Patients", "Sexe");
            DropColumn("dbo.Medecins", "Sexe");
        }
    }
}
