using log4net;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WSFinderBasic
{
    class Program
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        static void Main(string[] args)
        {
            log.Info("Application starting up...");
            byte maxAtOnce = 15;

            Console.ForegroundColor = ConsoleColor.Yellow;

            //This is test code:
            string test = OnLine.RenameConverstionR("SEATRAS100K01r");
            string test2 = OnLine.RenameConverstionR(test);
            //Dictionary<string, List<string>> test = WorkstationList.StationCityList("SEA","TR");
            //: and will be removed

            Console.WriteLine("Expections:\n * AstroGrep.exe is installed as \"Program Files (x86)\\AstroGrep\\AstroGrep.exe\"");
            Console.WriteLine(" * PC_names.csv is located in the working directory of this application");
            //Search.AstroConfigs();

            Console.ReadKey();

            Dictionary<string, List<string>> workstationList = WorkstationList.StationCityList("SEA");
            log.Debug("Static List retured from Workstaiton.List.SaticList.");
            byte numberLaunched = 0;
            foreach (string workstation in workstationList.Keys)
            {
                if (OnLine.IsOnLine(workstation))
                {
                    if (numberLaunched == maxAtOnce)
                    {
                        Console.WriteLine("So far {0} of {1} have been launched.\nPress any key to continue.", numberLaunched, workstationList.Count);
                        log.Info("Maxium number of sessions launched.");
                        numberLaunched = 0;
                        Console.ReadKey();
                    }
                    Search.Astro(workstation);
                    numberLaunched++;
                }
                else
                {
                    Console.WriteLine("Sorry {0} is not online.", workstation);
                }
            }

            Console.ReadKey();
            log.Info("Application exiting...");
        }
    }
}
