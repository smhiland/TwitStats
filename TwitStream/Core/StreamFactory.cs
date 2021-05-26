namespace TwitStream.Core
{
    /// <summary>
    /// Stream Factory - creates Stream based on parameters
    /// </summary>
    internal class StreamFactory
    {
        /// <summary>
        /// Create a Twitter Stream
        /// </summary>
        /// <param name="filter">Optional filter string to filter tweets received from the stream</param>
        /// <returns>IStream representing the Twitter Stream</returns>
        public static IStream CreateStream(string filter = null)
        {
            IStream rtn;

            if (string.IsNullOrWhiteSpace(filter))
            {
                // We will create a regular Stream as we are not filtering
                rtn = new SampleStream();
            }
            else
            {
                // We will create a filtered stream
                rtn = new FilteredStream(filter);
            }

            return rtn;
        }
    }
}
