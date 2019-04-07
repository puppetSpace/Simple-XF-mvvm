using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pi.Xf.AppTest.ViewModels
{
    public class FirstPageViewModel : Pi.Xf.SimpleMvvm.ViewModelBase
    {

		private string _message;

		public string Message
		{
			get { return _message; }
			set { Set(ref _message, value); }
		}


		public override Task OnNavigatedFrom(object param)
		{
			Message = $"Navigated to. {param?.ToString()}";
			State = "Test param back";
			return Task.CompletedTask;
		}
	}
}
