namespace StateTemplateV5Beta.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDateTime : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AddBlog",
                c => new
                    {
                        BlogID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 100, unicode: false),
                        Description = c.String(nullable: false, unicode: false),
                    })
                .PrimaryKey(t => t.BlogID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AddBlog");
        }
    }
}
