using System;
using System.Collections.Generic;
using System.Threading;

namespace TwitStats.Core
{
    /// <summary>
    /// Base class for Stats'
    /// </summary>
    /// <typeparam name="T">Base Data type of the Stat</typeparam>
    public abstract class Stat<T> : IStat
    {
        readonly ReaderWriterLockSlim _readerWriterLockSlim = new();

        protected T _baseData;

        /// <inheritdoc/>
        public string Description { get; set; }

        /// <summary>
        /// Set the base data by the passed Data Point
        /// </summary>
        /// <param name="dataPoint">Data Point gathered</param>
        protected abstract void SetBaseData(IDataPoint dataPoint);

        /// <summary>
        /// Reset the base data to start fresh
        /// </summary>
        protected abstract void ResetBaseData();

        /// <summary>
        /// Results of the Stat based on the data points received
        /// </summary>
        /// <param name="statData">Base data of the state to process</param>
        /// <returns>String representation of the stats' result</returns>
        protected abstract string ResultsToString(T statData);

        /// <summary>
        /// Get the results for the stat
        /// </summary>
        /// <param name="statData">Backing data for Stat</param>
        /// <returns>
        /// New collection of results
        /// </returns>
        protected abstract IEnumerable<IStatResult> ReportStatResults(T statData);

        /// <inheritdoc/>
        public override string ToString() => $"{Description}: {Results()}";

        public Stat() { }

        public Stat(string description) : this() => Description = string.IsNullOrWhiteSpace(description) ? Description : description;

        /// <summary>
        /// Get the results of the stat
        /// </summary>
        /// <returns>List of results</returns>
        public IEnumerable<IStatResult> GetResults()
        {
            T results;
            _readerWriterLockSlim.EnterReadLock();
            try
            {
                results = _baseData;
            }
            finally
            {
                _readerWriterLockSlim.ExitReadLock();
            }

            return ReportStatResults(results);

        }

        /// <inheritdoc/>
        protected string Results()
        {
            T results;
            _readerWriterLockSlim.EnterReadLock();
            try
            {
                results = _baseData;
            }
            finally
            {
                _readerWriterLockSlim.ExitReadLock();
            }

            return ResultsToString(results);

        }

        /// <inheritdoc/>
        public void Gather(IDataPoint dataPoint)
        {
            _readerWriterLockSlim.EnterWriteLock();

            try
            {
                SetBaseData(dataPoint);
            }
            finally
            {
                _readerWriterLockSlim.ExitWriteLock();
            }
        }

        /// <inheritdoc/>
        public void Reset()
        {
            _readerWriterLockSlim.EnterWriteLock();

            try
            {
                ResetBaseData();
            }
            finally
            {
                _readerWriterLockSlim.ExitWriteLock();
            }
        }

        /// <inheritdoc/>
        public virtual void Dispose()
        {
            GC.SuppressFinalize(this);
            _readerWriterLockSlim.Dispose();
        }
    }
}
