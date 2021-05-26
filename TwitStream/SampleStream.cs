using System.Threading.Tasks;
using Tweetinvi.Events.V2;
using Tweetinvi.Streaming.V2;

namespace TwitStream
{

    /// <summary>
    /// Stream Concrete class
    /// </summary>
    internal class SampleStream : Stream
    {
        private ISampleStreamV2 _stream;

        protected override bool IsStreamNull()
        {
            return _stream is null;
        }

        protected override void SetStream()
        {
            _stream = _client.StreamsV2.CreateSampleStream();
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
        private void Stream_TweetReceived(object sender, TweetV2ReceivedEventArgs e) => RaiseEvent(e);

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
