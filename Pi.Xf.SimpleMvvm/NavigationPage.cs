﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Pi.Xf.SimpleMvvm
{
    public class NavigationPage : Xamarin.Forms.NavigationPage
    {
        public NavigationPage(ContentPage content) : base(content)
        {

            Popped += PagePopped;
            Pushed += PagePushed;
            content.Appearing += InitialPageAppearing;
        }

        private void InitialPageAppearing(object sender, EventArgs e)
        {
            var page = sender as Page;
            if (page == null)
                return;

            page.Appearing -= InitialPageAppearing;

            if (page.BindingContext is INavigationNotification nav)
            {
                nav.OnNavigatedFrom(nav.State);
            }

        }

        private void PagePushed(object sender, NavigationEventArgs e)
        {
            var indexOfPreviousPage = Application.Current.MainPage.Navigation.NavigationStack.Count - 2;
            if (indexOfPreviousPage >= 0)
            {
                var previousPage = Application.Current.MainPage.Navigation.NavigationStack[indexOfPreviousPage];
                if (previousPage != null && previousPage.BindingContext is INavigationNotification pnav)
                {
                    pnav.OnNavigatingTo();
                }
            }

            if (e.Page.BindingContext is INavigationNotification nav)
            {
                nav.OnNavigatedFrom(nav.State);
            }
        }

        private void PagePopped(object sender, NavigationEventArgs e)
        {
			var nav = e.Page.BindingContext as INavigationNotification;
			if (nav != null)
            {
                nav.OnNavigatingTo();
            }

            var currentPage = Application.Current.MainPage.Navigation.NavigationStack.LastOrDefault();

            if (currentPage != null && currentPage.BindingContext is INavigationNotification curNav)
            {
                curNav.OnNavigatedBack(nav?.State);
            }
        }
    }
}
