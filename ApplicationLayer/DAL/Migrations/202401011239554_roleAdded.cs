namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class roleAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "RoleId", c => c.Int(nullable: false));
            AddColumn("dbo.Users", "EmpId", c => c.Int(nullable: false));
            CreateIndex("dbo.Users", "RoleId");
            CreateIndex("dbo.Users", "EmpId");
            AddForeignKey("dbo.Users", "EmpId", "dbo.Employees", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Users", "RoleId", "dbo.Roles", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.Users", "EmpId", "dbo.Employees");
            DropIndex("dbo.Users", new[] { "EmpId" });
            DropIndex("dbo.Users", new[] { "RoleId" });
            DropColumn("dbo.Users", "EmpId");
            DropColumn("dbo.Users", "RoleId");
        }
    }
}
