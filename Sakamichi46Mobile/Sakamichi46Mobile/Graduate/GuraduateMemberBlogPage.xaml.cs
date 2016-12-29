using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Sakamichi46Mobile.Graduate
{
    public partial class GuraduateMemberBlogPage : ContentPage
    {
        public GuraduateMemberBlogPage()
        {
            InitializeComponent();
        }

        public GuraduateMemberBlogPage(string url) : this()
        {
            graduateMemberBlogWeb.Source = url;
        }
    }
}
