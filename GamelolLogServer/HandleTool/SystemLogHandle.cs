using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AceNetFrame.ace;
using AceNetFrame.ace.auto;
using LogServerDataMessage;
using GamelolLogServer.Util;
using GamelolLogServer.TextFile;

namespace GamelolLogServer.HandleTool
{
    public class SystemLogHandle : HanderInterface
    {
        private TextFileWrite textFileWrite = null;

        public SystemLogHandle() {
            textFileWrite = new TextFileWrite(ConfigurationSetting.GetConfigurationValue("systemLogFilePath"));
        }
        public void ClientClose(UserToken token)
        {
            throw new NotImplementedException();
        }

        public void MessageRecevie(UserToken token, SocketModel message)
        {
            SystemLogMessage systemLogMessage = message.getMessage<SystemLogMessage>();
            string time = systemLogMessage.dataTime.ToString("yyyy-MM-dd") + " " + systemLogMessage.dataTime.ToString("hh:mm:ss");
            string data = "[" + time + "] servername="+systemLogMessage.serverName+
                " serverid="+systemLogMessage.serverId+" cpuuse="+Math.Round(systemLogMessage.cpuLoad*100,2)+"%"+
                " memory="+Math.Round(systemLogMessage.memoryAvailable*100,2)+"%";
            textFileWrite.WirteLine(data);
        }
    }
}
