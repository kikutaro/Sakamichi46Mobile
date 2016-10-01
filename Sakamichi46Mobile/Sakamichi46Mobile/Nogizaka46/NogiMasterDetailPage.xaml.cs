using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sakamichi46Mobile.Controller;
using Sakamichi46Mobile.Model;
using Xamarin.Forms;

namespace Sakamichi46Mobile.Nogizaka46
{
    public partial class NogiMasterDetailPage : MasterDetailPage
    {
        private NogiDetailPage nogiDetail;
        public NogiMasterDetailPage()
        {
            InitializeComponent();
        }

        public NogiMasterDetailPage(NogiController nogiCtrl, List<Member> member, SakamichiUrl nogiUrl) : this()
        {
            Master = new NogiMasterPage();
            Detail = new NogiDetailPage(nogiCtrl, nogiUrl);

            nogiDetail = (NogiDetailPage)Detail;

            ((NogiMasterPage)Master).NogiListView.ItemsSource = new ObservableCollection<Member>(member);
            ((NogiMasterPage)Master).NogiListView.ItemSelected += (o, e) =>
            {
                IsPresented = false;
                nogiDetail.selectedMember = (Member)e.SelectedItem;
                nogiDetail.ChangeWebPage((Member)e.SelectedItem);
            };

            nogiDetail.CurrentPageChanged += (o, e) =>
            {
                nogiDetail.ChangeWebPage(nogiDetail.selectedMember, nogiUrl);
            };
        }

        public void OnSleep()
        {
            if(nogiDetail != null) nogiDetail.OnSleep();
        }
    }
}
