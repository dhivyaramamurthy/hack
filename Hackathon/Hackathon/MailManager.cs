using System;
using System.Collections.Generic;
using System.Linq;
using main;
using Microsoft.Exchange.WebServices.Data;

namespace Hackathon
{
    class MailManager
    {
        private ExchangeService _service;

        public MailManager(string emailAddress)
        {
            _service = new ExchangeService(ExchangeVersion.Exchange2010_SP2);
            _service.AutodiscoverUrl(emailAddress);
        }

        public IEnumerable<Mail> ReadMessages(string mailFolder)
        {
            var folder = FindFolderByName(mailFolder);

            var items = folder.FindItems(new ItemView(10)).OrderBy(x => x.DateTimeReceived);

            return items
                .Where(item => item is EmailMessage)
                .OrderBy(message => message.DateTimeReceived)
                .Select(message => new Mail(message as EmailMessage))
                .AsEnumerable();
        }

         public Folder FindFolderByName(string mailFolder)
        {
            Logger.WriteInformation(String.Format("Looking for folder named '{0}'", mailFolder));

            var folderFilter = new SearchFilter.IsEqualTo(FolderSchema.DisplayName, mailFolder);
            var rootFolder = Folder.Bind(_service, WellKnownFolderName.MsgFolderRoot);

            var searchResults = rootFolder.FindFolders(folderFilter, new FolderView(1));

            var folder = searchResults.First();
            return folder;
        }
    }
 }
