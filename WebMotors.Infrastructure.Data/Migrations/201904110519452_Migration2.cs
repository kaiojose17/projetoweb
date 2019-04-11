namespace WebMotors.Infrastructure.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tb_AnuncioWebmotors", "Marca", c => c.String(nullable: false, maxLength: 45, unicode: false));
            AlterColumn("dbo.tb_AnuncioWebmotors", "Modelo", c => c.String(nullable: false, maxLength: 45, unicode: false));
            AlterColumn("dbo.tb_AnuncioWebmotors", "Versao", c => c.String(nullable: false, maxLength: 45, unicode: false));
            AlterColumn("dbo.tb_AnuncioWebmotors", "Observacao", c => c.String(nullable: false, unicode: false, storeType: "text"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tb_AnuncioWebmotors", "Observacao", c => c.String(unicode: false, storeType: "text"));
            AlterColumn("dbo.tb_AnuncioWebmotors", "Versao", c => c.String(maxLength: 45));
            AlterColumn("dbo.tb_AnuncioWebmotors", "Modelo", c => c.String(maxLength: 45));
            AlterColumn("dbo.tb_AnuncioWebmotors", "Marca", c => c.String(maxLength: 45));
        }
    }
}
