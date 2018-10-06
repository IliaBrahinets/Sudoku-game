using System;
using System.Linq.Expressions;
using EntertainmentPortal.DataAccess.Common.Models.Games.Sudoku;

namespace EntertainmentPortal.Logic.Common.Models.Games.Sudoku.Levels
{
    /// <summary>
    /// Difficulty level based on the number of empty cells.
    /// </summary>
    public abstract class DifficultyLevel : IComparable<DifficultyLevel>, IComparable
    {
        /// <summary>
        /// Gets the name of the level.
        /// </summary>
        /// <value>
        /// The name of the level.
        /// </value>
        public abstract string LevelName { get; }

        /// <summary>
        /// Lower bound of empty cells count for this level.
        /// </summary>
        protected abstract int LowerBound { get; }

        /// <summary>
        /// Upper bound of empty cells count for this level.
        /// </summary>
        protected abstract int UpperBound { get; }

        /// <summary>
        /// Determines whether the specified board is of the current level.
        /// </summary>
        /// <param name="board">The board.</param>
        /// <returns>
        ///   <c>true</c> if the specified board is of the current level, otherwise <c>false</c>.
        /// </returns>
        public bool IsMatchLevel(TemplateBoardDbModel board)
        {
            return board.EmptyCellsCount >= LowerBound && board.EmptyCellsCount < UpperBound;
        }

        /// <summary>
        /// Expression for the current level criteria.
        /// </summary>
        public Expression<Func<TemplateBoardDbModel, bool>> IsMatchLevelExpression()
        {
            return board => board.EmptyCellsCount >= LowerBound && board.EmptyCellsCount < UpperBound;
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString() => LevelName;

        public int CompareTo(object obj)
        {
            if (obj == null)
            {
                return 1;
            }
            
            var level = obj as DifficultyLevel;;

            if (level != null)
            {
                return this.CompareTo(level);
            }
           
            throw new ArgumentException("Obj is not a difficultyLevel");
        }
        
        public int CompareTo(DifficultyLevel other)
        {
            if (other == null)
            {
                return 1;
            }
            
            return this.UpperBound - other.UpperBound;
        }
    }
}
