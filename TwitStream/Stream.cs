using System;
using System.Threading.Tasks;
using Tweetinvi;
using Tweetinvi.Events.V2;

namespace TwitStream
{
    using TwitStream.Core;

    /// <summary>
    /// Stream Concrete class
    /// </summary>
    internal abstract class Stream : IStream
    {

        protected TwitterClient _client;

        public event EventHandler<ITweet> TweetReceived = delegate { };


        public event EventHandler<Exception> ErrorReceived = delegate { };

        public Stream() { }

        protected abstract bool IsStreamNull();
        protected abstract void SetStream();
        protected abstract Task StartStreamAsync();
        protected abstract void StopStream();

        /// <summary>
        /// Validate the Client was provided
        /// </summary>
        /// <returns>True or throws exception</returns>
        protected bool ValidateClient()
        {
            if (_client is null)
            {
                throw new ArgumentNullException("A Client must be defined.");
            }

            return true;
        }

        /// <summary>
        /// Validate the Stream was provided
        /// </summary>
        /// <returns>True or throws exception</returns>
        protected bool ValidateStream()
        {
            if (IsStreamNull())
            {
                throw new ArgumentNullException("A Stream must be defined.");
            }

            return true;
        }

        /// <inheritdoc/>
        public IStream SetClient(TwitterClient client)
        {
            _client = client;
            ValidateClient();

            return this;
        }

        /// <inheritdoc/>
        public virtual IStream CreateStream()
        {
            ValidateClient();
            SetStream();
            RegisterEventHandler();

            return this;
        }

        /// <inheritdoc/>
        public Task StartAsync()
        {
            ValidateStream();
            return StartStreamAsync();
        }

        /// <inheritdoc/>
        public void Stop() => StopStream();

        /// <summary>
        /// Raise the event to process received tweet
        /// </summary>
        /// <param name="e">Tweet event arguments</param>
        protected void RaiseEvent(TweetV2EventArgs e)
        {
            if (e.Tweet is null)
            {
                // Raise error event
                ErrorReceived(this, new Exception("No Tweet returned. Confirm Client Credentials."));

                return;
            }


            TweetReceived(this, new DTOs.Tweet()
               {
                   Id = e.Tweet.Id,
                   AuthorId = e.Tweet.AuthorId,
                   CreatedAt = e.Tweet.CreatedAt,
                   Lang = e.Tweet.Lang,
                   Text = e.Tweet.Text
               });
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            Stop();
            UnRegisterEventHandler();
            _client = null;
        }

        /// <inheritdoc/>
        public abstract void RegisterEventHandler();

        /// <inheritdoc/>
        public abstract void UnRegisterEventHandler();
    }
}
