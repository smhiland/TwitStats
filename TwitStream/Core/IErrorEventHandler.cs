using System;

namespace TwitStream.Core
{
    /// <summary>
    /// Event handler for receiving tweets
    /// </summary>
    public interface IErrorEventHandler
    {
        /// <summary>
        /// Event Handler to react to error
        /// </summary>
        event EventHandler<Exception> ErrorReceived;
    }
}
