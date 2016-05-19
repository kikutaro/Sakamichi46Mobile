using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sakamichi46Mobile.Controller;
using Xamarin.Forms;

namespace Sakamichi46Mobile.HiraganaKeyaki
{
    public partial class HiraMasterPage : ContentPage
    {
        public ListView HiraganaListView { get { return hiraganaListView; } }

        public HiraMasterPage()
        {
            InitializeComponent();

            HiraController hiragana = new HiraController("http://46api.sakamichi46.com/sakamichi46api/api/hiraganakeyaki/profile");
            HiraganaListView.ItemsSource = new ObservableCollection<Member>(hiragana.GetAllProfile());
        }
    }
}
