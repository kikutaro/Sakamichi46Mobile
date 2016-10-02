using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sakamichi46Mobile.Constant;
using Sakamichi46Mobile.Controller;
using Sakamichi46Mobile.Model;
using Xamarin.Forms;

namespace Sakamichi46Mobile.HiraganaKeyaki
{
    public partial class HiraDetailPage : TabbedPage
    {
        private HiraController hiraCtrl;

        public Member selectedMember { get; set; }

        public SakamichiUrl hiraUrl;

        public HiraDetailPage()
        {
            InitializeComponent();
        }

        public HiraDetailPage(HiraController hiraCtrl, SakamichiUrl hiraUrl) : this()
        {
            this.hiraCtrl = hiraCtrl;
            this.hiraUrl = hiraUrl;
            ChangeWebPage(null, hiraUrl);
        }

        private void InitWebPage()
        {
            hiraWebBlog.Source = hiraUrl.OfficialBlogUrl;
            hiraWebMatome.Source = hiraUrl.MatomeUrl;
            hiraWebGoods.Source = hiraUrl.OfficialGoodsUrl;
            hiraWebYouTube.Source = UrlConst.YOUTUBE + SakamichiConst.HIRAGANA_KEYAKI;
            hiraWikipedia.Source = UrlConst.WIKIPEDIA + SakamichiConst.HIRAGANA_KEYAKI;
        }

        public void ChangeWebPage(Member selectedMember, SakamichiUrl hiraUrl)
        {
            this.hiraUrl = hiraUrl;
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
            if (tabIdx == 0)
            {
                hiraWebBlog.Source = this.selectedMember.blogUri;
            }
            else if (tabIdx == 1)
            {
                hiraWebYouTube.Source = UrlConst.YOUTUBE + this.selectedMember.name;
            }
            else if (tabIdx == 2)
            {
                hiraWikipedia.Source = UrlConst.WIKIPEDIA + this.selectedMember.name;
            }
            else if (tabIdx == 3)
            {
                hiraWebMatome.Source = this.selectedMember.matomeUri[0];
            }
            else if (tabIdx == 4)
            {
                hiraWebGoods.Source = this.selectedMember.goodsUri;
            }
        }

        private WebView GetCurrentWebView()
        {
            int tabIdx = Children.IndexOf(CurrentPage);
            if (tabIdx == 0)
            {
                return hiraWebBlog;
            }
            else if (tabIdx == 1)
            {
                return hiraWebYouTube;
            }
            else if (tabIdx == 2)
            {
                return hiraWikipedia;
            }
            else if (tabIdx == 3)
            {
                return hiraWebMatome;
            }
            else if (tabIdx == 4)
            {
                return hiraWebGoods;
            }
            return hiraWebBlog;
        }

        public void PageBack(Object sender, EventArgs e)
        {
            if (GetCurrentWebView().CanGoBack)
            {
                GetCurrentWebView().GoBack();
            }
        }

        public void PageForward(Object sender, EventArgs e)
        {
            if (GetCurrentWebView().CanGoForward)
            {
                GetCurrentWebView().GoForward();
            }
        }

        public void OnSleep()
        {
            //Sleep時にYouTube再生を止める
            hiraWebYouTube.Source = "about:blank";
        }
    }
}
