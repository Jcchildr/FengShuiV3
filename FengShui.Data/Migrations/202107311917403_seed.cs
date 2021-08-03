namespace FengShui.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seed : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Product", "CreatedUtc", c => c.DateTimeOffset(precision: 7));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Product", "CreatedUtc", c => c.DateTimeOffset(nullable: false, precision: 7));
        }
    }
}
