using System;
using System.Threading.Tasks;

namespace Pi.Xf.SimpleMvvm
{
    internal interface INavigationNotification
    {
        object State { get; set; }

        Task OnNavigatedFrom(object param);

        Task OnNavigatingTo();

        Task OnNavigatedBack(object param);

    }
}
