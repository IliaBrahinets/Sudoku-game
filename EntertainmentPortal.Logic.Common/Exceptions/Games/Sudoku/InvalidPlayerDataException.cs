using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EntertainmentPortal.Logic.Common.Exceptions.Sudoku
{
    /// <summary>
    /// Thrown when the inalid player data was provided.
    /// </summary>
    [Serializable]
    public class InvalidPlayerDataException : ArgumentException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidPlayerDataException"/> class.
        /// </summary>
        public InvalidPlayerDataException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidPlayerDataException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public InvalidPlayerDataException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidPlayerDataException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="inner">The inner.</param>
        public InvalidPlayerDataException(string message, Exception inner)
            : base(message, inner)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidPlayerDataException"/> class.
        /// </summary>
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo" /> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext" /> that contains contextual information about the source or destination.</param>
        protected InvalidPlayerDataException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
