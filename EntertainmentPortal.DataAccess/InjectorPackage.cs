using EntertainmentPortal.DataAccess.Context;
using SimpleInjector;
using SimpleInjector.Packaging;
using EntertainmentPortal.DataAccess.Common.Models.Games.Sudoku;
using EntertainmentPortal.DataAccess.Common.Repositories.Games.Sudoku;
using EntertainmentPortal.DataAccess.Common.UoW.Sudoku;
using EntertainmentPortal.DataAccess.Repositories.Sudoku;
using EntertainmentPortal.DataAccess.UoW.Sudoku;


namespace EntertainmentPortal.DataAccess
{
    public class InjectorPackage : IPackage
    {
        public void RegisterServices(Container container)
        {
            container.Register<SudokuContext>();
            container.Register<IRepository<TemplateBoardDbModel>, Repository<TemplateBoardDbModel>>();
            container.Register<IRepository<PlayerBoardDbModel>, Repository<PlayerBoardDbModel>>();
            container.Register<IRepository<CellDbModel>, Repository<CellDbModel>>();
            container.Register<IRepository<PlayerDbModel>, Repository<PlayerDbModel>>();
            container.Register<IUnitOfWork, UnitOfWork>();
        }
    }
}