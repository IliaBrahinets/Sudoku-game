using System;
using System.Collections.Generic;
using System.Linq;
using EntertainmentPortal.DataAccess.Common.Models.Games.Sudoku;
using EntertainmentPortal.Logic.Common.Models.Games.Sudoku.Levels;
using EntertainmentPortal.Logic.Common.Services.Games.Sudoku.LevelServices;
using EntertainmentPortal.Logic.Common.Exceptions.Sudoku;

namespace EntertainmentPortal.Logic.Services.Games.SudokuServices.LevelServices
{
    /// <summary>
    /// Exposes the operations of assignig a difficulty level to a board, creating a difficulty level by string representation. 
    /// </summary>
    /// <seealso cref="EntertainmentPortal.Logic.Common.Services.Games.Sudoku.LevelServices.ILevelAssigner" />
    /// <seealso cref="EntertainmentPortal.Logic.Common.Services.Games.Sudoku.LevelServices.ILevelFactory" />
    public class LevelFactory : ILevelAssigner, ILevelFactory, IAvailableLevelsProvider
    {
        private static IEnumerable<DifficultyLevel> levels;

        static LevelFactory() => Initialize();

        private static void Initialize()
        {
            var typesLevels = System.Reflection.Assembly.GetAssembly(typeof(DifficultyLevel)).GetTypes()
                .Where(type => typeof(DifficultyLevel).IsAssignableFrom(type) && !type.IsAbstract);

            levels = typesLevels.Select(type => System.Activator.CreateInstance(type) as DifficultyLevel);
        }
        
        /// <inheritdoc />
        public DifficultyLevel Assign(TemplateBoardDbModel template)
        {
            return levels.FirstOrDefault(level => level.IsMatchLevel(template)) ?? 
                throw new AssignBoardLevelException($"Level with {template.EmptyCellsCount} empty cells can not be assigned. Template board id: {template.Id}'");
        }

        /// <inheritdoc />
        public DifficultyLevel CreateLevel(string levelName)
        {
            return levels.FirstOrDefault(level => level.LevelName == levelName) ?? throw new LevelNotFoundException();
        }
        
        /// <inheritdoc />
        public IEnumerable<string> GetLevels()
        {
            var res = levels.ToArray();
            Array.Sort(res);
            return res.Select(level => level.LevelName);
        }
    }
}
