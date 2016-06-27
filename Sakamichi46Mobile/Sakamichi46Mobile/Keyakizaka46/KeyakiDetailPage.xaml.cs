﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Sakamichi46Mobile.Keyakizaka46
{
    public partial class KeyakiDetailPage : TabbedPage
    {
        public KeyakiDetailPage()
        {
            InitializeComponent();
        }

        public void ChangeWebPage(Member selectedMember)
        {
            keyakiWeb.Source = selectedMember.blogUri;
        }
    }
}