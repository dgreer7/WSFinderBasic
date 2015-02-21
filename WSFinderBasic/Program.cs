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
            string workstation = "NEPTUNE";
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Expections:\n * AstroGrep.exe is installed as \"Program Files (x86)\\AstroGrep\\AstroGrep.exe\"");
            //OnLine.LocalPing();
            Search.AstroConfigs();

            /*

            if (OnLine.IsOnLine(workstation))
            {
                Search.Astro(workstation);
            }
            else
            {
                Console.WriteLine("Sorry {0} is not online.", workstation);
            }*/
            Console.ReadKey();
             

        }
    }
}
