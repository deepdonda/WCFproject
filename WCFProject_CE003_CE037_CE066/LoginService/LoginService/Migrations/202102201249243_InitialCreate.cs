namespace LoginService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Arts",
                c => new
                    {
                        artid = c.Int(nullable: false, identity: true),
                        content = c.String(nullable: false),
                        title = c.String(nullable: false),
                        authorname = c.String(nullable: false),
                        authorid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.artid);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Arts");
        }
    }
}
