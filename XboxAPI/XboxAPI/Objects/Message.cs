using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace XboxAPI.Objects
{
    public class Message
    {
        public HeaderObj Header { get; protected set; }
        public string Summary { get; protected set; }

        public Message(JToken json)
        {
            if (json.SelectToken("header") != null)
                Header = new HeaderObj(json.SelectToken("header"));
            Summary = json.SelectToken("messageSummary")?.ToString();
        }

        public class HeaderObj
        {
            public int Id { get; protected set; }
            public bool IsRead { get; protected set; }
            public string SenderXuid { get; protected set; }
            public string Sender { get; protected set; }
            public string Sent { get; protected set; }
            public string Expiration { get; protected set; }
            public string MessageType { get; protected set; }
            public bool HasText { get; protected set; }
            public bool HasPhoto { get; protected set; }
            public bool HasAudio { get; protected set; }
            public string MessageFolderType { get; protected set; }

            public HeaderObj(JToken json)
            {
                bool isRead, hasText, hasPhoto, hasVoice;
                Id = int.Parse(json.SelectToken("id").ToString());
                IsRead = bool.TryParse(json.SelectToken("isRead")?.ToString(), out isRead) && isRead;
                SenderXuid = json.SelectToken("senderXuid")?.ToString();
                Sender = json.SelectToken("sender")?.ToString();
                Sent = json.SelectToken("sent")?.ToString();
                Expiration = json.SelectToken("expiration")?.ToString();
                MessageType = json.SelectToken("messageType")?.ToString();
                HasText = bool.TryParse(json.SelectToken("hasText")?.ToString(), out hasText) && hasText;
                HasPhoto = bool.TryParse(json.SelectToken("hasPhoto")?.ToString(), out hasPhoto) && hasPhoto;
                hasVoice = bool.TryParse(json.SelectToken("hasVoice")?.ToString(), out hasVoice) && hasVoice;
                MessageFolderType = json.SelectToken("messageFolderType")?.ToString();
            }
        }

    }
}
