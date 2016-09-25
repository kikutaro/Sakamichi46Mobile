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
    public partial class NogiThirdMasterPage : ContentPage
    {
        public ListView NogiThirdListView { get { return nogiThirdListView; } }

        public NogiThirdMasterPage()
        {
            InitializeComponent();
        }
    }
}
