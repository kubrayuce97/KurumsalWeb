namespace KurumsalWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updaedataaseforce : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Yorum", "Onay", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Yorum", "Onay");
        }
    }
}
