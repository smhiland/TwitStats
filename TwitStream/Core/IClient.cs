using Tweetinvi;

namespace TwitStream.Core
{
    /// <summary>
    /// Client which hosts stream to Twitter
    /// </summary>
    internal interface IClient
    {
        /// <summary>
        /// Create the Twitter Client based on passed credentials
        /// </summary>
        /// <param name="creds">Credentials for access to the stream</param>
        /// <returns>TwitterClient object which will host the stream</returns>
        TwitterClient CreateClient(ICredentials creds);
    }
}
