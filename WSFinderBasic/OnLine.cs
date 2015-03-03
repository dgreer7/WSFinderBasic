using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;



namespace WSFinderBasic
{
    class OnLine
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger
    (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// Will return boolean if passed string is online.
        /// Will return false for not online as well as not listed in DNS.
        /// </summary>
        /// <param name="workstationName"></param>
        /// <returns>boolean</returns>
        static public bool IsOnLine(string workstationName)
        {
            try
            {
                Ping pingSender = new Ping();
                PingReply reply = pingSender.Send(workstationName);

                if (reply.Status == IPStatus.Success)
                {
                    log.Debug(string.Format("{0} is online and is located in DNS.", workstationName));
                    return true;
                }
                else
                {
                    log.Info(string.Format("{0} is not online but is located in DNS.", workstationName));
                    return false;
                }
            }
            //catching exceptions for workstations that are no longer listed in the DNS
            catch (Exception)
            {
                log.Warn(string.Format("{0} is not online and is not located in DNS.", workstationName));
                return false;
            }
        }
        static public string RenameConverstionR(string workstationName)
        {
            if (workstationName.EndsWith("R", StringComparison.CurrentCultureIgnoreCase)) { return workstationName.Substring(0, workstationName.Length -1); }
            else { return workstationName + "R"; }
        }
    }
}
