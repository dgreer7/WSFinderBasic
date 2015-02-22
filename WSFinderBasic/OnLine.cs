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
                    return true;
                }
                else
                {
                    return false;
                }
            }
            //catching exceptions for workstations that are no longer listed in the DNS
            catch (Exception)
            {
                return false;
            }
        }
    }
}
