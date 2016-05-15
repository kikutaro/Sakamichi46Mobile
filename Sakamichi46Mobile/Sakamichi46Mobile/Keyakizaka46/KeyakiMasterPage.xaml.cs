using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sakamichi46Mobile.Controller;
using Xamarin.Forms;

namespace Sakamichi46Mobile.Keyakizaka46
{
    public partial class KeyakiMasterPage : ContentPage
    {
        public ListView KeyakiListView { get { return keyakiListView; } }

        public KeyakiMasterPage()
        {
            InitializeComponent();

            KeyakiController keyaki = new KeyakiController("http://46api.sakamichi46.com/sakamichi46api/api/keyakizaka46/profile");
            KeyakiListView.ItemsSource = new ObservableCollection<Member>(keyaki.GetAllProfile());
        }
    }
}
