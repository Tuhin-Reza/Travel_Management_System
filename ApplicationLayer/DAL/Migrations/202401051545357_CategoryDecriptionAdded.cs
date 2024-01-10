namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CategoryDecriptionAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PropertyCategories", "CategoryDescription", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PropertyCategories", "CategoryDescription");
        }
    }
}
