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
        private readonly EmailMessage _message;

        public Mail(EmailMessage message)
        {
            this._message = message;

            this._message.Load(new PropertySet(
                ItemSchema.Subject,
                ItemSchema.Body,
                EmailMessageSchema.ConversationIndex,
                EmailMessageSchema.ConversationId,
                EmailMessageSchema.Sender,
                EmailMessageSchema.From,
                EmailMessageSchema.ToRecipients,
                EmailMessageSchema.CcRecipients,
                EmailMessageSchema.MimeContent,
                ItemSchema.DateTimeSent,
                EmailMessageSchema.ConversationTopic
                ));
        }


        public string Subject
        {
            get { return _message.Subject; }
        }

        public string Body
        {
            get { return _message.Body; }
        }

        public string ConversationIndex
        {
            get
            {
                var rawId = HexToString(_message.ConversationIndex);
                return rawId.Substring(0, Math.Min(rawId.Length, 255));
            }
        }

        public string ConversationId
        {
            get { return _message.ConversationId; }
        }

        public string SenderAddress
        {
            get { return _message.Sender.Address; }
        }

        public IEnumerable<string> ToRecepients
        {
            get { return _message.ToRecipients.Select(x => x.Address); }
        }

        public IEnumerable<string> CcRecepients
        {
            get { return _message.CcRecipients.Select(x => x.Address); }
        }

        public string ConversationTopic
        {
            get { return _message.ConversationTopic; }
        }

        private static string HexToString(byte[] bytes)
        {
            var hex = new StringBuilder();
            foreach (byte t in bytes)
            {
                hex.Append(t.ToString("X2", System.Globalization.CultureInfo.InvariantCulture));
            }
            return hex.ToString();
        }
    }
}


