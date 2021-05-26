using TwitStats.Core;
using TwitStats.Stats;

namespace TwitStats.Data
{
    /// <inheritdoc/>
    public struct Datum : IData
    {
        public long TotalCount;
        public IDataPoints Data;

        /// <inheritdoc/>
        public void SetDefault()
        {
            TotalCount = 0;
            Data = new DataPoints();
        }
    }
}
