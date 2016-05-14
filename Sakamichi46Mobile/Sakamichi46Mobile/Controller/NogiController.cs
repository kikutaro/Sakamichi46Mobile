using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Sakamichi46Mobile.Controller
{
    class NogiController : IRestHandler<Member>
    {
        HttpClient httpClient;

        List<Member> nogiMember;

        public NogiController()
        {
            httpClient = new HttpClient();
            RunAsync().Wait();
        }

        public List<Member> GetAllProfile()
        {
            return nogiMember;
        }

        public async Task RunAsync()
        {
            var response = httpClient.GetAsync("http://46api.sakamichi46.com/sakamichi46api/api/nogizaka46/profile").Result;
            if(response.IsSuccessStatusCode)
            {
                var ret = await response.Content.ReadAsStringAsync();
                nogiMember = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Member>>(ret);
            }
        }

        public Member GetProfile(string name)
        {
            throw new NotImplementedException();
        }
    }
}
