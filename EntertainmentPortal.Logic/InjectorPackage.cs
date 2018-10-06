using Castle.DynamicProxy;
using EntertainmentPortal.Logic.Common.Services.Games.Sudoku;
using EntertainmentPortal.Logic.Services.Games.SudokuServices;
using FluentValidation;
using SimpleInjector;
using SimpleInjector.Packaging;
using System.Net.Http;
using EntertainmentPortal.Logic.Services.Games.SudokuServices.LevelServices;
using EntertainmentPortal.Logic.Common.Services.Games.Sudoku.LevelServices;

namespace EntertainmentPortal.Logic
{
    public class InjectorPackage : IPackage
    {
        public void RegisterServices(Container container)
        {
            container.Register<ITemplateBoardService, TemplateBoardService>();
            container.Register<IStartGameService, StartGameService>();
            container.Register<ILevelFactory, LevelFactory>();
            container.Register<ILevelAssigner, LevelFactory>();
            container.Register<IAvailableLevelsProvider, LevelFactory>();
            container.Register<IGameStatisticsService, GameStatisticsService>();
            container.Register<IGameFinishService, GameFinishService>();
            container.Register<IGameProcessService, GameProcessService>();
            container.RegisterDecorator<IGameProcessService, GameProcessServiceValidator>();
            container.Register<IPlayerService, PlayerService>();
            container.RegisterDecorator<IPlayerService, PlayerServiceValidator>();
        }
    }
}
