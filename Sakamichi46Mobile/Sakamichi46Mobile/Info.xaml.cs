using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Share;
using Xamarin.Forms;

namespace Sakamichi46Mobile
{
    public partial class Info : ContentPage
    {
        public Info()
        {
            InitializeComponent();

            btnShare.Clicked += (o, e) => 
            {
                CrossShare.Current.ShareLink("https://github.com/kikutaro/Sakamichi46Mobile", "Sakamichi46 App");
            };
        }
    }
}
