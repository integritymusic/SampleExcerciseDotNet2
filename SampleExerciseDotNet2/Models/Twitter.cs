using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Configuration;

namespace SampleExerciseDotNet2.Models
{
    public class Twitter
    {

        public async Task<IEnumerable<string>> GetTweets(string userName, int count, string accessToken = null)
        {
            if (accessToken == null)
            {
                Auth auth = new Auth
                {
                    OAuthConsumerKey = ConfigurationManager.AppSettings["OAuthConsumerKey"],
                    OAuthConsumerSecret = ConfigurationManager.AppSettings["OAuthConsumerSecret"]
                };

                accessToken = await auth.GetAccessToken().ConfigureAwait(false);
            }

            var requestUserTimeline = new HttpRequestMessage(HttpMethod.Get, string.Format("https://api.twitter.com/1.1/statuses/user_timeline.json?count={0}&screen_name={1}&trim_user=1&exclude_replies=1", count, userName));
            requestUserTimeline.Headers.Add("Authorization", "Bearer " + accessToken);
            var httpClient = new HttpClient();
            HttpResponseMessage responseUserTimeLine = await httpClient.SendAsync(requestUserTimeline);
            var serializer = new JavaScriptSerializer();
            dynamic json = serializer.Deserialize<object>(await responseUserTimeLine.Content.ReadAsStringAsync());
            var enumerableTwitts = (json as IEnumerable<dynamic>);

            if (enumerableTwitts == null)
            {
                return null;
            }
            return enumerableTwitts.Select(t => (string)(t["id"].ToString() + "-~- " + t["text"].ToString()));
        }
    }
}