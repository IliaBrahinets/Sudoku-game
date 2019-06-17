using System;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.SqlServer;
using System.IO;
using System.Reflection;
using EntertainmentPortal.DataAccess.Common.Models.Games.Sudoku;
using EntertainmentPortal.DataAccess.Migrations.Sudoku;
using EntertainmentPortal.DataAccess.ModelConfigurations.Sudoku;

namespace EntertainmentPortal.DataAccess.Context
{
    /// <summary>
    /// Represents a db context for sudoku game.
    /// </summary>
    [DbConfigurationType(typeof(SudokuContextConfiguration))]
    public class SudokuContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SudokuContext"/>.
        /// </summary>
        public SudokuContext(SudokuContextParameters param) : base(param?.ConnectionString)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<SudokuContext, SudokuConfiguration>(true));
        }

        /// <summary>
        /// Gets or sets the players.
        /// </summary>
        /// <value>
        /// The players.
        /// </value>
        public IDbSet<PlayerDbModel> Players { get; set; }

        /// <summary>
        /// Gets or sets a GamePanels.
        /// </summary>
        /// <value>A <see cref="BoardDbModel"/></value>
        public IDbSet<PlayerBoardDbModel> PlayerBoards { get; set; }

        /// <summary>
        /// Gets or sets a GamePanels.
        /// </summary>
        /// <value>A <see cref="TemplateBoardDbModel"/></value>
        public IDbSet<TemplateBoardDbModel> TemplateBoards { get; set; }

        /// <summary>
        /// Gets or sets a Cells.
        /// </summary>
        /// <value>A <see cref="CellDb"/></value>
        public IDbSet<CellDbModel> Cells { get; set; }

        /// <summary>
        /// Configurates tables.
        /// </summary>
        /// <param name="modelBuilder">ModelBuilder</param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new TemplateBoardDbConfiguration());
            modelBuilder.Configurations.Add(new PlayerBoardDbConfiguration());
            modelBuilder.Configurations.Add(new CellDbConfiguration());
            modelBuilder.Configurations.Add(new PlayerDbConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }

    public class SudokuContextConfiguration : DbConfiguration
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Context.SudokuContextConfiguration"/>.
        /// </summary>
        public SudokuContextConfiguration()
        {
            this.SetDefaultConnectionFactory(new LocalDbConnectionFactory("mssqllocaldb"));
            this.SetProviderServices(SqlProviderServices.ProviderInvariantName, SqlProviderServices.Instance);
        }
    }
}
