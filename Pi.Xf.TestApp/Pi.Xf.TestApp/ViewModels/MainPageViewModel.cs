using Pi.Xf.SimpleMvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Pi.Xf.TestApp.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {

        private ICommand _navigateToNextPageCommand;
        public ICommand NavigateToNextPageCommand
        {
            get { return _navigateToNextPageCommand; }
            set { Set(ref _navigateToNextPageCommand, value); }
        }

        public override Task OnNavigatedFrom(object param)
        {
            NavigateToNextPageCommand = new SimpleRelayCommand(async () =>
            {
                await NavigateTo("SecondPage","this is test");
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
