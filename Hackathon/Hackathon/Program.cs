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
            ExchangeService service = new ExchangeService(ExchangeVersion.Exchange2010_SP2);

            // Setting credentials is unnecessary when you connect from a computer that is
            // logged on to the domain.
            service.AutodiscoverUrl("dhgovind@microsoft.com");

            /* EmailMessage message = new EmailMessage(service);
             message.Subject = "Hello, world!";
             message.Body = "Sent using the EWS Managed API.";
             message.ToRecipients.Add("dhgovind@microsoft.com");
             message.SendAndSaveCopy();*/
            ListFirstTenItems(service);
            FindChildFolders(service);
            Console.ReadKey();

        }

        public static void FindChildFolders(ExchangeService service)
        {
            FindFoldersResults findResults = service.FindFolders(
            WellKnownFolderName.Inbox,
            new FolderView(int.MaxValue));

            foreach (Folder folder in findResults.Folders)
            {
                Console.WriteLine(folder.DisplayName);
                Console.WriteLine(folder.Id);
            }
        }

        public static void ListFirstTenItems(ExchangeService service)
        {
            FindItemsResults<Item> findResults = service.FindItems(
            WellKnownFolderName.Inbox,
            new ItemView(10));

            foreach (EmailMessage item in findResults.Items)
            {
                item.Load();
                Console.WriteLine(item.Body);
            }
        }


    }
}

