using System;
using System.Threading.Tasks;

namespace Pi.Xf.SimpleMvvm
{
    internal interface INavigationNotification
    {
        Task OnNavigatedFrom(object param);

        Task OnNavigatingTo();

        Task OnNavigatedBack(object param);

    }
}
