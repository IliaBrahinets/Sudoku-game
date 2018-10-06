namespace EntertainmentPortal.DataAccess.Migrations.Sudoku
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditedPlayerGameStatistics : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.players", "easy_wins", c => c.Int(nullable: false));
            AddColumn("dbo.players", "medium_wins", c => c.Int(nullable: false));
            AddColumn("dbo.players", "hard_wins", c => c.Int(nullable: false));
            DropColumn("dbo.players", "points_count");
            DropColumn("dbo.players", "max_point");
        }
        
        public override void Down()
        {
            AddColumn("dbo.players", "max_point", c => c.Int(nullable: false));
            AddColumn("dbo.players", "points_count", c => c.Int(nullable: false));
            DropColumn("dbo.players", "hard_wins");
            DropColumn("dbo.players", "medium_wins");
            DropColumn("dbo.players", "easy_wins");
        }
    }
}
