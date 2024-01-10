namespace DAL.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class Hotel_Room : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Hotels", "FacilityType_FacilityID", "dbo.FacilityTypes");
            DropForeignKey("dbo.Hotels", "PropertyType_PropertyTypeID", "dbo.PropertyTypes");
            DropIndex("dbo.Hotels", new[] { "FacilityType_FacilityID" });
            DropIndex("dbo.Hotels", new[] { "PropertyType_PropertyTypeID" });
            RenameColumn(table: "dbo.Hotels", name: "FacilityType_FacilityID", newName: "FacilityTypeID");
            RenameColumn(table: "dbo.Hotels", name: "PropertyType_PropertyTypeID", newName: "PropertyTypeID");
            AddColumn("dbo.Hotels", "HotelName", c => c.String(nullable: false));
            AddColumn("dbo.Hotels", "PropertyCategoryID", c => c.Int(nullable: false));
            AddColumn("dbo.Hotels", "CityPlaceID", c => c.Int(nullable: false));
            AddColumn("dbo.Hotels", "TotalRoom", c => c.Int(nullable: false));
            AddColumn("dbo.Hotels", "RoomStatus", c => c.Int(nullable: false));
            AddColumn("dbo.Hotels", "RoomType_RoomTypeID", c => c.Int());
            AddColumn("dbo.RoomTypes", "RoomTypeName", c => c.String(nullable: false));
            AddColumn("dbo.RoomTypes", "MemberCount", c => c.Int(nullable: false));
            AddColumn("dbo.RoomTypes", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.RoomTypes", "RoomDescription", c => c.String());
            AlterColumn("dbo.Hotels", "FacilityTypeID", c => c.Int(nullable: false));
            AlterColumn("dbo.Hotels", "PropertyTypeID", c => c.Int(nullable: false));
            CreateIndex("dbo.Hotels", "PropertyTypeID");
            CreateIndex("dbo.Hotels", "PropertyCategoryID");
            CreateIndex("dbo.Hotels", "FacilityTypeID");
            CreateIndex("dbo.Hotels", "CityPlaceID");
            CreateIndex("dbo.Hotels", "RoomType_RoomTypeID");
            AddForeignKey("dbo.Hotels", "CityPlaceID", "dbo.DestinationCountryCityPlaces", "PlaceID", cascadeDelete: true);
            AddForeignKey("dbo.Hotels", "PropertyCategoryID", "dbo.PropertyCategories", "CategoryID", cascadeDelete: true);
            AddForeignKey("dbo.Hotels", "RoomType_RoomTypeID", "dbo.RoomTypes", "RoomTypeID");
            AddForeignKey("dbo.Hotels", "FacilityTypeID", "dbo.FacilityTypes", "FacilityID", cascadeDelete: true);
            AddForeignKey("dbo.Hotels", "PropertyTypeID", "dbo.PropertyTypes", "PropertyTypeID", cascadeDelete: true);
        }

        public override void Down()
        {
            DropForeignKey("dbo.Hotels", "PropertyTypeID", "dbo.PropertyTypes");
            DropForeignKey("dbo.Hotels", "FacilityTypeID", "dbo.FacilityTypes");
            DropForeignKey("dbo.Hotels", "RoomType_RoomTypeID", "dbo.RoomTypes");
            DropForeignKey("dbo.Hotels", "PropertyCategoryID", "dbo.PropertyCategories");
            DropForeignKey("dbo.Hotels", "CityPlaceID", "dbo.DestinationCountryCityPlaces");
            DropIndex("dbo.Hotels", new[] { "RoomType_RoomTypeID" });
            DropIndex("dbo.Hotels", new[] { "CityPlaceID" });
            DropIndex("dbo.Hotels", new[] { "FacilityTypeID" });
            DropIndex("dbo.Hotels", new[] { "PropertyCategoryID" });
            DropIndex("dbo.Hotels", new[] { "PropertyTypeID" });
            AlterColumn("dbo.Hotels", "PropertyTypeID", c => c.Int());
            AlterColumn("dbo.Hotels", "FacilityTypeID", c => c.Int());
            DropColumn("dbo.RoomTypes", "RoomDescription");
            DropColumn("dbo.RoomTypes", "Price");
            DropColumn("dbo.RoomTypes", "MemberCount");
            DropColumn("dbo.RoomTypes", "RoomTypeName");
            DropColumn("dbo.Hotels", "RoomType_RoomTypeID");
            DropColumn("dbo.Hotels", "RoomStatus");
            DropColumn("dbo.Hotels", "TotalRoom");
            DropColumn("dbo.Hotels", "CityPlaceID");
            DropColumn("dbo.Hotels", "PropertyCategoryID");
            DropColumn("dbo.Hotels", "HotelName");
            RenameColumn(table: "dbo.Hotels", name: "PropertyTypeID", newName: "PropertyType_PropertyTypeID");
            RenameColumn(table: "dbo.Hotels", name: "FacilityTypeID", newName: "FacilityType_FacilityID");
            CreateIndex("dbo.Hotels", "PropertyType_PropertyTypeID");
            CreateIndex("dbo.Hotels", "FacilityType_FacilityID");
            AddForeignKey("dbo.Hotels", "PropertyType_PropertyTypeID", "dbo.PropertyTypes", "PropertyTypeID");
            AddForeignKey("dbo.Hotels", "FacilityType_FacilityID", "dbo.FacilityTypes", "FacilityID");
        }
    }
}
