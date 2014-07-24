using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Exchange.WebServices.Data;

namespace Hackathon
{
    class Mail
    {
        public readonly EmailMessage Message;

        public Mail(EmailMessage message)
        {
            this.Message = message;

            this.Message.Load(new PropertySet(
                ItemSchema.Subject,
                ItemSchema.Body,
                EmailMessageSchema.ConversationIndex,
                EmailMessageSchema.Sender,
                EmailMessageSchema.From,
                EmailMessageSchema.ToRecipients,
                EmailMessageSchema.CcRecipients,
                EmailMessageSchema.MimeContent,
                ItemSchema.DateTimeSent,
                EmailMessageSchema.ConversationTopic
                ));
        }
    }
}


