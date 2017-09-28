using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AceNetFrame.ace;
using AceNetFrame.ace.auto;
using LogServerDataMessage;
namespace GamelolLogServer.HandleTool
{
    public class LoginLogHandle : HanderInterface
    {
        public void ClientClose(UserToken token)
        {
            throw new NotImplementedException();
        }

        public void MessageRecevie(UserToken token, SocketModel message)
        {
            LoginLogMessage loginLogMessage = message.getMessage<LoginLogMessage>();
            string data = "[" + loginLogMessage.loginTime + "] " + loginLogMessage.loginPlayerId.ToString() + " " + loginLogMessage.loginIP;
            Console.WriteLine(data);
        }
    }
}
