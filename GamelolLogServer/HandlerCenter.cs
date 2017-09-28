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

        public HandlerCenter()
        {
            loginLogHandler = new LoginLogHandle();
        }

        public override void MessageRecive(UserToken token, object message)
        {
            SocketModel model = message as SocketModel;
            switch ((LogType)model.type)
            {
                case LogType.LOGIN_LOG:
                    loginLogHandler.MessageRecevie(token,model);
                    break;
            }
            
        }

        public override void ClientClose(UserToken token, string error)
        {
            //Console.WriteLine("有客户端断开" + "---error:" + error);
            //foreach(PlayerMessage playermessage in MapPlayer.mainMap){
            //    if (playermessage.usertoken == token)
            //    {
            //        MapPlayer.mainMap.Remove(playermessage);
            //        foreach (PlayerMessage playermessage1 in MapPlayer.mainMap) {
            //            UserDao user = new UserDao();
            //            user.userid = playermessage1.playerid;
            //            user.username = playermessage1.playername;
            //            user.posx = playermessage1.posx;
            //            user.posy = playermessage1.posx;
            //            SocketModel model = new SocketModel(1,1,1,user);
            //            SendtoClient.write(playermessage1.usertoken, model);
            //        }
            //        break;
            //    }
            //}
        }
    }
}
