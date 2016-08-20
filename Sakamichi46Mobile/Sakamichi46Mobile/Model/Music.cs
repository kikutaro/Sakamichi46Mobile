using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sakamichi46Mobile.Model
{
    public class Music
    {
        public string title { get; set; }

        public string releaseVersion { get; set; }

        public string releaseDate { get; set; }

        public string lyricUri { get; set; }

        public string coverPhotoUri { get; set; }

        public string officialMovieUri { get; set; }

        public string type { get; set; }

        public Music(string title)
        {
            this.title = title;
        }
    }
}
