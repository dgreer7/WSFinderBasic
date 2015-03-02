﻿using log4net;
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
        /// The static list will return a List&lt;string&gt; of all names that have been staticly
        /// compiled into code. This list was gathered from dud_AkPac_0.2.0.bat.
        /// List comprises SEA, PDX, ANC, SAN, SIT, and JNU.
        /// </summary>
        /// <returns></returns>
        public static List<string> StaticList()
        {
            List<string> listOfKnownNames = new List<string>();

            listOfKnownNames.Add("SEATRASP01W01B");
            listOfKnownNames.Add("SEATRASP01W02B");
            listOfKnownNames.Add("SEATRASP01W03B");
            listOfKnownNames.Add("SEATRASP01W04B");
            listOfKnownNames.Add("SEATRASP01W05R");
            listOfKnownNames.Add("SEATRASP01W06");
            listOfKnownNames.Add("SEATRASP01W07");
            listOfKnownNames.Add("SEATRASP01W08");
            listOfKnownNames.Add("SEATRASP02W09R");
            listOfKnownNames.Add("SEATRASP02W10R");
            listOfKnownNames.Add("SEATRASP02W11");
            listOfKnownNames.Add("SEATRASP02W12R");
            listOfKnownNames.Add("SEATRASP02W13");
            listOfKnownNames.Add("SEATRASP02W14R");
            listOfKnownNames.Add("SEATRASP02W15");
            listOfKnownNames.Add("SEATRASP02W16R");
            listOfKnownNames.Add("SEATRASP03W17");
            listOfKnownNames.Add("SEATRASP03W18");
            listOfKnownNames.Add("SEATRASP03W19R");
            listOfKnownNames.Add("SEATRASP03W20R");
            listOfKnownNames.Add("SEATRASP03W21R");
            listOfKnownNames.Add("SEATRASP03W22");
            listOfKnownNames.Add("SEATRASP03W23");
            listOfKnownNames.Add("SEATRASP03W24R");
            listOfKnownNames.Add("SEATRASP04W25");
            listOfKnownNames.Add("SEATRASP04W26R");
            listOfKnownNames.Add("SEATRASP04W27");
            listOfKnownNames.Add("SEATRASP04W28");
            listOfKnownNames.Add("SEATRASP04W29R");
            listOfKnownNames.Add("SEATRASP05W30");
            listOfKnownNames.Add("SEATRASP05W31");
            listOfKnownNames.Add("SEATRASP05W32");
            listOfKnownNames.Add("SEAGAC09ONW01");
            listOfKnownNames.Add("SEAGAC10ONW01R");
            listOfKnownNames.Add("SEAGAC11ONW01");
            listOfKnownNames.Add("SEAGAC12ONW01");
            listOfKnownNames.Add("SEAGAC14ONW01R");
            listOfKnownNames.Add("SEAGAC15ONW01R");
            listOfKnownNames.Add("SEAGAC16ONW01R");
            listOfKnownNames.Add("SEAGAC16ONW02");
            listOfKnownNames.Add("SEAGAC17ONW01R");
            listOfKnownNames.Add("SEAGAC20ONW01R");
            listOfKnownNames.Add("SEAGAN02ONW01R");
            listOfKnownNames.Add("SEAGAN03ONW01R");
            listOfKnownNames.Add("SEAGAN06ONW01");
            listOfKnownNames.Add("SEAGAN07ONW01");
            listOfKnownNames.Add("SEAGAN07ONW02R");
            listOfKnownNames.Add("SEAGAN07RONW01");
            listOfKnownNames.Add("SEAGAN08ONW01");
            listOfKnownNames.Add("SEAGAN09ONW01");
            listOfKnownNames.Add("SEAGAQXC2BW01");
            listOfKnownNames.Add("SEAGAQXC2BW02");
            listOfKnownNames.Add("SEAGAQXC2BW03R");
            listOfKnownNames.Add("SEAGAQXC2DW01R");
            listOfKnownNames.Add("SEAGAQXC2DW02");
            listOfKnownNames.Add("SEAGAQXC2DW03R");
            listOfKnownNames.Add("SEAGAQXC2FW01");
            listOfKnownNames.Add("SEAGAQXC2FW02");
            listOfKnownNames.Add("SEAGAQXC2FW03");
            listOfKnownNames.Add("SEAGAQXC2JW01");
            listOfKnownNames.Add("SEAGAQXC2JW02R");
            listOfKnownNames.Add("SEAGAQXC2JW03");
            listOfKnownNames.Add("SEAGAQXC2LW03R");
            listOfKnownNames.Add("SEAGAQXC2MW01R");
            listOfKnownNames.Add("SEAGAQXC2MW02");
            listOfKnownNames.Add("SEAQXC10ONW01R");
            listOfKnownNames.Add("SEAGAQXN12AW01R");
            listOfKnownNames.Add("SEAGAQXN12BW01R");
            listOfKnownNames.Add("SEAGAQXN12CW01R");
            listOfKnownNames.Add("SEAGAQXN12DW01R");
            listOfKnownNames.Add("SEAGAQXN12EW01");
            listOfKnownNames.Add("SEAGAQXN12FW01R");
            listOfKnownNames.Add("SEAGAQXN12W01");
            listOfKnownNames.Add("SEAGAQXN12W02");
            listOfKnownNames.Add("SANGA7ASG15ON");
            listOfKnownNames.Add("SANGA7ASG14ON");
            listOfKnownNames.Add("SANGA7ASG13ON");
            listOfKnownNames.Add("SANGA7ASG17ON");
            listOfKnownNames.Add("SANGA7ASG16ON");
            listOfKnownNames.Add("SANGA7ASG18W2");
            listOfKnownNames.Add("PDXTR7AS001W08");
            listOfKnownNames.Add("PDXTR7AS001W09");
            listOfKnownNames.Add("PDXTR7AS001W10");
            listOfKnownNames.Add("PDXTR7AS001W11");
            listOfKnownNames.Add("PDXTR7AS001W12");
            listOfKnownNames.Add("PDXTR7AS001W13");
            listOfKnownNames.Add("PDXTR7AS001W14");
            listOfKnownNames.Add("PDXTR7AS001W15");
            listOfKnownNames.Add("PDXTR7AS001W16");
            listOfKnownNames.Add("PDXTR7AS001W17");
            listOfKnownNames.Add("PDXTR7AS001W18");
            listOfKnownNames.Add("PDXTR7AS001W19");
            listOfKnownNames.Add("PDXTR7AS001W20");
            listOfKnownNames.Add("PDXTR7AS001W21");
            listOfKnownNames.Add("PDXTR7AS001W22");
            listOfKnownNames.Add("PDXTR7AS001W23");
            listOfKnownNames.Add("ANCTRASPODW01");
            listOfKnownNames.Add("ANCTRASPODW02");
            listOfKnownNames.Add("ANCTRASPODW03");
            listOfKnownNames.Add("ANCTRASPODW04R");
            listOfKnownNames.Add("ANCTRASPODW05");
            listOfKnownNames.Add("ANCTRASPODW06");
            listOfKnownNames.Add("ANCTRASPODW07");
            listOfKnownNames.Add("ANCTRASPODW08");
            listOfKnownNames.Add("ANCTRASPODW09X");
            listOfKnownNames.Add("ANCTRASPODW10R");
            listOfKnownNames.Add("JNUTRASPODW01");
            listOfKnownNames.Add("JNUTRASPODW02");
            listOfKnownNames.Add("JNUTRASPODW03");
            listOfKnownNames.Add("JNUTRASPODW04");
            listOfKnownNames.Add("JNUTRASPODW05");
            listOfKnownNames.Add("SITTRASPODW01");
            listOfKnownNames.Add("SITTRASPODW02");

            log.Debug("ListOFKnownNames has add all values and is about to return.");

            return listOfKnownNames;
        }
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
    }

}
