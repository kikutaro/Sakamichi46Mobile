using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sakamichi46Mobile.Constant;
using Sakamichi46Mobile.Controller;
using Sakamichi46Mobile.Model;
using Xamarin.Forms;

namespace Sakamichi46Mobile.Nogizaka46Third
{
    public partial class NogiThirdDetailPage : TabbedPage
    {
        private NogiController nogiCtrl;
        public Member selectedMember { get; set; }

        public SakamichiUrl nogiThirdUrl;

        public NogiThirdDetailPage()
        {
            InitializeComponent();
        }

        public NogiThirdDetailPage(NogiController nogiCtrl, SakamichiUrl nogiThirdUrl) : this()
        {
            this.nogiCtrl = nogiCtrl;
            this.nogiThirdUrl = nogiThirdUrl;
            ChangeWebPage(null, nogiThirdUrl);
        }

        private void InitWebPage()
        {
            nogiThirdWebBlog.Source = nogiThirdUrl.OfficialBlogUrl;
            nogiThirdWebYouTube.Source = UrlConst.YOUTUBE + SakamichiConst.NOGIZAKA46_THIRD;
        }

        public void ChangeWebPage(Member selectedMember, SakamichiUrl nogiThirdUrl)
        {
            this.nogiThirdUrl = nogiThirdUrl;
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
