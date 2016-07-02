using System;
using System.Collections.Generic;

namespace Sakamichi46Mobile.Controller
{
    public class KeyakiController : SakamichiController
    {
        public KeyakiController(string url) : base(url)
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
