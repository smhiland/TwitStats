using System.Collections.Generic;
using TwitStats.Core;
using TwitStats.Data;

namespace TwitStats.Stats
{
    /// <summary>
    /// Gather the Top Emojis found in Data
    /// </summary>
    public class TopEmojis : TopStats
    {
        readonly EmojiBase _emojiBase = EmojiBase.GetEmojiBase();

        /// <inheritdoc/>
        public TopEmojis() : base() 
            => Description = "Top Emojis";

        /// <inheritdoc/>
        public TopEmojis(string description) : base(description) { }

        /// <inheritdoc/>
        public TopEmojis(string description, int topCount = 3) : base(description, topCount) { }

        /// <inheritdoc/>
        protected override IDataPoints GetMatches(Datum statData)
            => statData.Data.GetMatches(PullMatches);

        /// <inheritdoc/>
        protected override IEnumerable<string> PullMatches(string dataPoint)
            => _emojiBase.GetEmojis(dataPoint);
    }
}
