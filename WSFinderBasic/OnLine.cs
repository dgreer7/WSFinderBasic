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
        //public static void LocalPing()
        //{
        //    // Ping's the local machine.
        //    Ping pingSender = new Ping();
        //    IPAddress address = IPAddress.Loopback;
        //    PingReply reply = pingSender.Send(address);

        //    if (reply.Status == IPStatus.Success)
        //    {
        //        Console.WriteLine("Address: {0}", reply.Address.ToString());
        //        Console.WriteLine("RoundTrip time: {0}", reply.RoundtripTime);
        //        Console.WriteLine("Time to live: {0}", reply.Options.Ttl);
        //        Console.WriteLine("Don't fragment: {0}", reply.Options.DontFragment);
        //        Console.WriteLine("Buffer size: {0}", reply.Buffer.Length);
        //    }
        //    else
        //    {
        //        Console.WriteLine(reply.Status);
        //    }
        //}
    }
}
