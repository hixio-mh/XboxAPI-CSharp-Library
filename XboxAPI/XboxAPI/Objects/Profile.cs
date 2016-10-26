using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace XboxAPI.Objects
{
    public class Profile
    {
        public string Id { get; protected set; }
        public string HostId { get; protected set; }
        public string GamerTag { get; protected set; }
        public string GameDisplayName { get; protected set; }
        public string AppDisplayName { get; protected set; }
        public int Gamerscore { get; protected set; }
        public string GameDisplayPicRaw { get; protected set; }
        public string AppDisplayPicRaw { get; protected set; }
        public string AccountTier { get; protected set; }
        public string XboxOneRep { get; protected set; }
        public string PreferredColor { get; protected set; }
        public int TenureLevel { get; protected set; }
        public bool IsSponsoredUser { get; protected set; }

        public Profile(JToken json)
        {
            bool isSponsoredUser;
            Id = json.SelectToken("id")?.ToString();
            HostId = json.SelectToken("hostId")?.ToString();
            GamerTag = json.SelectToken("Gamertag")?.ToString();
            GameDisplayName = json.SelectToken("GameDisplayName")?.ToString();
            AppDisplayName = json.SelectToken("AppDisplayName")?.ToString();
            Gamerscore = int.Parse(json.SelectToken("Gamerscore").ToString());
            GameDisplayPicRaw = json.SelectToken("GameDisplayPicRaw")?.ToString();
            AppDisplayPicRaw = json.SelectToken("AppDisplayPicRaw")?.ToString();
            AccountTier = json.SelectToken("AccountTier")?.ToString();
            XboxOneRep = json.SelectToken("XboxOneRep")?.ToString();
            PreferredColor = json.SelectToken("PreferredColor")?.ToString();
            TenureLevel = int.Parse(json.SelectToken("TenureLevel").ToString());
            IsSponsoredUser = bool.TryParse(json.SelectToken("isSponsoredUser")?.ToString(), out isSponsoredUser) && isSponsoredUser;
        }
    }
}
