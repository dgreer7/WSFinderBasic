using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSFinderBasic
{
    class Program
    {
        static void Main(string[] args)
        {
            byte maxAtOnce = 15;
            //string workstation = "NEPTUNE";
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Expections:\n * AstroGrep.exe is installed as \"Program Files (x86)\\AstroGrep\\AstroGrep.exe\"");
            //Search.AstroConfigs();

            List<string> workstationList = new List<string>();

            byte numberLaunched = 0;
            foreach (string workstation in workstationList)
            {
                if (OnLine.IsOnLine(workstation))
                {
                    if (numberLaunched == maxAtOnce)
                    {
                        Console.WriteLine("So far {0} of {1} have been launched.\nPress any key to continue.", numberLaunched, workstationList.Count);
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


        }
    }
}
