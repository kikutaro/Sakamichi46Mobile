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
        public Member selectedMember { get; set; }

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
            if(selectedMember != null)
            {
                this.selectedMember = selectedMember;
            } 

            int tabIdx = Children.IndexOf(CurrentPage);
            if(tabIdx == 0)
            {
                nogiWebBlog.Source = this.selectedMember.blogUri;
            }
            else if(tabIdx == 1)
            {
                nogiWebGoods.Source = this.selectedMember.goodsUri;
            }
        }
    }
}
