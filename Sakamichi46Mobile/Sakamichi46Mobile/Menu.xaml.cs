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
using Sakamichi46Mobile.HiraganaKeyaki;
using Sakamichi46Mobile.Discography;
using Sakamichi46Mobile.Nogizaka46Third;
using Sakamichi46Mobile.Model;

namespace Sakamichi46Mobile
{
    public partial class Menu : CarouselPage
    {
        private NogiMasterDetailPage nogiPage;
        private NogiController nogiCtrl;
        private List<Member> nogiMember;
        private string nogiOfficialBlog;
        private string nogiMatome;
        private string nogiOfficialGoods;

        private KeyakiMasterDetailPage keyakiPage;
        private KeyakiController keyakiCtrl;
        private List<Member> keyakiMember;
        private string keyakiOfficialBlog;
        private string keyakiMatome;
        private string keyakiOfficialGoods;

        private HiraMasterDetailPage hiraPage;
        private HiraController hiraCtrl;
        private List<Member> hiraMember;
        private string hiraOfficialBlog;
        private string hiraMatome;
        private string hiraOfficialGoods;

        private NogiThirdMasterDetailPage nogiThirdPage;
        private NogiThirdController nogiThirdCtrl;
        private List<Member> nogiThirdMember;
        private string nogiThirdOfficialBlog;
        private string nogiThirdMatome;
        private string nogiThirdOfficialGoods;

        private DiscographyPage discoPage;

        private bool isOffiline;

        public Menu()
        {
            InitializeComponent();

            btnDiscography.Clicked += (o, e) =>
            {
                discoPage = new DiscographyPage(nogiCtrl, keyakiCtrl);
                Navigation.PushModalAsync(discoPage);
            };

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
                nogiPage = new NogiMasterDetailPage(nogiCtrl, nogiMember, new SakamichiUrl { OfficialBlogUrl = nogiOfficialBlog, MatomeUrl = nogiMatome, OfficialGoodsUrl = nogiOfficialGoods });
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
                keyakiPage = new KeyakiMasterDetailPage(keyakiCtrl, keyakiMember, new SakamichiUrl { OfficialBlogUrl = keyakiOfficialBlog, MatomeUrl = keyakiMatome, OfficialGoodsUrl = keyakiOfficialGoods });
                if (keyakiPage != null)
                {
                    Navigation.PushModalAsync(keyakiPage);
                }
            };

            btnHira.Clicked += (o, e) =>
            {
                if (hiraMember == null || string.IsNullOrEmpty(hiraOfficialBlog) || string.IsNullOrEmpty(hiraOfficialGoods))
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
                hiraPage = new HiraMasterDetailPage(hiraCtrl, hiraMember, new SakamichiUrl { OfficialBlogUrl = hiraOfficialBlog, MatomeUrl = hiraMatome, OfficialGoodsUrl = hiraOfficialGoods });
                if (hiraPage != null)
                {
                    Navigation.PushModalAsync(hiraPage);
                }
            };

            btnNogi3rd.Clicked += (o, e) =>
            {
                if (nogiThirdMember == null || string.IsNullOrEmpty(nogiThirdOfficialBlog) || string.IsNullOrEmpty(nogiThirdOfficialGoods))
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
                nogiThirdPage = new NogiThirdMasterDetailPage(nogiThirdCtrl, nogiThirdMember, nogiThirdOfficialBlog, nogiThirdOfficialGoods);
                if (nogiThirdPage != null)
                {
                    Navigation.PushModalAsync(nogiThirdPage);
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
                nogiMatome = await nogiCtrl.GetMatome();
                Debug.WriteLine("end to download NogiMatome URL " + nogiMatome);
                nogiOfficialGoods = await nogiCtrl.GetOfficialGoods();
                Debug.WriteLine("end to download NogiOfficialGoods URL " + nogiOfficialGoods);

                keyakiCtrl = new KeyakiController(UrlConst.KEYAKI.AbsoluteUri);
                keyakiMember = await keyakiCtrl.RunAsync();
                Debug.WriteLine("end to download KeyakiMember List " + keyakiMember.Count);
                keyakiOfficialBlog = await keyakiCtrl.GetOfficialBlog();
                Debug.WriteLine("end to download KeyakiOfficialBlog URL " + keyakiOfficialBlog);
                keyakiMatome = await keyakiCtrl.GetMatome();
                Debug.WriteLine("end to download KeyakiMatome URL " + keyakiMatome);
                keyakiOfficialGoods = await keyakiCtrl.GetOfficialGoods();
                Debug.WriteLine("end to download KeyakiOfficialGoods URL " + keyakiOfficialGoods);

                hiraCtrl = new HiraController(UrlConst.HIRA.AbsoluteUri);
                hiraMember = await hiraCtrl.RunAsync();
                Debug.WriteLine("end to download HiraganaKeyakiMember List " + hiraMember.Count);
                hiraOfficialBlog = await keyakiCtrl.GetOfficialBlog();
                Debug.WriteLine("end to download HiraganaKeyakiOfficialBlog URL " + hiraOfficialBlog);
                hiraMatome = await hiraCtrl.GetMatome();
                Debug.WriteLine("end to download HiraganaKeyakiMatome URL " + hiraMatome);
                hiraOfficialGoods = await keyakiCtrl.GetOfficialGoods();
                Debug.WriteLine("end to download HiraganaKeyakiOfficialGoods URL " + hiraOfficialGoods);

                nogiThirdCtrl = new NogiThirdController(UrlConst.NOGI3.AbsoluteUri);
                nogiThirdMember = await nogiThirdCtrl.RunAsync();
                Debug.WriteLine("end to download NogiThirdMember List " + nogiThirdMember.Count);
                nogiThirdOfficialBlog = await nogiThirdCtrl.GetOfficialBlog();
                Debug.WriteLine("end to download NogiThirdOfficialBlog URL " + nogiThirdOfficialBlog);
                nogiThirdMatome = await nogiThirdCtrl.GetMatome();
                Debug.WriteLine("end to download NogiThirdMatome URL " + nogiThirdMatome);

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
