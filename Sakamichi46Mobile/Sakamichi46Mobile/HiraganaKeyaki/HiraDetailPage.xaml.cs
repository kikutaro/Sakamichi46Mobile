using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sakamichi46Mobile.Constant;
using Sakamichi46Mobile.Controller;
using Xamarin.Forms;

namespace Sakamichi46Mobile.HiraganaKeyaki
{
    public partial class HiraDetailPage : TabbedPage
    {
        private HiraController hiraCtrl;

        public Member selectedMember { get; set; }

        public string hiraOfficialBlog { get; set; }

        public string hiraOfficialGoods { get; set; }

        public HiraDetailPage()
        {
            InitializeComponent();
        }

        public HiraDetailPage(HiraController hiraCtrl, string hiraOfficialBlog, string hiraOfficialGoods) : this()
        {
            this.hiraCtrl = hiraCtrl;
            ChangeWebPage(null, hiraOfficialBlog, hiraOfficialGoods);
        }

        private void InitWebPage()
        {
            hiraWebBlog.Source = hiraOfficialBlog;
            hiraWebGoods.Source = hiraOfficialGoods;
            hiraWebYouTube.Source = UrlConst.YOUTUBE + SakamichiConst.HIRAGANA_KEYAKI;
            hiraWikipedia.Source = UrlConst.WIKIPEDIA + SakamichiConst.HIRAGANA_KEYAKI;
        }

        public void ChangeWebPage(Member selectedMember, string hiraOfficialBlog, string hiraOfficialGoods)
        {
            this.hiraOfficialBlog = hiraOfficialBlog;
            this.hiraOfficialGoods = hiraOfficialGoods;
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
