namespace Boootcamp20.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingModelSupplier2 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.DetailPenjualans", new[] { "Penjualann_id" });
            AddColumn("dbo.Penjualans", "Total", c => c.Int(nullable: false));
            CreateIndex("dbo.DetailPenjualans", "Penjualann_Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.DetailPenjualans", new[] { "Penjualann_Id" });
            DropColumn("dbo.Penjualans", "Total");
            CreateIndex("dbo.DetailPenjualans", "Penjualann_id");
        }
    }
}
