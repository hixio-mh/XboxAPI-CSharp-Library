using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace XboxAPI.Objects
{
    public class AccountProfile
    {
        public string UserKey { get; protected set; }
        public List<string> AdministeredConsoles { get; protected set; }
        public string DateOfBirth { get; protected set; }
        public string Email { get; protected set; }
        public string FirstName { get; protected set; }
        public string GamerTag { get; protected set; }
        public HomeAddressInfoObj HomeAddressInfo { get; protected set; }
        public string HomeConsole { get; protected set; }
        public string ImageUrl { get; protected set; }
        public bool IsAdult { get; protected set; }
        public string LastName { get; protected set; }
        public string LegalCountry { get; protected set; }
        public string Locale { get; protected set; }
        public bool MsftOptin { get; protected set; }
        public string OwnerHash { get; protected set; }
        public string OwnerXuid { get; protected set; }
        public string MidasConsole { get; protected set; }
        public bool PartnerOptIn { get; protected set; }
        public string UserHash { get; protected set; }
        public string UserXuid { get; protected set; }
        public string ToUAcceptanceDate { get; protected set; }
        public string GamerTagChangeReason { get; protected set; }

        public AccountProfile(JToken json)
        {
            bool isAdult, msftOptIn, partnerOptin;

            UserKey = json.SelectToken("userKey")?.ToString();
            if (json.SelectToken("administeredConsoles") != null)
                foreach (JToken console in json.SelectToken("administeredConsoles"))
                    AdministeredConsoles.Add(console.ToString());
            DateOfBirth = json.SelectToken("dateOfBirth")?.ToString();
            Email = json.SelectToken("email")?.ToString();
            FirstName = json.SelectToken("firstName")?.ToString();
            GamerTag = json.SelectToken("gamerTag")?.ToString();
            if (json.SelectToken("homeAddressInfo") != null)
                HomeAddressInfo = new HomeAddressInfoObj(json.SelectToken("homeAddressInfo"));
            HomeConsole = json.SelectToken("homeConsole")?.ToString();
            ImageUrl = json.SelectToken("homeUrl")?.ToString();
            IsAdult = bool.TryParse(json.SelectToken("isAdult").ToString(), out isAdult) && isAdult;
            LastName = json.SelectToken("lastName")?.ToString();
            LegalCountry = json.SelectToken("legalCountry")?.ToString();
            Locale = json.SelectToken("locale")?.ToString();
            MsftOptin = bool.TryParse(json.SelectToken("msftOptin").ToString(), out msftOptIn) && msftOptIn;
            OwnerHash = json.SelectToken("ownerHash")?.ToString();
            OwnerXuid = json.SelectToken("ownerXuid")?.ToString();
            MidasConsole = json.SelectToken("midasConsole")?.ToString();
            PartnerOptIn = bool.TryParse(json.SelectToken("partnerOptin").ToString(), out partnerOptin) && partnerOptin;
            UserHash = json.SelectToken("userHash")?.ToString();
            UserXuid = json.SelectToken("userXuid")?.ToString();
            ToUAcceptanceDate = json.SelectToken("touAcceptanceDate")?.ToString();
            GamerTagChangeReason = json.SelectToken("gamerTagChangeReason")?.ToString();
        }

        public class HomeAddressInfoObj
        {
            public string Street1 { get; protected set; }
            public string Street2 { get; protected set; }
            public string City { get; protected set; }
            public string State { get; protected set; }
            public string PostalCode { get; protected set; }
            public string Country { get; protected set; }

            public HomeAddressInfoObj(JToken json)
            {
                Street1 = json.SelectToken("street1")?.ToString();
                Street2 = json.SelectToken("street2")?.ToString();
                City = json.SelectToken("city")?.ToString();
                State = json.SelectToken("state")?.ToString();
                Country = json.SelectToken("country")?.ToString();
            }
        }
    }
}
