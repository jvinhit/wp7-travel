using System;

namespace SilverlightPhoneDatabase.Exceptions
{
    /// <summary>
    /// Exception thrown when table with the same name already exists
    /// </summary>
    public class TableExistsException : Exception
    {
        private TableExistsException() { }

        /// <summary>
        /// Create new instance of TableExistsException exception
        /// </summary>
        /// <param name="exceptionText">Exception text</param>
        public TableExistsException(string exceptionText)
            : base(exceptionText) { }

    }
}
