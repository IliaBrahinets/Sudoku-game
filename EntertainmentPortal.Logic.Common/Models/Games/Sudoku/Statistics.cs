using EntertainmentPortal.Logic.Common.Models.Games.Sudoku.Levels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EntertainmentPortal.Logic.Common.Models.Games.Sudoku
{
    /// <summary>
    /// A model to represent players statistics.
    /// </summary>
    public class Statistics
    {
        /// <summary>
        /// Gets or sets the number of won easy games.
        /// </summary>
        public int EasyWinsCount { get; set; }

        /// <summary>
        /// Gets or sets the number of won medium games.
        /// </summary>
        public int MediumWinsCount { get; set; }

        /// <summary>
        /// Gets or sets the number of won hard games.
        /// </summary>
        public int HardWinsCount { get; set; }

        /// <summary>
        /// Gets or sets the number of won games;
        /// </summary>
        public int Count => EasyWinsCount + MediumWinsCount + HardWinsCount;

        #region UpdateStatistic
        private const string PropertyNamePostfix = "WinsCount";
        private static PropertyInfo[] LevelPointProperties;

        static Statistics()
        {
            LevelPointProperties = typeof(Statistics).GetProperties()
                                                     .Where(prop => prop.Name.Contains(PropertyNamePostfix))
                                                     .ToArray();
        }

        public void AddWonGame(DifficultyLevel level)
        {
            var propName = $"{level}{PropertyNamePostfix}";
            var property = LevelPointProperties.First(prop => prop.Name.Equals(propName));
            int currentValue = (int)property.GetValue(this);
            currentValue++;
            property.SetValue(this, currentValue);
        }
        #endregion
    }
}
