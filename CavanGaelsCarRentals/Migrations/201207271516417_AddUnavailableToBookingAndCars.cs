namespace CavanGaelsCarRentals.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUnavailableToBookingAndCars : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cars", "car_make", c => c.String());
            AddColumn("dbo.Cars", "car_model", c => c.String());
            AddColumn("dbo.Cars", "number_of_passengers", c => c.Int(nullable: true));
            AddColumn("dbo.Cars", "luggage_space", c => c.String());
            AddColumn("dbo.Cars", "image_url", c => c.String());
            AddColumn("dbo.Bookings", "UnavailableId", c => c.Int(nullable: true));
            AddForeignKey("dbo.Bookings", "UnavailableId", "dbo.Unavailables", "Id", cascadeDelete: false);
            CreateIndex("dbo.Bookings", "UnavailableId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Bookings", new[] { "UnavailableId" });
            DropForeignKey("dbo.Bookings", "UnavailableId", "dbo.Unavailables");
            DropColumn("dbo.Bookings", "UnavailableId");
            DropColumn("dbo.Cars", "image_url");
            DropColumn("dbo.Cars", "luggage_space");
            DropColumn("dbo.Cars", "number_of_passengers");
            DropColumn("dbo.Cars", "car_model");
            DropColumn("dbo.Cars", "car_make");
        }
    }
}
