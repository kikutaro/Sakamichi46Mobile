using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Sakamichi46Mobile
{
    public partial class Menu : ContentPage
    {
        public Menu()
        {
            InitializeComponent();

            btnNogi.Clicked += (o, e) =>
            {
                Navigation.PushModalAsync(new Nogizaka46.NogiMasterDetailPage());
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
