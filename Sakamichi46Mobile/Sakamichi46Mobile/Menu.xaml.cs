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
                Navigation.PushModalAsync(new Keyakizaka46.KeyakiMasterDetailPage());
            };

            btnHira.Clicked += (o, e) =>
            {
                Navigation.PushModalAsync(new HiraganaKeyaki.HiraMasterDetailPage());
            };
        }
    }
}
