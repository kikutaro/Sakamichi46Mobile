using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Sakamichi46Mobile.Controller
{
    abstract class SakamichiController : IRestHandler<Member>
    {
        protected HttpClient httpClient;

        protected List<Member> member;

        private string url;

        protected SakamichiController(string url)
        {
            this.url = url;
            httpClient = new HttpClient();
            RunAsync().Wait();
        }

        public abstract List<Member> GetAllProfile();
        public abstract Member GetProfile(string name);

        public async Task RunAsync()
        {
            var response = httpClient.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                var ret = await response.Content.ReadAsStringAsync();
                member = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Member>>(ret);
            }
        }
    }
}
