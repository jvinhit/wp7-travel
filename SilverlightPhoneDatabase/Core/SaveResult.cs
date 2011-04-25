using System;

namespace SilverlightPhoneDatabase.Core
{
    /// <summary>
    /// Contains resutls of asynchronous Save operation
    /// </summary>
    public class SaveResult
    {
        private SaveResult() { }

        internal SaveResult(Exception error) 
        {
            Error = error;
        }
        /// <summary>
        /// Exception that occurred during save
        /// </summary>
        public Exception Error { get; private set; }
    }
}
