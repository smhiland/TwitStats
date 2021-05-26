using System;
using System.Collections.Generic;
using System.Linq;
using TwitStats.Core;
using TwitStats.DTO;

namespace TwitStats.Helpers
{
    /// <summary>
    /// Helper class to process data
    /// </summary>
    internal static class UrlHelper
    {
        /// <summary>
        /// URL RegEx filter string
        /// </summary>
        public static string UrlRegexFilter => @"(http|ftp|https):\/\/([\w\-_]+(?:(?:\.[\w\-_]+)+))([\w\-\.,@?^=%&amp;:\/~\+#]*[\w\-\@?^=%&amp;\/~\+#])?";

        /// <summary>
        /// Get URLs from the text of the data points
        /// </summary>
        /// <param name="dataPoints">Data Points to inspect</param>
        /// <returns>List of DataPoints with a URL in the text</returns>
        public static IDataPoints GetUrls(IDataPoints dataPoints, Func<string, IEnumerable<string>> matchFunc)
                => DataPoints.ParseStrings(dataPoints.Select(s => matchFunc(s?.Text))
                            .SelectMany(s => s));

        /// <summary>
        /// Get the Domain from the URL
        /// </summary>
        /// <param name="dataPoints">List of Data Points to inspect</param>
        /// <returns>Strings which are the domain of the URL</returns>
        public static IEnumerable<string> GetDomains(IDataPoints dataPoints, Func<string, IEnumerable<string>> matchFunc)
            => GetUrls(dataPoints, matchFunc)
                        .Select(s => GetDomain(s.Text))
                        .Where(s => !string.IsNullOrWhiteSpace(s))
                        .ToList();

        /// <summary>
        /// Get the Domain from the URL
        /// </summary>
        /// <param name="url">URL to inspect</param>
        /// <returns>Domain of the URL, empty if not a good URL</returns>
        public static string GetDomain(string url)
        {
            if (!string.IsNullOrWhiteSpace(url) && Uri.TryCreate(url, UriKind.RelativeOrAbsolute, out Uri uri))
            {
                try
                {
                    return uri.Host;
                }
                catch
                {
                    return string.Empty;
                }
            }
            return string.Empty;
        }
    }
}
