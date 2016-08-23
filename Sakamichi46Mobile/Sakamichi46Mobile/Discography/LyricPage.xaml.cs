using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Sakamichi46Mobile.Discography
{
    public partial class LyricPage : ContentPage
    {
        public LyricPage()
        {
            InitializeComponent();
        }

        public LyricPage(string url) : this()
        {
            lyricWeb.Source = url;
        }
    }
}
