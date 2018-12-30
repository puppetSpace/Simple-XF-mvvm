using System;
using System.Threading.Tasks;

namespace Pi.Xf.SimpleMvvm
{
    internal interface INavigationNotification
    {
        Task OnNavigatedFrom(object param);

        Task OnNavigatedBack(object param);

    }
}
