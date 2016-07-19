using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sakamichi46Mobile.Model;
using Xamarin.Forms;

namespace Sakamichi46Mobile
{
    public partial class Info : ContentPage
    {
        public ObservableCollection<InfoGroup> infoGroups;

        public Info()
        {
            InitializeComponent();

            infoGroups = new ObservableCollection<InfoGroup>();
            InfoGroup setting = new InfoGroup("設定", "設定");
            InfoGroup other = new InfoGroup("その他", "その他");
            infoGroups.Add(setting);
            infoGroups.Add(other);

            other.Add(new InfoItem("ご意見・ご要望"));
            other.Add(new InfoItem("シェア"));

            infoView.ItemsSource = infoGroups;
        }
    }
}
