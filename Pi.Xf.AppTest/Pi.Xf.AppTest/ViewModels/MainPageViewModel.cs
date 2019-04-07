using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Pi.Xf.AppTest.ViewModels
{
    public class MainPageViewModel : Pi.Xf.SimpleMvvm.ViewModelBase
    {
		public MainPageViewModel()
		{
			Navigate = new Pi.Xf.SimpleMvvm.SimpleRelayCommand(() => base.NavigateTo("FirstPage","Test param"));
		}
		public ICommand Navigate { get; set; }

		private string _message;
		public string Message
		{
			get { return _message; }
			set { Set(ref _message, value); }
		}


		public override Task OnNavigatingTo()
		{
			Message = "Was navigated";
			return Task.Delay(2000);
		}

		public override Task OnNavigatedBack(object param)
		{
			Message = $"Navigated Back. {param?.ToString()}";
			return Task.CompletedTask;
		}
	}
}
