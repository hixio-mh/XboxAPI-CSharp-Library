using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace XboxAPI.Objects
{
    public class AccountXuid
    {
        public string XUID { get; protected set; }
        public string GamerTag1 { get; protected set; }
        public string GamerTag2 { get; protected set; }

        public AccountXuid(JToken json)
        {
            XUID = json.SelectToken("xuid")?.ToString();
            GamerTag1 = json.SelectToken("gamerTag")?.ToString();
            GamerTag2 = json.SelectToken("gamertag")?.ToString();
        }
    }
}
