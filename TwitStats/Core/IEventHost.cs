namespace TwitStats.Core
{
    /// <summary>
    /// Manage event handlers
    /// </summary>
    public interface IEventHost
    {
        /// <summary>
        /// Register Event Handler on object
        /// </summary>
        void RegisterEventHandler();

        /// <summary>
        /// Unregister Event Handler on object
        /// </summary>
        void UnRegisterEventHandler();
    }
}
