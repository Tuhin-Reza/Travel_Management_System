namespace DAL.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class updateRoomTypeForHotel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Hotels", "RoomType_RoomTypeID", "dbo.RoomTypes");
            DropIndex("dbo.Hotels", new[] { "RoomType_RoomTypeID" });
            RenameColumn(table: "dbo.Hotels", name: "RoomType_RoomTypeID", newName: "RoomTypeID");
            AlterColumn("dbo.Hotels", "RoomStatus", c => c.String());
            AlterColumn("dbo.Hotels", "RoomTypeID", c => c.Int(nullable: false));
            CreateIndex("dbo.Hotels", "RoomTypeID");
            AddForeignKey("dbo.Hotels", "RoomTypeID", "dbo.RoomTypes", "RoomTypeID", cascadeDelete: true);
        }

        public override void Down()
        {
            DropForeignKey("dbo.Hotels", "RoomTypeID", "dbo.RoomTypes");
            DropIndex("dbo.Hotels", new[] { "RoomTypeID" });
            AlterColumn("dbo.Hotels", "RoomTypeID", c => c.Int());
            AlterColumn("dbo.Hotels", "RoomStatus", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Hotels", name: "RoomTypeID", newName: "RoomType_RoomTypeID");
            CreateIndex("dbo.Hotels", "RoomType_RoomTypeID");
            AddForeignKey("dbo.Hotels", "RoomType_RoomTypeID", "dbo.RoomTypes", "RoomTypeID");
        }
    }
}
