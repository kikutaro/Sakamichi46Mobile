using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sakamichi46Mobile.Controller
{
    public class HiraController : SakamichiController
    {
        public HiraController(string url) : base(url)
        {
        }

        public override List<Member> GetAllProfile()
        {
            return member;
        }

        public override Member GetProfile(string name)
        {
            throw new NotImplementedException();
        }
    }
}
