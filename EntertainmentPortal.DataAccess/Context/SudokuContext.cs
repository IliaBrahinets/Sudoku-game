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
        private const string _connectionName = "SudokuConnection";
        private const string _configFileName = "EntertainmentPortal.DataAccess.dll.config";
        private static readonly string _connectionString;

        /// <summary>
        /// Static constructor of a <see cref="SudokuContext"/>.
        /// </summary>
        /// <exception cref="ConfigurationErrorsException">Connection string is null or empty</exception>
        static SudokuContext()
        {
            var codeBase = Assembly.GetExecutingAssembly().CodeBase;
            var uri = new UriBuilder(codeBase);
            string path = Uri.UnescapeDataString(uri.Path);
            string fullCfgFileName = $@"{Path.GetDirectoryName(path)}\{_configFileName}";

            var configMap = new ExeConfigurationFileMap() { ExeConfigFilename = fullCfgFileName };
            var config = ConfigurationManager.OpenMappedExeConfiguration(configMap, ConfigurationUserLevel.None);
            foreach (ConnectionStringSettings connectionString in config.ConnectionStrings.ConnectionStrings)
            {
                if (connectionString.Name.Equals(_connectionName, StringComparison.OrdinalIgnoreCase))
                {
                    _connectionString = connectionString.ConnectionString;
                    break;
                }
            }

            if (string.IsNullOrEmpty(_connectionString))
            {
                throw new ConfigurationErrorsException($"Cannot find connection string with name {_connectionName}");
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SudokuContext"/>.
        /// </summary>
        public SudokuContext() : base(_connectionString)
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
