using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EntertainmentPortal.Logic.Common.Exceptions.Sudoku
{
    /// <summary>
    /// Thrown when can not update cell for some reasons.
    /// </summary>
    [Serializable]
    public class CannotUpdateCellException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CannotUpdateCellException"/> class.
        /// </summary>
        public CannotUpdateCellException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CannotUpdateCellException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public CannotUpdateCellException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CannotUpdateCellException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="inner">The inner.</param>
        public CannotUpdateCellException(string message, Exception inner)
            : base(message, inner)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CannotUpdateCellException"/> class.
        /// </summary>
        /// <param name="info">The information.</param>
        /// <param name="context">The context.</param>
        protected CannotUpdateCellException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
