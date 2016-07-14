using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sakamichi46Mobile.Constant;
using Sakamichi46Mobile.Controller;
using Xamarin.Forms;

namespace Sakamichi46Mobile.Keyakizaka46
{
    public partial class KeyakiDetailPage : TabbedPage
    {
        private KeyakiController keyakiCtrl;
        public Member selectedMember { get; set; }

        public KeyakiDetailPage()
        {
            InitializeComponent();
        }

        public KeyakiDetailPage(KeyakiController keyakiCtrl) : this()
        {
            this.keyakiCtrl = keyakiCtrl;
        }

        private void InitWebPage()
        {
            keyakiWebBlog.Source = keyakiCtrl.GetOfficialBlog().Result;
            keyakiWebGoods.Source = keyakiCtrl.GetOfficialGoods().Result;
        }

        public void ChangeWebPage(Member selectedMember)
        {
            if (selectedMember == null)
            {
                InitWebPage();
                return;
            }

            int tabIdx = Children.IndexOf(CurrentPage);
            if(tabIdx == 0)
            {
                keyakiWebBlog.Source = this.selectedMember.blogUri;
            }
            else if(tabIdx == 1)
            {
                keyakiWebGoods.Source = this.selectedMember.goodsUri;
            }
            else if(tabIdx == 2)
            {
                keyakiWebYouTube.Source = UrlConst.YOUTUBE + this.selectedMember.name;
            }
            else if(tabIdx == 3)
            {
                keyakiWikipedia.Source = UrlConst.WIKIPEDIA + this.selectedMember.name;
            }
        }
    }
}
