using log4net;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;


//Currently working on build static void twoLeterStationLocation()

//isStringAllChars all good
//Should really pull logic for list refinement out into its own method. Repeat code in list selection, launching search, gettting correct names.

namespace WSFinderBasic
{
    class Program
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static bool isclosing = false;
        static byte absoluteMax = 50;

        static void Main(string[] args)
        {
            //AppDomain.CurrentDomain.UnhandledException += UnhandledExceptionTrapper;

            log.Info("Application starting up...");
            SetConsoleCtrlHandler(new HandlerRoutine(ConsoleCtrlCheck), true);
            log.Info(string.Format("Application being started from location: {0} by {1}", System.Reflection.Assembly.GetExecutingAssembly().Location, Environment.UserName));
            byte maxAtOnce = 5;

            Console.ForegroundColor = ConsoleColor.Yellow;

            while (!isclosing)
            {
                maxAtOnce = OptionLauncher(GetUserSelection(maxAtOnce), maxAtOnce);
            }

        }
        static private void ConsoleCityLauncher(string cityCode, byte maxAtOnce)
        {
            Console.Clear();
            Console.WriteLine("Reading in workstation names. This will take about 90 seconds.");
            Dictionary<string, List<string>> fullWorkstationList = WorkstationList.StationCityList(cityCode);
            Console.Clear();

            Dictionary<string, List<string>> workingWorkstationList = WorkstationList.ScrubCityListForTR(fullWorkstationList, cityCode);
            int numberCurrentLaunched = 0;
            int numberTotalChecked = 0;
            foreach (string workstationInList in workingWorkstationList.Keys)
            {
                string workstation = workstationInList;
                byte namingAttempts = 0;
                while (namingAttempts < 1)
                {
                    if (OnLine.IsOnLine(workstation))
                    {
                        if (numberCurrentLaunched == maxAtOnce && numberTotalChecked < workingWorkstationList.Count + 1)
                        {
                            Console.WriteLine("So far {0} of {1} have been checked against.\nPress any key to continue.", numberTotalChecked, workingWorkstationList.Count + 1);
                            log.Info("Maxium number of sessions launched.");
                            numberCurrentLaunched = 0;
                            Console.ReadKey();
                        }
                        Search.Astro(workstation);
                        numberCurrentLaunched++;
                    }
                    else
                    {
                        Console.WriteLine("{0} is not online.", workstation);
                        try { workstation = OnLine.RenameConverstionR(workstation); }
                        catch (Exception renameExcetion) { log.Error(string.Format("An error occured when attempting to rename {0}", workstation), renameExcetion); }
                    }
                    namingAttempts++;
                }
                numberTotalChecked++;
            }
            workingWorkstationList = WorkstationList.ScrubCityListForGA(fullWorkstationList, cityCode);
            int workstationCount = numberTotalChecked + workingWorkstationList.Count + 1;
            foreach (string workstationInList in workingWorkstationList.Keys)
            {

                string workstation = workstationInList;
                byte namingAttempts = 0;
                while (namingAttempts < 1)
                {
                    if (OnLine.IsOnLine(workstation))
                    {
                        if (numberCurrentLaunched == maxAtOnce && numberTotalChecked < workstationCount)
                        {
                            Console.WriteLine("So far {0} of {1} have been launched.\nPress any key to continue.", numberTotalChecked, workingWorkstationList.Count + 1);
                            log.Info("Maxium number of sessions launched.");
                            numberCurrentLaunched = 0;
                            Console.ReadKey();
                        }
                        Search.Astro(workstation);
                        numberCurrentLaunched++;
                    }
                    else
                    {
                        Console.WriteLine("{0} is not online.", workstation);
                        try { workstation = OnLine.RenameConverstionR(workstation); }
                        catch (Exception renameExcetion) { log.Error(string.Format("An error occured when attempting to rename {0}", workstation), renameExcetion); }
                    }
                    namingAttempts++;
                }
                numberTotalChecked++;
            }
        }
        static private byte GetUserSelection(byte maxAtOnce)
        {
            byte choice;
            bool invalideResponse = true;
            do
            {

                Console.WriteLine("Expections:\n * AstroGrep.exe is installed as \"Program Files (x86)\\AstroGrep\\AstroGrep.exe\"");
                Console.WriteLine(" * PC_names.csv is located in the working directory of this application\n");
                Console.Write("Maximum number of AstroGrep sessions is set to {0}\n1. Open the AstroGrep configurations. \n2. Search by station. \n3. Search by station and specific location (TR/GA). \n4. Change maximum number of AstroGrep sessions to launch without pausing. \nEnter a value [1-4]: ", maxAtOnce);
                if (!byte.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 4)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nOnly a value of 1, 2, 3, or 4 is acceptable.\n");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    log.Info(string.Format("User has selected a choice of {0} which is invalid parameter for {1}", choice, System.Reflection.MethodBase.GetCurrentMethod().Name));
                }
                else
                {
                    invalideResponse = false;
                    log.Debug(string.Format("User has selected choice {0}", choice));
                }
            } while (invalideResponse);
            return choice;
        }
        static private string GetCitySelection()
        {
            string cty;
            Search.CloseAstroConfigs();
            Console.Clear();
            do
            {
                Console.Write("\nPlease enter the station's city code you'd like to search: ");
                cty = Console.ReadLine();
                if (cty.Length != 3 || !IsStringAllChars(cty))
                {

                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nOnly a three letter code is acceptable.\n");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    log.Info(string.Format("User has selected a choice of {0} which is invalid parameter for {1}", cty, System.Reflection.MethodBase.GetCurrentMethod().Name));
                }
                else
                    break;
            } while (true);
            log.Debug(string.Format("User has entered city code of {0}", cty));
            return cty.ToUpper();
        }
        static private byte OptionLauncher(byte choice, byte maxAtOnce)
        {
            switch (choice)
            {
                case 1: //open configs
                    Search.OpenAstroConfigs();
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Hopefully the configs have opened for you.\nRecommended changes: \n - AstroGrep.search.config \n   - At line 4 set UseRegularExpressions key to True \n   - At line 13 set UseRecursion key to True \n   - At line 25 set ContextLines key to 2 \n   - At line 48 ModifiedDateStart key \n - AstroGrep.general.config \n   - At line 66 set SearchFilters key to \"*_IMAGE.log, *_BDA.log, *_OBM.log\" \n   - At line 69 modify SearchTexts key\n");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case 2: //Full station search
                    ConsoleCityLauncher(GetCitySelection(), maxAtOnce);
                    break;
                case 3: //Station and location search
                    TwoLetterStationLocation(GetCitySelection(), maxAtOnce);
                    break;
                case 4: //Change maxAtOnce
                    maxAtOnce = SetMaxAtOnce(maxAtOnce);
                    break;
            }
            return maxAtOnce;
        }
        static private void TwoLetterStationLocation(string cityCode, byte maxAtOnce)
        {
            byte choice;
            bool invalideResponse = true;
            Console.Clear();
            do
            {
                Console.Write("\n1. Search for {0}TR... \n2. Search for {0}GA... \nEnter a value [1-2]: ", cityCode);
                if (!byte.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 2)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nOnly a value of 1 or 2 is acceptable.");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    log.Info(string.Format("User has selected a choice of {0} which is invalid parameter for {1}", choice, System.Reflection.MethodBase.GetCurrentMethod().Name));
                }
                else
                {
                    invalideResponse = false;
                    log.Debug(string.Format("User has selected choice {0} for {1}", choice, System.Reflection.MethodBase.GetCurrentMethod().Name));
                }
            } while (invalideResponse);
            switch (choice)
            {
                case 1:
                    Dictionary<string, List<string>> workstationList = WorkstationList.ScrubCityListForTR(WorkstationList.StationCityList(cityCode), cityCode);
                    int numberTotalLaunchedTR = 0;
                    int numberCurrentLaunchedTR = 0;
                    foreach (string workstationInList in workstationList.Keys)
                    {
                        string workstation = workstationInList;
                        byte namingAttempts = 0;
                        while (namingAttempts < 1)
                        {
                            if (OnLine.IsOnLine(workstation))
                            {
                                if (numberCurrentLaunchedTR == maxAtOnce && numberTotalLaunchedTR < workstationList.Count + 1)
                                {
                                    Console.WriteLine("So far {0} of {1} have been launched.\nPress any key to continue.", numberTotalLaunchedTR, workstationList.Count + 1);
                                    log.Info("Maxium number of sessions launched.");
                                    numberCurrentLaunchedTR = 0;
                                    Console.ReadKey();
                                }
                                Search.Astro(workstation);
                                numberCurrentLaunchedTR++;
                            }
                            else
                            {
                                Console.WriteLine("{0} is not online.", workstation);
                                try { workstation = OnLine.RenameConverstionR(workstation); }
                                catch (Exception renameExcetion) { log.Error(string.Format("An error occured when attempting to rename {0}", workstation), renameExcetion); }
                            }
                            namingAttempts++;
                        }
                    }
                    numberTotalLaunchedTR++;
                    break;
                case 2:
                    Dictionary<string, List<string>> workstationListGA = WorkstationList.ScrubCityListForGA(WorkstationList.StationCityList(cityCode), cityCode);
                    int numberCurrentLaunchedGA = 0;
                    int numberTotalLaunchedGA = 0;
                    foreach (string workstationInList in workstationListGA.Keys)
                    {
                        string workstation = workstationInList;
                        byte namingAttempts = 0;
                        while (namingAttempts < 1)
                        {
                            if (OnLine.IsOnLine(workstation))
                            {
                                if (numberCurrentLaunchedGA == maxAtOnce && numberTotalLaunchedGA < workstationListGA.Count + 1)
                                {
                                    Console.WriteLine("So far {0} of {1} have been launched.\nPress any key to continue.", numberTotalLaunchedGA, workstationListGA.Count);
                                    log.Info("Maxium number of sessions launched.");
                                    numberCurrentLaunchedGA = 0;
                                    Console.ReadKey();
                                }
                                Search.Astro(workstation);
                                numberCurrentLaunchedGA++;
                            }
                            else
                            {
                                Console.WriteLine("{0} is not online.", workstation);
                                try { workstation = OnLine.RenameConverstionR(workstation); }
                                catch (Exception renameExcetion) { log.Error(string.Format("An error occured when attempting to rename {0}", workstation), renameExcetion); }
                            }
                            namingAttempts++;
                        }
                        numberTotalLaunchedGA++;
                    }
                    break;
            }
        }
        static private bool IsStringAllChars(string stringToTest)
        {
            bool isAllChars = true;
            for (int i = 0; i < stringToTest.Length; i++)
            {
                if (!char.IsLetter(stringToTest, i))
                    isAllChars = false;
            }
            return isAllChars;
        }
        private static byte SetMaxAtOnce(byte maxAtOnce)
        {
            bool invalidResponse = true;
            Console.Clear();
            do
            {
                Console.Write("\nEnter the maxium number of AstroGrep sessions to launch at one time: ");
                if (!byte.TryParse(Console.ReadLine(), out maxAtOnce) || maxAtOnce < 1 || maxAtOnce >= absoluteMax)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nOnly a value of 1 or 2 is acceptable.");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    log.Info(string.Format("User has selected a choice of {0} which is invalid parameter for {1}", maxAtOnce, System.Reflection.MethodBase.GetCurrentMethod().Name));
                }
                else
                {
                    invalidResponse = false;
                    log.Debug(string.Format("User has selected choice {0} for {1}", maxAtOnce, System.Reflection.MethodBase.GetCurrentMethod().Name));
                }
            } while (invalidResponse);
            return maxAtOnce;
        }
        private static bool ConsoleCtrlCheck(CtrlTypes ctrlType)
        {
            // Put your own handler here
            switch (ctrlType)
            {
                case CtrlTypes.CTRL_C_EVENT:
                    isclosing = true;
                    log.Info("CTRL+C received.");
                    break;

                case CtrlTypes.CTRL_BREAK_EVENT:
                    isclosing = true;
                    log.Info("CTRL+BREAK received.");
                    break;

                case CtrlTypes.CTRL_CLOSE_EVENT:
                    isclosing = true;
                    log.Info("Program being closed.");
                    break;

                case CtrlTypes.CTRL_LOGOFF_EVENT:
                    isclosing = true;
                    log.Info("User is logging off.");
                    break;
                case CtrlTypes.CTRL_SHUTDOWN_EVENT:
                    isclosing = true;
                    log.Info("Shutdown detected.");
                    break;
            }
            CloseProgram();
            return isclosing;
        }
        private static void CloseProgram()
        {
            log.Info("Application shutting down...");
            Environment.Exit(0);
        }
        static void UnhandledExceptionTrapper(object sender, UnhandledExceptionEventArgs e)
        {
            log.Fatal("MAJOR MELTDOWN - Unhandled exception.");
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n********************************************************************************\n********************************************************************************");
            Console.WriteLine("\nAwwwwww Dang, I've done pooped myself.\nLet Dave know he writes crappy code; but at least he caught the exception.\nDon't loose the log.\nBetter luck next time.");
            Console.WriteLine("\n********************************************************************************\n********************************************************************************");
            Console.ReadKey();
            Environment.Exit(1);
        }
        #region unmanaged
        // Declare the SetConsoleCtrlHandler function
        // as external and receiving a delegate.

        [DllImport("Kernel32")]
        public static extern bool SetConsoleCtrlHandler(HandlerRoutine Handler, bool Add);

        // A delegate type to be used as the handler routine
        // for SetConsoleCtrlHandler.
        public delegate bool HandlerRoutine(CtrlTypes CtrlType);

        // An enumerated type for the control messages
        // sent to the handler routine.
        public enum CtrlTypes
        {
            CTRL_C_EVENT = 0,
            CTRL_BREAK_EVENT,
            CTRL_CLOSE_EVENT,
            CTRL_LOGOFF_EVENT = 5,
            CTRL_SHUTDOWN_EVENT
        }

        #endregion
    }
}
