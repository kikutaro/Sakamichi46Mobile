using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sakamichi46Mobile.Constant;
using Sakamichi46Mobile.Controller;
using Xamarin.Forms;

namespace Sakamichi46Mobile
{
    public partial class Menu : ContentPage
    {
        public bool isLoad { get; set; }

        public Menu()
        {
            InitializeComponent();

            isLoad = true;
            btnNogi.Opacity = 0.5;
            nogiIndicator.IsRunning = true;

            Nogizaka46.NogiMasterDetailPage nogiPage = null;
            Keyakizaka46.KeyakiMasterDetailPage keyakiPage = null;

            NogiController nogiCtrl = new NogiController(UrlConst.NOGI.AbsoluteUri);
            nogiCtrl.RunAsync().ContinueWith((t) =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    isLoad = false;
                    btnNogi.Opacity = 1.0;
                    nogiIndicator.IsRunning = false;
                    nogiPage = new Nogizaka46.NogiMasterDetailPage(nogiCtrl, t.Result);
                });
            });
            KeyakiController keyakiCtrl = new KeyakiController(UrlConst.KEYAKI.AbsoluteUri);
            keyakiCtrl.RunAsync().ContinueWith((t) =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    isLoad = false;
                    btnNogi.Opacity = 1.0;
                    nogiIndicator.IsRunning = false;
                    keyakiPage = new Keyakizaka46.KeyakiMasterDetailPage(keyakiCtrl, t.Result);
                });
            });

            string blog = nogiCtrl.GetOfficialBlog().Result;

            btnNogi.Clicked += (o, e) =>
            {
                if(nogiPage != null)
                {
                    Navigation.PushModalAsync(nogiPage);
                }
                
            };

            btnKeyaki.Clicked += (o, e) =>
            {
                if(keyakiPage != null)
                {
                    Navigation.PushModalAsync(keyakiPage);
                }
            };

            btnHira.Clicked += (o, e) =>
            {
                Navigation.PushModalAsync(new HiraganaKeyaki.HiraMasterDetailPage());
            };
        }
    }
}
