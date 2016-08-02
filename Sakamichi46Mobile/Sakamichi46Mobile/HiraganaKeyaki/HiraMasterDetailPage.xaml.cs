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
    public partial class HiraMasterDetailPage : MasterDetailPage
    {
        private HiraDetailPage hiraDetail;
        public HiraMasterDetailPage()
        {
            InitializeComponent();
        }

        public HiraMasterDetailPage(HiraController hiraCtrl, List<Member> member,
            string hiraOfficialBlog, string HiraOfficialGoods) : this()
        {
            Master = new HiraMasterPage();
            Detail = new HiraDetailPage(hiraCtrl, hiraOfficialBlog, HiraOfficialGoods);

            hiraDetail = (HiraDetailPage)Detail;

            ((HiraMasterPage)Master).HiraganaListView.ItemsSource = new ObservableCollection<Member>(member);
            ((HiraMasterPage)Master).HiraganaListView.ItemSelected += (o, e) =>
            {
                IsPresented = false;
                hiraDetail.selectedMember = (Member)e.SelectedItem;
                hiraDetail.ChangeWebPage((Member)e.SelectedItem);
            };

            hiraDetail.CurrentPageChanged += (o, e) =>
            {
                hiraDetail.ChangeWebPage(hiraDetail.selectedMember, hiraOfficialBlog, HiraOfficialGoods);
            };
        }

        public void OnSleep()
        {
            if (hiraDetail != null) hiraDetail.OnSleep();
        }

    }
}
