using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntertainmentPortal.Logic.Common.Models.Games.Sudoku
{
    /// <summary>
    /// Represent the current player board status.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum BoardStatus
    {
        InProgress,
        Invalid,
        Complete
    }
}
