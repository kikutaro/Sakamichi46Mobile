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
        public App()
        {
            MainPage = new Nogizaka46.NogiMasterDetailPage();
        }
    }
}
