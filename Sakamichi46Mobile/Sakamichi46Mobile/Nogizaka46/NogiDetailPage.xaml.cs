﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sakamichi46Mobile.Constant;
using Sakamichi46Mobile.Controller;
using Xamarin.Forms;

namespace Sakamichi46Mobile.Nogizaka46
{
    public partial class NogiDetailPage : TabbedPage
    {
        private NogiController nogiCtrl;
        public Member selectedMember { get; set; }

        public NogiDetailPage()
        {
            InitializeComponent();
        }

        public NogiDetailPage(NogiController nogiCtrl) : this()
        {
            this.nogiCtrl = nogiCtrl;
        }

        private void InitWebPage()
        {
            nogiWebBlog.Source = nogiCtrl.GetOfficialBlog().Result;
            nogiWebGoods.Source = nogiCtrl.GetOfficialGoods().Result;
        }

        public void ChangeWebPage(Member selectedMember)
        {
            if(selectedMember == null)
            {
                InitWebPage();
                return;
            } 

            int tabIdx = Children.IndexOf(CurrentPage);
            if(tabIdx == 0)
            {
                nogiWebBlog.Source = this.selectedMember.blogUri;
            }
            else if(tabIdx == 1)
            {
                nogiWebGoods.Source = this.selectedMember.goodsUri;
            }
            else if(tabIdx == 2)
            {
                nogiWebYouTube.Source = UrlConst.YOUTUBE + this.selectedMember.name;
            }
            else if(tabIdx == 3)
            {
                nogiWikipedia.Source = UrlConst.WIKIPEDIA + this.selectedMember.name;
            }
        }
    }
}
