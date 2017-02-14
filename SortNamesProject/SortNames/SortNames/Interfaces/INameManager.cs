using System.Collections.Generic;
using SortNames.Classes;

namespace SortNames.Interfaces
{
    /// <summary>
    /// Interface that specifies methods to handle name sorting and storing.
    /// </summary>
    interface INameManager
    {
        /// <summary>
        /// Gets the list of names that are in the "file".
        /// </summary>
        /// <param name="file">File that contains the names.</param>
        /// <param name="logger">Instance of the logger to write events of the application.</param>
        /// <returns>List of names from the file.</returns>
        IList<Name> GetNamesFromFile(string file, ILogger logger);

        /// <summary>
        /// Stores a list of names to the speficy file.
        /// </summary>
        /// <param name="nameList">List of names to be stored.</param>
        /// <param name="file">File where the list of names will be stored.</param>
        /// <param name="logger">Instance of the logger to write events of the application.</param>
        void SetNamesToFile(IList<Name> nameList, string file, ILogger logger);

        /// <summary>
        /// Sorts the names by last name followed by first name.
        /// </summary>
        /// <param name="nameList">List of names to be sorted.</param>
        /// <param name="logger">Instance of the logger to write events of the application.</param>
        /// <returns>Returns a sorted list of names.</returns>
        IList<Name> SortNames(IList<Name> nameList, ILogger logger);
    }
}
