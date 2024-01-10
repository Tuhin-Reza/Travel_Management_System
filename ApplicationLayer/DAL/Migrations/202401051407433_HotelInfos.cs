namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HotelInfos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DestinationCountries",
                c => new
                    {
                        CountryID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.CountryID);
            
            CreateTable(
                "dbo.DestinationCountryCities",
                c => new
                    {
                        CityID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.CityID);
            
            CreateTable(
                "dbo.DestinationCountryCityPlaces",
                c => new
                    {
                        PlaceID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.PlaceID);
            
            CreateTable(
                "dbo.EmployeeSalaries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Employee_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.Employee_Id)
                .Index(t => t.Employee_Id);
            
            CreateTable(
                "dbo.LeaveRequests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Employee_Id = c.Int(),
                        LeaveType_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.Employee_Id)
                .ForeignKey("dbo.LeaveTypes", t => t.LeaveType_Id)
                .Index(t => t.Employee_Id)
                .Index(t => t.LeaveType_Id);
            
            CreateTable(
                "dbo.LeaveSheets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Employee_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.Employee_Id)
                .Index(t => t.Employee_Id);
            
            CreateTable(
                "dbo.FacilityTypes",
                c => new
                    {
                        FacilityID = c.Int(nullable: false, identity: true),
                        FacilityName = c.String(nullable: false),
                        FacilityDescription = c.String(),
                    })
                .PrimaryKey(t => t.FacilityID);
            
            CreateTable(
                "dbo.Hotels",
                c => new
                    {
                        HotelID = c.Int(nullable: false, identity: true),
                        FacilityType_FacilityID = c.Int(),
                        PropertyType_PropertyTypeID = c.Int(),
                    })
                .PrimaryKey(t => t.HotelID)
                .ForeignKey("dbo.FacilityTypes", t => t.FacilityType_FacilityID)
                .ForeignKey("dbo.PropertyTypes", t => t.PropertyType_PropertyTypeID)
                .Index(t => t.FacilityType_FacilityID)
                .Index(t => t.PropertyType_PropertyTypeID);
            
            CreateTable(
                "dbo.LeaveTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LeaveTypeName = c.String(nullable: false),
                        TotalDays = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Properties",
                c => new
                    {
                        PropertyID = c.Int(nullable: false, identity: true),
                        PropertyCategory_CategoryID = c.Int(),
                    })
                .PrimaryKey(t => t.PropertyID)
                .ForeignKey("dbo.PropertyCategories", t => t.PropertyCategory_CategoryID)
                .Index(t => t.PropertyCategory_CategoryID);
            
            CreateTable(
                "dbo.PropertyCategories",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CategoryID);
            
            CreateTable(
                "dbo.PropertyTypes",
                c => new
                    {
                        PropertyTypeID = c.Int(nullable: false, identity: true),
                        TypeName = c.String(nullable: false),
                        TypeDescription = c.String(),
                    })
                .PrimaryKey(t => t.PropertyTypeID);
            
            CreateTable(
                "dbo.RoomTypes",
                c => new
                    {
                        RoomTypeID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.RoomTypeID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Hotels", "PropertyType_PropertyTypeID", "dbo.PropertyTypes");
            DropForeignKey("dbo.Properties", "PropertyCategory_CategoryID", "dbo.PropertyCategories");
            DropForeignKey("dbo.LeaveRequests", "LeaveType_Id", "dbo.LeaveTypes");
            DropForeignKey("dbo.Hotels", "FacilityType_FacilityID", "dbo.FacilityTypes");
            DropForeignKey("dbo.LeaveSheets", "Employee_Id", "dbo.Employees");
            DropForeignKey("dbo.LeaveRequests", "Employee_Id", "dbo.Employees");
            DropForeignKey("dbo.EmployeeSalaries", "Employee_Id", "dbo.Employees");
            DropIndex("dbo.Properties", new[] { "PropertyCategory_CategoryID" });
            DropIndex("dbo.Hotels", new[] { "PropertyType_PropertyTypeID" });
            DropIndex("dbo.Hotels", new[] { "FacilityType_FacilityID" });
            DropIndex("dbo.LeaveSheets", new[] { "Employee_Id" });
            DropIndex("dbo.LeaveRequests", new[] { "LeaveType_Id" });
            DropIndex("dbo.LeaveRequests", new[] { "Employee_Id" });
            DropIndex("dbo.EmployeeSalaries", new[] { "Employee_Id" });
            DropTable("dbo.RoomTypes");
            DropTable("dbo.PropertyTypes");
            DropTable("dbo.PropertyCategories");
            DropTable("dbo.Properties");
            DropTable("dbo.LeaveTypes");
            DropTable("dbo.Hotels");
            DropTable("dbo.FacilityTypes");
            DropTable("dbo.LeaveSheets");
            DropTable("dbo.LeaveRequests");
            DropTable("dbo.EmployeeSalaries");
            DropTable("dbo.DestinationCountryCityPlaces");
            DropTable("dbo.DestinationCountryCities");
            DropTable("dbo.DestinationCountries");
        }
    }
}
