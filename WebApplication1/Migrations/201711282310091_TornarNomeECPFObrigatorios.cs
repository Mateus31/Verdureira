namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TornarNomeECPFObrigatorios : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Clientes", "Nome", c => c.String(nullable: false));
            AlterColumn("dbo.Clientes", "CPF", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Clientes", "CPF", c => c.String());
            AlterColumn("dbo.Clientes", "Nome", c => c.String());
        }
    }
}
