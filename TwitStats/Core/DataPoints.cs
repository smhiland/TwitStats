using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TwitStats.DTO;

namespace TwitStats.Core
{
    internal class DataPoints : IDataPoints
    {

        readonly List<IDataPoint> _dataPoints;

        public DataPoints()
            => _dataPoints = new();

        public DataPoints(IList<IDataPoint> dataPoints)
            =>_dataPoints = dataPoints is null ? new() : new(dataPoints);

        /// <inheritdoc/>
        public void Add(IDataPoint dataPoint)
            => _dataPoints.Add(dataPoint);

        /// <inheritdoc/>
        public IEnumerator<IDataPoint> GetEnumerator()
            => _dataPoints.GetEnumerator();

        /// <inheritdoc/>
        IEnumerator IEnumerable.GetEnumerator()
            => _dataPoints.GetEnumerator();

        /// <inheritdoc/>
        public void Clear()
            => _dataPoints.Clear();

        /// <inheritdoc/>
        public int Count { get => _dataPoints?.Count ?? 0; }

        /// <inheritdoc/>
        public IDataPoints GetMatches(Func<string, IEnumerable<string>> testFunc)
            => ParseStrings(_dataPoints
                        .AsParallel()
                        .Select(dp => testFunc(dp?.Text))
                        .SelectMany(s => s)
                );

        /// <inheritdoc/>
        public IDataPoints Contains(Func<string, IEnumerable<string>> testFunc)
            => new DataPoints(_dataPoints
                        .AsParallel()
                        .Where(dp => testFunc(dp?.Text).Count() > 0)
                        .ToList()
                );

        /// <inheritdoc/>
        public IDataPoints GetMatchingWords(Func<string, bool> testFunc)
            => ParseStrings(_dataPoints
                        .AsParallel()
                        .Select(dp => (dp?.Text ?? string.Empty).Replace("\n", " ").Split(" "))
                        .SelectMany(s => s)
                        .Where(s => testFunc(s))
                );

        /// <inheritdoc/>
        public IDataPoints Frequency()
            => new DataPoints(_dataPoints
                        .AsParallel()
                        .GroupBy(s => s.Text)
                        .Select(g => new { count = g.Count(), text = g.Key })
                        .OrderByDescending(g => g.count)
                        .Select(g => new DataPoint(g.text) as IDataPoint)
                        .ToList()
                );

        /// <summary>
        /// Parse the list of strings into a IDataPoints object
        /// </summary>
        /// <param name="strings">List of strings</param>
        /// <returns>IDataPoints object of the strings</returns>
        public static IDataPoints ParseStrings(IEnumerable<string> strings)
            => new DataPoints(strings.Select(s => new DataPoint(s) as IDataPoint).ToList());
    }
}
