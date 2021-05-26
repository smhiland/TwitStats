using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using TwitStats.Core;
using TwitStats.Data;

namespace TwitStats.Stats
{
    /// <summary>
    /// Gather the Top Hashtags found in Data
    /// </summary>
    public class TopHashtags : TopStats
    {
        protected string RegexFilter { get => @"#(\w*)?"; }

        /// <inheritdoc/>
        public TopHashtags() : base() => Description = "Top Hashtags";

        /// <inheritdoc/>
        public TopHashtags(string description) : base(description) { }

        /// <inheritdoc/>
        public TopHashtags(string description, int topCount = 3) : base(description, topCount) { }

        /// <inheritdoc/>
        protected override IEnumerable<string> PullMatches(string s)
            => Regex.Matches(s ?? string.Empty, RegexFilter)
                    .Select(m => m.Value);

        /// <inheritdoc/>
        protected override IDataPoints GetMatches(Datum statData)
            => statData.Data.GetMatches(PullMatches);
    }
}
