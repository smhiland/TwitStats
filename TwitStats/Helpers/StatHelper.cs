using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using TwitStats.Core;

namespace TwitStats.Helpers
{
    /// <summary>
    /// Helper class to process data
    /// </summary>
    internal static class StatHelper
    {
        public static string UrlRegex = @"(http|ftp|https):\/\/([\w\-_]+(?:(?:\.[\w\-_]+)+))([\w\-\.,@?^=%&amp;:\/~\+#]*[\w\-\@?^=%&amp;\/~\+#])?";

        /// <summary>
        /// Determine if Data Point contains URL
        /// </summary>
        /// <param name="dataPoints">List of Data Points to inspect</param>
        /// <returns>Strings which contain a URL</returns>
        public static IEnumerable<string> ContainsUrl(IDataPoints dataPoints)
        {
            return dataPoints
                    .AsParallel()
                    .Where(dp => Regex.Match(dp?.Text ?? string.Empty, UrlRegex).Success)
                    .Select(dp => dp.Text)
                    .ToList();
        }

        /// <summary>
        /// Get the URLs from the text
        /// </summary>
        /// <param name="dataPoints">List of Data Points to inspect</param>
        /// <returns>Strings which are the URL</returns>
        public static IEnumerable<string> GetUrls(IDataPoints dataPoints)
        {
            return ContainsUrl(dataPoints)
                        .Select(s => Regex.Match(s, UrlRegex).Value).ToList();

        }

        /// <summary>
        /// Get the Domain from the URL
        /// </summary>
        /// <param name="dataPoints">List of Data Points to inspect</param>
        /// <returns>Strings which are the domain of the URL</returns>
        public static IEnumerable<string> GetDomains(IDataPoints dataPoints)
        {
            return GetUrls(dataPoints)
                        .Select(s => GetDomain(s))
                        .Where(s => !string.IsNullOrWhiteSpace(s))
                        .ToList();
        }

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

        /// <summary>
        /// Get hashtags out of the texts
        /// </summary>
        /// <param name="dataPoints">List of Data Points to inspect</param>
        /// <returns>Strings which are the hashtag strings</returns>
        public static IEnumerable<string> GetHashtags(IDataPoints dataPoints)
        {
            return dataPoints
                    .AsParallel()
                    .Select(dp => (dp?.Text ?? string.Empty).Replace("\n", " ").Split(" "))
                    .SelectMany(s => s)
                    .Where(s => s.Contains("#") && s.Length > 1);
        }
    }
}
