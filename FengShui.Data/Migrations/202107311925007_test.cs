namespace FengShui.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Product", "UserId", c => c.Guid(nullable: false));
            AlterColumn("dbo.Product", "CreatedUtc", c => c.DateTimeOffset(nullable: false, precision: 7));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Product", "CreatedUtc", c => c.DateTimeOffset(precision: 7));
            DropColumn("dbo.Product", "UserId");
        }
    }
}
