using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using SortNames.Interfaces;

namespace SortNames.Classes
{
    /// <summary>
    /// Class that implements methods to sort and store a list of names.
    /// </summary>
    internal class NameManager : INameManager
    { 
        /// <inheritDoc/>
        public IList<Name> GetNamesFromFile(string file, ILogger logger)
        {
            IList<Name> result = new List<Name>();
            StreamReader reader = null;

            try
            {
                reader = new StreamReader(file);
                string strline;

                while ((strline = reader.ReadLine()) != null)
                {
                    var values = strline.Split(',').Select(p => p.Trim()).ToList();
                    var name = new Name
                    {
                        LastName = values[0],
                        FirstName = values[1]
                    };

                    result.Add(name);

                    logger.WriteLog("Name: " + name.LastName + ", " + name.FirstName +
                                    " successfully read from file.");
                }
            }
            catch (Exception exception)
            {
                logger.WriteLog("An exception occurred in method 'GetNamesFromFile'. ", exception);
                throw;
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
            }

            return result;
        }

        /// <inheritDoc/>
        public void SetNamesToFile(IList<Name> nameList, string file, ILogger logger)
        {
            StreamWriter writer = null;

            try
            {
                if (File.Exists(file))
                {
                    File.Delete(file);
                    logger.WriteLog("A previous file named '" + file + "' already existed and it was deleted.");
                }

                writer = File.CreateText(file);

                foreach (var name in nameList)
                {
                    writer.WriteLine(name.LastName + ", " + name.FirstName);
                    logger.WriteLog("Name: " + name.LastName + ", " + name.FirstName + " successfully written to file.");
                }

                writer.Close();
            }
            catch (Exception exception)
            {
                logger.WriteLog("An exception occurred in method 'SetNamesToFile'. ", exception);
                throw;
            }
            finally
            {
                if (writer != null)
                {
                    writer.Close();
                }
            }
        }

        /// <inheritDoc/>
        public IList<Name> SortNames(IList<Name> nameList, ILogger logger)
        {
            IList<Name> result = new List<Name>();

            try
            {
                result = nameList.OrderBy(x => x.LastName).ThenBy(y => y.FirstName).ToList();
            }
            catch (Exception exception)
            {
                logger.WriteLog("An exception occurred in method 'SortNames'. ", exception);
                throw;
            }

            return result;
        }
    }
}