using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Sakamichi46Mobile.Graduate
{
    public partial class GraduateMemberPage : ContentPage
    {
        public GraduateMemberPage()
        {
            InitializeComponent();
        }

        public GraduateMemberPage(List<Member> listGraduate)
        {
            InitializeComponent();

            graduateMember.ItemsSource = listGraduate;
        }

        public void SelectGraduateMember(object sender, SelectedItemChangedEventArgs e)
        {
            if(e.SelectedItem != null)
            {
                Member member = (Member)e.SelectedItem;
                Navigation.PushModalAsync(new GuraduateMemberBlogPage(member.blogUri));
            }
        }
    }
}
