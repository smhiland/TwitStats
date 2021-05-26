using System;
using Tweetinvi;
using Tweetinvi.Models;

namespace TwitStream.Core
{
    /// <inheritdoc/>
    internal class Client : IClient
    {
        // Current implementation could be a static class with a static method
        // However, left as is to keep open for future changes
        // This is an object which could be expanded

        /// <inheritdoc/>
        public TwitterClient CreateClient(ICredentials creds)
        {
            if (string.IsNullOrWhiteSpace(creds?.Key)
                    || string.IsNullOrWhiteSpace(creds?.Secret)
                    || string.IsNullOrWhiteSpace(creds?.BearerToken))
            {
                throw new ArgumentNullException(nameof(creds));
            }

            return new(new ConsumerOnlyCredentials(creds.Key, creds.Secret)
                {
                    BearerToken = creds.BearerToken
                });
        }
    }
}
