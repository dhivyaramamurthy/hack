using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hackathon;
using Microsoft.Exchange.WebServices.Data;
using Microsoft.Exchange.WebServices.Auth;

namespace main
{
    class Program
    {
        static void Main(string[] args)
        {

            var mailbox = new MailManager("dhgovind@microsoft.com");
            var messages = mailbox.ReadMessages("hydchat");
            messages.ToList().ForEach( x => Logger.WriteInformation(x.Message.ConversationTopic));
            Console.ReadKey();

        }

    }
}

