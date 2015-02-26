using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSFinderBasic
{
    class WorkstationList
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger
    (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        /// <summary>
        /// The static list will return a List<string> of all names that have been staticly
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

            log.Debug("ListOFKnownNames has add all values and is about to return");

            return listOfKnownNames;
        }
        public static List<string> StationCityList(string cityCode)
        {
            List<string> listOfMatchingNames = new List<string>();
            return listOfMatchingNames;
        }
        private static List<string> ReadInNameList()
        {
            List<string> listOfFoundNames = new List<string>();

            return listOfFoundNames;
        }
    }

}
