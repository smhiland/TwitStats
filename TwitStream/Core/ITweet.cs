using System;

namespace TwitStream.Core
{
    /// <summary>
    /// Tweet object received
    /// </summary>
    public interface ITweet
    {
        /// <summary>
        /// Id of the Tweet
        /// </summary>
        string Id { get; set; }
        
        /// <summary>
        /// Date and Time the Tweet was created
        /// </summary>
        DateTimeOffset CreatedAt { get; set; }

        /// <summary>
        /// Author Id of the Tweet
        /// </summary>
        string AuthorId { get; set; }

        /// <summary>
        /// Text of the Tweet
        /// </summary>
        string Text { get; set; }

        /// <summary>
        /// Language of the Tweet
        /// </summary>
        string Lang { get; set; }
    }
}
