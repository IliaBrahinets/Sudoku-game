using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using EntertainmentPortal.DataAccess.Common.Models.Games.Sudoku;

namespace EntertainmentPortal.DataAccess.ModelConfigurations.Sudoku
{
    /// <summary>
    /// Represents an entity configuration for <see cref="TemplateBoardDbModel"/>.
    /// </summary>
    public class TemplateBoardDbConfiguration : EntityTypeConfiguration<TemplateBoardDbModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BoardDbConfiguration"/>.
        /// </summary>
        public TemplateBoardDbConfiguration()
        {
            ToTable("template_boards");
            HasKey(board => board.Id);

            Property(property => property.Id).HasColumnName("template_board_id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(property => property.EmptyCellsCount).HasColumnName("empty_cells_count").IsRequired();
        }
    }
}
