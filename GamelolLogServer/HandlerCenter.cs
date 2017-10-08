using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AceNetFrame.ace;
using AceNetFrame.ace.auto;
using GamelolLogServer.HandleTool;
using LogServerDataMessage;
namespace GamelolLogServer
{
    public class HandlerCenter:AbsHandleCenter
    {

        private HanderInterface loginLogHandler;

        private HanderInterface systemLogHandler;

        public HandlerCenter()
        {
            loginLogHandler = new LoginLogHandle();
            systemLogHandler = new SystemLogHandle();
        }

        public override void MessageRecive(UserToken token, object message)
        {
            SocketModel model = message as SocketModel;
            switch ((LogType)model.type)
            {
                case LogType.LOGIN_LOG:
                    loginLogHandler.MessageRecevie(token,model);
                    break;
                case LogType.SYSTEM_LOG:
                    systemLogHandler.MessageRecevie(token,model);
                    break;
            }
            
        }

        public override void ClientClose(UserToken token, string error)
        {
            Console.WriteLine("有客户端断开" + "---error:" + error);
        }
    }
}
