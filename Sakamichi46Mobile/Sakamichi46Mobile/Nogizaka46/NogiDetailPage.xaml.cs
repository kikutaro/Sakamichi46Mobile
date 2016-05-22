using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Sakamichi46Mobile.Nogizaka46
{
    public partial class NogiDetailPage : TabbedPage
    {
        public NogiDetailPage()
        {
            InitializeComponent();
        }

        public void ChangeWebPage(Member selectedMember)
        {
            nogiWeb.Source = selectedMember.blogUri;
        }
    }
}
