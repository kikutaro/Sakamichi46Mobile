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
    public partial class NogiMasterDetailPage : MasterDetailPage
    {
        public NogiMasterDetailPage()
        {
            InitializeComponent();
        }

        public NogiMasterDetailPage(NogiController nogiCtrl, List<Member> member,
            string nogiOfficialBlog, string nogiOfficialGoods) : this()
        {
            Master = new NogiMasterPage();
            Detail = new NogiDetailPage(nogiCtrl, nogiOfficialBlog, nogiOfficialGoods);

            NogiDetailPage nogiDetail = (NogiDetailPage)Detail;

            ((NogiMasterPage)Master).NogiListView.ItemsSource = new ObservableCollection<Member>(member);
            ((NogiMasterPage)Master).NogiListView.ItemSelected += (o, e) =>
            {
                IsPresented = false;
                nogiDetail.selectedMember = (Member)e.SelectedItem;
                nogiDetail.ChangeWebPage((Member)e.SelectedItem);
            };

            nogiDetail.CurrentPageChanged += (o, e) =>
            {
                nogiDetail.ChangeWebPage(nogiDetail.selectedMember, nogiOfficialBlog, nogiOfficialGoods);
            };
        }
    }
}
