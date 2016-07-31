using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sakamichi46Mobile.Controller;
using Xamarin.Forms;

namespace Sakamichi46Mobile
{
    public partial class App : Application
    {
        private Menu menuPage;

        public App()
        {
            Resources = new Xamarin.Forms.Themes.LightThemeResources();
            menuPage = new Menu();
            MainPage = new NavigationPage(menuPage);
        }

        protected override void OnSleep()
        {
            menuPage.OnSleep();
        }
    }
}
