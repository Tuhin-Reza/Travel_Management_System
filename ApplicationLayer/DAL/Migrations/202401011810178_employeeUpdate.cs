namespace DAL.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class employeeUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "FirstName", c => c.String(nullable: false));
            AddColumn("dbo.Employees", "LastName", c => c.String(nullable: false));
            DropColumn("dbo.Employees", "FullName");
        }

        public override void Down()
        {
            AddColumn("dbo.Employees", "FullName", c => c.String(nullable: false));
            DropColumn("dbo.Employees", "LastName");
            DropColumn("dbo.Employees", "FirstName");
        }
    }
}
