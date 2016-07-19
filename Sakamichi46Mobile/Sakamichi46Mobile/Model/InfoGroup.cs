using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sakamichi46Mobile.Model
{
    public class InfoGroup : ObservableCollection<InfoItem>
    {
        public string Title { get; set; }

        public string ShortName { get; set; }

        public InfoGroup(string title, string shortName)
        {
            this.Title = title;
            this.ShortName = shortName;
        }
    }
}
