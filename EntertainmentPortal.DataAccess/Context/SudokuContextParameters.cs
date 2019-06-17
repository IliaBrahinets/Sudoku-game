using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntertainmentPortal.DataAccess.Context
{
    public class SudokuContextParameters
    {
        public string ConnectionString { get; }

        public SudokuContextParameters(string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString)) throw new ArgumentNullException(nameof(connectionString));
            this.ConnectionString = connectionString;
        }
    }
}
