using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sakamichi46Mobile.Controller;
using Sakamichi46Mobile.Model;
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

        public NogiThirdMasterDetailPage(NogiController nogiThirdCtrl, List<Member> member, SakamichiUrl nogiThirdUrl) : this()
        {
            Master = new NogiThirdMasterPage();
            Detail = new NogiThirdDetailPage(nogiThirdCtrl, nogiThirdUrl);

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
                nogiThirdDetail.ChangeWebPage(nogiThirdDetail.selectedMember, nogiThirdUrl);
            };
        }

        public void OnSleep()
        {
            if(nogiThirdDetail != null) nogiThirdDetail.OnSleep();
        }
    }
}
