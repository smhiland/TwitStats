using System;

namespace TwitStream.Core
{
    /// <summary>
    /// Interface for Publisher objects
    /// </summary>
    public interface IPublisher : IEventHandler, IErrorEventHandler, IMonitor, IEventHost, IDisposable
    {
    }
}
