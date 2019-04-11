namespace WebMotors.Infrastructure.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tb_AnuncioWebmotors", "Marca", c => c.String(maxLength: 45));
            AlterColumn("dbo.tb_AnuncioWebmotors", "Modelo", c => c.String(maxLength: 45));
            AlterColumn("dbo.tb_AnuncioWebmotors", "Versao", c => c.String(maxLength: 45));
            AlterColumn("dbo.tb_AnuncioWebmotors", "Observacao", c => c.String(unicode: false, storeType: "text"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tb_AnuncioWebmotors", "Observacao", c => c.String());
            AlterColumn("dbo.tb_AnuncioWebmotors", "Versao", c => c.String());
            AlterColumn("dbo.tb_AnuncioWebmotors", "Modelo", c => c.String());
            AlterColumn("dbo.tb_AnuncioWebmotors", "Marca", c => c.String());
        }
    }
}
