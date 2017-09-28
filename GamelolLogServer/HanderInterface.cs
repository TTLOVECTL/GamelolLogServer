using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AceNetFrame.ace;
using AceNetFrame.ace.auto;
namespace GamelolLogServer
{
    interface HanderInterface
    {
        void MessageRecevie(UserToken token, SocketModel message);
        void ClientClose(UserToken token);
    }
}
