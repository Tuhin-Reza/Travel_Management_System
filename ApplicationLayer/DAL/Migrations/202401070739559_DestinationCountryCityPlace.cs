namespace DAL.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class DestinationCountryCityPlace : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DestinationCountryCityPlaces", "DestinationCountry_CountryID", "dbo.DestinationCountries");
            DropIndex("dbo.DestinationCountryCityPlaces", new[] { "DestinationCountry_CountryID" });
            RenameColumn(table: "dbo.DestinationCountryCityPlaces", name: "DestinationCountry_CountryID", newName: "DestinationCountryId");
            AddColumn("dbo.DestinationCountryCityPlaces", "PlaceName", c => c.String(nullable: false));
            AddColumn("dbo.DestinationCountryCityPlaces", "PlaceDescription", c => c.String());
            AddColumn("dbo.DestinationCountryCityPlaces", "DestinationCountryCityId", c => c.Int(nullable: false));
            AlterColumn("dbo.DestinationCountryCityPlaces", "DestinationCountryId", c => c.Int(nullable: false));
            CreateIndex("dbo.DestinationCountryCityPlaces", "DestinationCountryId");
            CreateIndex("dbo.DestinationCountryCityPlaces", "DestinationCountryCityId");
            AddForeignKey("dbo.DestinationCountryCityPlaces", "DestinationCountryCityId", "dbo.DestinationCountryCities", "CityID");
            AddForeignKey("dbo.DestinationCountryCityPlaces", "DestinationCountryId", "dbo.DestinationCountries", "CountryID", cascadeDelete: true);
        }

        public override void Down()
        {
            DropForeignKey("dbo.DestinationCountryCityPlaces", "DestinationCountryId", "dbo.DestinationCountries");
            DropForeignKey("dbo.DestinationCountryCityPlaces", "DestinationCountryCityId", "dbo.DestinationCountryCities");
            DropIndex("dbo.DestinationCountryCityPlaces", new[] { "DestinationCountryCityId" });
            DropIndex("dbo.DestinationCountryCityPlaces", new[] { "DestinationCountryId" });
            AlterColumn("dbo.DestinationCountryCityPlaces", "DestinationCountryId", c => c.Int());
            DropColumn("dbo.DestinationCountryCityPlaces", "DestinationCountryCityId");
            DropColumn("dbo.DestinationCountryCityPlaces", "PlaceDescription");
            DropColumn("dbo.DestinationCountryCityPlaces", "PlaceName");
            RenameColumn(table: "dbo.DestinationCountryCityPlaces", name: "DestinationCountryId", newName: "DestinationCountry_CountryID");
            CreateIndex("dbo.DestinationCountryCityPlaces", "DestinationCountry_CountryID");
            AddForeignKey("dbo.DestinationCountryCityPlaces", "DestinationCountry_CountryID", "dbo.DestinationCountries", "CountryID");
        }
    }
}
