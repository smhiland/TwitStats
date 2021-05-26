using System;
using TwitStream.Core;

namespace TwitStream.DTOs
{
    /// <summary>
    /// Tweet DTO
    /// </summary>
    internal struct Tweet : ITweet
    {
        /// <inheritdoc/>
        public string Id { get; set; }

        /// <inheritdoc/>
        public DateTimeOffset CreatedAt { get; set; }

        /// <inheritdoc/>
        public string AuthorId { get; set; }

        /// <inheritdoc/>
        public string Text { get; set; }

        /// <inheritdoc/>
        public string Lang { get; set; }
    }
}
