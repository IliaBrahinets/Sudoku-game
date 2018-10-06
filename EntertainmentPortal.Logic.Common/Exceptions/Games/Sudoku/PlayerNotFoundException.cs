using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EntertainmentPortal.Logic.Common.Exceptions.Sudoku
{
    /// <summary>
    /// Thrown when a player can not be found.
    /// </summary>
    /// <seealso cref="System.Exception" />
    [Serializable]
    public class PlayerNotFoundException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PlayerNotFoundException"/> class.
        /// </summary>
        public PlayerNotFoundException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PlayerNotFoundException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public PlayerNotFoundException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PlayerNotFoundException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="inner">The inner.</param>
        public PlayerNotFoundException(string message, Exception inner)
            : base(message, inner)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PlayerNotFoundException"/> class.
        /// </summary>
        /// <param name="info">The information.</param>
        /// <param name="context">The context.</param>
        protected PlayerNotFoundException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
