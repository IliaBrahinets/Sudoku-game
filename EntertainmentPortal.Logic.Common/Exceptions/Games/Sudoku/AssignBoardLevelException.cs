using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EntertainmentPortal.Logic.Common.Exceptions.Sudoku
{
    /// <summary>
    /// Board level can not be assigned exception.
    /// </summary>
    [Serializable]
    public class AssignBoardLevelException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AssignBoardLevelException"/> class.
        /// </summary>
        public AssignBoardLevelException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AssignBoardLevelException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public AssignBoardLevelException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AssignBoardLevelException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="inner">The inner.</param>
        public AssignBoardLevelException(string message, Exception inner)
            : base(message, inner)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AssignBoardLevelException"/> class.
        /// </summary>
        /// <param name="info">The information.</param>
        /// <param name="context">The context.</param>
        protected AssignBoardLevelException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
