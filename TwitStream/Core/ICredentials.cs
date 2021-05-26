namespace TwitStream.Core
{
    /// <summary>
    /// Credentials used for access
    /// </summary>
    public interface ICredentials
    {
        /// <summary>
        /// API Key
        /// </summary>
        string Key { get; set; }

        /// <summary>
        /// API Secret
        /// </summary>
        string Secret { get; set; }

        /// <summary>
        /// API Bearer Token
        /// </summary>
        string BearerToken { get; set; }
    }
}
