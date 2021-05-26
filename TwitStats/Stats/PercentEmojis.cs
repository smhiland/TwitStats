using System.Collections.Generic;
using TwitStats.Core;
using TwitStats.Data;

namespace TwitStats.Stats
{
    /// <summary>
    /// Gather the Percent of Tweets which contain a URL
    /// </summary>
    public class PercentEmojis : MatchStat
    {
        readonly EmojiBase _emojiBase = EmojiBase.GetEmojiBase();

        /// <inheritdoc/>
        public PercentEmojis() : base()
                => Description = "% with Emoji";

        /// <inheritdoc/>
        public PercentEmojis(string description) : base(description) { }

        /// <inheritdoc/>
        protected override IDataPoints GetMatches(Datum statData)
                => statData.Data.Contains(PullMatches);

        /// <inheritdoc/>
        protected override IEnumerable<string> PullMatches(string s)
            => base.PullMatches(_emojiBase.ContainsEmoji(s).Value);

        /// <inheritdoc/>
        protected override string PrintResult(Datum statData)
        {
            int matchCount = GetMatches(statData).Count;

            return $"{matchCount:n0}/{statData.TotalCount:n0} = {(matchCount / (double)statData.TotalCount):p2}";
        }
    }
}
