namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class employeeType : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FullName = c.String(nullable: false),
                        Gender = c.String(nullable: false),
                        HireDate = c.DateTime(nullable: false),
                        PhoneNumber = c.String(nullable: false),
                        PresentAddress = c.String(nullable: false),
                        PermanentAddress = c.String(nullable: false),
                        Status = c.String(nullable: false),
                        EmplTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EmployeeTypes", t => t.EmplTypeId, cascadeDelete: true)
                .Index(t => t.EmplTypeId);
            
            CreateTable(
                "dbo.EmployeeTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmployeeTypeName = c.String(nullable: false),
                        BasicSalary = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoleName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "EmplTypeId", "dbo.EmployeeTypes");
            DropIndex("dbo.Employees", new[] { "EmplTypeId" });
            DropTable("dbo.Users");
            DropTable("dbo.Roles");
            DropTable("dbo.EmployeeTypes");
            DropTable("dbo.Employees");
        }
    }
}
