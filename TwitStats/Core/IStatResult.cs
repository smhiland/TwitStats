namespace TwitStats.Core
{
    public interface IStatResult
    {
        /// <summary>
        /// Description of the result
        /// </summary>
        string Description { get; set; }

        /// <summary>
        /// Value of the result
        /// </summary>
        string Value { get; set; }
    }
}
