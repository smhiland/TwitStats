namespace TwitStream.Core
{
    /// <summary>
    /// Stream Builder - builds Stream based on parameters
    /// </summary>
    internal class StreamBuilder
    {
        private readonly IStream _stream;
        private readonly ICredentials _creds;

        public StreamBuilder(ICredentials creds, string filter = null)
        {
            _creds = creds;
            _stream = StreamFactory.CreateStream(filter);
        }

        /// <summary>
        /// Build the Stream
        /// </summary>
        /// <returns>Built Stream</returns>
        public IStream BuildStream()
        {
            IClient client = new Client();
            _stream.SetClient(client.CreateClient(_creds));

            return _stream.CreateStream();
        }
    }
}
