using TwitStats.Core;

namespace TwitStats.DTO
{
    /// <inheritdoc/>
    public struct DataPoint : IDataPoint
    {
        /// <inheritdoc/>
        public string Text { get; set; }

        public DataPoint(string text) => Text = text;
    }
}
