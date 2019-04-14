namespace WebMotors.Infrastructure.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tb_AnuncioWebmotors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Marca = c.String(nullable: false, maxLength: 45, unicode: false),
                        Modelo = c.String(nullable: false, maxLength: 45, unicode: false),
                        Versao = c.String(nullable: false, maxLength: 45, unicode: false),
                        Ano = c.Int(nullable: false),
                        Quilometragem = c.Int(nullable: false),
                        Observacao = c.String(nullable: false, unicode: false, storeType: "text"),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.tb_AnuncioWebmotors");
        }
    }
}
