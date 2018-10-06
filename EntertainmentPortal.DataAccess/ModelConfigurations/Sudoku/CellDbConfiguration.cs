using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using EntertainmentPortal.DataAccess.Common.Models.Games.Sudoku;

namespace EntertainmentPortal.DataAccess.ModelConfigurations.Sudoku
{
    /// <summary>
    /// Represents an entity configuration for <see cref="CellDbModel"/>.
    /// </summary>
    /// <seealso cref="System.Data.Entity.ModelConfiguration.EntityTypeConfiguration{EntertainmentPortal.DataAccess.Common.Models.Games.Sudoku.CellDbModel}" />
    public class CellDbConfiguration : EntityTypeConfiguration<CellDbModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CellDbConfiguration"/>.
        /// </summary>
        public CellDbConfiguration()
        {
            ToTable("cells");
            HasKey(cell => cell.Id);
            HasOptional(cell => cell.TemplateBoard).WithMany(templateBoard => templateBoard.CellList).HasForeignKey(cell => cell.TemplateBoardId).WillCascadeOnDelete(true);
            HasOptional(cell => cell.PlayerBoard).WithMany(playerBoard => playerBoard.CellList).HasForeignKey(cell => cell.PlayerBoardId).WillCascadeOnDelete(true);

            Property(property => property.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(property => property.XCoordinate).HasColumnName("x_coordinate").IsRequired();
            Property(property => property.YCoordinate).HasColumnName("y_coordinate").IsRequired();
            Property(property => property.BlockNumber).HasColumnName("block_number").IsRequired();
            Property(property => property.Value).HasColumnName("value").IsOptional();
            Property(property => property.IsConst).HasColumnName("is_const").IsRequired();
            Property(property => property.TemplateBoardId).HasColumnName("template_board_id").IsOptional();
            Property(property => property.PlayerBoardId).HasColumnName("player_board_id").IsOptional(); 
        }
    }
}
