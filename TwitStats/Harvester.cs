using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using TwitStats.Core;
using TwitStats.DTO;
using TwitStream;
using TwitStream.Core;

namespace TwitStats
{
    /// <summary>
    /// Harvester object to gather data and pass along to Stats it is following
    /// </summary>
    public class Harvester : IHarvester
    {
        readonly IList<IStat> _stats;
        readonly IPublisher _publisher;

        public Harvester(ICredentials creds)
        {
            PublisherBuilder publisherBuilder = new(creds);
            _publisher = publisherBuilder.BuildPublisher();

            RegisterEventHandler();

            _stats = new List<IStat>();
        }

        /// <inheritdoc/>
        public IHarvester RegisterStat(IStat stat)
        {
            if (!_stats.Contains(stat))
            {
                _stats.Add(stat);
            }

            return this;
        }

        /// <inheritdoc/>
        public IHarvester UnRegisterStat(IStat stat)
        {
            if (_stats.Contains(stat))
            {
                _stats.Remove(stat);
            }

            return this;
        }

        /// <inheritdoc/>
        public void Start()
        {
            _publisher.StartAsync();
        }

        /// <inheritdoc/>
        public void Stop()
        {
            _publisher.Stop();
        }

        /// <summary>
        /// Event handler for Data received
        /// </summary>
        /// <param name="sender">Caller of method</param>
        /// <param name="e">Tweet received</param>
        private void Publisher_TweetReceived(object sender, ITweet e)
        {
#if DEBUG
            if (!e.Lang.Contains("en")) return;
#endif

            IDataPoint dp = new DataPoint(e.Text);
            foreach(IStat stat in _stats)
            {
                // Throw the tweet text at the stat object
                // Fire and forget
                // Possible issues here
                // If stat object encounters an error and the tweet
                // is not actually gathered, stat would be off
                Task.Run(() => stat.Gather(dp));
            }
        }

        private void Publisher_ErrorReceived(object sender, Exception e)
        {
            Stop();
            throw e;
        }

        /// <inheritdoc/>
        public string GetStatResult(IStat stat) => stat.ToString();

        /// <inheritdoc/>
        public string GetStatsResults()
        {
            StringWriter sw = new();
            foreach(IStat stat in _stats)
            {
                sw.WriteLine(GetStatResult(stat));
            }

            return sw.ToString();
        }

        /// <inheritdoc/>
        public void Reset(IStat stat) => stat.Reset();

        /// <inheritdoc/>
        public void Reset()
        {
            foreach (IStat stat in _stats)
            {
                Reset(stat);
            }
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            GC.SuppressFinalize(this);
            Stop();
            UnRegisterEventHandler();
            _publisher.Dispose();

            foreach(IStat stat in _stats)
            {
                stat.Dispose();
            }
            _stats.Clear();
        }

        /// <inheritdoc/>
        public virtual void RegisterEventHandler()
        {
            _publisher.TweetReceived += Publisher_TweetReceived;
            _publisher.ErrorReceived += Publisher_ErrorReceived;
        }

        /// <inheritdoc/>
        public virtual void UnRegisterEventHandler()
        {
            _publisher.TweetReceived -= Publisher_TweetReceived;
            _publisher.ErrorReceived -= Publisher_ErrorReceived;
        }
    }
}
