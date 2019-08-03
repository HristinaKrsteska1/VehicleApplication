namespace VehicleApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMarkaNaVozilo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MarkaNaVoziloes",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        ModelName = c.String(),
                        ModelCode = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Vehicles", "MarkaNaVoziloId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Vehicles", "MarkaNaVoziloId");
            AddForeignKey("dbo.Vehicles", "MarkaNaVoziloId", "dbo.MarkaNaVoziloes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vehicles", "MarkaNaVoziloId", "dbo.MarkaNaVoziloes");
            DropIndex("dbo.Vehicles", new[] { "MarkaNaVoziloId" });
            DropColumn("dbo.Vehicles", "MarkaNaVoziloId");
            DropTable("dbo.MarkaNaVoziloes");
        }
    }
}
