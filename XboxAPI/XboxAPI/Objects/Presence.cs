using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace XboxAPI.Objects
{
    public class Presence
    {
        public string XUID { get; protected set; }
        public string State { get; protected set; }
        public LastSeenObj LastSeen { get; protected set; }

        public Presence(JToken json)
        {
            XUID = json.SelectToken("xuid")?.ToString();
            State = json.SelectToken("state")?.ToString();
            LastSeen = new LastSeenObj(json.SelectToken("lastSeen"));
        }

        public class LastSeenObj
        {
            public string DeviceType { get; protected set; }
            public string TitleId { get; protected set; }
            public string TitleName { get; protected set; }
            public string TimeStamp { get; protected set; }

            public LastSeenObj(JToken json)
            {
                DeviceType = json.SelectToken("deviceType")?.ToString();
                TitleId = json.SelectToken("titleId")?.ToString();
                TitleName = json.SelectToken("titleName")?.ToString();
                TimeStamp = json.SelectToken("timestamp")?.ToString();
            }
        }
    }
}
