namespace TwitStream.Core
{
    /// <summary>
    /// Interface for Filtered Stream
    /// </summary>
    internal interface IFilteredStream
    {
        /// <summary>
        /// Filter string for the stream
        /// </summary>
        string Filter { get; set; }
    }
}
