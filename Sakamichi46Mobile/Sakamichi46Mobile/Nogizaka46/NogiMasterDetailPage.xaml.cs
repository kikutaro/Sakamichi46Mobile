using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Sakamichi46Mobile.Nogizaka46
{
    public partial class NogiMasterDetailPage : MasterDetailPage
    {
        public NogiMasterDetailPage()
        {
            InitializeComponent();

            nogiMaster.NogiListView.ItemSelected += (o, e) =>
            {
                IsPresented = false;
                nogiDetail.ChangeWebPage((Member)e.SelectedItem);
            };
        }
    }
}
