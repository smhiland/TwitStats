using System;

namespace TwitStream.Core
{
    /// <summary>
    /// Event handler for receiving tweets
    /// </summary>
    public interface IEventHandler
    {
        /// <summary>
        /// Event Handler to react to received tweet
        /// </summary>
        event EventHandler<ITweet> TweetReceived;
    }
}
