using TwitStats.Core;

namespace TwitStats.DTO
{
    public struct StatResult : IStatResult
    {
        /// <inheritdoc/>
        public string Description { get; set; }

        /// <inheritdoc/>
        public string Value { get; set; }

        public StatResult(string description, string value)
        {
            Description = description;
            Value = value;
        }
    }
}
