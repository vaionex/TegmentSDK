using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace Tegment.Logs
{
    public static partial class LogManager 
    {
        /// <summary>
        /// Write log to file
        /// </summary>
        /// <param name="logString"></param>
        public static void WriteToLog(string logString)
        {
            TextWriter tw = new StreamWriter(Application.dataPath+"/logfile.txt",true);
            tw.WriteLine("[ "+System.DateTime.Now+" ] "+logString);
            tw.Close();
        }
    }
}
