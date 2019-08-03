namespace VehicleApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMarkaNaVoziloes : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO MarkaNaVoziloes (Id, ModelName, ModelCode) VALUES (1, 'MAZDA LAPUTA' , 'TA-HP22S')");
            Sql("INSERT INTO MarkaNaVoziloes (Id, ModelName, ModelCode) VALUES (2, 'TOYOTA MR2 GT', 'E-SW20')");
            Sql("INSERT INTO MarkaNaVoziloes (Id, ModelName, ModelCode) VALUES (3, 'BMW M1', 'E-26')");
            Sql("INSERT INTO MarkaNaVoziloes (Id, ModelName, ModelCode) VALUES (4, 'Mercedes', 'P0469')");           
        }
        
        public override void Down()
        {

        }
    }
}
