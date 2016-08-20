using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sakamichi46Mobile.Constant
{
    class UrlConst
    {
        public static readonly Uri SAKAMICHI_ROOT_API = new Uri("http://46api.sakamichi46.com/sakamichi46api/api/");

        public static readonly Uri NOGI = new Uri(SAKAMICHI_ROOT_API, "nogizaka46/");

        public static readonly Uri KEYAKI = new Uri(SAKAMICHI_ROOT_API, "keyakizaka46/");

        public static readonly Uri HIRA = new Uri(SAKAMICHI_ROOT_API, "hiraganakeyaki/");

        public const string PROFILE = "profile";

        public const string BLOG = "blog/mobile";

        public const string GOODS = "goods/mobile";

        public const string MUSIC = "music";

        public const string YOUTUBE = "https://www.youtube.com/results?search_query=";

        public const string WIKIPEDIA = "https://ja.wikipedia.org/wiki/";
    }
}
