namespace Courses.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedSomething : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Students", "FirstName", c => c.String(nullable: false, maxLength: 60));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Students", "FirstName", c => c.String(maxLength: 60));
        }
    }
}
