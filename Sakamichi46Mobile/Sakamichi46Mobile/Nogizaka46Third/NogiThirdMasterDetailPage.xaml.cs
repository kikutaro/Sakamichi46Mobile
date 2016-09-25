using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sakamichi46Mobile.Controller;
using Xamarin.Forms;

namespace Sakamichi46Mobile.Nogizaka46Third
{
    public partial class NogiThirdMasterDetailPage : MasterDetailPage
    {
        private NogiThirdDetailPage nogiThirdDetail;
        public NogiThirdMasterDetailPage()
        {
            InitializeComponent();
        }

        public NogiThirdMasterDetailPage(NogiController nogiThirdCtrl, List<Member> member,
            string nogiThirdOfficialBlog, string nogiThirdOfficialGoods) : this()
        {
            Master = new NogiThirdMasterPage();
            Detail = new NogiThirdDetailPage(nogiThirdCtrl, nogiThirdOfficialBlog, nogiThirdOfficialGoods);

            nogiThirdDetail = (NogiThirdDetailPage)Detail;

            ((NogiThirdMasterPage)Master).NogiThirdListView.ItemsSource = new ObservableCollection<Member>(member);
            ((NogiThirdMasterPage)Master).NogiThirdListView.ItemSelected += (o, e) =>
            {
                IsPresented = false;
                nogiThirdDetail.selectedMember = (Member)e.SelectedItem;
                nogiThirdDetail.ChangeWebPage((Member)e.SelectedItem);
            };

            nogiThirdDetail.CurrentPageChanged += (o, e) =>
            {
                nogiThirdDetail.ChangeWebPage(nogiThirdDetail.selectedMember, nogiThirdOfficialBlog, nogiThirdOfficialGoods);
            };
        }

        public void OnSleep()
        {
            if(nogiThirdDetail != null) nogiThirdDetail.OnSleep();
        }
    }
}
