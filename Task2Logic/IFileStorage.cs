using System;
using System.Collections.Generic;

namespace Task2Logic
{
    /// <summary>
    /// Provides functionality for work with a file storage.
    /// </summary>
    /// <typeparam name="T"> Type of files in the storage</typeparam>
    public interface IFileStorage<T>
    {
        /// <summary>
        /// Loads files from storage.
        /// </summary>
        /// <returns> IEnumerable containing files</returns>
        IEnumerable<T> Load();

        /// <summary>
        /// Saves IEnumerable containing files to storage.
        /// </summary>
        /// <param name="files"> IEnumerable containing files</param>
        void Save(IEnumerable<T> files);
    }
}
