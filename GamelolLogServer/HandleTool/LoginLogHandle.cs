using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AceNetFrame.ace;
using AceNetFrame.ace.auto;
using LogServerDataMessage;
using GamelolLogServer.TextFile;
using GamelolLogServer.Util;

namespace GamelolLogServer.HandleTool
{
    public class LoginLogHandle : HanderInterface
    {

        private TextFileWrite textFileWrite = null;

        public LoginLogHandle() {

            textFileWrite = new TextFileWrite(ConfigurationSetting.GetConfigurationValue("loginLogFilePath"));
        }
        public void ClientClose(UserToken token)
        {
            throw new NotImplementedException();
        }

        public void MessageRecevie(UserToken token, SocketModel message)
        {
            LoginLogMessage loginLogMessage = message.getMessage<LoginLogMessage>();
            string time = loginLogMessage.loginTime.ToString("yyyy-MM-dd") + " " + loginLogMessage.loginTime.ToString("hh:mm:ss");
            string data = "[" + time + "] loginplayerid=" + loginLogMessage.loginPlayerId.ToString() + " loginip=" + loginLogMessage.loginIP;
            textFileWrite.WirteLine(data);
        }
    }
}
