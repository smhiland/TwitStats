using System.Threading.Tasks;

namespace TwitStream.Core
{
    /// <summary>
    /// Interface to monitor events/stream
    /// </summary>
    public interface IMonitor
    {
        /// <summary>
        /// Start monitoring
        /// </summary>
        /// <returns>Task representing work</returns>
        Task StartAsync();

        /// <summary>
        /// Stop monitoring
        /// </summary>
        void Stop();
    }
}
