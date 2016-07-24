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
    public partial class KeyakiMasterDetailPage : MasterDetailPage
    {
        public KeyakiMasterDetailPage()
        {
            InitializeComponent();
        }

        public KeyakiMasterDetailPage(KeyakiController keyakiCtrl, List<Member> member,
            string keyakiOfficialBlog, string keyakiOfficialGoods) : this()
        {
            Master = new KeyakiMasterPage();
            Detail = new KeyakiDetailPage(keyakiCtrl, keyakiOfficialBlog, keyakiOfficialGoods);

            KeyakiDetailPage keyakiDetail = (KeyakiDetailPage)Detail;

            ((KeyakiMasterPage)Master).KeyakiListView.ItemsSource = new ObservableCollection<Member>(member);
            ((KeyakiMasterPage)Master).KeyakiListView.ItemSelected += (o, e) =>
            {
                IsPresented = false;
                keyakiDetail.selectedMember = (Member)e.SelectedItem;
                keyakiDetail.ChangeWebPage((Member)e.SelectedItem);
            };

            keyakiDetail.CurrentPageChanged += (o, e) =>
            {
                keyakiDetail.ChangeWebPage(keyakiDetail.selectedMember, keyakiOfficialBlog, keyakiOfficialGoods);
            };
        }
    }
}
