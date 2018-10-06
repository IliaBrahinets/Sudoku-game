using System;
using System.Runtime.Serialization;

namespace EntertainmentPortal.Logic.Common.Exceptions.Sudoku
{
    /// <summary>
    /// Thrown when a board is not found.
    /// </summary>
    /// <seealso cref="System.Exception" />
    [Serializable]
    public class BoardNotFoundException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BoardNotFoundException"/> class.
        /// </summary>
        public BoardNotFoundException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BoardNotFoundException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public BoardNotFoundException(string message)
            : base(message)        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BoardNotFoundException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="inner">The inner.</param>
        public BoardNotFoundException(string message, Exception inner)
            : base(message, inner)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BoardNotFoundException"/> class.
        /// </summary>
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo" /> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext" /> that contains contextual information about the source or destination.</param>
        protected BoardNotFoundException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
