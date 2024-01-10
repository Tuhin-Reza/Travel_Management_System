namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatePropertyCategory : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PropertyCategories", "CategoryDescription", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PropertyCategories", "CategoryDescription", c => c.Int(nullable: false));
        }
    }
}
