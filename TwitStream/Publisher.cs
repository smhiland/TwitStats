using System;
using System.Threading.Tasks;
using TwitStream.Core;

namespace TwitStream
{
    /// <summary>
    /// Publisher of Tweets from the provided Stream
    /// </summary>
    internal class Publisher : IPublisher, IDisposable
    {
        public event EventHandler<ITweet> TweetReceived = delegate { };

        public event EventHandler<Exception> ErrorReceived = delegate { };

        private readonly IStream _stream;

        public Publisher(IStream stream)
        {
            if (stream is null)
            {
                throw new ArgumentNullException(nameof(stream));
            }

            _stream = stream;
            RegisterEventHandler();
        }

        /// <inheritdoc/>
        public Task StartAsync()
        {
            // Start listening to feed
            return _stream.StartAsync();
        }

        /// <inheritdoc/>
        public void Stop()
        {
            // Stop listening to feed
            _stream.Stop();
        }

        /// <summary>
        /// Process the incoming Tweet
        /// </summary>
        /// <param name="sender">Caller of method</param>
        /// <param name="e">Tweet data received from Stream</param>
        private void Stream_TweetReceived(object sender, ITweet e) => TweetReceived(this, e);

        /// <summary>
        /// Process the incoming error
        /// </summary>
        /// <param name="sender">Caller of method</param>
        /// <param name="e">Exception data received</param>
        private void Stream_ErrorReceived(object sender, Exception e) => ErrorReceived(this, e);

        /// <inheritdoc/>
        public void Dispose()
        {
            Stop();
            UnRegisterEventHandler();
            _stream.Dispose();
        }

        /// <inheritdoc/>
        public virtual void RegisterEventHandler()
        {
            _stream.TweetReceived += Stream_TweetReceived;
            _stream.ErrorReceived += Stream_ErrorReceived;
        }

        /// <inheritdoc/>
        public virtual void UnRegisterEventHandler()
        {
            _stream.TweetReceived -= Stream_TweetReceived;
            _stream.ErrorReceived -= Stream_ErrorReceived;
        }
    }
}
