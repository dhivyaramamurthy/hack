using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Exchange.WebServices.Data;
using Microsoft.Exchange.WebServices.Auth;

namespace main
{
    class Program
    {
        static void Main(string[] args)
        {

            var mailbox = new MailManager("dhgovind@microsoft.com");
            mailbox.FindChildFolders();
            mailbox.ListFirstTenItems();
            Console.ReadKey();

        }

        


    }
}

