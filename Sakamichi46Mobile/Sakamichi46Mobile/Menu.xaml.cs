using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sakamichi46Mobile.Constant;
using Sakamichi46Mobile.Controller;
using Sakamichi46Mobile.Keyakizaka46;
using Sakamichi46Mobile.Nogizaka46;
using Plugin.Share;
using Xamarin.Forms;
using System.Net;

namespace Sakamichi46Mobile
{
    public partial class Menu : CarouselPage
    {
        private NogiMasterDetailPage nogiPage;
        private NogiController nogiCtrl;
        private List<Member> nogiMember;
        private string nogiOfficialBlog;
        private string nogiOfficialGoods;

        private KeyakiMasterDetailPage keyakiPage;
        private KeyakiController keyakiCtrl;
        private List<Member> keyakiMember;
        private string keyakiOfficialBlog;
        private string keyakiOfficialGoods;

        private bool isOffiline;

        public Menu()
        {
            InitializeComponent();

            btnNogi.Clicked += (o, e) =>
            {
                if(nogiMember == null || string.IsNullOrEmpty(nogiOfficialBlog) || string.IsNullOrEmpty(nogiOfficialGoods))
                {
                    if (isOffiline)
                    {
                        DisplayAlert(string.Empty, Message.NETWORK_DISCONNECTION, Message.OK);
                    }
                    else
                    {
                        DisplayAlert(string.Empty, Message.NOW_DOWNLOADING, Message.OK);
                    }
                    return;
                }
                nogiPage = new NogiMasterDetailPage(nogiCtrl, nogiMember, nogiOfficialBlog, nogiOfficialGoods);
                if (nogiPage != null)
                {
                    Navigation.PushModalAsync(nogiPage);
                }
            };

            btnKeyaki.Clicked += (o, e) =>
            {
                if(keyakiMember == null || string.IsNullOrEmpty(keyakiOfficialBlog) || string.IsNullOrEmpty(keyakiOfficialGoods))
                {
                    if (isOffiline)
                    {
                        DisplayAlert(string.Empty, Message.NETWORK_DISCONNECTION, Message.OK);
                    }
                    else
                    {
                        DisplayAlert(string.Empty, Message.NOW_DOWNLOADING, Message.OK);
                    }
                    return;
                }
                keyakiPage = new KeyakiMasterDetailPage(keyakiCtrl, keyakiMember, keyakiOfficialBlog, keyakiOfficialGoods);
                if (keyakiPage != null)
                {
                    Navigation.PushModalAsync(keyakiPage);
                }
            };

            btnShare.Clicked += (o, e) =>
            {
                CrossShare.Current.ShareLink("https://play.google.com/store/apps/details?id=com.sakamichi46.Sakamichi46Mobile&hl=ja", "Sakamichi46 App");
            };

            btnDevBlog.Clicked += (o, e) =>
            {
                CrossShare.Current.OpenBrowser("http://nogizaka46.hatenablog.jp/");
            };
        }

        protected async override void OnAppearing()
        {
            try
            {
                nogiCtrl = new NogiController(UrlConst.NOGI.AbsoluteUri);
                nogiMember = await nogiCtrl.RunAsync();
                Debug.WriteLine("end to download NogiMember List " + nogiMember.Count);
                nogiOfficialBlog = await nogiCtrl.GetOfficialBlog();
                Debug.WriteLine("end to download NogiOfficialBlog URL " + nogiOfficialBlog);
                nogiOfficialGoods = await nogiCtrl.GetOfficialGoods();
                Debug.WriteLine("end to download NogiOfficialGoods URL " + nogiOfficialGoods);

                keyakiCtrl = new KeyakiController(UrlConst.KEYAKI.AbsoluteUri);
                keyakiMember = await keyakiCtrl.RunAsync();
                Debug.WriteLine("end to download KeyakiMember List " + keyakiMember.Count);
                keyakiOfficialBlog = await keyakiCtrl.GetOfficialBlog();
                Debug.WriteLine("end to download KeyakiOfficialBlog URL " + keyakiOfficialBlog);
                keyakiOfficialGoods = await keyakiCtrl.GetOfficialGoods();
                Debug.WriteLine("end to download KeyakiOfficialGoods URL " + keyakiOfficialGoods);
            }
            catch(WebException e)
            {
                Debug.WriteLine("Network error " + e.Response);
                await DisplayAlert(string.Empty, Message.NETWORK_DISCONNECTION, Message.OK);
                isOffiline = true;
            }
        }

        public void OnSleep()
        {
            if(nogiPage != null) nogiPage.OnSleep();
            if(keyakiPage != null) keyakiPage.OnSleep();
        }
    }
}
