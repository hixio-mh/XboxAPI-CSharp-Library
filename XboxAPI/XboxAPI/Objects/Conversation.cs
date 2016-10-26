using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace XboxAPI.Objects
{
    public class Conversation
    {
        public string SenderXuid { get; protected set; }
        public string SenderGamerTag { get; protected set; }
        public string Sent { get; protected set; }
        public string LastUpdate { get; protected set; }
        public int MessageCount { get; protected set; }
        public int UnreadMessageCount { get; protected set; }
        public LastMessageObj LastMessage { get; protected set; }

        public Conversation(JToken json)
        {
            SenderXuid = json.SelectToken("senderXuid")?.ToString();
            SenderGamerTag = json.SelectToken("senderGamerTag")?.ToString();
            Sent = json.SelectToken("sent")?.ToString();
            LastUpdate = json.SelectToken("lastUpdateTime")?.ToString();
            MessageCount = int.Parse(json.SelectToken("messageCount").ToString());
            UnreadMessageCount = int.Parse(json.SelectToken("unreadMessageCount").ToString());
            LastMessage = new LastMessageObj(json.SelectToken("lastMessage"));
        }

        public class LastMessageObj
        {
            public int Id { get; protected set; }
            public bool IsRead { get; protected set; }
            public int SenderTitleId { get; protected set; }
            public string SenderXuid { get; protected set; }
            public string SenderGamerTag { get; protected set; }
            public string Sent { get; protected set; }
            public string LastUpdate { get; protected set; }
            public string MessageType { get; protected set; }
            public string MessageFolder { get; protected set; }
            public bool HasPhoto { get; protected set; }
            public bool HasAudio { get; protected set; }
            public string MessageText { get; protected set; }

            public LastMessageObj(JToken json)
            {
                bool isRead, hasPhoto, hasVoice;
                Id = int.Parse(json.SelectToken("messageId").ToString());
                IsRead = bool.TryParse(json.SelectToken("isRead")?.ToString(), out isRead) && isRead;
                SenderTitleId = int.Parse(json.SelectToken("senderTitleId").ToString());
                SenderXuid = json.SelectToken("senderXuid")?.ToString();
                SenderGamerTag = json.SelectToken("senderGamerTag")?.ToString();
                Sent = json.SelectToken("sentTime")?.ToString();
                LastUpdate = json.SelectToken("lastUpdateTime")?.ToString();
                MessageType = json.SelectToken("messageType")?.ToString();
                HasPhoto = bool.TryParse(json.SelectToken("hasPhoto")?.ToString(), out hasPhoto) && hasPhoto;
                hasVoice = bool.TryParse(json.SelectToken("hasVoice")?.ToString(), out hasVoice) && hasVoice;
                MessageFolder = json.SelectToken("messageFolder")?.ToString();
                MessageText = json.SelectToken("messageText")?.ToString();
            }
        }
    }
}
