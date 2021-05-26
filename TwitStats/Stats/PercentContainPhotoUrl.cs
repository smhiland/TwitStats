using System.Collections.Generic;
using System.Linq;
using TwitStats.Core;
using TwitStats.Data;
using TwitStats.Helpers;

namespace TwitStats.Stats
{
    /// <summary>
    /// Gather the Percent of Data which contain a Photo URL
    /// </summary>
    public class PercentContainPhotoUrl : PercentContainUrl
    {

        /// <summary>
        /// Domains watching for in URLs
        /// </summary>
        readonly IEnumerable<string> _photoDomains = new List<string>() { "pic.twitter.com", "instagram.com", "pbs.twimg.com", "t.co" };

        /// <inheritdoc/>
        public PercentContainPhotoUrl() : base()
                => Description = "% with Photo URL";

        /// <inheritdoc/>
        public PercentContainPhotoUrl(string description) : base(description) { }

        /// <inheritdoc/>
        public PercentContainPhotoUrl(string description, IEnumerable<string> photoDomains = null) : this(description)
        {
            if (photoDomains is not null)
            {
                _photoDomains = photoDomains;
            }
        }

        /// <inheritdoc/>
        protected override IDataPoints GetMatches(Datum statData)
            => DataPoints.ParseStrings(UrlHelper.GetDomains(statData.Data, PullMatches)
                        .Where(url => ContainsPhotoDomain(url ?? string.Empty)));

        /// <summary>
        /// Determine if the URL is from one of the watched domains
        /// </summary>
        /// <param name="url">URL to inspect</param>
        /// <returns>Flag if URL is from a watched domain</returns>
        private bool ContainsPhotoDomain(string url)
                => _photoDomains.Any(url.Contains);
    }
}
