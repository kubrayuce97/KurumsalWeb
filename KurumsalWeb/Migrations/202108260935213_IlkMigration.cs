namespace KurumsalWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IlkMigration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Slider", "Aciklama", c => c.String(maxLength: 150));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Slider", "Aciklama", c => c.String(maxLength: 30));
        }
    }
}
