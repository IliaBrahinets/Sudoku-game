using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using EntertainmentPortal.DataAccess.Common.Models.Games.Sudoku;

namespace EntertainmentPortal.DataAccess.ModelConfigurations.Sudoku
{
    /// <summary>
    /// Represents an entity configuration for <see cref="PlayerDbModel"/>.
    /// </summary>
    public class PlayerDbConfiguration : EntityTypeConfiguration<PlayerDbModel>
    {
        public PlayerDbConfiguration()
        {
            ToTable("players");
            HasKey(player => player.Id);

            Property(property => property.Id).HasColumnName("player_id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(property => property.Name).HasColumnName("name").IsRequired();
            Property(property => property.EasyWinsCount).HasColumnName("easy_wins").IsRequired();
            Property(property => property.MediumWinsCount).HasColumnName("medium_wins").IsRequired();
            Property(property => property.HardWinsCount).HasColumnName("hard_wins").IsRequired();
        }
    }
}
