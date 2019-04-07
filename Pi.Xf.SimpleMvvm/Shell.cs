using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Pi.Xf.SimpleMvvm
{
    public class Shell : Xamarin.Forms.Shell
    {

        public Shell()
        {
        }

        protected override void OnNavigating(ShellNavigatingEventArgs args)
        {
            //get route from args.Source
            var navigatedFromPage = Routing.GetOrCreateContent(args.Current.Location.AbsolutePath); 
            if(navigatedFromPage is INavigationNotification nav)
            {
                nav.OnNavigatingTo();
            }
        }

        protected override void OnNavigated(ShellNavigatedEventArgs args)
        {
            //get route from args.Current
            var navigatedToPage = Routing.GetOrCreateContent(args.Current.Location.AbsolutePath);
            if (navigatedToPage is INavigationNotification nav)
            {
                nav.OnNavigatedFrom(nav.State);
            }
        }
    }
}
