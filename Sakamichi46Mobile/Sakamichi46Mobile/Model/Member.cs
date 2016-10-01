using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sakamichi46Mobile
{
    public class Member
    {
        public string name { get; set; }
        public string birthday { get; set; }
        public string bloodType { get; set; }
        public string constellation { get; set; }
        public string profilePhotoUri { get; set; }
        public string blogUri { get; set; }
        public string goodsUri { get; set; }
        public List<string> matomeUri { get; set; }
    }
}
