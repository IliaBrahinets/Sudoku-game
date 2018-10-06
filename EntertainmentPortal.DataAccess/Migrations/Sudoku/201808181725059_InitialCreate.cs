namespace EntertainmentPortal.DataAccess.Migrations.Sudoku
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.cells",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        x_coordinate = c.Int(nullable: false),
                        y_coordinate = c.Int(nullable: false),
                        block_number = c.Int(nullable: false),
                        value = c.Int(nullable: false),
                        is_empty = c.Boolean(nullable: false),
                        template_board_id = c.Int(),
                        player_board_id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.player_boards", t => t.player_board_id)
                .ForeignKey("dbo.template_boards", t => t.template_board_id)
                .Index(t => t.template_board_id)
                .Index(t => t.player_board_id);
            
            CreateTable(
                "dbo.player_boards",
                c => new
                    {
                        player_board_id = c.Int(nullable: false, identity: true),
                        template_board_id = c.Int(nullable: false),
                        player_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.player_board_id)
                .ForeignKey("dbo.players", t => t.player_id, cascadeDelete: true)
                .ForeignKey("dbo.template_boards", t => t.template_board_id, cascadeDelete: true)
                .Index(t => t.template_board_id)
                .Index(t => t.player_id);
            
            CreateTable(
                "dbo.players",
                c => new
                    {
                        player_id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false),
                        points_count = c.Int(nullable: false),
                        max_point = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.player_id);
            
            CreateTable(
                "dbo.template_boards",
                c => new
                    {
                        template_board_id = c.Int(nullable: false, identity: true),
                        empty_cells_count = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.template_board_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.cells", "template_board_id", "dbo.template_boards");
            DropForeignKey("dbo.cells", "player_board_id", "dbo.player_boards");
            DropForeignKey("dbo.player_boards", "template_board_id", "dbo.template_boards");
            DropForeignKey("dbo.player_boards", "player_id", "dbo.players");
            DropIndex("dbo.player_boards", new[] { "player_id" });
            DropIndex("dbo.player_boards", new[] { "template_board_id" });
            DropIndex("dbo.cells", new[] { "player_board_id" });
            DropIndex("dbo.cells", new[] { "template_board_id" });
            DropTable("dbo.template_boards");
            DropTable("dbo.players");
            DropTable("dbo.player_boards");
            DropTable("dbo.cells");
        }
    }
}
