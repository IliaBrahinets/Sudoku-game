namespace EntertainmentPortal.DataAccess.Migrations.Sudoku
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CellsDeletedWhenBoardsDeleted : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.cells", "player_board_id", "dbo.player_boards");
            DropForeignKey("dbo.cells", "template_board_id", "dbo.template_boards");
            AddForeignKey("dbo.cells", "player_board_id", "dbo.player_boards", "player_board_id", cascadeDelete: true);
            AddForeignKey("dbo.cells", "template_board_id", "dbo.template_boards", "template_board_id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.cells", "template_board_id", "dbo.template_boards");
            DropForeignKey("dbo.cells", "player_board_id", "dbo.player_boards");
            AddForeignKey("dbo.cells", "template_board_id", "dbo.template_boards", "template_board_id");
            AddForeignKey("dbo.cells", "player_board_id", "dbo.player_boards", "player_board_id");
        }
    }
}
