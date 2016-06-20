using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sakamichi46Mobile.Constant;
using Sakamichi46Mobile.Controller;
using Xamarin.Forms;

namespace Sakamichi46Mobile.Nogizaka46
{
    public partial class NogiDetailPage : TabbedPage
    {
        public NogiDetailPage()
        {
            InitializeComponent();
        }

        public NogiDetailPage(NogiController nogiCtrl) : this()
        {
            nogiWebBlog.Source = nogiCtrl.GetOfficialBlog().Result;
            nogiWebGoods.Source = nogiCtrl.GetOfficialGoods().Result;
        }

        public void ChangeWebPage(Member selectedMember)
        {
            nogiWebBlog.Source = selectedMember.blogUri;
        }
    }
}
