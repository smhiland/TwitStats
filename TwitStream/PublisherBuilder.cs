using TwitStream.Core;

namespace TwitStream
{
    /// <summary>
    /// Publisher Builder - builds Publisher based on parameters
    /// </summary>
    public class PublisherBuilder
    {
        readonly ICredentials _creds;
        readonly string _filter;

        public PublisherBuilder(ICredentials creds, string filter = null)
        {
            _creds = creds;
            _filter = filter;
        }

        /// <inheritdoc/>
        public IPublisher BuildPublisher()
        {
            StreamBuilder streamBuilder = new(_creds, _filter);

            return new Publisher(streamBuilder.BuildStream());
        }
    }
}
