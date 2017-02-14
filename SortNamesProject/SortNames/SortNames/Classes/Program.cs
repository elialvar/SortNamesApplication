using System;
using System.Collections.Generic;
using System.IO;
using SortNames.Interfaces;

namespace SortNames.Classes
{
    class Program
    {
        /// <summary>
        /// File name where the sorted name list will be stored.
        /// </summary>
        const string OutputFileName = "sortedName.txt";

        /// <summary>
        /// File name where the events of the application will be stored.
        /// </summary>
        const string LogFileName = "LogFile";
        
        static void Main(string[] args)
        {
            Logger.Initialize(LogFileName);
            ILogger logger = Logger.Instance;

            INameManager nameManager = new NameManager();

            while (true) // Loop indefinitely
            {
                Console.WriteLine("**************************");
                Console.WriteLine("");

                Console.WriteLine("Enter file name:");
                string fileName = Console.ReadLine();

                if (!File.Exists(fileName))
                {
                    Console.WriteLine("The file '" + fileName + "' does not exist.");
                }
                else
                {
                    try
                    {
                        IList<Name> originalNameList = nameManager.GetNamesFromFile(fileName, logger);
                        IList<Name> sortedNameList = nameManager.SortNames(originalNameList, logger);
                        nameManager.SetNamesToFile(sortedNameList, OutputFileName, logger);

                        Console.WriteLine("Finished: created " + OutputFileName);
                    }
                    catch
                    {
                        Console.WriteLine("An error occurred while processing the name list. Please, check the log file for more information.");
                    }
                }

                Console.WriteLine("");
                Console.WriteLine("");
            }
        }
    }
}
