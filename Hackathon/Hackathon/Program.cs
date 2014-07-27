using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
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

            var mailbox = new MailManager("dhivyar@microsoft.com");
            var messages = mailbox.ReadMessages("Inbox");
            messages.ToList().ForEach( x => ProcessMail(x));
            Console.ReadKey();

        }

        private static void ProcessMail(Mail mail)
        {
            String path = "D:\\Temp\\mail.txt";

            if (!File.Exists(path))
            { 
                var mailFilePtr=File.CreateText(path);
                mailFilePtr.Dispose();
            }
 
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine(mail.ConversationId + "\t" + mail.ConversationTopic);
                Logger.WriteInformation(mail.ConversationTopic + mail.ConversationIndex);
                sw.Close();
            }
        }
    }
}

