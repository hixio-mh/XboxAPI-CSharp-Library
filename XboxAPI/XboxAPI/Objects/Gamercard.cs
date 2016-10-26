using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace XboxAPI.Objects
{
    public class Gamercard
    {
        public string GamerTag { get; protected set; }
        public string Name { get; protected set; }
        public string Location { get; protected set; }
        public string Bio { get; protected set; }
        public int Gamerscore { get; protected set; }
        public string Tier { get; protected set; }
        public string Motto { get; protected set; }
        public string AvatarBodyImagePath { get; protected set; }
        public string GamerpicSmallImagePath { get; protected set; }
        public string GamerpicLargeImagePath { get; protected set; }
        public string GamerpicSmallSslImagePath { get; protected set; }
        public string GamerpicLargeSslImagePath { get; protected set; }
        public string AvatarManifest { get; protected set; }

        public Gamercard(JToken json)
        {
            GamerTag = json.SelectToken("gamertag")?.ToString();
            Name = json.SelectToken("name")?.ToString();
            Location = json.SelectToken("location")?.ToString();
            Bio = json.SelectToken("bio")?.ToString();
            Gamerscore = int.Parse(json.SelectToken("gamerscore").ToString());
            Tier = json.SelectToken("tier")?.ToString();
            Motto = json.SelectToken("motto")?.ToString();
            AvatarBodyImagePath = json.SelectToken("avatarBodyImagePath")?.ToString();
            GamerpicSmallImagePath = json.SelectToken("gamerpicSmallImagePath")?.ToString();
            GamerpicLargeImagePath = json.SelectToken("gamerpicLargeImagePath")?.ToString();
            GamerpicSmallSslImagePath = json.SelectToken("gamerpicSmallSslImagePath")?.ToString();
            GamerpicLargeSslImagePath = json.SelectToken("gamerpicLargeSslImagePath")?.ToString();
            AvatarManifest = json.SelectToken("avatarManifest")?.ToString();
        }
    }
}
