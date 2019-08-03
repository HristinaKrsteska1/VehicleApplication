namespace VehicleApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddVehicles : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Vehicles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LicencePlateNumber = c.String(),
                        VIN = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Vehicles");
        }
    }
}
