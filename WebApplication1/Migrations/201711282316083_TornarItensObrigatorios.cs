namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TornarItensObrigatorios : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Items", "Nome", c => c.String(nullable: false));
            AlterColumn("dbo.Items", "Tipo", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Items", "Tipo", c => c.String());
            AlterColumn("dbo.Items", "Nome", c => c.String());
        }
    }
}
