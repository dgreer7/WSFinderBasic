using log4net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WSFinderBasic
{
    class WorkstationList
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger
    (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// Will reture Dictionary&lt;string, List&lt;string&gt;&gt; contianing matches to city code provided.
        /// </summary>
        /// <param name="cityCode"></param>
        /// <returns>Dictionary where keys are workstation names matching cityCode and value contains list[I.P, DiskImage, Model, Serial, User, OS Name]</returns>
        public static Dictionary<string, List<string>> StationCityList(string cityCode)
        {
            Dictionary<string, List<string>> listOfMatchingNames, fullListOfNames = new Dictionary<string, List<string>>();

            try
            {
                fullListOfNames = ReadInNameList();
                log.Debug("Pulling full workstaiton list");
            }
            catch (Exception fullnameListFetchFailure) { log.Fatal("Failure when attempting to pull full name list for processing.", fullnameListFetchFailure); }

            try
            {
                listOfMatchingNames = fullListOfNames.Where(d => d.Key.StartsWith(cityCode) && d.Key[3] != 'M' && d.Key[3] != 'S').ToDictionary(d => d.Key, d => d.Value);
                log.Debug(string.Format("Processed LINQ to pull out {0} entries.", cityCode));
                return listOfMatchingNames;
            }
            catch (Exception LINQException) { log.Fatal(string.Format("Error during LINQ to pull out {0} entries.", cityCode), LINQException); }

            return null;
        }
        /// <summary>
        /// Will reture Dictionary&lt;string, List&lt;string&gt;&gt; contianing matches to city code and location code provided.
        /// </summary>
        /// <param name="cityCode"></param>
        /// <param name="locationCode"></param>
        /// <returns>Dictionary where keys are workstation names matching cityCode and location and value contains list[I.P, DiskImage, Model, Serial, User, OS Name]</returns>
        public static Dictionary<string, List<string>> StationCityList(string cityCode, string locationCode)
        {
            Dictionary<string, List<string>> listOfMatchingNames, fullListOfNames = new Dictionary<string, List<string>>();

            try
            {
                fullListOfNames = ReadInNameList();
                log.Debug("Pulling full workstaiton list.");
            }
            catch (Exception fullnameListFetchFailure) { log.Fatal("Failure when attempting to pull full name list for processing.", fullnameListFetchFailure); }

            try
            {
                listOfMatchingNames = fullListOfNames.Where(d => d.Key.StartsWith(cityCode + locationCode)).ToDictionary(d => d.Key, d => d.Value);
                log.Debug(string.Format("Processed LINQ to pull out {0} entries.", cityCode + locationCode));
                return listOfMatchingNames;
            }
            catch (Exception LINQException) { log.Fatal(string.Format("Error during LINQ to pull out {0} entries.", cityCode + locationCode), LINQException); }

            return null;
        }
        /// <summary>
        /// Will read in all entries from PC_name.csv located in the working directory and store them in a Dictionary&lt;string, List&lt;string&gt;&gt;.
        /// </summary>
        /// <returns>Dictionary where keys are workstation names and value contains list[I.P, DiskImage, Model, Serial, User, OS Name]</returns>
        public static Dictionary<string, List<string>> ReadInNameList()
        {
            Dictionary<string, List<string>> listOfNames = new Dictionary<string, List<string>>();

            StreamReader file = null;
            string listLocation = "PC_names.csv";
            log.Info(string.Format("The list location has been set to {0}.", listLocation));
            try { file = new StreamReader(listLocation); }
            catch (Exception readException)
            {
                log.Fatal(string.Format("Exception when loading {0}.", listLocation), readException);
                return null;
            }

            log.Info("Starting workstation list read-in.");
            string line = null;
            //Counter intialized and two lines read in to skip the header and prime the first line.
            uint counter = 1;
            try { line = file.ReadLine(); log.Debug(string.Format("Reading in line {0} of file {1}.", counter, listLocation)); }
            catch { log.Error(string.Format("Unable to read in a line {0} of file {1}", counter, listLocation)); }
            counter++;
            try { line = file.ReadLine(); log.Debug(string.Format("Reading in line {0} of file {1}.", counter, listLocation)); }
            catch { log.Error(string.Format("Unable to read in a line {0} of file {1}.", counter, listLocation)); }

            //While reading in a line from the name list
            while (line != null)
            {
                //split the string into a List
                List<string> valuesFromLine = new List<string>();
                try { valuesFromLine = line.Split(',').ToList(); }
                catch { log.Error(string.Format("Error parsing line {0} of file {1}.", counter, listLocation)); }
                //pull the first field off as workstation name:
                string dictionaryName = valuesFromLine.First();
                //remove the name off the List
                try { valuesFromLine.RemoveAt(0); }
                catch { log.Error(string.Format("Error removing index at line {0} of file {1}.", counter, listLocation)); }
                //Add the name as key and the remaining list as dictionary value
                try { listOfNames.Add(dictionaryName, valuesFromLine); }
                catch (Exception addTodictionaryException) { log.Error(string.Format("Error while adding {0} at line {1} of {2}.", dictionaryName, counter, listLocation), addTodictionaryException); }
                counter++;
                try { line = file.ReadLine(); log.Debug(string.Format("Reading in line {0} of file {1}.", counter, listLocation)); }
                catch { log.Error(string.Format("Unable to read in a line {0} of file {1}.", counter, listLocation)); }
            }
            log.Info("Completed workstation list read-in.");
            return listOfNames;
        }

        public static Dictionary<string, List<string>> ScrubCityListForTR(Dictionary<string, List<string>> fullList, string cityCode)
        {
            Dictionary<string, List<string>> listOfMatchingNames = new Dictionary<string, List<string>>();
            try
            {
                listOfMatchingNames = fullList.Where(d => d.Key.StartsWith(cityCode + "TR")).ToDictionary(d => d.Key, d => d.Value);
                log.Debug(string.Format("Processed LINQ to pull out {0} entries.", cityCode));
                return listOfMatchingNames;
            }
            catch (Exception LINQException) { log.Fatal(string.Format("Error during LINQ to pull out {0} entries.", cityCode), LINQException); }
            return null;
        }

        public static Dictionary<string, List<string>> ScrubCityListForGA(Dictionary<string, List<string>> fullList, string cityCode)
        {
            Dictionary<string, List<string>> listOfMatchingNames = new Dictionary<string, List<string>>();
            try
            {
                listOfMatchingNames = fullList.Where(d => d.Key.StartsWith(cityCode + "GA")).ToDictionary(d => d.Key, d => d.Value);
                log.Debug(string.Format("Processed LINQ to pull out {0} entries.", cityCode));
                return listOfMatchingNames;
            }
            catch (Exception LINQException) { log.Fatal(string.Format("Error during LINQ to pull out {0} entries.", cityCode), LINQException); }
            return null;
        }
    }

}
