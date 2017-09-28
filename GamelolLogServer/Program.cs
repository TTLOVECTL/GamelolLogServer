using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using AceNetFrame.ace;
using AceNetFrame.ace.auto;


namespace GamelolLogServer
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                NetServer server = new NetServer(10);
                server.lengthEncode = LengthEncoding.encode;
                server.lengthDecode = LengthEncoding.decode;
                server.serDecode = MessageEncoding.Decode;
                server.serEncode = MessageEncoding.Encode;
                server.center = new HandlerCenter();
                server.init();
                server.Start(2000);
            }
            catch (Exception e)
            {
                Console.WriteLine("Server Error " + e.TargetSite);
                Console.WriteLine(e.Source);
                Console.WriteLine(e.Message);
            }
            while (true)
            {

            }
        }
    }
}
