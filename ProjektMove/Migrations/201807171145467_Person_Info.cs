namespace ProjektMove.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Person_Info : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Person_Info_Model",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Phone_No = c.Int(nullable: false),
                        Category = c.String(nullable: false),
                        Volunteer = c.Boolean(nullable: false),
                        Leader = c.Boolean(nullable: false),
                        Approved = c.Boolean(nullable: false),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AlterColumn("dbo.Image_Model", "Image_Name", c => c.String(nullable: false));
            AlterColumn("dbo.Image_Model", "Directory", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Image_Model", "Directory", c => c.String());
            AlterColumn("dbo.Image_Model", "Image_Name", c => c.String());
            DropTable("dbo.Person_Info_Model");
        }
    }
}
