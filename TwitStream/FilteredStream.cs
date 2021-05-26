using System.Threading.Tasks;
using Tweetinvi.Streaming.V2;

namespace TwitStream
{
    using TwitStream.Core;

    /// <summary>
    /// Filtered Stream Concrete class
    /// Inherits from Stream Concrete class
    /// </summary>
    internal class FilteredStream : Stream, IFilteredStream
    {
        private IFilteredStreamV2 _stream;

        /// <inheritdoc/>
        public string Filter { get; set; }

        public FilteredStream(string filter) => Filter = filter;

        protected override bool IsStreamNull()
        {
            return _stream is null;
        }

        protected override void SetStream()
        {
            _client.StreamsV2.AddRulesToFilteredStreamAsync(new Tweetinvi.Parameters.V2.FilteredStreamRuleConfig(Filter)).ConfigureAwait(false).GetAwaiter();
            _stream = _client.StreamsV2.CreateFilteredStream();
        }

        protected override Task StartStreamAsync()
        {
            return _stream.StartAsync();
        }

        protected override void StopStream()
        {
            _stream.StopStream();
        }

        /// <summary>
        /// Process the incoming Tweet
        /// </summary>
        /// <param name="sender">Caller of method</param>
        /// <param name="e">Stream event arguments</param>
        private void Stream_TweetReceived(object sender, Tweetinvi.Events.V2.FilteredStreamTweetV2EventArgs e) => RaiseEvent(e);

        /// <inheritdoc/>
        public override void RegisterEventHandler()
        {
            _stream.TweetReceived += Stream_TweetReceived;
        }

        /// <inheritdoc/>
        public override void UnRegisterEventHandler()
        {
            _stream.TweetReceived -= Stream_TweetReceived;
        }
    }
}
