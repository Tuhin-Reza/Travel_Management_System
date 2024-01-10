namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DestinationCountryCity : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DestinationCountryCities", "DestinationCountry_CountryID", "dbo.DestinationCountries");
            DropIndex("dbo.DestinationCountryCities", new[] { "DestinationCountry_CountryID" });
            RenameColumn(table: "dbo.DestinationCountryCities", name: "DestinationCountry_CountryID", newName: "DestinationCountryID");
            AddColumn("dbo.DestinationCountryCities", "CityName", c => c.String(nullable: false));
            AddColumn("dbo.DestinationCountryCities", "CityDescription", c => c.String(nullable: false));
            AddColumn("dbo.DestinationCountryCities", "Population", c => c.Int(nullable: false));
            AddColumn("dbo.DestinationCountryCityPlaces", "DestinationCountryCity_CityID", c => c.Int());
            AlterColumn("dbo.DestinationCountryCities", "DestinationCountryID", c => c.Int(nullable: false));
            CreateIndex("dbo.DestinationCountryCities", "DestinationCountryID");
            CreateIndex("dbo.DestinationCountryCityPlaces", "DestinationCountryCity_CityID");
            AddForeignKey("dbo.DestinationCountryCityPlaces", "DestinationCountryCity_CityID", "dbo.DestinationCountryCities", "CityID");
            AddForeignKey("dbo.DestinationCountryCities", "DestinationCountryID", "dbo.DestinationCountries", "CountryID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DestinationCountryCities", "DestinationCountryID", "dbo.DestinationCountries");
            DropForeignKey("dbo.DestinationCountryCityPlaces", "DestinationCountryCity_CityID", "dbo.DestinationCountryCities");
            DropIndex("dbo.DestinationCountryCityPlaces", new[] { "DestinationCountryCity_CityID" });
            DropIndex("dbo.DestinationCountryCities", new[] { "DestinationCountryID" });
            AlterColumn("dbo.DestinationCountryCities", "DestinationCountryID", c => c.Int());
            DropColumn("dbo.DestinationCountryCityPlaces", "DestinationCountryCity_CityID");
            DropColumn("dbo.DestinationCountryCities", "Population");
            DropColumn("dbo.DestinationCountryCities", "CityDescription");
            DropColumn("dbo.DestinationCountryCities", "CityName");
            RenameColumn(table: "dbo.DestinationCountryCities", name: "DestinationCountryID", newName: "DestinationCountry_CountryID");
            CreateIndex("dbo.DestinationCountryCities", "DestinationCountry_CountryID");
            AddForeignKey("dbo.DestinationCountryCities", "DestinationCountry_CountryID", "dbo.DestinationCountries", "CountryID");
        }
    }
}
