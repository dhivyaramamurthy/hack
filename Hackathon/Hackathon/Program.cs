using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

            var mailbox = new MailManager("dhgovind@microsoft.com");
            var messages = mailbox.ReadMessages("hydchat");
            messages.ToList().ForEach( x => ProcessMail(x));
            Console.ReadKey();

        }

        private static void ProcessMail(Mail mail)
        {
            String path = "C:\\temp\\mail.txt";

            if (!File.Exists(path))
            { 
                File.CreateText(path);
               
            }

            // This text is always added, making the file longer over time 
            // if it is not deleted. 
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine(mail.Message.ConversationId + "\t" + mail.Message.ConversationTopic);
                sw.Close();
            }
        }
    }
}

