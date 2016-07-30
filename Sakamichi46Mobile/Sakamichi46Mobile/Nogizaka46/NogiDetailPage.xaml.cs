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
        private NogiController nogiCtrl;
        public Member selectedMember { get; set; }

        public string nogiOfficialBlog { get; set; }
        
        public string nogiOfficialGoods { get; set; }

        public NogiDetailPage()
        {
            InitializeComponent();
        }

        public NogiDetailPage(NogiController nogiCtrl, string nogiOfficialBlog, string nogiOfficialGoods) : this()
        {
            this.nogiCtrl = nogiCtrl;
            ChangeWebPage(null, nogiOfficialBlog, nogiOfficialGoods);
        }

        private void InitWebPage()
        {
            nogiWebBlog.Source = nogiOfficialBlog;
            nogiWebGoods.Source = nogiOfficialGoods;
            nogiWebYouTube.Source = UrlConst.YOUTUBE + SakamichiConst.NOGIZAKA46;
            nogiWikipedia.Source = UrlConst.WIKIPEDIA + SakamichiConst.NOGIZAKA46;
        }

        public void ChangeWebPage(Member selectedMember, string nogiOfficialBlog, string nogiOfficialGoods)
        {
            this.nogiOfficialBlog = nogiOfficialBlog;
            this.nogiOfficialGoods = nogiOfficialGoods;
            ChangeWebPage(selectedMember);
        }

        public void ChangeWebPage(Member selectedMember)
        {
            if(selectedMember == null)
            {
                InitWebPage();
                return;
            }
            this.selectedMember = selectedMember;

            int tabIdx = Children.IndexOf(CurrentPage);
            if(tabIdx == 0)
            {
                nogiWebBlog.Source = this.selectedMember.blogUri;
            }
            else if(tabIdx == 1)
            {
                nogiWebYouTube.Source = UrlConst.YOUTUBE + this.selectedMember.name;
            }
            else if(tabIdx == 2)
            {
                nogiWikipedia.Source = UrlConst.WIKIPEDIA + this.selectedMember.name;
            }
            else if(tabIdx == 3)
            {
                nogiWebGoods.Source = this.selectedMember.goodsUri;
            }
        }
    }
}
