using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Sakamichi46Mobile.Constant;

namespace Sakamichi46Mobile.Controller
{
    public abstract class SakamichiController : IRestHandler<Member>
    {
        protected HttpClient httpClient;

        protected List<Member> member;

        private Uri baseUrl;

        protected SakamichiController(string baseUrl)
        {
            this.baseUrl = new Uri(baseUrl);
            httpClient = new HttpClient(); 
        }

        public abstract List<Member> GetAllProfile();

        
        public abstract Member GetProfile(string name);

        public async Task<List<Member>> RunAsync()
        {
            Uri profileUrl = new Uri(baseUrl, UrlConst.PROFILE);
            var response = await httpClient.GetAsync(profileUrl.AbsoluteUri);
            if (response.IsSuccessStatusCode)
            {
                var ret = await response.Content.ReadAsStringAsync();
                member = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Member>>(ret);
            }
            return member;
        }

        public async Task<string> GetOfficialBlog()
        {
            Uri blogUrl = new Uri(baseUrl, UrlConst.BLOG);
            var response = await httpClient.GetAsync(blogUrl.AbsoluteUri);
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<String> GetOfficialGoods()
        {
            Uri goodsUrl = new Uri(baseUrl, UrlConst.GOODS);
            var response = httpClient.GetAsync(goodsUrl.AbsoluteUri).Result;
            return await response.Content.ReadAsStringAsync();
        }
    }
}
