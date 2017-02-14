using System;
using System.IO;
using SortNames.Interfaces;

namespace SortNames.Classes
{
    /// <summary>
    /// Class that logs the events of the application to a file.
    /// </summary>
    internal class Logger : ILogger
    {
        private static Logger _mInstance;
        private static TextWriter _mWriter;

        /// <summary>
        /// Returns the instance of the logger.
        /// </summary>
        internal static Logger Instance => _mInstance;

        internal Logger()
        {
            _mInstance = this;
        }
       
        /// <inheritDoc/>
        internal static void Initialize(string file)
        {
            if (_mInstance == null)
            {
                _mInstance = new Logger();
            }
            
            string fOutput = file + "_" + DateTime.Now.ToString("yyyy-MM-dd_HH_mm_ss") + ".log";

            if (!File.Exists(file + fOutput))
            {
                _mWriter = TextWriter.Synchronized(new StreamWriter(fOutput, true));
            }
            else
            {
                _mWriter = TextWriter.Synchronized(File.AppendText(fOutput));
            }
        }
        
        /// <inheritDoc/>
        public void WriteLog(string trace)
        {
            WriteTrace(trace);
        }

        /// <inheritDoc/>
        public void WriteLog(string trace, Exception ex)
        {
            string str = trace;
            if (ex != null)
            {
                str = str + ": " + ex.Message;
                if (ex.InnerException != null)
                {
                    str = str + Environment.NewLine + "        " + ex.InnerException.Message;
                }
            }
            WriteTrace(str);
        }

        private void WriteTrace(string trace)
        {
            _mWriter.WriteLine(DateTime.Now + ": " + trace);
                
            _mWriter.Flush();
        }
    }
}
