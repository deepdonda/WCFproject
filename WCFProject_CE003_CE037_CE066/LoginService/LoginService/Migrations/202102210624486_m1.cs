namespace LoginService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Arts", "authorid");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Arts", "authorid", c => c.Int(nullable: false));
        }
    }
}
