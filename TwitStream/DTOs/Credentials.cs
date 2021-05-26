using TwitStream.Core;

namespace TwitStream.DTOs
{
    internal class Credentials : ICredentials
    {
        /// <inheritdoc/>
        public string Key { get; set; }

        /// <inheritdoc/>
        public string Secret { get; set; }

        /// <inheritdoc/>
        public string BearerToken { get; set; }
    }
}
