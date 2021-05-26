using System;

namespace TwitStats.Data
{
    /// <inheritdoc/>
    public struct AverageStatBaseData : IData
    {
        public long TotalCount;
        public DateTime? StartDateTime;

        /// <inheritdoc/>
        public void SetDefault()
        {
            TotalCount = 0;
            StartDateTime = null;
        }
    }
}
