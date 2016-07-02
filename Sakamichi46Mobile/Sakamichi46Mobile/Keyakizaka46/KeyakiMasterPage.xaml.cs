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
    public partial class KeyakiMasterPage : ContentPage
    {
        public ListView KeyakiListView { get { return keyakiListView; } }

        public KeyakiMasterPage()
        {
            InitializeComponent();
        }
    }
}
