namespace GastosBack_ConsoleApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MovsEfectivo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RubroEfectivoId = c.Int(nullable: false),
                        Description = c.String(),
                        FechaIngreso = c.DateTime(nullable: false),
                        FechaMov = c.DateTime(nullable: false),
                        Monto = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Signo = c.String(),
                        Saldo = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RubrosBanco",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Rubro = c.String(nullable: false, maxLength: 50),
                        Signo = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RubrosEfectivo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Rubro = c.String(nullable: false, maxLength: 50),
                        Signo = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.RubrosEfectivo");
            DropTable("dbo.RubrosBanco");
            DropTable("dbo.MovsEfectivo");
        }
    }
}
