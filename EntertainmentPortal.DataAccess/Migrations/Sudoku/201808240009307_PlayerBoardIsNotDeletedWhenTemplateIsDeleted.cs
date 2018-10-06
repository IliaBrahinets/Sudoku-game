namespace EntertainmentPortal.DataAccess.Migrations.Sudoku
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PlayerBoardIsNotDeletedWhenTemplateIsDeleted : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.player_boards", "template_board_id", "dbo.template_boards");
            AddForeignKey("dbo.player_boards", "template_board_id", "dbo.template_boards", "template_board_id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.player_boards", "template_board_id", "dbo.template_boards");
            AddForeignKey("dbo.player_boards", "template_board_id", "dbo.template_boards", "template_board_id", cascadeDelete: true);
        }
    }
}
