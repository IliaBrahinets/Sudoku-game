using EntertainmentPortal.DataAccess.Common.UoW.Sudoku;
using EntertainmentPortal.DataAccess.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntertainmentPortal.DataAccess.UoW.Sudoku
{
    /// <summary>
    /// Implementation of a unit of work.
    /// </summary>
    /// <seealso cref="EntertainmentPortal.DataAccess.Common.UoW.Sudoku.IUnitOfWork" />
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _dbContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWork"/> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        public UnitOfWork(SudokuContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <inheritdoc/>
        public int Commit()
        {
            return _dbContext.SaveChanges();
        }

        /// <inheritdoc/>
        public async Task<int> CommitAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}
