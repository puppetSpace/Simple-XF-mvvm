using Pi.Xf.SimpleMvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Pi.Xf.TestApp.ViewModels
{
    public class SecondPageViewModel : ViewModelBase
    {

        private ICommand _navigateBackCommand;
        public ICommand NavigateBackCommand
        {
            get { return _navigateBackCommand; }
            set { Set(ref _navigateBackCommand, value); }
        }

        public override Task OnNavigatedFrom(object param)
        {
            NavigateBackCommand = new SimpleRelayCommand(async () =>
            {
                await NavigateBack("Nog een test");
            });
            return base.OnNavigatedFrom(param);
        }

        public override Task OnNavigatedBack(object param)
        {
            return base.OnNavigatedBack(param);
        }

        public override Task OnNavigatingTo()
        {
            return base.OnNavigatingTo();
        }
    }
}
