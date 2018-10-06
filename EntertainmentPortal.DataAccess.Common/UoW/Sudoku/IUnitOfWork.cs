using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntertainmentPortal.DataAccess.Common.UoW.Sudoku
{
    /// <summary>
    /// Exposes unitOfWork, it represents a database transaction.
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// Commits transaction.
        /// </summary>
        /// <returns></returns>
        int Commit();

        /// <summary>
        /// Commits transaction asynchronously.
        /// </summary>
        /// <returns></returns>
        Task<int> CommitAsync();
    }
}
