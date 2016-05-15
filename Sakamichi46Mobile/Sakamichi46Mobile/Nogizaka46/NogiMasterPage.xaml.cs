using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sakamichi46Mobile.Controller;
using Xamarin.Forms;

namespace Sakamichi46Mobile.Nogizaka46
{
    public partial class NogiMasterPage : ContentPage
    {
        public ListView NogiListView { get { return nogiListView; } }

        public NogiMasterPage()
        {
            InitializeComponent();

            NogiController nogi = new NogiController("http://46api.sakamichi46.com/sakamichi46api/api/nogizaka46/profile");
            nogiListView.ItemsSource = new ObservableCollection<Member>(nogi.GetAllProfile());
        }
    }
}
