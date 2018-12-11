namespace AppForDoctorWebServices.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class gom : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.DemandeModifications", "ReportDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DemandeModifications", "ReportDate", c => c.DateTime(nullable: false));
        }
    }
}
