namespace CinemAPI.Data.EF
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingReservationandTicket : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProjectionStartDate = c.DateTime(nullable: false),
                        MovieName = c.String(nullable: false),
                        CinemaName = c.String(nullable: false),
                        RoomNumber = c.Int(nullable: false),
                        Row = c.Int(nullable: false),
                        Col = c.Int(nullable: false),
                        ProjectionId = c.Int(nullable: false),
                        MovieId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AlterColumn("dbo.Reservations", "MovieName", c => c.String(nullable: false));
            AlterColumn("dbo.Reservations", "CinemaName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Reservations", "CinemaName", c => c.String());
            AlterColumn("dbo.Reservations", "MovieName", c => c.String());
            DropTable("dbo.Tickets");
        }
    }
}
