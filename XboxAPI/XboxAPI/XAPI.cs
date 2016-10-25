using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace XboxAPI
{
    public static class XAPI
    {
        private static string xboxAPIKey;

        public static void SetXboxAPIKey(string key)
        {
            xboxAPIKey = key;
        }

        public async static Task<Objects.Profile> GetMyProfile()
        {
            return new Objects.Profile(JObject.Parse(await MakeGetRequest("https://xboxapi.com/v2/profile")));
        }

        public async static Task<Objects.AccountXuid> GetMyAccountXuid()
        {
            return new Objects.AccountXuid(JObject.Parse(await MakeGetRequest("https://xboxapi.com/v2/accountXuid")));
        }

        public async static Task<List<Objects.Message>> GetMyMessages()
        {
            List<Objects.Message> messages = new List<Objects.Message>();
            string resp = await MakeGetRequest("https://xboxapi.com/v2/messages");
            JToken json = JArray.Parse(resp);
            foreach(JToken message in json)
                messages.Add(new Objects.Message(message));
            return messages;
        }

        #region Internals
        private static async Task<string> MakeGetRequest(string url)
        {
            if (string.IsNullOrEmpty(xboxAPIKey))
                throw new Exceptions.XboxAPIKeyNotSetException();

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(new Uri(url));
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Headers.Add("X-Auth", xboxAPIKey);

            try
            {
                using (var responseStream = await request.GetResponseAsync())
                {
                    return await new StreamReader(responseStream.GetResponseStream(), Encoding.Default, true).ReadToEndAsync();
                }
            }
            catch (WebException e) { handleWebException(e); return null; }

        }

        private static async Task<string> MakeRestRequest(string url, string method, string requestData = null)
        {
            if (string.IsNullOrEmpty(xboxAPIKey))
                throw new Exceptions.XboxAPIKeyNotSetException();

            var data = new UTF8Encoding().GetBytes(requestData ?? "");

            var request = (HttpWebRequest)WebRequest.Create(new Uri(url));
            request.Method = method;
            request.Accept = "application/vnd.twitchtv.v3+json";
            request.ContentType = method == "POST"
                ? "application/x-www-form-urlencoded"
                : "application/json";
            request.Headers.Add("X-Auth", xboxAPIKey);

            using (var requestStream = await request.GetRequestStreamAsync())
            {
                await requestStream.WriteAsync(data, 0, data.Length);
            }

            try
            {
                using (var responseStream = await request.GetResponseAsync())
                {
                    return await new StreamReader(responseStream.GetResponseStream(), Encoding.Default, true).ReadToEndAsync();
                }
            }
            catch (WebException e) { handleWebException(e); return null; }

        }

        private static void handleWebException(WebException e)
        {
            HttpWebResponse errorResp = e.Response as HttpWebResponse;
            switch (errorResp.StatusCode)
            {
                case HttpStatusCode.Unauthorized:
                    throw new Exceptions.BadAPIKeyException(xboxAPIKey);
                default:
                    throw e;
            }
        }
        #endregion
    }
}
