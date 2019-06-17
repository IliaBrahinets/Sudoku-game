using EntertainmentPortal.DataAccess.Context;
using SimpleInjector;
using SimpleInjector.Packaging;
using EntertainmentPortal.DataAccess.Common.Models.Games.Sudoku;
using EntertainmentPortal.DataAccess.Common.Repositories.Games.Sudoku;
using EntertainmentPortal.DataAccess.Common.UoW.Sudoku;
using EntertainmentPortal.DataAccess.Repositories.Sudoku;
using EntertainmentPortal.DataAccess.UoW.Sudoku;
using System.Configuration;
using System;

namespace EntertainmentPortal.DataAccess
{
    public class InjectorPackage : IPackage
    {
        public void RegisterServices(Container container)
        {
            container.Register<SudokuContext>(() => CreateSudokuContext(container));
            container.Register<IRepository<TemplateBoardDbModel>, Repository<TemplateBoardDbModel>>();
            container.Register<IRepository<PlayerBoardDbModel>, Repository<PlayerBoardDbModel>>();
            container.Register<IRepository<CellDbModel>, Repository<CellDbModel>>();
            container.Register<IRepository<PlayerDbModel>, Repository<PlayerDbModel>>();
            container.Register<IUnitOfWork, UnitOfWork>();
        }

        private SudokuContext CreateSudokuContext(Container container)
        {
            var config = container.GetInstance<Configuration>();
            string connecionString = null;
            foreach (ConnectionStringSettings item in config.ConnectionStrings.ConnectionStrings)
            {
                if (item.Name.Equals(SudokuContextConsts.ConnectionName, StringComparison.OrdinalIgnoreCase))
                {
                    connecionString = item.ConnectionString;
                    break;
                }
            }
            if (string.IsNullOrEmpty(connecionString))
            {
                throw new ConfigurationErrorsException($"Cannot find connection string with name {SudokuContextConsts.ConnectionName}");
            }
            var param = new SudokuContextParameters(connecionString);
            return new SudokuContext(param);
        }
    }
}