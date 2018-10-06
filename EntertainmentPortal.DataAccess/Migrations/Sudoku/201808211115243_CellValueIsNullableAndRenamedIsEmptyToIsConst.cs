namespace EntertainmentPortal.DataAccess.Migrations.Sudoku
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CellValueIsNullableAndRenamedIsEmptyToIsConst : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.cells", "is_const", c => c.Boolean(nullable: false));
            AlterColumn("dbo.cells", "value", c => c.Int());
            DropColumn("dbo.cells", "is_empty");
        }
        
        public override void Down()
        {
            AddColumn("dbo.cells", "is_empty", c => c.Boolean(nullable: false));
            AlterColumn("dbo.cells", "value", c => c.Int(nullable: false));
            DropColumn("dbo.cells", "is_const");
        }
    }
}
