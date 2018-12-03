using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace SampleExerciseDotNet2.Models
{
    public class Auth
    {

        public string OAuthConsumerSecret { get; set; }
        public string OAuthConsumerKey { get; set; }

        public async Task<string> GetAccessToken()
        {
            var httpClient = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, "https://api.twitter.com/oauth2/token ");
            var customerInfo = Convert.ToBase64String(new UTF8Encoding().GetBytes(OAuthConsumerKey + ":" + OAuthConsumerSecret));
            request.Headers.Add("Authorization", "Basic " + customerInfo);
            request.Content = new StringContent("grant_type=client_credentials", Encoding.UTF8, "application/x-www-form-urlencoded");

            HttpResponseMessage response = await httpClient.SendAsync(request).ConfigureAwait(false);

            string json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            var serializer = new JavaScriptSerializer();
            dynamic item = serializer.Deserialize<object>(json);

            return item["access_token"].ToString();
        }


    }
}