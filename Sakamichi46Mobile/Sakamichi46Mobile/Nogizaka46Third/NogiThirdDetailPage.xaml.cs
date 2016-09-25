using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sakamichi46Mobile.Constant;
using Sakamichi46Mobile.Controller;
using Xamarin.Forms;

namespace Sakamichi46Mobile.Nogizaka46Third
{
    public partial class NogiThirdDetailPage : TabbedPage
    {
        private NogiController nogiCtrl;
        public Member selectedMember { get; set; }

        public string nogiOfficialBlog { get; set; }
        
        public string nogiOfficialGoods { get; set; }

        public NogiThirdDetailPage()
        {
            InitializeComponent();
        }

        public NogiThirdDetailPage(NogiController nogiCtrl, string nogiOfficialBlog, string nogiOfficialGoods) : this()
        {
            this.nogiCtrl = nogiCtrl;
            ChangeWebPage(null, nogiOfficialBlog, nogiOfficialGoods);
        }

        private void InitWebPage()
        {
            nogiThirdWebBlog.Source = nogiOfficialBlog;
            //nogiThirdWebGoods.Source = nogiOfficialGoods;
            nogiThirdWebYouTube.Source = UrlConst.YOUTUBE + SakamichiConst.NOGIZAKA46_THIRD;
            nogiThirdWikipedia.Source = UrlConst.WIKIPEDIA + SakamichiConst.NOGIZAKA46_THIRD;
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
                if(!string.IsNullOrEmpty(this.selectedMember.blogUri))
                {
                    nogiThirdWebBlog.Source = this.selectedMember.blogUri;
                }
                else
                {
                    var htmlNotHaveBlog = new HtmlWebViewSource();
                    htmlNotHaveBlog.Html = @"<html><body><p>ブログがまだありません。</p></body></html>";
                    nogiThirdWebBlog.Source = htmlNotHaveBlog;
                }
                
            }
            else if(tabIdx == 1)
            {
                nogiThirdWebYouTube.Source = UrlConst.YOUTUBE + this.selectedMember.name;
            }
            else if(tabIdx == 2)
            {
                nogiThirdWikipedia.Source = UrlConst.WIKIPEDIA + this.selectedMember.name;
            }
            else if(tabIdx == 3)
            {
                //nogiThirdWebGoods.Source = this.selectedMember.goodsUri;
            }
        }

        private WebView GetCurrentWebView()
        {
            int tabIdx = Children.IndexOf(CurrentPage);
            if (tabIdx == 0)
            {
                return nogiThirdWebBlog;
            }
            else if (tabIdx == 1)
            {
                return nogiThirdWebYouTube;
            }
            else if (tabIdx == 2)
            {
                return nogiThirdWikipedia;
            }
            //else if (tabIdx == 3)
            //{
            //    return nogiThirdWebGoods;
            //}
            return nogiThirdWebBlog;
        }

        public void PageBack(Object sender, EventArgs e)
        {
            if(GetCurrentWebView().CanGoBack)
            {
                GetCurrentWebView().GoBack();
            }
        }

        public void PageForward(Object sender, EventArgs e)
        {
            if(GetCurrentWebView().CanGoForward)
            {
                GetCurrentWebView().GoForward();
            }
        }

        public void OnSleep()
        {
            //Sleep時にYouTube再生を止める
            nogiThirdWebYouTube.Source = "about:blank";
        }
    }
}
