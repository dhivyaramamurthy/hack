using System;
using Microsoft.Exchange.WebServices.Data;

namespace main
{
    class MailManager
    {
        private ExchangeService _exchangeService;

        public MailManager(string emailAddress)
        {
            _exchangeService = new ExchangeService(ExchangeVersion.Exchange2010_SP2);
            _exchangeService.AutodiscoverUrl(emailAddress);
        }

        public void FindChildFolders()
        {
            FindFoldersResults findResults = _exchangeService.FindFolders(
            WellKnownFolderName.Inbox,
            new FolderView(int.MaxValue));

            foreach (Folder folder in findResults.Folders)
            {
                Logger.WriteInformation(folder.DisplayName);
                Logger.WriteInformation(folder.Id.ToString());
            }
        }

        public void ListFirstTenItems()
        {
            FindItemsResults<Item> findResults = _exchangeService.FindItems(
            WellKnownFolderName.Inbox,
            new ItemView(10));

            foreach (EmailMessage item in findResults.Items)
            {
                item.Load();
                Logger.WriteInformation(item.Body);
            }
        }
    }
}