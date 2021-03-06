// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;

namespace Microsoft.AppCenter.Channel
{
    /// <summary>
    /// Represents a collection of channels that can perform aggregate operations
    /// </summary>
    public interface IChannelGroup : IChannel
    {
        /// <summary>
        /// Adds an IChannelUnit to the group. This transfers ownership of the IChannelUnit to IChannelGroup.
        /// </summary>
        /// <param name="channel">The ChannelUnit to add</param>
        void AddChannel(IChannelUnit channel);

       /// <summary>
       /// Adds an IChannelUnit to the group.
       /// </summary>
       /// <param name="name">The name of the ChannelUnit</param>
       /// <param name="maxLogsPerBatch">The maximum batch size for the ChannelUnit</param>
       /// <param name="batchTimeInterval">The maximum time interval between batches</param>
       /// <param name="maxParallelBatches">The maximum number of batches to be processed in parallel</param>
       /// <returns>The created IChannelUnit</returns>
        IChannelUnit AddChannel(string name, int maxLogsPerBatch, TimeSpan batchTimeInterval, int maxParallelBatches);

        /// <summary>
        /// Sets the ingestion endpoint to send App Center logs to.
        /// </summary>
        /// <param name="logUrl">The log URL</param>
        void SetLogUrl(string logUrl);

        /// <summary>
        /// Waits for any running storage operations to complete.
        /// </summary>
        Task WaitStorageOperationsAsync();

        /// <summary>
        /// Set the maximum size of the storage.
        /// </summary>
        /// <param name="sizeInBytes">
        /// Maximum size of the storage in bytes. This will be rounded up to the nearest multiple of a SQLite page size (default is 4096 bytes).
        /// Values below 20,480 bytes (20 KiB) will be ignored.
        /// </param>
        /// <returns><code>true</code> if changing the size was successful.</returns>
        Task<bool> SetMaxStorageSizeAsync(long sizeInBytes);
    }
}
