using EntertainmentPortal.DataAccess.Common.Models.Games.Sudoku;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntertainmentPortal.DataAccess.ModelConfigurations.Sudoku
{
    /// <summary>
    /// Represents an entity configuration for <see cref="PlayerBoardDbModel"/>.
    /// </summary>
    public class PlayerBoardDbConfiguration : EntityTypeConfiguration<PlayerBoardDbModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BoardDbConfiguration"/>.
        /// </summary>
        public PlayerBoardDbConfiguration()
        {
            ToTable("player_boards");
            HasKey(board => board.Id);
            HasRequired(property => property.Player).WithMany(player => player.UnfinishedGames);
            HasRequired(property => property.TemplateBoard).WithMany().WillCascadeOnDelete(false);

            Property(property => property.Id).HasColumnName("player_board_id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(property => property.PlayerId).HasColumnName("player_id").IsRequired();
            Property(property => property.TemplateBoardId).HasColumnName("template_board_id").IsRequired();

        }
    }
}
