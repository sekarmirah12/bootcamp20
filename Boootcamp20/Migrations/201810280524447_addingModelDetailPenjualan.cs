namespace Boootcamp20.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingModelDetailPenjualan : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DetailPenjualans",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        qyt = c.Int(nullable: false),
                        price = c.Int(nullable: false),
                        total = c.Int(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        UpdateDate = c.DateTime(nullable: false),
                        DeleteDate = c.DateTime(nullable: false),
                        isDelete = c.Boolean(nullable: false),
                        Items_Id = c.Int(),
                        Penjualann_id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Items", t => t.Items_Id)
                .ForeignKey("dbo.Penjualans", t => t.Penjualann_id)
                .Index(t => t.Items_Id)
                .Index(t => t.Penjualann_id);
            
            CreateTable(
                "dbo.Penjualans",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DetailPenjualans", "Penjualann_id", "dbo.Penjualans");
            DropForeignKey("dbo.DetailPenjualans", "Items_Id", "dbo.Items");
            DropIndex("dbo.DetailPenjualans", new[] { "Penjualann_id" });
            DropIndex("dbo.DetailPenjualans", new[] { "Items_Id" });
            DropTable("dbo.Penjualans");
            DropTable("dbo.DetailPenjualans");
        }
    }
}
