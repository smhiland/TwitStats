using System;
using Tweetinvi;

namespace TwitStream.Core
{
    /// <summary>
    /// Interface for Stream objects
    /// </summary>
    public interface IStream : IEventHandler, IErrorEventHandler, IMonitor, IDisposable, IEventHost
    {
        /// <summary>
        /// Create Twitter Stream based on client
        /// </summary>
        /// <param name="client">TwitterClient object which will host the stream</param>
        /// <returns>IStream object representing the Stream</returns>
        IStream CreateStream();

        /// <summary>
        /// Set the client for the stream
        /// </summary>
        /// <param name="client">Client hosting stream</param>
        /// <returns>Stream created from client</returns>
        IStream SetClient(TwitterClient client);

    }
}
