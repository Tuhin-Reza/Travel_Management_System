namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DestinationCountry : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DestinationCountries", "CountryName", c => c.String(nullable: false));
            AddColumn("dbo.DestinationCountries", "Population", c => c.Int(nullable: false));
            AddColumn("dbo.DestinationCountries", "Language", c => c.String(nullable: false));
            AddColumn("dbo.DestinationCountries", "Currency", c => c.String(nullable: false));
            AddColumn("dbo.DestinationCountryCities", "DestinationCountry_CountryID", c => c.Int());
            AddColumn("dbo.DestinationCountryCityPlaces", "DestinationCountry_CountryID", c => c.Int());
            CreateIndex("dbo.DestinationCountryCities", "DestinationCountry_CountryID");
            CreateIndex("dbo.DestinationCountryCityPlaces", "DestinationCountry_CountryID");
            AddForeignKey("dbo.DestinationCountryCities", "DestinationCountry_CountryID", "dbo.DestinationCountries", "CountryID");
            AddForeignKey("dbo.DestinationCountryCityPlaces", "DestinationCountry_CountryID", "dbo.DestinationCountries", "CountryID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DestinationCountryCityPlaces", "DestinationCountry_CountryID", "dbo.DestinationCountries");
            DropForeignKey("dbo.DestinationCountryCities", "DestinationCountry_CountryID", "dbo.DestinationCountries");
            DropIndex("dbo.DestinationCountryCityPlaces", new[] { "DestinationCountry_CountryID" });
            DropIndex("dbo.DestinationCountryCities", new[] { "DestinationCountry_CountryID" });
            DropColumn("dbo.DestinationCountryCityPlaces", "DestinationCountry_CountryID");
            DropColumn("dbo.DestinationCountryCities", "DestinationCountry_CountryID");
            DropColumn("dbo.DestinationCountries", "Currency");
            DropColumn("dbo.DestinationCountries", "Language");
            DropColumn("dbo.DestinationCountries", "Population");
            DropColumn("dbo.DestinationCountries", "CountryName");
        }
    }
}
