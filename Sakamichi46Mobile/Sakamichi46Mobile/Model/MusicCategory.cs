using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sakamichi46Mobile.Model
{
    public class MusicCategory : List<Music>
    {
        public string releaseVersion { get; set; }

        public MusicCategory(string releaseVersion)
        {
            this.releaseVersion = releaseVersion;
            
        }
    }
}
